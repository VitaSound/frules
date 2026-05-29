\ tests/challenges/106-hamming-weight.fs
include _tester.fs

\ === paste your solution below this line ===

: hamming  ( n -- w )  recursive
  dup 0= if  drop 0 exit  then
  dup 1- and hamming 1+ ;

\ === paste your solution above this line ===

T{ 0 hamming -> 0 }T
T{ 106 hamming -> 4 }T
T{ 255 hamming -> 8 }T
T{ 13 hamming -> 3 }T

report bye
