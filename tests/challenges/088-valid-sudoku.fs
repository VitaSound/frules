\ tests/challenges/088-valid-sudoku.fs
\
\ CHALLENGE: Valid Sudoku
\ Source: leetcode  https://leetcode.com/problems/valid-sudoku/
\ Cognitive: 6/10  |  Pattern: valid-sudoku-board
\
\ Define a word
\
\   : sudoku?  ( -- flag )
\
\ Return TRUE if 9x9 partial sudoku has no row/col/box duplicates.
\ 0=empty digit.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Use bitmask or hash.
\   - Preload board digits.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
8 constant ch-cols
8 constant ch-rows
create ch-grid ch-cols ch-rows * cells allot

: ch-grid@  ( col row -- n )  ch-cols * + cells ch-grid + @ ;
: ch-grid!  ( n col row -- )  ch-cols * + cells ch-grid + ! ;
5 0 0 ch-grid!  3 1 0 ch-grid!  0 2 0 ch-grid!  0 3 0 ch-grid!  7 4 0 ch-grid!  0 5 0 ch-grid!  0 6 0 ch-grid!  0 7 0 ch-grid!  0 8 0 ch-grid!
6 0 1 ch-grid!  0 1 1 ch-grid!  0 2 1 ch-grid!  1 3 1 ch-grid!  9 4 1 ch-grid!  5 5 1 ch-grid!  0 6 1 ch-grid!  0 7 1 ch-grid!  0 8 1 ch-grid!
0 0 2 ch-grid!  9 1 2 ch-grid!  8 2 2 ch-grid!  0 3 2 ch-grid!  0 4 2 ch-grid!  0 5 2 ch-grid!  0 6 2 ch-grid!  6 7 2 ch-grid!  0 8 2 ch-grid!
9 constant ch-cols-used
9 constant ch-rows-used

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ sudoku? -> true }T

report bye
