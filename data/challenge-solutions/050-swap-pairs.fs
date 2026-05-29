\ tests/challenges/050-swap-pairs.fs
\
\ CHALLENGE: Swap Nodes in Pairs
\ Source: leetcode  https://leetcode.com/problems/swap-nodes-in-pairs/
\ Cognitive: 5/10  |  Pattern: swap-nodes-in-pairs
\
\ Define a word
\
\   : swap-pairs  ( head -- new-head )
\
\ Swap every two adjacent nodes; return new head.
\ Odd tail unchanged.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Pointer surgery on indices.
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

variable ch-first
variable ch-second
variable ch-third
variable ch-tail

: swap-pairs ( head -- new-head )
  recursive
  dup 0= if exit then
  dup ch-next@ dup 0= if 2drop exit then
  swap ch-first ! ch-second !
  ch-second @ ch-next@ ch-third !
  ch-third @ if
    ch-second @ >r ch-first @ >r
    ch-third @ swap-pairs ch-tail !
    r> ch-first !  r> ch-second !
    ch-first @ ch-second @ ch-next!
    ch-tail @ ch-first @ ch-next!
  else
    ch-first @ ch-second @ ch-next!
  then
  ch-second @ ;

\ === paste your solution above this line ===

T{ 1 swap-pairs -> 2 }T
T{ 2 ch-val@ -> 1 }T

report bye
