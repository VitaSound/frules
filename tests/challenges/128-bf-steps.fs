\ tests/challenges/128-bf-steps.fs
\
\ CHALLENGE: Brainfuck Steps
\ Source: codewars  https://www.codewars.com/kata/526156943dfe7ce06200063e
\ Cognitive: 7/10  |  Pattern: brainfuck-step-count
\
\ Define a word
\
\   : bf-steps  ( c-addr u -- steps )
\
\ Run Brainfuck program until halt; return instruction steps executed.
\ Tape size 30000; input empty.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Interpreter loop.
\   - Use ch-setup for program.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
create ch-buf 64 chars allot

: ch-setup  ( c-addr u -- ch-buf u )
  dup >r  ch-buf swap  move  ch-buf r> ;
s" +." ch-setup bf-steps -> 2

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ s" +++" ch-setup bf-steps -> 3 }T
T{ s" [.-]" ch-setup bf-steps -> 0 }T

report bye
