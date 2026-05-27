\ tests/challenges/010-string-to-int.fs
\
\ CHALLENGE: String to Integer
\ Source: leetcode  https://leetcode.com/problems/string-to-integer-atoi/
\ Cognitive: 5/10  |  Pattern: string-to-integer-parse
\
\ Define a word
\
\   : atoi  ( c-addr u -- n )
\
\ Parse optional leading sign and digits into signed cell.
\ Stop at first non-digit; non-digit start -> 0.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Use ch-setup in tests.
\   - Clamp overflow to cell limits for benchmark.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
create ch-buf 64 chars allot

: ch-setup  ( c-addr u -- ch-buf u )
  dup >r  ch-buf swap  move  ch-buf r> ;

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ s" 42" ch-setup atoi -> 42 }T
T{ s"   -7" ch-setup atoi -> -7 }T
T{ s" 4193abc" ch-setup atoi -> 4193 }T
T{ s" abc" ch-setup atoi -> 0 }T
T{ s" +12" ch-setup atoi -> 12 }T

report bye
