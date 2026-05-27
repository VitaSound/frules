\ tests/challenges/131-topo-len.fs
\
\ CHALLENGE: Topological Order Length
\ Source: leetcode  https://leetcode.com/problems/course-schedule-ii/
\ Cognitive: 6/10  |  Pattern: topological-sort-length
\
\ Define a word
\
\   : topo-len  ( -- n )
\
\ Return number of courses in a valid topological order for DAG edges in ch-edges.
\ If cycle exists return 0.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Kahn or DFS topo.
\   - Preload edges like can-finish.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
2 1 ch!  3 1 ch!  4 2 ch!  5 3 ch!
4 constant ch-n-courses

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ topo-len -> 4 }T

report bye
