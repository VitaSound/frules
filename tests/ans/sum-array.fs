\ tests/ans/sum-array.fs — CREATE/DOES> defining word + DO loop.
\ Exercises: defining words, CELLS for portable scaling, accumulator pattern.

include _tester.fs

: cell-array  ( n "name" -- )
  create cells allot
  does>     ( i a-addr -- addr )  swap cells + ;

5 cell-array data

: !data  ( n i -- )  data ! ;
: @data  ( i -- n )  data @ ;

: fill-data  ( -- )
  1 0 !data  2 1 !data  3 2 !data  4 3 !data  5 4 !data ;

: sum-data  ( -- n )
  0  5 0 ?do  i @data +  loop ;

fill-data

T{ sum-data ->  15 }T
T{ 0 @data  ->   1 }T
T{ 4 @data  ->   5 }T

100 2 !data
T{ 0 @data  ->   1 }T
T{ 2 @data  -> 100 }T
T{ sum-data -> 112 }T    \ 1+2+100+4+5

report bye
