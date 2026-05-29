\ tests/challenges/071-rotting-oranges.fs
\
\ CHALLENGE: Rotting Oranges
\ Source: leetcode  https://leetcode.com/problems/rotting-oranges/
\ Cognitive: 6/10  |  Pattern: rotting-oranges-bfs
\
\ Define a word
\
\   : rotten-days  ( -- days )
\
\ Return minutes until no fresh orange remains; -1 if impossible.
\ 2=rotten 1=fresh 0=empty.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Multi-source BFS.
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
2 0 0 ch-grid!  1 1 0 ch-grid!  1 2 0 ch-grid!
1 0 1 ch-grid!  0 1 1 ch-grid!  2 2 1 ch-grid!
2 0 2 ch-grid!  1 1 2 ch-grid!  1 2 2 ch-grid!
3 constant ch-cols-used
3 constant ch-rows-used

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ rotten-days -> 4 }T

report bye
