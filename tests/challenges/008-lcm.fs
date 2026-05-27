\ tests/challenges/008-lcm.fs
\
\ CHALLENGE: Least Common Multiple
\ Source: rosetta  https://rosettacode.org/wiki/Least_common_multiple
\ Cognitive: 4/10  |  Pattern: least-common-multiple
\
\ Define a word
\
\   : lcm  ( a b -- m )
\
\ Return lcm(a,b) = abs(a*b)/gcd(a,b).
\ Either argument may be zero (return 0).
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Reuse gcd or inline Euclid.
\   - Handle zero without divide-by-zero.
\
include _tester.fs

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 4 6 lcm -> 12 }T
T{ 21 6 lcm -> 42 }T
T{ 0 5 lcm -> 0 }T
T{ 7 7 lcm -> 7 }T
T{ 9 12 lcm -> 36 }T

report bye
