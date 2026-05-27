\ tests/challenges/121-subsets-count.fs
\
\ CHALLENGE: Subsets Count
\ Source: leetcode  https://leetcode.com/problems/subsets/
\ Cognitive: 4/10  |  Pattern: subsets-count
\
\ Define a word
\
\   : subsets-n  ( n -- count )
\
\ Return 2^n count of subsets of n elements.
\ n<=10.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Bit shift or recursion.
\   - Power of two.
\
include _tester.fs

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 0 subsets-n -> 1 }T
T{ 1 subsets-n -> 2 }T
T{ 3 subsets-n -> 8 }T
T{ 10 subsets-n -> 1024 }T

report bye
