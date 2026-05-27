\ tests/challenges/068-num-islands.fs
\
\ CHALLENGE: Number of Islands
\ Source: leetcode  https://leetcode.com/problems/number-of-islands/
\ Cognitive: 6/10  |  Pattern: count-islands-grid
\
\ Define a word
\
\   : num-islands  ( -- count )
\
\ Count connected components of 1-cells in ch-grid (4-directional).
\ 0=water 1=land.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - DFS/BFS flood fill.
\   - Uses ch-grid@.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
8 constant ch-cols
8 constant ch-rows
create ch-grid ch-cols ch-rows * cells allot

: ch-grid@  ( col row -- n )  ch-cols * + cells ch-grid + @ ;
: ch-grid!  ( n col row -- )  ch-cols * + cells ch-grid + ! ;
1 0 0 ch-grid!  1 1 0 ch-grid!  0 2 0 ch-grid!
0 0 1 ch-grid!  0 1 1 ch-grid!  0 2 1 ch-grid!
0 0 2 ch-grid!  0 1 2 ch-grid!  0 2 2 ch-grid!
3 constant ch-cols-used
3 constant ch-rows-used

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ num-islands -> 1 }T

report bye
