\ tests/challenges/042-search-matrix.fs
\
\ CHALLENGE: Search 2D Matrix
\ Source: leetcode  https://leetcode.com/problems/search-a-2d-matrix/
\ Cognitive: 5/10  |  Pattern: search-2d-matrix
\
\ Define a word
\
\   : matrix-search?  ( key -- flag )
\
\ Return TRUE if key exists in row-major sorted grid.
\ Each row sorted; first of row > last of prev.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Treat as 1D sorted or stair search.
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
1 0 0 ch-grid!  3 1 0 ch-grid!  5 2 0 ch-grid!
10 0 1 ch-grid!  11 1 1 ch-grid!  16 2 1 ch-grid!
13 0 2 ch-grid!  14 1 2 ch-grid!  15 2 2 ch-grid!
3 constant ch-cols-used
3 constant ch-rows-used

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 3 matrix-search? -> true }T
T{ 13 matrix-search? -> false }T

report bye
