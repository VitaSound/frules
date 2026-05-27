\ tests/challenges/033-valid-brackets.fs
\
\ CHALLENGE: Valid Brackets Mixed
\ Source: leetcode  https://leetcode.com/problems/valid-parentheses/
\ Cognitive: 5/10  |  Pattern: valid-bracket-mixed
\
\ Define a word
\
\   : brackets?  ( c-addr u -- flag )
\
\ Return TRUE iff (), [], {} are properly nested and matched.
\ Differs from round-only seed challenge.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Use a counter/stack for three kinds.
\   - Return true/false.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
create ch-buf 64 chars allot

: ch-setup  ( c-addr u -- ch-buf u )
  dup >r  ch-buf swap  move  ch-buf r> ;

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ s" ()[]{} " ch-setup brackets? -> true }T
T{ s" ([)]" ch-setup brackets? -> false }T
T{ s" {[]}" ch-setup brackets? -> true }T
T{ s" " ch-setup brackets? -> true }T
T{ s" (]" ch-setup brackets? -> false }T

report bye
