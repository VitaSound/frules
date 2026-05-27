\ tests/challenges/018-remove-dup-sorted.fs
\
\ CHALLENGE: Remove Duplicates Length
\ Source: leetcode  https://leetcode.com/problems/remove-duplicates-from-sorted-array/
\ Cognitive: 4/10  |  Pattern: remove-duplicates-sorted-len
\
\ Define a word
\
\   : dedup-len  ( -- len )
\
\ Array ch@/ch! length ch-n sorted non-decreasing.
\ Return new length with unique values kept at front.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - In-place overwrite; no second array.
\   - Use preloaded sorted array.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
1 0 ch!  1 1 ch!  2 2 ch!  3 3 ch!  3 4 ch!
5 constant ch-n

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ dedup-len -> 4 }T
T{ ch@ 0 -> 1 }T
T{ ch@ 3 -> 3 }T

report bye
