#!/usr/bin/env bash
# Smoke: each challenge file must parse and fail on undefined challenge word.
set -euo pipefail
cd "$(dirname "$0")/../tests/challenges"
ok=0
fail=0
for f in 0[1-6]-*.fs [0-9][0-9][0-9]-*.fs; do
  [[ -f "$f" ]] || continue
  out=$(gforth "$f" 2>&1 || true)
  if echo "$out" | grep -qiE 'undefined word|uninitialized|not found'; then
    ok=$((ok + 1))
  elif echo "$out" | grep -qiE 'syntax error|error:|exception'; then
    echo "FAIL (syntax/load): $f"
    echo "$out" | tail -5
    fail=$((fail + 1))
  else
    echo "WARN (unexpected exit): $f"
    echo "$out" | tail -3
    fail=$((fail + 1))
  fi
done
echo "Smoke: $ok ok (undefined challenge word), $fail failed"
[[ "$fail" -eq 0 ]]
