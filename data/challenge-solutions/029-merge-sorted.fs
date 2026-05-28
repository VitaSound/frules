\ tests/challenges/029-merge-sorted.fs
\
\ CHALLENGE: Merge Sorted Arrays
\ Source: leetcode  https://leetcode.com/problems/merge-sorted-array/
\ Cognitive: 4/10  |  Pattern: merge-sorted-arrays
\
\ Define a word
\
\   : merge-into  ( -- len )
\
\ Merge ch-a and ch-b (each sorted) into front of ch-data.
\ Return total length.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Two-finger merge.
\   - Preload two segments.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
\ Fixed: ch-a-len was 4 but segment A is [1,2,3] (length 3); B is [2,5,6].
\ Fixed: second test was "ch@ 5" (underflow); index must precede ch@.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
1 0 ch!  2 1 ch!  3 2 ch!  2 3 ch!  5 4 ch!  6 5 ch!
6 constant ch-n
3 constant ch-a-len

\ === paste your solution below this line ===

create ch-work  ch-max cells allot

: work@  ( i -- n )  cells ch-work + @ ;
: work!  ( n i -- )  cells ch-work + ! ;

: merge-into  ( -- len )
  ch-a-len 0 0 { ib ia w }
  begin ia ch-a-len < ib ch-n < and while
    ia ch@ ib ch@ <= if
      ia ch@ w work!  ia 1+ to ia
    else
      ib ch@ w work!  ib 1+ to ib
    then
    w 1+ to w
  repeat
  begin ia ch-a-len < while
    ia ch@ w work!  ia 1+ to ia  w 1+ to w
  repeat
  begin ib ch-n < while
    ib ch@ w work!  ib 1+ to ib  w 1+ to w
  repeat
  ch-n 0 ?do  i work@ i ch!  loop
  ch-n ;

\ === paste your solution above this line ===

T{ merge-into -> 6 }T
T{ 5 ch@ -> 6 }T

report bye
