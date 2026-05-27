> Source: https://gforth.org/manual/Exceptions-Tutorial.html

<span id="Exceptions-Tutorial"></span>

<div class="header">

Next: [Defining Words Tutorial](Defining-Words-Tutorial.html#Defining-Words-Tutorial), Previous: [Execution Tokens Tutorial](Execution-Tokens-Tutorial.html#Execution-Tokens-Tutorial), Up: [Tutorial](Tutorial.html#Tutorial)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Exceptions"></span>

### 3.30 Exceptions

<span id="index-exceptions-tutorial"></span>

`throw ( n -- )` causes an exception unless n is zero.

<div class="example">

``` example
100 throw .s
0 throw .s
```

</div>

`catch ( ... xt -- ... n )` behaves similar to `execute`, but it catches exceptions and pushes the number of the exception on the stack (or 0, if the xt executed without exception). If there was an exception, the stacks have the same depth as when entering `catch`:

<div class="example">

``` example
.s
3 0 ' / catch .s
3 2 ' / catch .s
```

</div>

> **Assignment:** Try the same with `execute` instead of `catch`.

`Throw` always jumps to the dynamically next enclosing `catch`, even if it has to leave several call levels to achieve this:

<div class="example">

``` example
: foo 100 throw ;
: foo1 foo ." after foo" ;
: bar ['] foo1 catch ;
bar .
```

</div>

It is often important to restore a value upon leaving a definition, even if the definition is left through an exception. You can ensure this like this:

<div class="example">

``` example
: ...
   save-x
   ['] word-changing-x catch ( ... n )
   restore-x
   ( ... n ) throw ;
```

</div>

However, this is still not safe against, e.g., the user pressing <span class="kbd">Ctrl-C</span> when execution is between the `catch` and `restore-x`.

Gforth provides an alternative exception handling syntax that is safe against such cases: `try ... restore ... endtry`. If the code between `try` and `endtry` has an exception, the stack depths are restored, the exception number is pushed on the stack, and the execution continues right after `restore`.

The safer equivalent to the restoration code above is

<div class="example">

``` example
: ...
  save-x
  try
    word-changing-x 0
  restore
    restore-x
  endtry
  throw ;
```

</div>

Reference: [Exception Handling](Exception-Handling.html#Exception-Handling).

-----

<div class="header">

Next: [Defining Words Tutorial](Defining-Words-Tutorial.html#Defining-Words-Tutorial), Previous: [Execution Tokens Tutorial](Execution-Tokens-Tutorial.html#Execution-Tokens-Tutorial), Up: [Tutorial](Tutorial.html#Tutorial)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
