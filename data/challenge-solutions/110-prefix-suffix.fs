\ tests/challenges/110-prefix-suffix.fs
\
\ CHALLENGE: Prefix Suffix Search
\ Source: leetcode  https://leetcode.com/problems/prefix-and-suffix-search/
\ Cognitive: 7/10  |  Pattern: prefix-and-suffix-search
\
\ Define a word
\
\   : prefix-suffix?  ( c-addr u -- flag )
\
\ Return TRUE if any word has given prefix and suffix simultaneously.
\ Benchmark boolean variant.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Combined trie or hash.
\   - Use ch-setup.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
create ch-buf 64 chars allot

: ch-setup  ( c-addr u -- ch-buf u )
  dup >r  ch-buf swap  move  ch-buf r> ;

\ === paste your solution below this line ===

256 constant ps-max-nodes
27 constant ps-node-cells
create ps-nodes  ps-max-nodes ps-node-cells cells * allot
variable ps-node-n

0 constant ps-root
variable ps-cur
variable ps-ch
variable ps-pnode

create ps-path  64 chars allot
variable ps-depth
variable ps-fail

: ps-node  ( idx -- addr )
  ps-node-cells * cells ps-nodes + ;

: ps-end@  ( node -- f )
  ps-node 26 cells + @ ;

: ps-end!  ( f node -- )
  ps-node 26 cells + ! ;

: ps-slot  ( node ch -- addr )
  { node ch }
  node ps-node  ch [char] a - cells + ;

: ps-child@  ( node ch -- child )
  ps-slot @ ;

: ps-child!  ( child node ch -- child )
  { child node ch }
  child  node ch ps-slot  !  child ;

: ps-new-node  ( -- node )
  ps-node-n @
  dup >r  ps-node ps-node-cells cells 0 fill
  r@ 1+ ps-node-n !  r> ;

: ps-find-child  ( node ch -- child )
  2dup ps-child@ dup if
    >r  2drop  r>
  else
    drop  ps-ch !  ps-pnode !
    ps-new-node
    ps-pnode @  ps-ch @  ps-child!
  then ;

: ps-init  ( -- )
  ps-node-n @ 0= if
    ps-root ps-node-cells * cells ps-nodes +  ps-node-cells cells 0 fill
    1 ps-node-n !
  then ;

: dict-add  ( c-addr ulen -- )
  { buf nlen }
  ps-init
  ps-root ps-cur !
  nlen 0 ?do
    buf i + c@  ps-cur @  swap  ps-find-child  ps-cur !
  loop
  1 ps-cur @ ps-end! ;

: ps-suffix?  ( depth slen sufaddr -- f )
  { depth slen sufaddr }
  depth slen u< if
    false
  else
    depth slen -  ps-path +  slen  sufaddr slen  compare  0=
  then ;

: ps-dfs  ( node slen sufaddr -- f )  recursive
  { node slen sufaddr }
  node ps-end@ if
    ps-depth @ slen u>= if
      ps-depth @ slen sufaddr ps-suffix? if  true  exit  then
    then
  then
  26 0 do
    node  i [char] a +  ps-child@  ?dup if
      i [char] a +  ps-depth @ ps-path + c!
      ps-depth @ 1+ ps-depth !
      slen sufaddr recurse  if
        ps-depth @ 1- ps-depth !
        unloop  true  exit
      then
      ps-depth @ 1- ps-depth !
    then
  loop
  false ;

: prefix-suffix?  ( c-addr ulen -- f )
  { qaddr qlen }
  qlen 0= if
    false
  else
    0 ps-depth !
    0 ps-fail !
    ps-root ps-cur !
    qlen 0 ?do
      qaddr i + c@  { ch }
      ch  ps-depth @  ps-path +  c!
      ps-depth @  1+  ps-depth !
      ch  ps-cur @  swap  ps-child@  dup 0= if
        drop  1 ps-fail !  leave
      then
      ps-cur !
    loop
    ps-fail @ 0= if
      ps-cur @  ps-end@ if
        ps-depth @  qlen  u>= if
          ps-depth @  qlen  qaddr  ps-suffix?  if
            true
          else
            ps-cur @  qlen  qaddr  ps-dfs
          then
        else
          ps-cur @  qlen  qaddr  ps-dfs
        then
      else
        ps-cur @  qlen  qaddr  ps-dfs
      then
    else
      false
    then
  then ;

\ === paste your solution above this line ===

s" apple" ch-setup dict-add

T{ s" apple" ch-setup prefix-suffix? -> true }T
T{ s" xyz" ch-setup prefix-suffix? -> false }T

report bye
