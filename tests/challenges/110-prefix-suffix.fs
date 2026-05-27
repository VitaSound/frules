\ tests/challenges/110-prefix-suffix.fs
\
\ CHALLENGE: Prefix Suffix Search
\ Source: leetcode  https://leetcode.com/problems/prefix-and-suffix-search/
\ Cognitive: 7/10  |  Pattern: prefix-and-suffix-search
\
\ Define a word
\
\   : prefix-suffix?  ( c-addr u -- flag )
\
\ Return TRUE if any word has given prefix and suffix simultaneously.
\ Benchmark boolean variant.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Combined trie or hash.
\   - Use ch-setup.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
create ch-buf 64 chars allot

: ch-setup  ( c-addr u -- ch-buf u )
  dup >r  ch-buf swap  move  ch-buf r> ;
s" apple" ch-setup dict-add drop

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ s" apple" ch-setup prefix-suffix? -> true }T
T{ s" xyz" ch-setup prefix-suffix? -> false }T

report bye
