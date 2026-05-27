\ tests/challenges/001-reverse-int.fs
\
\ CHALLENGE: Reverse Integer
\ Source: leetcode  https://leetcode.com/problems/reverse-integer/
\ Cognitive: 3/10  |  Pattern: reverse-signed-digits
\
\ Define a word
\
\   : reverse-int  ( n -- n' )
\
\ Reverse signed cell digits; return 0 if reversed value exceeds 32-bit signed range.
\ Negative sign preserved.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Use arithmetic, not string conversion.
\   - Document stack effect on every helper.
\
include _tester.fs

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 123 reverse-int -> 321 }T
T{ -120 reverse-int -> -21 }T
T{ 1530 reverse-int -> 351 }T
T{ 0 reverse-int -> 0 }T
T{ 1000000003 reverse-int -> 0 }T

report bye
