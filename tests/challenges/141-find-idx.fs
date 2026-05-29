\ tests/challenges/141-find-idx.fs
\
\ CHALLENGE: Find Index in Sorted Array
\ Source: rosetta  https://rosettacode.org/wiki/Binary_search
\ Cognitive: 3/10  |  Pattern: sorted-array-find-index
\
\ Define a word
\
\   : find-idx  ( key -- idx|-1 )
\
\ Return index i in ch-data[0..5) where ch-data[i]=key, or -1 if absent.
\ Values are sorted ascending (Rosetta binary-search demo set).
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Linear scan OK for small n.
\   - Use ch@; locals: addr# i cells + @ not i addr# cells + @.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
2 0 ch!  4 1 ch!  6 2 ch!  9 3 ch!  11 4 ch!
5 constant search-n

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 2 find-idx -> 0 }T
T{ 6 find-idx -> 2 }T
T{ 7 find-idx -> -1 }T
T{ 11 find-idx -> 4 }T

report bye
