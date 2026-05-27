\ tests/challenges/130-union-find.fs
\
\ CHALLENGE: Union Find Root
\ Source: leetcode  https://leetcode.com/problems/redundant-connection/
\ Cognitive: 6/10  |  Pattern: union-find-path-compress
\
\ Define a word
\
\   : uf-find  ( i -- root )
\
\ Return root of set containing i using parent[] in ch-data with path compression.
\ 1-indexed nodes.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Union in scaffold init.
\   - uf-find only for tests.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
2 1 ch!  3 1 ch!  4 4 ch!  5 4 ch!
5 constant ch-n

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 3 uf-find -> 1 }T
T{ 4 uf-find -> 4 }T
T{ 5 uf-find -> 4 }T

report bye
