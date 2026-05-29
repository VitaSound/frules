\ tests/challenges/142-sq-brackets.fs
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
create ch-buf 64 chars allot

: ch-setup  ( c-addr u -- ch-buf u )
  dup >r  ch-buf swap  move  ch-buf r> ;

\ === paste your solution below this line ===

variable sq-lev

: sq-brackets? ( c-addr u -- flag )
  0 sq-lev !
  dup if
    bounds ?do
      i c@ case
        91 of  1  endof
        93 of -1  endof
        0
      endcase
      sq-lev @ + sq-lev !
    loop
  else
    2drop
  then
  sq-lev @ 0= ;

\ === paste your solution above this line ===

T{ s" " ch-setup sq-brackets? -> true }T
T{ s" []" ch-setup sq-brackets? -> true }T
T{ s" [[]]" ch-setup sq-brackets? -> true }T
T{ s" [[]" ch-setup sq-brackets? -> false }T
T{ s" ][ " ch-setup sq-brackets? -> false }T

report bye
