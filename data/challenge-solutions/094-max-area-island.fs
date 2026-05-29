\ tests/challenges/094-max-area-island.fs
\
\ CHALLENGE: Max Area Island
\ Source: leetcode  https://leetcode.com/problems/max-area-of-island/
\ Cognitive: 6/10  |  Pattern: max-area-of-island
\
\ Define a word
\
\   : max-island  ( -- area )
\
\ Return area of largest 1-component in ch-grid.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - DFS count.
\   - Uses grid scaffold.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
\ Fixed: 2x3 island block yields area 6 (was 3 on old grid).
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
8 constant ch-cols
8 constant ch-rows
create ch-grid ch-cols ch-rows * cells allot

: ch-grid@  ( col row -- n )  ch-cols * + cells ch-grid + @ ;
: ch-grid!  ( n col row -- )  ch-cols * + cells ch-grid + ! ;
1 0 0 ch-grid!  1 1 0 ch-grid!  1 2 0 ch-grid!
1 0 1 ch-grid!  1 1 1 ch-grid!  1 2 1 ch-grid!
0 0 2 ch-grid!  0 1 2 ch-grid!  0 2 2 ch-grid!
3 constant ch-cols-used
3 constant ch-rows-used

\ === paste your solution below this line ===

: isl-in? ( c r -- f )
  { c r }
  c 0>= r 0>= and r ch-rows-used < and c ch-cols-used < and ;

: isl-dfs ( c r -- area )
  recursive
  { c r }
  c r isl-in? 0= if 0 exit then
  c r ch-grid@ 1 <> if 0 exit then
  0 c r ch-grid!
  1
  c 1+ r isl-dfs +
  c 1- r isl-dfs +
  c r 1+ isl-dfs +
  c r 1- isl-dfs + ;

: max-island ( -- area )
  0
  ch-rows-used 0 ?do
    ch-cols-used 0 ?do
      i j ch-grid@ 1 = if
        i j isl-dfs max
      then
    loop
  loop ;

\ === paste your solution above this line ===

T{ max-island -> 6 }T

report bye
