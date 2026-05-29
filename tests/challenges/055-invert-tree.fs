\ tests/challenges/055-invert-tree.fs
\
\ CHALLENGE: Invert Binary Tree
\ Source: leetcode  https://leetcode.com/problems/invert-binary-tree/
\ Cognitive: 4/10  |  Pattern: invert-binary-tree
\
\ Define a word
\
\   : invert-tree  ( root -- root )
\
\ Swap left/right subtrees recursively in place.
\ Return root unchanged.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Mutates ch-t! fields.
\   - Post-order swap.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
\ Node i: val, left, right at offsets i*3 (0 = null child)
12 constant ch-max-nodes
create ch-tree ch-max-nodes 3 * cells allot

: ch-t@  ( off -- n )  cells ch-tree + @ ;
: ch-t! ( n off -- )  swap cells ch-tree + ! ;
4 0 ch-t!  2 1 ch-t!  7 2 ch-t!
2 3 ch-t!  1 4 ch-t!  3 5 ch-t!
5 6 ch-t!  6 7 ch-t!  4 8 ch-t!
1 constant ch-root

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 1 invert-tree -> 1 }T
T{ ch-t@ 1 -> 3 }T
T{ ch-t@ 2 -> 2 }T

report bye
