\ tests/challenges/139-sorted-median.fs
\
\ CHALLENGE: Median of Sorted Array
\ Source: leetcode  https://leetcode.com/problems/median-of-two-sorted-arrays/
\ Cognitive: 7/10  |  Pattern: median-sorted-array
\
\ Define a word
\
\   : sorted-median  ( -- med )
\
\ Return median of sorted values in ch-data[0..ch-n).
\ Even n: lower-middle element for benchmark.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Binary search or index math.
\   - Small n.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
1 0 ch!  2 1 ch!  3 2 ch!  4 3 ch!  5 4 ch!  6 5 ch!
6 constant ch-n

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ sorted-median -> 3 }T

report bye
