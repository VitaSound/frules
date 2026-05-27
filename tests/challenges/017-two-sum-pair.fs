\ tests/challenges/017-two-sum-pair.fs
\
\ CHALLENGE: Two Sum Pair
\ Source: leetcode  https://leetcode.com/problems/two-sum/
\ Cognitive: 3/10  |  Pattern: two-sum-pair-exists
\
\ Define a word
\
\   : two-sum?  ( target a b -- flag )
\
\ Return TRUE if a+b equals target.
\ Exactly two values on stack.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - One comparison after add.
\   - Return true/false.
\
include _tester.fs

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 9 2 7 two-sum? -> true }T
T{ 9 2 6 two-sum? -> false }T
T{ 0 5 -5 two-sum? -> true }T
T{ 15 10 5 two-sum? -> true }T

report bye
