\ tests/challenges/016-valid-anagram.fs
\
\ CHALLENGE: Valid Anagram
\ Source: leetcode  https://leetcode.com/problems/valid-anagram/
\ Cognitive: 3/10  |  Pattern: valid-anagram-check
\
\ Define a word
\
\   : anagram?  ( a-addr au b-addr bu -- flag )
\
\ Return TRUE iff two strings are anagrams (same multiset of chars).
\ Assume lowercase a-z in tests.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - O(n) count table.
\   - Use ch-setup.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
create ch-buf 64 chars allot

: ch-setup  ( c-addr u -- ch-buf u )
  dup >r  ch-buf swap  move  ch-buf r> ;

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ s" anagram" ch-setup s" nagaram" ch-setup anagram? -> true }T
T{ s" rat" ch-setup s" car" ch-setup anagram? -> false }T
T{ s" a" ch-setup s" a" ch-setup anagram? -> true }T
T{ s" ab" ch-setup s" ba" ch-setup anagram? -> true }T

report bye
