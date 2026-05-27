\ tests/challenges/082-kth-largest.fs
\
\ CHALLENGE: Kth Largest
\ Source: leetcode  https://leetcode.com/problems/kth-largest-element-in-an-array/
\ Cognitive: 5/10  |  Pattern: kth-largest-element
\
\ Define a word
\
\   : kth-largest  ( k -- n )
\
\ Return kth largest element in unsorted ch-data.
\ 1-indexed k.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Quickselect or heap.
\   - Uses ch-n preload.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
3 0 ch!  2 1 ch!  1 2 ch!  5 3 ch!  6 4 ch!  4 5 ch!
6 constant ch-n

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 2 kth-largest -> 5 }T
T{ 4 kth-largest -> 4 }T

report bye
