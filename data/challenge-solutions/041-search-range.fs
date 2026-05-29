\ tests/challenges/041-search-range.fs
\
\ CHALLENGE: Search Range
\ Source: leetcode  https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/
\ Cognitive: 5/10  |  Pattern: search-first-last-position
\
\ Define a word
\
\   : search-range  ( key -- lo hi )
\
\ Return lo hi indices of key in sorted ch-data.
\ Return -1 -1 if absent.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Two binary searches.
\   - Sorted with duplicates OK.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
5 0 ch!  7 1 ch!  7 2 ch!  8 3 ch!  8 4 ch!  10 5 ch!
6 constant ch-n

\ === paste your solution below this line ===

: find-first ( key -- idx|-1 )
  { key }
  ch-n { hi }
  0 { lo }
  begin  hi lo -  while
    lo hi + 2/ { mid }
    mid ch@ key < if  mid 1+ to lo  else  mid to hi  then
  repeat
  lo ch-n u< if
    lo ch@ key = if  lo  else  -1  then
  else
    -1
  then ;

: find-last ( key -- idx|-1 )
  { key }
  ch-n 1- { hi }
  0 { lo }
  begin  lo hi <  while
    lo hi + 1 + 2/ { mid }
    mid ch@ key > if  mid 1- to hi  else  mid to lo  then
  repeat
  lo ch@ key = if  lo  else  -1  then ;

: search-range ( key -- lo hi )
  dup find-first { key lo }
  lo -1 = if  key drop -1 -1 exit  then
  key find-last lo swap ;

\ === paste your solution above this line ===

T{ 8 search-range -> 3 4 }T
T{ 6 search-range -> -1 -1 }T

report bye
