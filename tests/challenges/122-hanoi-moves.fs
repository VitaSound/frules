\ tests/challenges/122-hanoi-moves.fs
\
\ CHALLENGE: Tower of Hanoi
\ Source: rosetta  https://rosettacode.org/wiki/Tower_of_Hanoi
\ Cognitive: 4/10  |  Pattern: tower-of-hanoi-moves
\
\ Define a word
\
\   : hanoi  ( n -- moves )
\
\ Return minimum moves to solve n-disk Tower of Hanoi.
\ Classic recurrence 2^n-1.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Recursive formula.
\   - n>=0.
\
include _tester.fs

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 0 hanoi -> 0 }T
T{ 1 hanoi -> 1 }T
T{ 3 hanoi -> 7 }T
T{ 4 hanoi -> 15 }T
T{ 10 hanoi -> 1023 }T

report bye
