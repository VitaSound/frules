\ tests/challenges/056-valid-bst.fs
\
\ CHALLENGE: Validate BST
\ Source: leetcode  https://leetcode.com/problems/validate-binary-search-tree/
\ Cognitive: 6/10  |  Pattern: validate-binary-search-tree
\
\ Define a word
\
\   : valid-bst?  ( root -- flag )
\
\ Return TRUE iff tree satisfies BST ordering.
\ No duplicate values in tests.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Range check or inorder.
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
2 0 ch-t!  1 1 ch-t!  3 2 ch-t!
1 3 ch-t!  0 4 ch-t!  0 5 ch-t!
2 6 ch-t!  0 7 ch-t!  0 8 ch-t!
2 constant ch-root-good
5 9 ch-t!  4 10 ch-t!  4 11 ch-t!
1 12 ch-t!  0 13 ch-t!  6 14 ch-t!
3 15 ch-t!  0 16 ch-t!  0 17 ch-t!
3 constant ch-root-bad

\ === paste your solution below this line ===

: node-val ( i -- n )  3 * ch-t@ ;
: node-left ( i -- n )  3 * 1 + ch-t@ ;
: node-right ( i -- n )  3 * 2 + ch-t@ ;

variable bst-prev

: inorder ( i -- flag )
  dup 0= if drop true exit then
  dup node-left dup if recurse else drop true then
  dup 0= if swap drop false exit then  drop
  dup node-val 2dup bst-prev @ <= if 2drop drop false exit then
  bst-prev !
  dup node-right dup if recurse else drop true then
  dup 0= if swap drop false exit then  swap drop ;

: valid-bst? ( root -- flag )
  >r 0 bst-prev ! r> inorder
  begin depth 1 > while nip repeat ;

\ === paste your solution above this line ===

T{ 2 valid-bst? -> true }T
T{ 3 valid-bst? -> false }T

report bye
