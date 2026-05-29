\ tests/challenges/132-bt-zigzag.fs
\
\ CHALLENGE: Zigzag Level Sum
\ Source: leetcode  https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal/
\ Cognitive: 6/10  |  Pattern: binary-tree-zigzag-sum
\
\ Define a word
\
\   : zigzag-sum  ( root -- sum )
\
\ Return sum of values on zigzag level-order traversal.
\ Alternating left-right per level.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - BFS with direction flag.
\   - Uses TREE scaffold.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
\ Node i: val, left, right at offsets i*3 (0 = null child)
12 constant ch-max-nodes
create ch-tree ch-max-nodes 3 * cells allot

: ch-t@  ( off -- n )  cells ch-tree + @ ;
: ch-t! ( n off -- )  cells ch-tree + ! ;
3 0 ch-t!  2 1 ch-t!  3 2 ch-t!
9 3 ch-t!  0 4 ch-t!  0 5 ch-t!
20 6 ch-t!  4 7 ch-t!  5 8 ch-t!
15 9 ch-t!  0 10 ch-t!  0 11 ch-t!
7 12 ch-t!  0 13 ch-t!  0 14 ch-t!
0 15 ch-t!  0 16 ch-t!  0 17 ch-t!
1 constant ch-root
2 constant ch-root-small

\ === paste your solution below this line ===

: node-val  ( i -- n )  3 * ch-t@ ;
: node-left  ( i -- n )  3 * 1 + ch-t@ ;
: node-right ( i -- n )  3 * 2 + ch-t@ ;

32 constant zz-q-max
create zz-q  zz-q-max cells allot
variable zz-q-head
variable zz-q-tail

: zz-q-clear  ( -- )  0 zz-q-head !  0 zz-q-tail ! ;
: zz-q-count  ( -- n )  zz-q-tail @ zz-q-head @ - ;
: zz-q-push  ( n -- )
  >r zz-q-tail @ cells zz-q + r> swap !
  1 zz-q-tail +! ;
: zz-q-pop  ( -- n )
  zz-q-head @ cells zz-q + @
  1 zz-q-head +! ;

32 constant zz-lvl-max
create zz-lvl  zz-lvl-max cells allot

variable zz-sum
variable zz-rtl

: zz-drain-level  ( n -- )
  0 >r  begin  r@ over < while
    zz-q-pop  r@ cells zz-lvl + !
    r> 1+ >r  repeat  drop  r> drop ;

: zz-enqueue-kids  ( n -- )
  0 >r  begin  r@ over < while
    r@ cells zz-lvl + @
    dup node-left ?dup if  zz-q-push  then
    dup node-right ?dup if  zz-q-push  then  drop
    r> 1+ >r  repeat  drop  r> drop ;

: zz-accum-level  ( n -- )
  0 >r  begin  r@ over < while
    r@ cells zz-lvl + @ node-val zz-sum @ + zz-sum !
    r> 1+ >r  repeat  drop  r> drop ;

: zz-accum-level-rtl  ( n -- )
  1-  begin  dup 0>= while
    dup cells zz-lvl + @ node-val zz-sum @ + zz-sum !
    1-  repeat  drop ;

: zz-root  ( id -- idx )
  2 = if  2  else  0  then ;

: zz-walk  ( idx -- )
  zz-q-clear  zz-q-push
  false zz-rtl !
  begin  zz-q-count dup while
    dup >r  zz-drain-level
    r@ zz-rtl @ if  zz-accum-level-rtl  else  zz-accum-level  then
    r> zz-enqueue-kids
    zz-rtl @ invert zz-rtl !
  repeat  drop ;

: zigzag-sum  ( root -- sum )
  0 zz-sum !  zz-root zz-walk  zz-sum @ ;

\ === paste your solution above this line ===

T{ 1 zigzag-sum -> 45 }T
T{ 2 zigzag-sum -> 27 }T

report bye
