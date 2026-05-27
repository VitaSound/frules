\ tests/challenges/095-longest-unique.fs
\
\ CHALLENGE: Longest Unique Substring
\ Source: leetcode  https://leetcode.com/problems/longest-substring-without-repeating-characters/
\ Cognitive: 5/10  |  Pattern: longest-substring-without-repeating
\
\ Define a word
\
\   : longest-unique  ( c-addr u -- len )
\
\ Return length of longest substring without repeating characters.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Sliding window with map.
\   - Use ch-setup.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
create ch-buf 64 chars allot

: ch-setup  ( c-addr u -- ch-buf u )
  dup >r  ch-buf swap  move  ch-buf r> ;

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ s" abcabcbb" ch-setup longest-unique -> 3 }T
T{ s" bbbbb" ch-setup longest-unique -> 1 }T
T{ s" pwwkew" ch-setup longest-unique -> 3 }T
T{ s" " ch-setup longest-unique -> 0 }T

report bye
