\ tests/challenges/078-gas-station.fs
\
\ CHALLENGE: Gas Station
\ Source: leetcode  https://leetcode.com/problems/gas-station/
\ Cognitive: 6/10  |  Pattern: gas-station-circuit
\
\ Define a word
\
\   : gas-start  ( -- idx )
\
\ Return starting station index for circuit or -1.
\ gas and cost arrays interleaved in ch-data.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Single pass greedy.
\   - Preload gas/cost pairs.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
1 0 ch!  3 1 ch!  2 2 ch!  4 3 ch!  3 4 ch!  5 5 ch!
4 6 ch!  1 7 ch!  5 8 ch!  2 9 ch!
10 constant ch-n

\ === paste your solution below this line ===

: gas@ ( i -- n )  2* ch@ ;
: cost@ ( i -- n )  2* 1+ ch@ ;

variable ch-gas-tank
variable ch-gas-idx

: gas-sum ( -- n )
  0  5 0 ?do  i gas@ i cost@ - +  loop ;

: gas-start ( -- idx )
  gas-sum dup 0< if  drop -1 exit  then  drop
  0 ch-gas-tank !  0 ch-gas-idx !
  5 0 ?do
    ch-gas-tank @  i gas@ i cost@ - +  dup 0<
    if  drop  i 1+ ch-gas-idx !  0 ch-gas-tank !
    else  ch-gas-tank !
    then
  loop
  ch-gas-idx @ ;

\ === paste your solution above this line ===

T{ gas-start -> 3 }T

report bye
