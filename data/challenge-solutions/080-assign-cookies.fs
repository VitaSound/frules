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

create work-c  ch-max cells allot
create work-g  ch-max cells allot

: wc@ ( i -- n )  cells work-c + @ ;
: wc! ( n i -- )  tuck cells work-c + ! ;
: wg@ ( i -- n )  cells work-g + @ ;
: wg! ( n i -- )  tuck cells work-g + ! ;

variable cook-n
variable child-n

: load-cooks ( -- )
  ch-g-len cook-n !
  cook-n @ 0 ?do  i ch@ i wc!  loop ;

: load-child ( -- )
  ch-n ch-g-len - child-n !
  child-n @ 0 ?do  ch-g-len i + ch@ i wg!  loop ;

: sort-wc ( n -- )
  { n }
  1 begin
    dup n <
    if
      dup 1- { j }
      begin  j 0> while
        j wc@  j 1- wc@  <
        if  j wc@  j 1- wc@  j wc!  j 1- wc!
          j 1- j wc@  j wc!
        else  drop
        then
        j 1- to j
      repeat
      1+
    else  drop  exit
    then
  again ;

: sort-wg ( n -- )
  { n }
  1 begin
    dup n <
    if
      dup 1- { j }
      begin  j 0> while
        j wg@  j 1- wg@  <
        if  j wg@  j 1- wg@  j wg!  j 1- wg!
          j 1- j wg@  j wg!
        else  drop
        then
        j 1- to j
      repeat
      1+
    else  drop  exit
    then
  again ;

variable assign-ci
variable assign-gi
variable assign-cnt

: assign-greedy ( -- count )
  0 assign-ci !  0 assign-gi !  0 assign-cnt !
  begin  assign-gi @ child-n @ < assign-ci @ cook-n @ < and  while
    assign-gi @ wg@  assign-ci @ wc@  <=
    if  assign-cnt @ 1+ assign-cnt !
      assign-gi @ 1+ assign-gi !  assign-ci @ 1+ assign-ci !
    else  assign-ci @ 1+ assign-ci !
    then
  repeat
  assign-cnt @ ;

: assign-cookies ( -- count )
  load-cooks  cook-n @ sort-wc
  load-child  child-n @ sort-wg
  begin  depth  while  drop  repeat
  assign-greedy ;

\ === paste your solution above this line ===

T{ assign-cookies -> 2 }T

report bye
