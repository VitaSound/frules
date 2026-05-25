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

s" 123" parse-int  true t= 123 t=
s" 0"   parse-int  true t=   0 t=
s" 42"  parse-int  true t=  42 t=
s" abc" parse-int  false t=  0 t=
s" 12x" parse-int  false t=  0 t=
s" "    parse-int  true t=   0 t=    \ empty: trivially parsed as 0

report bye
