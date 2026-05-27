\ tests/challenges/052-max-depth.fs
\
\ CHALLENGE: Max Tree Depth
\ Source: leetcode  https://leetcode.com/problems/maximum-depth-of-binary-tree/
\ Cognitive: 4/10  |  Pattern: binary-tree-max-depth
\
\ Define a word
\
\   : max-depth  ( root -- d )
\
\ Return max depth of binary tree rooted at index root.
\ Null child index is 0.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Recursive or BFS.
\   - Uses ch-t@ offsets val/left/right.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
\ Node i: val, left, right at offsets i*3 (0 = null child)
12 constant ch-max-nodes
create ch-tree ch-max-nodes 3 * cells allot

: ch-t@  ( off -- n )  cells ch-tree + @ ;
: ch-t! ( n off -- )  swap cells ch-tree + ! ;
3 0 ch-t!  2 1 ch-t!  3 2 ch-t!
9 3 ch-t!  0 4 ch-t!  0 5 ch-t!
20 6 ch-t!  4 7 ch-t!  5 8 ch-t!
15 9 ch-t!  0 10 ch-t!  0 11 ch-t!
7 12 ch-t!  0 13 ch-t!  0 14 ch-t!
1 constant ch-root
2 constant ch-root-small

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 1 max-depth -> 3 }T
T{ 2 max-depth -> 2 }T

report bye
