\ tests/challenges/128-bf-steps.fs
\
\ CHALLENGE: Brainfuck Steps
\ Source: codewars  https://www.codewars.com/kata/526156943dfe7ce06200063e
\ Cognitive: 7/10  |  Pattern: brainfuck-step-count
\
\ Define a word
\
\   : bf-steps  ( c-addr u -- steps )
\
\ Run Brainfuck program until halt; return instruction steps executed.
\ Tape size 30000; input empty.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Interpreter loop.
\   - Use ch-setup for program.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
create ch-buf 64 chars allot

: ch-setup  ( c-addr u -- ch-buf u )
  dup >r  ch-buf swap  move  ch-buf r> ;

\ === paste your solution below this line ===

30000 constant bf-tape-size
create bf-tape  bf-tape-size allot

variable bf-ip
variable bf-dp
variable bf-steps-count
variable bf-prog
variable bf-len

: bf-cell  ( -- addr )
  bf-tape bf-dp @ + ;

: bf-ins@  ( -- c )
  bf-prog @ bf-ip @ + c@ ;

: bf-scan-fwd  ( -- )
  1 >r
  begin  r@ 0> while
    1 bf-ip +!
    bf-ins@  dup [char] [ = if  drop  r> 1+ >r  else
      dup [char] ] = if  drop  r> 1- >r  else  drop  then  then
  repeat  r> drop ;

: bf-scan-back  ( -- )
  1 >r
  begin  r@ 0> while
    -1 bf-ip +!
    bf-ins@  dup [char] ] = if  drop  r> 1+ >r  else
      dup [char] [ = if  drop  r> 1- >r  else  drop  then  then
  repeat  r> drop ;

: bf-steps  ( c-addr u -- steps )
  bf-tape bf-tape-size erase
  0 bf-ip !  0 bf-dp !  0 bf-steps-count !
  over bf-prog !  bf-len !
  begin  bf-ip @ bf-len @ < while
    bf-ins@  case
      [char] + of
        1 bf-steps-count +!  bf-cell dup c@ 1+ swap c!
      endof
      [char] - of
        1 bf-steps-count +!  bf-cell dup c@ 1- swap c!
      endof
      [char] > of
        1 bf-steps-count +!  1 bf-dp +!
      endof
      [char] < of
        1 bf-steps-count +!  -1 bf-dp +!
      endof
      [char] . of
        1 bf-steps-count +!
      endof
      [char] , of
        1 bf-steps-count +!  0 bf-cell c!
      endof
      [char] [ of
        bf-cell c@ 0= if  bf-scan-fwd  then
      endof
      [char] ] of
        bf-cell c@ 0<> if  bf-scan-back  then
      endof
    endcase
    1 bf-ip +!
  repeat  drop  bf-steps-count @ ;

\ === paste your solution above this line ===

T{ s" +." ch-setup bf-steps -> 2 }T
T{ s" +++" ch-setup bf-steps -> 3 }T
T{ s" [.-]" ch-setup bf-steps -> 0 }T

report bye
