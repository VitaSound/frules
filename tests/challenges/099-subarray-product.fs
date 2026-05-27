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

\ === paste your solution above this line ===

T{ 100 subarray-prod -> 8 }T
T{ 0 subarray-prod -> 0 }T

report bye
