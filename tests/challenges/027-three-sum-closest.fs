\ tests/challenges/027-three-sum-closest.fs
\
\ CHALLENGE: Three Sum Closest
\ Source: leetcode  https://leetcode.com/problems/3sum-closest/
\ Cognitive: 6/10  |  Pattern: three-sum-closest-sum
\
\ Define a word
\
\   : three-sum-closest  ( target -- sum )
\
\ Return sum of three distinct elements closest to target.
\ Tie: smaller absolute difference wins.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Sort + two pointers.
\   - Uses ch-data preload.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
-1 2 1 ch!
3 constant ch-n

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 1 three-sum-closest -> 2 }T

report bye
