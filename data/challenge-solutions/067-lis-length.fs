\ tests/challenges/067-lis-length.fs
\
\ CHALLENGE: Longest Increasing Subsequence
\ Source: leetcode  https://leetcode.com/problems/longest-increasing-subsequence/
\ Cognitive: 7/10  |  Pattern: longest-increasing-subsequence
\
\ Define a word
\
\   : lis-len  ( -- len )
\
\ Return length of longest strictly increasing subsequence in ch-data.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - O(n^2) DP OK for small n.
\   - Uses ch-n.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
10 0 ch!  9 1 ch!  2 2 ch!  5 3 ch!  3 4 ch!  7 5 ch!  101 6 ch!  18 7 ch!
8 constant ch-n

\ === paste your solution below this line ===

create ch-dp  ch-max cells allot

: dp@ ( i -- n )  cells ch-dp + @ ;
: dp! ( n i -- )
  { n idx }  idx cells ch-dp +  n swap ! ;

variable lis-best

: lis-len ( -- len )
  ch-n 0= if
    0
  else
    0 lis-best !
    ch-n 0 ?do
      1 i dp!
      0 begin  dup i <
      while
        dup ch@  i ch@  < if
          dup dp@ 1+  i dp@ max  i dp!
        then
        1+
      repeat  drop
      i dp@  lis-best @ max  lis-best !
    loop
    lis-best @
  then ;

\ === paste your solution above this line ===

T{ lis-len -> 4 }T

report bye
