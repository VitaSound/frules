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
\   - a-setup / b-setup for two operand copies.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
create a-buf 64 chars allot
create b-buf 64 chars allot

: a-setup  ( c-addr u -- a-buf u )
  dup >r  a-buf swap  move  a-buf r> ;

: b-setup  ( c-addr u -- b-buf u )
  dup >r  b-buf swap  move  b-buf r> ;

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ s" anagram" a-setup s" nagaram" b-setup anagram? -> true }T
T{ s" rat" a-setup s" car" b-setup anagram? -> false }T
T{ s" a" a-setup s" a" b-setup anagram? -> true }T
T{ s" ab" a-setup s" ba" b-setup anagram? -> true }T

report bye
