\ tests/challenges/022-sort-colors.fs
\
\ CHALLENGE: Sort Colors
\ Source: leetcode  https://leetcode.com/problems/sort-colors/
\ Cognitive: 5/10  |  Pattern: dutch-national-flag-sort
\
\ Define a word
\
\   : sort-colors  ( -- )
\
\ Sort ch-data[0..ch-n) containing only 0,1,2 in place.
\ One pass preferred.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Three-way partition.
\   - Mutates ch-data.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
2 0 ch!  0 1 ch!  2 2 ch!  1 3 ch!  0 4 ch!
5 constant ch-n

\ === paste your solution below this line ===

variable dnf-lo
variable dnf-mid
variable dnf-hi
variable swap-x
variable swap-y

: ch-swap ( i j -- )
  swap-x !  swap-y !
  swap-x @ ch@  swap-y @ ch@
  2dup swap-x @ ch!  nip nip  swap-y @ ch! ;

: sort-colors ( -- )
  0 dnf-lo !
  0 dnf-mid !
  ch-n 1- dnf-hi !
  begin
    dnf-mid @ dnf-hi @ <=
  while
    dnf-mid @ ch@
    dup 0= if
      drop  dnf-lo @ dnf-mid @ ch-swap
      dnf-lo @ 1+ dnf-lo !
      dnf-mid @ 1+ dnf-mid !
    else  dup 2 = if
      drop  dnf-mid @ dnf-hi @ ch-swap
      dnf-hi @ 1- dnf-hi !
    else
      drop  dnf-mid @ 1+ dnf-mid !
    then  then
  repeat ;

: sort-colors-stack ( -- )
  sort-colors ;

\ === paste your solution above this line ===

T{ sort-colors }T
T{ 0 ch@ -> 0 }T
T{ 4 ch@ -> 2 }T

report bye
