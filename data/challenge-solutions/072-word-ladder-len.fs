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

: save-start-u  ( start-buf u -- )  nip ch-start-u ! ;
: save-end-u  ( end-buf u -- )  nip ch-end-u ! ;
: save-wordlist-u  ( ch-wordlist u -- )  nip ch-wordlist-u ! ;

s" hit" start-setup save-start-u
s" cog" end-setup save-end-u
s" hot dot dog lot log cog" wordlist-setup save-wordlist-u

\ === paste your solution below this line ===

32 constant wl-max-words
create wl-off  wl-max-words cells allot
create wl-len  wl-max-words cells allot
variable wl-nw

64 constant wl-q-max
create wl-q-idx  wl-q-max cells allot
create wl-q-dep  wl-q-max cells allot
variable wl-q-in
variable wl-q-out

create wl-vis  wl-max-words cells allot

: wl-off!  ( off idx -- )  cells wl-off + ! ;
: wl-len!  ( len idx -- )  cells wl-len + ! ;
: wl-off@  ( idx -- off )  cells wl-off + @ ;
: wl-len@  ( idx -- len )  cells wl-len + @ ;

: wl-word  ( idx -- c-addr u )
  dup wl-off@ ch-wordlist +  swap wl-len@ ;

: wl-vis@  ( idx -- f )  cells wl-vis + @ ;
: wl-vis!  ( f idx -- )  cells wl-vis + ! ;

: wl-q-clear  ( -- )  0 wl-q-in !  0 wl-q-out ! ;

: wl-q-count  ( -- n )
  wl-q-in @ wl-q-out @  2dup =
  if  2drop 0
  else  2dup > if  -  else  wl-q-max swap - wl-q-in @ +  then
  then ;

: wl-q-idx!  ( idx slot -- )  cells wl-q-idx + ! ;
: wl-q-dep!  ( dep slot -- )  cells wl-q-dep + ! ;
: wl-q-idx@  ( slot -- idx )  cells wl-q-idx + @ ;
: wl-q-dep@  ( slot -- dep )  cells wl-q-dep + @ ;

variable wl-slot

\ ( idx dep -- )  Gforth { dep word-idx }: top=dep, next=word-idx
: wl-q-enq  ( idx dep -- )
  { word-idx dep }
  wl-q-in @ wl-slot !
  word-idx wl-slot @ wl-q-idx!
  dep wl-slot @ wl-q-dep!
  wl-slot @ 1+ dup wl-q-max = if drop 0 then wl-q-in ! ;

: wl-q-deq  ( -- idx dep )
  wl-q-out @ >r
  r@ wl-q-idx@
  r@ wl-q-dep@
  r> 1+ dup wl-q-max = if drop 0 then wl-q-out ! ;

: wl-add-word  ( c-addr u -- )
  wl-nw @ >r
  r@ wl-max-words >= if  r> 2drop exit  then
  tuck r@ wl-len!
  nip ch-wordlist - r@ wl-off!
  r> 1+ wl-nw ! ;

variable wl-pos
variable wl-beg

: wl-init-words  ( -- )
  0 wl-nw !  0 wl-pos !
  begin
    wl-pos @  ch-wordlist-u @ >=  if  exit  then
    wl-pos @  ch-wordlist +  c@  bl <>
    if
      wl-pos @  wl-beg !
      wl-pos @  1+  wl-pos !
      begin
        wl-pos @  ch-wordlist-u @ <
        wl-pos @  ch-wordlist +  c@  bl <>  and
      while
        wl-pos @  1+  wl-pos !
      repeat
      wl-pos @  wl-beg @  -
      wl-beg @  ch-wordlist +  swap  wl-add-word
    else
      wl-pos @  1+  wl-pos !
    then
  again ;

: wl-one-diff  ( a1 u a2 -- flag )
  { a2 u a1 | n }
  0 to n
  u 0 do
    a1 i + c@  a2 i + c@  <> if  1 n + to n  then
  loop
  n 1 = ;

: wl-matches-end  ( c-addr u -- flag )
  2dup ch-end ch-end-u @ compare 0=  >r  2drop  r> ;

variable wl-cur
variable wl-cu
variable wl-wave
variable wl-found

: wl-vis-clear  ( -- )
  wl-nw @ 0  ?do  0  i  wl-vis!  loop ;

variable wl-dep

: wl-try-idx  ( idx -- )
  >r
  r@ wl-vis@ 0= if
    wl-cur @ wl-cu @  r@ wl-word drop  wl-one-diff if
      wl-wave @ 1+ wl-dep !
      r@ wl-word wl-matches-end if
        wl-dep @ wl-found !
      else
        r@ 1 wl-vis!  r@ wl-dep @ wl-q-enq
      then
    then
  then  r> drop ;

: wl-expand  ( -- )
  wl-nw @ 0  ?do  i wl-try-idx  loop ;

: wl-deq-step  ( -- )
  wl-q-deq  swap >r wl-wave !  r> wl-word  tuck wl-cu !  nip wl-cur ! ;

: wl-process-queue  ( -- )
  wl-q-count 0  ?do
    wl-deq-step
    wl-cur @ wl-cu @ wl-matches-end if
      wl-wave @ wl-found !
    else
      wl-expand
    then
  loop ;

: ladder-len  ( -- len )
  wl-init-words
  wl-vis-clear
  wl-q-clear
  0 wl-found !
  ch-start ch-start-u @ wl-matches-end if
    1
  else
    ch-start wl-cur !  ch-start-u @ wl-cu !
    1 wl-wave !
    wl-expand
    wl-found @  if
      wl-found @
    else
      begin  wl-q-count  wl-found @ 0=  and  while
        wl-process-queue
      repeat
      wl-found @
    then
  then ;

\ === paste your solution above this line ===

T{ ladder-len -> 5 }T

report bye
