> Source: https://gforth.org/manual/POSTPONE-Tutorial.html

<span id="POSTPONE-Tutorial"></span>

<div class="header">

Next: [Literal Tutorial](Literal-Tutorial.html#Literal-Tutorial), Previous: [Arrays and Records Tutorial](Arrays-and-Records-Tutorial.html#Arrays-and-Records-Tutorial), Up: [Tutorial](Tutorial.html#Tutorial)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="POSTPONE"></span>

### 3.33 `POSTPONE`

<span id="index-postpone-tutorial"></span>

You can compile the compilation semantics (instead of compiling the interpretation semantics) of a word with `POSTPONE`:

<div class="example">

``` example
: MY-+ ( Compilation: -- ; Run-time of compiled code: n1 n2 -- n )
 POSTPONE + ; immediate
: foo ( n1 n2 -- n )
 MY-+ ;
1 2 foo .
see foo
```

</div>

During the definition of `foo` the text interpreter performs the compilation semantics of `MY-+`, which performs the compilation semantics of `+`, i.e., it compiles `+` into `foo`.

This example also displays separate stack comments for the compilation semantics and for the stack effect of the compiled code. For words with default compilation semantics these stack effects are usually not displayed; the stack effect of the compilation semantics is always `( -- )` for these words, the stack effect for the compiled code is the stack effect of the interpretation semantics.

Note that the state of the interpreter does not come into play when performing the compilation semantics in this way. You can also perform it interpretively, e.g.:

<div class="example">

``` example
: foo2 ( n1 n2 -- n )
 [ MY-+ ] ;
1 2 foo .
see foo
```

</div>

However, there are some broken Forth systems where this does not always work, and therefore this practice was been declared non-standard in 1999.

Here is another example for using `POSTPONE`:

<div class="example">

``` example
: MY-- ( Compilation: -- ; Run-time of compiled code: n1 n2 -- n )
 POSTPONE negate POSTPONE + ; immediate compile-only
: bar ( n1 n2 -- n )
  MY-- ;
2 1 bar .
see bar
```

</div>

You can define `ENDIF` in this way:

<div class="example">

``` example
: ENDIF ( Compilation: orig -- )
  POSTPONE then ; immediate
```

</div>

> **Assignment:** Write `MY-2DUP` that has compilation semantics equivalent to `2dup`, but compiles `over over`.

-----

<div class="header">

Next: [Literal Tutorial](Literal-Tutorial.html#Literal-Tutorial), Previous: [Arrays and Records Tutorial](Arrays-and-Records-Tutorial.html#Arrays-and-Records-Tutorial), Up: [Tutorial](Tutorial.html#Tutorial)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
