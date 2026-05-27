\ tests/challenges/019-remove-element.fs
\
\ CHALLENGE: Remove Element Count
\ Source: leetcode  https://leetcode.com/problems/remove-element/
\ Cognitive: 3/10  |  Pattern: remove-element-count
\
\ Define a word
\
\   : remove-val-len  ( val -- len )
\
\ Remove all cells equal to val from ch-data[0..ch-n).
\ Return new length; order of survivors preserved.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - In-place compaction.
\   - val on stack.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
3 0 ch!  2 1 ch!  2 2 ch!  3 3 ch!
4 constant ch-n

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 3 remove-val-len -> 2 }T
T{ ch@ 0 -> 2 }T
T{ ch@ 1 -> 2 }T

report bye
