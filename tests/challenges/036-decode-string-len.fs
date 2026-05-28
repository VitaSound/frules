\ tests/challenges/036-decode-string-len.fs
\
\ CHALLENGE: Decode String Length
\ Source: leetcode  https://leetcode.com/problems/decode-string/
\ Cognitive: 7/10  |  Pattern: decode-string-length
\
\ Define a word
\
\   : decode-len  ( c-addr u -- len )
\
\ Return length of decoded k[encoded] pattern (digits and letters only).
\ Do not materialize full string.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Use count stack.
\   - Use ch-setup.
\
\ Fixed: expected length is 12 (abc + cd×3 + xyz), not 9.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
create ch-buf 64 chars allot

: ch-setup  ( c-addr u -- ch-buf u )
  dup >r  ch-buf swap  move  ch-buf r> ;

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ s" 3[a]2[bc]" ch-setup decode-len -> 7 }T
T{ s" abc3[cd]xyz" ch-setup decode-len -> 12 }T
T{ s" a" ch-setup decode-len -> 1 }T

report bye
