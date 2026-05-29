\ tests/challenges/143-expect-match.fs
\
\ CHALLENGE: Expected Value Match
\ Source: rosetta  https://rosettacode.org/wiki/Assertions
\ Cognitive: 2/10  |  Pattern: expected-value-assert
\
\ Define a word
\
\   : matches?  ( n -- flag )
\
\ Return TRUE iff n equals the value stored by expect! (Rosetta assert pattern).
\ expect! is provided in scaffold; do not abort — return flag for T{ }T.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Compare to variable.
\   - Prefer Gforth assert( ) in real code — see forth-debugging.mdc.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
variable expect-val
: expect! ( n -- )  expect-val ! ;

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 42 expect!  42 matches? -> true }T
T{ 42 expect!  7 matches? -> false }T
T{ 0 expect!  0 matches? -> true }T

report bye
