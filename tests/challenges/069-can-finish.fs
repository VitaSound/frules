\ tests/challenges/069-can-finish.fs
\
\ CHALLENGE: Course Schedule
\ Source: leetcode  https://leetcode.com/problems/course-schedule/
\ Cognitive: 6/10  |  Pattern: course-schedule-topo
\
\ Define a word
\
\   : can-finish?  ( -- flag )
\
\ Return TRUE if all courses can finish given prereq pairs in ch-edges.
\ No cycle in directed graph.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Topological sort.
\   - Preload edges as flat pairs.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
2 0 ch!  0 1 ch!  1 1 ch!
2 constant ch-n
2 constant ch-num-courses

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ can-finish? -> true }T

report bye
