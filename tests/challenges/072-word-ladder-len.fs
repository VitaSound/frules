\ tests/challenges/072-word-ladder-len.fs
\
\ CHALLENGE: Word Ladder Length
\ Source: leetcode  https://leetcode.com/problems/word-ladder/
\ Cognitive: 9/10  |  Pattern: word-ladder-length
\
\ Define a word
\
\   : ladder-len  ( -- len )
\
\ Return shortest transformation length from ch-start to ch-end using ch-wordlist.
\ One letter change per step; each step word must appear in ch-wordlist (begin may not).
\ Return 0 if no path.
\
\ Style guard (rules/forth-factoring.mdc, forth-style.mdc):
\   - BFS on implicit graph.
\   - Preload start/end strings.
\
\ Fixed: shared ch-buf overwrote start/end; separate start-buf, end-buf, ch-wordlist.
\
include _tester.fs

\ --- scaffold (buffers / arrays / lists only) ---
create start-buf 16 chars allot
create end-buf 16 chars allot
create ch-wordlist 64 chars allot
variable ch-start-u
variable ch-end-u
variable ch-wordlist-u

: start-setup  ( c-addr u -- start-buf u )
  dup >r  start-buf swap  move  start-buf r> ;
: end-setup  ( c-addr u -- end-buf u )
  dup >r  end-buf swap  move  end-buf r> ;
: wordlist-setup  ( c-addr u -- ch-wordlist u )
  dup >r  ch-wordlist swap  move  ch-wordlist r> ;

start-buf constant ch-start
end-buf constant ch-end

: save-start-u  ( start-buf u -- )  tuck ch-start-u !  drop ;
: save-end-u  ( end-buf u -- )  tuck ch-end-u !  drop ;
: save-wordlist-u  ( ch-wordlist u -- )  tuck ch-wordlist-u !  drop ;

s" hit" start-setup save-start-u drop
s" cog" end-setup save-end-u drop
s" hot dot dog lot log cog" wordlist-setup save-wordlist-u drop

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ ladder-len -> 5 }T

report bye
