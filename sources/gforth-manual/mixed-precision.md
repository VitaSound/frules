> Source: https://gforth.org/manual/Mixed-precision.html

<span id="Mixed-precision"></span>

<div class="header">

Next: [Floating Point](Floating-Point.html#Floating-Point), Previous: [Numeric comparison](Numeric-comparison.html#Numeric-comparison), Up: [Arithmetic](Arithmetic.html#Arithmetic)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Mixed-precision-1"></span>

#### 5.5.5 Mixed precision

<span id="index-mixed-precision-arithmetic-words"></span> <span id="index-m_002b--d1-n-_002d_002d-d2--double"></span> <span id="index-m_002b"></span> <span id="index-m_002b-1"></span>

<div class="format">

``` format
m+       d1 n – d2        double       “m-plus”
```

</div>

<span id="index-_002a_002f--n1-n2-n3-_002d_002d-n4--core"></span> <span id="index-_002a_002f"></span> <span id="index-_002a_002f-1"></span>

<div class="format">

``` format
*/       n1 n2 n3 – n4        core       “star-slash”
```

</div>

n4=(n1\*n2)/n3, with the intermediate result being double.

<span id="index-_002a_002fmod--n1-n2-n3-_002d_002d-n4-n5--core"></span> <span id="index-_002a_002fmod"></span> <span id="index-_002a_002fmod-1"></span>

<div class="format">

``` format
*/mod       n1 n2 n3 – n4 n5        core       “star-slash-mod”
```

</div>

n1\*n2=n3\*n5+n4, with the intermediate result (n1\*n2) being double.

<span id="index-m_002a--n1-n2-_002d_002d-d--core"></span> <span id="index-m_002a"></span> <span id="index-m_002a-1"></span>

<div class="format">

``` format
m*       n1 n2 – d        core       “m-star”
```

</div>

<span id="index-um_002a--u1-u2-_002d_002d-ud--core"></span> <span id="index-um_002a"></span> <span id="index-um_002a-1"></span>

<div class="format">

``` format
um*       u1 u2 – ud        core       “u-m-star”
```

</div>

<span id="index-m_002a_002f--d1-n2-u3-_002d_002d-dquot--double"></span> <span id="index-m_002a_002f"></span> <span id="index-m_002a_002f-1"></span>

<div class="format">

``` format
m*/       d1 n2 u3 – dquot         double       “m-star-slash”
```

</div>

dquot=(d1\*n2)/u3, with the intermediate result being triple-precision. In ANS Forth u3 can only be a positive signed number.

<span id="index-um_002fmod--ud-u1-_002d_002d-u2-u3--core"></span> <span id="index-um_002fmod"></span> <span id="index-um_002fmod-1"></span>

<div class="format">

``` format
um/mod       ud u1 – u2 u3        core       “u-m-slash-mod”
```

</div>

ud=u3\*u1+u2, u1\>u2\>=0

<span id="index-fm_002fmod--d1-n1-_002d_002d-n2-n3--core"></span> <span id="index-fm_002fmod"></span> <span id="index-fm_002fmod-1"></span>

<div class="format">

``` format
fm/mod       d1 n1 – n2 n3        core       “f-m-slash-mod”
```

</div>

Floored division: *d1* = *n3*\**n1*+*n2*, *n1*\>*n2*\>=0 or 0\>=*n2*\>*n1*.

<span id="index-sm_002frem--d1-n1-_002d_002d-n2-n3--core"></span> <span id="index-sm_002frem"></span> <span id="index-sm_002frem-1"></span>

<div class="format">

``` format
sm/rem       d1 n1 – n2 n3        core       “s-m-slash-rem”
```

</div>

Symmetric division: *d1* = *n3*\**n1*+*n2*, sign(*n2*)=sign(*d1*) or 0.
