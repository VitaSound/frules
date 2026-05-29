\ tests/challenges/074-pe-multiples.fs
\
\ CHALLENGE: PE Multiples of 3 and 5
\ Source: project-euler  https://projecteuler.net/problem=1
\ Cognitive: 3/10  |  Pattern: project-euler-multiples
\
\ Define a word
\
\   : pe-mult3-5  ( limit -- sum )
\
\ Return sum of natural numbers below limit divisible by 3 or 5.
\ Classic Project Euler #1.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Inclusion-exclusion or simple loop.
\   - limit on stack.
\
include _tester.fs

\ === paste your solution below this line ===

: pe-mult3-5 ( limit -- sum )
  0 swap 0 ?do
    i dup 3 mod 0=  over 5 mod 0=  or if  +  else  drop  then
  loop ;

\ === paste your solution above this line ===

T{ 10 pe-mult3-5 -> 23 }T
T{ 1000 pe-mult3-5 -> 233168 }T
T{ 15 pe-mult3-5 -> 45 }T

report bye
