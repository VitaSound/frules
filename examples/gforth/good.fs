\ examples/gforth/good.fs — idiomatic Gforth that frules should approve of.
\ Loadable: gforth examples/gforth/good.fs -e bye

\ Constants instead of magic numbers
80    constant line-width
1024  constant buf-size

\ Small factored words with stack effects
: spaces-on-line   ( n -- )    line-width min spaces ;
: clamp-positive   ( n -- u )  0 max ;

\ Locals (Gforth) keep deep stacks readable
: clamp ( n lo hi -- n' )
  { n lo hi }
  n hi min  lo max ;

\ Defining word: typed cell array
: cell-array  ( n "name" -- )
  create cells allot
  does>     ( i a-addr -- addr )  swap cells + ;

10 cell-array readings

: store-reading   ( n i -- )  readings ! ;
: fetch-reading   ( i -- n )  readings @ ;

\ Error handling via THROW, ior checked on file I/O
: open-log  ( c-addr u -- fid )
  r/w bin open-file throw ;

: log-line  ( c-addr u fid -- )
  >r r@ write-file throw
  s\" \n" r> write-file throw ;

\ Address/length pair, NOT counted string
: greet  ( -- )  s" hello, forth" type cr ;

include ../../tests/ans/_tester.fs

T{ -3 clamp-positive -> 0 }T
T{  5 clamp-positive -> 5 }T
T{  5 0 10 clamp -> 5 }T
T{ 15 0 10 clamp -> 10 }T
T{ -5 0 10 clamp -> 0 }T
T{  3 spaces-on-line -> }T
T{ 42 0 store-reading -> }T
T{  0 fetch-reading -> 42 }T
T{ greet -> }T

report bye
