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

\ === paste your solution above this line ===

T{ sort-colors }T
T{ ch@ 0 -> 0 }T
T{ ch@ 4 -> 2 }T

report bye
