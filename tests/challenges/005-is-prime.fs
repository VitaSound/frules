\ tests/challenges/005-is-prime.fs
\
\ CHALLENGE: Is Prime
\ Source: kata  https://www.codewars.com/kata/is-this-a-prime-number
\ Cognitive: 5/10  |  Pattern: primality-trial
\
\ Define a word
\
\   : prime?  ( n -- flag )
\
\ Return TRUE iff n>=2 and n has no divisors except 1 and itself.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Trial division is fine.
\   - Return true/false.
\
include _tester.fs

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 0 prime? -> false }T
T{ 1 prime? -> false }T
T{ 2 prime? -> true }T
T{ 17 prime? -> true }T
T{ 18 prime? -> false }T
T{ 97 prime? -> true }T

report bye
