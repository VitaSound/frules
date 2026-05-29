\ tests/challenges/121-subsets-count.fs
include _tester.fs

\ === paste your solution below this line ===

: subsets-n  ( n -- count )
  1 swap lshift ;

\ === paste your solution above this line ===

T{ 0 subsets-n -> 1 }T
T{ 1 subsets-n -> 2 }T
T{ 3 subsets-n -> 8 }T
T{ 10 subsets-n -> 1024 }T
report bye
