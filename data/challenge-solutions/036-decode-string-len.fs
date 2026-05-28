\ tests/challenges/036-decode-string-len.fs
\
\ CHALLENGE: Decode String Length
\ Source: leetcode  https://leetcode.com/problems/decode-string/
\ Cognitive: 7/10  |  Pattern: decode-string-length
\
\ Define a word
\
\   : decode-len  ( c-addr u -- len )
\
\ Return length of decoded k[encoded] pattern (digits and letters only).
\ Do not materialize full string.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Use count stack.
\   - Use ch-setup.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
create ch-buf 64 chars allot

: ch-setup  ( c-addr u -- ch-buf u )
  dup >r  ch-buf swap  move  ch-buf r> ;

\ === paste your solution below this line ===

create dec-stk  32 cells allot
variable dec-sp
variable dec-len
variable dec-num
variable dec-base
variable dec-u
variable dec-i

91 constant const-lbrack
93 constant const-rbrack

: dec-push  ( n -- )
  dec-sp @ cells dec-stk + !  dec-sp @ 1+ dec-sp ! ;

: dec-pop  ( -- n )
  dec-sp @ 1- dup dec-sp !  cells dec-stk + @ ;

: decode-len  ( c-addr u -- len )
  dec-u !  dec-base !
  0 dec-len !  0 dec-num !  0 dec-sp !  0 dec-i !
  begin  dec-i @ dec-u @ < while
    dec-base @ dec-i @ + c@  ( ch )
    dup  [char] 0  [char] 9  within if
      [char] 0 -  dec-num @ 10 * +  dec-num !
    else  dup const-lbrack = if
      drop  dec-len @ dec-push  dec-num @ dec-push
      0 dec-len !  0 dec-num !
    else  dup const-rbrack = if
      drop  dec-pop  dec-len @  *  dec-pop  +  dec-len !
    else
      drop  dec-len @ 1+ dec-len !
    then  then  then
    dec-i @ 1+ dec-i !
  repeat
  dec-len @ ;

\ === paste your solution above this line ===

T{ s" 3[a]2[bc]" ch-setup decode-len -> 7 }T
T{ s" abc3[cd]xyz" ch-setup decode-len -> 12 }T
T{ s" a" ch-setup decode-len -> 1 }T

report bye
