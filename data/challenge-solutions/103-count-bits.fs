\ tests/challenges/103-count-bits.fs
include _tester.fs

\ === paste your solution below this line ===

: count-bits  ( n -- c )  recursive
  dup 0= if  drop 0 exit  then
  dup 1- and count-bits 1+ ;

\ === paste your solution above this line ===

T{ 0 count-bits -> 0 }T
T{ 1 count-bits -> 1 }T
T{ 5 count-bits -> 2 }T
T{ 7 count-bits -> 3 }T
T{ 15 count-bits -> 4 }T

report bye
