\ tests/challenges/031-remove-pal-sub.fs
\
\ CHALLENGE: Remove Adjacent Duplicates
\ Source: leetcode  https://leetcode.com/problems/remove-all-adjacent-duplicates-in-string/
\ Cognitive: 5/10  |  Pattern: remove-palindrome-substring
\
\ Define a word
\
\   : remove-pal-sub  ( c-addr u -- c-addr2 u2 )
\
\ Remove all adjacent equal char pairs until stable.
\ Return result in ch-buf.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Stack or two-pointer in buffer.
\   - Use ch-setup.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
create ch-buf 64 chars allot

: ch-setup  ( c-addr u -- ch-buf u )
  dup >r  ch-buf swap  move  ch-buf r> ;

\ === paste your solution below this line ===

variable rm-base
variable rm-len
variable rm-w

variable rm-idx

: remove-pal-sub  ( c-addr u -- c-addr2 u2 )
  rm-len !  rm-base !
  0 rm-w !  0 rm-idx !
  begin rm-idx @ rm-len @ < while
    rm-base @ rm-idx @ + c@
    rm-w @ 0> if
      dup rm-w @ 1- rm-base @ + c@ = if
        drop  rm-w @ 1- rm-w !
      else
        dup rm-base @ rm-w @ + c!  drop
        rm-w @ 1+ rm-w !
      then
    else
      rm-base @ rm-w @ + c!
      rm-w @ 1+ rm-w !
    then
    rm-idx @ 1+ rm-idx !
  repeat
  rm-base @ rm-w @ ;

\ === paste your solution above this line ===

T{ s" abbaca" ch-setup remove-pal-sub s" ca" expect-str-eq -> }T
T{ s" azxxzy" ch-setup remove-pal-sub s" ay" expect-str-eq -> }T
T{ s" a" ch-setup remove-pal-sub s" a" expect-str-eq -> }T

report bye
