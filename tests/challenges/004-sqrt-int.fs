\ tests/challenges/004-sqrt-int.fs
\
\ CHALLENGE: Integer Square Root
\ Source: codewars  https://www.codewars.com/kata/integer-square-root
\ Cognitive: 4/10  |  Pattern: integer-sqrt-floor
\
\ Define a word
\
\   : isqrt  ( n -- r )
\
\ Return floor(sqrt(n)) for non-negative n.
\ No floating point.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Binary search or Newton iteration.
\   - n=0 returns 0.
\
include _tester.fs

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 0 isqrt -> 0 }T
T{ 1 isqrt -> 1 }T
T{ 8 isqrt -> 2 }T
T{ 15 isqrt -> 3 }T
T{ 16 isqrt -> 4 }T
T{ 99 isqrt -> 9 }T

report bye
