\ tests/challenges/058-path-sum.fs
\
\ CHALLENGE: Path Sum
\ Source: leetcode  https://leetcode.com/problems/path-sum/
\ Cognitive: 5/10  |  Pattern: binary-tree-path-sum
\
\ Define a word
\
\   : path-sum?  ( root target -- flag )
\
\ Return TRUE if root-to-leaf path sums to target.
\ Leaf has no children.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - DFS accumulation.
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
5 0 ch-t!  1 1 ch-t!  2 2 ch-t!
4 3 ch-t!  3 4 ch-t!  0 5 ch-t!
8 6 ch-t!  4 7 ch-t!  5 8 ch-t!
11 9 ch-t!  6 10 ch-t!  7 11 ch-t!
13 12 ch-t!  0 13 ch-t!  0 14 ch-t!
4 15 ch-t!  0 16 ch-t!  8 17 ch-t!
7 18 ch-t!  0 19 ch-t!  0 20 ch-t!
2 21 ch-t!  0 22 ch-t!  0 23 ch-t!
1 24 ch-t!  0 25 ch-t!  0 26 ch-t!
0 constant ch-root

\ === paste your solution below this line ===

: node-val ( i -- n )  3 * ch-t@ ;
: node-left ( i -- n )  3 * 1 + ch-t@ ;
: node-right ( i -- n )  3 * 2 + ch-t@ ;

variable ch-need
variable ch-hit

: ch-walk ( i -- flag )
  false ch-hit !
  >r
  r@ node-val ch-need @ swap - ch-need !
  r@ node-left r@ node-right or if
    ch-hit @ 0= if
      r@ node-left ?dup if
        ch-need @ >r recurse r> ch-need !
        if true ch-hit ! then
      then
    then
    ch-hit @ 0= if
      r@ node-right ?dup if
        ch-need @ >r recurse r> ch-need !
        if true ch-hit ! then
      then
    then
    rdrop ch-hit @
  else
    ch-need @ 0= rdrop
  then ;

: path-sum? ( root target -- flag )
  swap >r ch-need ! r> ch-walk ;

\ === paste your solution above this line ===

T{ ch-root 22 path-sum? -> true }T
T{ ch-root 28 path-sum? -> false }T

report bye
