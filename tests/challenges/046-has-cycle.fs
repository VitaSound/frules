\ tests/challenges/046-has-cycle.fs
\
\ CHALLENGE: Linked List Cycle
\ Source: leetcode  https://leetcode.com/problems/linked-list-cycle/
\ Cognitive: 5/10  |  Pattern: linked-list-cycle-detect
\
\ Define a word
\
\   : has-cycle?  ( head -- flag )
\
\ Return TRUE if list from head index contains a cycle.
\ Floyd tortoise/hare on indices.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Return true/false.
\   - Preload cyclic list.
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
3 1 3 ch-val! 1 ch-next!
3 constant ch-head-cyclic
1 10 4 ch-val! 0 ch-next!
4 constant ch-head-acyclic

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 3 has-cycle? -> true }T
T{ 4 has-cycle? -> false }T

report bye
