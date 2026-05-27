\ tests/challenges/083-top-k-frequent.fs
\
\ CHALLENGE: Top K Frequent
\ Source: leetcode  https://leetcode.com/problems/top-k-frequent-elements/
\ Cognitive: 6/10  |  Pattern: top-k-frequent-element
\
\ Define a word
\
\   : top-k-freq  ( k -- n )
\
\ Return most frequent element among top-k (benchmark returns single mode for k=1).
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Count then select.
\   - k on stack.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
1 0 ch!  1 1 ch!  1 2 ch!  2 3 ch!  2 4 ch!  2 5 ch!
6 constant ch-n

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 1 top-k-freq -> 1 }T

report bye
