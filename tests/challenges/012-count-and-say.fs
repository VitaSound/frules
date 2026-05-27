\ tests/challenges/012-count-and-say.fs
\
\ CHALLENGE: Count and Say Next
\ Source: leetcode  https://leetcode.com/problems/count-and-say/
\ Cognitive: 6/10  |  Pattern: count-and-say-next
\
\ Define a word
\
\   : count-say  ( c-addr u -- c-addr2 u2 )
\
\ Transform run-length string to next term (1->11, 11->21).
\ Return result in ch-buf as counted string.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Factor digit-run encoder.
\   - Result valid until next call.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
create ch-buf 64 chars allot

: ch-setup  ( c-addr u -- ch-buf u )
  dup >r  ch-buf swap  move  ch-buf r> ;

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ s" 1" ch-setup count-say s" 11" expect-str-eq -> }T
T{ s" 11" ch-setup count-say s" 21" expect-str-eq -> }T
T{ s" 21" ch-setup count-say s" 1211" expect-str-eq -> }T

report bye
