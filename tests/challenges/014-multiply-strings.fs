\ tests/challenges/014-multiply-strings.fs
\
\ CHALLENGE: Multiply String Numbers
\ Source: leetcode  https://leetcode.com/problems/multiply-strings/
\ Cognitive: 7/10  |  Pattern: decimal-string-multiply
\
\ Define a word
\
\   : str-mul  ( a-addr au b-addr bu -- c-addr cu )
\
\ Multiply two non-negative decimal digit strings.
\ Return product as counted string in ch-buf.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Grade-school multiply OK.
\   - No ANS numeric conversion of whole string.
\   - a-setup / b-setup for two operand copies; product in ch-buf.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
create a-buf 64 chars allot
create b-buf 64 chars allot
create ch-buf 64 chars allot

: a-setup  ( c-addr u -- a-buf u )
  dup >r  a-buf swap  move  a-buf r> ;

: b-setup  ( c-addr u -- b-buf u )
  dup >r  b-buf swap  move  b-buf r> ;

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ s" 2" a-setup s" 3" b-setup str-mul s" 6" expect-str-eq -> }T
T{ s" 123" a-setup s" 456" b-setup str-mul s" 56088" expect-str-eq -> }T
T{ s" 0" a-setup s" 999" b-setup str-mul s" 0" expect-str-eq -> }T

report bye
