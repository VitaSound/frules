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

create prod 128 cells allot

: prod@ ( i -- n )  cells prod + @ ;
: prod! ( n i -- )  cells prod + ! ;
: prod+! ( n i -- )  cells prod + dup @ rot + swap ! ;
: prod-clear ( plen -- )  cells prod swap 0 fill ;

: str-mul-pack ( plen start -- c-addr cu )
  { plen start | k }
  plen start = if
    s" 0" 2dup ch-buf swap move  ch-buf 1
  else
    plen start - to k
    k 0 ?do
      start i + prod@ [char] 0 +  ch-buf i + c!
    loop
    ch-buf k
  then ;

: prod-start ( plen -- start )
  >r
  0 r@ ?do
    i prod@ 0<> if
      r> drop  i  unloop  exit
    then
  loop
  r> ;

: str-mul-core ( a-addr au b-addr bu -- plen )
  { a au b bu | da db pos d plen }
  au bu + to plen
  plen prod-clear
  au 0 ?do
    bu 0 ?do
      au 1- i - a + c@ [char] 0 - to da
      bu 1- j - b + c@ [char] 0 - to db
      i j + 1+ to pos
      da db * pos prod@ + pos prod!
    loop
  loop
  plen 1- dup 0> if
    plen 1- 0 ?do
      plen 1- i - to pos
      pos prod@ to d
      d 10 / pos 1- prod+!
      d 10 mod pos prod!
    loop
  then
  plen ;

: str-mul ( a-addr au b-addr bu -- c-addr cu )
  str-mul-core  dup prod-start  str-mul-pack ;

: str-mul-stack-add-term ( a au b bu plen ii jj -- plen )
  >r >r
  4 pick 3 pick 1- r@ -  4 pick + c@ [char] 0 -
  >r
  2 pick 1 pick 1- r@ -  2 pick + c@ [char] 0 -
  r> r> *  >r
  r@ 2 pick + 1+  dup prod@ r> + swap prod!
  drop ;

: str-mul-stack-multiply ( a au b bu plen -- plen )
  0 >r
  begin  r@ 3 pick <
  while
    0 >r
    begin  r@ 2 pick <
    while
      5 pick 5 pick 5 pick 5 pick 5 pick  r@ r@
      str-mul-stack-add-term
      r> 1+ >r
    repeat
    r> drop
    r> 1+ >r
  repeat
  r> drop ;

: str-mul-stack-carry ( plen -- plen )
  dup 1- dup 0> if
    >r  0 r@ ?do
      dup r@ i - 1-  dup prod@ swap
      dup 10 / rot 1- prod+!
      10 mod swap prod!
    loop
  else  drop  then ;

: str-mul-stack ( a-addr au b-addr bu -- c-addr cu )
  2 pick 0 pick +  dup prod-clear
  str-mul-stack-multiply  str-mul-stack-carry
  dup prod-start  str-mul-pack ;

\ === paste your solution above this line ===

T{ s" 2" a-setup s" 3" b-setup str-mul s" 6" expect-str-eq -> }T
T{ s" 123" a-setup s" 456" b-setup str-mul s" 56088" expect-str-eq -> }T
T{ s" 0" a-setup s" 999" b-setup str-mul s" 0" expect-str-eq -> }T

T{ s" 2" a-setup s" 3" b-setup str-mul-stack s" 6" expect-str-eq -> }T
T{ s" 123" a-setup s" 456" b-setup str-mul-stack s" 56088" expect-str-eq -> }T
T{ s" 0" a-setup s" 999" b-setup str-mul-stack s" 0" expect-str-eq -> }T

report bye
