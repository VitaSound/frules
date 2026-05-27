\ tests/challenges/003-pow-x-n.fs
\
\ CHALLENGE: Pow(x, n)
\ Source: leetcode  https://leetcode.com/problems/powx-n/
\ Cognitive: 4/10  |  Pattern: integer-exponentiation
\
\ Define a word
\
\   : ipow  ( base exp -- n )
\
\ Raise base to non-negative exp using fast exponentiation.
\ Assume result fits in a cell.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Binary exponentiation preferred.
\   - exp=0 always returns 1.
\
include _tester.fs

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 2 10 ipow -> 1024 }T
T{ 3 0 ipow -> 1 }T
T{ 5 3 ipow -> 125 }T
T{ 2 16 ipow -> 65536 }T
T{ 10 2 ipow -> 100 }T

report bye
