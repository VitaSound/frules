\ tests/challenges/111-longest-dict-word.fs
\
\ CHALLENGE: Longest Dictionary Word
\ Source: leetcode  https://leetcode.com/problems/longest-word-in-dictionary/
\ Cognitive: 5/10  |  Pattern: longest-word-in-dictionary
\
\ Define a word
\
\   : longest-dict  ( c-addr u -- len )
\
\ Return length of longest word from dictionary buildable by adding one char at a time.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Trie + BFS/DFS.
\   - Dictionary preloaded.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
create ch-buf 64 chars allot

: ch-setup  ( c-addr u -- ch-buf u )
  dup >r  ch-buf swap  move  ch-buf r> ;

\ === paste your solution below this line ===

256 constant ld-max-nodes
27 constant ld-node-cells
create ld-nodes  ld-max-nodes ld-node-cells cells * allot
variable ld-node-n

0 constant ld-root
variable ld-best
variable ld-cur
variable ld-ch
variable ld-pnode

: ld-node  ( idx -- addr )
  ld-node-cells * cells ld-nodes + ;

: ld-end@  ( node -- f )
  ld-node 26 cells + @ ;

: ld-end!  ( f node -- )
  ld-node 26 cells + ! ;

: +slot  ( node ch -- addr )
  { node ch }
  node ld-node  ch [char] a - cells + ;

: ld-child@  ( node ch -- child )
  +slot @ ;

: ld-child!  ( child node ch -- child )
  { child node ch }
  child  node ch +slot  !  child ;

: ld-new-node  ( -- node )
  ld-node-n @
  dup >r  ld-node ld-node-cells cells 0 fill
  r@ 1+ ld-node-n !  r> ;

: ld-find-child  ( node ch -- child )
  2dup ld-child@ dup if
    >r  2drop  r>
  else
    drop  ld-ch !  ld-pnode !
    ld-new-node
    ld-pnode @  ld-ch @  ld-child!
  then ;

: ld-init  ( -- )
  ld-node-n @ 0= if
    ld-root ld-node-cells * cells ld-nodes +  ld-node-cells cells 0 fill
    1 ld-node-n !
  then ;

: dict-add  ( c-addr ulen -- )
  { c ulen }
  ld-init
  ld-root ld-cur !
  ulen 0 ?do
    c i + c@  ld-cur @  swap  ld-find-child  ld-cur !
  loop
  1 ld-cur @ ld-end! ;

: ld-can-grow?  ( node -- f )
  dup ld-root = if
    drop true
  else
    ld-end@
  then ;

: ld-dfs  ( node len -- )
  recursive
  { node len }
  len ld-best @ max ld-best !
  node ld-can-grow? if
    26 0 do
      node  i [char] a +  ld-child@ ?dup if
        len 1+  recurse
      then
    loop
  then ;

: longest-dict  ( c-addr u -- len )
  { c ulen }
  ld-root ld-cur !
  ulen 0 ?do
    c i + c@  ld-cur @  swap  ld-find-child  ld-cur !
  loop
  0 ld-best !
  ld-cur @ ulen ld-dfs
  ld-best @
  ;

\ === paste your solution above this line ===

s" w" ch-setup dict-add
s" wo" ch-setup dict-add
s" wor" ch-setup dict-add
s" worl" ch-setup dict-add
s" world" ch-setup dict-add

T{ s" w" ch-setup longest-dict -> 5 }T

report bye
