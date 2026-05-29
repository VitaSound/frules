\ tests/challenges/084-merge-k-lists.fs
\
\ CHALLENGE: Merge K Lists
\ Source: leetcode  https://leetcode.com/problems/merge-k-sorted-lists/
\ Cognitive: 9/10  |  Pattern: merge-k-sorted-lists
\
\ Define a word
\
\   : merge-k  ( -- head )
\
\ Merge k sorted lists whose heads are in ch-heads array; return merged head.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Heap or divide-conquer.
\   - Preload list heads.
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
1 0 ch!  3 1 ch!
2 constant ch-k
2 constant ch-n

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ merge-k -> 1 }T

report bye
