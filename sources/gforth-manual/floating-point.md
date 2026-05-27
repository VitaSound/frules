> Source: https://gforth.org/manual/Floating-Point.html

<span id="Floating-Point"></span>

<div class="header">

Previous: [Mixed precision](Mixed-precision.html#Mixed-precision), Up: [Arithmetic](Arithmetic.html#Arithmetic)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Floating-Point-2"></span>

#### 5.5.6 Floating Point

<span id="index-floating-point-arithmetic-words"></span>

For the rules used by the text interpreter for recognising floating-point numbers see [Number Conversion](Number-Conversion.html#Number-Conversion).

Gforth has a separate floating point stack, but the documentation uses the unified notation.[<sup>9</sup>](#FOOT9)

<span id="index-floating_002dpoint-arithmetic_002c-pitfalls"></span>

Floating point numbers have a number of unpleasant surprises for the unwary (e.g., floating point addition is not associative) and even a few for the wary. You should not use them unless you know what you are doing or you don’t care that the results you get are totally bogus. If you want to learn about the problems of floating point numbers (and how to avoid them), you might start with David Goldberg, [What Every Computer Scientist Should Know About Floating-Point Arithmetic](http://docs.sun.com/source/806-3568/ncg_goldberg.html), ACM Computing Surveys 23(1):5-48, March 1991.

Conversion between integers and floating-point:

<span id="index-s_003ef--n-_002d_002d-r--float"></span> <span id="index-s_003ef"></span> <span id="index-s_003ef-1"></span>

<div class="format">

``` format
s>f       n – r        float       “s-to-f”
```

</div>

<span id="index-d_003ef--d-_002d_002d-r--float"></span> <span id="index-d_003ef"></span> <span id="index-d_003ef-1"></span>

<div class="format">

``` format
d>f       d – r        float       “d-to-f”
```

</div>

<span id="index-f_003es--r-_002d_002d-n--float"></span> <span id="index-f_003es"></span> <span id="index-f_003es-1"></span>

<div class="format">

``` format
f>s       r – n        float       “f-to-s”
```

</div>

<span id="index-f_003ed--r-_002d_002d-d--float"></span> <span id="index-f_003ed"></span> <span id="index-f_003ed-1"></span>

<div class="format">

``` format
f>d       r – d        float       “f-to-d”
```

</div>

Arithmetics:

<span id="index-f_002b--r1-r2-_002d_002d-r3--float"></span> <span id="index-f_002b"></span> <span id="index-f_002b-1"></span>

<div class="format">

``` format
f+       r1 r2 – r3        float       “f-plus”
```

</div>

<span id="index-f_002d--r1-r2-_002d_002d-r3--float"></span> <span id="index-f_002d"></span> <span id="index-f_002d-1"></span>

<div class="format">

``` format
f-       r1 r2 – r3        float       “f-minus”
```

</div>

<span id="index-f_002a--r1-r2-_002d_002d-r3--float"></span> <span id="index-f_002a"></span> <span id="index-f_002a-1"></span>

<div class="format">

``` format
f*       r1 r2 – r3        float       “f-star”
```

</div>

<span id="index-f_002f--r1-r2-_002d_002d-r3--float"></span> <span id="index-f_002f"></span> <span id="index-f_002f-1"></span>

<div class="format">

``` format
f/       r1 r2 – r3        float       “f-slash”
```

</div>

<span id="index-fnegate--r1-_002d_002d-r2--float"></span> <span id="index-fnegate"></span> <span id="index-fnegate-1"></span>

<div class="format">

``` format
fnegate       r1 – r2        float       “f-negate”
```

</div>

<span id="index-fabs--r1-_002d_002d-r2--float_002dext"></span> <span id="index-fabs"></span> <span id="index-fabs-1"></span>

<div class="format">

``` format
fabs       r1 – r2        float-ext       “f-abs”
```

</div>

<span id="index-fmax--r1-r2-_002d_002d-r3--float"></span> <span id="index-fmax"></span> <span id="index-fmax-1"></span>

<div class="format">

``` format
fmax       r1 r2 – r3        float       “f-max”
```

</div>

<span id="index-fmin--r1-r2-_002d_002d-r3--float"></span> <span id="index-fmin"></span> <span id="index-fmin-1"></span>

<div class="format">

``` format
fmin       r1 r2 – r3        float       “f-min”
```

</div>

<span id="index-floor--r1-_002d_002d-r2--float"></span> <span id="index-floor"></span> <span id="index-floor-1"></span>

<div class="format">

``` format
floor       r1 – r2        float       “floor”
```

</div>

Round towards the next smaller integral value, i.e., round toward negative infinity.

<span id="index-fround--r1-_002d_002d-r2--float"></span> <span id="index-fround"></span> <span id="index-fround-1"></span>

<div class="format">

``` format
fround       r1 – r2        float       “f-round”
```

</div>

Round to the nearest integral value.

<span id="index-f_002a_002a--r1-r2-_002d_002d-r3--float_002dext"></span> <span id="index-f_002a_002a"></span> <span id="index-f_002a_002a-1"></span>

<div class="format">

``` format
f**       r1 r2 – r3        float-ext       “f-star-star”
```

</div>

*r3* is *r1* raised to the *r2*th power.

<span id="index-fsqrt--r1-_002d_002d-r2--float_002dext"></span> <span id="index-fsqrt"></span> <span id="index-fsqrt-1"></span>

<div class="format">

``` format
fsqrt       r1 – r2        float-ext       “f-square-root”
```

</div>

<span id="index-fexp--r1-_002d_002d-r2--float_002dext"></span> <span id="index-fexp"></span> <span id="index-fexp-1"></span>

<div class="format">

``` format
fexp       r1 – r2        float-ext       “f-e-x-p”
```

</div>

<span id="index-fexpm1--r1-_002d_002d-r2--float_002dext"></span> <span id="index-fexpm1"></span> <span id="index-fexpm1-1"></span>

<div class="format">

``` format
fexpm1       r1 – r2        float-ext       “f-e-x-p-m-one”
```

</div>

*r2*=*e*\*\**r1*-1

<span id="index-fln--r1-_002d_002d-r2--float_002dext"></span> <span id="index-fln"></span> <span id="index-fln-1"></span>

<div class="format">

``` format
fln       r1 – r2        float-ext       “f-l-n”
```

</div>

<span id="index-flnp1--r1-_002d_002d-r2--float_002dext"></span> <span id="index-flnp1"></span> <span id="index-flnp1-1"></span>

<div class="format">

``` format
flnp1       r1 – r2        float-ext       “f-l-n-p-one”
```

</div>

*r2*=ln(*r1*+1)

<span id="index-flog--r1-_002d_002d-r2--float_002dext"></span> <span id="index-flog"></span> <span id="index-flog-1"></span>

<div class="format">

``` format
flog       r1 – r2        float-ext       “f-log”
```

</div>

The decimal logarithm.

<span id="index-falog--r1-_002d_002d-r2--float_002dext"></span> <span id="index-falog"></span> <span id="index-falog-1"></span>

<div class="format">

``` format
falog       r1 – r2        float-ext       “f-a-log”
```

</div>

*r2*=10\*\**r1*

<span id="index-f2_002a--r1-_002d_002d-r2--gforth"></span> <span id="index-f2_002a"></span> <span id="index-f2_002a-1"></span>

<div class="format">

``` format
f2*       r1 – r2         gforth       “f2*”
```

</div>

Multiply *r1* by 2.0e0

<span id="index-f2_002f--r1-_002d_002d-r2--gforth"></span> <span id="index-f2_002f"></span> <span id="index-f2_002f-1"></span>

<div class="format">

``` format
f2/       r1 – r2         gforth       “f2/”
```

</div>

Multiply *r1* by 0.5e0

<span id="index-1_002ff--r1-_002d_002d-r2--gforth"></span> <span id="index-1_002ff"></span> <span id="index-1_002ff-1"></span>

<div class="format">

``` format
1/f       r1 – r2         gforth       “1/f”
```

</div>

Divide 1.0e0 by *r1*.

<span id="index-angles-in-trigonometric-operations"></span> <span id="index-trigonometric-operations"></span>

Angles in floating point operations are given in radians (a full circle has 2 pi radians).

<span id="index-fsin--r1-_002d_002d-r2--float_002dext"></span> <span id="index-fsin"></span> <span id="index-fsin-1"></span>

<div class="format">

``` format
fsin       r1 – r2        float-ext       “f-sine”
```

</div>

<span id="index-fcos--r1-_002d_002d-r2--float_002dext"></span> <span id="index-fcos"></span> <span id="index-fcos-1"></span>

<div class="format">

``` format
fcos       r1 – r2        float-ext       “f-cos”
```

</div>

<span id="index-fsincos--r1-_002d_002d-r2-r3--float_002dext"></span> <span id="index-fsincos"></span> <span id="index-fsincos-1"></span>

<div class="format">

``` format
fsincos       r1 – r2 r3        float-ext       “f-sine-cos”
```

</div>

*r2*=sin(*r1*), *r3*=cos(*r1*)

<span id="index-ftan--r1-_002d_002d-r2--float_002dext"></span> <span id="index-ftan"></span> <span id="index-ftan-1"></span>

<div class="format">

``` format
ftan       r1 – r2        float-ext       “f-tan”
```

</div>

<span id="index-fasin--r1-_002d_002d-r2--float_002dext"></span> <span id="index-fasin"></span> <span id="index-fasin-1"></span>

<div class="format">

``` format
fasin       r1 – r2        float-ext       “f-a-sine”
```

</div>

<span id="index-facos--r1-_002d_002d-r2--float_002dext"></span> <span id="index-facos"></span> <span id="index-facos-1"></span>

<div class="format">

``` format
facos       r1 – r2        float-ext       “f-a-cos”
```

</div>

<span id="index-fatan--r1-_002d_002d-r2--float_002dext"></span> <span id="index-fatan"></span> <span id="index-fatan-1"></span>

<div class="format">

``` format
fatan       r1 – r2        float-ext       “f-a-tan”
```

</div>

<span id="index-fatan2--r1-r2-_002d_002d-r3--float_002dext"></span> <span id="index-fatan2"></span> <span id="index-fatan2-1"></span>

<div class="format">

``` format
fatan2       r1 r2 – r3        float-ext       “f-a-tan-two”
```

</div>

*r1/r2*=tan(*r3*). ANS Forth does not require, but probably intends this to be the inverse of `fsincos`. In gforth it is.

<span id="index-fsinh--r1-_002d_002d-r2--float_002dext"></span> <span id="index-fsinh"></span> <span id="index-fsinh-1"></span>

<div class="format">

``` format
fsinh       r1 – r2        float-ext       “f-cinch”
```

</div>

<span id="index-fcosh--r1-_002d_002d-r2--float_002dext"></span> <span id="index-fcosh"></span> <span id="index-fcosh-1"></span>

<div class="format">

``` format
fcosh       r1 – r2        float-ext       “f-cosh”
```

</div>

<span id="index-ftanh--r1-_002d_002d-r2--float_002dext"></span> <span id="index-ftanh"></span> <span id="index-ftanh-1"></span>

<div class="format">

``` format
ftanh       r1 – r2        float-ext       “f-tan-h”
```

</div>

<span id="index-fasinh--r1-_002d_002d-r2--float_002dext"></span> <span id="index-fasinh"></span> <span id="index-fasinh-1"></span>

<div class="format">

``` format
fasinh       r1 – r2        float-ext       “f-a-cinch”
```

</div>

<span id="index-facosh--r1-_002d_002d-r2--float_002dext"></span> <span id="index-facosh"></span> <span id="index-facosh-1"></span>

<div class="format">

``` format
facosh       r1 – r2        float-ext       “f-a-cosh”
```

</div>

<span id="index-fatanh--r1-_002d_002d-r2--float_002dext"></span> <span id="index-fatanh"></span> <span id="index-fatanh-1"></span>

<div class="format">

``` format
fatanh       r1 – r2        float-ext       “f-a-tan-h”
```

</div>

<span id="index-pi--_002d_002d-r--gforth"></span> <span id="index-pi"></span> <span id="index-pi-1"></span>

<div class="format">

``` format
pi       – r         gforth       “pi”
```

</div>

`Fconstant` – *r* is the value pi; the ratio of a circle’s area to its diameter.

<span id="index-equality-of-floats"></span> <span id="index-floating_002dpoint-comparisons"></span>

One particular problem with floating-point arithmetic is that comparison for equality often fails when you would expect it to succeed. For this reason approximate equality is often preferred (but you still have to know what you are doing). Also note that IEEE NaNs may compare differently from what you might expect. The comparison words are:

<span id="index-f_007erel--r1-r2-r3-_002d_002d-flag--gforth"></span> <span id="index-f_007erel"></span> <span id="index-f_007erel-1"></span>

<div class="format">

``` format
f~rel       r1 r2 r3 – flag         gforth       “f~rel”
```

</div>

Approximate equality with relative error: |r1-r2|\<r3\*|r1+r2|.

<span id="index-f_007eabs--r1-r2-r3-_002d_002d-flag--gforth"></span> <span id="index-f_007eabs"></span> <span id="index-f_007eabs-1"></span>

<div class="format">

``` format
f~abs       r1 r2 r3 – flag         gforth       “f~abs”
```

</div>

Approximate equality with absolute error: |r1-r2|\<r3.

<span id="index-f_007e--r1-r2-r3-_002d_002d-flag--float_002dext"></span> <span id="index-f_007e"></span> <span id="index-f_007e-1"></span>

<div class="format">

``` format
f~       r1 r2 r3 – flag         float-ext       “f-proximate”
```

</div>

ANS Forth medley for comparing r1 and r2 for equality: r3\>0: `f~abs`; r3=0: bitwise comparison; r3\<0: `fnegate f~rel`.

<span id="index-f_003d--r1-r2-_002d_002d-f--gforth"></span> <span id="index-f_003d"></span> <span id="index-f_003d-1"></span>

<div class="format">

``` format
f=       r1 r2 – f        gforth       “f-equals”
```

</div>

<span id="index-f_003c_003e--r1-r2-_002d_002d-f--gforth"></span> <span id="index-f_003c_003e"></span> <span id="index-f_003c_003e-1"></span>

<div class="format">

``` format
f<>       r1 r2 – f        gforth       “f-not-equals”
```

</div>

<span id="index-f_003c--r1-r2-_002d_002d-f--float"></span> <span id="index-f_003c"></span> <span id="index-f_003c-1"></span>

<div class="format">

``` format
f<       r1 r2 – f        float       “f-less-than”
```

</div>

<span id="index-f_003c_003d--r1-r2-_002d_002d-f--gforth"></span> <span id="index-f_003c_003d"></span> <span id="index-f_003c_003d-1"></span>

<div class="format">

``` format
f<=       r1 r2 – f        gforth       “f-less-or-equal”
```

</div>

<span id="index-f_003e--r1-r2-_002d_002d-f--gforth"></span> <span id="index-f_003e"></span> <span id="index-f_003e-1"></span>

<div class="format">

``` format
f>       r1 r2 – f        gforth       “f-greater-than”
```

</div>

<span id="index-f_003e_003d--r1-r2-_002d_002d-f--gforth"></span> <span id="index-f_003e_003d"></span> <span id="index-f_003e_003d-1"></span>

<div class="format">

``` format
f>=       r1 r2 – f        gforth       “f-greater-or-equal”
```

</div>

<span id="index-f0_003c--r-_002d_002d-f--float"></span> <span id="index-f0_003c"></span> <span id="index-f0_003c-1"></span>

<div class="format">

``` format
f0<       r – f        float       “f-zero-less-than”
```

</div>

<span id="index-f0_003c_003d--r-_002d_002d-f--gforth"></span> <span id="index-f0_003c_003d"></span> <span id="index-f0_003c_003d-1"></span>

<div class="format">

``` format
f0<=       r – f        gforth       “f-zero-less-or-equal”
```

</div>

<span id="index-f0_003c_003e--r-_002d_002d-f--gforth"></span> <span id="index-f0_003c_003e"></span> <span id="index-f0_003c_003e-1"></span>

<div class="format">

``` format
f0<>       r – f        gforth       “f-zero-not-equals”
```

</div>

<span id="index-f0_003d--r-_002d_002d-f--float"></span> <span id="index-f0_003d"></span> <span id="index-f0_003d-1"></span>

<div class="format">

``` format
f0=       r – f        float       “f-zero-equals”
```

</div>

<span id="index-f0_003e--r-_002d_002d-f--gforth"></span> <span id="index-f0_003e"></span> <span id="index-f0_003e-1"></span>

<div class="format">

``` format
f0>       r – f        gforth       “f-zero-greater-than”
```

</div>

<span id="index-f0_003e_003d--r-_002d_002d-f--gforth"></span> <span id="index-f0_003e_003d"></span> <span id="index-f0_003e_003d-1"></span>

<div class="format">

``` format
f0>=       r – f        gforth       “f-zero-greater-or-equal”
```

</div>

<div class="footnote">

-----

#### Footnotes

### [(9)](#DOCF9)

It’s easy to generate the separate notation from that by just separating the floating-point numbers out: e.g. `( n r1 u r2 -- r3 )` becomes `( n u -- ) ( F: r1 r2 -- r3 )`.

</div>

-----

<div class="header">

Previous: [Mixed precision](Mixed-precision.html#Mixed-precision), Up: [Arithmetic](Arithmetic.html#Arithmetic)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
