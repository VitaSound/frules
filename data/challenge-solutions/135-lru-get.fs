\ tests/challenges/135-lru-get.fs
\
\ CHALLENGE: LRU Get
\ Source: leetcode  https://leetcode.com/problems/lru-cache/
\ Cognitive: 7/10  |  Pattern: lru-cache-get
\
\ Define a word
\
\   : lru-get  ( key -- val flag )
\
\ Return value and TRUE if key in fixed LRU (capacity 3) after sequence of puts in scaffold.
\ Companion words lru-put in scaffold.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Doubly-linked + hash table.
\   - Tests call lru-get only.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;

\ === paste your solution below this line ===

\ Avoid hyphens in create names used inside word bodies (tokenizer splits on '-').
3 constant lru-cap
8 constant lru-buckets

create lruht   lru-buckets cells allot
create lrunk   lru-cap cells allot
create lrunv   lru-cap cells allot
create lrupv   lru-cap cells allot
create lrunx   lru-cap cells allot

variable lru-head
variable lru-tail
variable lru-count

: lrunk@  ( n -- key )  cells lrunk + @ ;
: lrunv@  ( n -- val )  cells lrunv + @ ;
: lrupv@  ( n -- p )   cells lrupv + @ ;
: lrunx@  ( n -- nx )  cells lrunx + @ ;
: lrunk!  ( key n -- )  cells lrunk + ! ;
: lrunv!  ( val n -- )  cells lrunv + ! ;
: lrupv!  ( p n -- )    cells lrupv + ! ;
: lrunx!  ( nx n -- )   cells lrunx + ! ;

: lru-bucket  ( key -- addr )  lru-buckets mod cells lruht + ;

: lru-ht@  ( key -- n|-1 )  lru-bucket @ ;
: lru-ht!  ( n key -- )  lru-bucket ! ;
: lru-htclr  ( key -- )  -1 swap lru-bucket ! ;

variable lru-p
variable lru-nx

: lru-unlink  ( n -- )
  dup lrupv@ lru-p !
  dup lrunx@ lru-nx !
  lru-p @ -1 <> if
    lru-nx @ over lrunx!
  else
    lru-nx @ lru-head !
  then
  lru-nx @ -1 <> if
    lru-p @ over lrupv!
  else
    lru-p @ lru-tail !
  then
  -1 over lrupv!
  -1 swap lrunx! ;

: lru-append  ( n -- )
  { n | t }
  n lru-tail @  to t
  -1 n lrunx!
  t -1 <> if
    t n lrupv!
    n t lrunx!
  else
    n lru-head !
  then
  n lru-tail ! ;

: lru-touch  ( n -- )
  dup lru-tail @ = if  drop exit  then
  dup lru-unlink  lru-append ;

: lru-find  ( key -- n|-1 )
  { key }
  key lru-ht@ dup -1 <> if
    dup lrunk@ key = if  nip exit  then
  then
  drop -1 ;

: lru-init  ( -- )
  lru-buckets 0 ?do  -1 i cells lruht + !  loop
  -1 lru-head !
  -1 lru-tail !
  0 lru-count !
  lru-cap 0 ?do  -1 i lrupv!  -1 i lrunx!  loop ;

variable lru-node

: lru-put  ( key val -- )
  { key val }
  key lru-find dup -1 <> if
    val swap  lrunv!  dup  lru-touch  exit
  then
  drop
  lru-count @ lru-cap = if
    lru-head @  lru-node !
    lru-node @ lrunk@ lru-htclr
    lru-node @ lru-unlink
  else
    lru-count @  lru-node !
    lru-node @ 1+ lru-count !
  then
  key lru-node @ lrunk!
  val lru-node @ lrunv!
  lru-node @ key lru-ht!
  lru-node @ lru-append ;

: lru-get  ( key -- val true | false )
  lru-find dup -1 <> if
    dup lru-node !
    lru-node @ lrunv@
    lru-node @ lru-touch
    drop  true
  else
    drop false
  then ;

\ === paste your solution above this line ===

lru-init  1 1 lru-put  2 2 lru-put  1 3 lru-put

T{ 2 lru-get -> 2 true }T
T{ 3 lru-get -> false }T

report bye
