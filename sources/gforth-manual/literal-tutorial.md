> Source: https://gforth.org/manual/Literal-Tutorial.html

<span id="Literal-Tutorial"></span>

<div class="header">

Next: [Advanced macros Tutorial](Advanced-macros-Tutorial.html#Advanced-macros-Tutorial), Previous: [POSTPONE Tutorial](POSTPONE-Tutorial.html#POSTPONE-Tutorial), Up: [Tutorial](Tutorial.html#Tutorial)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Literal"></span>

### 3.34 `Literal`

<span id="index-literal-tutorial"></span>

You cannot `POSTPONE` numbers:

<div class="example">

``` example
: [FOO] POSTPONE 500 ; immediate
```

</div>

Instead, you can use `LITERAL (compilation: n --; run-time: -- n )`:

<div class="example">

``` example
: [FOO] ( compilation: --; run-time: -- n )
  500 POSTPONE literal ; immediate

: flip [FOO] ;
flip .
see flip
```

</div>

`LITERAL` consumes a number at compile-time (when it’s compilation semantics are executed) and pushes it at run-time (when the code it compiled is executed). A frequent use of `LITERAL` is to compile a number computed at compile time into the current word:

<div class="example">

``` example
: bar ( -- n )
  [ 2 2 + ] literal ;
see bar
```

</div>

> **Assignment:** Write `]L` which allows writing the example above as `: bar ( -- n ) [ 2 2 + ]L ;`
