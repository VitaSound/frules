\ tests/challenges/120-permute-count.fs
\
\ CHALLENGE: Permutations Count
\ Source: leetcode  https://leetcode.com/problems/permutations/
\ Cognitive: 5/10  |  Pattern: permutations-count
\
\ Define a word
\
\   : permute-n  ( n -- count )
\
\ Return n! for n distinct items.
\ Benchmark uses factorial count.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Recursive multiply.
\   - n<=10 in tests.
\
include _tester.fs

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 0 permute-n -> 1 }T
T{ 1 permute-n -> 1 }T
T{ 3 permute-n -> 6 }T
T{ 4 permute-n -> 24 }T
T{ 5 permute-n -> 120 }T

report bye
