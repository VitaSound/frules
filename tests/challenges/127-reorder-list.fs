\ tests/challenges/127-reorder-list.fs
\
\ CHALLENGE: Reorder List
\ Source: leetcode  https://leetcode.com/problems/reorder-list/
\ Cognitive: 6/10  |  Pattern: linked-list-reorder
\
\ Define a word
\
\   : reorder-list  ( head -- head' )
\
\ Reorder L0..Ln-1 to L0,Ln-1,L1,Ln-2,...
\ Return new head index.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Find middle, reverse second half, merge.
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
1 2 1 ch-val! 2 ch-next!
2 3 2 ch-val! 3 ch-next!
3 4 3 ch-val! 4 ch-next!
4 5 4 ch-val! 5 ch-next!
5 0 5 ch-val! 0 ch-next!
1 constant ch-head

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 1 reorder-list -> 1 }T

report bye
