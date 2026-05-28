\ tests/challenges/012-count-and-say.fs
\
\ CHALLENGE: Count and Say Next
\ Source: leetcode  https://leetcode.com/problems/count-and-say/
\ Cognitive: 6/10  |  Pattern: count-and-say-next
\
\ Define a word
\
\   : count-say  ( c-addr u -- c-addr2 u2 )
\
\ Transform run-length string to next term (1->11, 11->21).
\ Return result in ch-buf as counted string.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Factor digit-run encoder.
\   - Result valid until next call.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
create ch-buf 64 chars allot

: ch-setup  ( c-addr u -- ch-buf u )
  dup >r  ch-buf swap  move  ch-buf r> ;

\ === paste your solution below this line ===

\ Output lives in its own buffer so reading the input (in ch-buf) is never
\ clobbered while we write; result is valid until the next call.
create out-buf 64 chars allot

: append-num  ( n outp -- outp2 )   \ write decimal digits of n at out-buf+outp
  { n outp }
  n 10 >= if  n 10 / outp recurse to outp  then
  n 10 mod [char] 0 +  out-buf outp + c!
  outp 1+ ;

: count-say  ( c-addr u -- c-addr2 u2 )
  0 0 0 0  { src len i outp cur cnt }
  begin i len < while
    src i + c@ to cur                 \ digit starting this run
    1 to cnt
    begin
      i cnt + len <
      src i cnt + + c@ cur =  and      \ in range and still same digit
    while
      cnt 1+ to cnt
    repeat
    cnt outp append-num to outp        \ emit run length
    cur out-buf outp + c!  outp 1+ to outp  \ then the digit
    i cnt + to i
  repeat
  out-buf outp ;

\ === paste your solution above this line ===

T{ s" 1" ch-setup count-say s" 11" expect-str-eq -> }T
T{ s" 11" ch-setup count-say s" 21" expect-str-eq -> }T
T{ s" 21" ch-setup count-say s" 1211" expect-str-eq -> }T

report bye
