\ tests/challenges/086-find-k-pairs.fs
\
\ CHALLENGE: K Pairs Smallest
\ Source: leetcode  https://leetcode.com/problems/find-k-pairs-with-smallest-sums/
\ Cognitive: 7/10  |  Pattern: find-k-pairs-with-smallest-sums
\
\ Define a word
\
\   : k-pairs-sum  ( k -- sum )
\
\ Return sum of kth smallest pair from two sorted arrays in ch-a/ch-b segments.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Heap merge.
\   - Preload arrays.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
\ Fixed: A=[1,1,3] B=[3,4] sorted; k=2 smallest pair sum is 4.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
1 0 ch!  1 1 ch!  3 2 ch!  3 3 ch!  4 4 ch!
5 constant ch-n
3 constant ch-a-len

\ === paste your solution below this line ===

create kp-sums  ch-max cells allot
variable kp-n

: b-len ( -- n )  ch-n ch-a-len - ;

: b@ ( j -- n )  ch-a-len + ch@ ;

: sum@ ( i -- n )  cells kp-sums + @ ;

: sum! ( n i -- )  cells kp-sums + ! ;

: pair-sum ( ai bi -- s )
  >r ch@ r> b@ + ;

: fill-sums ( -- )
  0 kp-n !
  ch-a-len 0 ?do
    b-len 0 ?do
      j i pair-sum  kp-n @ sum!  kp-n @ 1+ kp-n !
    loop
  loop ;

variable swap-t

: sum-swap ( i j -- )
  dup sum@ swap-t !
  sum@ over sum!  swap-t @ swap sum! ;

variable sel-best
variable sel-val
variable sel-pos
variable kp-k

variable sel-i

: try-smaller ( cur -- )
  sel-val @ over > if
    sel-val !  sel-i @ sel-best !
  else drop then ;

: sel-step ( pos -- )
  dup sel-best !  dup sum@ sel-val !
  sel-pos !
  sel-pos @ 1+ sel-i !
  begin  sel-i @ kp-n @ <
  while
    sel-i @ sum@ try-smaller
    sel-i @ 1+ sel-i !
  repeat
  sel-pos @ sel-best @ sum-swap ;

variable kp-i

: k-pairs-sum ( k -- sum )
  kp-k !
  fill-sums
  0 kp-i !
  begin  kp-i @ kp-k @ <
  while
    kp-i @ sel-step
    kp-i @ 1+ kp-i !
  repeat
  kp-k @ 1- sum@ ;

\ === paste your solution above this line ===

T{ 2 k-pairs-sum -> 4 }T

report bye
