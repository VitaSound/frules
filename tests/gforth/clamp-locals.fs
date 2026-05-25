\ tests/gforth/clamp-locals.fs — clamp(n, lo, hi) with Gforth locals.
\ Exercises: 3-arg locals, no PICK / ROLL, simple math.

include _tester.fs

: clamp  ( n lo hi -- n' )
  { n lo hi }
  n hi min  lo max ;

   5  0 10 clamp   5 t=
  -3  0 10 clamp   0 t=
  42  0 10 clamp  10 t=
   0  0 10 clamp   0 t=
  10  0 10 clamp  10 t=
 100 50 60 clamp  60 t=

report bye
