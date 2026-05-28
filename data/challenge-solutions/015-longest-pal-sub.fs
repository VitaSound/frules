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

: pal-at ( c-addr u l r -- n )
  { c u l r | left right }
  l to left
  r to right
  begin
    left 0>=  right u <  and
    left c + c@  right c + c@  =
    and
  while
    1 left - to left
    1 right + to right
  repeat
  right left - 1- ;

: longest-pal-len ( c-addr u -- len )
  { c u | best n }
  0 to best
  u 0 ?do
    c u i i pal-at to n
    n best max to best
    i 1+ u < if
      c u i i 1+ pal-at to n
      n best max to best
    then
  loop
  best ;

: longest-pal-len-stack ( c-addr u -- len )
  >r 0 >r
  r@ 0 ?do
    r@ i i 3 pick pal-at  r> max >r
    i 1+ r@ < if
      r@ i i 1+ 3 pick pal-at  r> max >r
    then
  loop
  r> r> swap drop ;

\ === paste your solution above this line ===

T{ s" babad" ch-setup longest-pal-len -> 3 }T
T{ s" cbbd" ch-setup longest-pal-len -> 2 }T
T{ s" a" ch-setup longest-pal-len -> 1 }T
T{ s" racecar" ch-setup longest-pal-len -> 7 }T

T{ s" babad" ch-setup longest-pal-len-stack -> 3 }T
T{ s" cbbd" ch-setup longest-pal-len-stack -> 2 }T
T{ s" a" ch-setup longest-pal-len-stack -> 1 }T
T{ s" racecar" ch-setup longest-pal-len-stack -> 7 }T

report bye
