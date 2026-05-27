> Source: https://gforth.org/manual/Floating-point-stack.html

<span id="Floating-point-stack"></span>

<div class="header">

Next: [Return stack](Return-stack.html#Return-stack), Previous: [Data stack](Data-stack.html#Data-stack), Up: [Stack Manipulation](Stack-Manipulation.html#Stack-Manipulation)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Floating-point-stack-1"></span>

#### 5.6.2 Floating point stack

<span id="index-floating_002dpoint-stack-manipulation-words"></span> <span id="index-stack-manipulation-words_002c-floating_002dpoint-stack"></span> <span id="index-floating_002dstack--_002d_002d-n--environment"></span> <span id="index-floating_002dstack"></span> <span id="index-floating_002dstack-1"></span>

<div class="format">

``` format
floating-stack       – n         environment       “floating-stack”
```

</div>

`n` is non-zero, showing that Gforth maintains a separate floating-point stack of depth `n`.

<span id="index-fdrop--r-_002d_002d--float"></span> <span id="index-fdrop"></span> <span id="index-fdrop-1"></span>

<div class="format">

``` format
fdrop       r –        float       “f-drop”
```

</div>

<span id="index-fnip--r1-r2-_002d_002d-r2--gforth"></span> <span id="index-fnip"></span> <span id="index-fnip-1"></span>

<div class="format">

``` format
fnip       r1 r2 – r2        gforth       “f-nip”
```

</div>

<span id="index-fdup--r-_002d_002d-r-r--float"></span> <span id="index-fdup"></span> <span id="index-fdup-1"></span>

<div class="format">

``` format
fdup       r – r r        float       “f-dupe”
```

</div>

<span id="index-fover--r1-r2-_002d_002d-r1-r2-r1--float"></span> <span id="index-fover"></span> <span id="index-fover-1"></span>

<div class="format">

``` format
fover       r1 r2 – r1 r2 r1        float       “f-over”
```

</div>

<span id="index-ftuck--r1-r2-_002d_002d-r2-r1-r2--gforth"></span> <span id="index-ftuck"></span> <span id="index-ftuck-1"></span>

<div class="format">

``` format
ftuck       r1 r2 – r2 r1 r2        gforth       “f-tuck”
```

</div>

<span id="index-fswap--r1-r2-_002d_002d-r2-r1--float"></span> <span id="index-fswap"></span> <span id="index-fswap-1"></span>

<div class="format">

``` format
fswap       r1 r2 – r2 r1        float       “f-swap”
```

</div>

<span id="index-fpick--f_003a_002e_002e_002e-u-_002d_002d-f_003a_002e_002e_002e-r--gforth"></span> <span id="index-fpick"></span> <span id="index-fpick-1"></span>

<div class="format">

``` format
fpick       f:... u – f:... r        gforth       “fpick”
```

</div>

Actually the stack effect is `  r0 ... ru u -- r0 ... ru r0  `.

<span id="index-frot--r1-r2-r3-_002d_002d-r2-r3-r1--float"></span> <span id="index-frot"></span> <span id="index-frot-1"></span>

<div class="format">

``` format
frot       r1 r2 r3 – r2 r3 r1        float       “f-rote”
```

</div>
