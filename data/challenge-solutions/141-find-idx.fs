\ tests/challenges/141-find-idx.fs
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;

2 0 ch!  4 1 ch!  6 2 ch!  9 3 ch!  11 4 ch!
5 constant search-n

\ === paste your solution below this line ===

: find-idx ( key -- idx|-1 )
  { key# }  -1 { idx# }
  search-n 0 do
    key# i ch@ = if i to idx# then
  loop
  idx# ;

\ === paste your solution above this line ===

T{ 2 find-idx -> 0 }T
T{ 6 find-idx -> 2 }T
T{ 7 find-idx -> -1 }T
T{ 11 find-idx -> 4 }T

report bye
