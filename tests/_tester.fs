\ tests/_tester.fs — minimal portable test harness (gforth + pforth).
\
\ Usage in a test file:
\   include _tester.fs
\   <actual-expr> <expected-literal> t=
\   ...
\   report bye

variable #fails  0 #fails !

: t=  ( got expected -- )
  2dup = if 2drop exit then
  cr ." FAIL  expected " . ."  got " . space
  1 #fails +! ;

: report  ( -- )
  cr #fails @
  if ." TESTS FAILED: " #fails @ . cr
  else ." TESTS OK" cr then ;
