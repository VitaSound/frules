> Source: https://gforth.org/manual/Return-stack.html

<span id="Return-stack"></span>

<div class="header">

Next: [Locals stack](Locals-stack.html#Locals-stack), Previous: [Floating point stack](Floating-point-stack.html#Floating-point-stack), Up: [Stack Manipulation](Stack-Manipulation.html#Stack-Manipulation)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Return-stack-1"></span>

#### 5.6.3 Return stack

<span id="index-return-stack-manipulation-words"></span> <span id="index-stack-manipulation-words_002c-return-stack"></span> <span id="index-return-stack-and-locals"></span> <span id="index-locals-and-return-stack"></span>

A Forth system is allowed to keep local variables on the return stack. This is reasonable, as local variables usually eliminate the need to use the return stack explicitly. So, if you want to produce a standard compliant program and you are using local variables in a word, forget about return stack manipulations in that word (refer to the standard document for the exact rules).

<span id="index-_003er--w-_002d_002d-R_003aw--core"></span> <span id="index-_003er"></span> <span id="index-_003er-1"></span>

<div class="format">

``` format
>r       w – R:w        core       “to-r”
```

</div>

<span id="index-r_003e--R_003aw-_002d_002d-w--core"></span> <span id="index-r_003e"></span> <span id="index-r_003e-1"></span>

<div class="format">

``` format
r>       R:w – w        core       “r-from”
```

</div>

<span id="index-r_0040--_002d_002d-w-_003b-R_003a-w-_002d_002d-w--core"></span> <span id="index-r_0040"></span> <span id="index-r_0040-1"></span>

<div class="format">

``` format
r@       – w ; R: w – w         core       “r-fetch”
```

</div>

<span id="index-rdrop--R_003aw-_002d_002d--gforth"></span> <span id="index-rdrop"></span> <span id="index-rdrop-1"></span>

<div class="format">

``` format
rdrop       R:w –        gforth       “rdrop”
```

</div>

<span id="index-2_003er--w1-w2-_002d_002d-R_003aw1-R_003aw2--core_002dext"></span> <span id="index-2_003er"></span> <span id="index-2_003er-1"></span>

<div class="format">

``` format
2>r       w1 w2 – R:w1 R:w2        core-ext       “two-to-r”
```

</div>

<span id="index-2r_003e--R_003aw1-R_003aw2-_002d_002d-w1-w2--core_002dext"></span> <span id="index-2r_003e"></span> <span id="index-2r_003e-1"></span>

<div class="format">

``` format
2r>       R:w1 R:w2 – w1 w2        core-ext       “two-r-from”
```

</div>

<span id="index-2r_0040--R_003aw1-R_003aw2-_002d_002d-R_003aw1-R_003aw2-w1-w2--core_002dext"></span> <span id="index-2r_0040"></span> <span id="index-2r_0040-1"></span>

<div class="format">

``` format
2r@       R:w1 R:w2 – R:w1 R:w2 w1 w2        core-ext       “two-r-fetch”
```

</div>

<span id="index-2rdrop--R_003aw1-R_003aw2-_002d_002d--gforth"></span> <span id="index-2rdrop"></span> <span id="index-2rdrop-1"></span>

<div class="format">

``` format
2rdrop       R:w1 R:w2 –        gforth       “two-r-drop”
```

</div>
