> Source: https://gforth.org/manual/Stack-pointer-manipulation.html

<span id="Stack-pointer-manipulation"></span>

<div class="header">

Previous: [Locals stack](Locals-stack.html#Locals-stack), Up: [Stack Manipulation](Stack-Manipulation.html#Stack-Manipulation)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Stack-pointer-manipulation-1"></span>

#### 5.6.5 Stack pointer manipulation

<span id="index-stack-pointer-manipulation-words"></span> <span id="index-sp0--_002d_002d-a_002daddr--gforth"></span> <span id="index-sp0"></span> <span id="index-sp0-1"></span>

<div class="format">

``` format
sp0       – a-addr         gforth       “sp0”
```

</div>

`User` variable – initial value of the data stack pointer.

<span id="index-sp_0040--S_003a_002e_002e_002e-_002d_002d-a_002daddr--gforth"></span> <span id="index-sp_0040"></span> <span id="index-sp_0040-1"></span>

<div class="format">

``` format
sp@       S:... – a-addr        gforth       “sp-fetch”
```

</div>

<span id="index-sp_0021--a_002daddr-_002d_002d-S_003a_002e_002e_002e--gforth"></span> <span id="index-sp_0021"></span> <span id="index-sp_0021-1"></span>

<div class="format">

``` format
sp!       a-addr – S:...        gforth       “sp-store”
```

</div>

<span id="index-fp0--_002d_002d-a_002daddr--gforth"></span> <span id="index-fp0"></span> <span id="index-fp0-1"></span>

<div class="format">

``` format
fp0       – a-addr         gforth       “fp0”
```

</div>

`User` variable – initial value of the floating-point stack pointer.

<span id="index-fp_0040--f_003a_002e_002e_002e-_002d_002d-f_002daddr--gforth"></span> <span id="index-fp_0040"></span> <span id="index-fp_0040-1"></span>

<div class="format">

``` format
fp@       f:... – f-addr        gforth       “fp-fetch”
```

</div>

<span id="index-fp_0021--f_002daddr-_002d_002d-f_003a_002e_002e_002e--gforth"></span> <span id="index-fp_0021"></span> <span id="index-fp_0021-1"></span>

<div class="format">

``` format
fp!       f-addr – f:...        gforth       “fp-store”
```

</div>

<span id="index-rp0--_002d_002d-a_002daddr--gforth"></span> <span id="index-rp0"></span> <span id="index-rp0-1"></span>

<div class="format">

``` format
rp0       – a-addr         gforth       “rp0”
```

</div>

`User` variable – initial value of the return stack pointer.

<span id="index-rp_0040--_002d_002d-a_002daddr--gforth"></span> <span id="index-rp_0040"></span> <span id="index-rp_0040-1"></span>

<div class="format">

``` format
rp@       – a-addr        gforth       “rp-fetch”
```

</div>

<span id="index-rp_0021--a_002daddr-_002d_002d--gforth"></span> <span id="index-rp_0021"></span> <span id="index-rp_0021-1"></span>

<div class="format">

``` format
rp!       a-addr –        gforth       “rp-store”
```

</div>

<span id="index-lp0--_002d_002d-a_002daddr--gforth"></span> <span id="index-lp0"></span> <span id="index-lp0-1"></span>

<div class="format">

``` format
lp0       – a-addr         gforth       “lp0”
```

</div>

`User` variable – initial value of the locals stack pointer.

<span id="index-lp_0040--_002d_002d-addr--gforth"></span> <span id="index-lp_0040"></span> <span id="index-lp_0040-1"></span>

<div class="format">

``` format
lp@       – addr         gforth       “lp-fetch”
```

</div>

<span id="index-lp_0021--c_002daddr-_002d_002d--gforth"></span> <span id="index-lp_0021"></span> <span id="index-lp_0021-2"></span>

<div class="format">

``` format
lp!       c-addr –        gforth       “lp-store”
```

</div>
