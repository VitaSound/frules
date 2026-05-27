\ tests/challenges/054-same-tree.fs
\
\ CHALLENGE: Same Tree
\ Source: leetcode  https://leetcode.com/problems/same-tree/
\ Cognitive: 4/10  |  Pattern: same-binary-tree
\
\ Define a word
\
\   : same-tree?  ( r1 r2 -- flag )
\
\ Return TRUE if trees at r1 and r2 are structurally identical with equal values.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Parallel recursion on indices.
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
1 0 ch-t!  2 1 ch-t!  3 2 ch-t!
1 3 ch-t!  0 4 ch-t!  0 5 ch-t!
1 6 ch-t!  2 7 ch-t!  1 8 ch-t!
1 constant ch-root-a
2 constant ch-root-b

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 1 1 same-tree? -> true }T
T{ 1 2 same-tree? -> false }T

report bye
