#!/usr/bin/env bash
# Merge frules SFT JSONL for 0.5B (short system — fits MAX_SEQ_LENGTH=1024).
set -euo pipefail
ROOT="$(cd "$(dirname "$0")/.." && pwd)"
cd "$ROOT"

CORE="${1:-data/train-core-validated.jsonl}"
OUT="${2:-data/train-merged.jsonl}"
SYSTEM="${SYSTEM:-short}"

echo "=== build train core (tests/ans, gforth — gforth TESTS OK, system=$SYSTEM) ==="
python3 scripts/build-dataset.py --validate --system "$SYSTEM" --out "$CORE"

echo "=== build challenge train (train_for_sft only, system=$SYSTEM) ==="
python3 scripts/build-challenge-dataset.py --validate --system "$SYSTEM"

echo "=== merge -> $OUT ==="
cat "$CORE" data/challenge-train.jsonl > "$OUT"
wc -l "$CORE" data/challenge-train.jsonl "$OUT"

echo "=== validate token lengths ==="
python3 scripts/validate-train-tokens.py "$CORE" --max-seq 1024
if ! python3 scripts/validate-train-tokens.py "$OUT" --max-seq 2048; then
  echo "error: some rows exceed 2048 tokens" >&2
  exit 1
fi
if ! python3 scripts/validate-train-tokens.py "$OUT" --max-seq 1024 >/dev/null 2>&1; then
  echo "note: train-merged needs --max-seq 2048 (long challenge solutions)"
fi
