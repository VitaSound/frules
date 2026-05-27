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

\ === paste your solution above this line ===

T{ s" ababcbacadefegdehijhklij" ch-setup part-labels-len -> 3 }T
T{ s" eccbbbbdec" ch-setup part-labels-len -> 2 }T

report bye
