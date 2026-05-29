\ tests/challenges/144-holder.fs
\
\ CHALLENGE: Holder Defining Word
\ Source: rosetta  https://rosettacode.org/wiki/Classes
\ Cognitive: 5/10  |  Pattern: create-does-fetch-constant
\
\ Define a word
\
\   : holder  ( n "name" -- )
\
\ Define parsing word holder ( n "name" -- ) using CREATE , DOES> @.
\ In solution zone after holder, compile: 42 holder box-a
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - CREATE/DOES> instance data.
\   - Rosetta Classes substitute — no ;class OOP.
\
include _tester.fs

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ box-a -> 42 }T

report bye
