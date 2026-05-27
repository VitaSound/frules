\ tests/challenges/076-jump-min.fs
\
\ CHALLENGE: Jump Game II
\ Source: leetcode  https://leetcode.com/problems/jump-game-ii/
\ Cognitive: 6/10  |  Pattern: jump-game-minimum
\
\ Define a word
\
\   : jump-min  ( -- steps )
\
\ Return minimum jumps to reach last index.
\ Always reachable in tests.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Greedy BFS layers.
\   - Uses ch-n.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
2 0 ch!  3 1 ch!  1 2 ch!  1 3 ch!  4 4 ch!
5 constant ch-n

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ jump-min -> 2 }T

report bye
