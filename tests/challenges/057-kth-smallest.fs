\ tests/challenges/057-kth-smallest.fs
\
\ CHALLENGE: Kth Smallest BST
\ Source: leetcode  https://leetcode.com/problems/kth-smallest-element-in-a-bst/
\ Cognitive: 6/10  |  Pattern: kth-smallest-bst
\
\ Define a word
\
\   : kth-smallest  ( root k -- n )
\
\ Return kth smallest value (1-indexed) in BST.
\ Tree is valid BST.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Inorder walk counting nodes.
\   - Uses tree scaffold.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
\ Node i: val, left, right at offsets i*3 (0 = null child)
12 constant ch-max-nodes
create ch-tree ch-max-nodes 3 * cells allot

: ch-t@  ( off -- n )  cells ch-tree + @ ;
: ch-t! ( n off -- )  swap cells ch-tree + ! ;
3 0 ch-t!  1 1 ch-t!  4 2 ch-t!
1 3 ch-t!  0 4 ch-t!  2 5 ch-t!
2 6 ch-t!  0 7 ch-t!  0 8 ch-t!
4 9 ch-t!  0 10 ch-t!  0 11 ch-t!
3 constant ch-root

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 3 1 kth-smallest -> 1 }T
T{ 3 3 kth-smallest -> 3 }T

report bye
