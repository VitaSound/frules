> Source: https://gforth.org/manual/Execution-token.html

<span id="Execution-token"></span>

<div class="header">

Next: [Compilation token](Compilation-token.html#Compilation-token), Previous: [Tokens for Words](Tokens-for-Words.html#Tokens-for-Words), Up: [Tokens for Words](Tokens-for-Words.html#Tokens-for-Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Execution-token-1"></span>

#### 5.11.1 Execution token

<span id="index-xt-1"></span> <span id="index-execution-token-1"></span>

An *execution token* (*XT*) represents some behaviour of a word. You can use `execute` to invoke this behaviour.

<span id="index-tick-_0028_0027_0029"></span>

You can use `'` to get an execution token that represents the interpretation semantics of a named word:

<div class="example">

``` example
5 ' .   ( n xt ) 
execute ( )      \ execute the xt (i.e., ".")
```

</div>

<span id="index-_0027--_0022name_0022-_002d_002d-xt--core"></span> <span id="index-_0027"></span> <span id="index-_0027-2"></span>

<div class="format">

``` format
'       "name" – xt         core       “tick”
```

</div>

*xt* represents *name*’s interpretation semantics. Perform `-14 throw` if the word has no interpretation semantics.

`'` parses at run-time; there is also a word `[']` that parses when it is compiled, and compiles the resulting XT:

<div class="example">

``` example
: foo ['] . execute ;
5 foo
: bar ' execute ; \ by contrast,
5 bar .           \ ' parses "." when bar executes
```

</div>

<span id="index-_005b_0027_005d--compilation_002e-_0022name_0022-_002d_002d-_003b-run_002dtime_002e-_002d_002d-xt--core"></span> <span id="index-_005b_0027_005d"></span> <span id="index-_005b_0027_005d-1"></span>

<div class="format">

``` format
[']       compilation. "name" – ; run-time. – xt         core       “bracket-tick”
```

</div>

*xt* represents *name*’s interpretation semantics. Perform `-14 throw` if the word has no interpretation semantics.

If you want the execution token of *word*, write `['] word` in compiled code and `' word` in interpreted code. Gforth’s `'` and `[']` warns when you use them on compile-only words, because such usage may be non-portable between different Forth systems.

You can avoid that warning as well as the portability problems by defining an immediate variant of the word, e.g.:

<div class="example">

``` example
: if postpone if ; immediate
: test [ ' if execute ] ." test" then ;
```

</div>

The resulting execution token performs the compilation semantics of `if` when `execute`d.

Another way to get an XT is `:noname` or `latestxt` (see [Anonymous Definitions](Anonymous-Definitions.html#Anonymous-Definitions)). For anonymous words this gives an xt for the only behaviour the word has (the execution semantics). For named words, `latestxt` produces an XT for the same behaviour it would produce if the word was defined anonymously.

<div class="example">

``` example
:noname ." hello" ;
execute
```

</div>

An XT occupies one cell and can be manipulated like any other cell.

<span id="index-code-field-address"></span> <span id="index-CFA"></span>

In Standard Forth the XT is just an abstract data type (i.e., defined by the operations that produce or consume it). For old hands: In Gforth, the XT is implemented as a code field address (CFA).

<span id="index-execute--xt-_002d_002d--core"></span> <span id="index-execute"></span> <span id="index-execute-1"></span>

<div class="format">

``` format
execute       xt –        core       “execute”
```

</div>

Perform the semantics represented by the execution token, *xt*.

<span id="index-perform--a_002daddr-_002d_002d--gforth"></span> <span id="index-perform"></span> <span id="index-perform-1"></span>

<div class="format">

``` format
perform       a-addr –        gforth       “perform”
```

</div>

`@ execute`.

-----

<div class="header">

Next: [Compilation token](Compilation-token.html#Compilation-token), Previous: [Tokens for Words](Tokens-for-Words.html#Tokens-for-Words), Up: [Tokens for Words](Tokens-for-Words.html#Tokens-for-Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
