\ tests/challenges/049-remove-nth-end.fs
\
\ CHALLENGE: Remove Nth From End
\ Source: leetcode  https://leetcode.com/problems/remove-nth-node-from-end-of-list/
\ Cognitive: 6/10  |  Pattern: remove-nth-from-end
\
\ Define a word
\
\   : remove-nth  ( head n -- new-head )
\
\ Remove nth node from end (1-indexed); return head.
\ Use two-pass or two-pointer.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Mutates ch-next! fields.
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
4 0 4 ch-val! 0 ch-next!
1 constant ch-head

\ === paste your solution below this line ===

: list-len ( head -- len )
  0 swap begin  dup while  ch-next@ swap 1+ swap  repeat  drop ;

: remove-nth ( head n -- new-head )
  { head n }
  head 0= if 0 exit then
  n 1 <= if
    head ch-next@
    exit
  then
  head { prev }
  n 2 - 0 ?do
    prev ch-next@ dup 0= if
      drop head unloop exit
    then
    to prev
  loop
  prev ch-next@ dup if
    ch-next@ prev ch-next!
  else
    drop
  then
  head ;

\ === paste your solution above this line ===

T{ 1 2 remove-nth -> 1 }T
T{ 1 1 remove-nth -> 2 }T

report bye
