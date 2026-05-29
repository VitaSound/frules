\ tests/challenges/086-find-k-pairs.fs
\
\ CHALLENGE: K Pairs Smallest
\ Source: leetcode  https://leetcode.com/problems/find-k-pairs-with-smallest-sums/
\ Cognitive: 7/10  |  Pattern: find-k-pairs-with-smallest-sums
\
\ Define a word
\
\   : k-pairs-sum  ( k -- sum )
\
\ Return sum of kth smallest pair from two sorted arrays in ch-a/ch-b segments.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Heap merge.
\   - Preload arrays.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
1 0 ch!  1 1 ch!  3 2 ch!  3 3 ch!  4 4 ch!
5 constant ch-n
3 constant ch-a-len

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 2 k-pairs-sum -> 4 }T

report bye
