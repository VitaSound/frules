\ tests/challenges/024-majority-element.fs
\
\ CHALLENGE: Majority Element
\ Source: leetcode  https://leetcode.com/problems/majority-element/
\ Cognitive: 4/10  |  Pattern: majority-element-boyer
\
\ Define a word
\
\   : majority  ( -- n )
\
\ Return element appearing more than n/2 times in ch-data.
\ Majority always exists in tests.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Boyer-Moore vote.
\   - Uses ch-n.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
2 0 ch!  2 1 ch!  1 2 ch!  2 3 ch!  2 4 ch!
5 constant ch-n

\ === paste your solution below this line ===

: majority ( -- n )
  0 { cand }  0 { count }
  ch-n 0 ?do
    i ch@
    count 0= if
      to cand  1 to count
    else
      dup cand = if
        drop  count 1+ to count
      else
        drop  count 1- to count
      then
    then
  loop
  cand ;

: majority-stack ( -- n )
  0 0  ( cand count )
  ch-n 0 ?do
    i ch@
    over 0= if
      nip dup 1
    else
      2dup = if
        >r 1+ r>
      else
        >r 1- r>
      then
      nip
    then
  loop
  drop ;

\ === paste your solution above this line ===

T{ majority -> 2 }T

report bye
