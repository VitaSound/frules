# Rosetta distill candidates → challenge bank

Fifteen smoke-tested Rosetta tasks from [`gforth-compat.yaml`](../../sources/rosettacode-forth/gforth-compat.yaml).

| # | Rosetta task | Bank challenge | Notes |
|---|--------------|----------------|-------|
| 1 | Greatest-common-divisor | `007-gcd.fs` | already in bank |
| 2 | Least-common-multiple | `008-lcm.fs` | already in bank |
| 3 | Population-count | `106-hamming-weight.fs` | same idiom (`hamming` = popcount) |
| 4 | Fibonacci-sequence | `006-fib-nth.fs` | already in bank |
| 5 | FizzBuzz | `116-fizzbuzz-count.fs` | different contract (line count) |
| 6 | Parsing-RPN (algorithm 1) | `034-eval-rpn.fs` | already in bank |
| 7 | Parsing-RPN (algorithm 2) | `034-eval-rpn.fs` | same skill; no separate challenge |
| 8 | Singly-linked-list push | `140-dict-list-push.fs` | **added** — dictionary-linked list |
| 9 | Levenshtein-distance | `134-edit-distance.fs` | DP contract differs from recursive Rosetta |
| 10 | Towers-of-Hanoi | `122-hanoi-moves.fs` | moves count, not print trace |
| 11 | Binary-search | `141-find-idx.fs` | **added** — index in sorted cell array |
| 12 | Balanced-brackets | `142-sq-brackets.fs` | **added** — `[` `]` only (Rosetta) |
| 13 | Assertions | `143-expect-match.fs` | **added** — expected-value check |
| 14 | Classes | `144-holder.fs` | **added** — `CREATE`/`DOES>` instance |
| 15 | Collections | `145-arr-sum.fs` | **added** — sum first u cells |

Gforth fixes for upstream-broken snippets: [`sources/rosettacode-forth/gforth/`](../../sources/rosettacode-forth/gforth/).
