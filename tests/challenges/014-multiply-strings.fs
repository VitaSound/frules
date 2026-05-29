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
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
create ch-buf 64 chars allot

: ch-setup  ( c-addr u -- ch-buf u )
  dup >r  ch-buf swap  move  ch-buf r> ;

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ s" 2" ch-setup s" 3" ch-setup str-mul s" 6" expect-str-eq -> }T
T{ s" 123" ch-setup s" 456" ch-setup str-mul s" 56088" expect-str-eq -> }T
T{ s" 0" ch-setup s" 999" ch-setup str-mul s" 0" expect-str-eq -> }T

report bye
