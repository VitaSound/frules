\ tests/challenges/105-divide-int.fs
\
\ CHALLENGE: Divide Two Integers
\ Source: leetcode  https://leetcode.com/problems/divide-two-integers/
\ Cognitive: 6/10  |  Pattern: divide-two-integers
\
\ Define a word
\
\   : divide-int  ( a b -- q )
\
\ Return a/b truncated toward zero without using / or mod.
\ Assume b!=0.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Bit shift subtract.
\   - Handle signs.
\
include _tester.fs

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 10 3 divide-int -> 3 }T
T{ -10 3 divide-int -> -3 }T
T{ 7 2 divide-int -> 3 }T
T{ 0 5 divide-int -> 0 }T

report bye
