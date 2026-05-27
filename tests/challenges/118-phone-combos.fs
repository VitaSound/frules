\ tests/challenges/118-phone-combos.fs
\
\ CHALLENGE: Phone Letter Combos Count
\ Source: leetcode  https://leetcode.com/problems/letter-combinations-of-a-phone-number/
\ Cognitive: 4/10  |  Pattern: letter-combinations-count
\
\ Define a word
\
\   : phone-combos  ( d -- count )
\
\ Return count of letter combinations for phone digit d (2-9).
\ Benchmark scalar: 3->3 letters etc.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Recursion count.
\   - Single digit on stack.
\
include _tester.fs

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 2 phone-combos -> 3 }T
T{ 7 phone-combos -> 4 }T
T{ 9 phone-combos -> 4 }T
T{ 0 phone-combos -> 0 }T

report bye
