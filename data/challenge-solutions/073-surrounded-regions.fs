\ tests/challenges/073-surrounded-regions.fs
\
\ CHALLENGE: Surrounded Regions
\ Source: leetcode  https://leetcode.com/problems/surrounded-regions/
\ Cognitive: 7/10  |  Pattern: surrounded-regions-flip
\
\ Define a word
\
\   : capture-count  ( -- count )
\
\ Return count of O regions fully surrounded by X after capture.
\ X and O on grid.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - DFS from borders.
\   - Mutates grid to count.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
char X constant ch-X
char O constant ch-O
8 constant ch-cols
8 constant ch-rows
create ch-grid ch-cols ch-rows * cells allot

: ch-grid@  ( col row -- n )  ch-cols * + cells ch-grid + @ ;
: ch-grid!  ( n col row -- )  ch-cols * + cells ch-grid + ! ;
ch-X 0 0 ch-grid!  ch-X 1 0 ch-grid!  ch-X 2 0 ch-grid!
ch-X 0 1 ch-grid!  ch-O 1 1 ch-grid!  ch-X 2 1 ch-grid!
ch-X 0 2 ch-grid!  ch-X 1 2 ch-grid!  ch-X 2 2 ch-grid!
3 constant ch-cols-used
3 constant ch-rows-used

\ === paste your solution below this line ===

3 constant ch-safe

: in-bounds? ( col row -- flag )
  over ch-cols-used <  over ch-rows-used <  and  nip nip ;

: mark-safe ( col row -- )
  recursive
  { c r }
  c r in-bounds? 0= if exit then
  c r ch-grid@  dup ch-O <> if drop exit then
  dup ch-safe = if drop exit then  drop
  ch-safe c r ch-grid!
  c 1+ r mark-safe
  c 1- r mark-safe
  c r 1+ mark-safe
  c r 1- mark-safe ;

: border-mark ( -- )
  ch-cols-used 0 ?do  i 0 mark-safe  loop
  ch-cols-used 0 ?do  i ch-rows-used 1- mark-safe  loop
  ch-rows-used 0 ?do  0 i mark-safe  loop
  ch-rows-used 0 ?do  ch-cols-used 1- i mark-safe  loop ;

: flip-captured ( -- count )
  0  ch-rows-used 0 ?do
    ch-cols-used 0 ?do
      i j ch-grid@  dup ch-O =
      if  drop ch-X i j ch-grid!  1+
      else  drop  then
    loop
  loop ;

: capture-count ( -- count )
  border-mark  flip-captured ;

\ === paste your solution above this line ===

T{ capture-count -> 1 }T

report bye
