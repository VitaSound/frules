\ tests/challenges/142-sq-brackets.fs
\
\ CHALLENGE: Square Bracket Balance
\ Source: rosetta  https://rosettacode.org/wiki/Balanced_brackets
\ Cognitive: 4/10  |  Pattern: square-bracket-balance
\
\ Define a word
\
\   : sq-brackets?  ( c-addr u -- flag )
\
\ Return TRUE iff `[` and `]` are balanced (Rosetta variant; square only).
\ Other characters are ignored. Empty string is balanced.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Running depth counter.
\   - Use ch-setup for string tests.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
create ch-buf 64 chars allot

: ch-setup  ( c-addr u -- ch-buf u )
  dup >r  ch-buf swap  move  ch-buf r> ;

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ s" " ch-setup sq-brackets? -> true }T
T{ s" []" ch-setup sq-brackets? -> true }T
T{ s" [[]]" ch-setup sq-brackets? -> true }T
T{ s" [[]" ch-setup sq-brackets? -> false }T
T{ s" ][ " ch-setup sq-brackets? -> false }T

report bye
