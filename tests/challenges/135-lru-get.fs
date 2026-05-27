\ tests/challenges/135-lru-get.fs
\
\ CHALLENGE: LRU Get
\ Source: leetcode  https://leetcode.com/problems/lru-cache/
\ Cognitive: 7/10  |  Pattern: lru-cache-get
\
\ Define a word
\
\   : lru-get  ( key -- val flag )
\
\ Return value and TRUE if key in fixed LRU (capacity 3) after sequence of puts in scaffold.
\ Companion words lru-put in scaffold.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Doubly-linked + hash table.
\   - Tests call lru-get only.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
16 constant ch-max
create ch-data ch-max cells allot

: ch@  ( i -- n )  cells ch-data + @ ;
: ch!  ( n i -- )  cells ch-data + ! ;
: lru-init ( -- ) ;
: lru-put ( key val -- ) ;
lru-init  1 1 lru-put  2 2 lru-put  1 3 lru-put

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 2 lru-get -> 2 true }T
T{ 3 lru-get -> false }T

report bye
