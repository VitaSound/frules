\ tests/challenges/103-count-bits.fs
\
\ CHALLENGE: Counting Bits
\ Source: leetcode  https://leetcode.com/problems/counting-bits/
\ Cognitive: 4/10  |  Pattern: counting-bits-popcount
\
\ Define a word
\
\   : count-bits  ( n -- c )
\
\ Return number of 1-bits in binary representation of n.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Brian Kernighan or lookup.
\   - Non-negative n.
\
include _tester.fs

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 0 count-bits -> 0 }T
T{ 1 count-bits -> 1 }T
T{ 5 count-bits -> 2 }T
T{ 7 count-bits -> 3 }T
T{ 15 count-bits -> 4 }T

report bye
