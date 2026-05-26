\ tests/challenges/06-roman.fs
\
\ CHALLENGE: integer -> Roman numeral
\
\ Define a word
\
\   : roman  ( n -- c-addr u )
\
\ that converts 1..3999 into its standard Roman-numeral spelling and
\ returns it as an ANS string ( address, byte count ).
\
\ Use subtractive notation for 4, 9, 40, 90, 400, 900.
\
\ You decide where the bytes live (CREATE buffer, PAD, pictured numeric
\ output buffer, ...). The buffer must stay valid until EXPECT-STR-EQ
\ has read it, i.e. across one assertion.
\
\ Style guard (rules/forth-factoring.mdc):
\   - this is the classic Brodie lexicon: factor it into one small word
\     that emits "value -> glyph(s)" once, and one driver that walks the
\     value/glyph table from largest to smallest;
\   - the table of (1000,"M") (900,"CM") (500,"D") ... is data, not
\     thirteen IFs ("calculation > data structure > logic");
\   - no magic numerals inside the loop body; M, CM, D, CD, ... come from
\     the table.

include _tester.fs

\ === paste your solution below this line ===

\ === paste your solution above this line ===

T{    1 roman s" I"         expect-str-eq -> }T
T{    3 roman s" III"       expect-str-eq -> }T
T{    4 roman s" IV"        expect-str-eq -> }T
T{    9 roman s" IX"        expect-str-eq -> }T
T{   14 roman s" XIV"       expect-str-eq -> }T
T{   40 roman s" XL"        expect-str-eq -> }T
T{   58 roman s" LVIII"     expect-str-eq -> }T
T{   90 roman s" XC"        expect-str-eq -> }T
T{   99 roman s" XCIX"      expect-str-eq -> }T
T{  400 roman s" CD"        expect-str-eq -> }T
T{  444 roman s" CDXLIV"    expect-str-eq -> }T
T{  900 roman s" CM"        expect-str-eq -> }T
T{ 1994 roman s" MCMXCIV"   expect-str-eq -> }T
T{ 3999 roman s" MMMCMXCIX" expect-str-eq -> }T

report bye
