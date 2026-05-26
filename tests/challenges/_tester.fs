\ tests/challenges/_tester.fs — forwards to vendored ttester in ../ans/.
\
\ Run challenges from inside this directory:
\   cd tests/challenges
\   gforth 01-clamp.fs

include ../ans/ttester.4th
include ../ans/ttester-ext.4th

: report  ( -- )
  cr #errors @
  if   ." TESTS FAILED: " #errors @ . cr
  else ." TESTS OK" cr
  then ;
