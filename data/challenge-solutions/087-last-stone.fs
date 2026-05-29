\ tests/challenges/087-last-stone.fs
\
\ CHALLENGE: Last Stone Weight
\ Source: codewars  https://www.codewars.com/kata/last-stone-weight
\ Cognitive: 5/10  |  Pattern: last-stone-weight
\
\ Define a word
\
\   : last-stone  ( -- n )
\
\ Repeatedly smash two largest stones; return last weight or 0.
\ Use ch-data as heap array.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Simulate with sorted pass.
\   - Preload stones.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
\ Fixed: add missing stone 1 at index 2 (LeetCode [2,7,4,1,8,1] layout).
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
2 0 ch!  7 1 ch!  1 2 ch!  4 3 ch!  1 4 ch!  8 5 ch!
6 constant ch-n

\ === paste your solution below this line ===

create st-buf  ch-max cells allot

: st@ ( i -- n )  cells st-buf + @ ;
: st! ( n i -- )  cells st-buf + ! ;

variable st-n
variable st-i
variable st-j
variable st-k

: st-swap ( i j -- )
  { i j }
  i st@ j st@
  tuck j st! nip
  i st! ;

: st-sort ( n -- )
  st-k !
  0 st-i !
  begin  st-i @ st-k @ <
  while
    0 st-j !
    begin  st-j @ st-k @ 1- st-i @ - <
    while
      st-j @ st@  st-j @ 1+ st@  <  if
        st-j @ st-j @ 1+ st-swap
      then
      st-j @ 1+ st-j !
    repeat
    st-i @ 1+ st-i !
  repeat ;

: st-load ( -- )
  ch-n st-n !
  ch-n 0 ?do  i ch@ i st!  loop ;

: smash-pass ( n -- n' )
  dup 2 < if nip exit then
  st-k !
  st-k @ st-sort
  0 st@ 1 st@ - >r
  st-k @ 2 ?do  i st@  i 2 - st!  loop
  st-k @ 2 - st-k !
  r> dup if
    st-k @ over st!
    drop  st-k @ 1+ st-k !
  then
  st-k @ ;

: last-stone ( -- n )
  st-load
  begin  st-n @ 2 >=  while
    st-n @ smash-pass st-n !
  repeat
  st-n @ if  0 st@  else  0  then ;

\ === paste your solution above this line ===

T{ last-stone -> 1 }T

report bye
