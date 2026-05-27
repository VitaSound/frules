\ tests/challenges/006-fib-nth.fs
\
\ CHALLENGE: Nth Fibonacci
\ Source: rosetta  https://rosettacode.org/wiki/Fibonacci_sequence
\ Cognitive: 3/10  |  Pattern: fibonacci-nth-term
\
\ Define a word
\
\   : fib  ( n -- f )
\
\ Return F(n) with F(0)=0, F(1)=1.
\ Assume n<=30 for cell safety.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Iterative preferred.
\   - No magic indices in loop body.
\
include _tester.fs

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 0 fib -> 0 }T
T{ 1 fib -> 1 }T
T{ 5 fib -> 5 }T
T{ 10 fib -> 55 }T
T{ 20 fib -> 6765 }T

report bye
