\ tests/challenges/092-game-of-life.fs
\
\ CHALLENGE: Game of Life
\ Source: leetcode  https://leetcode.com/problems/game-of-life/
\ Cognitive: 7/10  |  Pattern: game-of-life-next
\
\ Define a word
\
\   : life-next  ( -- )
\
\ Apply Conway rules to ch-grid in place for one generation.
\ 1=live 0=dead.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Use scratch or in-place encoding.
\   - Mutates grid.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
8 constant ch-cols
8 constant ch-rows
create ch-grid ch-cols ch-rows * cells allot

: ch-grid@  ( col row -- n )  ch-cols * + cells ch-grid + @ ;
: ch-grid!  ( n col row -- )  ch-cols * + cells ch-grid + ! ;
0 0 0 ch-grid!  1 1 0 ch-grid!  0 2 0 ch-grid!
0 0 1 ch-grid!  0 1 1 ch-grid!  1 2 1 ch-grid!
0 0 2 ch-grid!  1 1 2 ch-grid!  0 2 2 ch-grid!
3 constant ch-cols-used
3 constant ch-rows-used

\ === paste your solution below this line ===

create life-scr  ch-cols ch-rows * cells allot

: lscr@ ( col row -- n )  ch-cols * + cells life-scr + @ ;
: lscr! ( n col row -- )  ch-cols * + cells life-scr + ! ;

: life-in? ( col row -- f )
  { col row }
  col 0>= row 0>= and row ch-rows-used < and col ch-cols-used < and ;

: life-live? ( col row -- n )
  2dup life-in? if  ch-grid@ 1 and  else  2drop 0  then ;

: life-nbrs ( col row -- n )
  { c r }
  0
  c r 1- life-live? +
  c 1+ r 1- life-live? +
  c 1+ r life-live? +
  c 1+ r 1+ life-live? +
  c r 1+ life-live? +
  c 1- r 1+ life-live? +
  c 1- r life-live? +
  c 1- r 1- life-live? + ;

: life-next-cell ( col row -- n )
  { col row }
  col row life-nbrs { n }
  col row ch-grid@ 1 and if
    n 2 = n 3 = or if 1 else 0 then
  else
    n 3 = if 1 else 0 then
  then ;

: life-copy-back ( -- )
  ch-rows-used 0 ?do
    ch-cols-used 0 ?do
      j i lscr@ j i ch-grid!
    loop
  loop ;

: life-next ( -- )
  ch-rows-used 0 ?do
    ch-cols-used 0 ?do
      j i life-next-cell j i lscr!
    loop
  loop
  life-copy-back ;

\ === paste your solution above this line ===

T{ life-next }T
T{ 1 1 ch-grid@ -> 1 }T

report bye
