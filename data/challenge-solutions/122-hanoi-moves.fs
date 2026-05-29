\ tests/challenges/122-hanoi-moves.fs
include _tester.fs

\ === paste your solution below this line ===

: hanoi  ( n -- moves )
  1 swap lshift 1- ;

\ === paste your solution above this line ===

T{ 0 hanoi -> 0 }T
T{ 1 hanoi -> 1 }T
T{ 3 hanoi -> 7 }T
T{ 4 hanoi -> 15 }T
T{ 10 hanoi -> 1023 }T
report bye
