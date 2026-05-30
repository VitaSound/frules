\ examples/ans/portable.fs — pure ANS Forth (DPANS94).
\ Must compile in BOTH gforth and pforth without warnings or errors.
\ No { locals }, no s\", no $@, no bin file mode, no Gforth-only words.

\ Constants
80   constant line-width
1024 constant buf-size

\ Small factored words with stack effects
: clamp-positive   ( n -- u )  0 max ;
: clamp-line       ( n -- u )  clamp-positive line-width min ;

\ Portable scaling — square via stack only, no variables
: square           ( n -- n*n )  dup * ;

\ Defining word: typed cell array via CREATE / DOES>
: cell-array  ( n "name" -- )
  create cells allot
  does>     ( i a-addr -- addr )  swap cells + ;

10 cell-array readings

: store-reading   ( n i -- )  readings ! ;
: fetch-reading   ( i -- n )  readings @ ;

\ Address/length pair via ANS S"
: greet  ( -- )  s" hello ans" type cr ;

\ Counted string via C" + COUNT
: tag    ( -- c-addr u )  c" v1" count ;

include ../../tests/ans/_tester.fs

T{ -3 clamp-positive -> 0 }T
T{  5 clamp-positive -> 5 }T
T{  7 clamp-line -> 7 }T
T{  4 square -> 16 }T
T{ 99 0 store-reading -> }T
T{  0 fetch-reading -> 99 }T
T{ greet -> }T
T{ tag nip -> 2 }T

report bye
