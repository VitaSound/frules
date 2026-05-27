\ tests/challenges/073-surrounded-regions.fs
\
\ CHALLENGE: Surrounded Regions
\ Source: leetcode  https://leetcode.com/problems/surrounded-regions/
\ Cognitive: 7/10  |  Pattern: surrounded-regions-flip
\
\ Define a word
\
\   : capture-count  ( -- count )
\
\ Return count of O regions fully surrounded by X after capture.
\ X and O on grid.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - DFS from borders.
\   - Mutates grid to count.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
8 constant ch-cols
8 constant ch-rows
create ch-grid ch-cols ch-rows * cells allot

: ch-grid@  ( col row -- n )  ch-cols * + cells ch-grid + @ ;
: ch-grid!  ( n col row -- )  ch-cols * + cells ch-grid + ! ;
X 0 0 ch-grid!  X 1 0 ch-grid!  X 2 0 ch-grid!
X 0 1 ch-grid!  O 1 1 ch-grid!  X 2 1 ch-grid!
X 0 2 ch-grid!  X 1 2 ch-grid!  X 2 2 ch-grid!
3 constant ch-cols-used
3 constant ch-rows-used

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ capture-count -> 1 }T

report bye
