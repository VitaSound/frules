\ tests/challenges/070-shortest-path.fs
\
\ CHALLENGE: Shortest Path Binary
\ Source: leetcode  https://leetcode.com/problems/shortest-path-in-binary-matrix/
\ Cognitive: 6/10  |  Pattern: shortest-path-binary-matrix
\
\ Define a word
\
\   : shortest-path  ( -- len )
\
\ Return shortest path length from top-left to bottom-right through 0-cells.
\ Return 0 if blocked.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - BFS on grid.
\   - 8-directional or 4-directional per spec: use 8.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
8 constant ch-cols
8 constant ch-rows
create ch-grid ch-cols ch-rows * cells allot

: ch-grid@  ( col row -- n )  ch-cols * + cells ch-grid + @ ;
: ch-grid!  ( n col row -- )  ch-cols * + cells ch-grid + ! ;
0 0 0 ch-grid!  1 1 0 ch-grid!
1 0 1 ch-grid!  0 1 1 ch-grid!
2 constant ch-cols-used
2 constant ch-rows-used

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ shortest-path -> 2 }T

report bye
