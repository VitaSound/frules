#!/usr/bin/env bash
# Print first unchecked challenge from SOLVE-QUEUE.md (solve phase complete → QUEUE_EMPTY)
set -euo pipefail
ROOT="$(cd "$(dirname "$0")/.." && pwd)"
QUEUE="$ROOT/data/challenge-solutions/SOLVE-QUEUE.md"

if [[ ! -f "$QUEUE" ]]; then
  echo "Missing $QUEUE — run: python3 scripts/gen_solve_queue.py" >&2
  exit 1
fi

line="$(grep -m1 '^- \[ \]' "$QUEUE" || true)"
if [[ -z "$line" ]]; then
  echo "QUEUE_EMPTY"
  echo "STATUS=SOLVE_PHASE_COMPLETE"
  echo "NOTE=train_for_sft queue done; use eval_holdout for model validation (docs/CHALLENGE-TO-TRAIN.md)"
  exit 0
fi

# "- [ ] 004-sqrt-int.fs  (`isqrt`)"
file="$(echo "$line" | sed -n 's/^- \[ \] \([^ ]*\).*/\1/p')"
word="$(echo "$line" | sed -n 's/.*(`\([^`]*\)`).*/\1/p')"
echo "FILE=$file"
echo "WORD=$word"
echo "CHALLENGE=$ROOT/tests/challenges/$file"
echo "SOLUTION=$ROOT/data/challenge-solutions/$file"
