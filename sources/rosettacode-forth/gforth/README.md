# Gforth adaptations for Rosetta distill candidates (15 tasks)

Original vendored snippets live in `../<Task>/`. **Do not edit upstream copies.**

| # | Task | File here / upstream | Status |
|---|------|----------------------|--------|
| 1 | Greatest-common-divisor | `../Greatest-common-divisor/greatest-common-divisor.fth` | ok as-is |
| 2 | Least-common-multiple | `../Least-common-multiple/least-common-multiple.fth` | ok as-is |
| 3 | Population-count | `../Population-count/population-count.fth` | ok as-is |
| 4 | Fibonacci-sequence | `../Fibonacci-sequence/fibonacci-sequence-1.fth` | ok as-is |
| 5 | FizzBuzz | `../FizzBuzz/fizzbuzz-1.fth` | ok as-is |
| 6 | Parsing-RPN (one-liner) | `../Parsing-RPN-calculator-algorithm/parsing-rpn-calculator-algorithm-1.fth` | ok as-is |
| 7 | Parsing-RPN (detail) | `parsing-rpn-calculator-algorithm-2.fth` | fixed (non-interactive demo) |
| 8 | Singly-linked-list push | `../Singly-linked-list-Element-definition/singly-linked-list-element-definition-1.fth` | ok as-is |
| 9 | Levenshtein-distance | `../Levenshtein-distance/levenshtein-distance.fth` | ok as-is |
| 10 | Towers-of-Hanoi | `../Towers-of-Hanoi/towers-of-hanoi-1.fth` | ok as-is |
| 11 | Binary-search | `binary-search.fth` | fixed (`cell-`) |
| 12 | Balanced-brackets | `balanced-brackets.fth` | fixed (no `lib/`, no `\` line trap) |
| 13 | Assertions | `assertions.fth` | fixed (demo passes) |
| 14 | Classes | `classes-minimal.fth` | substitute (Rosetta uses non-Gforth OOP) |
| 15 | Collections | `collections-minimal.fth` | substitute (Rosetta needs `ffl/car.fs`) |

Smoke all: `bash smoke-all.sh`

Policy: minimal diff from Rosetta where possible; **substitute** when original needs missing libraries.
