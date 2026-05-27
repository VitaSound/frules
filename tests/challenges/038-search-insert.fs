\ tests/challenges/038-search-insert.fs
\
\ CHALLENGE: Search Insert Position
\ Source: leetcode  https://leetcode.com/problems/search-insert-position/
\ Cognitive: 3/10  |  Pattern: search-insert-position
\
\ Define a word
\
\   : search-insert  ( key -- idx )
\
\ Return index where key belongs in sorted ch-data[0..ch-n).
\ Equal key returns its index.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Binary search.
\   - Sorted preload.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
1 0 ch!  3 1 ch!  5 2 ch!  6 3 ch!
4 constant ch-n

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 5 search-insert -> 2 }T
T{ 2 search-insert -> 1 }T
T{ 7 search-insert -> 4 }T
T{ 0 search-insert -> 0 }T

report bye
