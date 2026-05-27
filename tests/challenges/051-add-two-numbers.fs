\ tests/challenges/051-add-two-numbers.fs
\
\ CHALLENGE: Add Two Numbers
\ Source: leetcode  https://leetcode.com/problems/add-two-numbers/
\ Cognitive: 6/10  |  Pattern: add-two-number-lists
\
\ Define a word
\
\   : add-lists  ( ha hb -- hc )
\
\ Add two digit lists (LSB first); return sum list head.
\ Digits 0-9, no leading zeros except 0.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Propagate carry.
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
2 3 1 ch-val! 2 ch-next!
4 0 2 ch-val! 0 ch-next!
5 6 3 ch-val! 4 ch-next!
4 0 4 ch-val! 0 ch-next!
1 constant ch-head-a
3 constant ch-head-b

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 1 2 add-lists -> 1 }T
T{ ch-val@ 1 -> 7 }T

report bye
