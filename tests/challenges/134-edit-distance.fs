\ tests/challenges/134-edit-distance.fs
\
\ CHALLENGE: Edit Distance
\ Source: leetcode  https://leetcode.com/problems/edit-distance/
\ Cognitive: 7/10  |  Pattern: levenshtein-distance
\
\ Define a word
\
\   : edit-dist  ( a-addr a-u b-addr b-u -- d )
\
\ Return minimum edit distance between two strings (insert/delete/replace).
\ Use two ch-setup buffers.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - 2D DP table.
\   - Addresses on stack before call.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
create ch-buf 64 chars allot

: ch-setup  ( c-addr u -- ch-buf u )
  dup >r  ch-buf swap  move  ch-buf r> ;
create ed-a 32 chars allot
create ed-b 32 chars allot
: ed-a-setup ( c-addr u -- ed-a u )  dup >r ed-a swap move ed-a r> ;
: ed-b-setup ( c-addr u -- ed-b u )  dup >r ed-b swap move ed-b r> ;

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ s" horse" ed-a-setup s" ros" ed-b-setup edit-dist -> 3 }T
T{ s" " ed-a-setup s" a" ed-b-setup edit-dist -> 1 }T
T{ s" abc" ed-a-setup s" abc" ed-b-setup edit-dist -> 0 }T

report bye
