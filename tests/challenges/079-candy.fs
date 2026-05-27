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

\ === paste your solution above this line ===

T{ candy-min -> 5 }T

report bye
