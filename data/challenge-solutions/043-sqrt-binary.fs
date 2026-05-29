\ tests/challenges/043-sqrt-binary.fs
\
\ CHALLENGE: Sqrt x Binary
\ Source: leetcode  https://leetcode.com/problems/sqrtx/
\ Cognitive: 4/10  |  Pattern: sqrt-binary-search
\
\ Define a word
\
\   : isqrt-n  ( n -- r )
\
\ Return floor(sqrt(n)) for non-negative n.
\ Binary search variant of isqrt.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - No floating point.
\   - Distinct from scalar isqrt pattern key.
\
include _tester.fs

\ === paste your solution below this line ===

: isqrt-n ( n -- r )
  dup 0= if drop 0 exit then
  { n }
  0 { lo }
  n 1+ { hi }
  begin  hi lo - 1 u>  while
    lo hi + 2/ { mid }
    mid mid * n u<= if  mid to lo  else  mid to hi  then
  repeat
  lo ;

\ === paste your solution above this line ===

T{ 0 isqrt-n -> 0 }T
T{ 4 isqrt-n -> 2 }T
T{ 8 isqrt-n -> 2 }T
T{ 17 isqrt-n -> 4 }T

report bye
