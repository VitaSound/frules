#!/usr/bin/env bash
# Merge frules SFT JSONL for 0.5B "more data" run (same model, not hold-out).
set -euo pipefail
ROOT="$(cd "$(dirname "$0")/.." && pwd)"
cd "$ROOT"

CORE="${1:-data/train-core-validated.jsonl}"
OUT="${2:-data/train-merged.jsonl}"

echo "=== build train core (tests/ans, gforth — gforth TESTS OK) ==="
echo "    (one gforth run per source file; good.fs / portable.fs include T{ }T)"
python3 scripts/build-dataset.py --validate --out "$CORE"

echo "=== build challenge train (train_for_sft only) ==="
python3 scripts/build-challenge-dataset.py --validate

echo "=== merge -> $OUT ==="
cat "$CORE" data/challenge-train.jsonl > "$OUT"
wc -l "$CORE" data/challenge-train.jsonl "$OUT"
