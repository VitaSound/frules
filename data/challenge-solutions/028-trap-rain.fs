\ tests/challenges/028-trap-rain.fs
\
\ CHALLENGE: Trapping Rain Water
\ Source: leetcode  https://leetcode.com/problems/trapping-rain-water/
\ Cognitive: 7/10  |  Pattern: trapping-rain-water-volume
\
\ Define a word
\
\   : trap-rain  ( -- vol )
\
\ Return trapped water volume for height array ch-data[0..ch-n).
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Two-pointer or prefix max.
\   - Uses preloaded heights.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
0 0 ch!  1 1 ch!  0 2 ch!  2 3 ch!  1 4 ch!
0 5 ch!  1 6 ch!  3 7 ch!  2 8 ch!  1 9 ch!  2 10 ch!  1 11 ch!
12 constant ch-n

\ === paste your solution below this line ===

: trap-rain  ( -- vol )
  ch-n 2 < if  0 exit  then
  ch-n 1- 0 0 0 0 0 0 { hi lo vol lmax rmax hlo hhi }
  begin lo hi < while
    lo ch@ to hlo
    hi ch@ to hhi
    hlo hhi <= if
      hlo lmax > if  hlo to lmax  then
      lmax hlo > if  lmax hlo - vol + to vol  then
      lo 1+ to lo
    else
      hhi rmax > if  hhi to rmax  then
      rmax hhi > if  rmax hhi - vol + to vol  then
      hi 1- to hi
    then
  repeat
  vol ;

\ === paste your solution above this line ===

T{ trap-rain -> 6 }T

report bye
