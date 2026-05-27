\ tests/challenges/107-trie-insert.fs
\
\ CHALLENGE: Trie Insert
\ Source: leetcode  https://leetcode.com/problems/implement-trie-prefix-tree/
\ Cognitive: 6/10  |  Pattern: implement-trie-insert
\
\ Define a word
\
\   : trie-insert  ( c-addr u -- )
\
\ Insert counted string into internal trie.
\ Companion trie-search? returns flag.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Node array trie.
\   - Use ch-setup in tests.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
create ch-buf 64 chars allot

: ch-setup  ( c-addr u -- ch-buf u )
  dup >r  ch-buf swap  move  ch-buf r> ;

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ s" apple" ch-setup trie-insert s" apple" ch-setup trie-search? -> true }T
T{ s" app" ch-setup trie-search? -> false }T

report bye
