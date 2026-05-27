\ tests/challenges/002-palindrome-num.fs
\
\ CHALLENGE: Palindrome Number
\ Source: leetcode  https://leetcode.com/problems/palindrome-number/
\ Cognitive: 3/10  |  Pattern: palindrome-number-check
\
\ Define a word
\
\   : palindrome-num?  ( n -- flag )
\
\ Return TRUE iff n reads the same forward and backward.
\ Negative numbers are not palindromes.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - No string allocation required.
\   - Return true/false not 1/0.
\
include _tester.fs

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 121 palindrome-num? -> true }T
T{ -121 palindrome-num? -> false }T
T{ 10 palindrome-num? -> false }T
T{ 0 palindrome-num? -> true }T
T{ 1221 palindrome-num? -> true }T

report bye
