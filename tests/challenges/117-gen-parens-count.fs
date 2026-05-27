\ tests/challenges/117-gen-parens-count.fs
\
\ CHALLENGE: Generate Parentheses Count
\ Source: leetcode  https://leetcode.com/problems/generate-parentheses/
\ Cognitive: 5/10  |  Pattern: generate-parentheses-count
\
\ Define a word
\
\   : gen-parens-n  ( n -- count )
\
\ Return number of valid combinations of n pairs of parentheses.
\ Catalan number.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Recursion or DP count only.
\   - Do not enumerate strings.
\
include _tester.fs

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 1 gen-parens-n -> 1 }T
T{ 2 gen-parens-n -> 2 }T
T{ 3 gen-parens-n -> 5 }T
T{ 4 gen-parens-n -> 14 }T

report bye
