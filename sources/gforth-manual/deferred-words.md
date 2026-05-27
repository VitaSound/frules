> Source: https://gforth.org/manual/Deferred-Words.html

<span id="Deferred-Words"></span>

<div class="header">

Next: [Forward](Forward.html#Forward), Previous: [User-defined Defining Words](User_002ddefined-Defining-Words.html#User_002ddefined-Defining-Words), Up: [Defining Words](Defining-Words.html#Defining-Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Deferred-Words-1"></span>

#### 5.9.10 Deferred Words

<span id="index-deferred-words"></span>

The defining word `Defer` allows you to define a word by name without defining its behaviour; the definition of its behaviour is deferred. Here are two situation where this can be useful:

  - Where you want to allow the behaviour of a word to be altered later, and for all precompiled references to the word to change when its behaviour is changed.
  - For mutual recursion; See [Calls and returns](Calls-and-returns.html#Calls-and-returns).

In the following example, `foo` always invokes the version of `greet` that prints “`Good morning`” whilst `bar` always invokes the version that prints “`Hello`”. There is no way of getting `foo` to use the later version without re-ordering the source code and recompiling it.

<div class="example">

``` example
: greet ." Good morning" ;
: foo ... greet ... ;
: greet ." Hello" ;
: bar ... greet ... ;
```

</div>

This problem can be solved by defining `greet` as a `Defer`red word. The behaviour of a `Defer`red word can be defined and redefined at any time by using `IS` to associate the xt of a previously-defined word with it. The previous example becomes:

<div class="example">

``` example
Defer greet ( -- )
: foo ... greet ... ;
: bar ... greet ... ;
: greet1 ( -- ) ." Good morning" ;
: greet2 ( -- ) ." Hello" ;
' greet2 IS greet  \ make greet behave like greet2
```

</div>

Programming style note: You should write a stack comment for every deferred word, and put only XTs into deferred words that conform to this stack effect. Otherwise it’s too difficult to use the deferred word.

A deferred word can be used to improve the statistics-gathering example from [User-defined Defining Words](User_002ddefined-Defining-Words.html#User_002ddefined-Defining-Words); rather than edit the application’s source code to change every `:` to a `my:`, do this:

<div class="example">

``` example
: real: : ;     \ retain access to the original
defer :         \ redefine as a deferred word
' my: IS :      \ use special version of :
\
\ load application here
\
' real: IS :    \ go back to the original
```

</div>

One thing to note is that `IS` has special compilation semantics, such that it parses the name at compile time (like `TO`):

<div class="example">

``` example
: set-greet ( xt -- )
  IS greet ;

' greet1 set-greet
```

</div>

In situations where `IS` does not fit, use `defer!` instead.

A deferred word can only inherit execution semantics from the xt (because that is all that an xt can represent – for more discussion of this see [Tokens for Words](Tokens-for-Words.html#Tokens-for-Words)); by default it will have default interpretation and compilation semantics deriving from this execution semantics. However, you can change the interpretation and compilation semantics of the deferred word in the usual ways:

<div class="example">

``` example
: bar .... ; immediate
Defer fred immediate
Defer jim

' bar IS jim  \ jim has default semantics
' bar IS fred \ fred is immediate
```

</div>

<span id="index-Defer--_0022name_0022-_002d_002d--gforth"></span> <span id="index-Defer"></span> <span id="index-Defer-1"></span>

<div class="format">

``` format
Defer       "name" –         gforth       “Defer”
```

</div>

Define a deferred word *name*; its execution semantics can be set with `defer!` or `is` (and they have to, before first executing *name*.

<span id="index-defer_0021--xt-xt_002ddeferred-_002d_002d--gforth"></span> <span id="index-defer_0021"></span> <span id="index-defer_0021-1"></span>

<div class="format">

``` format
defer!       xt xt-deferred –         gforth       “defer-store”
```

</div>

Changes the `defer`red word `xt-deferred` to execute `xt`.

<span id="index-IS--value-_0022name_0022-_002d_002d--core_002dext"></span> <span id="index-IS"></span> <span id="index-IS-1"></span>

<div class="format">

``` format
IS       value "name" –         core-ext       “IS”
```

</div>

changes the `defer`red word `name` to execute `value`

<span id="index-defer_0040--xt_002ddeferred-_002d_002d-xt--gforth"></span> <span id="index-defer_0040"></span> <span id="index-defer_0040-1"></span>

<div class="format">

``` format
defer@       xt-deferred – xt         gforth       “defer-fetch”
```

</div>

*xt* represents the word currently associated with the deferred word *xt-deferred*.

<span id="index-action_002dof--interpretation-_0022name_0022-_002d_002d-xt_003b-compilation-_0022name_0022-_002d_002d-_003b-run_002dtime-_002d_002d-xt--core_002dext"></span> <span id="index-action_002dof"></span> <span id="index-action_002dof-1"></span>

<div class="format">

``` format
action-of       interpretation "name" – xt; compilation "name" – ; run-time – xt         core-ext       “action-of”
```

</div>

*Xt* is the XT that is currently assigned to *name*.

<span id="index-defers--compilation-_0022name_0022-_002d_002d-_003b-run_002dtime-_002e_002e_002e-_002d_002d-_002e_002e_002e--gforth"></span> <span id="index-defers"></span> <span id="index-defers-1"></span>

<div class="format">

``` format
defers       compilation "name" – ; run-time ... – ...         gforth       “defers”
```

</div>

Compiles the present contents of the deferred word *name* into the current definition. I.e., this produces static binding as if *name* was not deferred.

Definitions of these words (except `defers`) in Standard Forth are provided in `compat/defer.fs`.

-----

<div class="header">

Next: [Forward](Forward.html#Forward), Previous: [User-defined Defining Words](User_002ddefined-Defining-Words.html#User_002ddefined-Defining-Words), Up: [Defining Words](Defining-Words.html#Defining-Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
