\ tests/challenges/015-longest-pal-sub.fs
\
\ CHALLENGE: Longest Palindrome Length
\ Source: leetcode  https://leetcode.com/problems/longest-palindromic-substring/
\ Cognitive: 6/10  |  Pattern: longest-palindrome-substring-len
\
\ Define a word
\
\   : longest-pal-len  ( c-addr u -- len )
\
\ Return length of longest palindromic substring.
\ Single char counts as length 1.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Expand-around-center or DP.
\   - Use ch-setup.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
create ch-buf 64 chars allot

: ch-setup  ( c-addr u -- ch-buf u )
  dup >r  ch-buf swap  move  ch-buf r> ;

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ s" babad" ch-setup longest-pal-len -> 3 }T
T{ s" cbbd" ch-setup longest-pal-len -> 2 }T
T{ s" a" ch-setup longest-pal-len -> 1 }T
T{ s" racecar" ch-setup longest-pal-len -> 7 }T

report bye
