\ tests/challenges/013-strstr.fs
\
\ Fixed: dual ch-setup shared one buffer; use hay-buf / ned-buf.
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
\   - hay-setup / ned-setup for two string copies.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
create hay-buf 64 chars allot
create ned-buf 64 chars allot

: hay-setup  ( c-addr u -- hay-buf u )
  dup >r  hay-buf swap  move  hay-buf r> ;

: ned-setup  ( c-addr u -- ned-buf u )
  dup >r  ned-buf swap  move  ned-buf r> ;

\ === paste your solution below this line ===

: strstr-idx ( h-addr hu n-addr nu -- idx )
  { z0 z1 z2 z3 | z4 z5 }
  z3 0= if  0 exit  then
  z1 z3 < if  -1 exit  then
  -1 to z5
  z1 z3 - 1+ 0 ?do
    i z0 + z3 z2 z3 compare 0= if
      i to z5  leave
    then
  loop
  z5 ;

\ === paste your solution above this line ===

T{ s" hello" hay-setup s" ll" ned-setup strstr-idx -> 2 }T
T{ s" hello" hay-setup s" z" ned-setup strstr-idx -> -1 }T
T{ s" aa" hay-setup s" a" ned-setup strstr-idx -> 0 }T
T{ s" abc" hay-setup s" bc" ned-setup strstr-idx -> 1 }T

report bye
