\ tests/challenges/097-max-consecutive-ones.fs
\
\ CHALLENGE: Max Consecutive Ones
\ Source: leetcode  https://leetcode.com/problems/max-consecutive-ones-iii/
\ Cognitive: 5/10  |  Pattern: max-consecutive-ones-iii
\
\ Define a word
\
\   : max-ones  ( k -- len )
\
\ Return longest subarray of 1s after flipping at most k zeros in ch-data.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Sliding window.
\   - k on stack.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
\ Fixed: k=2 expected 9 (array has 3 zeros; full length needs k>=3).
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
1 0 ch!  1 1 ch!  0 2 ch!  1 3 ch!  1 4 ch!  0 5 ch!  1 6 ch!  1 7 ch!  1 8 ch!  0 9 ch!
10 constant ch-n

\ === paste your solution below this line ===

variable mo-k
variable mo-left
variable mo-zeros
variable mo-best

: max-ones ( k -- len )
  mo-k !
  0 mo-left !  0 mo-zeros !  0 mo-best !
  ch-n 0 ?do
    i ch@ 0= if  1 mo-zeros +!  then
    begin  mo-zeros @ mo-k @ >  while
      mo-left @ ch@ 0= if  -1 mo-zeros +!  then
      mo-left @ 1+ mo-left !
    repeat
    i mo-left @ - 1+ mo-best @ max mo-best !
  loop
  mo-best @ ;

\ === paste your solution above this line ===

T{ 1 max-ones -> 6 }T
T{ 2 max-ones -> 9 }T

report bye
