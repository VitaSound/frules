\ tests/challenges/090-spiral-len.fs
\
\ CHALLENGE: Spiral Matrix Count
\ Source: leetcode  https://leetcode.com/problems/spiral-matrix/
\ Cognitive: 5/10  |  Pattern: spiral-matrix-count
\
\ Define a word
\
\   : spiral-cells  ( -- count )
\
\ Return number of cells visited in clockwise spiral order (benchmark counts visits).
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Simulate directions.
\   - Uses rectangular grid.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
8 constant ch-cols
8 constant ch-rows
create ch-grid ch-cols ch-rows * cells allot

: ch-grid@  ( col row -- n )  ch-cols * + cells ch-grid + @ ;
: ch-grid!  ( n col row -- )  ch-cols * + cells ch-grid + ! ;
1 0 0 ch-grid!  2 1 0 ch-grid!  3 2 0 ch-grid!
4 0 1 ch-grid!  5 1 1 ch-grid!  6 2 1 ch-grid!
7 0 2 ch-grid!  8 1 2 ch-grid!  9 2 2 ch-grid!
3 constant ch-cols-used
3 constant ch-rows-used

\ === paste your solution below this line ===

variable sp-top
variable sp-bot
variable sp-left
variable sp-right
variable sp-cnt
variable sp-i

: sp-inc ( -- )  1 sp-cnt +! ;

: sp-top-row ( -- )
  sp-left @ sp-i !
  begin  sp-i @ sp-right @ <=  while
    sp-inc  sp-i @ 1+ sp-i !
  repeat ;

: sp-right-col ( -- )
  sp-top @ sp-i !
  begin  sp-i @ sp-bot @ <=  while
    sp-inc  sp-i @ 1+ sp-i !
  repeat ;

: sp-bot-row ( -- )
  sp-right @ sp-i !
  begin  sp-i @ sp-left @ >=  while
    sp-inc  sp-i @ 1- sp-i !
  repeat ;

: sp-left-col ( -- )
  sp-bot @ sp-i !
  begin  sp-i @ sp-top @ >=  while
    sp-inc  sp-i @ 1- sp-i !
  repeat ;

: spiral-cells ( -- n )
  0 sp-cnt !
  0 sp-top !  ch-rows-used 1- sp-bot !
  0 sp-left !  ch-cols-used 1- sp-right !
  begin  sp-top @ sp-bot @ <=  sp-left @ sp-right @ <=  and  while
    sp-left @ sp-right @ <= if
      sp-top-row  sp-top @ 1+ sp-top !
    then
    sp-top @ sp-bot @ <= if
      sp-right-col  sp-right @ 1- sp-right !
    then
    sp-top @ sp-bot @ <=  sp-left @ sp-right @ <=  and  if
      sp-bot-row  sp-bot @ 1- sp-bot !
    then
    sp-top @ sp-bot @ <=  sp-left @ sp-right @ <=  and  if
      sp-left-col  sp-left @ 1+ sp-left !
    then
  repeat
  sp-cnt @ ;

\ === paste your solution above this line ===

T{ spiral-cells -> 9 }T

report bye
