\ tests/challenges/094-max-area-island.fs
\
\ CHALLENGE: Max Area Island
\ Source: leetcode  https://leetcode.com/problems/max-area-of-island/
\ Cognitive: 6/10  |  Pattern: max-area-of-island
\
\ Define a word
\
\   : max-island  ( -- area )
\
\ Return area of largest 1-component in ch-grid.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - DFS count.
\   - Uses grid scaffold.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
8 constant ch-cols
8 constant ch-rows
create ch-grid ch-cols ch-rows * cells allot

: ch-grid@  ( col row -- n )  ch-cols * + cells ch-grid + @ ;
: ch-grid!  ( n col row -- )  ch-cols * + cells ch-grid + ! ;
0 0 0 ch-grid!  0 1 0 ch-grid!  1 2 0 ch-grid!
0 0 1 ch-grid!  0 1 1 ch-grid!  0 2 1 ch-grid!
1 0 2 ch-grid!  1 1 2 ch-grid!  1 2 2 ch-grid!
3 constant ch-cols-used
3 constant ch-rows-used

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ max-island -> 6 }T

report bye
