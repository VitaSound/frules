\ tests/challenges/123-quick-exponent.fs
include _tester.fs

\ === paste your solution below this line ===

variable ip-b
variable ip-e

: power-rec  ( base exp -- n )
  swap  ip-b !  ip-e !  1
  begin  ip-e @  while
    ip-b @ *  ip-e @ 1- ip-e !
  repeat ;

\ === paste your solution above this line ===

T{ 2 10 power-rec -> 1024 }T
T{ 3 4 power-rec -> 81 }T
T{ 5 0 power-rec -> 1 }T
T{ 2 1 power-rec -> 2 }T
report bye
