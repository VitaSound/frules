\ tests/challenges/113-score-parens.fs
\
\ CHALLENGE: Score of Parentheses
\ Source: leetcode  https://leetcode.com/problems/score-of-parentheses/
\ Cognitive: 5/10  |  Pattern: score-of-parentheses
\
\ Define a word
\
\   : score-parens  ( c-addr u -- n )
\
\ Return score: ()=1, AB=A+B, (A)=2*A for balanced parens only.
\ Differs from validation seed.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Stack accumulation.
\   - Use ch-setup.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
create ch-buf 64 chars allot

: ch-setup  ( c-addr u -- ch-buf u )
  dup >r  ch-buf swap  move  ch-buf r> ;

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ s" ()" ch-setup score-parens -> 1 }T
T{ s" (())" ch-setup score-parens -> 2 }T
T{ s" ()()" ch-setup score-parens -> 2 }T
T{ s" (()(()))" ch-setup score-parens -> 6 }T

report bye
