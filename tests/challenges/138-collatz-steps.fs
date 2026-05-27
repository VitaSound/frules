\ tests/challenges/138-collatz-steps.fs
\
\ CHALLENGE: Collatz Steps
\ Source: project-euler  https://projecteuler.net/problem=14
\ Cognitive: 4/10  |  Pattern: collatz-sequence-length
\
\ Define a word
\
\   : collatz  ( n -- steps )
\
\ Return number of steps to reach 1 in Collatz sequence starting at n.
\ n>=1.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - While loop.
\   - Classic PE pattern.
\
include _tester.fs

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 1 collatz -> 0 }T
T{ 13 collatz -> 9 }T
T{ 27 collatz -> 111 }T

report bye
