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

T{ s" "        palindrome? -> true  }T
T{ s" a"       palindrome? -> true  }T
T{ s" aa"      palindrome? -> true  }T
T{ s" ab"      palindrome? -> false }T
T{ s" aba"     palindrome? -> true  }T
T{ s" abba"    palindrome? -> true  }T
T{ s" abca"    palindrome? -> false }T
T{ s" racecar" palindrome? -> true  }T
T{ s" forth"   palindrome? -> false }T

report bye
