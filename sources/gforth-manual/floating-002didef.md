> Source: https://gforth.org/manual/floating_002didef.html

<span id="floating_002didef"></span>

<div class="header">

Next: [floating-ambcond](floating_002dambcond.html#floating_002dambcond), Previous: [The optional Floating-Point word set](The-optional-Floating_002dPoint-word-set.html#The-optional-Floating_002dPoint-word-set), Up: [The optional Floating-Point word set](The-optional-Floating_002dPoint-word-set.html#The-optional-Floating_002dPoint-word-set)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Implementation-Defined-Options-5"></span>

#### 8.7.1 Implementation Defined Options

<span id="index-implementation_002ddefined-options_002c-floating_002dpoint-words"></span> <span id="index-floating_002dpoint-words_002c-implementation_002ddefined-options"></span>

  - *format and range of floating point numbers:*  
    <span id="index-format-and-range-of-floating-point-numbers"></span> <span id="index-floating-point-numbers_002c-format-and-range"></span>
    
    System-dependent; the `double` type of C.

  - *results of `REPRESENT` when *float* is out of range:*  
    <span id="index-REPRESENT_002c-results-when-float-is-out-of-range"></span>
    
    System dependent; `REPRESENT` is implemented using the C library function `ecvt()` and inherits its behaviour in this respect.

  - *rounding or truncation of floating-point numbers:*  
    <span id="index-rounding-of-floating_002dpoint-numbers"></span> <span id="index-truncation-of-floating_002dpoint-numbers"></span> <span id="index-floating_002dpoint-numbers_002c-rounding-or-truncation"></span>
    
    System dependent; the rounding behaviour is inherited from the hosting C compiler. IEEE-FP-based (i.e., most) systems by default round to nearest, and break ties by rounding to even (i.e., such that the last bit of the mantissa is 0).

  - *size of floating-point stack:*  
    <span id="index-floating_002dpoint-stack-size"></span>
    
    `s" FLOATING-STACK" environment? drop .` gives the total size of the floating-point stack (in floats). You can specify this on startup with the command-line option `-f` (see [Invoking Gforth](Invoking-Gforth.html#Invoking-Gforth)).

  - *width of floating-point stack:*  
    <span id="index-floating_002dpoint-stack-width"></span>
    
    `1 floats`.
