# Rosetta Code — Forth examples

Vendored Forth solutions from [Rosetta Code](https://rosettacode.org/wiki/Category:Forth),
via [acmeism/RosettaCodeData](https://github.com/acmeism/RosettaCodeData/tree/main/Lang/Forth).

**569 tasks**, **812** `.fth` files. Refresh: `bash fetch.sh` then `python3 gen-index.py`.

## Purpose in frules

| Use | Action |
|-----|--------|
| Challenge solve / eval | Read **ideas**; adapt to `WORD`, stack effect, Style guard — see [`challenge-links.yaml`](challenge-links.yaml) |
| Agent lookup | `python3 ../../scripts/rosettacode-hint.py tests/challenges/NNN-slug.fs` |
| Rules (`rules/*.mdc`) | **Ref only** — do not bulk-distill; wiki snippets vary in dialect/quality |
| Training SFT | **Not** a substitute for `data/challenge-solutions/` (no unified `T{ }T`) |

**License:** per-contributor on rosettacode.org. Do not assume one license when copying.

**Coverage legend** (challenge cross-ref `kind` in [`challenge-links.yaml`](challenge-links.yaml)):

| Tag | Meaning |
|-----|---------|
| `exact` | Same wiki task as bank `Source:` URL |
| `related` | Same algorithm family; contract may differ |
| `ref` | Loose inspiration — verify before reuse |
| `skip` | Games/graphics/demo — index only (~23 tasks auto-tagged) |

**Search:** `rg -l 'pattern' sources/rosettacode-forth/` · taxonomy tags: [`taxonomy-keywords.yaml`](taxonomy-keywords.yaml)

---

## By challenge taxonomy block

Auto-tagged by slug keywords ([`taxonomy-keywords.yaml`](taxonomy-keywords.yaml)).
Sample tasks per block (not exhaustive):

| Block | ~Tasks | Examples |
|-------|-------:|----------|
| `arrays-hash` | 26 | `Apply-a-callback-to-an-array`, `Array-concatenation`, `Array-length`, `Arrays`, `Associative-array-Creation` |
| `binary-search` | 1 | `Binary-search` |
| `bit-xor` | 4 | `Bitwise-IO`, `Bitwise-operations`, `Gray-code`, `Population-count` |
| `dynamic-programming` | 4 | `Knapsack-problem-0-1`, `Knapsack-problem-Continuous`, `Knapsack-problem-Unbounded`, `Levenshtein-distance` |
| `graph` | 6 | `Bitmap-Flood-fill`, `Dijkstras-algorithm`, `Hello-world-Graphical`, `Maze-generation`, `Sierpinski-triangle-Graphical` |
| `greedy` | 0 | — |
| `heap-topk` | 2 | `Priority-queue`, `Sorting-algorithms-Heapsort` |
| `linked-structure` | 4 | `Compare-a-list-of-strings`, `Singly-linked-list-Element-definition`, `Singly-linked-list-Element-insertion`, `Singly-linked-list-Traversal` |
| `matrix` | 6 | `Identity-matrix`, `Matrix-multiplication`, `Matrix-transposition`, `Sudoku`, `Ulam-spiral-for-primes-` |
| `parse-interpreter` | 11 | `Compiler-AST-interpreter`, `Compiler-virtual-machine-interpreter`, `Evaluate-binomial-coefficients`, `FizzBuzz`, `General-FizzBuzz` |
| `recursion` | 6 | `Ackermann-function`, `Anonymous-recursion`, `Find-limit-of-recursion`, `Mutual-recursion`, `Permutations-by-swapping` |
| `scalar-math` | 38 | `AKS-test-for-primes`, `Abundant-deficient-and-perfect-number-classifications`, `Ackermann-function`, `Additive-primes`, `Almost-prime` |
| `sliding-window` | 3 | `Simple-windowed-application`, `Window-creation`, `Window-creation-X11` |
| `stack-queue` | 7 | `Balanced-brackets`, `Parsing-RPN-calculator-algorithm`, `Priority-queue`, `Queue-Definition`, `Queue-Usage` |
| `strings` | 38 | `Binary-strings`, `Caesar-cipher`, `Comma-quibbling`, `Compare-a-list-of-strings`, `Compare-length-of-two-strings` |
| `trees-bst` | 6 | `Abstract-type`, `Count-occurrences-of-a-substring`, `Singly-linked-list-Traversal`, `Substring`, `Substring-Top-and-tail` |
| `trie-design` | 0 | — |
| `two-pointers` | 0 | — |

---

## By frules topic

| Rule file | ~Tasks | Notes |
|-----------|-------:|-------|
| `forth-c-bindings` | 5 | foreign function examples |
| `forth-control` | 20 | recursion, loops, permutations |
| `forth-debugging` | 1 | `Assertions` task |
| `forth-defining` | 2 | factories, closures (non-standard) |
| `forth-floating-point` | 24 | float demos (train bank avoids FP) |
| `forth-io` | 28 | files, CLI args |
| `forth-memory` | 15 | arrays, linked lists |
| `forth-meta` | 2 | interpreters, tokenizers |
| `forth-numeric` | 28 | primes, arithmetic puzzles |
| `forth-oof` | 21 | Classes/OOP samples — ref only |
| `forth-portability` | 8 | ANS notes in `00-LANG.txt` |
| `forth-stack` | 3 | RPN, stack juggling demos |
| `forth-strings` | 33 | parsing, encode/decode |
| `forth-wordlists` | 0 | see slug samples in catalog |

---

## Challenge bank cross-reference

Curated hints: bank file → Rosetta task dir(s). Extend [`challenge-links.yaml`](challenge-links.yaml)
when you find a good pair; re-run `gen-index.py`.

| Challenge | kind | Rosetta task(s) |
|-----------|------|-----------------|
| `001-reverse-int.fs` | ref | [`Reverse-a-string`](Reverse-a-string/) |
| `003-palindrome-num.fs` | related | [`Palindrome-detection`](Palindrome-detection/) |
| `004-sqrt-int.fs` | related | [`Isqrt-integer-square-root-of-X`](Isqrt-integer-square-root-of-X/) |
| `005-is-prime.fs` | related | [`Primality-by-trial-division`](Primality-by-trial-division/) |
| `006-fib-nth.fs` | exact | [`Fibonacci-sequence`](Fibonacci-sequence/) |
| `007-gcd.fs` | exact | [`Greatest-common-divisor`](Greatest-common-divisor/) |
| `008-lcm.fs` | exact | [`Least-common-multiple`](Least-common-multiple/) |
| `009-longest-common-prefix.fs` | ref | [`Substring`](Substring/) |
| `010-string-to-int.fs` | ref | [`Arithmetic-Integer`](Arithmetic-Integer/) |
| `012-count-and-say.fs` | ref | [`Look-and-say-sequence`](Look-and-say-sequence/) |
| `017-two-sum-pair.fs` | ref | [`Array-concatenation`](Array-concatenation/) |
| `018-remove-dup-sorted.fs` | related | [`Remove-duplicate-elements`](Remove-duplicate-elements/) |
| `019-remove-element.fs` | related | [`Remove-duplicate-elements`](Remove-duplicate-elements/) |
| `03-reverse-string.fs` | related | [`Reverse-a-string`](Reverse-a-string/) |
| `038-search-insert.fs` | related | [`Binary-search`](Binary-search/) |
| `039-search-rotated.fs` | ref | [`Binary-search`](Binary-search/) |
| `04-caesar-shift.fs` | related | [`Caesar-cipher`](Caesar-cipher/) |
| `045-merge-two-lists.fs` | ref | [`Sorting-algorithms-Merge-sort`](Sorting-algorithms-Merge-sort/) |
| `047-reverse-list.fs` | ref | [`Reverse-a-string`](Reverse-a-string/) |
| `05-balanced-parens.fs` | related | [`Balanced-brackets`](Balanced-brackets/) |
| `052-max-depth.fs` | related | [`Tree-traversal`](Tree-traversal/) |
| `054-same-tree.fs` | ref | [`Tree-traversal`](Tree-traversal/) |
| `06-roman.fs` | related | [`Roman-numerals-Encode`](Roman-numerals-Encode/), [`Roman-numerals-Decode`](Roman-numerals-Decode/) |
| `060-max-subarray.fs` | related | [`Greatest-subsequential-sum`](Greatest-subsequential-sum/) |
| `068-num-islands.fs` | related | [`Bitmap-Flood-fill`](Bitmap-Flood-fill/) |
| `070-shortest-path.fs` | ref | [`Dijkstras-algorithm`](Dijkstras-algorithm/) |
| `101-single-number.fs` | related | [`Population-count`](Population-count/), [`Bitwise-operations`](Bitwise-operations/) |
| `103-count-bits.fs` | related | [`Population-count`](Population-count/) |
| `106-hamming-weight.fs` | exact | [`Population-count`](Population-count/) |
| `112-calc-basic.fs` | ref | [`Parsing-RPN-calculator-algorithm`](Parsing-RPN-calculator-algorithm/) |
| `114-parse-int-hex.fs` | ref | [`Non-decimal-radices-Convert`](Non-decimal-radices-Convert/), [`Binary-digits`](Binary-digits/) |
| `116-fizzbuzz-count.fs` | exact | [`FizzBuzz`](FizzBuzz/), [`General-FizzBuzz`](General-FizzBuzz/) |
| `117-gen-parens-count.fs` | related | [`Balanced-brackets`](Balanced-brackets/) |
| `118-phone-combos.fs` | related | [`Permutations-by-swapping`](Permutations-by-swapping/) |
| `122-hanoi-moves.fs` | exact | [`Towers-of-Hanoi`](Towers-of-Hanoi/) |
| `134-edit-distance.fs` | related | [`Levenshtein-distance`](Levenshtein-distance/) |

Bank tasks **without** a row above: no curated Rosetta hint yet — use `rg` or taxonomy table.
Only **6** bank tasks use `source: rosetta`; the rest are LeetCode-style with optional Rosetta **related** snippets.

---

Smoke: `gforth -e "include sources/rosettacode-forth/<task>/<file> bye"` — **no edits** to Rosetta sources.
Policy: if **ok** → verbatim in `rules/`; if **broken**/**partial** → mark here + TODO; **do not fix** in vendored tree.
Machine-readable: [`gforth-compat.yaml`](gforth-compat.yaml).

| Task | File | Gforth | Rules | Note |
|------|------|--------|-------|------|
| `Greatest-common-divisor` | `greatest-common-divisor.fth` | **ok** | `forth-numeric` |  |
| `Least-common-multiple` | `least-common-multiple.fth` | **ok** | `forth-numeric` |  |
| `Population-count` | `population-count.fth` | **ok** | `forth-numeric` |  |
| `Fibonacci-sequence` | `fibonacci-sequence-1.fth` | **ok** | `forth-control` |  |
| `FizzBuzz` | `fizzbuzz-1.fth` | **ok** | `forth-defining` |  |
| `Parsing-RPN-calculator-algorithm` | `parsing-rpn-calculator-algorithm-1.fth` | **ok** | `forth-meta` |  |
| `Parsing-RPN-calculator-algorithm` | `parsing-rpn-calculator-algorithm-2.fth` | **fixed** | `forth-meta` | non-interactive demo; original hangs on bl word |
| `Singly-linked-list-Element-definition` | `singly-linked-list-element-definition-1.fth` | **ok** | `forth-memory` |  |
| `Levenshtein-distance` | `levenshtein-distance.fth` | **ok** | `forth-strings` |  |
| `Towers-of-Hanoi` | `towers-of-hanoi-1.fth` | **ok** | `forth-control` |  |
| `Binary-search` | `binary-search.fth` | **fixed** | `forth-memory` | original uses -cell; gforth/ uses find-idx linear search |
| `Balanced-brackets` | `balanced-brackets.fth` | **fixed** | `forth-control` | no lib/choose; [char] \ line trap removed |
| `Assertions` | `assertions.fth` | **fixed** | `forth-debugging` | demo uses 42 so assert passes |
| `Classes` | `classes-minimal.fth` | **substitute** | `forth-defining` | CREATE/DOES> stub; original uses ;class OOP |
| `Collections` | `collections-minimal.fth` | **substitute** | `forth-memory` | fixed array demo; original needs ffl/car.fs |

**Distilled (verbatim, ok):** 9 → `rules/forth-*.mdc`.
**Gforth fixes (`gforth/`):** 6 — run `bash gforth/smoke-all.sh` (15/15). Upstream `../` untouched.

Policy: do **not** patch vendored Rosetta originals; use [`gforth/`](gforth/README.md) for adaptations.

---

## Related frules docs

| File | Role |
|------|------|
| [`docs/SOURCES.md`](../../docs/SOURCES.md) | Provenance row |
| [`docs/AGENT-SOLVE-CHALLENGES.md`](../../docs/AGENT-SOLVE-CHALLENGES.md) | May read `sources/rosettacode-forth/` when solving |
| [`docs/CHALLENGE-TO-TRAIN.md`](../../docs/CHALLENGE-TO-TRAIN.md) | Train vs hold-out; Rosetta is hint, not gold |
| [`docs/CHALLENGE-RUNS.md`](../../docs/CHALLENGE-RUNS.md) | Blind eval: deny `sources/` unless allowed |
| [`rules/frules-index.mdc`](../../rules/frules-index.mdc) | Topic routing + Rosetta lookup row |
| [`sources/theforth.net-packages/INDEX.md`](../theforth.net-packages/INDEX.md) | Libraries (prefer for reusable words) |
| [`TODO.md`](../../TODO.md) | Integration checklist |

**Status:** indexed 569 tasks · challenge-links 36 entries · distill **done** · gforth smoke **15/15**

---

## Full task catalog

| Task | Files | Wiki |
|------|-------|------|
| `100-doors` | 100-doors-1.fth, 100-doors-2.fth | [100-doors](https://rosettacode.org/wiki/100_doors) |
| `100-prisoners` | 100-prisoners.fth | [100-prisoners](https://rosettacode.org/wiki/100_prisoners) |
| `15-puzzle-game` | 15-puzzle-game.fth | [15-puzzle-game](https://rosettacode.org/wiki/15_puzzle_game) |
| `15-puzzle-solver` | 15-puzzle-solver.fth | [15-puzzle-solver](https://rosettacode.org/wiki/15_puzzle_solver) |
| `2048` | 2048.fth | [2048](https://rosettacode.org/wiki/2048) |
| `21-game` | 21-game.fth | [21-game](https://rosettacode.org/wiki/21_game) |
| `99-bottles-of-beer` | 99-bottles-of-beer-1.fth, 99-bottles-of-beer-2.fth, 99-bottles-of-beer-3.fth | [99-bottles-of-beer](https://rosettacode.org/wiki/99_bottles_of_beer) |
| `A+B` | a+b-1.fth, a+b-2.fth | [A+B](https://rosettacode.org/wiki/A+B) |
| `ABC-problem` | abc-problem.fth | [ABC-problem](https://rosettacode.org/wiki/ABC_problem) |
| `AKS-test-for-primes` | aks-test-for-primes.fth | [AKS-test-for-primes](https://rosettacode.org/wiki/AKS_test_for_primes) |
| `Abbreviations-simple` | abbreviations-simple.fth | [Abbreviations-simple](https://rosettacode.org/wiki/Abbreviations_simple) |
| `Abelian-sandpile-model` | abelian-sandpile-model.fth | [Abelian-sandpile-model](https://rosettacode.org/wiki/Abelian_sandpile_model) |
| `Abstract-type` | abstract-type-1.fth, abstract-type-2.fth | [Abstract-type](https://rosettacode.org/wiki/Abstract_type) |
| `Abundant-deficient-and-perfect-number-classifications` | abundant-deficient-and-perfect-number-classifications.fth | [Abundant-deficient-and-perfect-number-classifications](https://rosettacode.org/wiki/Abundant_deficient_and_perfect_number_classifications) |
| `Accumulator-factory` | accumulator-factory-1.fth, accumulator-factory-2.fth | [Accumulator-factory](https://rosettacode.org/wiki/Accumulator_factory) |
| `Ackermann-function` | ackermann-function-1.fth, ackermann-function-2.fth | [Ackermann-function](https://rosettacode.org/wiki/Ackermann_function) |
| `Add-a-variable-to-a-class-instance-at-runtime` | add-a-variable-to-a-class-instance-at-runtime.fth | [Add-a-variable-to-a-class-instance-at-runtime](https://rosettacode.org/wiki/Add_a_variable_to_a_class_instance_at_runtime) |
| `Additive-primes` | additive-primes.fth | [Additive-primes](https://rosettacode.org/wiki/Additive_primes) |
| `Align-columns` | align-columns.fth | [Align-columns](https://rosettacode.org/wiki/Align_columns) |
| `Almost-prime` | almost-prime.fth | [Almost-prime](https://rosettacode.org/wiki/Almost_prime) |
| `Amicable-pairs` | amicable-pairs-1.fth, amicable-pairs-2.fth | [Amicable-pairs](https://rosettacode.org/wiki/Amicable_pairs) |
| `Angle-difference-between-two-bearings` | angle-difference-between-two-bearings.fth | [Angle-difference-between-two-bearings](https://rosettacode.org/wiki/Angle_difference_between_two_bearings) |
| `Anonymous-recursion` | anonymous-recursion-1.fth, anonymous-recursion-2.fth, anonymous-recursion-3.fth | [Anonymous-recursion](https://rosettacode.org/wiki/Anonymous_recursion) |
| `Anti-primes` | anti-primes.fth | [Anti-primes](https://rosettacode.org/wiki/Anti_primes) |
| `Apply-a-callback-to-an-array` | apply-a-callback-to-an-array-1.fth, apply-a-callback-to-an-array-2.fth | [Apply-a-callback-to-an-array](https://rosettacode.org/wiki/Apply_a_callback_to_an_array) |
| `Approximate-equality` | approximate-equality.fth | [Approximate-equality](https://rosettacode.org/wiki/Approximate_equality) |
| `Arbitrary-precision-integers-included-` | arbitrary-precision-integers-included-.fth | [Arbitrary-precision-integers-included-](https://rosettacode.org/wiki/Arbitrary_precision_integers_included_) |
| `Arithmetic-Complex` | arithmetic-complex.fth | [Arithmetic-Complex](https://rosettacode.org/wiki/Arithmetic_Complex) |
| `Arithmetic-Integer` | arithmetic-integer-1.fth, arithmetic-integer-2.fth, arithmetic-integer-3.fth | [Arithmetic-Integer](https://rosettacode.org/wiki/Arithmetic_Integer) |
| `Arithmetic-Rational` | arithmetic-rational.fth | [Arithmetic-Rational](https://rosettacode.org/wiki/Arithmetic_Rational) |
| `Arithmetic-geometric-mean` | arithmetic-geometric-mean.fth | [Arithmetic-geometric-mean](https://rosettacode.org/wiki/Arithmetic_geometric_mean) |
| `Array-concatenation` | array-concatenation.fth | [Array-concatenation](https://rosettacode.org/wiki/Array_concatenation) |
| `Array-length` | array-length-1.fth, array-length-2.fth | [Array-length](https://rosettacode.org/wiki/Array_length) |
| `Arrays` | arrays-1.fth, arrays-2.fth, arrays-3.fth | [Arrays](https://rosettacode.org/wiki/Arrays) |
| `Ascending-primes` | ascending-primes.fth | [Ascending-primes](https://rosettacode.org/wiki/Ascending_primes) |
| `Assertions` | assertions.fth | [Assertions](https://rosettacode.org/wiki/Assertions) |
| `Associative-array-Creation` | associative-array-creation-1.fth, associative-array-creation-2.fth, associative-array-creation-3.fth | [Associative-array-Creation](https://rosettacode.org/wiki/Associative_array_Creation) |
| `Associative-array-Iteration` | associative-array-iteration-1.fth, associative-array-iteration-2.fth | [Associative-array-Iteration](https://rosettacode.org/wiki/Associative_array_Iteration) |
| `Averages-Arithmetic-mean` | averages-arithmetic-mean.fth | [Averages-Arithmetic-mean](https://rosettacode.org/wiki/Averages_Arithmetic_mean) |
| `Averages-Median` | averages-median-1.fth, averages-median-2.fth | [Averages-Median](https://rosettacode.org/wiki/Averages_Median) |
| `Averages-Pythagorean-means` | averages-pythagorean-means.fth | [Averages-Pythagorean-means](https://rosettacode.org/wiki/Averages_Pythagorean_means) |
| `Averages-Root-mean-square` | averages-root-mean-square.fth | [Averages-Root-mean-square](https://rosettacode.org/wiki/Averages_Root_mean_square) |
| `Averages-Simple-moving-average` | averages-simple-moving-average.fth | [Averages-Simple-moving-average](https://rosettacode.org/wiki/Averages_Simple_moving_average) |
| `Babbage-problem` | babbage-problem.fth | [Babbage-problem](https://rosettacode.org/wiki/Babbage_problem) |
| `Balanced-brackets` | balanced-brackets.fth | [Balanced-brackets](https://rosettacode.org/wiki/Balanced_brackets) |
| `Barnsley-fern` | barnsley-fern-1.fth, barnsley-fern-2.fth | [Barnsley-fern](https://rosettacode.org/wiki/Barnsley_fern) |
| `Base64-decode-data` | base64-decode-data.fth | [Base64-decode-data](https://rosettacode.org/wiki/Base64_decode_data) |
| `Bell-numbers` | bell-numbers.fth | [Bell-numbers](https://rosettacode.org/wiki/Bell_numbers) |
| `Benfords-law` | benfords-law.fth | [Benfords-law](https://rosettacode.org/wiki/Benfords_law) |
| `Binary-digits` | binary-digits.fth | [Binary-digits](https://rosettacode.org/wiki/Binary_digits) |
| `Binary-search` | binary-search.fth | [Binary-search](https://rosettacode.org/wiki/Binary_search) |
| `Binary-strings` | binary-strings-1.fth, binary-strings-2.fth | [Binary-strings](https://rosettacode.org/wiki/Binary_strings) |
| `Bitmap` | bitmap.fth | [Bitmap](https://rosettacode.org/wiki/Bitmap) |
| `Bitmap-Bresenhams-line-algorithm` | bitmap-bresenhams-line-algorithm.fth | [Bitmap-Bresenhams-line-algorithm](https://rosettacode.org/wiki/Bitmap_Bresenhams_line_algorithm) |
| `Bitmap-Flood-fill` | bitmap-flood-fill.fth | [Bitmap-Flood-fill](https://rosettacode.org/wiki/Bitmap_Flood_fill) |
| `Bitmap-Histogram` | bitmap-histogram.fth | [Bitmap-Histogram](https://rosettacode.org/wiki/Bitmap_Histogram) |
| `Bitmap-Midpoint-circle-algorithm` | bitmap-midpoint-circle-algorithm.fth | [Bitmap-Midpoint-circle-algorithm](https://rosettacode.org/wiki/Bitmap_Midpoint_circle_algorithm) |
| `Bitmap-Read-a-PPM-file` | bitmap-read-a-ppm-file.fth | [Bitmap-Read-a-PPM-file](https://rosettacode.org/wiki/Bitmap_Read_a_PPM_file) |
| `Bitmap-Write-a-PPM-file` | bitmap-write-a-ppm-file.fth | [Bitmap-Write-a-PPM-file](https://rosettacode.org/wiki/Bitmap_Write_a_PPM_file) |
| `Bitwise-IO` | bitwise-io.fth | [Bitwise-IO](https://rosettacode.org/wiki/Bitwise_IO) |
| `Bitwise-operations` | bitwise-operations.fth | [Bitwise-operations](https://rosettacode.org/wiki/Bitwise_operations) |
| `Boolean-values` | boolean-values.fth | [Boolean-values](https://rosettacode.org/wiki/Boolean_values) |
| `Brazilian-numbers` | brazilian-numbers.fth | [Brazilian-numbers](https://rosettacode.org/wiki/Brazilian_numbers) |
| `Break-OO-privacy` | break-oo-privacy.fth | [Break-OO-privacy](https://rosettacode.org/wiki/Break_OO_privacy) |
| `Bulls-and-cows` | bulls-and-cows.fth | [Bulls-and-cows](https://rosettacode.org/wiki/Bulls_and_cows) |
| `CRC-32` | crc-32.fth | [CRC-32](https://rosettacode.org/wiki/CRC_32) |
| `CSV-data-manipulation` | csv-data-manipulation.fth | [CSV-data-manipulation](https://rosettacode.org/wiki/CSV_data_manipulation) |
| `CSV-to-HTML-translation` | csv-to-html-translation-1.fth, csv-to-html-translation-2.fth | [CSV-to-HTML-translation](https://rosettacode.org/wiki/CSV_to_HTML_translation) |
| `Caesar-cipher` | caesar-cipher.fth | [Caesar-cipher](https://rosettacode.org/wiki/Caesar_cipher) |
| `Calculating-the-value-of-e` | calculating-the-value-of-e.fth | [Calculating-the-value-of-e](https://rosettacode.org/wiki/Calculating_the_value_of_e) |
| `Calendar` | calendar.fth | [Calendar](https://rosettacode.org/wiki/Calendar) |
| `Calendar---for-REAL-programmers` | calendar---for-real-programmers.fth | [Calendar---for-REAL-programmers](https://rosettacode.org/wiki/Calendar___for_REAL_programmers) |
| `Calkin-Wilf-sequence` | calkin-wilf-sequence.fth | [Calkin-Wilf-sequence](https://rosettacode.org/wiki/Calkin_Wilf_sequence) |
| `Call-a-foreign-language-function` | call-a-foreign-language-function.fth | [Call-a-foreign-language-function](https://rosettacode.org/wiki/Call_a_foreign_language_function) |
| `Call-a-function` | call-a-function.fth | [Call-a-function](https://rosettacode.org/wiki/Call_a_function) |
| `Call-a-function-in-a-shared-library` | call-a-function-in-a-shared-library.fth | [Call-a-function-in-a-shared-library](https://rosettacode.org/wiki/Call_a_function_in_a_shared_library) |
| `Call-an-object-method` | call-an-object-method-1.fth, call-an-object-method-2.fth | [Call-an-object-method](https://rosettacode.org/wiki/Call_an_object_method) |
| `Cantor-set` | cantor-set.fth | [Cantor-set](https://rosettacode.org/wiki/Cantor_set) |
| `Case-sensitivity-of-identifiers` | case-sensitivity-of-identifiers.fth | [Case-sensitivity-of-identifiers](https://rosettacode.org/wiki/Case_sensitivity_of_identifiers) |
| `Catalan-numbers` | catalan-numbers.fth | [Catalan-numbers](https://rosettacode.org/wiki/Catalan_numbers) |
| `Catamorphism` | catamorphism-1.fth, catamorphism-2.fth, catamorphism-3.fth, catamorphism-4.fth, catamorphism-5.fth | [Catamorphism](https://rosettacode.org/wiki/Catamorphism) |
| `Chaocipher` | chaocipher.fth | [Chaocipher](https://rosettacode.org/wiki/Chaocipher) |
| `Chaos-game` | chaos-game.fth | [Chaos-game](https://rosettacode.org/wiki/Chaos_game) |
| `Character-codes` | character-codes.fth | [Character-codes](https://rosettacode.org/wiki/Character_codes) |
| `Check-input-device-is-a-terminal` | check-input-device-is-a-terminal-1.fth, check-input-device-is-a-terminal-2.fth, check-input-device-is-a-terminal-3.fth, check-input-device-is-a-terminal-4.fth | [Check-input-device-is-a-terminal](https://rosettacode.org/wiki/Check_input_device_is_a_terminal) |
| `Check-that-file-exists` | check-that-file-exists.fth | [Check-that-file-exists](https://rosettacode.org/wiki/Check_that_file_exists) |
| `Chinese-remainder-theorem` | chinese-remainder-theorem.fth | [Chinese-remainder-theorem](https://rosettacode.org/wiki/Chinese_remainder_theorem) |
| `Chinese-zodiac` | chinese-zodiac.fth | [Chinese-zodiac](https://rosettacode.org/wiki/Chinese_zodiac) |
| `Circular-primes` | circular-primes.fth | [Circular-primes](https://rosettacode.org/wiki/Circular_primes) |
| `Classes` | classes-1.fth, classes-2.fth, classes-3.fth, classes-4.fth, classes-5.fth, classes-6.fth, classes-7.fth | [Classes](https://rosettacode.org/wiki/Classes) |
| `Closures-Value-capture` | closures-value-capture-1.fth, closures-value-capture-2.fth | [Closures-Value-capture](https://rosettacode.org/wiki/Closures_Value_capture) |
| `Collections` | collections-1.fth, collections-2.fth, collections-3.fth | [Collections](https://rosettacode.org/wiki/Collections) |
| `Colour-bars-Display` | colour-bars-display.fth | [Colour-bars-Display](https://rosettacode.org/wiki/Colour_bars_Display) |
| `Comma-quibbling` | comma-quibbling.fth | [Comma-quibbling](https://rosettacode.org/wiki/Comma_quibbling) |
| `Command-line-arguments` | command-line-arguments-1.fth, command-line-arguments-2.fth | [Command-line-arguments](https://rosettacode.org/wiki/Command_line_arguments) |
| `Comments` | comments-1.fth, comments-2.fth, comments-3.fth, comments-4.fth | [Comments](https://rosettacode.org/wiki/Comments) |
| `Compare-a-list-of-strings` | compare-a-list-of-strings-1.fth, compare-a-list-of-strings-2.fth | [Compare-a-list-of-strings](https://rosettacode.org/wiki/Compare_a_list_of_strings) |
| `Compare-length-of-two-strings` | compare-length-of-two-strings.fth | [Compare-length-of-two-strings](https://rosettacode.org/wiki/Compare_length_of_two_strings) |
| `Compile-time-calculation` | compile-time-calculation-1.fth, compile-time-calculation-2.fth | [Compile-time-calculation](https://rosettacode.org/wiki/Compile_time_calculation) |
| `Compiler-AST-interpreter` | compiler-ast-interpreter.fth | [Compiler-AST-interpreter](https://rosettacode.org/wiki/Compiler_AST_interpreter) |
| `Compiler-code-generator` | compiler-code-generator.fth | [Compiler-code-generator](https://rosettacode.org/wiki/Compiler_code_generator) |
| `Compiler-lexical-analyzer` | compiler-lexical-analyzer.fth | [Compiler-lexical-analyzer](https://rosettacode.org/wiki/Compiler_lexical_analyzer) |
| `Compiler-syntax-analyzer` | compiler-syntax-analyzer.fth | [Compiler-syntax-analyzer](https://rosettacode.org/wiki/Compiler_syntax_analyzer) |
| `Compiler-virtual-machine-interpreter` | compiler-virtual-machine-interpreter.fth | [Compiler-virtual-machine-interpreter](https://rosettacode.org/wiki/Compiler_virtual_machine_interpreter) |
| `Compound-data-type` | compound-data-type-1.fth, compound-data-type-2.fth | [Compound-data-type](https://rosettacode.org/wiki/Compound_data_type) |
| `Concurrent-computing` | concurrent-computing.fth | [Concurrent-computing](https://rosettacode.org/wiki/Concurrent_computing) |
| `Conditional-structures` | conditional-structures-1.fth, conditional-structures-2.fth, conditional-structures-3.fth, conditional-structures-4.fth, conditional-structures-5.fth, conditional-structures-6.fth | [Conditional-structures](https://rosettacode.org/wiki/Conditional_structures) |
| `Constrained-genericity` | constrained-genericity.fth | [Constrained-genericity](https://rosettacode.org/wiki/Constrained_genericity) |
| `Constrained-random-points-on-a-circle` | constrained-random-points-on-a-circle.fth | [Constrained-random-points-on-a-circle](https://rosettacode.org/wiki/Constrained_random_points_on_a_circle) |
| `Continued-fraction` | continued-fraction.fth | [Continued-fraction](https://rosettacode.org/wiki/Continued_fraction) |
| `Continued-fraction-Arithmetic-Construct-from-rational-number` | continued-fraction-arithmetic-construct-from-rational-number.fth | [Continued-fraction-Arithmetic-Construct-from-rational-number](https://rosettacode.org/wiki/Continued_fraction_Arithmetic_Construct_from_rational_number) |
| `Convert-decimal-number-to-rational` | convert-decimal-number-to-rational-1.fth, convert-decimal-number-to-rational-2.fth | [Convert-decimal-number-to-rational](https://rosettacode.org/wiki/Convert_decimal_number_to_rational) |
| `Convert-seconds-to-compound-duration` | convert-seconds-to-compound-duration.fth | [Convert-seconds-to-compound-duration](https://rosettacode.org/wiki/Convert_seconds_to_compound_duration) |
| `Conways-Game-of-Life` | conways-game-of-life.fth | [Conways-Game-of-Life](https://rosettacode.org/wiki/Conways_Game_of_Life) |
| `Copy-a-string` | copy-a-string.fth | [Copy-a-string](https://rosettacode.org/wiki/Copy_a_string) |
| `Copy-stdin-to-stdout` | copy-stdin-to-stdout.fth | [Copy-stdin-to-stdout](https://rosettacode.org/wiki/Copy_stdin_to_stdout) |
| `Count-in-factors` | count-in-factors.fth | [Count-in-factors](https://rosettacode.org/wiki/Count_in_factors) |
| `Count-in-octal` | count-in-octal.fth | [Count-in-octal](https://rosettacode.org/wiki/Count_in_octal) |
| `Count-occurrences-of-a-substring` | count-occurrences-of-a-substring.fth | [Count-occurrences-of-a-substring](https://rosettacode.org/wiki/Count_occurrences_of_a_substring) |
| `Count-the-coins` | count-the-coins.fth | [Count-the-coins](https://rosettacode.org/wiki/Count_the_coins) |
| `Create-a-file` | create-a-file.fth | [Create-a-file](https://rosettacode.org/wiki/Create_a_file) |
| `Create-a-two-dimensional-array-at-runtime` | create-a-two-dimensional-array-at-runtime-1.fth, create-a-two-dimensional-array-at-runtime-2.fth | [Create-a-two-dimensional-array-at-runtime](https://rosettacode.org/wiki/Create_a_two_dimensional_array_at_runtime) |
| `Create-an-HTML-table` | create-an-html-table.fth | [Create-an-HTML-table](https://rosettacode.org/wiki/Create_an_HTML_table) |
| `Create-an-object-at-a-given-address` | create-an-object-at-a-given-address.fth | [Create-an-object-at-a-given-address](https://rosettacode.org/wiki/Create_an_object_at_a_given_address) |
| `Cuban-primes` | cuban-primes.fth | [Cuban-primes](https://rosettacode.org/wiki/Cuban_primes) |
| `Cumulative-standard-deviation` | cumulative-standard-deviation-1.fth, cumulative-standard-deviation-2.fth, cumulative-standard-deviation-3.fth | [Cumulative-standard-deviation](https://rosettacode.org/wiki/Cumulative_standard_deviation) |
| `Currying` | currying.fth | [Currying](https://rosettacode.org/wiki/Currying) |
| `Damm-algorithm` | damm-algorithm.fth | [Damm-algorithm](https://rosettacode.org/wiki/Damm_algorithm) |
| `Date-format` | date-format-1.fth, date-format-2.fth, date-format-3.fth | [Date-format](https://rosettacode.org/wiki/Date_format) |
| `Day-of-the-week` | day-of-the-week-1.fth, day-of-the-week-2.fth, day-of-the-week-3.fth, day-of-the-week-4.fth | [Day-of-the-week](https://rosettacode.org/wiki/Day_of_the_week) |
| `Deceptive-numbers` | deceptive-numbers.fth | [Deceptive-numbers](https://rosettacode.org/wiki/Deceptive_numbers) |
| `Define-a-primitive-data-type` | define-a-primitive-data-type-1.fth, define-a-primitive-data-type-2.fth, define-a-primitive-data-type-3.fth, define-a-primitive-data-type-4.fth, define-a-primitive-data-type-5.fth, define-a-primitive-data-type-6.fth | [Define-a-primitive-data-type](https://rosettacode.org/wiki/Define_a_primitive_data_type) |
| `Delegates` | delegates.fth | [Delegates](https://rosettacode.org/wiki/Delegates) |
| `Delete-a-file` | delete-a-file.fth | [Delete-a-file](https://rosettacode.org/wiki/Delete_a_file) |
| `Department-numbers` | department-numbers.fth | [Department-numbers](https://rosettacode.org/wiki/Department_numbers) |
| `Descending-primes` | descending-primes.fth | [Descending-primes](https://rosettacode.org/wiki/Descending_primes) |
| `Detect-division-by-zero` | detect-division-by-zero.fth | [Detect-division-by-zero](https://rosettacode.org/wiki/Detect_division_by_zero) |
| `Determinant-and-permanent` | determinant-and-permanent.fth | [Determinant-and-permanent](https://rosettacode.org/wiki/Determinant_and_permanent) |
| `Determine-if-a-string-has-all-the-same-characters` | determine-if-a-string-has-all-the-same-characters.fth | [Determine-if-a-string-has-all-the-same-characters](https://rosettacode.org/wiki/Determine_if_a_string_has_all_the_same_characters) |
| `Determine-if-a-string-is-numeric` | determine-if-a-string-is-numeric.fth | [Determine-if-a-string-is-numeric](https://rosettacode.org/wiki/Determine_if_a_string_is_numeric) |
| `Dice-game-probabilities` | dice-game-probabilities.fth | [Dice-game-probabilities](https://rosettacode.org/wiki/Dice_game_probabilities) |
| `Digital-root` | digital-root-1.fth, digital-root-2.fth | [Digital-root](https://rosettacode.org/wiki/Digital_root) |
| `Dijkstras-algorithm` | dijkstras-algorithm.fth | [Dijkstras-algorithm](https://rosettacode.org/wiki/Dijkstras_algorithm) |
| `Dinesmans-multiple-dwelling-problem` | dinesmans-multiple-dwelling-problem.fth | [Dinesmans-multiple-dwelling-problem](https://rosettacode.org/wiki/Dinesmans_multiple_dwelling_problem) |
| `Disarium-numbers` | disarium-numbers.fth | [Disarium-numbers](https://rosettacode.org/wiki/Disarium_numbers) |
| `Documentation` | documentation-1.fth, documentation-2.fth | [Documentation](https://rosettacode.org/wiki/Documentation) |
| `Dot-product` | dot-product.fth | [Dot-product](https://rosettacode.org/wiki/Dot_product) |
| `Dragon-curve` | dragon-curve-1.fth, dragon-curve-2.fth | [Dragon-curve](https://rosettacode.org/wiki/Dragon_curve) |
| `Draw-a-clock` | draw-a-clock.fth | [Draw-a-clock](https://rosettacode.org/wiki/Draw_a_clock) |
| `Draw-a-cuboid` | draw-a-cuboid-1.fth, draw-a-cuboid-2.fth, draw-a-cuboid-3.fth, draw-a-cuboid-4.fth | [Draw-a-cuboid](https://rosettacode.org/wiki/Draw_a_cuboid) |
| `Draw-a-pixel` | draw-a-pixel.fth | [Draw-a-pixel](https://rosettacode.org/wiki/Draw_a_pixel) |
| `Draw-a-sphere` | draw-a-sphere-1.fth, draw-a-sphere-2.fth | [Draw-a-sphere](https://rosettacode.org/wiki/Draw_a_sphere) |
| `Duffinian-numbers` | duffinian-numbers.fth | [Duffinian-numbers](https://rosettacode.org/wiki/Duffinian_numbers) |
| `Dutch-national-flag-problem` | dutch-national-flag-problem.fth | [Dutch-national-flag-problem](https://rosettacode.org/wiki/Dutch_national_flag_problem) |
| `Dynamic-variable-names` | dynamic-variable-names.fth | [Dynamic-variable-names](https://rosettacode.org/wiki/Dynamic_variable_names) |
| `Echo-server` | echo-server.fth | [Echo-server](https://rosettacode.org/wiki/Echo_server) |
| `Egyptian-division` | egyptian-division.fth | [Egyptian-division](https://rosettacode.org/wiki/Egyptian_division) |
| `Elementary-cellular-automaton` | elementary-cellular-automaton.fth | [Elementary-cellular-automaton](https://rosettacode.org/wiki/Elementary_cellular_automaton) |
| `Emirp-primes` | emirp-primes.fth | [Emirp-primes](https://rosettacode.org/wiki/Emirp_primes) |
| `Empty-program` | empty-program-1.fth, empty-program-2.fth | [Empty-program](https://rosettacode.org/wiki/Empty_program) |
| `Empty-string` | empty-string.fth | [Empty-string](https://rosettacode.org/wiki/Empty_string) |
| `Enforced-immutability` | enforced-immutability.fth | [Enforced-immutability](https://rosettacode.org/wiki/Enforced_immutability) |
| `Entropy` | entropy.fth | [Entropy](https://rosettacode.org/wiki/Entropy) |
| `Enumerations` | enumerations-1.fth, enumerations-2.fth, enumerations-3.fth, enumerations-4.fth, enumerations-5.fth, enumerations-6.fth, enumerations-7.fth | [Enumerations](https://rosettacode.org/wiki/Enumerations) |
| `Environment-variables` | environment-variables.fth | [Environment-variables](https://rosettacode.org/wiki/Environment_variables) |
| `Esthetic-numbers` | esthetic-numbers.fth | [Esthetic-numbers](https://rosettacode.org/wiki/Esthetic_numbers) |
| `Ethiopian-multiplication` | ethiopian-multiplication.fth | [Ethiopian-multiplication](https://rosettacode.org/wiki/Ethiopian_multiplication) |
| `Euler-method` | euler-method.fth | [Euler-method](https://rosettacode.org/wiki/Euler_method) |
| `Eulers-identity` | eulers-identity.fth | [Eulers-identity](https://rosettacode.org/wiki/Eulers_identity) |
| `Eulers-sum-of-powers-conjecture` | eulers-sum-of-powers-conjecture.fth | [Eulers-sum-of-powers-conjecture](https://rosettacode.org/wiki/Eulers_sum_of_powers_conjecture) |
| `Evaluate-binomial-coefficients` | evaluate-binomial-coefficients.fth | [Evaluate-binomial-coefficients](https://rosettacode.org/wiki/Evaluate_binomial_coefficients) |
| `Even-or-odd` | even-or-odd.fth | [Even-or-odd](https://rosettacode.org/wiki/Even_or_odd) |
| `Evolutionary-algorithm` | evolutionary-algorithm.fth | [Evolutionary-algorithm](https://rosettacode.org/wiki/Evolutionary_algorithm) |
| `Exceptions` | exceptions-1.fth, exceptions-2.fth, exceptions-3.fth, exceptions-4.fth | [Exceptions](https://rosettacode.org/wiki/Exceptions) |
| `Execute-Computer-Zero` | execute-computer-zero.fth | [Execute-Computer-Zero](https://rosettacode.org/wiki/Execute_Computer_Zero) |
| `Execute-HQ9+` | execute-hq9+.fth | [Execute-HQ9+](https://rosettacode.org/wiki/Execute_HQ9+) |
| `Execute-a-system-command` | execute-a-system-command.fth | [Execute-a-system-command](https://rosettacode.org/wiki/Execute_a_system_command) |
| `Exponentiation-operator` | exponentiation-operator-1.fth, exponentiation-operator-2.fth | [Exponentiation-operator](https://rosettacode.org/wiki/Exponentiation_operator) |
| `Extend-your-language` | extend-your-language.fth | [Extend-your-language](https://rosettacode.org/wiki/Extend_your_language) |
| `Extreme-floating-point-values` | extreme-floating-point-values.fth | [Extreme-floating-point-values](https://rosettacode.org/wiki/Extreme_floating_point_values) |
| `FASTA-format` | fasta-format.fth | [FASTA-format](https://rosettacode.org/wiki/FASTA_format) |
| `Factorial` | factorial-1.fth, factorial-2.fth | [Factorial](https://rosettacode.org/wiki/Factorial) |
| `Factors-of-a-Mersenne-number` | factors-of-a-mersenne-number.fth | [Factors-of-a-Mersenne-number](https://rosettacode.org/wiki/Factors_of_a_Mersenne_number) |
| `Factors-of-an-integer` | factors-of-an-integer-1.fth, factors-of-an-integer-2.fth | [Factors-of-an-integer](https://rosettacode.org/wiki/Factors_of_an_integer) |
| `Fibonacci-n-step-number-sequences` | fibonacci-n-step-number-sequences.fth | [Fibonacci-n-step-number-sequences](https://rosettacode.org/wiki/Fibonacci_n_step_number_sequences) |
| `Fibonacci-sequence` | fibonacci-sequence-1.fth, fibonacci-sequence-2.fth, fibonacci-sequence-3.fth | [Fibonacci-sequence](https://rosettacode.org/wiki/Fibonacci_sequence) |
| `Fibonacci-word` | fibonacci-word.fth | [Fibonacci-word](https://rosettacode.org/wiki/Fibonacci_word) |
| `File-input-output` | file-input-output-1.fth, file-input-output-2.fth | [File-input-output](https://rosettacode.org/wiki/File_input_output) |
| `File-size` | file-size.fth | [File-size](https://rosettacode.org/wiki/File_size) |
| `Filter` | filter.fth | [Filter](https://rosettacode.org/wiki/Filter) |
| `Find-limit-of-recursion` | find-limit-of-recursion-1.fth, find-limit-of-recursion-2.fth, find-limit-of-recursion-3.fth | [Find-limit-of-recursion](https://rosettacode.org/wiki/Find_limit_of_recursion) |
| `Find-the-missing-permutation` | find-the-missing-permutation.fth | [Find-the-missing-permutation](https://rosettacode.org/wiki/Find_the_missing_permutation) |
| `First-class-functions` | first-class-functions.fth | [First-class-functions](https://rosettacode.org/wiki/First_class_functions) |
| `First-perfect-square-in-base-n-with-n-unique-digits` | first-perfect-square-in-base-n-with-n-unique-digits.fth | [First-perfect-square-in-base-n-with-n-unique-digits](https://rosettacode.org/wiki/First_perfect_square_in_base_n_with_n_unique_digits) |
| `FizzBuzz` | fizzbuzz-1.fth, fizzbuzz-2.fth, fizzbuzz-3.fth, fizzbuzz-4.fth, fizzbuzz-5.fth | [FizzBuzz](https://rosettacode.org/wiki/FizzBuzz) |
| `Flatten-a-list` | flatten-a-list.fth | [Flatten-a-list](https://rosettacode.org/wiki/Flatten_a_list) |
| `Flipping-bits-game` | flipping-bits-game-1.fth, flipping-bits-game-2.fth | [Flipping-bits-game](https://rosettacode.org/wiki/Flipping_bits_game) |
| `Flow-control-structures` | flow-control-structures.fth | [Flow-control-structures](https://rosettacode.org/wiki/Flow_control_structures) |
| `Floyds-triangle` | floyds-triangle.fth | [Floyds-triangle](https://rosettacode.org/wiki/Floyds_triangle) |
| `Forest-fire` | forest-fire.fth | [Forest-fire](https://rosettacode.org/wiki/Forest_fire) |
| `Formatted-numeric-output` | formatted-numeric-output-1.fth, formatted-numeric-output-2.fth | [Formatted-numeric-output](https://rosettacode.org/wiki/Formatted_numeric_output) |
| `Forward-difference` | forward-difference.fth | [Forward-difference](https://rosettacode.org/wiki/Forward_difference) |
| `Four-bit-adder` | four-bit-adder.fth | [Four-bit-adder](https://rosettacode.org/wiki/Four_bit_adder) |
| `Function-composition` | function-composition.fth | [Function-composition](https://rosettacode.org/wiki/Function_composition) |
| `Function-definition` | function-definition.fth | [Function-definition](https://rosettacode.org/wiki/Function_definition) |
| `Function-frequency` | function-frequency.fth | [Function-frequency](https://rosettacode.org/wiki/Function_frequency) |
| `Fusc-sequence` | fusc-sequence.fth | [Fusc-sequence](https://rosettacode.org/wiki/Fusc_sequence) |
| `GUI-component-interaction` | gui-component-interaction.fth | [GUI-component-interaction](https://rosettacode.org/wiki/GUI_component_interaction) |
| `Gamma-function` | gamma-function-1.fth, gamma-function-2.fth | [Gamma-function](https://rosettacode.org/wiki/Gamma_function) |
| `Gapful-numbers` | gapful-numbers.fth | [Gapful-numbers](https://rosettacode.org/wiki/Gapful_numbers) |
| `General-FizzBuzz` | general-fizzbuzz.fth | [General-FizzBuzz](https://rosettacode.org/wiki/General_FizzBuzz) |
| `Generate-Chess960-starting-position` | generate-chess960-starting-position.fth | [Generate-Chess960-starting-position](https://rosettacode.org/wiki/Generate_Chess960_starting_position) |
| `Generate-lower-case-ASCII-alphabet` | generate-lower-case-ascii-alphabet-1.fth, generate-lower-case-ascii-alphabet-2.fth, generate-lower-case-ascii-alphabet-3.fth, generate-lower-case-ascii-alphabet-4.fth | [Generate-lower-case-ASCII-alphabet](https://rosettacode.org/wiki/Generate_lower_case_ASCII_alphabet) |
| `Generator-Exponential` | generator-exponential.fth | [Generator-Exponential](https://rosettacode.org/wiki/Generator_Exponential) |
| `Generic-swap` | generic-swap.fth | [Generic-swap](https://rosettacode.org/wiki/Generic_swap) |
| `Get-system-command-output` | get-system-command-output.fth | [Get-system-command-output](https://rosettacode.org/wiki/Get_system_command_output) |
| `Gray-code` | gray-code.fth | [Gray-code](https://rosettacode.org/wiki/Gray_code) |
| `Grayscale-image` | grayscale-image.fth | [Grayscale-image](https://rosettacode.org/wiki/Grayscale_image) |
| `Greatest-common-divisor` | greatest-common-divisor.fth | [Greatest-common-divisor](https://rosettacode.org/wiki/Greatest_common_divisor) |
| `Greatest-element-of-a-list` | greatest-element-of-a-list.fth | [Greatest-element-of-a-list](https://rosettacode.org/wiki/Greatest_element_of_a_list) |
| `Greatest-subsequential-sum` | greatest-subsequential-sum-1.fth, greatest-subsequential-sum-2.fth | [Greatest-subsequential-sum](https://rosettacode.org/wiki/Greatest_subsequential_sum) |
| `Guess-the-number` | guess-the-number.fth | [Guess-the-number](https://rosettacode.org/wiki/Guess_the_number) |
| `HTTP` | http.fth | [HTTP](https://rosettacode.org/wiki/HTTP) |
| `Hailstone-sequence` | hailstone-sequence.fth | [Hailstone-sequence](https://rosettacode.org/wiki/Hailstone_sequence) |
| `Hamming-numbers` | hamming-numbers-1.fth, hamming-numbers-2.fth | [Hamming-numbers](https://rosettacode.org/wiki/Hamming_numbers) |
| `Handle-a-signal` | handle-a-signal.fth | [Handle-a-signal](https://rosettacode.org/wiki/Handle_a_signal) |
| `Happy-numbers` | happy-numbers-1.fth, happy-numbers-2.fth, happy-numbers-3.fth | [Happy-numbers](https://rosettacode.org/wiki/Happy_numbers) |
| `Harmonic-series` | harmonic-series.fth | [Harmonic-series](https://rosettacode.org/wiki/Harmonic_series) |
| `Hash-join` | hash-join.fth | [Hash-join](https://rosettacode.org/wiki/Hash_join) |
| `Haversine-formula` | haversine-formula.fth | [Haversine-formula](https://rosettacode.org/wiki/Haversine_formula) |
| `Hello-world-Graphical` | hello-world-graphical-1.fth, hello-world-graphical-2.fth | [Hello-world-Graphical](https://rosettacode.org/wiki/Hello_world_Graphical) |
| `Hello-world-Line-printer` | hello-world-line-printer.fth | [Hello-world-Line-printer](https://rosettacode.org/wiki/Hello_world_Line_printer) |
| `Hello-world-Newline-omission` | hello-world-newline-omission.fth | [Hello-world-Newline-omission](https://rosettacode.org/wiki/Hello_world_Newline_omission) |
| `Hello-world-Standard-error` | hello-world-standard-error.fth | [Hello-world-Standard-error](https://rosettacode.org/wiki/Hello_world_Standard_error) |
| `Hello-world-Text` | hello-world-text-1.fth, hello-world-text-2.fth | [Hello-world-Text](https://rosettacode.org/wiki/Hello_world_Text) |
| `Here-document` | here-document-1.fth, here-document-2.fth | [Here-document](https://rosettacode.org/wiki/Here_document) |
| `Hickerson-series-of-almost-integers` | hickerson-series-of-almost-integers.fth | [Hickerson-series-of-almost-integers](https://rosettacode.org/wiki/Hickerson_series_of_almost_integers) |
| `Higher-order-functions` | higher-order-functions.fth | [Higher-order-functions](https://rosettacode.org/wiki/Higher_order_functions) |
| `Hilbert-curve` | hilbert-curve.fth | [Hilbert-curve](https://rosettacode.org/wiki/Hilbert_curve) |
| `History-variables` | history-variables.fth | [History-variables](https://rosettacode.org/wiki/History_variables) |
| `Hofstadter-Q-sequence` | hofstadter-q-sequence.fth | [Hofstadter-Q-sequence](https://rosettacode.org/wiki/Hofstadter_Q_sequence) |
| `Holidays-related-to-Easter` | holidays-related-to-easter.fth | [Holidays-related-to-Easter](https://rosettacode.org/wiki/Holidays_related_to_Easter) |
| `Horizontal-sundial-calculations` | horizontal-sundial-calculations.fth | [Horizontal-sundial-calculations](https://rosettacode.org/wiki/Horizontal_sundial_calculations) |
| `Horners-rule-for-polynomial-evaluation` | horners-rule-for-polynomial-evaluation.fth | [Horners-rule-for-polynomial-evaluation](https://rosettacode.org/wiki/Horners_rule_for_polynomial_evaluation) |
| `Host-introspection` | host-introspection.fth | [Host-introspection](https://rosettacode.org/wiki/Host_introspection) |
| `Hostname` | hostname.fth | [Hostname](https://rosettacode.org/wiki/Hostname) |
| `Hunt-the-Wumpus` | hunt-the-wumpus.fth | [Hunt-the-Wumpus](https://rosettacode.org/wiki/Hunt_the_Wumpus) |
| `IBAN` | iban.fth | [IBAN](https://rosettacode.org/wiki/IBAN) |
| `ISBN13-check-digit` | isbn13-check-digit.fth | [ISBN13-check-digit](https://rosettacode.org/wiki/ISBN13_check_digit) |
| `Identity-matrix` | identity-matrix.fth | [Identity-matrix](https://rosettacode.org/wiki/Identity_matrix) |
| `Image-noise` | image-noise.fth | [Image-noise](https://rosettacode.org/wiki/Image_noise) |
| `Include-a-file` | include-a-file.fth | [Include-a-file](https://rosettacode.org/wiki/Include_a_file) |
| `Increment-a-numerical-string` | increment-a-numerical-string-1.fth, increment-a-numerical-string-2.fth, increment-a-numerical-string-3.fth, increment-a-numerical-string-4.fth | [Increment-a-numerical-string](https://rosettacode.org/wiki/Increment_a_numerical_string) |
| `Infinity` | infinity.fth | [Infinity](https://rosettacode.org/wiki/Infinity) |
| `Inheritance-Multiple` | inheritance-multiple.fth | [Inheritance-Multiple](https://rosettacode.org/wiki/Inheritance_Multiple) |
| `Inheritance-Single` | inheritance-single-1.fth, inheritance-single-2.fth | [Inheritance-Single](https://rosettacode.org/wiki/Inheritance_Single) |
| `Input-loop` | input-loop.fth | [Input-loop](https://rosettacode.org/wiki/Input_loop) |
| `Integer-comparison` | integer-comparison.fth | [Integer-comparison](https://rosettacode.org/wiki/Integer_comparison) |
| `Integer-sequence` | integer-sequence.fth | [Integer-sequence](https://rosettacode.org/wiki/Integer_sequence) |
| `Interactive-programming-repl-` | interactive-programming-repl-.fth | [Interactive-programming-repl-](https://rosettacode.org/wiki/Interactive_programming_repl_) |
| `Introspection` | introspection-1.fth, introspection-2.fth | [Introspection](https://rosettacode.org/wiki/Introspection) |
| `Isqrt-integer-square-root-of-X` | isqrt-integer-square-root-of-x-1.fth, isqrt-integer-square-root-of-x-2.fth | [Isqrt-integer-square-root-of-X](https://rosettacode.org/wiki/Isqrt_integer_square_root_of_X) |
| `Iterated-digits-squaring` | iterated-digits-squaring.fth | [Iterated-digits-squaring](https://rosettacode.org/wiki/Iterated_digits_squaring) |
| `Jensens-Device` | jensens-device-1.fth, jensens-device-2.fth, jensens-device-3.fth | [Jensens-Device](https://rosettacode.org/wiki/Jensens_Device) |
| `Josephus-problem` | josephus-problem.fth | [Josephus-problem](https://rosettacode.org/wiki/Josephus_problem) |
| `Jump-anywhere` | jump-anywhere-1.fth, jump-anywhere-2.fth, jump-anywhere-3.fth, jump-anywhere-4.fth, jump-anywhere-5.fth, jump-anywhere-6.fth, jump-anywhere-7.fth, jump-anywhere-8.fth | [Jump-anywhere](https://rosettacode.org/wiki/Jump_anywhere) |
| `Kaprekar-numbers` | kaprekar-numbers.fth | [Kaprekar-numbers](https://rosettacode.org/wiki/Kaprekar_numbers) |
| `Keyboard-input-Flush-the-keyboard-buffer` | keyboard-input-flush-the-keyboard-buffer.fth | [Keyboard-input-Flush-the-keyboard-buffer](https://rosettacode.org/wiki/Keyboard_input_Flush_the_keyboard_buffer) |
| `Keyboard-input-Keypress-check` | keyboard-input-keypress-check.fth | [Keyboard-input-Keypress-check](https://rosettacode.org/wiki/Keyboard_input_Keypress_check) |
| `Keyboard-input-Obtain-a-Y-or-N-response` | keyboard-input-obtain-a-y-or-n-response.fth | [Keyboard-input-Obtain-a-Y-or-N-response](https://rosettacode.org/wiki/Keyboard_input_Obtain_a_Y_or_N_response) |
| `Knapsack-problem-0-1` | knapsack-problem-0-1.fth | [Knapsack-problem-0-1](https://rosettacode.org/wiki/Knapsack_problem_0_1) |
| `Knapsack-problem-Continuous` | knapsack-problem-continuous.fth | [Knapsack-problem-Continuous](https://rosettacode.org/wiki/Knapsack_problem_Continuous) |
| `Knapsack-problem-Unbounded` | knapsack-problem-unbounded-1.fth, knapsack-problem-unbounded-2.fth | [Knapsack-problem-Unbounded](https://rosettacode.org/wiki/Knapsack_problem_Unbounded) |
| `Knuth-shuffle` | knuth-shuffle.fth | [Knuth-shuffle](https://rosettacode.org/wiki/Knuth_shuffle) |
| `Koch-curve` | koch-curve.fth | [Koch-curve](https://rosettacode.org/wiki/Koch_curve) |
| `LZW-compression` | lzw-compression.fth | [LZW-compression](https://rosettacode.org/wiki/LZW_compression) |
| `Lah-numbers` | lah-numbers.fth | [Lah-numbers](https://rosettacode.org/wiki/Lah_numbers) |
| `Langtons-ant` | langtons-ant.fth | [Langtons-ant](https://rosettacode.org/wiki/Langtons_ant) |
| `Largest-proper-divisor-of-n` | largest-proper-divisor-of-n.fth | [Largest-proper-divisor-of-n](https://rosettacode.org/wiki/Largest_proper_divisor_of_n) |
| `Leap-year` | leap-year-1.fth, leap-year-2.fth | [Leap-year](https://rosettacode.org/wiki/Leap_year) |
| `Least-common-multiple` | least-common-multiple.fth | [Least-common-multiple](https://rosettacode.org/wiki/Least_common_multiple) |
| `Left-factorials` | left-factorials.fth | [Left-factorials](https://rosettacode.org/wiki/Left_factorials) |
| `Leonardo-numbers` | leonardo-numbers.fth | [Leonardo-numbers](https://rosettacode.org/wiki/Leonardo_numbers) |
| `Letter-frequency` | letter-frequency.fth | [Letter-frequency](https://rosettacode.org/wiki/Letter_frequency) |
| `Levenshtein-distance` | levenshtein-distance.fth | [Levenshtein-distance](https://rosettacode.org/wiki/Levenshtein_distance) |
| `Linear-congruential-generator` | linear-congruential-generator.fth | [Linear-congruential-generator](https://rosettacode.org/wiki/Linear_congruential_generator) |
| `Literals-Integer` | literals-integer-1.fth, literals-integer-2.fth, literals-integer-3.fth | [Literals-Integer](https://rosettacode.org/wiki/Literals_Integer) |
| `Literals-String` | literals-string-1.fth, literals-string-2.fth, literals-string-3.fth | [Literals-String](https://rosettacode.org/wiki/Literals_String) |
| `Logical-operations` | logical-operations.fth | [Logical-operations](https://rosettacode.org/wiki/Logical_operations) |
| `Long-primes` | long-primes.fth | [Long-primes](https://rosettacode.org/wiki/Long_primes) |
| `Long-year` | long-year.fth | [Long-year](https://rosettacode.org/wiki/Long_year) |
| `Look-and-say-sequence` | look-and-say-sequence.fth | [Look-and-say-sequence](https://rosettacode.org/wiki/Look_and_say_sequence) |
| `Loop-over-multiple-arrays-simultaneously` | loop-over-multiple-arrays-simultaneously.fth | [Loop-over-multiple-arrays-simultaneously](https://rosettacode.org/wiki/Loop_over_multiple_arrays_simultaneously) |
| `Loops-Break` | loops-break.fth | [Loops-Break](https://rosettacode.org/wiki/Loops_Break) |
| `Loops-Continue` | loops-continue.fth | [Loops-Continue](https://rosettacode.org/wiki/Loops_Continue) |
| `Loops-Do-while` | loops-do-while.fth | [Loops-Do-while](https://rosettacode.org/wiki/Loops_Do_while) |
| `Loops-Downward-for` | loops-downward-for.fth | [Loops-Downward-for](https://rosettacode.org/wiki/Loops_Downward_for) |
| `Loops-For` | loops-for-1.fth, loops-for-2.fth | [Loops-For](https://rosettacode.org/wiki/Loops_For) |
| `Loops-For-with-a-specified-step` | loops-for-with-a-specified-step.fth | [Loops-For-with-a-specified-step](https://rosettacode.org/wiki/Loops_For_with_a_specified_step) |
| `Loops-Foreach` | loops-foreach-1.fth, loops-foreach-2.fth | [Loops-Foreach](https://rosettacode.org/wiki/Loops_Foreach) |
| `Loops-Infinite` | loops-infinite.fth | [Loops-Infinite](https://rosettacode.org/wiki/Loops_Infinite) |
| `Loops-N-plus-one-half` | loops-n-plus-one-half-1.fth, loops-n-plus-one-half-2.fth, loops-n-plus-one-half-3.fth | [Loops-N-plus-one-half](https://rosettacode.org/wiki/Loops_N_plus_one_half) |
| `Loops-Nested` | loops-nested.fth | [Loops-Nested](https://rosettacode.org/wiki/Loops_Nested) |
| `Loops-While` | loops-while.fth | [Loops-While](https://rosettacode.org/wiki/Loops_While) |
| `Loops-Wrong-ranges` | loops-wrong-ranges-1.fth, loops-wrong-ranges-2.fth | [Loops-Wrong-ranges](https://rosettacode.org/wiki/Loops_Wrong_ranges) |
| `Lucas-Lehmer-test` | lucas-lehmer-test-1.fth, lucas-lehmer-test-2.fth | [Lucas-Lehmer-test](https://rosettacode.org/wiki/Lucas_Lehmer_test) |
| `Luhn-test-of-credit-card-numbers` | luhn-test-of-credit-card-numbers.fth | [Luhn-test-of-credit-card-numbers](https://rosettacode.org/wiki/Luhn_test_of_credit_card_numbers) |
| `M-bius-function` | m-bius-function.fth | [M-bius-function](https://rosettacode.org/wiki/M_bius_function) |
| `MD5` | md5.fth | [MD5](https://rosettacode.org/wiki/MD5) |
| `Magic-8-ball` | magic-8-ball.fth | [Magic-8-ball](https://rosettacode.org/wiki/Magic_8_ball) |
| `Man-or-boy-test` | man-or-boy-test.fth | [Man-or-boy-test](https://rosettacode.org/wiki/Man_or_boy_test) |
| `Mandelbrot-set` | mandelbrot-set-1.fth, mandelbrot-set-2.fth | [Mandelbrot-set](https://rosettacode.org/wiki/Mandelbrot_set) |
| `Map-range` | map-range-1.fth, map-range-2.fth | [Map-range](https://rosettacode.org/wiki/Map_range) |
| `Matrix-multiplication` | matrix-multiplication.fth | [Matrix-multiplication](https://rosettacode.org/wiki/Matrix_multiplication) |
| `Matrix-transposition` | matrix-transposition.fth | [Matrix-transposition](https://rosettacode.org/wiki/Matrix_transposition) |
| `Maximum-triangle-path-sum` | maximum-triangle-path-sum.fth | [Maximum-triangle-path-sum](https://rosettacode.org/wiki/Maximum_triangle_path_sum) |
| `Maze-generation` | maze-generation-1.fth, maze-generation-2.fth | [Maze-generation](https://rosettacode.org/wiki/Maze_generation) |
| `Memory-allocation` | memory-allocation-1.fth, memory-allocation-2.fth, memory-allocation-3.fth | [Memory-allocation](https://rosettacode.org/wiki/Memory_allocation) |
| `Memory-layout-of-a-data-structure` | memory-layout-of-a-data-structure-1.fth, memory-layout-of-a-data-structure-2.fth | [Memory-layout-of-a-data-structure](https://rosettacode.org/wiki/Memory_layout_of_a_data_structure) |
| `Menu` | menu-1.fth, menu-2.fth | [Menu](https://rosettacode.org/wiki/Menu) |
| `Mertens-function` | mertens-function.fth | [Mertens-function](https://rosettacode.org/wiki/Mertens_function) |
| `Metaprogramming` | metaprogramming-1.fth, metaprogramming-2.fth | [Metaprogramming](https://rosettacode.org/wiki/Metaprogramming) |
| `Middle-three-digits` | middle-three-digits.fth | [Middle-three-digits](https://rosettacode.org/wiki/Middle_three_digits) |
| `Minimum-multiple-of-m-where-digital-sum-equals-m` | minimum-multiple-of-m-where-digital-sum-equals-m.fth | [Minimum-multiple-of-m-where-digital-sum-equals-m](https://rosettacode.org/wiki/Minimum_multiple_of_m_where_digital_sum_equals_m) |
| `Modular-inverse` | modular-inverse-1.fth, modular-inverse-2.fth | [Modular-inverse](https://rosettacode.org/wiki/Modular_inverse) |
| `Monty-Hall-problem` | monty-hall-problem-1.fth, monty-hall-problem-2.fth, monty-hall-problem-3.fth | [Monty-Hall-problem](https://rosettacode.org/wiki/Monty_Hall_problem) |
| `Morse-code` | morse-code.fth | [Morse-code](https://rosettacode.org/wiki/Morse_code) |
| `Multi-dimensional-array` | multi-dimensional-array-1.fth, multi-dimensional-array-2.fth, multi-dimensional-array-3.fth | [Multi-dimensional-array](https://rosettacode.org/wiki/Multi_dimensional_array) |
| `Multifactorial` | multifactorial.fth | [Multifactorial](https://rosettacode.org/wiki/Multifactorial) |
| `Multiple-distinct-objects` | multiple-distinct-objects.fth | [Multiple-distinct-objects](https://rosettacode.org/wiki/Multiple_distinct_objects) |
| `Multiplication-tables` | multiplication-tables.fth | [Multiplication-tables](https://rosettacode.org/wiki/Multiplication_tables) |
| `Munchausen-numbers` | munchausen-numbers.fth | [Munchausen-numbers](https://rosettacode.org/wiki/Munchausen_numbers) |
| `Musical-scale` | musical-scale.fth | [Musical-scale](https://rosettacode.org/wiki/Musical_scale) |
| `Mutual-recursion` | mutual-recursion.fth | [Mutual-recursion](https://rosettacode.org/wiki/Mutual_recursion) |
| `N-queens-problem` | n-queens-problem-1.fth, n-queens-problem-2.fth | [N-queens-problem](https://rosettacode.org/wiki/N_queens_problem) |
| `Named-parameters` | named-parameters.fth | [Named-parameters](https://rosettacode.org/wiki/Named_parameters) |
| `Naming-conventions` | naming-conventions-1.fth, naming-conventions-2.fth | [Naming-conventions](https://rosettacode.org/wiki/Naming_conventions) |
| `Narcissist` | narcissist.fth | [Narcissist](https://rosettacode.org/wiki/Narcissist) |
| `Narcissistic-decimal-number` | narcissistic-decimal-number.fth | [Narcissistic-decimal-number](https://rosettacode.org/wiki/Narcissistic_decimal_number) |
| `Non-decimal-radices-Convert` | non-decimal-radices-convert-1.fth, non-decimal-radices-convert-2.fth | [Non-decimal-radices-Convert](https://rosettacode.org/wiki/Non_decimal_radices_Convert) |
| `Non-decimal-radices-Input` | non-decimal-radices-input.fth | [Non-decimal-radices-Input](https://rosettacode.org/wiki/Non_decimal_radices_Input) |
| `Non-decimal-radices-Output` | non-decimal-radices-output-1.fth, non-decimal-radices-output-2.fth | [Non-decimal-radices-Output](https://rosettacode.org/wiki/Non_decimal_radices_Output) |
| `Nth` | nth.fth | [Nth](https://rosettacode.org/wiki/Nth) |
| `Nth-root` | nth-root.fth | [Nth-root](https://rosettacode.org/wiki/Nth_root) |
| `Number-reversal-game` | number-reversal-game.fth | [Number-reversal-game](https://rosettacode.org/wiki/Number_reversal_game) |
| `Numbers-which-are-the-cube-roots-of-the-product-of-their-proper-divisors` | numbers-which-are-the-cube-roots-of-the-product-of-their-proper-divisors.fth | [Numbers-which-are-the-cube-roots-of-the-product-of-their-proper-divisors](https://rosettacode.org/wiki/Numbers_which_are_the_cube_roots_of_the_product_of_their_proper_divisors) |
| `Numbers-with-equal-rises-and-falls` | numbers-with-equal-rises-and-falls.fth | [Numbers-with-equal-rises-and-falls](https://rosettacode.org/wiki/Numbers_with_equal_rises_and_falls) |
| `Numerical-integration` | numerical-integration.fth | [Numerical-integration](https://rosettacode.org/wiki/Numerical_integration) |
| `Odd-word-problem` | odd-word-problem.fth | [Odd-word-problem](https://rosettacode.org/wiki/Odd_word_problem) |
| `Old-Russian-measure-of-length` | old-russian-measure-of-length.fth | [Old-Russian-measure-of-length](https://rosettacode.org/wiki/Old_Russian_measure_of_length) |
| `Old-lady-swallowed-a-fly` | old-lady-swallowed-a-fly.fth | [Old-lady-swallowed-a-fly](https://rosettacode.org/wiki/Old_lady_swallowed_a_fly) |
| `One-dimensional-cellular-automata` | one-dimensional-cellular-automata-1.fth, one-dimensional-cellular-automata-2.fth | [One-dimensional-cellular-automata](https://rosettacode.org/wiki/One_dimensional_cellular_automata) |
| `One-of-n-lines-in-a-file` | one-of-n-lines-in-a-file.fth | [One-of-n-lines-in-a-file](https://rosettacode.org/wiki/One_of_n_lines_in_a_file) |
| `OpenGL` | opengl-1.fth, opengl-2.fth | [OpenGL](https://rosettacode.org/wiki/OpenGL) |
| `Ordered-words` | ordered-words.fth | [Ordered-words](https://rosettacode.org/wiki/Ordered_words) |
| `Palindrome-detection` | palindrome-detection-1.fth, palindrome-detection-2.fth | [Palindrome-detection](https://rosettacode.org/wiki/Palindrome_detection) |
| `Pangram-checker` | pangram-checker.fth | [Pangram-checker](https://rosettacode.org/wiki/Pangram_checker) |
| `Parsing-RPN-calculator-algorithm` | parsing-rpn-calculator-algorithm-1.fth, parsing-rpn-calculator-algorithm-2.fth | [Parsing-RPN-calculator-algorithm](https://rosettacode.org/wiki/Parsing_RPN_calculator_algorithm) |
| `Particle-fountain` | particle-fountain.fth | [Particle-fountain](https://rosettacode.org/wiki/Particle_fountain) |
| `Pascals-triangle` | pascals-triangle-1.fth, pascals-triangle-2.fth | [Pascals-triangle](https://rosettacode.org/wiki/Pascals_triangle) |
| `Percentage-difference-between-images` | percentage-difference-between-images.fth | [Percentage-difference-between-images](https://rosettacode.org/wiki/Percentage_difference_between_images) |
| `Perfect-numbers` | perfect-numbers.fth | [Perfect-numbers](https://rosettacode.org/wiki/Perfect_numbers) |
| `Permutations-by-swapping` | permutations-by-swapping.fth | [Permutations-by-swapping](https://rosettacode.org/wiki/Permutations_by_swapping) |
| `Pernicious-numbers` | pernicious-numbers.fth | [Pernicious-numbers](https://rosettacode.org/wiki/Pernicious_numbers) |
| `Pig-the-dice-game` | pig-the-dice-game.fth | [Pig-the-dice-game](https://rosettacode.org/wiki/Pig_the_dice_game) |
| `Plasma-effect` | plasma-effect.fth | [Plasma-effect](https://rosettacode.org/wiki/Plasma_effect) |
| `Playing-cards` | playing-cards.fth | [Playing-cards](https://rosettacode.org/wiki/Playing_cards) |
| `Polymorphic-copy` | polymorphic-copy-1.fth, polymorphic-copy-2.fth | [Polymorphic-copy](https://rosettacode.org/wiki/Polymorphic_copy) |
| `Polymorphism` | polymorphism-1.fth, polymorphism-2.fth | [Polymorphism](https://rosettacode.org/wiki/Polymorphism) |
| `Population-count` | population-count.fth | [Population-count](https://rosettacode.org/wiki/Population_count) |
| `Power-set` | power-set.fth | [Power-set](https://rosettacode.org/wiki/Power_set) |
| `Price-fraction` | price-fraction-1.fth, price-fraction-2.fth | [Price-fraction](https://rosettacode.org/wiki/Price_fraction) |
| `Primality-by-Wilsons-theorem` | primality-by-wilsons-theorem.fth | [Primality-by-Wilsons-theorem](https://rosettacode.org/wiki/Primality_by_Wilsons_theorem) |
| `Primality-by-trial-division` | primality-by-trial-division.fth | [Primality-by-trial-division](https://rosettacode.org/wiki/Primality_by_trial_division) |
| `Prime-decomposition` | prime-decomposition.fth | [Prime-decomposition](https://rosettacode.org/wiki/Prime_decomposition) |
| `Priority-queue` | priority-queue.fth | [Priority-queue](https://rosettacode.org/wiki/Priority_queue) |
| `Probabilistic-choice` | probabilistic-choice.fth | [Probabilistic-choice](https://rosettacode.org/wiki/Probabilistic_choice) |
| `Program-name` | program-name.fth | [Program-name](https://rosettacode.org/wiki/Program_name) |
| `Program-termination` | program-termination.fth | [Program-termination](https://rosettacode.org/wiki/Program_termination) |
| `Proper-divisors` | proper-divisors.fth | [Proper-divisors](https://rosettacode.org/wiki/Proper_divisors) |
| `Pseudo-random-numbers-Combined-recursive-generator-MRG32k3a` | pseudo-random-numbers-combined-recursive-generator-mrg32k3a.fth | [Pseudo-random-numbers-Combined-recursive-generator-MRG32k3a](https://rosettacode.org/wiki/Pseudo_random_numbers_Combined_recursive_generator_MRG32k3a) |
| `Pseudo-random-numbers-Middle-square-method` | pseudo-random-numbers-middle-square-method.fth | [Pseudo-random-numbers-Middle-square-method](https://rosettacode.org/wiki/Pseudo_random_numbers_Middle_square_method) |
| `Pseudo-random-numbers-PCG32` | pseudo-random-numbers-pcg32-1.fth, pseudo-random-numbers-pcg32-2.fth | [Pseudo-random-numbers-PCG32](https://rosettacode.org/wiki/Pseudo_random_numbers_PCG32) |
| `Pseudo-random-numbers-Splitmix64` | pseudo-random-numbers-splitmix64.fth | [Pseudo-random-numbers-Splitmix64](https://rosettacode.org/wiki/Pseudo_random_numbers_Splitmix64) |
| `Pythagorean-triples` | pythagorean-triples.fth | [Pythagorean-triples](https://rosettacode.org/wiki/Pythagorean_triples) |
| `Queue-Definition` | queue-definition-1.fth, queue-definition-2.fth | [Queue-Definition](https://rosettacode.org/wiki/Queue_Definition) |
| `Queue-Usage` | queue-usage-1.fth, queue-usage-2.fth | [Queue-Usage](https://rosettacode.org/wiki/Queue_Usage) |
| `Quine` | quine.fth | [Quine](https://rosettacode.org/wiki/Quine) |
| `RPG-attributes-generator` | rpg-attributes-generator.fth | [RPG-attributes-generator](https://rosettacode.org/wiki/RPG_attributes_generator) |
| `Random-number-generator-device-` | random-number-generator-device-.fth | [Random-number-generator-device-](https://rosettacode.org/wiki/Random_number_generator_device_) |
| `Random-numbers` | random-numbers-1.fth, random-numbers-2.fth | [Random-numbers](https://rosettacode.org/wiki/Random_numbers) |
| `Range-expansion` | range-expansion.fth | [Range-expansion](https://rosettacode.org/wiki/Range_expansion) |
| `Range-extraction` | range-extraction.fth | [Range-extraction](https://rosettacode.org/wiki/Range_extraction) |
| `Read-a-configuration-file` | read-a-configuration-file.fth | [Read-a-configuration-file](https://rosettacode.org/wiki/Read_a_configuration_file) |
| `Read-a-file-line-by-line` | read-a-file-line-by-line-1.fth, read-a-file-line-by-line-2.fth | [Read-a-file-line-by-line](https://rosettacode.org/wiki/Read_a_file_line_by_line) |
| `Read-entire-file` | read-entire-file-1.fth, read-entire-file-2.fth | [Read-entire-file](https://rosettacode.org/wiki/Read_entire_file) |
| `Real-constants-and-functions` | real-constants-and-functions.fth | [Real-constants-and-functions](https://rosettacode.org/wiki/Real_constants_and_functions) |
| `Recamans-sequence` | recamans-sequence.fth | [Recamans-sequence](https://rosettacode.org/wiki/Recamans_sequence) |
| `Regular-expressions` | regular-expressions.fth | [Regular-expressions](https://rosettacode.org/wiki/Regular_expressions) |
| `Remove-duplicate-elements` | remove-duplicate-elements-1.fth, remove-duplicate-elements-2.fth, remove-duplicate-elements-3.fth | [Remove-duplicate-elements](https://rosettacode.org/wiki/Remove_duplicate_elements) |
| `Rename-a-file` | rename-a-file.fth | [Rename-a-file](https://rosettacode.org/wiki/Rename_a_file) |
| `Rep-string` | rep-string-1.fth, rep-string-2.fth | [Rep-string](https://rosettacode.org/wiki/Rep_string) |
| `Repeat` | repeat-1.fth, repeat-2.fth, repeat-3.fth, repeat-4.fth | [Repeat](https://rosettacode.org/wiki/Repeat) |
| `Repeat-a-string` | repeat-a-string-1.fth, repeat-a-string-2.fth, repeat-a-string-3.fth | [Repeat-a-string](https://rosettacode.org/wiki/Repeat_a_string) |
| `Respond-to-an-unknown-method-call` | respond-to-an-unknown-method-call.fth | [Respond-to-an-unknown-method-call](https://rosettacode.org/wiki/Respond_to_an_unknown_method_call) |
| `Return-multiple-values` | return-multiple-values.fth | [Return-multiple-values](https://rosettacode.org/wiki/Return_multiple_values) |
| `Reverse-a-string` | reverse-a-string-1.fth, reverse-a-string-2.fth, reverse-a-string-3.fth | [Reverse-a-string](https://rosettacode.org/wiki/Reverse_a_string) |
| `Reverse-words-in-a-string` | reverse-words-in-a-string.fth | [Reverse-words-in-a-string](https://rosettacode.org/wiki/Reverse_words_in_a_string) |
| `Rock-paper-scissors` | rock-paper-scissors.fth | [Rock-paper-scissors](https://rosettacode.org/wiki/Rock_paper_scissors) |
| `Roman-numerals-Decode` | roman-numerals-decode-1.fth, roman-numerals-decode-2.fth | [Roman-numerals-Decode](https://rosettacode.org/wiki/Roman_numerals_Decode) |
| `Roman-numerals-Encode` | roman-numerals-encode-1.fth, roman-numerals-encode-2.fth | [Roman-numerals-Encode](https://rosettacode.org/wiki/Roman_numerals_Encode) |
| `Roots-of-a-quadratic-function` | roots-of-a-quadratic-function-1.fth, roots-of-a-quadratic-function-2.fth | [Roots-of-a-quadratic-function](https://rosettacode.org/wiki/Roots_of_a_quadratic_function) |
| `Roots-of-unity` | roots-of-unity-1.fth, roots-of-unity-2.fth | [Roots-of-unity](https://rosettacode.org/wiki/Roots_of_unity) |
| `Rot-13` | rot-13-1.fth, rot-13-2.fth | [Rot-13](https://rosettacode.org/wiki/Rot_13) |
| `Run-length-encoding` | run-length-encoding-1.fth, run-length-encoding-2.fth | [Run-length-encoding](https://rosettacode.org/wiki/Run_length_encoding) |
| `Runtime-evaluation` | runtime-evaluation-1.fth, runtime-evaluation-2.fth | [Runtime-evaluation](https://rosettacode.org/wiki/Runtime_evaluation) |
| `Runtime-evaluation-In-an-environment` | runtime-evaluation-in-an-environment-1.fth, runtime-evaluation-in-an-environment-2.fth | [Runtime-evaluation-In-an-environment](https://rosettacode.org/wiki/Runtime_evaluation_In_an_environment) |
| `SEDOLs` | sedols.fth | [SEDOLs](https://rosettacode.org/wiki/SEDOLs) |
| `SHA-256` | sha-256.fth | [SHA-256](https://rosettacode.org/wiki/SHA_256) |
| `Safe-addition` | safe-addition.fth | [Safe-addition](https://rosettacode.org/wiki/Safe_addition) |
| `Sailors-coconuts-and-a-monkey-problem` | sailors-coconuts-and-a-monkey-problem.fth | [Sailors-coconuts-and-a-monkey-problem](https://rosettacode.org/wiki/Sailors_coconuts_and_a_monkey_problem) |
| `Search-a-list` | search-a-list-1.fth, search-a-list-2.fth | [Search-a-list](https://rosettacode.org/wiki/Search_a_list) |
| `Self-describing-numbers` | self-describing-numbers.fth | [Self-describing-numbers](https://rosettacode.org/wiki/Self_describing_numbers) |
| `Semiprime` | semiprime.fth | [Semiprime](https://rosettacode.org/wiki/Semiprime) |
| `Semordnilap` | semordnilap.fth | [Semordnilap](https://rosettacode.org/wiki/Semordnilap) |
| `Send-an-unknown-method-call` | send-an-unknown-method-call.fth | [Send-an-unknown-method-call](https://rosettacode.org/wiki/Send_an_unknown_method_call) |
| `Sequence-of-non-squares` | sequence-of-non-squares.fth | [Sequence-of-non-squares](https://rosettacode.org/wiki/Sequence_of_non_squares) |
| `Sequence-of-primes-by-trial-division` | sequence-of-primes-by-trial-division.fth | [Sequence-of-primes-by-trial-division](https://rosettacode.org/wiki/Sequence_of_primes_by_trial_division) |
| `Set` | set.fth | [Set](https://rosettacode.org/wiki/Set) |
| `Seven-sided-dice-from-five-sided-dice` | seven-sided-dice-from-five-sided-dice.fth | [Seven-sided-dice-from-five-sided-dice](https://rosettacode.org/wiki/Seven_sided_dice_from_five_sided_dice) |
| `Shell-one-liner` | shell-one-liner.fth | [Shell-one-liner](https://rosettacode.org/wiki/Shell_one_liner) |
| `Short-circuit-evaluation` | short-circuit-evaluation.fth | [Short-circuit-evaluation](https://rosettacode.org/wiki/Short_circuit_evaluation) |
| `Show-ASCII-table` | show-ascii-table-1.fth, show-ascii-table-2.fth | [Show-ASCII-table](https://rosettacode.org/wiki/Show_ASCII_table) |
| `Show-the-epoch` | show-the-epoch.fth | [Show-the-epoch](https://rosettacode.org/wiki/Show_the_epoch) |
| `Sierpinski-arrowhead-curve` | sierpinski-arrowhead-curve-1.fth, sierpinski-arrowhead-curve-2.fth | [Sierpinski-arrowhead-curve](https://rosettacode.org/wiki/Sierpinski_arrowhead_curve) |
| `Sierpinski-carpet` | sierpinski-carpet.fth | [Sierpinski-carpet](https://rosettacode.org/wiki/Sierpinski_carpet) |
| `Sierpinski-triangle` | sierpinski-triangle.fth | [Sierpinski-triangle](https://rosettacode.org/wiki/Sierpinski_triangle) |
| `Sierpinski-triangle-Graphical` | sierpinski-triangle-graphical.fth | [Sierpinski-triangle-Graphical](https://rosettacode.org/wiki/Sierpinski_triangle_Graphical) |
| `Sieve-of-Eratosthenes` | sieve-of-eratosthenes-1.fth, sieve-of-eratosthenes-2.fth, sieve-of-eratosthenes-3.fth | [Sieve-of-Eratosthenes](https://rosettacode.org/wiki/Sieve_of_Eratosthenes) |
| `Simple-database` | simple-database.fth | [Simple-database](https://rosettacode.org/wiki/Simple_database) |
| `Simple-windowed-application` | simple-windowed-application-1.fth, simple-windowed-application-2.fth, simple-windowed-application-3.fth, simple-windowed-application-4.fth | [Simple-windowed-application](https://rosettacode.org/wiki/Simple_windowed_application) |
| `Singleton` | singleton.fth | [Singleton](https://rosettacode.org/wiki/Singleton) |
| `Singly-linked-list-Element-definition` | singly-linked-list-element-definition-1.fth, singly-linked-list-element-definition-2.fth | [Singly-linked-list-Element-definition](https://rosettacode.org/wiki/Singly_linked_list_Element_definition) |
| `Singly-linked-list-Element-insertion` | singly-linked-list-element-insertion-1.fth, singly-linked-list-element-insertion-2.fth, singly-linked-list-element-insertion-3.fth | [Singly-linked-list-Element-insertion](https://rosettacode.org/wiki/Singly_linked_list_Element_insertion) |
| `Singly-linked-list-Traversal` | singly-linked-list-traversal-1.fth, singly-linked-list-traversal-2.fth | [Singly-linked-list-Traversal](https://rosettacode.org/wiki/Singly_linked_list_Traversal) |
| `Sleep` | sleep.fth | [Sleep](https://rosettacode.org/wiki/Sleep) |
| `Smarandache-prime-digital-sequence` | smarandache-prime-digital-sequence.fth | [Smarandache-prime-digital-sequence](https://rosettacode.org/wiki/Smarandache_prime_digital_sequence) |
| `Sockets` | sockets.fth | [Sockets](https://rosettacode.org/wiki/Sockets) |
| `Sort-an-integer-array` | sort-an-integer-array-1.fth, sort-an-integer-array-2.fth | [Sort-an-integer-array](https://rosettacode.org/wiki/Sort_an_integer_array) |
| `Sorting-algorithms-Bubble-sort` | sorting-algorithms-bubble-sort-1.fth, sorting-algorithms-bubble-sort-2.fth, sorting-algorithms-bubble-sort-3.fth | [Sorting-algorithms-Bubble-sort](https://rosettacode.org/wiki/Sorting_algorithms_Bubble_sort) |
| `Sorting-algorithms-Cocktail-sort` | sorting-algorithms-cocktail-sort-1.fth, sorting-algorithms-cocktail-sort-2.fth | [Sorting-algorithms-Cocktail-sort](https://rosettacode.org/wiki/Sorting_algorithms_Cocktail_sort) |
| `Sorting-algorithms-Comb-sort` | sorting-algorithms-comb-sort-1.fth, sorting-algorithms-comb-sort-2.fth | [Sorting-algorithms-Comb-sort](https://rosettacode.org/wiki/Sorting_algorithms_Comb_sort) |
| `Sorting-algorithms-Gnome-sort` | sorting-algorithms-gnome-sort-1.fth, sorting-algorithms-gnome-sort-2.fth | [Sorting-algorithms-Gnome-sort](https://rosettacode.org/wiki/Sorting_algorithms_Gnome_sort) |
| `Sorting-algorithms-Heapsort` | sorting-algorithms-heapsort-1.fth, sorting-algorithms-heapsort-2.fth | [Sorting-algorithms-Heapsort](https://rosettacode.org/wiki/Sorting_algorithms_Heapsort) |
| `Sorting-algorithms-Insertion-sort` | sorting-algorithms-insertion-sort.fth | [Sorting-algorithms-Insertion-sort](https://rosettacode.org/wiki/Sorting_algorithms_Insertion_sort) |
| `Sorting-algorithms-Merge-sort` | sorting-algorithms-merge-sort.fth | [Sorting-algorithms-Merge-sort](https://rosettacode.org/wiki/Sorting_algorithms_Merge_sort) |
| `Sorting-algorithms-Pancake-sort` | sorting-algorithms-pancake-sort.fth | [Sorting-algorithms-Pancake-sort](https://rosettacode.org/wiki/Sorting_algorithms_Pancake_sort) |
| `Sorting-algorithms-Quicksort` | sorting-algorithms-quicksort.fth | [Sorting-algorithms-Quicksort](https://rosettacode.org/wiki/Sorting_algorithms_Quicksort) |
| `Sorting-algorithms-Selection-sort` | sorting-algorithms-selection-sort.fth | [Sorting-algorithms-Selection-sort](https://rosettacode.org/wiki/Sorting_algorithms_Selection_sort) |
| `Sorting-algorithms-Shell-sort` | sorting-algorithms-shell-sort-1.fth, sorting-algorithms-shell-sort-2.fth | [Sorting-algorithms-Shell-sort](https://rosettacode.org/wiki/Sorting_algorithms_Shell_sort) |
| `Soundex` | soundex.fth | [Soundex](https://rosettacode.org/wiki/Soundex) |
| `Special-characters` | special-characters-1.fth, special-characters-2.fth | [Special-characters](https://rosettacode.org/wiki/Special_characters) |
| `Spinning-rod-animation-Text` | spinning-rod-animation-text-1.fth, spinning-rod-animation-text-2.fth | [Spinning-rod-animation-Text](https://rosettacode.org/wiki/Spinning_rod_animation_Text) |
| `Split-a-character-string-based-on-change-of-character` | split-a-character-string-based-on-change-of-character.fth | [Split-a-character-string-based-on-change-of-character](https://rosettacode.org/wiki/Split_a_character_string_based_on_change_of_character) |
| `Square-but-not-cube` | square-but-not-cube.fth | [Square-but-not-cube](https://rosettacode.org/wiki/Square_but_not_cube) |
| `Square-free-integers` | square-free-integers.fth | [Square-free-integers](https://rosettacode.org/wiki/Square_free_integers) |
| `Stack` | stack.fth | [Stack](https://rosettacode.org/wiki/Stack) |
| `Stack-traces` | stack-traces.fth | [Stack-traces](https://rosettacode.org/wiki/Stack_traces) |
| `Stair-climbing-puzzle` | stair-climbing-puzzle-1.fth, stair-climbing-puzzle-2.fth | [Stair-climbing-puzzle](https://rosettacode.org/wiki/Stair_climbing_puzzle) |
| `Start-from-a-main-routine` | start-from-a-main-routine-1.fth, start-from-a-main-routine-2.fth, start-from-a-main-routine-3.fth | [Start-from-a-main-routine](https://rosettacode.org/wiki/Start_from_a_main_routine) |
| `Stem-and-leaf-plot` | stem-and-leaf-plot.fth | [Stem-and-leaf-plot](https://rosettacode.org/wiki/Stem_and_leaf_plot) |
| `Stern-Brocot-sequence` | stern-brocot-sequence.fth | [Stern-Brocot-sequence](https://rosettacode.org/wiki/Stern_Brocot_sequence) |
| `Stirling-numbers-of-the-first-kind` | stirling-numbers-of-the-first-kind.fth | [Stirling-numbers-of-the-first-kind](https://rosettacode.org/wiki/Stirling_numbers_of_the_first_kind) |
| `Stirling-numbers-of-the-second-kind` | stirling-numbers-of-the-second-kind.fth | [Stirling-numbers-of-the-second-kind](https://rosettacode.org/wiki/Stirling_numbers_of_the_second_kind) |
| `String-append` | string-append-1.fth, string-append-2.fth | [String-append](https://rosettacode.org/wiki/String_append) |
| `String-comparison` | string-comparison.fth | [String-comparison](https://rosettacode.org/wiki/String_comparison) |
| `String-concatenation` | string-concatenation.fth | [String-concatenation](https://rosettacode.org/wiki/String_concatenation) |
| `String-interpolation-included-` | string-interpolation-included-.fth | [String-interpolation-included-](https://rosettacode.org/wiki/String_interpolation_included_) |
| `String-length` | string-length-1.fth, string-length-2.fth, string-length-3.fth, string-length-4.fth | [String-length](https://rosettacode.org/wiki/String_length) |
| `String-matching` | string-matching.fth | [String-matching](https://rosettacode.org/wiki/String_matching) |
| `String-prepend` | string-prepend.fth | [String-prepend](https://rosettacode.org/wiki/String_prepend) |
| `Strip-a-set-of-characters-from-a-string` | strip-a-set-of-characters-from-a-string-1.fth, strip-a-set-of-characters-from-a-string-2.fth | [Strip-a-set-of-characters-from-a-string](https://rosettacode.org/wiki/Strip_a_set_of_characters_from_a_string) |
| `Strip-comments-from-a-string` | strip-comments-from-a-string.fth | [Strip-comments-from-a-string](https://rosettacode.org/wiki/Strip_comments_from_a_string) |
| `Strip-control-codes-and-extended-characters-from-a-string` | strip-control-codes-and-extended-characters-from-a-string.fth | [Strip-control-codes-and-extended-characters-from-a-string](https://rosettacode.org/wiki/Strip_control_codes_and_extended_characters_from_a_string) |
| `Strip-whitespace-from-a-string-Top-and-tail` | strip-whitespace-from-a-string-top-and-tail-1.fth, strip-whitespace-from-a-string-top-and-tail-2.fth | [Strip-whitespace-from-a-string-Top-and-tail](https://rosettacode.org/wiki/Strip_whitespace_from_a_string_Top_and_tail) |
| `Subleq` | subleq.fth | [Subleq](https://rosettacode.org/wiki/Subleq) |
| `Substring` | substring.fth | [Substring](https://rosettacode.org/wiki/Substring) |
| `Substring-Top-and-tail` | substring-top-and-tail.fth | [Substring-Top-and-tail](https://rosettacode.org/wiki/Substring_Top_and_tail) |
| `Sudoku` | sudoku.fth | [Sudoku](https://rosettacode.org/wiki/Sudoku) |
| `Sum-and-product-of-an-array` | sum-and-product-of-an-array.fth | [Sum-and-product-of-an-array](https://rosettacode.org/wiki/Sum_and_product_of_an_array) |
| `Sum-digits-of-an-integer` | sum-digits-of-an-integer.fth | [Sum-digits-of-an-integer](https://rosettacode.org/wiki/Sum_digits_of_an_integer) |
| `Sum-multiples-of-3-and-5` | sum-multiples-of-3-and-5-1.fth, sum-multiples-of-3-and-5-2.fth | [Sum-multiples-of-3-and-5](https://rosettacode.org/wiki/Sum_multiples_of_3_and_5) |
| `Sum-of-a-series` | sum-of-a-series.fth | [Sum-of-a-series](https://rosettacode.org/wiki/Sum_of_a_series) |
| `Sum-of-squares` | sum-of-squares.fth | [Sum-of-squares](https://rosettacode.org/wiki/Sum_of_squares) |
| `Sum-to-100` | sum-to-100.fth | [Sum-to-100](https://rosettacode.org/wiki/Sum_to_100) |
| `Summarize-primes` | summarize-primes.fth | [Summarize-primes](https://rosettacode.org/wiki/Summarize_primes) |
| `Symmetric-difference` | symmetric-difference.fth | [Symmetric-difference](https://rosettacode.org/wiki/Symmetric_difference) |
| `Synchronous-concurrency` | synchronous-concurrency.fth | [Synchronous-concurrency](https://rosettacode.org/wiki/Synchronous_concurrency) |
| `System-time` | system-time.fth | [System-time](https://rosettacode.org/wiki/System_time) |
| `Take-notes-on-the-command-line` | take-notes-on-the-command-line-1.fth, take-notes-on-the-command-line-2.fth | [Take-notes-on-the-command-line](https://rosettacode.org/wiki/Take_notes_on_the_command_line) |
| `Tau-function` | tau-function.fth | [Tau-function](https://rosettacode.org/wiki/Tau_function) |
| `Tau-number` | tau-number.fth | [Tau-number](https://rosettacode.org/wiki/Tau_number) |
| `Taxicab-numbers` | taxicab-numbers.fth | [Taxicab-numbers](https://rosettacode.org/wiki/Taxicab_numbers) |
| `Temperature-conversion` | temperature-conversion.fth | [Temperature-conversion](https://rosettacode.org/wiki/Temperature_conversion) |
| `Terminal-control-Clear-the-screen` | terminal-control-clear-the-screen.fth | [Terminal-control-Clear-the-screen](https://rosettacode.org/wiki/Terminal_control_Clear_the_screen) |
| `Terminal-control-Coloured-text` | terminal-control-coloured-text-1.fth, terminal-control-coloured-text-2.fth | [Terminal-control-Coloured-text](https://rosettacode.org/wiki/Terminal_control_Coloured_text) |
| `Terminal-control-Cursor-movement` | terminal-control-cursor-movement-1.fth, terminal-control-cursor-movement-2.fth | [Terminal-control-Cursor-movement](https://rosettacode.org/wiki/Terminal_control_Cursor_movement) |
| `Terminal-control-Cursor-positioning` | terminal-control-cursor-positioning.fth | [Terminal-control-Cursor-positioning](https://rosettacode.org/wiki/Terminal_control_Cursor_positioning) |
| `Terminal-control-Dimensions` | terminal-control-dimensions.fth | [Terminal-control-Dimensions](https://rosettacode.org/wiki/Terminal_control_Dimensions) |
| `Terminal-control-Display-an-extended-character` | terminal-control-display-an-extended-character.fth | [Terminal-control-Display-an-extended-character](https://rosettacode.org/wiki/Terminal_control_Display_an_extended_character) |
| `Terminal-control-Inverse-video` | terminal-control-inverse-video.fth | [Terminal-control-Inverse-video](https://rosettacode.org/wiki/Terminal_control_Inverse_video) |
| `Terminal-control-Preserve-screen` | terminal-control-preserve-screen.fth | [Terminal-control-Preserve-screen](https://rosettacode.org/wiki/Terminal_control_Preserve_screen) |
| `Terminal-control-Ringing-the-terminal-bell` | terminal-control-ringing-the-terminal-bell-1.fth, terminal-control-ringing-the-terminal-bell-2.fth, terminal-control-ringing-the-terminal-bell-3.fth | [Terminal-control-Ringing-the-terminal-bell](https://rosettacode.org/wiki/Terminal_control_Ringing_the_terminal_bell) |
| `Ternary-logic` | ternary-logic.fth | [Ternary-logic](https://rosettacode.org/wiki/Ternary_logic) |
| `Text-processing-1` | text-processing-1.fth | [Text-processing-1](https://rosettacode.org/wiki/Text_processing_1) |
| `Text-processing-Max-licenses-in-use` | text-processing-max-licenses-in-use.fth | [Text-processing-Max-licenses-in-use](https://rosettacode.org/wiki/Text_processing_Max_licenses_in_use) |
| `The-Twelve-Days-of-Christmas` | the-twelve-days-of-christmas.fth | [The-Twelve-Days-of-Christmas](https://rosettacode.org/wiki/The_Twelve_Days_of_Christmas) |
| `Tic-tac-toe` | tic-tac-toe.fth | [Tic-tac-toe](https://rosettacode.org/wiki/Tic_tac_toe) |
| `Time-a-function` | time-a-function.fth | [Time-a-function](https://rosettacode.org/wiki/Time_a_function) |
| `Tokenize-a-string` | tokenize-a-string.fth | [Tokenize-a-string](https://rosettacode.org/wiki/Tokenize_a_string) |
| `Tokenize-a-string-with-escaping` | tokenize-a-string-with-escaping.fth | [Tokenize-a-string-with-escaping](https://rosettacode.org/wiki/Tokenize_a_string_with_escaping) |
| `Top-rank-per-group` | top-rank-per-group.fth | [Top-rank-per-group](https://rosettacode.org/wiki/Top_rank_per_group) |
| `Topic-variable` | topic-variable-1.fth, topic-variable-2.fth | [Topic-variable](https://rosettacode.org/wiki/Topic_variable) |
| `Topological-sort` | topological-sort.fth | [Topological-sort](https://rosettacode.org/wiki/Topological_sort) |
| `Totient-function` | totient-function.fth | [Totient-function](https://rosettacode.org/wiki/Totient_function) |
| `Towers-of-Hanoi` | towers-of-hanoi-1.fth, towers-of-hanoi-2.fth | [Towers-of-Hanoi](https://rosettacode.org/wiki/Towers_of_Hanoi) |
| `Trabb-Pardo-Knuth-algorithm` | trabb-pardo-knuth-algorithm.fth | [Trabb-Pardo-Knuth-algorithm](https://rosettacode.org/wiki/Trabb_Pardo_Knuth_algorithm) |
| `Tree-traversal` | tree-traversal.fth | [Tree-traversal](https://rosettacode.org/wiki/Tree_traversal) |
| `Trigonometric-functions` | trigonometric-functions.fth | [Trigonometric-functions](https://rosettacode.org/wiki/Trigonometric_functions) |
| `Truncatable-primes` | truncatable-primes.fth | [Truncatable-primes](https://rosettacode.org/wiki/Truncatable_primes) |
| `Truncate-a-file` | truncate-a-file.fth | [Truncate-a-file](https://rosettacode.org/wiki/Truncate_a_file) |
| `Twelve-statements` | twelve-statements.fth | [Twelve-statements](https://rosettacode.org/wiki/Twelve_statements) |
| `Twin-primes` | twin-primes.fth | [Twin-primes](https://rosettacode.org/wiki/Twin_primes) |
| `Twos-complement` | twos-complement.fth | [Twos-complement](https://rosettacode.org/wiki/Twos_complement) |
| `UTF-8-encode-and-decode` | utf-8-encode-and-decode-1.fth, utf-8-encode-and-decode-2.fth | [UTF-8-encode-and-decode](https://rosettacode.org/wiki/UTF_8_encode_and_decode) |
| `Ulam-spiral-for-primes-` | ulam-spiral-for-primes-.fth | [Ulam-spiral-for-primes-](https://rosettacode.org/wiki/Ulam_spiral_for_primes_) |
| `Undefined-values` | undefined-values.fth | [Undefined-values](https://rosettacode.org/wiki/Undefined_values) |
| `Unicode-variable-names` | unicode-variable-names.fth | [Unicode-variable-names](https://rosettacode.org/wiki/Unicode_variable_names) |
| `Unix-ls` | unix-ls-1.fth, unix-ls-2.fth | [Unix-ls](https://rosettacode.org/wiki/Unix_ls) |
| `User-input-Text` | user-input-text-1.fth, user-input-text-2.fth, user-input-text-3.fth, user-input-text-4.fth, user-input-text-5.fth, user-input-text-6.fth | [User-input-Text](https://rosettacode.org/wiki/User_input_Text) |
| `Vampire-number` | vampire-number.fth | [Vampire-number](https://rosettacode.org/wiki/Vampire_number) |
| `Van-der-Corput-sequence` | van-der-corput-sequence.fth | [Van-der-Corput-sequence](https://rosettacode.org/wiki/Van_der_Corput_sequence) |
| `Variable-size-Get` | variable-size-get-1.fth, variable-size-get-2.fth | [Variable-size-Get](https://rosettacode.org/wiki/Variable_size_Get) |
| `Variable-size-Set` | variable-size-set.fth | [Variable-size-Set](https://rosettacode.org/wiki/Variable_size_Set) |
| `Variables` | variables-1.fth, variables-2.fth, variables-3.fth, variables-4.fth | [Variables](https://rosettacode.org/wiki/Variables) |
| `Variadic-function` | variadic-function-1.fth, variadic-function-2.fth | [Variadic-function](https://rosettacode.org/wiki/Variadic_function) |
| `Vector` | vector.fth | [Vector](https://rosettacode.org/wiki/Vector) |
| `Vector-products` | vector-products-1.fth, vector-products-2.fth | [Vector-products](https://rosettacode.org/wiki/Vector_products) |
| `Verify-distribution-uniformity-Naive` | verify-distribution-uniformity-naive.fth | [Verify-distribution-uniformity-Naive](https://rosettacode.org/wiki/Verify_distribution_uniformity_Naive) |
| `Walk-a-directory-Non-recursively` | walk-a-directory-non-recursively.fth | [Walk-a-directory-Non-recursively](https://rosettacode.org/wiki/Walk_a_directory_Non_recursively) |
| `Walk-a-directory-Recursively` | walk-a-directory-recursively.fth | [Walk-a-directory-Recursively](https://rosettacode.org/wiki/Walk_a_directory_Recursively) |
| `Web-scraping` | web-scraping.fth | [Web-scraping](https://rosettacode.org/wiki/Web_scraping) |
| `Wieferich-primes` | wieferich-primes.fth | [Wieferich-primes](https://rosettacode.org/wiki/Wieferich_primes) |
| `Window-creation` | window-creation-1.fth, window-creation-2.fth | [Window-creation](https://rosettacode.org/wiki/Window_creation) |
| `Window-creation-X11` | window-creation-x11.fth | [Window-creation-X11](https://rosettacode.org/wiki/Window_creation_X11) |
| `Wireworld` | wireworld.fth | [Wireworld](https://rosettacode.org/wiki/Wireworld) |
| `Word-wrap` | word-wrap.fth | [Word-wrap](https://rosettacode.org/wiki/Word_wrap) |
| `Write-entire-file` | write-entire-file.fth | [Write-entire-file](https://rosettacode.org/wiki/Write_entire_file) |
| `Write-float-arrays-to-a-text-file` | write-float-arrays-to-a-text-file.fth | [Write-float-arrays-to-a-text-file](https://rosettacode.org/wiki/Write_float_arrays_to_a_text_file) |
| `Write-language-name-in-3D-ASCII` | write-language-name-in-3d-ascii-1.fth, write-language-name-in-3d-ascii-2.fth | [Write-language-name-in-3D-ASCII](https://rosettacode.org/wiki/Write_language_name_in_3D_ASCII) |
| `XML-DOM-serialization` | xml-dom-serialization.fth | [XML-DOM-serialization](https://rosettacode.org/wiki/XML_DOM_serialization) |
| `XML-Input` | xml-input.fth | [XML-Input](https://rosettacode.org/wiki/XML_Input) |
| `XML-Output` | xml-output.fth | [XML-Output](https://rosettacode.org/wiki/XML_Output) |
| `Y-combinator` | y-combinator-1.fth, y-combinator-2.fth, y-combinator-3.fth, y-combinator-4.fth | [Y-combinator](https://rosettacode.org/wiki/Y_combinator) |
| `Yellowstone-sequence` | yellowstone-sequence.fth | [Yellowstone-sequence](https://rosettacode.org/wiki/Yellowstone_sequence) |
| `Yin-and-yang` | yin-and-yang-1.fth, yin-and-yang-2.fth | [Yin-and-yang](https://rosettacode.org/wiki/Yin_and_yang) |
| `Zeckendorf-number-representation` | zeckendorf-number-representation.fth | [Zeckendorf-number-representation](https://rosettacode.org/wiki/Zeckendorf_number_representation) |
| `Zero-to-the-zero-power` | zero-to-the-zero-power-1.fth, zero-to-the-zero-power-2.fth | [Zero-to-the-zero-power](https://rosettacode.org/wiki/Zero_to_the_zero_power) |
| `Zig-zag-matrix` | zig-zag-matrix.fth | [Zig-zag-matrix](https://rosettacode.org/wiki/Zig_zag_matrix) |
