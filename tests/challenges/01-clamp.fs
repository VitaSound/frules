\ tests/challenges/01-clamp.fs
\
\ CHALLENGE: clamp(n, lo, hi)
\
\ Define a word
\
\   : clamp  ( n lo hi -- n' )
\
\ that returns n forced into the closed range [lo .. hi]:
\   n < lo  -> lo
\   n > hi  -> hi
\   else    -> n
\
\ You may assume lo <= hi.
\
\ Style guard (rules/forth-style.mdc, rules/forth-anti-patterns.mdc):
\   - keep the live stack within ~3 items; if you need 4, use Gforth locals;
\   - no PICK / no ROLL;
\   - one-liner is fine, but every named subword should still have a
\     stack-effect comment.

include _tester.fs

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{    5  0 10 clamp ->  5 }T
T{   -3  0 10 clamp ->  0 }T
T{   42  0 10 clamp -> 10 }T
T{    0  0 10 clamp ->  0 }T
T{   10  0 10 clamp -> 10 }T
T{  100 50 60 clamp -> 60 }T
T{  -50 -10 10 clamp -> -10 }T

report bye
