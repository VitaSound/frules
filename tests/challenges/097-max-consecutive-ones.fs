\ tests/challenges/097-max-consecutive-ones.fs
\
\ CHALLENGE: Max Consecutive Ones
\ Source: leetcode  https://leetcode.com/problems/max-consecutive-ones-iii/
\ Cognitive: 5/10  |  Pattern: max-consecutive-ones-iii
\
\ Define a word
\
\   : max-ones  ( k -- len )
\
\ Return longest subarray of 1s after flipping at most k zeros in ch-data.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Sliding window.
\   - k on stack.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
1 0 ch!  1 1 ch!  0 2 ch!  1 3 ch!  1 4 ch!  0 5 ch!  1 6 ch!  1 7 ch!  1 8 ch!  0 9 ch!
10 constant ch-n

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 1 max-ones -> 6 }T
T{ 2 max-ones -> 10 }T

report bye
