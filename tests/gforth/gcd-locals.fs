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

12  8 gcd  4 t=
17  5 gcd  1 t=
 0  7 gcd  7 t=
 7  0 gcd  7 t=
48 18 gcd  6 t=

report bye
