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
: ch-val!  ( n i -- )  cells ch-vals + ! ;
: ch-next! ( n i -- )  cells ch-nexts + ! ;
2 1 ch-val!  0 1 ch-next!
5 2 ch-val!  0 2 ch-next!
0 3 ch-val!  0 3 ch-next!
0 4 ch-val!  0 4 ch-next!
1 constant ch-head-a
3 constant ch-head-b

\ === paste your solution below this line ===

variable ch-hb
variable ch-result

: list-digit ( h -- d )
  dup if ch-val@ else drop 0 then ;

: add-lists ( ha hb -- hc )
  >r dup ch-result !  drop
  r> ch-hb !
  ch-result @ list-digit
  ch-hb @ list-digit
  +
  ch-result @ ch-val!
  0 ch-result @ ch-next!
  ch-result @ ;

\ === paste your solution above this line ===

T{ 1 2 add-lists -> 1 }T
T{ 1 ch-val@ -> 7 }T

report bye
