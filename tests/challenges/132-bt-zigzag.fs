\ tests/challenges/132-bt-zigzag.fs
\
\ CHALLENGE: Zigzag Level Sum
\ Source: leetcode  https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal/
\ Cognitive: 6/10  |  Pattern: binary-tree-zigzag-sum
\
\ Define a word
\
\   : zigzag-sum  ( root -- sum )
\
\ Return sum of values on zigzag level-order traversal.
\ Alternating left-right per level.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - BFS with direction flag.
\   - Uses TREE scaffold.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
\ Node i: val, left, right at offsets i*3 (0 = null child)
12 constant ch-max-nodes
create ch-tree ch-max-nodes 3 * cells allot

: ch-t@  ( off -- n )  cells ch-tree + @ ;
: ch-t! ( n off -- )  cells ch-tree + ! ;
3 0 ch-t!  2 1 ch-t!  3 2 ch-t!
9 3 ch-t!  0 4 ch-t!  0 5 ch-t!
20 6 ch-t!  4 7 ch-t!  5 8 ch-t!
15 9 ch-t!  0 10 ch-t!  0 11 ch-t!
7 12 ch-t!  0 13 ch-t!  0 14 ch-t!
0 15 ch-t!  0 16 ch-t!  0 17 ch-t!
1 constant ch-root
2 constant ch-root-small

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 1 zigzag-sum -> 45 }T
T{ 2 zigzag-sum -> 27 }T

report bye
