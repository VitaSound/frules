\ tests/challenges/092-game-of-life.fs
\
\ CHALLENGE: Game of Life
\ Source: leetcode  https://leetcode.com/problems/game-of-life/
\ Cognitive: 7/10  |  Pattern: game-of-life-next
\
\ Define a word
\
\   : life-next  ( -- )
\
\ Apply Conway rules to ch-grid in place for one generation.
\ 1=live 0=dead.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Use scratch or in-place encoding.
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
0 0 0 ch-grid!  1 1 0 ch-grid!  0 2 0 ch-grid!
0 0 1 ch-grid!  0 1 1 ch-grid!  1 2 1 ch-grid!
0 0 2 ch-grid!  1 1 2 ch-grid!  0 2 2 ch-grid!
3 constant ch-cols-used
3 constant ch-rows-used

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ life-next }T
T{ ch-grid@ 1 1 -> 1 }T

report bye
