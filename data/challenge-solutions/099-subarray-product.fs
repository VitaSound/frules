\ tests/challenges/099-subarray-product.fs
\
\ CHALLENGE: Subarray Product Less Than K
\ Source: leetcode  https://leetcode.com/problems/subarray-product-less-than-k/
\ Cognitive: 6/10  |  Pattern: subarray-product-less-than-k
\
\ Define a word
\
\   : subarray-prod  ( k -- count )
\
\ Count contiguous subarrays with product strictly less than k.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Sliding window on positives.
\   - k on stack.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
10 0 ch!  5 1 ch!  2 2 ch!  6 3 ch!
4 constant ch-n

\ === paste your solution below this line ===

variable sp-k
variable sp-left
variable sp-prod
variable sp-cnt

: subarray-prod ( k -- len )
  dup 0<= if  drop 0 exit  then
  sp-k !
  1 sp-prod !  0 sp-left !  0 sp-cnt !
  ch-n 0 ?do
    sp-prod @ i ch@ * sp-prod !
    begin  sp-prod @ sp-k @ >=  while
      sp-left @ ch@ sp-prod @ swap / sp-prod !
      sp-left @ 1+ sp-left !
    repeat
    i sp-left @ - 1+ sp-cnt +!
  loop
  sp-cnt @ ;

\ === paste your solution above this line ===

T{ 100 subarray-prod -> 8 }T
T{ 0 subarray-prod -> 0 }T

report bye
