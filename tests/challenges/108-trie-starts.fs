\ tests/challenges/108-trie-starts.fs
\
\ CHALLENGE: Trie Starts With
\ Source: leetcode  https://leetcode.com/problems/implement-trie-prefix-tree/
\ Cognitive: 5/10  |  Pattern: trie-starts-with
\
\ Define a word
\
\   : trie-starts?  ( c-addr u -- flag )
\
\ Return TRUE if any inserted key has given prefix.
\ Requires prior inserts in test.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Prefix walk.
\   - Use ch-setup.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
create ch-buf 64 chars allot

: ch-setup  ( c-addr u -- ch-buf u )
  dup >r  ch-buf swap  move  ch-buf r> ;
s" apple" ch-setup trie-insert drop

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ s" app" ch-setup trie-starts? -> true }T
T{ s" b" ch-setup trie-starts? -> false }T

report bye
