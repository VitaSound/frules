\ tests/challenges/102-single-number-ii.fs
\
\ CHALLENGE: Single Number II
\ Source: leetcode  https://leetcode.com/problems/single-number-ii/
\ Cognitive: 6/10  |  Pattern: single-number-appears-thrice
\
\ Define a word
\
\   : single-ii  ( -- n )
\
\ Return element appearing once while others appear three times.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Bit count per bit position.
\   - Uses ch-data preload.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
2 0 ch!  2 1 ch!  3 2 ch!  2 3 ch!
4 constant ch-n

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ single-ii -> 3 }T

report bye
