\ tests/challenges/026-three-sum-count.fs
\
\ CHALLENGE: Three Sum Count
\ Source: leetcode  https://leetcode.com/problems/3sum/
\ Cognitive: 6/10  |  Pattern: three-sum-triplet-count
\
\ Define a word
\
\   : three-sum-count  ( target -- count )
\
\ Count unique triplets in ch-data summing to target.
\ Each index used at most once per triplet.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Sort then two-pointer.
\   - Uses preloaded array.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
-1 0 ch!  0 1 ch!  1 2 ch!
3 constant ch-n

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 0 three-sum-count -> 1 }T

report bye
