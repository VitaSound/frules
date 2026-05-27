\ tests/challenges/119-combo-sum.fs
\
\ CHALLENGE: Combination Sum Exists
\ Source: leetcode  https://leetcode.com/problems/combination-sum/
\ Cognitive: 6/10  |  Pattern: combination-sum-exists
\
\ Define a word
\
\   : combo-sum?  ( target -- flag )
\
\ Return TRUE if some multiset from ch-data sums to target.
\ Reuse elements allowed.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Backtracking.
\   - Uses preloaded candidates.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
2 0 ch!  3 1 ch!  6 2 ch!  7 3 ch!
4 constant ch-n

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 7 combo-sum? -> true }T
T{ 2 combo-sum? -> false }T

report bye
