\ tests/challenges/063-min-path-sum.fs
\
\ CHALLENGE: Minimum Path Sum
\ Source: leetcode  https://leetcode.com/problems/minimum-path-sum/
\ Cognitive: 6/10  |  Pattern: minimum-path-sum-grid
\
\ Define a word
\
\   : min-path-sum  ( -- sum )
\
\ Return min sum path from top-left to bottom-right using ch-grid.
\ Only right/down moves.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - DP on grid scaffold.
\   - Uses preloaded costs.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
8 constant ch-cols
8 constant ch-rows
create ch-grid ch-cols ch-rows * cells allot

: ch-grid@  ( col row -- n )  ch-cols * + cells ch-grid + @ ;
: ch-grid!  ( n col row -- )  ch-cols * + cells ch-grid + ! ;
1 0 0 ch-grid!  3 1 0 ch-grid!  1 2 0 ch-grid!
1 0 1 ch-grid!  5 1 1 ch-grid!  1 2 1 ch-grid!
4 0 2 ch-grid!  2 1 2 ch-grid!  1 2 2 ch-grid!
3 constant ch-cols-used
3 constant ch-rows-used

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ min-path-sum -> 7 }T

report bye
