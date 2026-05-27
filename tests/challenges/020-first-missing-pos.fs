\ tests/challenges/020-first-missing-pos.fs
\
\ CHALLENGE: First Missing Positive
\ Source: leetcode  https://leetcode.com/problems/first-missing-positive/
\ Cognitive: 6/10  |  Pattern: first-missing-positive
\
\ Define a word
\
\   : first-missing  ( -- n )
\
\ Return smallest positive integer absent from ch-data.
\ Array length ch-n; values may repeat.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - O(n) preferred for small n.
\   - Uses ch-n preloaded array.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
3 0 ch!  4 1 ch!  -1 2 ch!  1 3 ch!
4 constant ch-n

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ first-missing -> 2 }T

report bye
