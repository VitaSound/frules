\ tests/ans/gcd.fs — Euclidean GCD, iterative, no locals.
\ Exercises: BEGIN WHILE REPEAT, MOD, stack juggling without PICK/ROLL.

include _tester.fs

: gcd  ( a b -- g )
  begin dup while  tuck mod  repeat drop ;

12  8 gcd  4 t=
17  5 gcd  1 t=
 0  7 gcd  7 t=
 7  0 gcd  7 t=
48 18 gcd  6 t=

report bye
