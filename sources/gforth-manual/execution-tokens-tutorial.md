> Source: https://gforth.org/manual/Execution-Tokens-Tutorial.html

<span id="Execution-Tokens-Tutorial"></span>

<div class="header">

Next: [Exceptions Tutorial](Exceptions-Tutorial.html#Exceptions-Tutorial), Previous: [Interpretation and Compilation Semantics and Immediacy Tutorial](Interpretation-and-Compilation-Semantics-and-Immediacy-Tutorial.html#Interpretation-and-Compilation-Semantics-and-Immediacy-Tutorial), Up: [Tutorial](Tutorial.html#Tutorial)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Execution-Tokens"></span>

### 3.29 Execution Tokens

<span id="index-execution-tokens-tutorial"></span> <span id="index-XT-tutorial"></span>

`' word` gives you the execution token (XT) of a word. The XT is a cell representing the interpretation semantics of a word. You can execute this semantics with `execute`:

<div class="example">

``` example
' + .s
1 2 rot execute .
```

</div>

The XT is similar to a function pointer in C. However, parameter passing through the stack makes it a little more flexible:

<div class="example">

``` example
: map-array ( ... addr u xt -- ... )
\ executes xt ( ... x -- ... ) for every element of the array starting
\ at addr and containing u elements
  { xt }
  cells over + swap ?do
    i @ xt execute
  1 cells +loop ;

create a 3 , 4 , 2 , -1 , 4 ,
a 5 ' . map-array .s
0 a 5 ' + map-array .
s" max-n" environment? drop .s
a 5 ' min map-array .
```

</div>

You can use map-array with the XTs of words that consume one element more than they produce. In theory you can also use it with other XTs, but the stack effect then depends on the size of the array, which is hard to understand.

Since XTs are cell-sized, you can store them in memory and manipulate them on the stack like other cells. You can also compile the XT into a word with `compile,`:

<div class="example">

``` example
: foo1 ( n1 n2 -- n )
   [ ' + compile, ] ;
see foo1
```

</div>

This is non-standard, because `compile,` has no compilation semantics in the standard, but it works in good Forth systems. For the broken ones, use

<div class="example">

``` example
: [compile,] compile, ; immediate

: foo1 ( n1 n2 -- n )
   [ ' + ] [compile,] ;
see foo1
```

</div>

`'` is a word with default compilation semantics; it parses the next word when its interpretation semantics are executed, not during compilation:

<div class="example">

``` example
: foo ( -- xt )
  ' ;
see foo
: bar ( ... "word" -- ... )
  ' execute ;
see bar
1 2 bar + .
```

</div>

You often want to parse a word during compilation and compile its XT so it will be pushed on the stack at run-time. `[']` does this:

<div class="example">

``` example
: xt-+ ( -- xt )
  ['] + ;
see xt-+
1 2 xt-+ execute .
```

</div>

Many programmers tend to see `'` and the word it parses as one unit, and expect it to behave like `[']` when compiled, and are confused by the actual behaviour. If you are, just remember that the Forth system just takes `'` as one unit and has no idea that it is a parsing word (attempts to convenience programmers in this issue have usually resulted in even worse pitfalls, see [`State`-smartness—Why it is evil and How to Exorcise it](http://www.complang.tuwien.ac.at/papers/ertl98.ps.gz)).

Note that the state of the interpreter does not come into play when creating and executing XTs. I.e., even when you execute `'` in compile state, it still gives you the interpretation semantics. And whatever that state is, `execute` performs the semantics represented by the XT (i.e., for XTs produced with `'` the interpretation semantics).

Reference: [Tokens for Words](Tokens-for-Words.html#Tokens-for-Words).

-----

<div class="header">

Next: [Exceptions Tutorial](Exceptions-Tutorial.html#Exceptions-Tutorial), Previous: [Interpretation and Compilation Semantics and Immediacy Tutorial](Interpretation-and-Compilation-Semantics-and-Immediacy-Tutorial.html#Interpretation-and-Compilation-Semantics-and-Immediacy-Tutorial), Up: [Tutorial](Tutorial.html#Tutorial)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
