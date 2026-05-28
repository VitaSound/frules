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

create counts 26 cells allot

: counts-clear ( -- )  26 cells counts 0 fill ;

: count+ ( ch -- )  [char] a -  cells counts +  1 swap  dup @ +  swap ! ;

: count- ( ch -- )  [char] a -  cells counts +  1 swap  dup @ +  swap ! ;

: counts-zero? ( -- flag )
  26 0 ?do  i cells counts + @ 0<> if  0 unloop unloop exit  then  loop  -1 ;

: anagram? ( a-addr au b-addr bu -- flag )
  { a au b bu }
  au bu <> if  0  else
    counts-clear
    au 0 ?do  a i + c@ count+  loop
    bu 0 ?do  b i + c@ [char] a -  cells counts +  1 swap  dup @ 1-  swap !  loop
    counts-zero?
  then ;

: anagram?-stack ( a-addr au b-addr bu -- flag )
  2over <> if  2drop 2drop 0  else
    counts-clear
    2dup 0 ?do  2dup i + c@ count+  loop  drop
    0 ?do  2over i + c@ [char] a -  cells counts +  dup @ 1-  swap !  loop  drop
    counts-zero?
  then ;

\ === paste your solution above this line ===

T{ s" anagram" a-setup s" nagaram" b-setup anagram? -> true }T
T{ s" rat" a-setup s" car" b-setup anagram? -> false }T
T{ s" a" a-setup s" a" b-setup anagram? -> true }T
T{ s" ab" a-setup s" ba" b-setup anagram? -> true }T

T{ s" anagram" a-setup s" nagaram" b-setup anagram?-stack -> true }T
T{ s" rat" a-setup s" car" b-setup anagram?-stack -> false }T
T{ s" a" a-setup s" a" b-setup anagram?-stack -> true }T
T{ s" ab" a-setup s" ba" b-setup anagram?-stack -> true }T

report bye
