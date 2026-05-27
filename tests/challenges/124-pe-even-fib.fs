\ tests/challenges/124-pe-even-fib.fs
\
\ CHALLENGE: PE Even Fibonacci Sum
\ Source: project-euler  https://projecteuler.net/problem=2
\ Cognitive: 4/10  |  Pattern: even-fibonacci-sum
\
\ Define a word
\
\   : pe-fib-sum  ( limit -- sum )
\
\ Return sum of even Fibonacci terms not exceeding limit.
\ Project Euler #2.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Iterative fib walk.
\   - limit on stack.
\
include _tester.fs

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 10 pe-fib-sum -> 10 }T
T{ 34 pe-fib-sum -> 44 }T
T{ 100 pe-fib-sum -> 44 }T

report bye
