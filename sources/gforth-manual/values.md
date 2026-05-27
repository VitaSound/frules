> Source: https://gforth.org/manual/Values.html

<span id="Values"></span>

<div class="header">

Next: [Colon Definitions](Colon-Definitions.html#Colon-Definitions), Previous: [Constants](Constants.html#Constants), Up: [Defining Words](Defining-Words.html#Defining-Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Values-1"></span>

#### 5.9.4 Values

<span id="index-values"></span>

A `Value` behaves like a `Constant`, but it can be changed. `TO` is a parsing word that changes a `Values`. In Gforth (not in Standard Forth) you can access (and change) a `value` also with `>body`.

Here are some examples:

<div class="example">

``` example
12 Value APPLES     \ Define APPLES with an initial value of 12
34 TO APPLES        \ Change the value of APPLES. TO is a parsing word
1 ' APPLES >body +! \ Increment APPLES.  Non-standard usage.
APPLES              \ puts 35 on the top of the stack.
```

</div>

<span id="index-Value--w-_0022name_0022-_002d_002d--core_002dext"></span> <span id="index-Value"></span> <span id="index-Value-1"></span>

<div class="format">

``` format
Value       w "name" –         core-ext       “Value”
```

</div>

<span id="index-TO--value-_0022name_0022-_002d_002d--core_002dext"></span> <span id="index-TO"></span> <span id="index-TO-1"></span>

<div class="format">

``` format
TO       value "name" –         core-ext       “TO”
```

</div>

changes the value of `name` to `value`

<span id="index-_002bTO--value-_0022name_0022-_002d_002d--gforth"></span> <span id="index-_002bTO"></span> <span id="index-_002bTO-1"></span>

<div class="format">

``` format
+TO       value "name" –         gforth       “+TO”
```

</div>

increments the value of `name` by `value`

<span id="index-addr--_0022name_0022-_002d_002d-addr--gforth"></span> <span id="index-addr"></span> <span id="index-addr-1"></span>

<div class="format">

``` format
addr       "name" – addr         gforth       “addr”
```

</div>

provides the address `addr` of the value stored in `name`
