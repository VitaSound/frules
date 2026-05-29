\ tests/challenges/114-parse-int-hex.fs
include _tester.fs
create ch-buf 64 chars allot
: ch-setup  ( c-addr u -- c-addr u ) ;

\ === paste your solution below this line ===

: hex-val  ( ch -- n f )
  dup 48 >= swap 57 <= and if  48 - true else
  dup 97 >= swap 102 <= and if  97 - 10 + true else
  2drop false then then ;

: parse-hex  ( c-addr u -- n )
  { c u -- n }
  0 { n # }
  u 0 ?do
    c i + c@ hex-val if
      n swap 16 * + to n
    then
  loop  n ;

\ === paste your solution above this line ===

T{ s" ff" ch-setup parse-hex -> 255 }T
T{ s" 2a" ch-setup parse-hex -> 42 }T
T{ s" 0" ch-setup parse-hex -> 0 }T
report bye
