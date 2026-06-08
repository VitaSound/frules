#!/usr/bin/env python3
"""List train_for_sft challenges sorted by cognitive (ascending).

Usage:
  python3 scripts/benchmark_train_order.py
  python3 scripts/benchmark_train_order.py --json
  python3 scripts/benchmark_train_order.py --markdown
  python3 scripts/benchmark_train_order.py --markdown --results output/benchmark/RUN/results.jsonl
"""

from __future__ import annotations

import argparse
import json
import re
import sys
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
SLICES = ROOT / "tests/challenges/eval-slices.yaml"
MANIFEST = ROOT / "tests/challenges/manifest.yaml"


def _load_train_files() -> list[str]:
    text = SLICES.read_text(encoding="utf-8")
    in_train = False
    files: list[str] = []
    for line in text.splitlines():
        if re.match(r"^\s+train_for_sft:\s*$", line):
            in_train = False
        if line.strip() == "train_for_sft:":
            in_train = True
            continue
        if in_train:
            if re.match(r"^\s+eval_holdout:\s*$", line) or re.match(r"^\s+\w+:\s*$", line):
                if files:
                    break
            m = re.match(r"^\s+-\s+(\S+\.fs)\s*$", line)
            if m:
                files.append(m.group(1))
    if not files:
        raise SystemExit(f"no train_for_sft files in {SLICES}")
    return files


def _load_metadata() -> dict[str, dict[str, object]]:
    text = MANIFEST.read_text(encoding="utf-8")
    meta: dict[str, dict[str, object]] = {}
    blocks = re.split(r"\n  - id:", text)
    for block in blocks[1:]:
        fm = re.search(r'file:\s*"([^"]+)"', block)
        if not fm:
            continue
        file = fm.group(1)
        cm = re.search(r"cognitive:\s*(\d+)", block)
        tm = re.search(r'taxonomy_block:\s*(\S+)', block)
        wm = re.search(r'word:\s*(\S+)', block)
        meta[file] = {
            "cognitive": int(cm.group(1)) if cm else 99,
            "taxonomy_block": tm.group(1) if tm else "?",
            "word": wm.group(1) if wm else "?",
        }
    return meta


def build_rows() -> list[dict[str, object]]:
    train = _load_train_files()
    meta = _load_metadata()
    rows: list[dict[str, object]] = []
    for file in train:
        m = meta.get(file, {"cognitive": 99, "taxonomy_block": "?", "word": "?"})
        rows.append(
            {
                "file": file,
                "cognitive": m["cognitive"],
                "taxonomy_block": m["taxonomy_block"],
                "word": m["word"],
            }
        )
    rows.sort(key=lambda r: (int(r["cognitive"]), str(r["file"])))
    return rows


def load_verdicts(path: Path) -> dict[tuple[str, str], str]:
    out: dict[tuple[str, str], str] = {}
    if not path.is_file():
        return out
    for line in path.read_text(encoding="utf-8").splitlines():
        line = line.strip()
        if not line:
            continue
        rec = json.loads(line)
        arm = str(rec.get("arm", ""))
        file = str(rec.get("file", ""))
        verdict = str(rec.get("verdict", ""))
        if arm and file:
            out[(arm, file)] = verdict
    return out


def main() -> int:
    ap = argparse.ArgumentParser(description=__doc__)
    ap.add_argument("--json", action="store_true", help="JSON array")
    ap.add_argument("--markdown", action="store_true", help="Markdown table rows")
    ap.add_argument("--results", type=Path, default=None, help="results.jsonl for verdict columns")
    args = ap.parse_args()

    rows = build_rows()
    verdicts = load_verdicts(args.results) if args.results else {}

    if args.json:
        print(json.dumps(rows, ensure_ascii=False, indent=2))
        return 0

    if args.markdown:
        print("| cognitive | challenge | A bare | B +eco | C local |")
        print("|-----------|-----------|--------|--------|---------|")
        for r in rows:
            f = str(r["file"])
            c = r["cognitive"]
            a = verdicts.get(("cursor_auto_bare", f), "TBD")
            b = verdicts.get(("cursor_auto_eco", f), "TBD")
            loc = verdicts.get(("ollama_local", f), "TBD")
            print(f"| {c} | `{f}` | {a} | {b} | {loc} |")
        return 0

    print(f"# train_for_sft: {len(rows)} files (cognitive asc)\n")
    print("cognitive\tfile\tword\ttaxonomy")
    for r in rows:
        print(f"{r['cognitive']}\t{r['file']}\t{r['word']}\t{r['taxonomy_block']}")
    return 0


if __name__ == "__main__":
    sys.exit(main())
