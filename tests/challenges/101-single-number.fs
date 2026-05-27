\ tests/challenges/101-single-number.fs
\
\ CHALLENGE: Single Number
\ Source: leetcode  https://leetcode.com/problems/single-number/
\ Cognitive: 3/10  |  Pattern: single-number-xor
\
\ Define a word
\
\   : single  ( a b c -- n )
\
\ Return element that appears once when others appear twice.
\ Three values on stack for benchmark.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - XOR all values.
\   - Scalar demo of pattern.
\
include _tester.fs

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 2 2 1 single -> 1 }T
T{ 4 1 4 single -> 1 }T
T{ 7 3 3 single -> 7 }T

report bye
