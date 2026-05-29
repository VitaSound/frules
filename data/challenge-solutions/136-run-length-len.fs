\ tests/challenges/136-run-length-len.fs
include _tester.fs
create ch-buf 64 chars allot
: ch-setup  ( c-addr u -- c-addr u ) ;

\ === paste your solution below this line ===

variable rl-c
variable rl-u
variable rl-i
variable rl-n
variable rl-run
variable rl-ch

: rle-len  ( c-addr u -- out-u )
  rl-c !  rl-u !  0 rl-n !  0 rl-i !
  rl-c @ 0 rl-u @ 0= if  rl-n @ exit  then
  rl-c @ 0 c@ rl-ch !
  1 rl-run !
  begin  rl-i @ rl-u @ < while
    rl-c @ rl-i @ + c@ rl-ch @ =
    if  1 rl-run +!  else
      1 rl-n +!
      rl-run @ 1 > if  rl-run @ 1 rl-n +!  then
      rl-c @ rl-i @ + c@ rl-ch !
      1 rl-run !
    then
    rl-i @ 1+ rl-i !
  repeat
  1 rl-n +!
  rl-run @ 1 > if  rl-run @ 1 rl-n +!  then
  rl-n @ ;

\ === paste your solution above this line ===

T{ s" aaa" ch-setup rle-len -> 2 }T
T{ s" aabbb" ch-setup rle-len -> 4 }T
T{ s" ab" ch-setup rle-len -> 2 }T
report bye
