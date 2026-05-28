\ tests/challenges/027-three-sum-closest.fs
\
\ CHALLENGE: Three Sum Closest
\ Source: leetcode  https://leetcode.com/problems/3sum-closest/
\ Cognitive: 6/10  |  Pattern: three-sum-closest-sum
\
\ Define a word
\
\   : three-sum-closest  ( target -- sum )
\
\ Return sum of three distinct elements closest to target.
\ Tie: smaller absolute difference wins.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Sort + two pointers.
\   - Uses ch-data preload.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
\ Fixed: preload was "-1 2 1 ch!" (only set ch-data[1]=2, left -1 on stack);
\        now loads -1,2,1 with the standard "n i ch!" pattern.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
-1 0 ch!  2 1 ch!  1 2 ch!
3 constant ch-n

\ === paste your solution below this line ===

\ Private working copy so we never mutate the read-only fixture ch-data.
create ch-work ch-max cells allot

: work@  ( i -- n )  cells ch-work + @ ;
: work!  ( n i -- )  cells ch-work + ! ;

: load-work  ( -- )            \ copy ch-data[0..ch-n) into ch-work
  0 { p }
  begin p ch-n < while
    p ch@ p work!
    p 1+ to p
  repeat ;

: sort-work  ( -- )            \ insertion sort ch-work ascending
  0 0 0 { p j key }
  1 to p
  begin p ch-n < while
    p work@ to key
    p to j
    begin j 0> j 1- work@ key > and while
      j 1- work@ j work!
      j 1- to j
    repeat
    key j work!
    p 1+ to p
  repeat ;

: three-sum-closest  ( target -- sum )
  load-work  sort-work
  0 0 0 0 0  { target best lo hi sum p }
  0 work@ 1 work@ + 2 work@ + to best
  begin p ch-n 2 - < while
    p 1+ to lo
    ch-n 1- to hi
    begin lo hi < while
      p work@ lo work@ + hi work@ + to sum
      sum target - abs  best target - abs  < if  sum to best  then
      sum target < if  lo 1+ to lo
      else sum target > if  hi 1- to hi
      else  hi to lo
      then then
    repeat
    p 1+ to p
  repeat
  best ;

\ === paste your solution above this line ===

T{ 1 three-sum-closest -> 2 }T

report bye
