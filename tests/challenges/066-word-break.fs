\ tests/challenges/066-word-break.fs
\
\ CHALLENGE: Word Break
\ Source: leetcode  https://leetcode.com/problems/word-break/
\ Cognitive: 6/10  |  Pattern: word-break-dictionary
\
\ Define a word
\
\   : word-break?  ( c-addr u -- flag )
\
\ Return TRUE if string can be segmented into space-separated dictionary words.
\ Dictionary in ch-dict helper.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - DP over positions.
\   - Use ch-setup.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
create ch-buf 64 chars allot

: ch-setup  ( c-addr u -- ch-buf u )
  dup >r  ch-buf swap  move  ch-buf r> ;
create ch-dict
s" leet code apple pen" ch-setup drop

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ s" leetcode" ch-setup word-break? -> true }T
T{ s" applepen" ch-setup word-break? -> true }T
T{ s" catsandog" ch-setup word-break? -> false }T

report bye
