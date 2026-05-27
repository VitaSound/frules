\ tests/challenges/077-max-profit.fs
\
\ CHALLENGE: Best Time Stock
\ Source: leetcode  https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
\ Cognitive: 4/10  |  Pattern: best-time-buy-sell-stock
\
\ Define a word
\
\   : max-profit  ( -- profit )
\
\ Return max profit from one buy/sell using daily prices in ch-data.
\ Must buy before sell.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Track min price so far.
\   - Single pass.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
7 0 ch!  1 1 ch!  5 2 ch!  3 3 ch!  6 4 ch!  4 5 ch!
6 constant ch-n

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ max-profit -> 5 }T

report bye
