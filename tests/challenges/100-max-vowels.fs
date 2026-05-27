\ tests/challenges/100-max-vowels.fs
\
\ CHALLENGE: Maximum Vowels Substring
\ Source: leetcode  https://leetcode.com/problems/maximum-number-of-vowels-in-a-substring-of-given-length/
\ Cognitive: 4/10  |  Pattern: maximum-vowels-substring
\
\ Define a word
\
\   : max-vowels  ( k -- len )
\
\ Return max vowels in any length-k substring of preloaded string ch-text.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Fixed-size sliding window.
\   - k on stack.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
create ch-buf 64 chars allot

: ch-setup  ( c-addr u -- ch-buf u )
  dup >r  ch-buf swap  move  ch-buf r> ;
s" abciiidef" ch-setup drop
9 constant ch-text-len

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 3 max-vowels -> 3 }T
T{ 2 max-vowels -> 2 }T

report bye
