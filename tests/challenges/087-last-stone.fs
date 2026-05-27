\ tests/challenges/087-last-stone.fs
\
\ CHALLENGE: Last Stone Weight
\ Source: codewars  https://www.codewars.com/kata/last-stone-weight
\ Cognitive: 5/10  |  Pattern: last-stone-weight
\
\ Define a word
\
\   : last-stone  ( -- n )
\
\ Repeatedly smash two largest stones; return last weight or 0.
\ Use ch-data as heap array.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Simulate with sorted pass.
\   - Preload stones.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
2 0 ch!  7 1 ch!  4 3 ch!  1 4 ch!  8 5 ch!
6 constant ch-n

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ last-stone -> 1 }T

report bye
