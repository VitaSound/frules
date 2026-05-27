\ tests/challenges/061-climb-stairs.fs
\
\ CHALLENGE: Climbing Stairs
\ Source: leetcode  https://leetcode.com/problems/climbing-stairs/
\ Cognitive: 4/10  |  Pattern: climbing-stairs-count
\
\ Define a word
\
\   : climb  ( n -- ways )
\
\ Return number of distinct ways to climb n steps taking 1 or 2.
\ n<=20 in tests.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Fibonacci DP.
\   - Iterative.
\
include _tester.fs

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 2 climb -> 2 }T
T{ 3 climb -> 3 }T
T{ 5 climb -> 8 }T
T{ 1 climb -> 1 }T

report bye
