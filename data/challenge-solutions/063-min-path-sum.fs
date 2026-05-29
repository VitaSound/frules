\ tests/challenges/063-min-path-sum.fs
\
\ CHALLENGE: Minimum Path Sum
\ Source: leetcode  https://leetcode.com/problems/minimum-path-sum/
\ Cognitive: 6/10  |  Pattern: minimum-path-sum-grid
\
\ Define a word
\
\   : min-path-sum  ( -- sum )
\
\ Return min sum path from top-left to bottom-right using ch-grid.
\ Only right/down moves.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - DP on grid scaffold.
\   - Uses preloaded costs.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
8 constant ch-cols
8 constant ch-rows
create ch-grid ch-cols ch-rows * cells allot

: ch-grid@  ( col row -- n )  ch-cols * + cells ch-grid + @ ;
: ch-grid!  ( n col row -- )  ch-cols * + cells ch-grid + ! ;
1 0 0 ch-grid!  3 1 0 ch-grid!  1 2 0 ch-grid!
1 0 1 ch-grid!  5 1 1 ch-grid!  1 2 1 ch-grid!
4 0 2 ch-grid!  2 1 2 ch-grid!  1 2 2 ch-grid!
3 constant ch-cols-used
3 constant ch-rows-used

\ === paste your solution below this line ===

create ch-dp  ch-cols ch-rows * cells allot

: ch-dp@  ( col row -- n )  ch-cols * + cells ch-dp + @ ;
: ch-dp!  ( n col row -- )  ch-cols * + cells ch-dp + ! ;

variable fill-col
variable fill-row

: fill-dp ( -- )
  ch-cols-used ch-rows-used * 0 ?do
    i ch-cols-used mod fill-col !
    i ch-cols-used / fill-row !
    fill-col @ fill-row @ or 0= if
      fill-col @ fill-row @ ch-grid@  fill-col @ fill-row @ ch-dp!
    else
      fill-col @ 0= if
        fill-col @ fill-row @ ch-grid@
        fill-col @ fill-row @ 1- ch-dp@ +  fill-col @ fill-row @ ch-dp!
      else
        fill-row @ 0= if
          fill-col @ fill-row @ ch-grid@
          fill-col @ 1- fill-row @ ch-dp@ +  fill-col @ fill-row @ ch-dp!
        else
          fill-col @ fill-row @ ch-grid@
          fill-col @ 1- fill-row @ ch-dp@
          fill-col @ fill-row @ 1- ch-dp@  min +
          fill-col @ fill-row @ ch-dp!
        then
      then
    then
  loop ;

: min-path-sum ( -- sum )
  fill-dp
  ch-cols-used 1-  ch-rows-used 1-  ch-dp@ ;

\ === paste your solution above this line ===

T{ min-path-sum -> 7 }T

report bye
