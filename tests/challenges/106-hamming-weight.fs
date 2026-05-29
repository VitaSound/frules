\ tests/challenges/106-hamming-weight.fs
\
\ CHALLENGE: Hamming Weight
\ Source: rosetta  https://rosettacode.org/wiki/Hamming_weight
\ Cognitive: 3/10  |  Pattern: hamming-weight-popcount
\
\ Define a word
\
\   : hamming  ( n -- w )
\
\ Return count of set bits (same as popcount).
\ Rosetta variant name.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Use bit operations.
\   - Non-negative.
\
include _tester.fs

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 0 hamming -> 0 }T
T{ 106 hamming -> 4 }T
T{ 255 hamming -> 8 }T
T{ 13 hamming -> 3 }T

report bye
