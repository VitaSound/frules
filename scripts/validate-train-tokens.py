#!/usr/bin/env python3
"""
Check SFT JSONL rows fit max_seq_length (assistant not truncated).

  python3 scripts/validate-train-tokens.py data/train-merged.jsonl
  python3 scripts/validate-train-tokens.py data/train-simple.jsonl --max-seq 1024
"""

from __future__ import annotations

import argparse
import json
import sys
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
DEFAULT_MODEL = "Qwen/Qwen2.5-Coder-0.5B-Instruct"


def load_rows(path: Path) -> list[dict]:
    rows: list[dict] = []
    with path.open(encoding="utf-8") as f:
        for i, line in enumerate(f, 1):
            line = line.strip()
            if not line:
                continue
            obj = json.loads(line)
            if "messages" not in obj:
                raise SystemExit(f"{path}:{i}: missing messages")
            rows.append(obj)
    if not rows:
        raise SystemExit(f"empty: {path}")
    return rows


def token_stats(tokenizer, messages: list[dict]) -> dict:
    full_text = tokenizer.apply_chat_template(
        messages, tokenize=False, add_generation_prompt=False
    )
    full_ids = tokenizer.encode(full_text)
    prefix_text = tokenizer.apply_chat_template(
        messages[:-1], tokenize=False, add_generation_prompt=True
    )
    prefix_len = len(tokenizer.encode(prefix_text))
    assistant_len = len(tokenizer.encode(messages[-1]["content"]))
    return {
        "full": len(full_ids),
        "prefix": prefix_len,
        "assistant": assistant_len,
    }


def main() -> int:
    ap = argparse.ArgumentParser(description="Validate JSONL token lengths for SFT")
    ap.add_argument("jsonl", type=Path, help="Dataset JSONL path")
    ap.add_argument(
        "--max-seq",
        type=int,
        default=1024,
        help="Same as train-sandbox.py MAX_SEQ_LENGTH (default 1024)",
    )
    ap.add_argument("--model", default=DEFAULT_MODEL)
    ap.add_argument("--show-worst", type=int, default=5, help="Print N longest rows")
    args = ap.parse_args()

    path = args.jsonl if args.jsonl.is_absolute() else ROOT / args.jsonl
    if not path.is_file():
        raise SystemExit(f"missing: {path}")

    from transformers import AutoTokenizer

    tok = AutoTokenizer.from_pretrained(args.model, trust_remote_code=True)
    rows = load_rows(path)

    bad: list[tuple[int, dict, dict]] = []
    lengths: list[tuple[int, str, dict]] = []

    for i, row in enumerate(rows, 1):
        stats = token_stats(tok, row["messages"])
        label = row.get("word") or row.get("source") or f"line-{i}"
        lengths.append((stats["full"], str(label), stats))
        if stats["full"] > args.max_seq:
            bad.append((i, row, stats))

    lengths.sort(reverse=True)
    print(f"file: {path}")
    print(f"rows: {len(rows)}  max_seq: {args.max_seq}")
    print(
        f"tokens: min={min(x[0] for x in lengths)} "
        f"max={max(x[0] for x in lengths)} "
        f"median={sorted(x[0] for x in lengths)[len(lengths)//2]}"
    )

    n_show = min(args.show_worst, len(lengths))
    print(f"\nlongest {n_show}:")
    for full, label, stats in lengths[:n_show]:
        ok = "OK" if full <= args.max_seq else "TRUNCATED"
        print(
            f"  {full:4d} tok  prefix={stats['prefix']:4d}  "
            f"assistant={stats['assistant']:3d}  [{ok}]  {label}"
        )

    if bad:
        print(f"\nFAIL: {len(bad)} row(s) exceed max_seq={args.max_seq}", file=sys.stderr)
        for line_no, row, stats in bad[:10]:
            word = row.get("word", "?")
            print(
                f"  line {line_no}: {word} full={stats['full']} "
                f"(assistant starts at token {stats['prefix']})",
                file=sys.stderr,
            )
        print(
            "\nhint: rebuild with short system:\n"
            "  python3 scripts/build-dataset.py --validate --out data/train-simple.jsonl\n"
            "  FORCE_MERGE_BUILD=1 bash scripts/build-train-merged.sh",
            file=sys.stderr,
        )
        return 1

    print("\nOK: all rows fit within max_seq (assistant included in loss).")
    return 0


if __name__ == "__main__":
    sys.exit(main())
