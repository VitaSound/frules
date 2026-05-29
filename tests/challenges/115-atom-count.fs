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
\ Two-letter symbols count 2; depth-0 digits multiply; in groups digits add w+n;
\ group multiplier after ) at depth 1 only; nested groups use ac-save2.
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

\ === paste your solution above this line ===

T{ s" H2O" ch-setup atom-count -> 3 }T
T{ s" Mg(OH)2" ch-setup atom-count -> 6 }T
T{ s" K4(ON(SO3)2)2" ch-setup atom-count -> 18 }T

report bye
