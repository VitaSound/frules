\ tests/challenges/136-run-length-len.fs
\
\ CHALLENGE: Run-Length Output Len
\ Source: codewars  https://www.codewars.com/kata/23f4a78cfd7d6b08a000056c
\ Cognitive: 4/10  |  Pattern: run-length-encode-len
\
\ Define a word
\
\   : rle-len  ( c-addr u -- out-u )
\
\ Return byte length of run-length encoding of input (digits + char).
\ aaabb -> a3b2 length.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Single pass.
\   - Use ch-setup.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
create ch-buf 64 chars allot

: ch-setup  ( c-addr u -- ch-buf u )
  dup >r  ch-buf swap  move  ch-buf r> ;

\ === paste your solution below this line ===

variable rl-buf
variable rl-ulen
variable rl-outv
variable rl-runv
variable rl-curv

: rle-len  ( c-addr u -- out-u )
  { buf u }
  u 0= if
    0
  else
    0 rl-outv !
    buf c@ rl-curv c!
    0 rl-runv !
    u 0 ?do
      buf i + c@ rl-curv c@ <>
      if
        1 rl-outv +!
        rl-runv @ 1 > if  1 rl-outv +!  then
        buf i + c@ rl-curv c!
        1 rl-runv !
      else
        1 rl-runv +!
      then
    loop
    1 rl-outv +!
    rl-runv @ 1 > if  1 rl-outv +!  then
    rl-outv @
  then ;

\ === paste your solution above this line ===

T{ s" aaa" ch-setup rle-len -> 2 }T
T{ s" aabbb" ch-setup rle-len -> 4 }T
T{ s" ab" ch-setup rle-len -> 2 }T

report bye
