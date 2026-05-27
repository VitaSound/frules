\ tests/challenges/040-find-min-rotated.fs
\
\ CHALLENGE: Find Minimum Rotated
\ Source: leetcode  https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/
\ Cognitive: 5/10  |  Pattern: find-minimum-rotated
\
\ Define a word
\
\   : find-min-rot  ( -- n )
\
\ Return minimum element in rotated sorted ch-data with distinct values.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Binary search on rotation.
\   - Uses ch-n.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
3 0 ch!  4 1 ch!  5 2 ch!  1 3 ch!  2 4 ch!
5 constant ch-n

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ find-min-rot -> 1 }T

report bye
