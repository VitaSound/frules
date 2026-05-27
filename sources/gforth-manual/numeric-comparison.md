> Source: https://gforth.org/manual/Numeric-comparison.html

<span id="Numeric-comparison"></span>

<div class="header">

Next: [Mixed precision](Mixed-precision.html#Mixed-precision), Previous: [Bitwise operations](Bitwise-operations.html#Bitwise-operations), Up: [Arithmetic](Arithmetic.html#Arithmetic)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Numeric-comparison-1"></span>

#### 5.5.4 Numeric comparison

<span id="index-numeric-comparison-words"></span>

Note that the words that compare for equality (`= <> 0= 0<> d= d<> d0= d0<>`) work for for both signed and unsigned numbers.

<span id="index-_003c--n1-n2-_002d_002d-f--core"></span> <span id="index-_003c"></span> <span id="index-_003c-1"></span>

<div class="format">

``` format
<       n1 n2 – f        core       “less-than”
```

</div>

<span id="index-_003c_003d--n1-n2-_002d_002d-f--gforth"></span> <span id="index-_003c_003d"></span> <span id="index-_003c_003d-1"></span>

<div class="format">

``` format
<=       n1 n2 – f        gforth       “less-or-equal”
```

</div>

<span id="index-_003c_003e--n1-n2-_002d_002d-f--core_002dext"></span> <span id="index-_003c_003e"></span> <span id="index-_003c_003e-1"></span>

<div class="format">

``` format
<>       n1 n2 – f        core-ext       “not-equals”
```

</div>

<span id="index-_003d--n1-n2-_002d_002d-f--core"></span> <span id="index-_003d"></span> <span id="index-_003d-1"></span>

<div class="format">

``` format
=       n1 n2 – f        core       “equals”
```

</div>

<span id="index-_003e--n1-n2-_002d_002d-f--core"></span> <span id="index-_003e"></span> <span id="index-_003e-1"></span>

<div class="format">

``` format
>       n1 n2 – f        core       “greater-than”
```

</div>

<span id="index-_003e_003d--n1-n2-_002d_002d-f--gforth"></span> <span id="index-_003e_003d"></span> <span id="index-_003e_003d-1"></span>

<div class="format">

``` format
>=       n1 n2 – f        gforth       “greater-or-equal”
```

</div>

<span id="index-0_003c--n-_002d_002d-f--core"></span> <span id="index-0_003c"></span> <span id="index-0_003c-1"></span>

<div class="format">

``` format
0<       n – f        core       “zero-less-than”
```

</div>

<span id="index-0_003c_003d--n-_002d_002d-f--gforth"></span> <span id="index-0_003c_003d"></span> <span id="index-0_003c_003d-1"></span>

<div class="format">

``` format
0<=       n – f        gforth       “zero-less-or-equal”
```

</div>

<span id="index-0_003c_003e--n-_002d_002d-f--core_002dext"></span> <span id="index-0_003c_003e"></span> <span id="index-0_003c_003e-1"></span>

<div class="format">

``` format
0<>       n – f        core-ext       “zero-not-equals”
```

</div>

<span id="index-0_003d--n-_002d_002d-f--core"></span> <span id="index-0_003d"></span> <span id="index-0_003d-1"></span>

<div class="format">

``` format
0=       n – f        core       “zero-equals”
```

</div>

<span id="index-0_003e--n-_002d_002d-f--core_002dext"></span> <span id="index-0_003e"></span> <span id="index-0_003e-1"></span>

<div class="format">

``` format
0>       n – f        core-ext       “zero-greater-than”
```

</div>

<span id="index-0_003e_003d--n-_002d_002d-f--gforth"></span> <span id="index-0_003e_003d"></span> <span id="index-0_003e_003d-1"></span>

<div class="format">

``` format
0>=       n – f        gforth       “zero-greater-or-equal”
```

</div>

<span id="index-u_003c--u1-u2-_002d_002d-f--core"></span> <span id="index-u_003c"></span> <span id="index-u_003c-1"></span>

<div class="format">

``` format
u<       u1 u2 – f        core       “u-less-than”
```

</div>

<span id="index-u_003c_003d--u1-u2-_002d_002d-f--gforth"></span> <span id="index-u_003c_003d"></span> <span id="index-u_003c_003d-1"></span>

<div class="format">

``` format
u<=       u1 u2 – f        gforth       “u-less-or-equal”
```

</div>

<span id="index-u_003e--u1-u2-_002d_002d-f--core_002dext"></span> <span id="index-u_003e"></span> <span id="index-u_003e-1"></span>

<div class="format">

``` format
u>       u1 u2 – f        core-ext       “u-greater-than”
```

</div>

<span id="index-u_003e_003d--u1-u2-_002d_002d-f--gforth"></span> <span id="index-u_003e_003d"></span> <span id="index-u_003e_003d-1"></span>

<div class="format">

``` format
u>=       u1 u2 – f        gforth       “u-greater-or-equal”
```

</div>

<span id="index-within--u1-u2-u3-_002d_002d-f--core_002dext"></span> <span id="index-within"></span> <span id="index-within-1"></span>

<div class="format">

``` format
within       u1 u2 u3 – f        core-ext       “within”
```

</div>

u2\<u3 and u1 in \[u2,u3) or: u2\>=u3 and u1 not in \[u3,u2). This works for unsigned and signed numbers (but not a mixture). Another way to think about this word is to consider the numbers as a circle (wrapping around from `max-u` to 0 for unsigned, and from `max-n` to min-n for signed numbers); now consider the range from u2 towards increasing numbers up to and excluding u3 (giving an empty range if u2=u3); if u1 is in this range, `within` returns true.

<span id="index-d_003c--d1-d2-_002d_002d-f--double"></span> <span id="index-d_003c"></span> <span id="index-d_003c-1"></span>

<div class="format">

``` format
d<       d1 d2 – f        double       “d-less-than”
```

</div>

<span id="index-d_003c_003d--d1-d2-_002d_002d-f--gforth"></span> <span id="index-d_003c_003d"></span> <span id="index-d_003c_003d-1"></span>

<div class="format">

``` format
d<=       d1 d2 – f        gforth       “d-less-or-equal”
```

</div>

<span id="index-d_003c_003e--d1-d2-_002d_002d-f--gforth"></span> <span id="index-d_003c_003e"></span> <span id="index-d_003c_003e-1"></span>

<div class="format">

``` format
d<>       d1 d2 – f        gforth       “d-not-equals”
```

</div>

<span id="index-d_003d--d1-d2-_002d_002d-f--double"></span> <span id="index-d_003d"></span> <span id="index-d_003d-1"></span>

<div class="format">

``` format
d=       d1 d2 – f        double       “d-equals”
```

</div>

<span id="index-d_003e--d1-d2-_002d_002d-f--gforth"></span> <span id="index-d_003e"></span> <span id="index-d_003e-1"></span>

<div class="format">

``` format
d>       d1 d2 – f        gforth       “d-greater-than”
```

</div>

<span id="index-d_003e_003d--d1-d2-_002d_002d-f--gforth"></span> <span id="index-d_003e_003d"></span> <span id="index-d_003e_003d-1"></span>

<div class="format">

``` format
d>=       d1 d2 – f        gforth       “d-greater-or-equal”
```

</div>

<span id="index-d0_003c--d-_002d_002d-f--double"></span> <span id="index-d0_003c"></span> <span id="index-d0_003c-1"></span>

<div class="format">

``` format
d0<       d – f        double       “d-zero-less-than”
```

</div>

<span id="index-d0_003c_003d--d-_002d_002d-f--gforth"></span> <span id="index-d0_003c_003d"></span> <span id="index-d0_003c_003d-1"></span>

<div class="format">

``` format
d0<=       d – f        gforth       “d-zero-less-or-equal”
```

</div>

<span id="index-d0_003c_003e--d-_002d_002d-f--gforth"></span> <span id="index-d0_003c_003e"></span> <span id="index-d0_003c_003e-1"></span>

<div class="format">

``` format
d0<>       d – f        gforth       “d-zero-not-equals”
```

</div>

<span id="index-d0_003d--d-_002d_002d-f--double"></span> <span id="index-d0_003d"></span> <span id="index-d0_003d-1"></span>

<div class="format">

``` format
d0=       d – f        double       “d-zero-equals”
```

</div>

<span id="index-d0_003e--d-_002d_002d-f--gforth"></span> <span id="index-d0_003e"></span> <span id="index-d0_003e-1"></span>

<div class="format">

``` format
d0>       d – f        gforth       “d-zero-greater-than”
```

</div>

<span id="index-d0_003e_003d--d-_002d_002d-f--gforth"></span> <span id="index-d0_003e_003d"></span> <span id="index-d0_003e_003d-1"></span>

<div class="format">

``` format
d0>=       d – f        gforth       “d-zero-greater-or-equal”
```

</div>

<span id="index-du_003c--ud1-ud2-_002d_002d-f--double_002dext"></span> <span id="index-du_003c"></span> <span id="index-du_003c-1"></span>

<div class="format">

``` format
du<       ud1 ud2 – f        double-ext       “d-u-less-than”
```

</div>

<span id="index-du_003c_003d--ud1-ud2-_002d_002d-f--gforth"></span> <span id="index-du_003c_003d"></span> <span id="index-du_003c_003d-1"></span>

<div class="format">

``` format
du<=       ud1 ud2 – f        gforth       “d-u-less-or-equal”
```

</div>

<span id="index-du_003e--ud1-ud2-_002d_002d-f--gforth"></span> <span id="index-du_003e"></span> <span id="index-du_003e-1"></span>

<div class="format">

``` format
du>       ud1 ud2 – f        gforth       “d-u-greater-than”
```

</div>

<span id="index-du_003e_003d--ud1-ud2-_002d_002d-f--gforth"></span> <span id="index-du_003e_003d"></span> <span id="index-du_003e_003d-1"></span>

<div class="format">

``` format
du>=       ud1 ud2 – f        gforth       “d-u-greater-or-equal”
```

</div>

-----

<div class="header">

Next: [Mixed precision](Mixed-precision.html#Mixed-precision), Previous: [Bitwise operations](Bitwise-operations.html#Bitwise-operations), Up: [Arithmetic](Arithmetic.html#Arithmetic)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
