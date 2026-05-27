> Source: https://gforth.org/manual/Macros.html

<span id="Macros"></span>

<div class="header">

Previous: [Literals](Literals.html#Literals), Up: [Compiling words](Compiling-words.html#Compiling-words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Macros-1"></span>

#### 5.12.2 Macros

<span id="index-Macros"></span> <span id="index-compiling-compilation-semantics"></span>

`Literal` and friends compile data values into the current definition. You can also write words that compile other words into the current definition. E.g.,

<div class="example">

``` example
: compile-+ ( -- ) \ compiled code: ( n1 n2 -- n )
  POSTPONE + ;

: foo ( n1 n2 -- n )
  [ compile-+ ] ;
1 2 foo .
```

</div>

This is equivalent to `: foo + ;` (`see foo` to check this). What happens in this example? `Postpone` compiles the compilation semantics of `+` into `compile-+`; later the text interpreter executes `compile-+` and thus the compilation semantics of +, which compile (the execution semantics of) `+` into `foo`.[<sup>22</sup>](#FOOT22)

<span id="index-postpone--_0022name_0022-_002d_002d--core"></span> <span id="index-postpone"></span> <span id="index-postpone-2"></span>

<div class="format">

``` format
postpone       "name" –         core       “postpone”
```

</div>

Compiles the compilation semantics of *name*.

Compiling words like `compile-+` are usually immediate (or similar) so you do not have to switch to interpret state to execute them; modifying the last example accordingly produces:

<div class="example">

``` example
: [compile-+] ( compilation: --; interpretation: -- )
  \ compiled code: ( n1 n2 -- n )
  POSTPONE + ; immediate

: foo ( n1 n2 -- n )
  [compile-+] ;
1 2 foo .
```

</div>

You will occassionally find the need to POSTPONE several words; putting POSTPONE before each such word is cumbersome, so Gforth provides a more convenient syntax: `]] ... [[`. This allows us to write `[compile-+]` as:

<div class="example">

``` example
: [compile-+] ( compilation: --; interpretation: -- )
  ]] + [[ ; immediate
```

</div>

<span id="index-_005d_005d--_002d_002d--gforth"></span> <span id="index-_005d_005d"></span> <span id="index-_005d_005d-1"></span>

<div class="format">

``` format
]]       –         gforth       “right-bracket-bracket”
```

</div>

switch into postpone state

<span id="index-_005b_005b--_002d_002d--gforth"></span> <span id="index-_005b_005b"></span> <span id="index-_005b_005b-1"></span>

<div class="format">

``` format
[[       –         gforth       “left-bracket-bracket”
```

</div>

switch from postpone state to compile state

The unusual direction of the brackets indicates their function: `]]` switches from compilation to postponing (i.e., compilation of compilation), just like `]` switches from immediate execution (interpretation) to compilation. Conversely, `[[` switches from postponing to compilation, ananlogous to `[` which switches from compilation to immediate execution.

The real advantage of ` ]]  `...`  [[ ` becomes apparent when there are many words to POSTPONE. E.g., the word `compile-map-array` (see [Advanced macros Tutorial](Advanced-macros-Tutorial.html#Advanced-macros-Tutorial)) can be written much shorter as follows:

<div class="example">

``` example
: compile-map-array ( compilation: xt -- ; run-time: ... addr u -- ... )
\ at run-time, execute xt ( ... x -- ... ) for each element of the
\ array beginning at addr and containing u elements
  { xt }
  ]] cells over + swap ?do
    i @ [[ xt compile, 
  1 cells ]]L +loop [[ ;
```

</div>

This example also uses `]]L` as a shortcut for `]] literal`. There are also other shortcuts

<span id="index-_005d_005dL--postponing_003a-x-_002d_002d-_003b-compiling_003a-_002d_002d-x--gforth"></span> <span id="index-_005d_005dL"></span> <span id="index-_005d_005dL-1"></span>

<div class="format">

``` format
]]L       postponing: x – ; compiling: – x         gforth       “right-bracket-bracket-l”
```

</div>

Shortcut for `]] literal`.

<span id="index-_005d_005d2L--postponing_003a-x1-x2-_002d_002d-_003b-compiling_003a-_002d_002d-x1-x2--gforth"></span> <span id="index-_005d_005d2L"></span> <span id="index-_005d_005d2L-1"></span>

<div class="format">

``` format
]]2L       postponing: x1 x2 – ; compiling: – x1 x2         gforth       “right-bracket-bracket-two-l”
```

</div>

Shortcut for `]] 2literal`.

<span id="index-_005d_005dFL--postponing_003a-r-_002d_002d-_003b-compiling_003a-_002d_002d-r--gforth"></span> <span id="index-_005d_005dFL"></span> <span id="index-_005d_005dFL-1"></span>

<div class="format">

``` format
]]FL       postponing: r – ; compiling: – r         gforth       “right-bracket-bracket-f-l”
```

</div>

Shortcut for `]] fliteral`.

<span id="index-_005d_005dSL--postponing_003a-addr1-u-_002d_002d-_003b-compiling_003a-_002d_002d-addr2-u--gforth"></span> <span id="index-_005d_005dSL"></span> <span id="index-_005d_005dSL-1"></span>

<div class="format">

``` format
]]SL       postponing: addr1 u – ; compiling: – addr2 u         gforth       “right-bracket-bracket-s-l”
```

</div>

Shortcut for `]] sliteral`; if the string already has been allocated permanently, you can use `]]2L` instead.

Note that parsing words don’t parse at postpone time; if you want to provide the parsed string right away, you have to switch back to compilation:

<div class="example">

``` example
]] ... [[ s" some string" ]]2L ... [[
]] ... [[ ['] + ]]L ... [[
```

</div>

Definitions of `]]` and friends in Standard Forth are provided in `compat/macros.fs`.

Immediate compiling words are similar to macros in other languages (in particular, Lisp). The important differences to macros in, e.g., C are:

  - You use the same language for defining and processing macros, not a separate preprocessing language and processor.

  - Consequently, the full power of Forth is available in macro definitions. E.g., you can perform arbitrarily complex computations, or generate different code conditionally or in a loop (e.g., see [Advanced macros Tutorial](Advanced-macros-Tutorial.html#Advanced-macros-Tutorial)). This power is very useful when writing a parser generators or other code-generating software.

  - Macros defined using `postpone` etc. deal with the language at a higher level than strings; name binding happens at macro definition time, so you can avoid the pitfalls of name collisions that can happen in C macros. Of course, Forth is a liberal language and also allows to shoot yourself in the foot with text-interpreted macros like
    
    <div class="example">
    
    ``` example
    : [compile-+] s" +" evaluate ; immediate
    ```
    
    </div>
    
    Apart from binding the name at macro use time, using `evaluate` also makes your definition `state`-smart (see [state-smartness](Combined-words.html#state_002dsmartness)).

You may want the macro to compile a number into a word. The word to do it is `literal`, but you have to `postpone` it, so its compilation semantics take effect when the macro is executed, not when it is compiled:

<div class="example">

``` example
: [compile-5] ( -- ) \ compiled code: ( -- n )
  5 POSTPONE literal ; immediate

: foo [compile-5] ;
foo .
```

</div>

You may want to pass parameters to a macro, that the macro should compile into the current definition. If the parameter is a number, then you can use `postpone literal` (similar for other values).

If you want to pass a word that is to be compiled, the usual way is to pass an execution token and `compile,` it:

<div class="example">

``` example
: twice1 ( xt -- ) \ compiled code: ... -- ...
  dup compile, compile, ;

: 2+ ( n1 -- n2 )
  [ ' 1+ twice1 ] ;
```

</div>

<span id="index-compile_002c--xt-_002d_002d--unknown"></span> <span id="index-compile_002c"></span> <span id="index-compile_002c-1"></span>

<div class="format">

``` format
compile,       xt –         unknown       “compile,”
```

</div>

An alternative available in Gforth, that allows you to pass the compilation semantics as parameters is to use the compilation token (see [Compilation token](Compilation-token.html#Compilation-token)). The same example in this technique:

<div class="example">

``` example
: twice ( ... ct -- ... ) \ compiled code: ... -- ...
  2dup 2>r execute 2r> execute ;

: 2+ ( n1 -- n2 )
  [ comp' 1+ twice ] ;
```

</div>

In the example above `2>r` and `2r>` ensure that `twice` works even if the executed compilation semantics has an effect on the data stack.

You can also define complete definitions with these words; this provides an alternative to using `does>` (see [User-defined Defining Words](User_002ddefined-Defining-Words.html#User_002ddefined-Defining-Words)). E.g., instead of

<div class="example">

``` example
: curry+ ( n1 "name" -- )
    CREATE ,
DOES> ( n2 -- n1+n2 )
    @ + ;
```

</div>

you could define

<div class="example">

``` example
: curry+ ( n1 "name" -- )
  \ name execution: ( n2 -- n1+n2 )
  >r : r> POSTPONE literal POSTPONE + POSTPONE ; ;

-3 curry+ 3-
see 3-
```

</div>

The sequence `>r : r>` is necessary, because `:` puts a colon-sys on the data stack that makes everything below it unaccessible.

This way of writing defining words is sometimes more, sometimes less convenient than using `does>` (see [Advanced does\> usage example](Advanced-does_003e-usage-example.html#Advanced-does_003e-usage-example)). One advantage of this method is that it can be optimized better, because the compiler knows that the value compiled with `literal` is fixed, whereas the data associated with a `create`d word can be changed.

<div class="footnote">

-----

#### Footnotes

### [(22)](#DOCF22)

A recent RFI answer requires that compiling words should only be executed in compile state, so this example is not guaranteed to work on all standard systems, but on any decent system it will work.

</div>

-----

<div class="header">

Previous: [Literals](Literals.html#Literals), Up: [Compiling words](Compiling-words.html#Compiling-words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
