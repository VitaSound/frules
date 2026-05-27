\ tests/challenges/104-reverse-bits.fs
\
\ CHALLENGE: Reverse Bits
\ Source: leetcode  https://leetcode.com/problems/reverse-bits/
\ Cognitive: 5/10  |  Pattern: reverse-bits-32
\
\ Define a word
\
\   : reverse-bits  ( n -- r )
\
\ Reverse low 8 bits of n for benchmark (8-bit variant).
\ Higher bits zero.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Bit iteration.
\   - 8-bit test scope.
\
include _tester.fs

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 240 reverse-bits -> 15 }T
T{ 1 reverse-bits -> 128 }T
T{ 255 reverse-bits -> 255 }T

report bye
