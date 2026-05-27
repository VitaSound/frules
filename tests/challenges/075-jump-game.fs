\ tests/challenges/075-jump-game.fs
\
\ CHALLENGE: Jump Game
\ Source: leetcode  https://leetcode.com/problems/jump-game/
\ Cognitive: 5/10  |  Pattern: jump-game-reachable
\
\ Define a word
\
\   : jump-ok?  ( -- flag )
\
\ Return TRUE if last index reachable from index 0 by jumps <= ch-data[i].
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Greedy farthest reach.
\   - Return true/false.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
2 0 ch!  3 1 ch!  1 2 ch!  1 3 ch!  4 4 ch!
5 constant ch-n

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ jump-ok? -> true }T

report bye
