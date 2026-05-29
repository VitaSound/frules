\ tests/challenges/079-candy.fs
\
\ CHALLENGE: Candy
\ Source: leetcode  https://leetcode.com/problems/candy/
\ Cognitive: 6/10  |  Pattern: candy-distribution
\
\ Define a word
\
\   : candy-min  ( -- total )
\
\ Return minimum candies for ch-data ratings (neighbors compare).
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Two-pass greedy.
\   - Uses ch-n.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
1 0 ch!  0 1 ch!  2 2 ch!
3 constant ch-n

\ === paste your solution below this line ===

create ch-candy  ch-max cells allot

: candy@ ( i -- n )  cells ch-candy + @ ;
: candy! ( n i -- )  tuck cells ch-candy + ! ;

variable candy-tot

: candy-min ( -- total )
  ch-n 0= if  0 exit  then
  1 0 candy!
  ch-n 1 ?do
    i ch@  i 1- ch@  >
    if  i 1- candy@ 1+  i candy!
    else  1 i candy!
    then
  loop
  ch-n 2 >= if
    ch-n 1- 0 ?do
      ch-n 2 - i -  { idx }
      idx ch@  idx 1+ ch@  >
      if  idx 1+ candy@ 1+  idx candy@ max  idx candy!
      else  drop
      then
    loop
  else  drop
  then
  0 candy-tot !
  ch-n 0 ?do  candy-tot @ i candy@ + candy-tot !  loop
  begin  depth  while  drop  repeat
  candy-tot @ ;

\ === paste your solution above this line ===

T{ candy-min -> 5 }T

report bye
