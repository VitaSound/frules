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

: fib ( n -- f )
  dup 0= if drop 0 exit then
  dup 1 = if drop 1 exit then
  { n }
  0 { a }
  1 { b }
  n 1 ?do
    a b + { c }
    b to a
    c to b
  loop
  b ;

\ Stack-only variant (no locals); counter on return stack.
: fib-stack ( n -- f )
  dup 0= if drop 0 exit then
  dup 1 = if drop 1 exit then
  >r
  0 1
  r@ 1- 0 ?do
    swap over +
  loop
  r> drop nip ;

\ === paste your solution above this line ===

T{ 0 fib -> 0 }T
T{ 1 fib -> 1 }T
T{ 5 fib -> 5 }T
T{ 10 fib -> 55 }T
T{ 20 fib -> 6765 }T

T{ 0 fib-stack -> 0 }T
T{ 1 fib-stack -> 1 }T
T{ 5 fib-stack -> 5 }T
T{ 10 fib-stack -> 55 }T
T{ 20 fib-stack -> 6765 }T

report bye
