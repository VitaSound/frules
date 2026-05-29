#!/usr/bin/env bash
# Smoke all 15 Rosetta distill candidates under gforth (original or gforth/ fix).
set -euo pipefail
ROOT="$(cd "$(dirname "$0")/.." && pwd)"
GFORTH="${GFORTH:-gforth}"
ok=0 fail=0

run() {
  local label="$1" path="$2"
  if timeout 5 "$GFORTH" -e "include $path bye" &>/dev/null; then
    echo "ok   $label"
    ok=$((ok + 1))
  else
    echo "FAIL $label"
    fail=$((fail + 1))
  fi
}

run "Greatest-common-divisor" "$ROOT/Greatest-common-divisor/greatest-common-divisor.fth"
run "Least-common-multiple" "$ROOT/Least-common-multiple/least-common-multiple.fth"
run "Population-count" "$ROOT/Population-count/population-count.fth"
run "Fibonacci-sequence-1" "$ROOT/Fibonacci-sequence/fibonacci-sequence-1.fth"
run "FizzBuzz-1" "$ROOT/FizzBuzz/fizzbuzz-1.fth"
run "Parsing-RPN-1" "$ROOT/Parsing-RPN-calculator-algorithm/parsing-rpn-calculator-algorithm-1.fth"
run "Parsing-RPN-2-fixed" "$ROOT/gforth/parsing-rpn-calculator-algorithm-2.fth"
run "Singly-linked-list-push" "$ROOT/Singly-linked-list-Element-definition/singly-linked-list-element-definition-1.fth"
run "Levenshtein-distance" "$ROOT/Levenshtein-distance/levenshtein-distance.fth"
run "Towers-of-Hanoi-1" "$ROOT/Towers-of-Hanoi/towers-of-hanoi-1.fth"
run "Binary-search-fixed" "$ROOT/gforth/binary-search.fth"
run "Balanced-brackets-fixed" "$ROOT/gforth/balanced-brackets.fth"
run "Assertions-fixed" "$ROOT/gforth/assertions.fth"
run "Classes-minimal" "$ROOT/gforth/classes-minimal.fth"
run "Collections-minimal" "$ROOT/gforth/collections-minimal.fth"

echo "---"
echo "ok=$ok fail=$fail (of 15)"
test "$fail" -eq 0
