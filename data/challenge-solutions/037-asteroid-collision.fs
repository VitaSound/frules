\ tests/challenges/037-asteroid-collision.fs
\
\ CHALLENGE: Asteroid Collision
\ Source: leetcode  https://leetcode.com/problems/asteroid-collision/
\ Cognitive: 6/10  |  Pattern: asteroid-collision-count
\
\ Define a word
\
\   : asteroid-survive  ( -- count )
\
\ Simulate collisions on ch-data signed sizes; return surviving count.
\ Positive moves right, negative left.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Stack simulation.
\   - Preload asteroids.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
5 0 ch!  10 1 ch!  -5 2 ch!
3 constant ch-n

\ === paste your solution below this line ===

create ast-stk  16 cells allot
variable ast-sp

variable ast-alive
variable ast-cur
variable ast-done

: asteroid-survive  ( -- count )
  0 ast-sp !
  ch-n 0 ?do
    i ch@ ast-cur !
    ast-cur @ 0> if
      ast-cur @ ast-sp @ cells ast-stk + !  ast-sp @ 1+ ast-sp !
    else
      true ast-alive !
      false ast-done !
      begin
        ast-done @ 0=  ast-sp @ 0> and
      while
        ast-sp @ 1- cells ast-stk + @ { top }
        top 0<= if
          true ast-done !
        then
        ast-done @ 0= if
          top ast-cur @ abs > if
            false ast-alive !
            true ast-done !
          else
            top ast-cur @ abs < if
              ast-sp @ 1- ast-sp !
            else
              ast-sp @ 1- ast-sp !
              false ast-alive !
              true ast-done !
            then
          then
        then
      repeat
      ast-alive @ if
        ast-cur @ ast-sp @ cells ast-stk + !  ast-sp @ 1+ ast-sp !
      then
    then
  loop
  ast-sp @ ;

\ === paste your solution above this line ===

T{ asteroid-survive -> 2 }T

report bye
