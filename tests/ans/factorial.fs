\ tests/ans/factorial.fs — recursive factorial, pure stack contract.
\ Exercises: stack picture, RECURSE, base case, no magic state.

include _tester.fs

: factorial  ( n -- n! )
  dup 1 <= if drop 1 exit then
  dup 1- recurse * ;

T{ 0 factorial ->    1 }T
T{ 1 factorial ->    1 }T
T{ 5 factorial ->  120 }T
T{ 7 factorial -> 5040 }T

report bye
