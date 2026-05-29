\ tests/challenges/140-dict-list-push.fs
\
\ CHALLENGE: Dictionary Linked Push
\ Source: rosetta  https://rosettacode.org/wiki/Singly-linked_list/Element_definition
\ Cognitive: 4/10  |  Pattern: dictionary-linked-list-push
\
\ Define a word
\
\   : dict-push  ( n -- )
\
\ Push n onto a dictionary-linked list headed by list-head (Rosetta push idiom).
\ Each node: link cell then value cell; list-head points to newest node.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Use HERE and , ,.
\   - Implement list-sum to verify.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
0 value list-head
: list-reset ( -- )  0 to list-head ;

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ list-reset  1 dict-push 2 dict-push 3 dict-push  list-sum -> 6 }T
T{ list-reset  list-sum -> 0 }T
T{ list-reset  10 dict-push  list-sum -> 10 }T

report bye
