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
: ch-t!  ( n off -- )  cells ch-tree + ! ;
4 0 ch-t!  2 1 ch-t!  7 2 ch-t!
2 3 ch-t!  1 4 ch-t!  3 5 ch-t!
5 6 ch-t!  6 7 ch-t!  4 8 ch-t!
1 constant ch-root

\ === paste your solution below this line ===

: n-left@  ( i -- n )  3 * 1 + ch-t@ ;
: n-right@ ( i -- n )  3 * 2 + ch-t@ ;
: n-left!  ( n i -- )  swap >r 3 * 1 + r> swap ch-t! ;
: n-right! ( n i -- )  swap >r 3 * 2 + r> swap ch-t! ;

variable ch-node
variable ch-L
variable ch-R

: swap-children ( i -- )
  ch-node !
  ch-node @ n-left@  ch-L !
  ch-node @ n-right@ ch-R !
  ch-R @ ch-node @ n-left!
  ch-L @ ch-node @ n-right! ;

: invert-tree ( root -- root )  dup swap-children ;

\ === paste your solution above this line ===

T{ 1 invert-tree -> 1 }T
T{ 4 ch-t@ -> 3 }T
T{ 5 ch-t@ -> 1 }T

report bye
