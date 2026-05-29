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

ch-buf constant ch-text

variable mv-win
variable mv-best
variable mv-k

97 constant vow-a
101 constant vow-e
105 constant vow-i
111 constant vow-o
117 constant vow-u

: vowel?  ( ch -- flag )
  >r
  r@ vow-a =  r@ vow-e =  or  r@ vow-i =  or
  r@ vow-o =  or  r@ vow-u =  or  rdrop ;

: mv-take-best  ( -- )
  mv-win @ mv-best @ 2dup < if  swap  then  drop  mv-best ! ;

: mv-add-char  ( idx -- )
  ch-text + c@ vowel? if  mv-win @ 1+ mv-win !  then ;

: mv-drop-char  ( idx -- )
  ch-text + c@ vowel? if  mv-win @ 1- mv-win !  then ;

: max-vowels  ( k -- max )
  mv-k !
  0 mv-win !  0 mv-best !
  mv-k @ 0 ?do  i mv-add-char  loop
  mv-take-best
  ch-text-len mv-k @ ?do
    i mv-k @ - mv-drop-char
    i mv-add-char
    mv-take-best
  loop
  mv-best @ ;

\ === paste your solution above this line ===

T{ 3 max-vowels -> 3 }T
T{ 2 max-vowels -> 2 }T

report bye
