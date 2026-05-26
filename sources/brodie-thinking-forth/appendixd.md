# Answers to Further Thinking” Problems

## Chapter 3

1.  The answer depends on whether you believe that other components will need to “know the numeric code associated with each key. Usually this would *not* be the case. The simpler, more compact form is therefore preferable. Also in the first version, to add a new key would require a change in two places.

2.  The problem with the words RAM-ALLOT and THERE are that they are *time-dependent*: we must execute them in a particular order. Our solution then will be to devise an interface to the RAM allocation pointer that is not dependent on order; the way to do this is to have a *single* word which does both functions transparently.

    Our word’s syntax will be

    ``` forth
    : RAM-ALLOT   ( #bytes-to-allot -- starting-adr) 
        ... ;
    ```

    This syntax will remain the same whether we define it to allocate growing upward:

    ``` forth
    : RAM-ALLOT  ( #bytes-to-allot -- starting-adr)
        >RAM @  dup rot +  >RAM ! ;
    ```

    or to allocate growing downward:

    ``` forth
    : RAM-ALLOT  ( #bytes-to-allot -- starting-adr)
        >RAM @  swap -  dup >RAM ! ;
    ```

## Chapter 4

Our solution is as follows:

``` forth
\ CARDS Shuffle                              6-20-83
52 Constant #CARDS
Create DECK  #CARDS allot   \ one card per byte
: CARD ( i -- adr) DECK + ;
: INIT-DECK  #CARDS 0 DO  i  i CARD  c!  LOOP ;
INIT-DECK
: 'CSWAP  ( a1 a2 -- )  \  swap bytes at a1 and a2
   2dup c@  swap c@  rot c!  swap c! ;
: SHUFFLE   \  shuffle deck of cards
   #CARDS 0 DO  i CARD  #CARDS CHOOSE CARD  'CSWAP
   LOOP ;
```

## Chapter 8

``` forth
: DIRECTION  ( n|-n|0 -- 1|-1|0)  dup  IF  0< 1 or  THEN ;
```
