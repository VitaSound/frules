\ tests/challenges/014-multiply-strings.fs
\
\ CHALLENGE: Multiply String Numbers
\ Source: leetcode  https://leetcode.com/problems/multiply-strings/
\ Cognitive: 7/10  |  Pattern: decimal-string-multiply
\
\ Define a word
\
\   : str-mul  ( a-addr au b-addr bu -- c-addr cu )
\
\ Multiply two non-negative decimal digit strings.
\ Return product as counted string in ch-buf.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Grade-school multiply OK.
\   - No ANS numeric conversion of whole string.
\   - a-setup / b-setup for two operand copies; product in ch-buf.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
create a-buf 64 chars allot
create b-buf 64 chars allot
create ch-buf 64 chars allot

: a-setup  ( c-addr u -- a-buf u )
  dup >r  a-buf swap  move  a-buf r> ;

: b-setup  ( c-addr u -- b-buf u )
  dup >r  b-buf swap  move  b-buf r> ;

\ === paste your solution below this line ===

\ Grade-school multiply: digit products accumulate in prod[], one decimal
\ digit per cell; result string is built in ch-buf, valid until next call.
128 constant mul-max
create prod mul-max cells allot

: prod@  ( i -- n )  cells prod + @ ;
: prod!  ( n i -- )  cells prod + ! ;

: str-mul  ( a-addr au b-addr bu -- c-addr cu )
  0 0 0 0  { a au b bu ia ja n outp }
  au bu + to n
  0 to ia
  begin ia n < while  0 ia prod!  ia 1+ to ia  repeat
  au 1- to ia
  begin ia -1 > while
    bu 1- to ja
    begin ja -1 > while
      a ia + c@ [char] 0 -  b ja + c@ [char] 0 -  *
      ia ja + 1+ prod@ +                  ( sum )
      dup 10 mod  ia ja + 1+ prod!        ( sum )  \ low digit at i+j+1
      10 /  ia ja + prod@ +  ia ja + prod!         \ carry into i+j
      ja 1- to ja
    repeat
    ia 1- to ia
  repeat
  0 to ia
  begin ia n 1- <  ia prod@ 0=  and while  ia 1+ to ia  repeat
  0 to outp
  begin ia n < while
    ia prod@ [char] 0 +  ch-buf outp + c!
    outp 1+ to outp  ia 1+ to ia
  repeat
  ch-buf outp ;

\ === paste your solution above this line ===

T{ s" 2" a-setup s" 3" b-setup str-mul s" 6" expect-str-eq -> }T
T{ s" 123" a-setup s" 456" b-setup str-mul s" 56088" expect-str-eq -> }T
T{ s" 0" a-setup s" 999" b-setup str-mul s" 0" expect-str-eq -> }T

report bye
