\ tests/challenges/013-strstr.fs
\
\ CHALLENGE: Find Needle Index
\ Source: leetcode  https://leetcode.com/problems/find-the-index-of-the-first-occurrence-in-a-string/
\ Cognitive: 4/10  |  Pattern: substring-first-index
\
\ Define a word
\
\   : strstr-idx  ( h-addr hu n-addr nu -- idx )
\
\ Return 0-based index of first occurrence of needle in haystack.
\ Return -1 if absent.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Naive scan acceptable.
\   - Both strings via ch-setup copies.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
create ch-buf 64 chars allot

: ch-setup  ( c-addr u -- ch-buf u )
  dup >r  ch-buf swap  move  ch-buf r> ;

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ s" hello" ch-setup s" ll" ch-setup strstr-idx -> 2 }T
T{ s" hello" ch-setup s" z" ch-setup strstr-idx -> -1 }T
T{ s" aa" ch-setup s" a" ch-setup strstr-idx -> 0 }T
T{ s" abc" ch-setup s" bc" ch-setup strstr-idx -> 1 }T

report bye
