\ tests/challenges/035-daily-temp.fs
\
\ CHALLENGE: Daily Temperatures
\ Source: leetcode  https://leetcode.com/problems/daily-temperatures/
\ Cognitive: 6/10  |  Pattern: daily-temperatures-span
\
\ Define a word
\
\   : daily-temp  ( -- )
\
\ Fill ch-out[i] with days until warmer temperature after day i.
\ Last days get 0.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Monotonic stack.
\   - Preload temps in ch-data, ch-out same size.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
73 0 ch!  74 1 ch!  75 2 ch!  71 3 ch!  69 4 ch!  72 5 ch!  76 6 ch!  73 7 ch!
8 constant ch-n
create ch-out 16 cells allot
: ch-out@ ( i -- n ) cells ch-out + @ ;
: ch-out! ( n i -- ) cells ch-out + ! ;

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ daily-temp }T
T{ ch-out@ 1 -> 1 }T
T{ ch-out@ 4 -> 0 }T

report bye
