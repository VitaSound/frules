> Source: https://gforth.org/manual/Advanced-macros-Tutorial.html

<span id="Advanced-macros-Tutorial"></span>

<div class="header">

Next: [Compilation Tokens Tutorial](Compilation-Tokens-Tutorial.html#Compilation-Tokens-Tutorial), Previous: [Literal Tutorial](Literal-Tutorial.html#Literal-Tutorial), Up: [Tutorial](Tutorial.html#Tutorial)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Advanced-macros"></span>

### 3.35 Advanced macros

<span id="index-macros_002c-advanced-tutorial"></span> <span id="index-run_002dtime-code-generation_002c-tutorial"></span>

Reconsider `map-array` from [Execution Tokens](Execution-Tokens-Tutorial.html#Execution-Tokens-Tutorial). It frequently performs `execute`, a relatively expensive operation in some Forth implementations. You can use `compile,` and `POSTPONE` to eliminate these `execute`s and produce a word that contains the word to be performed directly:

<div class="example">

``` example
: compile-map-array ( compilation: xt -- ; run-time: ... addr u -- ... )
\ at run-time, execute xt ( ... x -- ... ) for each element of the
\ array beginning at addr and containing u elements
  { xt }
  POSTPONE cells POSTPONE over POSTPONE + POSTPONE swap POSTPONE ?do
    POSTPONE i POSTPONE @ xt compile,
  1 cells POSTPONE literal POSTPONE +loop ;

: sum-array ( addr u -- n )
 0 rot rot [ ' + compile-map-array ] ;
see sum-array
a 5 sum-array .
```

</div>

You can use the full power of Forth for generating the code; here’s an example where the code is generated in a loop:

<div class="example">

``` example
: compile-vmul-step ( compilation: n --; run-time: n1 addr1 -- n2 addr2 )
\ n2=n1+(addr1)*n, addr2=addr1+cell
  POSTPONE tuck POSTPONE @
  POSTPONE literal POSTPONE * POSTPONE +
  POSTPONE swap POSTPONE cell+ ;

: compile-vmul ( compilation: addr1 u -- ; run-time: addr2 -- n )
\ n=v1*v2 (inner product), where the v_i are represented as addr_i u
  0 postpone literal postpone swap
  [ ' compile-vmul-step compile-map-array ]
  postpone drop ;
see compile-vmul

: a-vmul ( addr -- n )
\ n=a*v, where v is a vector that's as long as a and starts at addr
 [ a 5 compile-vmul ] ;
see a-vmul
a a-vmul .
```

</div>

This example uses `compile-map-array` to show off, but you could also use `map-array` instead (try it now\!).

You can use this technique for efficient multiplication of large matrices. In matrix multiplication, you multiply every row of one matrix with every column of the other matrix. You can generate the code for one row once, and use it for every column. The only downside of this technique is that it is cumbersome to recover the memory consumed by the generated code when you are done (and in more complicated cases it is not possible portably).

-----

<div class="header">

Next: [Compilation Tokens Tutorial](Compilation-Tokens-Tutorial.html#Compilation-Tokens-Tutorial), Previous: [Literal Tutorial](Literal-Tutorial.html#Literal-Tutorial), Up: [Tutorial](Tutorial.html#Tutorial)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
