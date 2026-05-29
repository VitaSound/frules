\ Rosetta Assertions — gforth fix: demo uses 42 so assert passes
variable a
: assert   a @ 42 <> throw ;

42 a ! assert
