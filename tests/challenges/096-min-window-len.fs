\ tests/challenges/096-min-window-len.fs
\
\ CHALLENGE: Minimum Window Substring
\ Source: leetcode  https://leetcode.com/problems/minimum-window-substring/
\ Cognitive: 9/10  |  Pattern: minimum-window-substring
\
\ Define a word
\
\   : min-window  ( s-addr su t-addr tu -- len )
\
\ Return length of smallest window in s containing all chars of t.
\ Return 0 if none.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Sliding window with counts.
\   - Both strings via ch-setup.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
create ch-buf 64 chars allot

: ch-setup  ( c-addr u -- ch-buf u )
  dup >r  ch-buf swap  move  ch-buf r> ;

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ s" ADOBECODEBANC" ch-setup s" ABC" ch-setup min-window -> 4 }T
T{ s" a" ch-setup s" a" ch-setup min-window -> 1 }T
T{ s" a" ch-setup s" aa" ch-setup min-window -> 0 }T

report bye
