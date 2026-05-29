\ tests/challenges/125-pe-sum-square.fs
include _tester.fs

\ === paste your solution below this line ===

: sum-1..n  ( n -- s )
  dup 1+ * 2/ ;

: sum-sq-1..n  ( n -- s )
  dup  dup 1+ swap 2* 1+ *  *  6 / ;

: pe-sum-square  ( n -- diff )
  dup sum-1..n dup *  swap sum-sq-1..n - ;

\ === paste your solution above this line ===

T{ 10 pe-sum-square -> 2640 }T
T{ 100 pe-sum-square -> 25164150 }T
T{ 1 pe-sum-square -> 0 }T
report bye
