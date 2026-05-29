\ tests/challenges/120-permute-count.fs
include _tester.fs

\ === paste your solution below this line ===

: permute-n  ( n -- count )
  1 swap  1+  1 ?do  i *  loop ;

\ === paste your solution above this line ===

T{ 0 permute-n -> 1 }T
T{ 1 permute-n -> 1 }T
T{ 3 permute-n -> 6 }T
T{ 4 permute-n -> 24 }T
T{ 5 permute-n -> 120 }T

report bye
