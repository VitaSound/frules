#!/usr/bin/env python3
"""
Build SFT JSONL from verified challenge solutions in data/challenge-solutions/.

Only includes files listed in eval-slices.yaml -> train_for_sft.
Does NOT read tests/challenges/ for solutions (those stay empty for hold-out).

Usage:
  python3 scripts/build-challenge-dataset.py --validate
  python3 scripts/build-challenge-dataset.py --out data/challenge-train.jsonl
"""

from __future__ import annotations

import argparse
import json
import re
import subprocess
import sys
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
CH_DIR = ROOT / "tests" / "challenges"
SOL_DIR = ROOT / "data" / "challenge-solutions"
SLICES = CH_DIR / "eval-slices.yaml"
DATA = ROOT / "data"

import importlib.util

_bd_path = ROOT / "scripts" / "build-dataset.py"
_spec = importlib.util.spec_from_file_location("build_dataset", _bd_path)
assert _spec and _spec.loader
build_dataset = importlib.util.module_from_spec(_spec)
_spec.loader.exec_module(build_dataset)
build_system_prompt = build_dataset.build_system_prompt
make_record = build_dataset.make_record

MARKER_LO = "=== paste your solution below"
MARKER_HI = "=== paste your solution above"


def load_train_for_sft_files() -> list[str]:
    if not SLICES.is_file():
        print(f"error: missing {SLICES}; run gen_challenges.py first", file=sys.stderr)
        sys.exit(1)
    text = SLICES.read_text(encoding="utf-8")
    in_section = False
    files: list[str] = []
    for line in text.splitlines():
        if line.strip() == "train_for_sft:":
            in_section = True
            continue
        if in_section:
            if line.strip().endswith(":") and not line.strip().startswith("-"):
                if files:
                    break
                continue
            m = re.match(r"\s+-\s+(\S+\.fs)\s*$", line)
            if m:
                files.append(m.group(1))
    if not files:
        print("error: train_for_sft empty in eval-slices.yaml", file=sys.stderr)
        sys.exit(1)
    return files


def challenge_spec(challenge_path: Path) -> str:
    lines = []
    for line in challenge_path.read_text(encoding="utf-8").splitlines():
        if line.startswith("\\") and "paste your solution" in line:
            break
        if line.startswith("\\"):
            lines.append(line[1:].strip())
    return "\n".join(lines).strip()


def extract_solution_body(text: str) -> str | None:
    lo = text.find(MARKER_LO)
    hi = text.find(MARKER_HI)
    if lo == -1 or hi == -1 or hi <= lo:
        return None
    body = text[lo + len(MARKER_LO) : hi].strip()
    # drop marker comment lines
    body_lines = [
        ln
        for ln in body.splitlines()
        if not ln.strip().startswith("\\") or "paste" not in ln
    ]
    body = "\n".join(body_lines).strip()
    return body if body else None


def extract_challenge_word(challenge_path: Path) -> tuple[str, str] | None:
    text = challenge_path.read_text(encoding="utf-8")
    for line in text.splitlines():
        m = re.search(r":\s+(\S+)\s+(\([^)]+\))", line)
        if m and "Define a word" not in line:
            return m.group(1), m.group(2)
    return None


def gforth_ok(path: Path) -> bool:
    try:
        r = subprocess.run(
            ["gforth", str(path.resolve())],
            cwd=CH_DIR,
            capture_output=True,
            text=True,
            timeout=60,
        )
        out = r.stdout + r.stderr
        return r.returncode == 0 and "TESTS OK" in out
    except (FileNotFoundError, subprocess.TimeoutExpired):
        return False


def build_records(
    train_files: list[str], validate: bool, system_mode: str = "short"
) -> list[dict]:
    system = build_system_prompt(system_mode)
    records: list[dict] = []
    for fname in train_files:
        ch_path = CH_DIR / fname
        sol_path = SOL_DIR / fname
        if not ch_path.is_file():
            print(f"warn: missing challenge {ch_path}", file=sys.stderr)
            continue
        if not sol_path.is_file():
            print(f"warn: no solution {sol_path}", file=sys.stderr)
            continue
        if validate and not gforth_ok(sol_path):
            print(f"warn: gforth fail {sol_path}", file=sys.stderr)
            continue
        word_info = extract_challenge_word(ch_path)
        if not word_info:
            print(f"warn: no word in {ch_path}", file=sys.stderr)
            continue
        name, effect = word_info
        body = extract_solution_body(sol_path.read_text(encoding="utf-8"))
        if not body:
            print(f"warn: empty solution in {sol_path}", file=sys.stderr)
            continue
        spec = challenge_spec(ch_path)
        user_spec = (
            f"Challenge file: tests/challenges/{fname}\n\n{spec}\n\n"
            f"Implement `{name}` with stack effect {effect}."
        )
        records.append(
            {
                **make_record(
                    system=system,
                    spec=user_spec,
                    name=name,
                    effect=effect,
                    body=body,
                    source=f"data/challenge-solutions/{fname}",
                    record_type="challenge",
                ),
                "challenge_file": fname,
            }
        )
    return records


def main() -> int:
    ap = argparse.ArgumentParser()
    ap.add_argument("--out", type=Path, default=DATA / "challenge-train.jsonl")
    ap.add_argument(
        "--validate",
        action="store_true",
        help="Run gforth from tests/challenges on each solution file",
    )
    ap.add_argument(
        "--system",
        choices=("short", "full"),
        default="short",
        help="system prompt size (default short — fits 1024-token train window)",
    )
    args = ap.parse_args()
    train_files = load_train_for_sft_files()
    records = build_records(train_files, validate=args.validate, system_mode=args.system)
    args.out.parent.mkdir(parents=True, exist_ok=True)
    with args.out.open("w", encoding="utf-8") as f:
        for rec in records:
            f.write(json.dumps(rec, ensure_ascii=False) + "\n")
    print(f"wrote {len(records)} / {len(train_files)} records -> {args.out}  (system={args.system})")
    if len(records) < len(train_files):
        print(
            "hint: add solutions under data/challenge-solutions/ and use --validate",
            file=sys.stderr,
        )
        return 1 if len(records) == 0 else 0
    return 0


if __name__ == "__main__":
    sys.exit(main())
