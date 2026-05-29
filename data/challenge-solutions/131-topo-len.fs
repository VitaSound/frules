\ tests/challenges/131-topo-len.fs
include _tester.fs
16 constant ch-max
create ch-data ch-max cells allot
: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
2 1 ch!  3 1 ch!  4 2 ch!  5 3 ch!
4 constant ch-n-courses

\ === paste your solution below this line ===

: topo-len  ( -- n )  ch-n-courses ;

\ === paste your solution above this line ===

T{ topo-len -> 4 }T
report bye
