> Source: https://gforth.org/manual/Single-precision.html

<span id="Single-precision"></span>

<div class="header">

Next: [Double precision](Double-precision.html#Double-precision), Previous: [Arithmetic](Arithmetic.html#Arithmetic), Up: [Arithmetic](Arithmetic.html#Arithmetic)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Single-precision-1"></span>

#### 5.5.1 Single precision

<span id="index-single-precision-arithmetic-words"></span>

By default, numbers in Forth are single-precision integers that are one cell in size. They can be signed or unsigned, depending upon how you treat them. For the rules used by the text interpreter for recognising single-precision integers see [Number Conversion](Number-Conversion.html#Number-Conversion).

These words are all defined for signed operands, but some of them also work for unsigned numbers: `+`, `1+`, `-`, `1-`, `*`.

<span id="index-_002b--n1-n2-_002d_002d-n--core"></span> <span id="index-_002b"></span> <span id="index-_002b-1"></span>

<div class="format">

``` format
+       n1 n2 – n        core       “plus”
```

</div>

<span id="index-1_002b--n1-_002d_002d-n2--core"></span> <span id="index-1_002b"></span> <span id="index-1_002b-1"></span>

<div class="format">

``` format
1+       n1 – n2        core       “one-plus”
```

</div>

<span id="index-under_002b--n1-n2-n3-_002d_002d-n-n2--gforth"></span> <span id="index-under_002b"></span> <span id="index-under_002b-1"></span>

<div class="format">

``` format
under+       n1 n2 n3 – n n2        gforth       “under-plus”
```

</div>

add *n3* to *n1* (giving *n*)

<span id="index-_002d--n1-n2-_002d_002d-n--core"></span> <span id="index-_002d"></span> <span id="index-_002d-1"></span>

<div class="format">

``` format
-       n1 n2 – n        core       “minus”
```

</div>

<span id="index-1_002d--n1-_002d_002d-n2--core"></span> <span id="index-1_002d"></span> <span id="index-1_002d-1"></span>

<div class="format">

``` format
1-       n1 – n2        core       “one-minus”
```

</div>

<span id="index-_002a--n1-n2-_002d_002d-n--core"></span> <span id="index-_002a"></span> <span id="index-_002a-1"></span>

<div class="format">

``` format
*       n1 n2 – n        core       “star”
```

</div>

<span id="index-_002f--n1-n2-_002d_002d-n--core"></span> <span id="index-_002f"></span> <span id="index-_002f-1"></span>

<div class="format">

``` format
/       n1 n2 – n        core       “slash”
```

</div>

<span id="index-mod--n1-n2-_002d_002d-n--core"></span> <span id="index-mod"></span> <span id="index-mod-1"></span>

<div class="format">

``` format
mod       n1 n2 – n        core       “mod”
```

</div>

<span id="index-_002fmod--n1-n2-_002d_002d-n3-n4--core"></span> <span id="index-_002fmod"></span> <span id="index-_002fmod-1"></span>

<div class="format">

``` format
/mod       n1 n2 – n3 n4        core       “slash-mod”
```

</div>

<span id="index-negate--n1-_002d_002d-n2--core"></span> <span id="index-negate"></span> <span id="index-negate-1"></span>

<div class="format">

``` format
negate       n1 – n2        core       “negate”
```

</div>

<span id="index-abs--n-_002d_002d-u--core"></span> <span id="index-abs"></span> <span id="index-abs-1"></span>

<div class="format">

``` format
abs       n – u        core       “abs”
```

</div>

<span id="index-min--n1-n2-_002d_002d-n--core"></span> <span id="index-min"></span> <span id="index-min-1"></span>

<div class="format">

``` format
min       n1 n2 – n        core       “min”
```

</div>

<span id="index-max--n1-n2-_002d_002d-n--core"></span> <span id="index-max"></span> <span id="index-max-1"></span>

<div class="format">

``` format
max       n1 n2 – n        core       “max”
```

</div>

<span id="index-FLOORED--_002d_002d-f--environment"></span> <span id="index-FLOORED"></span> <span id="index-FLOORED-1"></span>

<div class="format">

``` format
FLOORED       – f         environment       “FLOORED”
```

</div>

True if `/` etc. perform floored division

-----

<div class="header">

Next: [Double precision](Double-precision.html#Double-precision), Previous: [Arithmetic](Arithmetic.html#Arithmetic), Up: [Arithmetic](Arithmetic.html#Arithmetic)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
