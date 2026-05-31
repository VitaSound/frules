#!/usr/bin/env bash
# Smoke infer for Track A — same prompts as JSONL, basic Forth shape checks.
set -euo pipefail
ROOT="$(cd "$(dirname "$0")/.." && pwd)"
cd "$ROOT"

ADAPTER="${1:-output/sandbox-adapter-fixed}"
JSONL="${JSONL:-data/train-simple.jsonl}"
FAIL=0

check_word() {
  local word="$1"
  local out
  echo ""
  echo "======== $word ========"
  out="$(python3 training/infer-sandbox.py \
    --adapter "$ADAPTER" \
    --from-jsonl "$JSONL" \
    --word "$word" 2>/dev/null | sed -n '/^---/,$p' | tail -n +2)"
  echo "$out"

  if [[ "$out" != *": $word"* ]] && [[ "$out" != *":${word}"* ]]; then
    echo "FAIL: missing ': $word' header" >&2
    FAIL=1
  fi
  if [[ "$out" != *";"* ]]; then
    echo "FAIL: missing ';'" >&2
    FAIL=1
  fi
  if [[ "$out" == *'```'* ]] || [[ "$out" == *'return.'* ]]; then
    echo "FAIL: looks like pseudo-code / markdown" >&2
    FAIL=1
  fi

  local tmp
  tmp="$(mktemp --suffix=.fs)"
  printf '%s\n' "$out" > "$tmp"
  if gforth "$tmp" -e bye 2>/dev/null; then
    echo "gforth: compiles (no TESTS OK — snippet only)"
  else
    echo "WARN: gforth compile failed (may need context words)" >&2
  fi
  rm -f "$tmp"
}

echo "adapter: $ADAPTER"
echo "jsonl:   $JSONL"

check_word gcd
check_word factorial
check_word divisible?

if [[ "$FAIL" -ne 0 ]]; then
  echo ""
  echo "SMOKE: some shape checks failed (see above)."
  exit 1
fi
echo ""
echo "SMOKE: basic shape OK for gcd / factorial / divisible?"
