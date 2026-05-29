\ tests/challenges/059-balanced-tree.fs
\
\ CHALLENGE: Balanced Binary Tree
\ Source: leetcode  https://leetcode.com/problems/balanced-binary-tree/
\ Cognitive: 5/10  |  Pattern: balanced-binary-tree
\
\ Define a word
\
\   : balanced?  ( root -- flag )
\
\ Return TRUE if heights of subtrees differ by at most 1 everywhere.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Post-order height check.
\   - Return true/false.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
\ Node i: val, left, right at offsets i*3 (0 = null child)
12 constant ch-max-nodes
create ch-tree ch-max-nodes 3 * cells allot

: ch-t@  ( off -- n )  cells ch-tree + @ ;
: ch-t!  ( n off -- )  cells ch-tree + ! ;
\ balanced?(3): leaf 15; balanced?(1): deep left chain under node 1
3 0 ch-t!  1 1 ch-t!  2 2 ch-t!
2 3 ch-t!  4 4 ch-t!  0 5 ch-t!
20 6 ch-t!  3 7 ch-t!  6 8 ch-t!
15 9 ch-t!  0 10 ch-t!  0 11 ch-t!
3 12 ch-t!  5 13 ch-t!  0 14 ch-t!
4 15 ch-t!  0 16 ch-t!  0 17 ch-t!
7 18 ch-t!  0 19 ch-t!  0 20 ch-t!
0 constant ch-root
1 constant ch-root-unbal

\ === paste your solution below this line ===

: node-left ( i -- n )  3 * 1 + ch-t@ ;
: node-right ( i -- n )  3 * 2 + ch-t@ ;

: height ( i -- h )
  >r
  r@ node-left ?dup if recurse else 0 then
  dup 0< if drop rdrop -1 exit then
  r@ node-right ?dup if recurse else 0 then
  dup 0< if drop rdrop -1 exit then
  swap
  2dup - abs 1 > if 2drop rdrop -1 exit then
  max 1+ rdrop ;

: balanced? ( root -- flag )
  height dup 0< if drop false else drop true then ;

\ === paste your solution above this line ===

T{ 3 balanced? -> true }T
T{ 1 balanced? -> false }T

report bye
