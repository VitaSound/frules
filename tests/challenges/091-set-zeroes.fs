\ tests/challenges/091-set-zeroes.fs
\
\ CHALLENGE: Set Matrix Zeroes
\ Source: leetcode  https://leetcode.com/problems/set-matrix-zeroes/
\ Cognitive: 6/10  |  Pattern: set-matrix-zeroes
\
\ Define a word
\
\   : set-zeroes  ( -- )
\
\ Zero entire row and column if cell is 0.
\ In-place marker trick allowed.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Mutates ch-grid.
\   - Preload matrix.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
8 constant ch-cols
8 constant ch-rows
create ch-grid ch-cols ch-rows * cells allot

: ch-grid@  ( col row -- n )  ch-cols * + cells ch-grid + @ ;
: ch-grid!  ( n col row -- )  ch-cols * + cells ch-grid + ! ;
0 0 0 ch-grid!  1 1 0 ch-grid!  1 2 0 ch-grid!
1 0 1 ch-grid!  0 1 1 ch-grid!  1 2 1 ch-grid!
3 constant ch-cols-used
2 constant ch-rows-used

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ set-zeroes }T
T{ ch-grid@ 0 0 -> 0 }T
T{ ch-grid@ 1 1 -> 0 }T

report bye
