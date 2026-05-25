\ tests/ans/count-char.fs — count a char in (c-addr u).
\ Exercises: address/length pair (NOT counted), recursion (no PICK, no DO/R-clash),
\ early base case.
\
\ Note: implemented recursively to avoid stashing `ch` on the return stack while
\ inside a DO/?DO loop (which already uses R: for the loop index).

include _tester.fs

: count-char  ( c-addr u ch -- n )
  over 0= if 2drop drop 0 exit then       \ u == 0 ⇒ count is 0
  >r                                       \ c-addr u  (R: ch)
  over c@ r@ =                             \ c-addr u flag  (R: ch)
  swap 1-                                  \ c-addr flag u-1
  rot char+ swap                           \ flag c-addr+1 u-1
  r>                                       \ flag c-addr+1 u-1 ch
  recurse                                  \ flag count'
  swap if 1+ then ;                        \ count

s" hello world"   bl     count-char  1 t=
s" abc"           bl     count-char  0 t=
s" "              bl     count-char  0 t=
s" a b c d e"     bl     count-char  4 t=
s" aaaa"        char a   count-char  4 t=
s" mississippi" char s   count-char  4 t=

report bye
