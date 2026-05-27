\ tests/challenges/007-gcd.fs
\
\ CHALLENGE: Greatest Common Divisor
\ Source: rosetta  https://rosettacode.org/wiki/Greatest_common_divisor
\ Cognitive: 3/10  |  Pattern: euclid-gcd
\
\ Define a word
\
\   : gcd  ( a b -- g )
\
\ Return gcd(a,b) using Euclidean algorithm.
\ gcd(0,b) returns abs(b).
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Keep stack depth shallow.
\   - Use ABS on result.
\
include _tester.fs

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 48 18 gcd -> 6 }T
T{ 101 10 gcd -> 1 }T
T{ 0 7 gcd -> 7 }T
T{ -12 8 gcd -> 4 }T
T{ 270 192 gcd -> 6 }T

report bye
