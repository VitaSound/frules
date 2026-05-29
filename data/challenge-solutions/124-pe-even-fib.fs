\ tests/challenges/124-pe-even-fib.fs
include _tester.fs

\ === paste your solution below this line ===

variable pe-lim
variable pe-sum
variable pe-a
variable pe-b

: pe-fib-sum  ( limit -- sum )
  pe-lim !  0 pe-sum !  1 pe-a !  1 pe-b !
  begin  pe-b @ pe-lim @ <= while
    pe-b @ 1 and 0= if
      pe-b @ pe-sum @ + pe-sum !
    then
    pe-b @ dup pe-a @ rot + pe-b !
    pe-a !
  repeat  pe-sum @ ;

\ === paste your solution above this line ===

T{ 10 pe-fib-sum -> 10 }T
T{ 34 pe-fib-sum -> 44 }T
T{ 100 pe-fib-sum -> 44 }T
report bye
