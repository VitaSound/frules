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

\ === paste your solution above this line ===

T{ lis-len -> 4 }T

report bye
