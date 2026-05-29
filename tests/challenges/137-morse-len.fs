\ tests/challenges/137-morse-len.fs
\
\ CHALLENGE: Morse Decode Len
\ Source: codewars  https://www.codewars.com/kata/5262119038c0985a5b00029
\ Cognitive: 5/10  |  Pattern: morse-decode-length
\
\ Define a word
\
\   : morse-len  ( c-addr u -- n )
\
\ Return length of decoded message from morse string (space-separated codes).
\ Invalid -> 0.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Table lookup.
\   - Use ch-setup.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
create ch-buf 64 chars allot

: ch-setup  ( c-addr u -- ch-buf u )
  dup >r  ch-buf swap  move  ch-buf r> ;

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ s" .... . -.-- . .-. .." ch-setup morse-len -> 6 }T
T{ s" -.... . .-.. .-.. --- .--." ch-setup morse-len -> 6 }T

report bye
