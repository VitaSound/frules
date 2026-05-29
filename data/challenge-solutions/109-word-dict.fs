\ tests/challenges/109-word-dict.fs
\
\ CHALLENGE: Word Dictionary
\ Source: leetcode  https://leetcode.com/problems/add-and-search-word-data-structure-design/
\ Cognitive: 6/10  |  Pattern: add-and-search-word-dictionary
\
\ Define a word
\
\   : word-dict?  ( c-addr u -- flag )
\
\ Return TRUE if word exists allowing '.' wildcard.
\ Trie with wildcard search.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - DFS on trie.
\   - Preload dictionary.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
create ch-buf 64 chars allot

: ch-setup  ( c-addr u -- ch-buf u )
  dup >r  ch-buf swap  move  ch-buf r> ;

\ === paste your solution below this line ===

256 constant wd-max-nodes
27 constant wd-node-cells
create wd-nodes  wd-max-nodes wd-node-cells cells * allot
variable wd-node-n

0 constant wd-root
variable wd-cur
variable wd-ch
variable wd-pnode

: wd-node  ( idx -- addr )
  wd-node-cells * cells wd-nodes + ;

: wd-end@  ( node -- f )
  wd-node 26 cells + @ ;

: wd-end!  ( f node -- )
  wd-node 26 cells + ! ;

: wd-slot  ( node ch -- addr )
  { node ch }
  node wd-node  ch [char] a - cells + ;

: wd-child@  ( node ch -- child )
  wd-slot @ ;

: wd-child!  ( child node ch -- child )
  { child node ch }
  child  node ch wd-slot  !  child ;

: wd-new-node  ( -- node )
  wd-node-n @
  dup >r  wd-node wd-node-cells cells 0 fill
  r@ 1+ wd-node-n !  r> ;

: wd-find-child  ( node ch -- child )
  2dup wd-child@ dup if
    >r  2drop  r>
  else
    drop  wd-ch !  wd-pnode !
    wd-new-node
    wd-pnode @  wd-ch @  wd-child!
  then ;

: wd-init  ( -- )
  wd-node-n @ 0= if
    wd-root wd-node-cells * cells wd-nodes +  wd-node-cells cells 0 fill
    1 wd-node-n !
  then ;

: dict-add  ( c-addr ulen -- )
  { buf nlen }
  wd-init
  wd-root wd-cur !
  nlen 0 ?do
    buf i + c@  wd-cur @  swap  wd-find-child  wd-cur !
  loop
  1 wd-cur @ wd-end! ;

: wd-search  ( node buf nlen pos -- f )  recursive
  { node buf nlen pos }
  pos nlen u= if
    node wd-end@ 0<>
  else
    buf pos + c@  { ch }
    ch  [char]  .  =
    if
      26 0 do
        node  i [char] a +  wd-child@  ?dup if
          buf  nlen  pos  1+  recurse  if
            unloop  true  exit
          then
        then
      loop
      false
    else
      node  ch  wd-child@  ?dup if
        buf  nlen  pos  1+  recurse
      else
        false
      then
    then
  then ;

: word-dict?  ( c-addr ulen -- f )
  { buf nlen }
  wd-root  buf  nlen  0  wd-search ;

\ === paste your solution above this line ===

s" bad" ch-setup dict-add
s" dad" ch-setup dict-add
s" mad" ch-setup dict-add

T{ s" bad" ch-setup word-dict? -> true }T
T{ s" b.d" ch-setup word-dict? -> true }T
T{ s" b.dz" ch-setup word-dict? -> false }T

report bye
