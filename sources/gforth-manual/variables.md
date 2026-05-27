> Source: https://gforth.org/manual/Variables.html

<span id="Variables"></span>

<div class="header">

Next: [Constants](Constants.html#Constants), Previous: [CREATE](CREATE.html#CREATE), Up: [Defining Words](Defining-Words.html#Defining-Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Variables-1"></span>

#### 5.9.2 Variables

<span id="index-variables"></span>

The previous section showed how a sequence of commands could be used to generate a variable. As a final refinement, the whole code sequence can be wrapped up in a defining word (pre-empting the subject of the next section), making it easier to create new variables:

<div class="example">

``` example
: myvariableX ( "name" -- a-addr ) CREATE 1 cells allot ;
: myvariable0 ( "name" -- a-addr ) CREATE 0 , ;

myvariableX foo \ variable foo starts off with an unknown value
myvariable0 joe \ whilst joe is initialised to 0

45 3 * foo !   \ set foo to 135
1234 joe !     \ set joe to 1234
3 joe +!       \ increment joe by 3.. to 1237
```

</div>

Not surprisingly, there is no need to define `myvariable`, since Forth already has a definition `Variable`. Standard Forth does not guarantee that a `Variable` is initialised when it is created (i.e., it may behave like `myvariableX`). In contrast, Gforth’s `Variable` initialises the variable to 0 (i.e., it behaves exactly like `myvariable0`). Forth also provides `2Variable` and `fvariable` for double and floating-point variables, respectively – they are initialised to 0. and 0e in Gforth. If you use a `Variable` to store a boolean, you can use `on` and `off` to toggle its state.

<span id="index-Variable--_0022name_0022-_002d_002d--core"></span> <span id="index-Variable"></span> <span id="index-Variable-1"></span>

<div class="format">

``` format
Variable       "name" –         core       “Variable”
```

</div>

<span id="index-2Variable--_0022name_0022-_002d_002d--double"></span> <span id="index-2Variable"></span> <span id="index-2Variable-1"></span>

<div class="format">

``` format
2Variable       "name" –         double       “two-variable”
```

</div>

<span id="index-fvariable--_0022name_0022-_002d_002d--float"></span> <span id="index-fvariable"></span> <span id="index-fvariable-1"></span>

<div class="format">

``` format
fvariable       "name" –         float       “f-variable”
```

</div>

<span id="index-user-variables"></span> <span id="index-user-space"></span>

The defining word `User` behaves in the same way as `Variable`. The difference is that it reserves space in *user (data) space* rather than normal data space. In a Forth system that has a multi-tasker, each task has its own set of user variables.

<span id="index-User--_0022name_0022-_002d_002d--gforth"></span> <span id="index-User"></span> <span id="index-User-1"></span>

<div class="format">

``` format
User       "name" –         gforth       “User”
```

</div>

-----

<div class="header">

Next: [Constants](Constants.html#Constants), Previous: [CREATE](CREATE.html#CREATE), Up: [Defining Words](Defining-Words.html#Defining-Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
