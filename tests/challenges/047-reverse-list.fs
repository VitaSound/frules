\ tests/challenges/047-reverse-list.fs
\
\ CHALLENGE: Reverse Linked List
\ Source: leetcode  https://leetcode.com/problems/reverse-linked-list/
\ Cognitive: 4/10  |  Pattern: reverse-linked-list
\
\ Define a word
\
\   : reverse-list  ( head -- new-head )
\
\ Reverse singly linked list; return new head index.
\ In-place pointer reversal.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Iterative preferred.
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
3 0 3 ch-val! 0 ch-next!
1 constant ch-head

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 1 reverse-list -> 3 }T
T{ ch-val@ 3 -> 2 }T

report bye
