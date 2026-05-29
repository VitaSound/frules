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
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
1 0 ch!  2 1 ch!  3 2 ch!  2 3 ch!  5 4 ch!  6 5 ch!
6 constant ch-n
4 constant ch-a-len

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ merge-into -> 6 }T
T{ ch@ 5 -> 6 }T

report bye
