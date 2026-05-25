\ tests/ans/palindrome.fs — palindrome check on (c-addr u).
\ Exercises: address/length pair, factoring helper words, recursion on
\ a shrinking substring, early exit.

include _tester.fs

: first-ch  ( c-addr u -- ch )  drop c@ ;
: last-ch   ( c-addr u -- ch )  1- chars + c@ ;

: palindrome?  ( c-addr u -- flag )
  dup 2 < if 2drop true exit then
  2dup first-ch  >r
  2dup last-ch   r> <>
  if 2drop false exit then
  swap char+ swap 2 -
  recurse ;

s" "          palindrome? true  t=
s" a"         palindrome? true  t=
s" aa"        palindrome? true  t=
s" ab"        palindrome? false t=
s" aba"       palindrome? true  t=
s" abba"      palindrome? true  t=
s" abca"      palindrome? false t=
s" racecar"   palindrome? true  t=
s" forth"     palindrome? false t=

report bye
