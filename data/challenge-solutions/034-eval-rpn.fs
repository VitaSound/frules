\ tests/challenges/034-eval-rpn.fs
\
\ CHALLENGE: Evaluate RPN
\ Source: leetcode  https://leetcode.com/problems/evaluate-reverse-polish-notation/
\ Cognitive: 6/10  |  Pattern: evaluate-reverse-polish
\
\ Define a word
\
\   : eval-rpn  ( c-addr u -- n )
\
\ Evaluate space-separated RPN expression with + - * / on integers.
\ Division truncates toward zero.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Use value stack.
\   - Use ch-setup for input string.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
create ch-buf 64 chars allot

: ch-setup  ( c-addr u -- ch-buf u )
  dup >r  ch-buf swap  move  ch-buf r> ;

\ === paste your solution below this line ===

create rpn-stk  32 cells allot
variable rpn-sp
variable rpn-base
variable rpn-len
variable rpn-pos

: rpn-push  ( n -- )
  rpn-sp @ cells rpn-stk + !  rpn-sp @ 1+ rpn-sp ! ;

: rpn-pop  ( -- n )
  rpn-sp @ 1- dup rpn-sp !  cells rpn-stk + @ ;

: rpn-char?  ( c -- flag )
  dup [char] 0 >= swap [char] 9 <= and ;

variable tl-c
variable tl-max
variable tl-i

variable tl-done

: token-len  ( c-addr u -- u' )
  false tl-done !
  tl-max !  tl-c !  0 tl-i !
  begin  tl-done @ 0=  tl-i @ tl-max @ <  and  while
    tl-c @ tl-i @ + c@ bl = if
      tl-i @ tl-max !  true tl-done !
    else
      tl-i @ 1+ tl-i !
    then
  repeat
  tl-max @ ;

: parse-uint  ( c-addr u -- n )
  0 0 2swap >number  2drop drop ;

: parse-int  ( c-addr u -- n )
  { c u }
  u 0= if 0 exit then
  c c@ [char] - = if
    c 1+ u 1- parse-uint negate
  else
    c u parse-uint
  then ;

variable rpn-x
variable rpn-y

: apply-op  ( char -- )
  rpn-pop rpn-y !  rpn-pop rpn-x !
  dup [char] + = if  drop  rpn-x @ rpn-y @ + rpn-push
  else  dup [char] - = if  drop  rpn-x @ rpn-y @ - rpn-push
  else  dup [char] * = if  drop  rpn-x @ rpn-y @ * rpn-push
  else  drop  rpn-x @ rpn-y @ / rpn-push  then  then  then ;

: eval-rpn  ( c-addr u -- n )
  rpn-len !  rpn-base !
  0 rpn-sp !  0 rpn-pos !
  begin rpn-pos @ rpn-len @ < while
    begin
      rpn-pos @ rpn-len @ < rpn-base @ rpn-pos @ + c@ bl = and
    while rpn-pos @ 1+ rpn-pos ! repeat
    rpn-pos @ rpn-len @ < if
      rpn-base @ rpn-pos @ +  rpn-len @ rpn-pos @ -  token-len  ( toklen )
      dup if
        dup 1 > if
          rpn-base @ rpn-pos @ + over parse-int  rpn-push
        else
          rpn-base @ rpn-pos @ + c@ rpn-char? if
            rpn-base @ rpn-pos @ +  1 parse-int  rpn-push
          else
            rpn-base @ rpn-pos @ + c@ apply-op
          then
        then
        rpn-pos @ +  rpn-pos !
      else  drop  then
    then
  repeat
  rpn-pop ;

\ === paste your solution above this line ===

T{ s" 2 1 + " ch-setup eval-rpn -> 3 }T
T{ s" 4 13 5 / + " ch-setup eval-rpn -> 6 }T
T{ s" 10 6 9 3 + -11 * / * 17 + 5 + " ch-setup eval-rpn -> 12 }T

report bye
