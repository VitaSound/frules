\ tests/challenges/129-count-words.fs
\
\ CHALLENGE: Word Count
\ Source: codewars  https://www.codewars.com/kata/515c4fe1ff9373f4b000058a
\ Cognitive: 3/10  |  Pattern: token-count-whitespace
\
\ Define a word
\
\   : word-count  ( c-addr u -- n )
\
\ Count whitespace-separated tokens in buffer.
\ Multiple spaces collapse.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Single pass.
\   - Use ch-setup.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
create ch-buf 64 chars allot

: ch-setup  ( c-addr u -- ch-buf u )
  dup >r  ch-buf swap  move  ch-buf r> ;

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ s" one two three" ch-setup word-count -> 3 }T
T{ s"  a  b " ch-setup word-count -> 2 }T
T{ s" " ch-setup word-count -> 0 }T
T{ s" x" ch-setup word-count -> 1 }T

report bye
