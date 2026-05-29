\ tests/challenges/093-word-search.fs
\
\ CHALLENGE: Word Search
\ Source: leetcode  https://leetcode.com/problems/word-search/
\ Cognitive: 7/10  |  Pattern: word-search-grid
\
\ Define a word
\
\   : word-search?  ( c-addr u -- flag )
\
\ Return TRUE if word exists in ch-grid using adjacent cell path.
\ Reuse cell allowed per path.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Backtracking DFS.
\   - Use ch-setup for word.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
8 constant ch-cols
8 constant ch-rows
create ch-grid ch-cols ch-rows * cells allot

: ch-grid@  ( col row -- n )  ch-cols * + cells ch-grid + @ ;
: ch-grid!  ( n col row -- )  ch-cols * + cells ch-grid + ! ;
A 0 0 ch-grid!  B 1 0 ch-grid!  C 2 0 ch-grid!
B 0 1 ch-grid!  E 1 1 ch-grid!  C 2 1 ch-grid!
A 0 2 ch-grid!  D 1 2 ch-grid!  E 2 2 ch-grid!
3 constant ch-cols-used
3 constant ch-rows-used

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ s" ABCCED" ch-setup word-search? -> true }T
T{ s" SEE" ch-setup word-search? -> true }T
T{ s" ABCB" ch-setup word-search? -> false }T

report bye
