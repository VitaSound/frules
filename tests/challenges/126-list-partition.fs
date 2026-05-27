\ tests/challenges/126-list-partition.fs
\
\ CHALLENGE: Partition List
\ Source: leetcode  https://leetcode.com/problems/partition-list/
\ Cognitive: 6/10  |  Pattern: linked-list-partition
\
\ Define a word
\
\   : part-list  ( head pivot -- lo-head )
\
\ Partition list so values < pivot come before others; return lo-head index.
\ Stable relative order within parts.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - In-place index links.
\   - Uses LINK scaffold.
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
1 1 1 ch-val! 4 ch-next!
4 3 4 ch-val! 3 ch-next!
3 2 3 ch-val! 2 ch-next!
2 5 2 ch-val! 5 ch-next!
5 0 5 ch-val! 0 ch-next!
1 constant ch-head

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 1 3 part-list -> 1 }T
T{ ch-val@ 1 -> 2 }T

report bye
