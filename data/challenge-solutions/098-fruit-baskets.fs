\ tests/challenges/098-fruit-baskets.fs
\
\ CHALLENGE: Fruit Into Baskets
\ Source: leetcode  https://leetcode.com/problems/fruit-into-baskets/
\ Cognitive: 5/10  |  Pattern: fruit-into-baskets
\
\ Define a word
\
\   : fruit-baskets  ( -- len )
\
\ Return longest subarray with at most 2 distinct values in ch-data.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Sliding window.
\   - Uses ch-n.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
\ Fixed: longest two-type window [1,2,1,2] has length 4.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
1 0 ch!  2 1 ch!  1 2 ch!  2 3 ch!  3 4 ch!
5 constant ch-n

\ === paste your solution below this line ===

create fb-cnt  ch-max cells allot

variable fb-left
variable fb-best
variable fb-kinds

: fb-cnt@ ( val -- n )  cells fb-cnt + @ ;
: fb-cnt! ( n val -- )  cells fb-cnt + ! ;

: fb-clear ( -- )
  ch-max 0 ?do  0 i fb-cnt!  loop
  0 fb-left !  0 fb-best !  0 fb-kinds ! ;

: fb-add ( val -- )
  dup fb-cnt@ dup if
    1+ swap fb-cnt!
  else
    drop  1 swap fb-cnt!  1 fb-kinds +!
  then ;

: fb-remove ( val -- )
  dup fb-cnt@ 1- dup if
    swap fb-cnt!
  else
    drop  0 swap fb-cnt!  -1 fb-kinds +!
  then ;

: fruit-baskets ( -- len )
  fb-clear
  ch-n 0 ?do
    i ch@ fb-add
    begin  fb-kinds @ 2 >  while
      fb-left @ ch@ fb-remove
      fb-left @ 1+ fb-left !
    repeat
    i fb-left @ - 1+ fb-best @ max fb-best !
  loop
  fb-best @ ;

\ === paste your solution above this line ===

T{ fruit-baskets -> 4 }T

report bye
