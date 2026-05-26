\ tests/challenges/02-min-max.fs
\
\ CHALLENGE: min-max
\
\ Define a word
\
\   : min-max  ( n1 n2 -- min max )
\
\ that returns both extremes of two signed cells, with the smaller value
\ underneath and the larger on top.
\
\ Style guard:
\   - one definition, no helper variables;
\   - do not call MIN twice or MAX twice (factor the comparison once);
\   - keep stack depth <= 3 inside the body.

include _tester.fs

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{   3  7 min-max ->   3   7 }T
T{   7  3 min-max ->   3   7 }T
T{   5  5 min-max ->   5   5 }T
T{  -2  8 min-max ->  -2   8 }T
T{   0 -1 min-max ->  -1   0 }T
T{ -10 -3 min-max -> -10  -3 }T

report bye
