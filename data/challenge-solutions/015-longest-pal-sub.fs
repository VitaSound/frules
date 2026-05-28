\ tests/challenges/015-longest-pal-sub.fs
\
\ CHALLENGE: Longest Palindrome Length
\ Source: leetcode  https://leetcode.com/problems/longest-palindromic-substring/
\ Cognitive: 6/10  |  Pattern: longest-palindrome-substring-len
\
\ Define a word
\
\   : longest-pal-len  ( c-addr u -- len )
\
\ Return length of longest palindromic substring.
\ Single char counts as length 1.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - Expand-around-center or DP.
\   - Use ch-setup.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
create ch-buf 64 chars allot

: ch-setup  ( c-addr u -- ch-buf u )
  dup >r  ch-buf swap  move  ch-buf r> ;

\ === paste your solution below this line ===

\ Expand-around-center: for each center grow outward while the mirrored
\ characters match, then report the widest span seen.
: pal-at  ( c-addr u l r -- len )
  { c u l r }
  begin
    l 0 >=  r u <  and
    dup if  drop  c l + c@  c r + c@  =  then   \ compare only when in range
  while
    l 1- to l
    r 1+ to r
  repeat
  r l - 1- ;

: longest-pal-len  ( c-addr u -- len )
  0 0  { c u best p }
  begin p u < while
    c u p p     pal-at  best max to best     \ odd-length center
    p 1+ u < if  c u p p 1+ pal-at  best max to best  then  \ even-length center
    p 1+ to p
  repeat
  best ;

\ === paste your solution above this line ===

T{ s" babad" ch-setup longest-pal-len -> 3 }T
T{ s" cbbd" ch-setup longest-pal-len -> 2 }T
T{ s" a" ch-setup longest-pal-len -> 1 }T
T{ s" racecar" ch-setup longest-pal-len -> 7 }T

report bye
