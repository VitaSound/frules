\ tests/ans/parse-int.fs — parse decimal (c-addr u) into ( n flag ).
\ Exercises: two-output contract, >NUMBER plumbing, ANS flag conventions (-1/0).

include _tester.fs

: parse-int  ( c-addr u -- n flag )
  0 0 2swap                             \ 0. c-addr u
  >number                               \ ud c-addr' u'
  if    2drop drop  0 false             \ leftover chars: not all digits
  else  drop drop  true                 \ keep ud-low as n, true
  then ;

decimal

T{ s" 123" parse-int -> 123 true  }T
T{ s" 0"   parse-int ->   0 true  }T
T{ s" 42"  parse-int ->  42 true  }T
T{ s" abc" parse-int ->   0 false }T
T{ s" 12x" parse-int ->   0 false }T
T{ s" "    parse-int ->   0 true  }T    \ empty: trivially parsed as 0

report bye
