\ tests/challenges/144-holder.fs
include _tester.fs

\ === paste your solution below this line ===

: holder ( n "name" -- )  create , does> @ ;
42 holder box-a

\ === paste your solution above this line ===

T{ box-a -> 42 }T

report bye
