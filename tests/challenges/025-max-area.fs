\ tests/challenges/025-max-area.fs
\
\ CHALLENGE: Container With Most Water
\ Source: leetcode  https://leetcode.com/problems/container-with-most-water/
\ Cognitive: 5/10  |  Pattern: container-max-water
\
\ Define a word
\
\   : max-area  ( h1 h2 w -- area )
\
\ Given two heights and width between them, return min(h1,h2)*w.
\ Benchmark uses scalar heights on stack.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - No nested loops required for single-width case.
\   - Keep stack <= 4.
\
include _tester.fs

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 1 2 3 max-area -> 3 }T
T{ 4 3 5 max-area -> 15 }T
T{ 7 7 10 max-area -> 70 }T
T{ 1 8 6 max-area -> 6 }T

report bye
