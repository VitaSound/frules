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

\ === paste your solution above this line ===

T{ max-prod-sub -> 6 }T

report bye
