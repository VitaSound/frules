\ tests/challenges/140-dict-list-push.fs
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
0 value list-head
: list-reset ( -- )  0 to list-head ;

\ === paste your solution below this line ===

: dict-push ( n -- )
  here swap list-head , , to list-head ;

: list-sum ( -- sum )
  0 { acc# }
  list-head
  begin dup while
    dup cell+ @ acc# + to acc#
    @
  repeat drop
  acc# ;

\ === paste your solution above this line ===

T{ list-reset  1 dict-push 2 dict-push 3 dict-push  list-sum -> 6 }T
T{ list-reset  list-sum -> 0 }T
T{ list-reset  10 dict-push  list-sum -> 10 }T

report bye
