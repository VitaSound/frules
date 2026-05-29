\ tests/challenges/066-word-break.fs
\
\ CHALLENGE: Word Break
\ Source: leetcode  https://leetcode.com/problems/word-break/
\ Cognitive: 6/10  |  Pattern: word-break-dictionary
\
\ Define a word
\
\   : word-break?  ( c-addr u -- flag )
\
\ Return TRUE if string can be segmented into space-separated dictionary words.
\ Dictionary in ch-dict helper.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - DP over positions.
\   - Use ch-setup.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
create ch-buf 64 chars allot

: ch-setup  ( c-addr u -- ch-buf u )
  dup >r  ch-buf swap  move  ch-buf r> ;

create ch-dict 64 chars allot
variable ch-dict-u

: dict-init ( c-addr u -- )
  dup >r  ch-dict swap  move  r>  ch-dict-u ! ;

s" leet code apple pen" dict-init

\ === paste your solution below this line ===

64 constant ch-dp-max
create ch-dp  ch-dp-max cells allot

: dp@ ( i -- flag )  cells ch-dp + @ ;
: dp! ( flag i -- )  cells ch-dp + ! ;

8 constant ch-max-words
create ch-w-off  ch-max-words cells allot
create ch-w-len  ch-max-words cells allot
variable w-n

: w-off@ ( idx -- n )  cells ch-w-off + @ ;
: w-len@ ( idx -- n )  cells ch-w-len + @ ;
: w-off! ( n idx -- )  cells ch-w-off + ! ;
: w-len! ( n idx -- )  cells ch-w-len + ! ;

\ Preparsed offsets for "leet code apple pen"
: parse-dict ( -- )
  4 w-n !
  0 0 w-off!   4 0 w-len!
  5 1 w-off!   4 1 w-len!
  10 2 w-off!  5 2 w-len!
  16 3 w-off!  3 3 w-len! ;

variable s-addr
variable s-len

: word-match? ( end idx -- flag )
  { end idx | wlen start }
  idx w-len@ to wlen
  end wlen < if false exit then
  end wlen - to start
  start dp@ 0= if false exit then
  s-addr @ start +  wlen
  ch-dict idx w-off@ +  wlen
  compare 0= ;

: word-break? ( c-addr u -- flag )
  { s u | end idx }
  s s-addr !
  u s-len !
  s-len @ ch-dp-max >= if false exit then
  parse-dict
  s-len @ 1+ 0 ?do  0 i dp!  loop
  1 0 dp!
  s-len @ 1+ 1 ?do
    i to end
    0 to idx
    begin
      idx w-n @ <
    while
      end idx word-match? if
        1 end dp!
        w-n @ to idx
      else
        idx 1+ to idx
      then
    repeat
  loop
  s-len @ dp@ 0<> ;

\ === paste your solution above this line ===

T{ s" leetcode" ch-setup word-break? -> true }T
T{ s" applepen" ch-setup word-break? -> true }T
T{ s" catsandog" ch-setup word-break? -> false }T

report bye
