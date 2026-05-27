\ tests/challenges/109-word-dict.fs
\
\ CHALLENGE: Word Dictionary
\ Source: leetcode  https://leetcode.com/problems/add-and-search-word-data-structure-design/
\ Cognitive: 6/10  |  Pattern: add-and-search-word-dictionary
\
\ Define a word
\
\   : word-dict?  ( c-addr u -- flag )
\
\ Return TRUE if word exists allowing '.' wildcard.
\ Trie with wildcard search.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - DFS on trie.
\   - Preload dictionary.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
create ch-buf 64 chars allot

: ch-setup  ( c-addr u -- ch-buf u )
  dup >r  ch-buf swap  move  ch-buf r> ;
s" bad" ch-setup dict-add drop
s" dad" ch-setup dict-add drop
s" mad" ch-setup dict-add drop

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ s" bad" ch-setup word-dict? -> true }T
T{ s" b.d" ch-setup word-dict? -> true }T
T{ s" b.dz" ch-setup word-dict? -> false }T

report bye
