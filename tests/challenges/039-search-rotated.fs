\ tests/challenges/039-search-rotated.fs
\
\ CHALLENGE: Search Rotated Sorted Array
\ Source: leetcode  https://leetcode.com/problems/search-in-rotated-sorted-array/
\ Cognitive: 6/10  |  Pattern: search-rotated-sorted
\
\ Define a word
\
\   : search-rotated  ( key -- idx )
\
\ Return index of key in rotated sorted distinct array.
\ Return -1 if absent.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Modified binary search.
\   - Preloaded rotated array.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
4 0 ch!  5 1 ch!  6 2 ch!  7 3 ch!  0 1 ch!  2 5 ch!
6 constant ch-n

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 0 search-rotated -> 4 }T
T{ 3 search-rotated -> -1 }T
T{ 4 search-rotated -> 5 }T

report bye
