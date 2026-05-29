\ tests/challenges/116-fizzbuzz-count.fs
include _tester.fs

\ === paste your solution below this line ===

: fizzbuzz-n  ( n -- count )
  0 swap
  1+ 1 ?do
    i 3 mod 0=  i 5 mod 0= or if  1+  then
  loop ;

\ === paste your solution above this line ===

T{ 15 fizzbuzz-n -> 7 }T
T{ 30 fizzbuzz-n -> 14 }T
T{ 1 fizzbuzz-n -> 0 }T

report bye
