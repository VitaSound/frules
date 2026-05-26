\ tests/challenges/03-reverse-string.fs
\
\ CHALLENGE: reverse a string in place
\
\ Define a word
\
\   : reverse  ( c-addr u -- )
\
\ that reverses u bytes starting at c-addr in place. Both the empty string
\ (u = 0) and the one-byte string must be handled without special cases
\ in the caller.
\
\ Style guard (rules/forth-anti-patterns.mdc, rules/forth-factoring.mdc):
\   - no allocation, no auxiliary buffer;
\   - no PICK / no ROLL; if you reach for them, factor a swap helper instead;
\   - if you split into smaller words, document their stack effects.

include _tester.fs

create rbuf 32 chars allot

\ Copy a literal into the writable buffer, return ( rbuf u ) for the test.
: setup  ( c-addr u -- rbuf u )
  dup >r  rbuf swap  move  rbuf r> ;

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{ s" abcd"    setup 2dup reverse  s" dcba"    expect-str-eq -> }T
T{ s" hello"   setup 2dup reverse  s" olleh"   expect-str-eq -> }T
T{ s" a"       setup 2dup reverse  s" a"       expect-str-eq -> }T
T{ s" "        setup 2dup reverse  s" "        expect-str-eq -> }T
T{ s" racecar" setup 2dup reverse  s" racecar" expect-str-eq -> }T
T{ s" ab"      setup 2dup reverse  s" ba"      expect-str-eq -> }T

report bye
