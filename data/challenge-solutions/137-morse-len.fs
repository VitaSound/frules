\ tests/challenges/137-morse-len.fs
\
\ CHALLENGE: Morse Decode Len
\ Source: codewars  https://www.codewars.com/kata/5262119038c0985a5b00029
\ Cognitive: 5/10  |  Pattern: morse-decode-length
\
\ Define a word
\
\   : morse-len  ( c-addr u -- n )
\
\ Return length of decoded message from morse string (space-separated codes).
\ Invalid -> 0.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Table lookup.
\   - Use ch-setup.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
create ch-buf 64 chars allot

: ch-setup  ( c-addr u -- ch-buf u )
  dup >r  ch-buf swap  move  ch-buf r> ;

\ === paste your solution below this line ===

: m=  ( c-addr u m-addr m-u -- f ) compare 0= ;

: morse-valid?  ( c-addr u -- f )
  2dup s" .-" m= if 2drop true exit then
  2dup s" -..." m= if 2drop true exit then
  2dup s" -.-." m= if 2drop true exit then
  2dup s" -.." m= if 2drop true exit then
  2dup s" ." m= if 2drop true exit then
  2dup s" ..-." m= if 2drop true exit then
  2dup s" --." m= if 2drop true exit then
  2dup s" ...." m= if 2drop true exit then
  2dup s" .." m= if 2drop true exit then
  2dup s" .---" m= if 2drop true exit then
  2dup s" -.-" m= if 2drop true exit then
  2dup s" .-.." m= if 2drop true exit then
  2dup s" --" m= if 2drop true exit then
  2dup s" -." m= if 2drop true exit then
  2dup s" ---" m= if 2drop true exit then
  2dup s" .--." m= if 2drop true exit then
  2dup s" --.-" m= if 2drop true exit then
  2dup s" .-." m= if 2drop true exit then
  2dup s" ..." m= if 2drop true exit then
  2dup s" -" m= if 2drop true exit then
  2dup s" ..-" m= if 2drop true exit then
  2dup s" ...-" m= if 2drop true exit then
  2dup s" .--" m= if 2drop true exit then
  2dup s" -..-" m= if 2drop true exit then
  2dup s" -.--" m= if 2drop true exit then
  2dup s" --.." m= if 2drop true exit then
  2dup s" -----" m= if 2drop true exit then
  2dup s" .----" m= if 2drop true exit then
  2dup s" ..---" m= if 2drop true exit then
  2dup s" ...--" m= if 2drop true exit then
  2dup s" ....-" m= if 2drop true exit then
  2dup s" ....." m= if 2drop true exit then
  2dup s" -...." m= if 2drop true exit then
  2dup s" --..." m= if 2drop true exit then
  2dup s" ---.." m= if 2drop true exit then
  2dup s" ----." m= if 2drop true exit then
  2drop false ;

: skip-spaces  ( base u pos -- pos' )
  { base u pos }
  begin
    pos u <
  while
    base pos + c@ bl = if
      pos 1+ to pos
    else
      pos exit
    then
  repeat
  pos ;

: token-end  ( base u pos -- pos' )
  { base u pos }
  begin
    pos u <
  while
    base pos + c@ bl <> if
      pos 1+ to pos
    else
      pos exit
    then
  repeat
  pos ;

: morse-len  ( c-addr u -- n )
  { base ulen }
  0 { pos }
  0 { sum }
  begin
    pos ulen <
  while
    base ulen pos skip-spaces to pos
    pos ulen >= if
      sum exit
    then
    base ulen pos token-end { pos2 }
    base pos +  pos2 pos -  morse-valid? 0= if
      0 exit
    then
    sum 1+ to sum
    pos2 to pos
  repeat
  sum ;

\ === paste your solution above this line ===

T{ s" .... . -.-- . .-. .." ch-setup morse-len -> 6 }T
T{ s" -.... . .-.. .-.. --- .--." ch-setup morse-len -> 6 }T

report bye
