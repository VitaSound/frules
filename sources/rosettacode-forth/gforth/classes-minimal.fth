\ Substitute for Rosetta Classes/classes-1.fth (non-Gforth ;class syntax)
: object: ( n "name" -- )
  create , does> ( -- n )  @ ;

5 object: my-obj
my-obj .
