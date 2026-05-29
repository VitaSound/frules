\ tests/challenges/127-reorder-list.fs
\
\ CHALLENGE: Reorder List
\ Source: leetcode  https://leetcode.com/problems/reorder-list/
\ Cognitive: 6/10  |  Pattern: linked-list-reorder
\
\ Define a word
\
\   : reorder-list  ( head -- head' )
\
\ Reorder L0..Ln-1 to L0,Ln-1,L1,Ln-2,...
\ Return new head index.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Find middle, reverse second half, merge.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
\ Node index i: value in ch-vals[i], next in ch-nexts[i] (0 = nil)
12 constant ch-max-nodes
create ch-vals  ch-max-nodes cells allot
create ch-nexts ch-max-nodes cells allot

: ch-val@  ( i -- n )  cells ch-vals + @ ;
: ch-next@ ( i -- n )  cells ch-nexts + @ ;
: ch-val!  ( n i -- )  swap cells ch-vals + ! ;
: ch-next! ( n i -- )  swap cells ch-nexts + ! ;
1 2 1 ch-val! 2 ch-next!
2 3 2 ch-val! 3 ch-next!
3 4 3 ch-val! 4 ch-next!
4 5 4 ch-val! 5 ch-next!
5 0 5 ch-val! 0 ch-next!
1 constant ch-head

\ === paste your solution below this line ===

variable rl-slow
variable rl-fast
variable rl-prev
variable rl-curr
variable rl-next
variable rl-p1
variable rl-p2
variable rl-t1
variable rl-t2
variable rl-head
variable rl-mid

: rl-can-advance-2?  ( node -- flag )
  dup 0<> if
    ch-next@ 0<> if  true  else  false  then
  else
    drop false
  then ;

: rl-find-middle  ( head -- mid-head )
  dup rl-slow !  rl-fast !
  begin  rl-fast @ rl-can-advance-2?  while
    rl-slow @ ch-next@ rl-slow !
    rl-fast @ ch-next@ ch-next@ rl-fast !
  repeat
  rl-slow @ ch-next@ rl-mid !
  rl-slow @ 0 ch-next!
  rl-mid @ ;

: rl-reverse  ( head -- new-head )
  0 rl-prev !
  rl-curr !
  begin  rl-curr @ 0<>  while
    rl-curr @ ch-next@ rl-next !
    rl-curr @ rl-prev @ ch-next!
    rl-curr @ rl-prev !
    rl-next @ rl-curr !
  repeat
  rl-prev @ ;

: rl-merge  ( head1 head2 -- )
  rl-p2 !  rl-p1 !
  begin  rl-p1 @ 0=  rl-p2 @ 0=  or  0=  while
    rl-p1 @ ch-next@ rl-t1 !
    rl-p2 @ ch-next@ rl-t2 !
    rl-p1 @ rl-p2 @ ch-next!
    rl-t1 @ if  rl-p2 @ rl-t1 @ ch-next!  then
    rl-t1 @ rl-p1 !
    rl-t2 @ rl-p2 !
  repeat ;

: reorder-list  ( head -- head' )
  rl-head !
  rl-head @ rl-find-middle rl-reverse
  rl-head @ swap rl-merge
  rl-head @ ;

\ === paste your solution above this line ===

T{ 1 reorder-list -> 1 }T
T{ 1 ch-next@ -> 5 }T
T{ 5 ch-next@ -> 2 }T
T{ 2 ch-next@ -> 4 }T
T{ 4 ch-next@ -> 3 }T

report bye
