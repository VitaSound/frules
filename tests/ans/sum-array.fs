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

sum-data 15 t=
0 @data 1 t=
4 @data 5 t=

100 2 !data
0 @data 1 t=
2 @data 100 t=
sum-data 112 t=    \ 1+2+100+4+5

report bye
