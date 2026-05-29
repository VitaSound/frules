\ tests/challenges/044-peak-index.fs
\
\ CHALLENGE: Peak Index Mountain
\ Source: leetcode  https://leetcode.com/problems/peak-index-in-a-mountain-array/
\ Cognitive: 4/10  |  Pattern: peak-index-mountain
\
\ Define a word
\
\   : peak-idx  ( -- idx )
\
\ Return index of peak in bitonic array (strictly increases then decreases).
\ Peak element guaranteed unique.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Binary search on slope.
\   - Preload mountain array.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
0 0 ch!  1 1 ch!  2 2 ch!  5 3 ch!  3 4 ch!
5 constant ch-n

\ === paste your solution below this line ===

: peak-idx ( -- idx )
  0 { lo }
  ch-n 1- { hi }
  begin  lo hi <  while
    lo hi + 2/ { mid }
    mid ch@ mid 1+ ch@ < if  mid 1+ to lo  else  mid to hi  then
  repeat
  lo ;

\ === paste your solution above this line ===

T{ peak-idx -> 3 }T

report bye
