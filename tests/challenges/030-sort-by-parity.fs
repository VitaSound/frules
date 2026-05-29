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
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
3 0 ch!  1 1 ch!  2 2 ch!  4 3 ch!
4 constant ch-n

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ sort-parity }T
T{ ch@ 0 -> 2 }T
T{ ch@ 3 -> 3 }T

report bye
