> Source: https://gforth.org/manual/Literals.html

<span id="Literals"></span>

<div class="header">

Next: [Macros](Macros.html#Macros), Previous: [Compiling words](Compiling-words.html#Compiling-words), Up: [Compiling words](Compiling-words.html#Compiling-words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Literals-1"></span>

#### 5.12.1 Literals

<span id="index-Literals"></span>

The simplest and most frequent example is to compute a literal during compilation. E.g., the following definition prints an array of strings, one string per line:

<div class="example">

``` example
: .strings ( addr u -- ) \ gforth
    2* cells bounds U+DO
    cr i 2@ type
    2 cells +LOOP ;  
```

</div>

With a simple-minded compiler like Gforth’s, this computes `2 cells` on every loop iteration. You can compute this value once and for all at compile time and compile it into the definition like this:

<div class="example">

``` example
: .strings ( addr u -- ) \ gforth
    2* cells bounds U+DO
    cr i 2@ type
    [ 2 cells ] literal +LOOP ;  
```

</div>

`[` switches the text interpreter to interpret state (you will get an `ok` prompt if you type this example interactively and insert a newline between `[` and `]`), so it performs the interpretation semantics of `2 cells`; this computes a number. `]` switches the text interpreter back into compile state. It then performs `Literal`’s compilation semantics, which are to compile this number into the current word. You can decompile the word with `see .strings` to see the effect on the compiled code.

You can also optimize the `2* cells` into `[ 2 cells ] literal *` in this way.

<span id="index-_005b--_002d_002d--core"></span> <span id="index-_005b"></span> <span id="index-_005b-1"></span>

<div class="format">

``` format
[       –         core       “left-bracket”
```

</div>

Enter interpretation state. Immediate word.

<span id="index-_005d--_002d_002d--core"></span> <span id="index-_005d"></span> <span id="index-_005d-1"></span>

<div class="format">

``` format
]       –         core       “right-bracket”
```

</div>

Enter compilation state.

<span id="index-Literal--compilation-n-_002d_002d-_003b-run_002dtime-_002d_002d-n--core"></span> <span id="index-Literal"></span> <span id="index-Literal-1"></span>

<div class="format">

``` format
Literal       compilation n – ; run-time – n         core       “Literal”
```

</div>

Compilation semantics: compile the run-time semantics.  
Run-time Semantics: push *n*.  
Interpretation semantics: undefined.

<span id="index-_005dL--compilation_003a-n-_002d_002d-_003b-run_002dtime_003a-_002d_002d-n--gforth"></span> <span id="index-_005dL"></span> <span id="index-_005dL-1"></span>

<div class="format">

``` format
]L       compilation: n – ; run-time: – n         gforth       “]L”
```

</div>

equivalent to `] literal`

There are also words for compiling other data types than single cells as literals:

<span id="index-2Literal--compilation-w1-w2-_002d_002d-_003b-run_002dtime-_002d_002d-w1-w2--double"></span> <span id="index-2Literal"></span> <span id="index-2Literal-1"></span>

<div class="format">

``` format
2Literal       compilation w1 w2 – ; run-time  – w1 w2         double       “two-literal”
```

</div>

Compile appropriate code such that, at run-time, *w1 w2* are placed on the stack. Interpretation semantics are undefined.

<span id="index-FLiteral--compilation-r-_002d_002d-_003b-run_002dtime-_002d_002d-r--float"></span> <span id="index-FLiteral"></span> <span id="index-FLiteral-1"></span>

<div class="format">

``` format
FLiteral       compilation r – ; run-time – r         float       “f-literal”
```

</div>

Compile appropriate code such that, at run-time, *r* is placed on the (floating-point) stack. Interpretation semantics are undefined.

<span id="index-SLiteral--Compilation-c_002daddr1-u-_003b-run_002dtime-_002d_002d-c_002daddr2-u--string"></span> <span id="index-SLiteral"></span> <span id="index-SLiteral-1"></span>

<div class="format">

``` format
SLiteral       Compilation c-addr1 u ; run-time – c-addr2 u         string       “SLiteral”
```

</div>

Compilation: compile the string specified by *c-addr1*, *u* into the current definition. Run-time: return *c-addr2 u* describing the address and length of the string.

<span id="index-colon_002dsys_002c-passing-data-across-_003a"></span> <span id="index-_003a_002c-passing-data-across"></span>

You might be tempted to pass data from outside a colon definition to the inside on the data stack. This does not work, because `:` puhes a colon-sys, making stuff below unaccessible. E.g., this does not work:

<div class="example">

``` example
5 : foo literal ; \ error: "unstructured"
```

</div>

Instead, you have to pass the value in some other way, e.g., through a variable:

<div class="example">

``` example
variable temp
5 temp !
: foo [ temp @ ] literal ;
```

</div>

-----

<div class="header">

Next: [Macros](Macros.html#Macros), Previous: [Compiling words](Compiling-words.html#Compiling-words), Up: [Compiling words](Compiling-words.html#Compiling-words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
