\ tests/ans/gcd.fs — Euclidean GCD, iterative, no locals.
\ Exercises: BEGIN WHILE REPEAT, MOD, stack juggling without PICK/ROLL.

include _tester.fs

: gcd  ( a b -- g )
  begin dup while  tuck mod  repeat drop ;

T{ 12  8 gcd -> 4 }T
T{ 17  5 gcd -> 1 }T
T{  0  7 gcd -> 7 }T
T{  7  0 gcd -> 7 }T
T{ 48 18 gcd -> 6 }T

report bye
