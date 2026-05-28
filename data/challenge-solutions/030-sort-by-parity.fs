\ tests/challenges/030-sort-by-parity.fs
\
\ CHALLENGE: Sort By Parity
\ Source: leetcode  https://leetcode.com/problems/sort-array-by-parity/
\ Cognitive: 4/10  |  Pattern: sort-array-by-parity
\
\ Define a word
\
\   : sort-parity  ( -- )
\
\ Reorder ch-data so evens precede odds.
\ Relative order within parity groups may change.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Two-pointer swap.
\   - In-place.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
\ Fixed: tests used "ch@ i" (underflow); index must precede ch@.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
3 0 ch!  1 1 ch!  2 2 ch!  4 3 ch!
4 constant ch-n

\ === paste your solution below this line ===

variable parity-lo
variable swap-x
variable swap-y

: ch-swap  ( ia ib -- )
  swap-x !  swap-y !
  swap-x @ ch@  swap-y @ ch@
  2dup swap-x @ ch!  nip nip  swap-y @ ch! ;

: reverse-range  ( lo hi -- )
  swap-y !  swap-x !
  begin swap-x @ swap-y @ < while
    swap-x @ swap-y @ ch-swap
    swap-x @ 1+ swap-x !
    swap-y @ 1- swap-y !
  repeat ;

: sort-parity  ( -- )
  0 parity-lo !
  ch-n 0 ?do
    i ch@ 1 and 0= if
      parity-lo @ i ch-swap
      parity-lo @ 1+ parity-lo !
    then
  loop
  parity-lo @ ch-n 1- reverse-range ;

\ === paste your solution above this line ===

T{ sort-parity }T
T{ 0 ch@ -> 2 }T
T{ 3 ch@ -> 3 }T

report bye
