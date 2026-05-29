\ tests/challenges/134-edit-distance.fs
\
\ CHALLENGE: Edit Distance
\ Source: leetcode  https://leetcode.com/problems/edit-distance/
\ Cognitive: 7/10  |  Pattern: levenshtein-distance
\
\ Define a word
\
\   : edit-dist  ( a-addr a-u b-addr b-u -- d )
\
\ Return minimum edit distance between two strings (insert/delete/replace).
\ Use two ch-setup buffers.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - 2D DP table.
\   - Addresses on stack before call.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
create ch-buf 64 chars allot

: ch-setup  ( c-addr u -- ch-buf u )
  dup >r  ch-buf swap  move  ch-buf r> ;
create ed-a 32 chars allot
create ed-b 32 chars allot
: ed-a-setup ( c-addr u -- ed-a u )  dup >r ed-a swap move ed-a r> ;
: ed-b-setup ( c-addr u -- ed-b u )  dup >r ed-b swap move ed-b r> ;

\ === paste your solution below this line ===

\ Avoid ed-a-* / ed-b-* names: hyphen splits after create ed-a / ed-b.
33 constant ed-max
create edtbl  ed-max ed-max * cells allot

variable ea-addr
variable ea-len
variable eb-addr
variable eb-len
variable edcols

: ed@  ( row col -- n )
  { row col }  row edcols @ * col + cells edtbl + @ ;

: ed!  ( n row col -- )
  { n row col }  row edcols @ * col + cells edtbl + n swap ! ;

: ed-cost  ( row col -- c )
  { row col }
  row 1- ea-addr @ + c@
  col 1- eb-addr @ + c@
  = if  0  else  1  then ;

: ed-init  ( -- )
  eb-len @ 1+ edcols !
  edcols @ 0 ?do  i 0 i ed!  loop
  ea-len @ 1+ 0 ?do  i i 0 ed!  loop ;

variable ed-row
variable ed-col

: ed-fill  ( -- )
  1 ed-row !
  begin  ed-row @ ea-len @ 1+ <  while
    1 ed-col !
    begin  ed-col @ eb-len @ 1+ <  while
      ed-row @ ed-col @ ed-cost >r
      ed-row @ 1- ed-col @ ed@ 1+
      ed-row @ ed-col @ 1- ed@ 1+
      r> ed-row @ 1- ed-col @ 1- ed@ +
      min min  ed-row @ ed-col @ ed!
      ed-col @ 1+ ed-col !
    repeat
    ed-row @ 1+ ed-row !
  repeat ;

: edit-dist  ( a-addr a-u b-addr b-u -- d )
  { a u1 b u2 }
  u2 eb-len !
  u1 ea-len !
  b eb-addr !
  a ea-addr !
  ed-init  ed-fill
  ea-len @ eb-len @ ed@ ;

\ === paste your solution above this line ===

T{ s" horse" ed-a-setup s" ros" ed-b-setup edit-dist -> 3 }T
T{ s" " ed-a-setup s" a" ed-b-setup edit-dist -> 1 }T
T{ s" abc" ed-a-setup s" abc" ed-b-setup edit-dist -> 0 }T

report bye
