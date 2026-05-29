\ tests/challenges/126-list-partition.fs
\
\ CHALLENGE: Partition List
\ Source: leetcode  https://leetcode.com/problems/partition-list/
\ Cognitive: 6/10  |  Pattern: linked-list-partition
\
\ Define a word
\
\   : part-list  ( head pivot -- lo-head )
\
\ Partition list so values < pivot come before others; return lo-head index.
\ Stable relative order within parts.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - In-place index links.
\   - Uses LINK scaffold.
\   - scaffold data is read-only for tests — do not mutate fixtures
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
12 constant ch-max-nodes
create ch-vals  ch-max-nodes cells allot
create ch-nexts ch-max-nodes cells allot

: ch-val@  ( i -- n )  cells ch-vals + @ ;
: ch-next@ ( i -- n )  cells ch-nexts + @ ;
: ch-val!  ( n i -- )  swap cells ch-vals + ! ;
: ch-next! ( n i -- )  swap cells ch-nexts + ! ;
1 1 1 ch-val! 4 ch-next!
4 4 4 ch-val! 3 ch-next!
3 3 3 ch-val! 2 ch-next!
2 2 2 ch-val! 5 ch-next!
5 5 5 ch-val! 0 ch-next!
1 constant ch-head

\ === paste your solution below this line ===

10 constant lo-sent
11 constant hi-sent

variable part-pivot
variable part-cur
variable part-next
variable lo-tail
variable hi-tail

: lo-append  ( i -- )
  dup lo-tail @ swap ch-next!
  lo-tail ! ;

: hi-append  ( i -- )
  dup hi-tail @ swap ch-next!
  hi-tail ! ;

: part-list  ( head pivot -- lo-head )
  part-pivot !
  part-cur !
  lo-sent lo-tail !
  hi-sent hi-tail !
  0 lo-sent ch-next!
  0 hi-sent ch-next!
  begin  part-cur @ dup  while
    dup ch-next@ part-next !
    dup ch-val@ part-pivot @ <
    if  dup lo-append  else  dup hi-append  then
    drop
    part-next @ part-cur !
  repeat  drop
  0 hi-tail @ ch-next!
  hi-sent ch-next@ lo-tail @ swap ch-next!
  lo-sent ch-next@ ;

\ === paste your solution above this line ===

T{ 1 3 part-list -> 1 }T
T{ 1 ch-next@ -> 2 }T

report bye
