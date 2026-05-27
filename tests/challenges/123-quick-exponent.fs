\ tests/challenges/123-quick-exponent.fs
\
\ CHALLENGE: Recursive Power
\ Source: codewars  https://www.codewars.com/kata/recursive-exponentiation
\ Cognitive: 5/10  |  Pattern: recursive-power
\
\ Define a word
\
\   : power-rec  ( base exp -- n )
\
\ Compute base^exp recursively for non-negative exp.
\ Distinct from iterative ipow.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Recursive divide.
\   - exp fits cell.
\
include _tester.fs

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 2 10 power-rec -> 1024 }T
T{ 3 4 power-rec -> 81 }T
T{ 5 0 power-rec -> 1 }T
T{ 2 1 power-rec -> 2 }T

report bye
