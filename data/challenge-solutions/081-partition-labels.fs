\ tests/challenges/081-partition-labels.fs
\
\ CHALLENGE: Partition Labels
\ Source: leetcode  https://leetcode.com/problems/partition-labels/
\ Cognitive: 5/10  |  Pattern: partition-labels-count
\
\ Define a word
\
\   : part-labels-len  ( c-addr u -- len )
\
\ Return count of partition sizes as single number for benchmark (product or sum per spec: return part count).
\ Return number of parts needed.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Greedy last occurrence.
\   - Use ch-setup.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
create ch-buf 64 chars allot

: ch-setup  ( c-addr u -- ch-buf u )
  dup >r  ch-buf swap  move  ch-buf r> ;

\ === paste your solution below this line ===

128 constant ch-alpha
create ch-last  ch-alpha cells allot

variable part-c
variable part-u
variable part-pos
variable part-end
variable part-n

: last! ( char idx -- )  swap  cells ch-last + ! ;
: last@ ( char -- idx )  cells ch-last + @ ;

: clear-last ( -- )
  ch-alpha 0 ?do  i -1 last!  loop ;

: part-labels-len ( c-addr u -- count )
  dup part-u !  swap part-c !
  clear-last
  0 part-pos !
  begin  part-pos @  part-u @  <
  while
    part-c @ part-pos @ + c@  part-pos @ last!
    part-pos @ 1+ part-pos !
  repeat
  0 part-pos !  0 part-end !  0 part-n !
  begin  part-pos @  part-u @  <
  while
    part-c @ part-pos @ + c@  last@
    part-end @ max  part-end !
    part-pos @ part-end @ = if  part-n @ 1+ part-n !  then
    part-pos @ 1+ part-pos !
  repeat
  begin  depth  while  drop  repeat
  part-n @ ;

\ === paste your solution above this line ===

T{ s" ababcbacadefegdehijhklij" ch-setup part-labels-len -> 3 }T
T{ s" eccbbbbdec" ch-setup part-labels-len -> 1 }T

report bye
