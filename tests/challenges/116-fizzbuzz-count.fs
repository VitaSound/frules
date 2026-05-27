\ tests/challenges/116-fizzbuzz-count.fs
\
\ CHALLENGE: FizzBuzz Count
\ Source: rosetta  https://rosettacode.org/wiki/FizzBuzz
\ Cognitive: 2/10  |  Pattern: fizzbuzz-line-count
\
\ Define a word
\
\   : fizzbuzz-n  ( n -- count )
\
\ Return count of numbers 1..n matching fizz OR buzz (not both double-count).
\ Benchmark returns match count.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Simple loop.
\   - n on stack.
\
include _tester.fs

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ 15 fizzbuzz-n -> 7 }T
T{ 30 fizzbuzz-n -> 14 }T
T{ 1 fizzbuzz-n -> 0 }T

report bye
