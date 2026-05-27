\ tests/challenges/098-fruit-baskets.fs
\
\ CHALLENGE: Fruit Into Baskets
\ Source: leetcode  https://leetcode.com/problems/fruit-into-baskets/
\ Cognitive: 5/10  |  Pattern: fruit-into-baskets
\
\ Define a word
\
\   : fruit-baskets  ( -- len )
\
\ Return longest subarray with at most 2 distinct values in ch-data.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Sliding window.
\   - Uses ch-n.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
1 0 ch!  2 1 ch!  1 2 ch!  2 3 ch!  3 4 ch!
5 constant ch-n

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ fruit-baskets -> 3 }T

report bye
