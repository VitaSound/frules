> Source: https://gforth.org/manual/Data-stack.html

<span id="Data-stack"></span>

<div class="header">

Next: [Floating point stack](Floating-point-stack.html#Floating-point-stack), Previous: [Stack Manipulation](Stack-Manipulation.html#Stack-Manipulation), Up: [Stack Manipulation](Stack-Manipulation.html#Stack-Manipulation)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Data-stack-1"></span>

#### 5.6.1 Data stack

<span id="index-data-stack-manipulation-words"></span> <span id="index-stack-manipulations-words_002c-data-stack"></span> <span id="index-drop--w-_002d_002d--core"></span> <span id="index-drop"></span> <span id="index-drop-1"></span>

<div class="format">

``` format
drop       w –        core       “drop”
```

</div>

<span id="index-nip--w1-w2-_002d_002d-w2--core_002dext"></span> <span id="index-nip"></span> <span id="index-nip-1"></span>

<div class="format">

``` format
nip       w1 w2 – w2        core-ext       “nip”
```

</div>

<span id="index-dup--w-_002d_002d-w-w--core"></span> <span id="index-dup"></span> <span id="index-dup-1"></span>

<div class="format">

``` format
dup       w – w w        core       “dupe”
```

</div>

<span id="index-over--w1-w2-_002d_002d-w1-w2-w1--core"></span> <span id="index-over"></span> <span id="index-over-1"></span>

<div class="format">

``` format
over       w1 w2 – w1 w2 w1        core       “over”
```

</div>

<span id="index-tuck--w1-w2-_002d_002d-w2-w1-w2--core_002dext"></span> <span id="index-tuck"></span> <span id="index-tuck-1"></span>

<div class="format">

``` format
tuck       w1 w2 – w2 w1 w2        core-ext       “tuck”
```

</div>

<span id="index-swap--w1-w2-_002d_002d-w2-w1--core"></span> <span id="index-swap"></span> <span id="index-swap-1"></span>

<div class="format">

``` format
swap       w1 w2 – w2 w1        core       “swap”
```

</div>

<span id="index-pick--S_003a_002e_002e_002e-u-_002d_002d-S_003a_002e_002e_002e-w--core_002dext"></span> <span id="index-pick"></span> <span id="index-pick-1"></span>

<div class="format">

``` format
pick       S:... u – S:... w        core-ext       “pick”
```

</div>

Actually the stack effect is `  x0 ... xu u -- x0 ... xu x0  `.

<span id="index-rot--w1-w2-w3-_002d_002d-w2-w3-w1--core"></span> <span id="index-rot"></span> <span id="index-rot-1"></span>

<div class="format">

``` format
rot       w1 w2 w3 – w2 w3 w1        core       “rote”
```

</div>

<span id="index-_002drot--w1-w2-w3-_002d_002d-w3-w1-w2--gforth"></span> <span id="index-_002drot"></span> <span id="index-_002drot-1"></span>

<div class="format">

``` format
-rot       w1 w2 w3 – w3 w1 w2        gforth       “not-rote”
```

</div>

<span id="index-_003fdup--w-_002d_002d-S_003a_002e_002e_002e-w--core"></span> <span id="index-_003fdup"></span> <span id="index-_003fdup-1"></span>

<div class="format">

``` format
?dup       w – S:... w        core       “question-dupe”
```

</div>

Actually the stack effect is: `( w -- 0 | w w )`. It performs a `dup` if w is nonzero.

<span id="index-roll--x0-x1-_002e_002e-xn-n-_002d_002d-x1-_002e_002e-xn-x0--core_002dext"></span> <span id="index-roll"></span> <span id="index-roll-1"></span>

<div class="format">

``` format
roll       x0 x1 .. xn n – x1 .. xn x0         core-ext       “roll”
```

</div>

<span id="index-2drop--w1-w2-_002d_002d--core"></span> <span id="index-2drop"></span> <span id="index-2drop-1"></span>

<div class="format">

``` format
2drop       w1 w2 –        core       “two-drop”
```

</div>

<span id="index-2nip--w1-w2-w3-w4-_002d_002d-w3-w4--gforth"></span> <span id="index-2nip"></span> <span id="index-2nip-1"></span>

<div class="format">

``` format
2nip       w1 w2 w3 w4 – w3 w4        gforth       “two-nip”
```

</div>

<span id="index-2dup--w1-w2-_002d_002d-w1-w2-w1-w2--core"></span> <span id="index-2dup"></span> <span id="index-2dup-1"></span>

<div class="format">

``` format
2dup       w1 w2 – w1 w2 w1 w2        core       “two-dupe”
```

</div>

<span id="index-2over--w1-w2-w3-w4-_002d_002d-w1-w2-w3-w4-w1-w2--core"></span> <span id="index-2over"></span> <span id="index-2over-1"></span>

<div class="format">

``` format
2over       w1 w2 w3 w4 – w1 w2 w3 w4 w1 w2        core       “two-over”
```

</div>

<span id="index-2tuck--w1-w2-w3-w4-_002d_002d-w3-w4-w1-w2-w3-w4--gforth"></span> <span id="index-2tuck"></span> <span id="index-2tuck-1"></span>

<div class="format">

``` format
2tuck       w1 w2 w3 w4 – w3 w4 w1 w2 w3 w4        gforth       “two-tuck”
```

</div>

<span id="index-2swap--w1-w2-w3-w4-_002d_002d-w3-w4-w1-w2--core"></span> <span id="index-2swap"></span> <span id="index-2swap-1"></span>

<div class="format">

``` format
2swap       w1 w2 w3 w4 – w3 w4 w1 w2        core       “two-swap”
```

</div>

<span id="index-2rot--w1-w2-w3-w4-w5-w6-_002d_002d-w3-w4-w5-w6-w1-w2--double_002dext"></span> <span id="index-2rot"></span> <span id="index-2rot-1"></span>

<div class="format">

``` format
2rot       w1 w2 w3 w4 w5 w6 – w3 w4 w5 w6 w1 w2        double-ext       “two-rote”
```

</div>

-----

<div class="header">

Next: [Floating point stack](Floating-point-stack.html#Floating-point-stack), Previous: [Stack Manipulation](Stack-Manipulation.html#Stack-Manipulation), Up: [Stack Manipulation](Stack-Manipulation.html#Stack-Manipulation)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
