\ tests/challenges/04-caesar-shift.fs
\
\ CHALLENGE: Caesar shift, in place
\
\ Define a word
\
\   : caesar  ( c-addr u n -- )
\
\ that shifts every ASCII letter in the buffer by n positions:
\   'a'..'z' wrap inside lower case,
\   'A'..'Z' wrap inside upper case,
\   any other byte is left untouched.
\
\ n is a signed cell; large values (positive or negative) must work
\ via modular arithmetic (e.g. shift 27 == shift 1, shift -1 == shift 25).
\
\ Style guard:
\   - rules/forth-anti-patterns.mdc "don't decide, calculate" — prefer
\     arithmetic to chained IFs;
\   - factor the per-character work into its own word and document its
\     stack effect;
\   - magic numbers ('a', 'A', 26) belong in CONSTANTs.

include _tester.fs

create cbuf 32 chars allot

: setup  ( c-addr u -- cbuf u )
  dup >r  cbuf swap  move  cbuf r> ;

\ === paste your solution below this line ===

char a constant lower-base
char A constant upper-base
26 constant letters

: ?select  ( a b flag -- x )
  if swap then drop ;

: in-range?  ( base c -- flag )
  swap - letters u< ;

: shift-lower  ( c n -- c' )
  swap lower-base - swap + letters mod lower-base + ;

: shift-upper  ( c n -- c' )
  swap upper-base - swap + letters mod upper-base + ;

: shift-char  ( c n -- c' )
  { ch n -- c' }
  ch ch n shift-lower
  lower-base ch in-range? ?select
  ch n shift-upper
  upper-base ch in-range? ?select ;

: caesar  ( c-addr u n -- )
  { addr len n -- }
  len 0 ?do
    addr i + dup c@ n shift-char swap c!
  loop ;

\ === paste your solution above this line ===

T{ s" abc"      setup 2dup  1 caesar  s" bcd"      expect-str-eq -> }T
T{ s" xyz"      setup 2dup  1 caesar  s" yza"      expect-str-eq -> }T
T{ s" Hello"    setup 2dup  1 caesar  s" Ifmmp"    expect-str-eq -> }T
T{ s" abc xy"   setup 2dup  1 caesar  s" bcd yz"   expect-str-eq -> }T
T{ s" Zoo"      setup 2dup  1 caesar  s" App"      expect-str-eq -> }T
T{ s" hello"    setup 2dup 27 caesar  s" ifmmp"    expect-str-eq -> }T
T{ s" abc"      setup 2dup -1 caesar  s" zab"      expect-str-eq -> }T
T{ s" Forth!"   setup 2dup  0 caesar  s" Forth!"   expect-str-eq -> }T

report bye
