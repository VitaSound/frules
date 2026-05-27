\ tests/challenges/085-k-closest.fs
\
\ CHALLENGE: K Closest Points
\ Source: leetcode  https://leetcode.com/problems/k-closest-points-to-origin/
\ Cognitive: 6/10  |  Pattern: k-closest-points-origin
\
\ Define a word
\
\   : k-closest  ( k -- dist )
\
\ Return squared distance of kth closest point to origin from ch-pairs x,y interleaved.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Partial sort or heap.
\   - k on stack.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
1 0 ch!  3 1 ch!  -2 2 ch!  2 3 ch!
4 constant ch-n

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 1 k-closest -> 2 }T
T{ 2 k-closest -> 5 }T

report bye
