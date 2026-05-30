#!/usr/bin/env python3
"""Repeat each JSONL line N times (oversample small train sets)."""
from __future__ import annotations

import argparse
import sys
from pathlib import Path


def main() -> int:
    ap = argparse.ArgumentParser(description="Repeat JSONL records")
    ap.add_argument("input", type=Path, help="Source JSONL")
    ap.add_argument("output", type=Path, help="Output JSONL")
    ap.add_argument("-n", "--times", type=int, default=5, help="Repeat factor (default 5)")
    args = ap.parse_args()
    if args.times < 1:
        print("error: --times must be >= 1", file=sys.stderr)
        return 1
    if not args.input.is_file():
        print(f"error: missing {args.input}", file=sys.stderr)
        return 1

    lines = [ln for ln in args.input.read_text(encoding="utf-8").splitlines() if ln.strip()]
    if not lines:
        print(f"error: empty {args.input}", file=sys.stderr)
        return 1

    out_lines = lines * args.times
    args.output.parent.mkdir(parents=True, exist_ok=True)
    args.output.write_text("\n".join(out_lines) + "\n", encoding="utf-8")
    print(f"wrote {len(out_lines)} lines ({len(lines)} x {args.times}) -> {args.output}")
    return 0


if __name__ == "__main__":
    sys.exit(main())
