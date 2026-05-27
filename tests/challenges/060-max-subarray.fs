\ tests/challenges/060-max-subarray.fs
\
\ CHALLENGE: Maximum Subarray
\ Source: leetcode  https://leetcode.com/problems/maximum-subarray/
\ Cognitive: 5/10  |  Pattern: maximum-subarray-kadane
\
\ Define a word
\
\   : max-subarray  ( -- sum )
\
\ Return maximum contiguous subarray sum in ch-data.
\ At least one element.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Kadane algorithm.
\   - Uses ch-n preload.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
-2 0 ch!  1 1 ch!  -3 2 ch!  4 3 ch!  -1 4 ch!  2 5 ch!  1 6 ch!  -5 7 ch!
8 constant ch-n

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ max-subarray -> 6 }T

report bye
