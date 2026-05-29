\ tests/challenges/064-max-prod-sub.fs
\
\ CHALLENGE: Maximum Product Subarray
\ Source: leetcode  https://leetcode.com/problems/maximum-product-subarray/
\ Cognitive: 6/10  |  Pattern: maximum-product-subarray
\
\ Define a word
\
\   : max-prod-sub  ( -- prod )
\
\ Return maximum product of contiguous subarray in ch-data.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Track min and max DP.
\   - Handles negatives.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
2 0 ch!  3 1 ch!  -2 2 ch!  4 3 ch!
4 constant ch-n

\ === paste your solution below this line ===

variable cur-max
variable cur-min
variable ch-best

: max-prod-sub ( -- prod )
  ch-n 0= if
    0
  else
    0 ch@ dup dup cur-max ! cur-min ! ch-best !
    ch-n 1 ?do
      i ch@ dup 0< if
        cur-max @ cur-min @ swap cur-max ! cur-min !
      then drop
      i ch@ dup cur-max @ * swap max cur-max !
      i ch@ dup cur-min @ * swap min cur-min !
      cur-max @ ch-best @ max ch-best !
    loop
    ch-best @
  then ;

\ === paste your solution above this line ===

T{ max-prod-sub -> 6 }T

report bye
