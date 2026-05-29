\ tests/challenges/071-rotting-oranges.fs
\
\ CHALLENGE: Rotting Oranges
\ Source: leetcode  https://leetcode.com/problems/rotting-oranges/
\ Cognitive: 6/10  |  Pattern: rotting-oranges-bfs
\
\ Define a word
\
\   : rotten-days  ( -- days )
\
\ Return minutes until no fresh orange remains; -1 if impossible.
\ 2=rotten 1=fresh 0=empty.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Multi-source BFS.
\   - Uses grid scaffold.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
8 constant ch-cols
8 constant ch-rows
create ch-grid ch-cols ch-rows * cells allot

: ch-grid@  ( col row -- n )  ch-cols * + cells ch-grid + @ ;
: ch-grid!  ( n col row -- )  ch-cols * + cells ch-grid + ! ;
2 0 0 ch-grid!  1 1 0 ch-grid!  1 2 0 ch-grid!
1 0 1 ch-grid!  1 1 1 ch-grid!  0 2 1 ch-grid!
0 0 2 ch-grid!  1 1 2 ch-grid!  1 2 2 ch-grid!
3 constant ch-cols-used
3 constant ch-rows-used

\ === paste your solution below this line ===

64 constant q-max
create q-col  q-max cells allot
create q-row  q-max cells allot
variable q-in
variable q-out

: q-clear ( -- )  0 q-in !  0 q-out ! ;

: q-items ( -- n )
  q-in @ q-out @  2dup =
  if  2drop 0
  else  2dup > if  -  else  q-max swap - q-in @ +  then
  then ;

: q-col! ( col idx -- ) swap cells q-col + ! ;
: q-row! ( row idx -- ) swap cells q-row + ! ;
: q-col@ ( idx -- col ) cells q-col + @ ;
: q-row@ ( idx -- row ) cells q-row + @ ;

: q-enq ( col row -- )
  { col row }
  q-in @ >r
  col r@ swap q-col!
  row r@ swap q-row!
  r> 1+ dup q-max = if drop 0 then q-in ! ;

: q-deq ( -- col row )
  q-out @ >r
  r@ q-col@
  r@ q-row@
  r> 1+ dup q-max = if drop 0 then q-out ! ;

variable ch-fresh
variable rot-minutes

: try-rot ( col row -- )
  { c r }
  c 0>= r 0>= and  c ch-cols-used <  r ch-rows-used <  and  if
    c r ch-grid@ 1 = if
      drop
      2 c r ch-grid!
      ch-fresh @ 1- ch-fresh !
      c r q-enq
    else
      drop
    then
  then ;

: rot-neighbors ( col row -- )
  { c r }
  c 1+ r try-rot
  c 1- r try-rot
  c r 1+ try-rot
  c r 1- try-rot ;

: seed-queue ( -- )
  q-clear  0 ch-fresh !  0 rot-minutes !
  ch-cols-used ch-rows-used * 0 ?do
    i ch-cols-used mod  i ch-cols-used /
    2dup ch-grid@
    dup 2 = if
      drop q-enq
    else
      dup 1 = if  ch-fresh @ 1+ ch-fresh !  then
      drop 2drop
    then
  loop ;

: rot-wave ( -- )
  q-items 0 ?do
    q-deq rot-neighbors
  loop ;

: rotten-days ( -- days )
  seed-queue
  ch-fresh @ 0= if
    rot-minutes @
  else
    begin  ch-fresh @  while
      rot-wave
      rot-minutes @ 1+ rot-minutes !
    repeat  2drop
    rot-minutes @
  then ;

\ === paste your solution above this line ===

T{ rotten-days -> 4 }T

report bye
