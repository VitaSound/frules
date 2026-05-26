\ tests/ans/fizzbuzz.fs — classify n as code 0/1/2/3.
\ 0 = number, 1 = fizz (div 3), 2 = buzz (div 5), 3 = fizzbuzz.
\ Exercises: named constants, factored predicates, nested IF without magic numbers.

include _tester.fs

3 constant fizz-mod
5 constant buzz-mod

: divisible?  ( n d -- flag )  mod 0= ;
: fizz?       ( n -- flag )    fizz-mod divisible? ;
: buzz?       ( n -- flag )    buzz-mod divisible? ;

: fb-classify  ( n -- code )
  dup fizz? swap buzz?
  if    if 3 else 2 then
  else  if 1 else 0 then
  then ;

T{  1 fb-classify -> 0 }T
T{  3 fb-classify -> 1 }T
T{  5 fb-classify -> 2 }T
T{ 15 fb-classify -> 3 }T
T{ 30 fb-classify -> 3 }T
T{  8 fb-classify -> 0 }T
T{  9 fb-classify -> 1 }T
T{ 25 fb-classify -> 2 }T

report bye
