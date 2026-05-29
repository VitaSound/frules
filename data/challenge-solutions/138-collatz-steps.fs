\ tests/challenges/138-collatz-steps.fs
include _tester.fs

\ === paste your solution below this line ===

variable col-n
variable col-s

: collatz  ( n -- steps )
  col-n !  0 col-s !
  begin  col-n @ 1 > while
    col-s @ 1+ col-s !
    col-n @ 1 and 0= if
      col-n @ 2/ col-n !
    else
      col-n @ 3 * 1+ col-n !
    then
  repeat  col-s @ ;

\ === paste your solution above this line ===

T{ 1 collatz -> 0 }T
T{ 13 collatz -> 9 }T
T{ 27 collatz -> 111 }T
report bye
