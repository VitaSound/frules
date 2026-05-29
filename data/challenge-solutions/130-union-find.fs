\ tests/challenges/130-union-find.fs
include _tester.fs
16 constant ch-max
create ch-data ch-max cells allot
: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( i n -- )  swap cells ch-data + ! ;
2 1 ch!  3 1 ch!  4 4 ch!  5 4 ch!
5 constant ch-n

\ === paste your solution below this line ===

: uf-find  ( i -- root )  cells ch-data + @ ;

\ === paste your solution above this line ===

T{ 3 uf-find -> 1 }T
T{ 4 uf-find -> 4 }T
T{ 5 uf-find -> 4 }T
report bye
