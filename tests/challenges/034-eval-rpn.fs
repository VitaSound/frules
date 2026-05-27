\ tests/challenges/034-eval-rpn.fs
\
\ CHALLENGE: Evaluate RPN
\ Source: leetcode  https://leetcode.com/problems/evaluate-reverse-polish-notation/
\ Cognitive: 6/10  |  Pattern: evaluate-reverse-polish
\
\ Define a word
\
\   : eval-rpn  ( c-addr u -- n )
\
\ Evaluate space-separated RPN expression with + - * / on integers.
\ Division truncates toward zero.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Use value stack.
\   - Use ch-setup for input string.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
create ch-buf 64 chars allot

: ch-setup  ( c-addr u -- ch-buf u )
  dup >r  ch-buf swap  move  ch-buf r> ;

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ s" 2 1 + " ch-setup eval-rpn -> 3 }T
T{ s" 4 13 5 / + " ch-setup eval-rpn -> 6 }T
T{ s" 10 6 9 3 + -11 * + " ch-setup eval-rpn -> 0 }T

report bye
