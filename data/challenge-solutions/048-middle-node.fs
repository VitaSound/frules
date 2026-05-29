\ tests/challenges/048-middle-node.fs
\
\ CHALLENGE: Middle of Linked List
\ Source: leetcode  https://leetcode.com/problems/middle-of-the-linked-list/
\ Cognitive: 4/10  |  Pattern: linked-list-middle
\
\ Define a word
\
\   : middle-node  ( head -- idx )
\
\ Return index of middle node; for even length pick second middle.
\ Fast/slow pointers.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Use index-based next pointers.
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
: ch-val!  ( n i -- )  swap cells ch-vals + ! ;
: ch-next! ( n i -- )  swap cells ch-nexts + ! ;
: ch-node! ( val next i -- )  tuck ch-next!  ch-val! ;
1 2 1 ch-val! 2 ch-next!
2 3 2 ch-val! 3 ch-next!
3 4 3 ch-val! 4 ch-next!
4 5 4 ch-val! 5 ch-next!
5 0 5 ch-val! 0 ch-next!
1 constant ch-head

\ === paste your solution below this line ===

variable ch-slow
variable ch-fast

: can-advance-2? ( node -- flag )
  dup if ch-next@ dup if ch-next@ if true else drop false then else drop false then
  else drop false then ;

: middle-node ( head -- idx )
  dup ch-fast ! ch-slow !
  begin  ch-fast @ can-advance-2?  while
    ch-slow @ ch-next@ ch-slow !
    ch-fast @ ch-next@ ch-next@ ch-fast !
  repeat
  ch-slow @ ;

\ === paste your solution above this line ===

T{ 1 middle-node -> 3 }T

report bye
