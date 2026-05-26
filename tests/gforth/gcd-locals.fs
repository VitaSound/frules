\ tests/gforth/gcd-locals.fs — same GCD as ans/gcd.fs, but with Gforth locals.
\ Exercises: { a b } binding order (rightmost = TOS), TO for mutating a value local,
\ readability over stack juggling.

include _tester.fs

: gcd  ( a b -- g )
  { a b }
  begin b while
    b a b mod  to b  to a
  repeat
  a ;

T{ 12  8 gcd -> 4 }T
T{ 17  5 gcd -> 1 }T
T{  0  7 gcd -> 7 }T
T{  7  0 gcd -> 7 }T
T{ 48 18 gcd -> 6 }T

report bye
