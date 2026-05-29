\ tests/challenges/105-divide-int.fs
\
\ CHALLENGE: Divide Two Integers
\ Source: leetcode  https://leetcode.com/problems/divide-two-integers/
\ Cognitive: 6/10  |  Pattern: divide-two-integers
\
\ Define a word
\
\   : divide-int  ( a b -- q )
\
\ Return a/b truncated toward zero without using / or mod.
\ Assume b!=0.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Bit shift subtract.
\   - Handle signs.
\
include _tester.fs

\ === paste your solution below this line ===

variable da
variable db
variable udiv-n
variable udiv-d
variable udiv-q
variable udiv-t
variable udiv-b

: uabs  ( n -- u )
  dup 0< if negate then ;

: udiv-can-shift?  ( -- f )
  udiv-t @ 1 lshift  dup  0>=  if
    udiv-n @  <=
  else
    drop  0
  then ;

: udiv-shift-sub  ( -- )
  udiv-d @ udiv-t !
  1 udiv-b !
  begin  udiv-can-shift?  while
    udiv-t @ 1 lshift  udiv-t !
    udiv-b @ 1 lshift  udiv-b !
  repeat ;

: udiv-pos  ( dividend divisor -- q )
  swap udiv-n ! udiv-d !
  0 udiv-q !
  begin  udiv-n @ udiv-d @ >=  while
    udiv-shift-sub
    udiv-n @ udiv-t @ -  udiv-n !
    udiv-q @ udiv-b @ +  udiv-q !
  repeat  udiv-q @ ;

: divide-int  ( a b -- q )
  db !  da !
  da @ 0<  db @ 0<  <>  >r
  da @ uabs  db @ uabs  udiv-pos
  r> if negate then ;

\ === paste your solution above this line ===

T{ 10 3 divide-int -> 3 }T
T{ -10 3 divide-int -> -3 }T
T{ 7 2 divide-int -> 3 }T
T{ 0 5 divide-int -> 0 }T

report bye
