> Source: https://gforth.org/manual/Bitwise-operations.html

<span id="Bitwise-operations"></span>

<div class="header">

Next: [Numeric comparison](Numeric-comparison.html#Numeric-comparison), Previous: [Double precision](Double-precision.html#Double-precision), Up: [Arithmetic](Arithmetic.html#Arithmetic)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Bitwise-operations-1"></span>

#### 5.5.3 Bitwise operations

<span id="index-bitwise-operation-words"></span> <span id="index-and--w1-w2-_002d_002d-w--core"></span> <span id="index-and"></span> <span id="index-and-1"></span>

<div class="format">

``` format
and       w1 w2 – w        core       “and”
```

</div>

<span id="index-or--w1-w2-_002d_002d-w--core"></span> <span id="index-or"></span> <span id="index-or-1"></span>

<div class="format">

``` format
or       w1 w2 – w        core       “or”
```

</div>

<span id="index-xor--w1-w2-_002d_002d-w--core"></span> <span id="index-xor"></span> <span id="index-xor-1"></span>

<div class="format">

``` format
xor       w1 w2 – w        core       “x-or”
```

</div>

<span id="index-invert--w1-_002d_002d-w2--core"></span> <span id="index-invert"></span> <span id="index-invert-1"></span>

<div class="format">

``` format
invert       w1 – w2        core       “invert”
```

</div>

<span id="index-lshift--u1-n-_002d_002d-u2--core"></span> <span id="index-lshift"></span> <span id="index-lshift-1"></span>

<div class="format">

``` format
lshift       u1 n – u2        core       “l-shift”
```

</div>

<span id="index-rshift--u1-n-_002d_002d-u2--core"></span> <span id="index-rshift"></span> <span id="index-rshift-1"></span>

<div class="format">

``` format
rshift       u1 n – u2        core       “r-shift”
```

</div>

Logical shift right by *n* bits.

<span id="index-2_002a--n1-_002d_002d-n2--core"></span> <span id="index-2_002a"></span> <span id="index-2_002a-1"></span>

<div class="format">

``` format
2*       n1 – n2        core       “two-star”
```

</div>

Shift left by 1; also works on unsigned numbers

<span id="index-d2_002a--d1-_002d_002d-d2--double"></span> <span id="index-d2_002a"></span> <span id="index-d2_002a-1"></span>

<div class="format">

``` format
d2*       d1 – d2        double       “d-two-star”
```

</div>

Shift left by 1; also works on unsigned numbers

<span id="index-2_002f--n1-_002d_002d-n2--core"></span> <span id="index-2_002f"></span> <span id="index-2_002f-1"></span>

<div class="format">

``` format
2/       n1 – n2        core       “two-slash”
```

</div>

Arithmetic shift right by 1. For signed numbers this is a floored division by 2 (note that `/` not necessarily floors).

<span id="index-d2_002f--d1-_002d_002d-d2--double"></span> <span id="index-d2_002f"></span> <span id="index-d2_002f-1"></span>

<div class="format">

``` format
d2/       d1 – d2        double       “d-two-slash”
```

</div>

Arithmetic shift right by 1. For signed numbers this is a floored division by 2.
