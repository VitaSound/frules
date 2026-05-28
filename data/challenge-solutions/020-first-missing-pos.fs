\ tests/challenges/020-first-missing-pos.fs
\
\ CHALLENGE: First Missing Positive
\ Source: leetcode  https://leetcode.com/problems/first-missing-positive/
\ Cognitive: 6/10  |  Pattern: first-missing-positive
\
\ Define a word
\
\   : first-missing  ( -- n )
\
\ Return smallest positive integer absent from ch-data.
\ Array length ch-n; values may repeat.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - O(n) preferred for small n.
\   - Uses ch-n preloaded array.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
3 0 ch!  4 1 ch!  -1 2 ch!  1 3 ch!
4 constant ch-n

\ === paste your solution below this line ===

\ O(n): mark which values in 1..ch-n appear (ch-data stays read-only), then
\ scan upward for the first unmarked positive. Answer is at most ch-n+1.
create seen ch-max 1+ cells allot

: first-missing  ( -- n )
  seen  ch-max 1+ cells  erase
  ch-n 0 ?do
    i ch@
    dup 0 >  over ch-n 1+ <  and if   \ keep only 1..ch-n
      cells seen +  true swap !
    else drop then
  loop
  1 begin  dup cells seen + @  while  1+  repeat ;

\ === paste your solution above this line ===

T{ first-missing -> 2 }T

report bye
