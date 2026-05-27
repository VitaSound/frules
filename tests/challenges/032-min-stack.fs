\ tests/challenges/032-min-stack.fs
\
\ CHALLENGE: Min Stack Push
\ Source: leetcode  https://leetcode.com/problems/min-stack/
\ Cognitive: 5/10  |  Pattern: min-stack-push
\
\ Define a word
\
\   : min-push  ( n -- )
\
\ Push n onto internal stack; companion word min-top returns current minimum.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Implement min-push and min-top.
\   - Use ch-data as stack with ch-sp index.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
variable ch-sp
0 ch-sp !
: min-top ( -- n ) ch-sp @ 1- ch@ ;

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 1 min-push 0 min-push -1 min-push min-top -> -1 }T
T{ 2 min-push min-top -> -1 }T

report bye
