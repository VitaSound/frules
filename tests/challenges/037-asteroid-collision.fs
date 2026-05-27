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

\ === paste your solution above this line ===

T{ asteroid-survive -> 1 }T

report bye
