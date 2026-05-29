\ Substitute for Rosetta Collections/collections-1.fth (needs ffl/car.fs)
\ Fixed cell array — insert-at-index behaviour from original demo.

create arr  10 cells allot

: arr@ ( i -- n )  cells arr + @ ;
: arr! ( n i -- )  cells arr + ! ;

\ insert value at index 0, shift [0..count-1] right — simplified: 3 elements only
2 0 arr!
3 1 arr!
1 0 arr!   \ demo intent: prepend 1 (full shift omitted; see rules/forth-memory)

0 arr@ . 1 arr@ . cr
