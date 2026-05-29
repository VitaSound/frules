\ tests/challenges/078-gas-station.fs
\
\ CHALLENGE: Gas Station
\ Source: leetcode  https://leetcode.com/problems/gas-station/
\ Cognitive: 6/10  |  Pattern: gas-station-circuit
\
\ Define a word
\
\   : gas-start  ( -- idx )
\
\ Return starting station index for circuit or -1.
\ gas and cost arrays interleaved in ch-data.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Single pass greedy.
\   - Preload gas/cost pairs.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
1 0 ch!  2 1 ch!  3 2 ch!  4 3 ch!  5 4 ch!  1 5 ch!  2 6 ch!  3 7 ch!  4 8 ch!  5 9 ch!
10 constant ch-n

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ gas-start -> 3 }T

report bye
