\ tests/challenges/053-min-depth.fs
\
\ CHALLENGE: Min Tree Depth
\ Source: leetcode  https://leetcode.com/problems/minimum-depth-of-binary-tree/
\ Cognitive: 5/10  |  Pattern: binary-tree-min-depth
\
\ Define a word
\
\   : min-depth  ( root -- d )
\
\ Return min root-to-leaf depth.
\ Leaf has both children 0.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - BFS preferred.
\   - Same tree scaffold.
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
1 constant ch-root

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 1 min-depth -> 2 }T

report bye
