\ tests/challenges/133-knapsack01.fs
\
\ CHALLENGE: 0/1 Knapsack Possible
\ Source: leetcode  https://leetcode.com/problems/subset-sum/
\ Cognitive: 7/10  |  Pattern: knapsack-01-exists
\
\ Define a word
\
\   : knapsack01?  ( cap -- flag )
\
\ Return TRUE if some subset of ch-data sums exactly to cap.
\ Each item used at most once.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Bitset or DP.
\   - cap on stack.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
1 0 ch!  5 1 ch!  11 2 ch!  5 3 ch!
4 constant ch-n

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 5 knapsack01? -> true }T
T{ 12 knapsack01? -> false }T
T{ 11 knapsack01? -> true }T

report bye
