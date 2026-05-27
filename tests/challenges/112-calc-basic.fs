\ tests/challenges/112-calc-basic.fs
\
\ CHALLENGE: Basic Calculator II
\ Source: leetcode  https://leetcode.com/problems/basic-calculator-ii/
\ Cognitive: 6/10  |  Pattern: basic-calculator-ii
\
\ Define a word
\
\   : calc-basic  ( c-addr u -- n )
\
\ Evaluate string expression with + - * / on non-negative integers.
\ Spaces optional.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Stack or linear scan.
\   - Use ch-setup.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
create ch-buf 64 chars allot

: ch-setup  ( c-addr u -- ch-buf u )
  dup >r  ch-buf swap  move  ch-buf r> ;

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ s" 3+2*2" ch-setup calc-basic -> 7 }T
T{ s" 3/2" ch-setup calc-basic -> 1 }T
T{ s" 2+3*4" ch-setup calc-basic -> 14 }T

report bye
