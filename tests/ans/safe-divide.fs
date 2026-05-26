\ tests/ans/safe-divide.fs — error propagation via THROW / CATCH.
\ Exercises: -10 (ANS "divide by zero"), CATCH unwinds, wrapper word for ['].
\
\ Note: ['] is used inside a colon definition (compile state) — its normal place.
\ At interpret level we just call try-divide-by-zero.

include _tester.fs

: safe/  ( a b -- q )
  dup 0= if -10 throw then / ;

: divide-by-zero        ( -- )    20 0 safe/ drop ;
: try-divide-by-zero    ( -- code )  ['] divide-by-zero catch ;

T{ 20 5 safe/           ->   4 }T
T{ try-divide-by-zero   -> -10 }T

\ Successful path through CATCH returns 0 and leaves the result.
: try-normal  ( -- q code )  ['] safe/ 20 5 rot catch ;
\ Above is awkward; easier: wrap the call.
: ok-divide      ( -- )       20 5 safe/ drop ;
: try-ok-divide  ( -- code )  ['] ok-divide catch ;

T{ try-ok-divide -> 0 }T

report bye
