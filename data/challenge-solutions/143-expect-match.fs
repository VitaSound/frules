\ tests/challenges/143-expect-match.fs
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
variable expect-val
: expect! ( n -- )  expect-val ! ;

\ === paste your solution below this line ===

: matches? ( n -- flag )  expect-val @ = ;

\ === paste your solution above this line ===

T{ 42 expect!  42 matches? -> true }T
T{ 42 expect!  7 matches? -> false }T
T{ 0 expect!  0 matches? -> true }T

report bye
