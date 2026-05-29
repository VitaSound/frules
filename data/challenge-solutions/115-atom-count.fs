\ tests/challenges/115-atom-count.fs
\
\ CHALLENGE: Number of Atoms Count
\ Source: leetcode  https://leetcode.com/problems/number-of-atoms/
\ Cognitive: 7/10  |  Pattern: number-of-atoms-count
\
\ Define a word
\
\   : atom-count  ( c-addr u -- n )
\
\ Return total atom count from chemical formula (uppercase element + optional digits).
\ Two-letter symbols count 2; depth-0 digits multiply; in groups digits add;
\ group multiplier after ) applies only at depth 1.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Stack parser.
\   - Use ch-setup.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
create ch-buf 64 chars allot

: ch-setup  ( c-addr u -- ch-buf u )
  dup >r  ch-buf swap  move  ch-buf r> ;

\ === paste your solution below this line ===

variable ac-buf
variable ac-len
variable ac-pos
variable ac-sum
variable ac-dep
variable ac-num
variable ac-tmp
variable ac-save
variable ac-save2

40 constant ch-lparen
41 constant ch-rparen

: ac-upper?  ( ch -- f )
  dup [char] A [char] Z 1+ within  nip ;

: ac-digit?  ( ch -- f )
  dup [char] 0 [char] : within  nip ;

: ac-peek  ( -- ch )
  ac-buf @ ac-pos @ + c@ ;

: ac-advance  ( -- )
  ac-pos @ 1+ ac-pos ! ;

: ac-more?  ( -- f )
  ac-pos @ ac-len @ < ;

: ac-read-num  ( -- n )
  0 ac-num !
  begin
    ac-more? if
      ac-peek ac-digit?
    else
      0
    then
  while
    ac-peek [char] 0 -
    ac-num @ 10 * + ac-num !
    ac-advance
  repeat
  ac-num @ dup 0= if  drop 1  then ;

: ac-lower?  ( ch -- f )
  dup [char] a [char] z 1+ within  nip ;

: ac-second-lower?  ( -- f )
  ac-pos @ ac-len @ < if
    ac-buf @ ac-pos @ + c@ ac-lower?
  else
    0
  then ;

: ac-elem-weight  ( -- w )
  ac-peek ac-advance drop
  ac-second-lower? if
    ac-advance  2
  else
    1
  then ;

: ac-apply  ( w n -- )
  ac-dep @ 0= if
    ac-sum @ ac-tmp !
    *
    ac-tmp @ + ac-sum !
  else
    ac-sum @ ac-tmp !
    swap +  ac-tmp @ +  ac-sum !
  then ;

: ac-add-elem  ( -- )
  ac-elem-weight  ac-more? if
    ac-peek ac-digit? if
      ac-read-num ac-apply
    else
      ac-sum @ + ac-sum !
    then
  else
    ac-sum @ + ac-sum !
  then ;

: ac-open  ( -- )
  ac-advance
  ac-dep @ 1 = if  ac-save @ ac-save2 !  then
  ac-sum @ ac-save !
  0 ac-sum !  ac-dep @ 1+ ac-dep ! ;

: ac-close  ( -- )
  ac-advance
  ac-dep @ 2 = if
    ac-dep @ 1- ac-dep !
  else  ac-dep @ 1 = if
    ac-sum @ ac-read-num * ac-sum !
    ac-dep @ 1- ac-dep !
  else
    ac-dep @ 1- ac-dep !
  then  then
  ac-save @ ac-sum @ + ac-sum !
  0 ac-save !
  ac-dep @ 1 = if  ac-save2 @ ac-save !  then ;

: ac-step  ( -- )
  ac-peek  dup ch-rparen = if
    drop  ac-close
  else  dup ch-lparen = if
    drop  ac-open
  else  dup ac-upper? if
    drop  ac-add-elem
  else
    drop  ac-advance
  then  then  then ;

: atom-count  ( c-addr u -- n )
  ac-len !  ac-buf !
  0 ac-pos !  0 ac-sum !  0 ac-dep !
  begin  ac-more? while  ac-step  repeat
  ac-sum @ ;

\ === paste your solution above this line ===

T{ s" H2O" ch-setup atom-count -> 3 }T
T{ s" Mg(OH)2" ch-setup atom-count -> 6 }T
T{ s" K4(ON(SO3)2)2" ch-setup atom-count -> 18 }T

report bye
