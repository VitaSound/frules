\ tests/challenges/090-spiral-len.fs
\
\ CHALLENGE: Spiral Matrix Count
\ Source: leetcode  https://leetcode.com/problems/spiral-matrix/
\ Cognitive: 5/10  |  Pattern: spiral-matrix-count
\
\ Define a word
\
\   : spiral-cells  ( -- count )
\
\ Return number of cells visited in clockwise spiral order (benchmark counts visits).
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Simulate directions.
\   - Uses rectangular grid.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
8 constant ch-cols
8 constant ch-rows
create ch-grid ch-cols ch-rows * cells allot

: ch-grid@  ( col row -- n )  ch-cols * + cells ch-grid + @ ;
: ch-grid!  ( n col row -- )  ch-cols * + cells ch-grid + ! ;
1 0 0 ch-grid!  2 1 0 ch-grid!  3 2 0 ch-grid!
4 0 1 ch-grid!  5 1 1 ch-grid!  6 2 1 ch-grid!
7 0 2 ch-grid!  8 1 2 ch-grid!  9 2 2 ch-grid!
3 constant ch-cols-used
3 constant ch-rows-used

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ spiral-cells -> 9 }T

report bye
