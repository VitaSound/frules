\ tests/challenges/145-arr-sum.fs
\
\ CHALLENGE: Array Prefix Sum
\ Source: rosetta  https://rosettacode.org/wiki/Collections
\ Cognitive: 3/10  |  Pattern: cell-array-prefix-sum
\
\ Define a word
\
\   : arr-sum  ( u -- sum )
\
\ Return sum of ch-data[0] .. ch-data[u-1] (Rosetta fixed-array idiom).
\ u=0 returns 0. Use ch@ from scaffold.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Simple loop 0 .. u-1.
\   - Collections substitute — no ffl/car.fs.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
10 0 ch!  20 1 ch!  30 2 ch!

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 3 arr-sum -> 60 }T
T{ 0 arr-sum -> 0 }T
T{ 1 arr-sum -> 10 }T

report bye
