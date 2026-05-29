\ tests/challenges/104-reverse-bits.fs
include _tester.fs

\ === paste your solution below this line ===

variable rev-n

: reverse-bits  ( n -- r )
  rev-n !
  0
  8 0 ?do
    rev-n @ i rshift 1 and if
      1 7 i - lshift +
    then
  loop ;

\ === paste your solution above this line ===

T{ 240 reverse-bits -> 15 }T
T{ 1 reverse-bits -> 128 }T
T{ 255 reverse-bits -> 255 }T

report bye
