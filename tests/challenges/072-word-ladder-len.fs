\ tests/challenges/072-word-ladder-len.fs
\
\ CHALLENGE: Word Ladder Length
\ Source: leetcode  https://leetcode.com/problems/word-ladder/
\ Cognitive: 9/10  |  Pattern: word-ladder-length
\
\ Define a word
\
\   : ladder-len  ( -- len )
\
\ Return shortest transformation length from ch-start to ch-end using ch-wordlist.
\ One letter change per step.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - BFS on implicit graph.
\   - Preload start/end strings.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
create ch-buf 64 chars allot

: ch-setup  ( c-addr u -- ch-buf u )
  dup >r  ch-buf swap  move  ch-buf r> ;
s" hit" ch-setup drop constant ch-start
s" cog" ch-setup drop constant ch-end
s" hot dot dog lot log cog" ch-setup drop

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ ladder-len -> 5 }T

report bye
