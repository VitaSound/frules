\ tests/challenges/021-next-permutation.fs
\
\ CHALLENGE: Next Permutation
\ Source: leetcode  https://leetcode.com/problems/next-permutation/
\ Cognitive: 7/10  |  Pattern: next-permutation-step
\
\ Define a word
\
\   : next-perm?  ( -- flag )
\
\ Transform ch-data[0..ch-n) to next lexicographic permutation in place.
\ Return FALSE if last permutation.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Standard algorithm; mutate ch-data.
\   - Return true/false.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
1 0 ch!  2 1 ch!  3 2 ch!
3 constant ch-n

\ === paste your solution below this line ===

variable piv-i
variable swap-j
variable piv-found
variable rev-lo
variable rev-hi
variable swap-x
variable swap-y

: ch-swap ( i j -- )
  swap-x !  swap-y !
  swap-x @ ch@  swap-y @ ch@
  2dup swap-x @ ch!  nip nip  swap-y @ ch! ;

: reverse-seg ( start end -- )
  rev-hi !  rev-lo !
  begin
    rev-hi @ rev-lo @ - 1 >
  while
    rev-lo @ rev-hi @ 1-  ch-swap
    rev-lo @ 1+ rev-lo !
    rev-hi @ 1- rev-hi !
  repeat ;

: find-pivot ( -- i )
  ch-n 1- 1- piv-i !
  false piv-found !
  begin
    piv-i @ 0>=  piv-found @ 0=  and
  while
    piv-i @  dup dup ch@  over 1+ ch@  <
    if
      2drop  true piv-found !
    else
      2drop  piv-i @ 1-  piv-i !
    then
  repeat
  piv-found @ if  piv-i @  else  -1  then ;

: find-swap ( -- j )
  ch-n 1- swap-j !
  false piv-found !
  begin
    swap-j @ piv-i @ >  piv-found @ 0=  and
  while
    swap-j @ ch@  piv-i @ ch@  >
    if
      true piv-found !
    else
      swap-j @ 1-  swap-j !
    then
  repeat
  swap-j @ ;

: next-perm? ( -- flag )
  find-pivot dup 0< if
    drop  0 ch-n reverse-seg  false
  else
    drop  find-swap drop
    piv-i @ swap-j @ ch-swap
    piv-i @ 1+ ch-n reverse-seg  true
  then ;

: reset-fixture ( -- )
  1 0 ch!  2 1 ch!  3 2 ch! ;

: next-perm-stack ( -- flag )
  next-perm? ;

\ === paste your solution above this line ===

T{ reset-fixture next-perm? -> true }T
T{ 0 ch@ -> 1 }T
T{ 1 ch@ -> 3 }T
T{ 2 ch@ -> 2 }T

T{ reset-fixture next-perm-stack -> true }T
T{ 0 ch@ -> 1 }T
T{ 1 ch@ -> 3 }T
T{ 2 ch@ -> 2 }T

report bye
