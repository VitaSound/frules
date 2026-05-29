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
: ch-t! ( n off -- )  swap cells ch-tree + ! ;
5 0 ch-t!  4 1 ch-t!  8 2 ch-t!
4 3 ch-t!  0 4 ch-t!  0 5 ch-t!
11 6 ch-t!  0 7 ch-t!  0 8 ch-t!
4 9 ch-t!  0 10 ch-t!  0 11 ch-t!
5 constant ch-root

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 5 22 path-sum? -> true }T
T{ 5 28 path-sum? -> false }T

report bye
