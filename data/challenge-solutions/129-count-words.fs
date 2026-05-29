\ tests/challenges/129-count-words.fs
include _tester.fs
create ch-buf 64 chars allot
: ch-setup  ( c-addr u -- c-addr u ) ;

\ === paste your solution below this line ===

variable wc-c
variable wc-u
variable wc-i
variable wc-n

: word-count  ( c-addr u -- n )
  wc-c !  wc-u !  0 wc-n !  0 wc-i !
  begin  wc-i @ wc-u @ < while
    wc-c @ wc-i @ + c@ bl <>
    wc-i @ 0= if
      1 wc-n +!
    else
      wc-i @ 0> if
        wc-c @ wc-i @ 1- + c@ bl = if
          1 wc-n +!
        then
      then
    then
    wc-i @ 1+ wc-i !
  repeat  wc-n @ ;

\ === paste your solution above this line ===

T{ s" one two three" ch-setup word-count -> 3 }T
T{ s"  a  b " ch-setup word-count -> 2 }T
T{ s" " ch-setup word-count -> 0 }T
T{ s" x" ch-setup word-count -> 1 }T
report bye
