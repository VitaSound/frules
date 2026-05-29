\ tests/challenges/065-coin-change.fs
\
\ CHALLENGE: Coin Change Ways
\ Source: leetcode  https://leetcode.com/problems/coin-change/
\ Cognitive: 6/10  |  Pattern: coin-change-combinations
\
\ Define a word
\
\   : coin-change  ( amount -- ways )
\
\ Count ways to make amount using coins in ch-data[0..ch-n).
\ Unlimited coin supply.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Unbounded knapsack DP.
\   - amount on stack.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
1 0 ch!  2 1 ch!  5 2 ch!
3 constant ch-n

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 5 coin-change -> 4 }T
T{ 3 coin-change -> 0 }T

report bye
