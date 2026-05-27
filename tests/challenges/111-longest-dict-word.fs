\ tests/challenges/111-longest-dict-word.fs
\
\ CHALLENGE: Longest Dictionary Word
\ Source: leetcode  https://leetcode.com/problems/longest-word-in-dictionary/
\ Cognitive: 5/10  |  Pattern: longest-word-in-dictionary
\
\ Define a word
\
\   : longest-dict  ( c-addr u -- len )
\
\ Return length of longest word from dictionary buildable by adding one char at a time.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Trie + BFS/DFS.
\   - Dictionary preloaded.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
create ch-buf 64 chars allot

: ch-setup  ( c-addr u -- ch-buf u )
  dup >r  ch-buf swap  move  ch-buf r> ;
s" w" ch-setup dict-add drop
s" wo" ch-setup dict-add drop
s" wor" ch-setup dict-add drop
s" worl" ch-setup dict-add drop
s" world" ch-setup dict-add drop

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ s" w" ch-setup longest-dict -> 3 }T

report bye
