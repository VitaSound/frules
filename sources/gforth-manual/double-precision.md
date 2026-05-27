> Source: https://gforth.org/manual/Double-precision.html

<span id="Double-precision"></span>

<div class="header">

Next: [Bitwise operations](Bitwise-operations.html#Bitwise-operations), Previous: [Single precision](Single-precision.html#Single-precision), Up: [Arithmetic](Arithmetic.html#Arithmetic)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Double-precision-1"></span>

#### 5.5.2 Double precision

<span id="index-double-precision-arithmetic-words"></span>

For the rules used by the text interpreter for recognising double-precision integers, see [Number Conversion](Number-Conversion.html#Number-Conversion).

A double precision number is represented by a cell pair, with the most significant cell at the TOS. It is trivial to convert an unsigned single to a double: simply push a `0` onto the TOS. Since numbers are represented by Gforth using 2’s complement arithmetic, converting a signed single to a (signed) double requires sign-extension across the most significant cell. This can be achieved using `s>d`. The moral of the story is that you cannot convert a number without knowing whether it represents an unsigned or a signed number.

These words are all defined for signed operands, but some of them also work for unsigned numbers: `d+`, `d-`.

<span id="index-s_003ed--n-_002d_002d-d--core"></span> <span id="index-s_003ed"></span> <span id="index-s_003ed-1"></span>

<div class="format">

``` format
s>d       n – d         core       “s-to-d”
```

</div>

<span id="index-d_003es--d-_002d_002d-n--double"></span> <span id="index-d_003es"></span> <span id="index-d_003es-1"></span>

<div class="format">

``` format
d>s       d – n         double       “d-to-s”
```

</div>

<span id="index-d_002b--d1-d2-_002d_002d-d--double"></span> <span id="index-d_002b"></span> <span id="index-d_002b-1"></span>

<div class="format">

``` format
d+       d1 d2 – d        double       “d-plus”
```

</div>

<span id="index-d_002d--d1-d2-_002d_002d-d--double"></span> <span id="index-d_002d"></span> <span id="index-d_002d-1"></span>

<div class="format">

``` format
d-       d1 d2 – d        double       “d-minus”
```

</div>

<span id="index-dnegate--d1-_002d_002d-d2--double"></span> <span id="index-dnegate"></span> <span id="index-dnegate-1"></span>

<div class="format">

``` format
dnegate       d1 – d2        double       “d-negate”
```

</div>

<span id="index-dabs--d-_002d_002d-ud--double"></span> <span id="index-dabs"></span> <span id="index-dabs-1"></span>

<div class="format">

``` format
dabs       d – ud         double       “d-abs”
```

</div>

<span id="index-dmin--d1-d2-_002d_002d-d--double"></span> <span id="index-dmin"></span> <span id="index-dmin-1"></span>

<div class="format">

``` format
dmin       d1 d2 – d         double       “d-min”
```

</div>

<span id="index-dmax--d1-d2-_002d_002d-d--double"></span> <span id="index-dmax"></span> <span id="index-dmax-1"></span>

<div class="format">

``` format
dmax       d1 d2 – d         double       “d-max”
```

</div>

-----

<div class="header">

Next: [Bitwise operations](Bitwise-operations.html#Bitwise-operations), Previous: [Single precision](Single-precision.html#Single-precision), Up: [Arithmetic](Arithmetic.html#Arithmetic)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
