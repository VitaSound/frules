\ tests/challenges/009-longest-common-prefix.fs
\
\ CHALLENGE: Longest Common Prefix Length
\ Source: leetcode  https://leetcode.com/problems/longest-common-prefix/
\ Cognitive: 4/10  |  Pattern: longest-common-prefix-length
\
\ Define a word
\
\   : lcp-len  ( c-addr1 u1 c-addr2 u2 -- len )
\
\ Given two counted strings, return length of longest shared prefix.
\ Empty prefix returns 0.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Use ch-setup for test inputs.
\   - No allocation beyond scaffold buffer.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
create ch-buf 64 chars allot

: ch-setup  ( c-addr u -- ch-buf u )
  dup >r  ch-buf swap  move  ch-buf r> ;

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ s" flower" ch-setup s" flow" ch-setup lcp-len -> 4 }T
T{ s" dog" ch-setup s" cat" ch-setup lcp-len -> 0 }T
T{ s" abc" ch-setup s" abc" ch-setup lcp-len -> 3 }T
T{ s" " ch-setup s" abc" ch-setup lcp-len -> 0 }T

report bye
