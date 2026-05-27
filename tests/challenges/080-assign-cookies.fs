\ tests/challenges/080-assign-cookies.fs
\
\ CHALLENGE: Assign Cookies
\ Source: leetcode  https://leetcode.com/problems/assign-cookies/
\ Cognitive: 4/10  |  Pattern: assign-cookies-greedy
\
\ Define a word
\
\   : assign-cookies  ( -- count )
\
\ Maximize children content with cookie sizes; ch-g and ch-s segments preloaded.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Sort and two-pointer.
\   - Return count satisfied.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
1 0 ch!  2 1 ch!  3 2 ch!
1 3 ch!  1 4 ch!
5 constant ch-n
3 constant ch-g-len

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ assign-cookies -> 2 }T

report bye
