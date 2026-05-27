\ tests/challenges/045-merge-two-lists.fs
\
\ CHALLENGE: Merge Two Sorted Lists
\ Source: leetcode  https://leetcode.com/problems/merge-two-sorted-lists/
\ Cognitive: 5/10  |  Pattern: merge-two-sorted-lists
\
\ Define a word
\
\   : merge-lists  ( -- head )
\
\ Merge lists starting ch-head-a and ch-head-b; return merged head index.
\ Nodes indexed 1..N, 0=nil.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Reuse node indices.
\   - Define ch-val!/ch-next! in extra scaffold.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
\ Node index i: value in ch-vals[i], next in ch-nexts[i] (0 = nil)
12 constant ch-max-nodes
create ch-vals  ch-max-nodes cells allot
create ch-nexts ch-max-nodes cells allot

: ch-val@  ( i -- n )  cells ch-vals + @ ;
: ch-next@ ( i -- n )  cells ch-nexts + @ ;
: ch-node! ( val next i -- )  >r swap r@ ch-next@!  ch-val@! ;
: ch-val!  ( n i -- )  swap cells ch-vals + ! ;
: ch-next! ( n i -- )  swap cells ch-nexts + ! ;
1 2 1 ch-val! 1 ch-next!
3 0 2 ch-val! 0 ch-next!
2 4 3 ch-val! 3 ch-next!
4 0 4 ch-val! 0 ch-next!
1 constant ch-head-a
2 constant ch-head-b

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ merge-lists -> 1 }T

report bye
