\ tests/challenges/035-daily-temp.fs
\
\ CHALLENGE: Daily Temperatures
\ Source: leetcode  https://leetcode.com/problems/daily-temperatures/
\ Cognitive: 6/10  |  Pattern: daily-temperatures-span
\
\ Define a word
\
\   : daily-temp  ( -- )
\
\ Fill ch-out[i] with days until warmer temperature after day i.
\ Last days get 0.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Monotonic stack.
\   - Preload temps in ch-data, ch-out same size.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
73 0 ch!  74 1 ch!  75 2 ch!  71 3 ch!  69 4 ch!  72 5 ch!  76 6 ch!  73 7 ch!
8 constant ch-n
create ch-out 16 cells allot
: ch-out@ ( i -- n ) cells ch-out + @ ;
: ch-out! ( n i -- ) cells ch-out + ! ;

\ === paste your solution below this line ===

create st-idx  16 cells allot
variable st-sp

variable warm-idx

: daily-temp  ( -- )
  0 st-sp !
  ch-n 0 ?do
    begin
      st-sp @ if  i ch@  st-sp @ 1- cells st-idx + @ ch@  >  else  0  then
    while
      st-sp @ 1- cells st-idx + @ warm-idx !
      i warm-idx @ -  warm-idx @ ch-out!
      st-sp @ 1- st-sp !
    repeat
    i  st-sp @ cells st-idx + !  st-sp @ 1+ st-sp !
  loop
  begin  st-sp @  while
    0  st-sp @ 1- cells st-idx + @  ch-out!
    st-sp @ 1- st-sp !
  repeat ;

\ === paste your solution above this line ===

T{ daily-temp }T
T{ 1 ch-out@ -> 1 }T
T{ 6 ch-out@ -> 0 }T

report bye
