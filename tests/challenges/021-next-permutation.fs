\ tests/challenges/021-next-permutation.fs
\
\ CHALLENGE: Next Permutation
\ Source: leetcode  https://leetcode.com/problems/next-permutation/
\ Cognitive: 7/10  |  Pattern: next-permutation-step
\
\ Define a word
\
\   : next-perm?  ( -- flag )
\
\ Transform ch-data[0..ch-n) to next lexicographic permutation in place.
\ Return FALSE if last permutation.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Standard algorithm; mutate ch-data.
\   - Return true/false.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
1 0 ch!  2 1 ch!  3 2 ch!
3 constant ch-n

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ next-perm? -> true }T
T{ ch@ 0 -> 1 }T
T{ ch@ 1 -> 3 }T
T{ ch@ 2 -> 2 }T

report bye
