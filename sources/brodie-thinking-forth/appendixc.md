# Other Utilities Described in This Book

This appendix is here to help you define some of the words referred to in this book that may not exist in your system. Definitions are given in Forth-83 Standard.

## From Chapter 4

A definition of ASCII that will work in ’83 Standard is:

``` forth
: ASCII  ( -- c)  \  Compile:  c  ( -- )
\ Interpret:   c   ( -- c)
     bl word 1+ c@  state @
     IF [compile] Literal  THEN ; immediate
```

## From Chapter 5

The word can be defined as:

``` forth
: \  ( skip rest of line)
     >in @  64 / 1+  64 *  >in ! ; immediate
```

If you decide not to use EXIT to terminate a screen, you can define S as:

``` forth
: \S   1024 >in ! ;
```

The word FH can be defined simply as:

``` forth
: FH   \   ( offset -- offset-block)   "from here"
    blk @ + ;
```

This factoring allows you to use FH in many ways, e.g.:

``` forth
: TEST   [ 1 FH ] Literal load ;
```

or

``` forth
: see   [ 2 FH ] Literal list ;
```

A slightly more complicated version of FH also lets you edit or load a screen with a phrase such as “14 FH LIST,” relative to the screen that you just listed (SCR):

``` forth
: FH   \   ( offset -- offset-block)   "from here"
     blk @  ?dup 0= IF  scr @  THEN  + ;
```

BL is a simple constant:

``` forth
32 Constant bl
```

TRUE and FALSE can be defined as:

``` forth
0 Constant false
-1 Constant true
```

(Forth’s control words such as IF and UNTIL interpret zero as “false” and any non-zero value as “true.” Before Forth ’83, the convention was to indicate “true” with the value $`1`$. Starting with Forth ’83, however, “true” is indicated with hex FFFF, which is the signed number $`-1`$ (all bits set).

WITHIN can be defined in high level like this:

``` forth
: within  ( n lo hi+1 -- ?)
     >r  1- over <  swap r>  < and ;
```

or

``` forth
: within ( n lo hi+1 -- ?)
   over -  >r - r> u< ;
```

## From Chapter 8

The implementation of LEAP will depend on how your system implements DO LOOPs. If DO keeps two items on the return stack (the index and the limit), LEAP must drop both of them plus one more return-stack item to exit:

``` forth
: LEAP   r> r> 2drop  r> drop ;
```

If DO keeps *three* items on the return stack, it must be defined:

``` forth
: LEAP   r> r> 2drop  r> r> 2drop ;
```
