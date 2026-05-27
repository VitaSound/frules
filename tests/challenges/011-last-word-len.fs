\ tests/challenges/011-last-word-len.fs
\
\ CHALLENGE: Length of Last Word
\ Source: leetcode  https://leetcode.com/problems/length-of-last-word/
\ Cognitive: 3/10  |  Pattern: last-word-length
\
\ Define a word
\
\   : last-word-len  ( c-addr u -- len )
\
\ Return length of last whitespace-delimited word.
\ Trailing spaces may appear.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Treat bl as separator only.
\   - Use ch-setup.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
create ch-buf 64 chars allot

: ch-setup  ( c-addr u -- ch-buf u )
  dup >r  ch-buf swap  move  ch-buf r> ;

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ s" Hello World" ch-setup last-word-len -> 5 }T
T{ s" fly me to the moon " ch-setup last-word-len -> 4 }T
T{ s" a" ch-setup last-word-len -> 1 }T
T{ s" " ch-setup last-word-len -> 0 }T

report bye
