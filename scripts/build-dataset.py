#!/usr/bin/env python3
"""
Build ShareGPT-style JSONL for Forth SFT from frules tests and examples.

Usage (from repo root):
  python3 scripts/build-dataset.py --sandbox
  python3 scripts/build-dataset.py --out data/train.jsonl
  python3 scripts/build-dataset.py --validate --sandbox

Does not include tests/challenges/ (eval hold-out).
"""

from __future__ import annotations

import argparse
import json
import re
import subprocess
import sys
from pathlib import Path
from shutil import which

ROOT = Path(__file__).resolve().parents[1]
RULES = ROOT / "rules"
DATA = ROOT / "data"

SYSTEM_FILES = (
    "forth-dialect-gforth.mdc",
    "forth-stack.mdc",
    "forth-anti-patterns.mdc",
)

SANDBOX_SOURCES: list[tuple[Path, str | None]] = [
    (ROOT / "tests" / "ans", None),
    (ROOT / "tests" / "gforth", None),
    (ROOT / "examples" / "gforth" / "good.fs", "good.fs"),
]

PROD_SOURCES = SANDBOX_SOURCES + [
    (ROOT / "examples" / "ans" / "portable.fs", "portable.fs"),
]

SANDBOX_SKIP_DUPES = {"clamp"}


def strip_mdc(text: str) -> str:
    if text.startswith("---"):
        end = text.find("---", 3)
        if end != -1:
            return text[end + 3 :].lstrip()
    return text


def build_system_prompt() -> str:
    parts = [
        "You write Gforth. Postfix Forth only — never C, Python, or infix.",
        (ROOT / "AGENTS.md").read_text(encoding="utf-8").strip(),
        "",
    ]
    for name in SYSTEM_FILES:
        path = RULES / name
        if path.is_file():
            parts.append(strip_mdc(path.read_text(encoding="utf-8")).strip())
            parts.append("")
    return "\n".join(parts).strip()


def header_spec(path: Path, text: str) -> str:
    lines = []
    for line in text.splitlines():
        if line.startswith("\\"):
            lines.append(line[1:].strip())
        elif line.strip() and not line.startswith(":"):
            break
        elif line.startswith(":"):
            break
    title = path.name
    body = "\n".join(lines).strip()
    return f"Source: {title}\n{body}" if body else f"Source: {title}"


def extract_words(text: str) -> list[tuple[str, str, str]]:
    lines = text.splitlines()
    out: list[tuple[str, str, str]] = []
    i = 0
    header_re = re.compile(r"^: (\S+)\s+(\([^)]+\))(.*)$")
    while i < len(lines):
        m = header_re.match(lines[i])
        if not m:
            i += 1
            continue
        name, effect, tail = m.group(1), m.group(2), m.group(3).strip()
        if tail.endswith(";"):
            out.append((name, effect, f": {name}  {effect}  {tail}".strip()))
            i += 1
            continue
        body_lines = [lines[i]]
        i += 1
        while i < len(lines):
            body_lines.append(lines[i])
            if ";" in lines[i]:
                break
            i += 1
        body = "\n".join(body_lines).strip()
        out.append((name, effect, body))
        i += 1
    return out


def make_record(
    *,
    system: str,
    spec: str,
    name: str,
    effect: str,
    body: str,
    source: str,
    record_type: str = "implement",
) -> dict:
    user = (
        f"Implement the Forth word `{name}` with stack effect {effect}.\n\n"
        f"{spec}\n\n"
        "Requirements:\n"
        "- Gforth\n"
        "- Stack-effect comment on every colon definition you add\n"
        "- Postfix Forth only\n"
        "- Output only the colon definition(s), no explanation"
    )
    return {
        "type": record_type,
        "source": source,
        "word": name,
        "messages": [
            {"role": "system", "content": system},
            {"role": "user", "content": user},
            {"role": "assistant", "content": body},
        ],
    }


def collect_from_file(
    path: Path,
    system: str,
    seen_words: set[str],
    skip_dupes: set[str],
) -> list[dict]:
    text = path.read_text(encoding="utf-8")
    spec = header_spec(path, text)
    records = []
    for name, effect, body in extract_words(text):
        if name in skip_dupes and name in seen_words:
            continue
        key = f"{path}:{name}"
        if key in seen_words:
            continue
        seen_words.add(key)
        records.append(
            make_record(
                system=system,
                spec=spec,
                name=name,
                effect=effect,
                body=body,
                source=str(path.relative_to(ROOT)),
            )
        )
    return records


def collect_sources(
    sources: list[tuple[Path, str | None]],
    skip_dupes: set[str],
) -> list[dict]:
    system = build_system_prompt()
    seen: set[str] = set()
    records: list[dict] = []
    for entry, single in sources:
        if single:
            path = entry
            if path.is_file():
                records.extend(
                    collect_from_file(path, system, seen, skip_dupes)
                )
            continue
        if not entry.is_dir():
            continue
        for path in sorted(entry.glob("*.fs")):
            if path.name.startswith("_"):
                continue
            records.extend(collect_from_file(path, system, seen, skip_dupes))
    return records


def validate_source_file(path: Path) -> bool:
    try:
        r = subprocess.run(
            ["gforth", path.name],
            cwd=path.parent,
            capture_output=True,
            text=True,
            timeout=30,
        )
        combined = r.stdout + r.stderr
        return r.returncode == 0 and "TESTS OK" in combined
    except (FileNotFoundError, subprocess.TimeoutExpired):
        return False


def validate_records(records: list[dict]) -> list[dict]:
    ok = []
    for rec in records:
        src = ROOT / rec["source"]
        if src.is_file() and validate_source_file(src):
            ok.append(rec)
        else:
            print(f"warn: validate skip {rec['source']}", file=sys.stderr)
    return ok


def write_jsonl(path: Path, records: list[dict]) -> None:
    path.parent.mkdir(parents=True, exist_ok=True)
    with path.open("w", encoding="utf-8") as f:
        for rec in records:
            f.write(json.dumps(rec, ensure_ascii=False) + "\n")


def main() -> int:
    ap = argparse.ArgumentParser(description="Build Forth SFT JSONL from frules")
    ap.add_argument("--sandbox", action="store_true", help="Sandbox subset")
    ap.add_argument("--out", type=Path, default=None, help="Output JSONL path")
    ap.add_argument(
        "--validate",
        action="store_true",
        help="Keep only records whose source .fs passes gforth",
    )
    args = ap.parse_args()

    sources = SANDBOX_SOURCES if args.sandbox else PROD_SOURCES
    skip_dupes = SANDBOX_SKIP_DUPES if args.sandbox else set()
    records = collect_sources(sources, skip_dupes)

    if args.validate:
        if not which("gforth"):
            print("error: gforth not in PATH", file=sys.stderr)
            return 1
        records = validate_records(records)

    out = args.out or (DATA / ("sandbox.jsonl" if args.sandbox else "train.jsonl"))
    write_jsonl(out, records)
    print(f"wrote {len(records)} records -> {out}")
    return 0


if __name__ == "__main__":
    sys.exit(main())
