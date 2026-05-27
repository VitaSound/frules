\ tests/challenges/089-rotate-matrix.fs
\
\ CHALLENGE: Rotate Image
\ Source: leetcode  https://leetcode.com/problems/rotate-image/
\ Cognitive: 6/10  |  Pattern: rotate-image-90
\
\ Define a word
\
\   : rotate-90  ( -- )
\
\ Rotate ch-grid square matrix 90 degrees clockwise in place.
\ n x n preloaded.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Layer swap or transpose+reverse.
\   - Mutates grid.
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

T{ rotate-90 }T
T{ ch-grid@ 0 0 -> 4 }T
T{ ch-grid@ 0 2 -> 1 }T

report bye
