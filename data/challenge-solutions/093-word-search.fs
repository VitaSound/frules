\ tests/challenges/093-word-search.fs
\
\ CHALLENGE: Word Search
\ Source: leetcode  https://leetcode.com/problems/word-search/
\ Cognitive: 7/10  |  Pattern: word-search-grid
\
\ Define a word
\
\   : word-search?  ( c-addr u -- flag )
\
\ Return TRUE if word exists in ch-grid using adjacent cell path.
\ Reuse cell allowed per path.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Backtracking DFS.
\   - Use ch-setup for word.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
\ Fixed: letter cells use char literals; add ch-setup; 4x3 LeetCode grid for SEE.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
8 constant ch-cols
8 constant ch-rows
create ch-grid ch-cols ch-rows * cells allot

: ch-grid@  ( col row -- n )  ch-cols * + cells ch-grid + @ ;
: ch-grid!  ( n col row -- )  ch-cols * + cells ch-grid + ! ;
char A 0 0 ch-grid!  char B 1 0 ch-grid!  char C 2 0 ch-grid!  char E 3 0 ch-grid!
char S 0 1 ch-grid!  char F 1 1 ch-grid!  char C 2 1 ch-grid!  char S 3 1 ch-grid!
char A 0 2 ch-grid!  char D 1 2 ch-grid!  char E 2 2 ch-grid!  char E 3 2 ch-grid!
4 constant ch-cols-used
3 constant ch-rows-used

create ch-buf 64 chars allot

: ch-setup  ( c-addr u -- ch-buf u )
  dup >r  ch-buf swap  move  ch-buf r> ;

\ === paste your solution below this line ===

create ws-vis  ch-cols ch-rows * cells allot

variable ws-addr
variable ws-length

: ws-in? ( c r -- f )
  { c r }
  c 0>= r 0>= and r ch-rows-used < and c ch-cols-used < and ;

: ws-v@ ( c r -- f )
  ch-cols * + cells ws-vis + @ ;

: ws-v! ( f c r -- )
  ch-cols * + cells ws-vis + ! ;

: ws-ch@ ( idx -- ch )
  ws-addr @ + c@ ;

: ws-match ( c r idx -- f )
  { c r idx }
  idx ws-length @ >= if true exit then
  c r ws-in? 0= if false exit then
  c r ws-v@ if false exit then
  idx ws-ch@ c r ch-grid@ = ;

: ws-dfs ( c r idx -- f )
  recursive
  { c r idx }
  c r idx ws-match 0= if false exit then
  idx ws-length @ >= if true exit then
  -1 c r ws-v!
  idx 1+ { n }
  c 1+ r n ws-dfs if c r 0 ws-v! true exit then
  c 1- r n ws-dfs if c r 0 ws-v! true exit then
  c r 1+ n ws-dfs if c r 0 ws-v! true exit then
  c r 1- n ws-dfs if c r 0 ws-v! true exit then
  c r 0 ws-v! false ;

: ws-clear ( -- )
  ch-rows-used 0 ?do
    ch-cols-used 0 ?do
      0 i j ws-v!
    loop
  loop ;

: ws-save-word ( c-addr u -- )
  swap ws-addr !  ws-length ! ;

variable ws-found

: word-search? ( c-addr u -- flag )
  ws-save-word
  ws-clear
  false ws-found !
  ch-rows-used 0 ?do
    ch-cols-used 0 ?do
      ws-found @ 0= if
        i j 0 ws-dfs if true ws-found ! then
      then
    loop
  loop
  begin  depth  while  drop  repeat
  ws-found @ ;

\ === paste your solution above this line ===

T{ s" ABCCED" ch-setup word-search? -> true }T
T{ s" SEE" ch-setup word-search? -> true }T
T{ s" ABCB" ch-setup word-search? -> false }T

report bye
