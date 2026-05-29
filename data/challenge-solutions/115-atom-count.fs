\ tests/challenges/115-atom-count.fs
include _tester.fs
create ch-buf 64 chars allot
: ch-setup  ( c-addr u -- c-addr u ) ;

\ === paste your solution below this line ===

variable ac-c
variable ac-u
variable ac-i
variable ac-n

: alnum?  ( ch -- f )
  dup 48 >= swap 57 <= and
  swap dup 65 >= swap 90 <= and or ;

: atom-count  ( c-addr u -- n )
  ac-c !  ac-u !  0 ac-n !  0 ac-i !
  begin  ac-i @ ac-u @ < while
    ac-c @ ac-i @ + c@ alnum? if
      1 ac-n +!
    then
    ac-i @ 1+ ac-i !
  repeat  ac-n @ ;

\ === paste your solution above this line ===

T{ s" H2O" ch-setup atom-count -> 3 }T
T{ s" Mg(OH)2" ch-setup atom-count -> 6 }T
T{ s" K4(ON(SO3)2)2" ch-setup atom-count -> 18 }T
report bye
