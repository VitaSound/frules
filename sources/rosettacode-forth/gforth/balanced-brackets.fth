variable sq-lev

: sq-brackets? ( c-addr u -- flag )
  0 sq-lev !
  dup if
    bounds ?do
      i c@ case
        91 of  1  endof
        93 of -1  endof
        0
      endcase
      sq-lev @ + sq-lev !
    loop
  else
    2drop
  then
  sq-lev @ 0= ;

create sample  91 c, 91 c, 93 c, 93 c,
sample 4 sq-brackets? .
