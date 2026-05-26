\ tests/gforth/clamp-locals.fs — clamp(n, lo, hi) with Gforth locals.
\ Exercises: 3-arg locals, no PICK / ROLL, simple math.

include _tester.fs

: clamp  ( n lo hi -- n' )
  { n lo hi }
  n hi min  lo max ;

T{   5  0 10 clamp ->  5 }T
T{  -3  0 10 clamp ->  0 }T
T{  42  0 10 clamp -> 10 }T
T{   0  0 10 clamp ->  0 }T
T{  10  0 10 clamp -> 10 }T
T{ 100 50 60 clamp -> 60 }T

report bye
