\ tests/challenges/125-pe-sum-square.fs
\
\ CHALLENGE: PE Sum Square Difference
\ Source: project-euler  https://projecteuler.net/problem=6
\ Cognitive: 3/10  |  Pattern: sum-square-difference
\
\ Define a word
\
\   : pe-sum-square  ( n -- diff )
\
\ Return (sum 1..n)^2 - sum of squares 1..n.
\ Project Euler #6.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Closed form or loop.
\   - n positive.
\
include _tester.fs

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 10 pe-sum-square -> 2640 }T
T{ 100 pe-sum-square -> 25164150 }T
T{ 1 pe-sum-square -> 0 }T

report bye
