\ tests/_tester.fs - wrapper around vendored ttester (Hayes/Ertl, public domain).
\
\ Each test file is expected to:
\   include _tester.fs
\   T{ <code> -> <expected stack> }T
\   ...
\   report bye
\
\ See ttester.4th (verbatim upstream) and ttester-ext.4th (extra expect-*
\ predicates and TS{ ... }ST fixture hooks) in this directory.
\
\ Upstream: http://www.complang.tuwien.ac.at/cvsweb/cgi-bin/cvsweb/gforth/test/ttester.fs
\ Fork:     https://github.com/VitaSound/ttester

include ttester.4th
include ttester-ext.4th

: report  ( -- )
  cr #errors @
  if   ." TESTS FAILED: " #errors @ . cr
  else ." TESTS OK" cr
  then ;
