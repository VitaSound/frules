\ tests/challenges/023-contains-dup.fs
\
\ CHALLENGE: Contains Duplicate
\ Source: leetcode  https://leetcode.com/problems/contains-duplicate/
\ Cognitive: 3/10  |  Pattern: contains-duplicate-flag
\
\ Define a word
\
\   : has-dup?  ( -- flag )
\
\ Return TRUE if any value appears twice in ch-data[0..ch-n).
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - O(n^2) OK for small n.
\   - Return true/false.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
1 0 ch!  2 1 ch!  3 2 ch!  1 3 ch!
4 constant ch-n

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ has-dup? -> true }T

report bye
