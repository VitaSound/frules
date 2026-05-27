\ tests/challenges/062-unique-paths.fs
\
\ CHALLENGE: Unique Paths
\ Source: leetcode  https://leetcode.com/problems/unique-paths/
\ Cognitive: 5/10  |  Pattern: unique-paths-grid
\
\ Define a word
\
\   : unique-paths  ( m n -- count )
\
\ Return paths from top-left to bottom-right moving only right/down in m x n grid.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Combinatorics or DP table.
\   - m,n positive.
\
include _tester.fs

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 3 2 unique-paths -> 3 }T
T{ 3 7 unique-paths -> 28 }T
T{ 1 1 unique-paths -> 1 }T

report bye
