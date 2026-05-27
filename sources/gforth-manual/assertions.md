> Source: https://gforth.org/manual/Assertions.html

<span id="Assertions"></span>

<div class="header">

Next: [Singlestep Debugger](Singlestep-Debugger.html#Singlestep-Debugger), Previous: [Debugging](Debugging.html#Debugging), Up: [Programming Tools](Programming-Tools.html#Programming-Tools)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Assertions-1"></span>

#### 5.24.4 Assertions

<span id="index-assertions"></span>

It is a good idea to make your programs self-checking, especially if you make an assumption that may become invalid during maintenance (for example, that a certain field of a data structure is never zero). Gforth supports *assertions* for this purpose. They are used like this:

<div class="example">

``` example
assert( flag )
```

</div>

The code between `assert(` and `)` should compute a flag, that should be true if everything is alright and false otherwise. It should not change anything else on the stack. The overall stack effect of the assertion is `( -- )`. E.g.

<div class="example">

``` example
assert( 1 1 + 2 = ) \ what we learn in school
assert( dup 0<> ) \ assert that the top of stack is not zero
assert( false ) \ this code should not be reached
```

</div>

The need for assertions is different at different times. During debugging, we want more checking, in production we sometimes care more for speed. Therefore, assertions can be turned off, i.e., the assertion becomes a comment. Depending on the importance of an assertion and the time it takes to check it, you may want to turn off some assertions and keep others turned on. Gforth provides several levels of assertions for this purpose:

<span id="index-assert0_0028--_002d_002d--gforth"></span> <span id="index-assert0_0028"></span> <span id="index-assert0_0028-1"></span>

<div class="format">

``` format
assert0(       –         gforth       “assert-zero”
```

</div>

Important assertions that should always be turned on.

<span id="index-assert1_0028--_002d_002d--gforth"></span> <span id="index-assert1_0028"></span> <span id="index-assert1_0028-1"></span>

<div class="format">

``` format
assert1(       –         gforth       “assert-one”
```

</div>

Normal assertions; turned on by default.

<span id="index-assert2_0028--_002d_002d--gforth"></span> <span id="index-assert2_0028"></span> <span id="index-assert2_0028-1"></span>

<div class="format">

``` format
assert2(       –         gforth       “assert-two”
```

</div>

Debugging assertions.

<span id="index-assert3_0028--_002d_002d--gforth"></span> <span id="index-assert3_0028"></span> <span id="index-assert3_0028-1"></span>

<div class="format">

``` format
assert3(       –         gforth       “assert-three”
```

</div>

Slow assertions that you may not want to turn on in normal debugging; you would turn them on mainly for thorough checking.

<span id="index-assert_0028--_002d_002d--gforth"></span> <span id="index-assert_0028"></span> <span id="index-assert_0028-1"></span>

<div class="format">

``` format
assert(       –         gforth       “assert(”
```

</div>

Equivalent to `assert1(`

<span id="index-_0029--_002d_002d--gforth"></span> <span id="index-_0029"></span> <span id="index-_0029-1"></span>

<div class="format">

``` format
)       –         gforth       “close-paren”
```

</div>

End an assertion. Generic end, can be used for other similar purposes

The variable `assert-level` specifies the highest assertions that are turned on. I.e., at the default `assert-level` of one, `assert0(` and `assert1(` assertions perform checking, while `assert2(` and `assert3(` assertions are treated as comments.

The value of `assert-level` is evaluated at compile-time, not at run-time. Therefore you cannot turn assertions on or off at run-time; you have to set the `assert-level` appropriately before compiling a piece of code. You can compile different pieces of code at different `assert-level`s (e.g., a trusted library at level 1 and newly-written code at level 3).

<span id="index-assert_002dlevel--_002d_002d-a_002daddr--gforth"></span> <span id="index-assert_002dlevel"></span> <span id="index-assert_002dlevel-1"></span>

<div class="format">

``` format
assert-level       – a-addr         gforth       “assert-level”
```

</div>

All assertions above this level are turned off.

If an assertion fails, a message compatible with Emacs’ compilation mode is produced and the execution is aborted (currently with `ABORT"`. If there is interest, we will introduce a special throw code. But if you intend to `catch` a specific condition, using `throw` is probably more appropriate than an assertion).

<span id="index-filenames-in-assertion-output"></span>

Assertions (and `~~`) will usually print the wrong file name if a marker is executed in the same file after their occurance. They will print ‘`*somewhere*`’ as file name if a marker is executed in the same file before their occurance.

Definitions in Standard Forth for these assertion words are provided in `compat/assert.fs`.

-----

<div class="header">

Next: [Singlestep Debugger](Singlestep-Debugger.html#Singlestep-Debugger), Previous: [Debugging](Debugging.html#Debugging), Up: [Programming Tools](Programming-Tools.html#Programming-Tools)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
