\ tests/challenges/145-arr-sum.fs
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;

10 0 ch!  20 1 ch!  30 2 ch!

\ === paste your solution below this line ===

: arr-sum ( u -- sum )
  0 swap 0 ?do  i ch@ +  loop ;

\ === paste your solution above this line ===

T{ 3 arr-sum -> 60 }T
T{ 0 arr-sum -> 0 }T
T{ 1 arr-sum -> 10 }T

report bye
