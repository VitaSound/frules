\ tests/challenges/065-coin-change.fs
\
\ CHALLENGE: Coin Change Ways
\ Source: leetcode  https://leetcode.com/problems/coin-change/
\ Cognitive: 6/10  |  Pattern: coin-change-combinations
\
\ Define a word
\
\   : coin-change  ( amount -- ways )
\
\ Count ways to make amount using coins in ch-data[0..ch-n).
\ Unlimited coin supply.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Unbounded knapsack DP.
\   - amount on stack.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
1 0 ch!  2 1 ch!  5 2 ch!
3 constant ch-n

\ === paste your solution below this line ===

256 constant ch-dp-max
create ch-dp  ch-dp-max cells allot

: ch-dp@  ( a -- n )  cells ch-dp + @ ;
: ch-dp!  ( n a -- )  cells ch-dp + ! ;

variable ch-amt
variable ch-coin
variable ch-ix

: zero-dp ( limit -- )
  1+ 0 ?do  0 i ch-dp!  loop ;

: add-coin ( -- )
  ch-ix @ ch@ ch-coin !
  ch-coin @ ch-amt @ <= if
    ch-amt @ 1+ ch-coin @ ?do
      i ch-dp@  i ch-coin @ - ch-dp@ +  i ch-dp!
    loop
  then ;

: coin-change ( amount -- ways )
  dup 0< if
    drop 0
  else
    ch-amt !
    ch-amt @ zero-dp
    1 0 ch-dp!
    0 ch-ix !
    begin
      ch-ix @ ch-n <
    while
      add-coin
      ch-ix @ 1+ ch-ix !
    repeat
    ch-amt @ ch-dp@
  then ;

\ === paste your solution above this line ===

T{ 5 coin-change -> 4 }T
T{ 3 coin-change -> 2 }T

report bye
