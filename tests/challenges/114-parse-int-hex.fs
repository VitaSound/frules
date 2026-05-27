\ tests/challenges/114-parse-int-hex.fs
\
\ CHALLENGE: Parse Hex
\ Source: kata  https://www.codewars.com/kata/hex-to-decimal
\ Cognitive: 5/10  |  Pattern: parse-hex-literal
\
\ Define a word
\
\   : parse-hex  ( c-addr u -- n )
\
\ Parse 0x-prefixed or plain hex string to integer.
\ Lowercase hex digits.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Digit parser loop.
\   - Use ch-setup.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
create ch-buf 64 chars allot

: ch-setup  ( c-addr u -- ch-buf u )
  dup >r  ch-buf swap  move  ch-buf r> ;

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ s" ff" ch-setup parse-hex -> 255 }T
T{ s" 2a" ch-setup parse-hex -> 42 }T
T{ s" 0" ch-setup parse-hex -> 0 }T

report bye
