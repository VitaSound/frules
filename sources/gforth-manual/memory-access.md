> Source: https://gforth.org/manual/Memory-Access.html

<span id="Memory-Access"></span>

<div class="header">

Next: [Address arithmetic](Address-arithmetic.html#Address-arithmetic), Previous: [Heap Allocation](Heap-Allocation.html#Heap-Allocation), Up: [Memory](Memory.html#Memory)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Memory-Access-1"></span>

#### 5.7.4 Memory Access

<span id="index-memory-access-words"></span> <span id="index-_0040--a_002daddr-_002d_002d-w--core"></span> <span id="index-_0040"></span> <span id="index-_0040-1"></span>

<div class="format">

``` format
@       a-addr – w        core       “fetch”
```

</div>

*w* is the cell stored at *a\_addr*.

<span id="index-_0021--w-a_002daddr-_002d_002d--core"></span> <span id="index-_0021"></span> <span id="index-_0021-1"></span>

<div class="format">

``` format
!       w a-addr –        core       “store”
```

</div>

Store *w* into the cell at *a-addr*.

<span id="index-_002b_0021--n-a_002daddr-_002d_002d--core"></span> <span id="index-_002b_0021"></span> <span id="index-_002b_0021-1"></span>

<div class="format">

``` format
+!       n a-addr –        core       “plus-store”
```

</div>

Add *n* to the cell at *a-addr*.

<span id="index-c_0040--c_002daddr-_002d_002d-c--core"></span> <span id="index-c_0040"></span> <span id="index-c_0040-1"></span>

<div class="format">

``` format
c@       c-addr – c        core       “c-fetch”
```

</div>

*c* is the char stored at *c\_addr*.

<span id="index-c_0021--c-c_002daddr-_002d_002d--core"></span> <span id="index-c_0021"></span> <span id="index-c_0021-1"></span>

<div class="format">

``` format
c!       c c-addr –        core       “c-store”
```

</div>

Store *c* into the char at *c-addr*.

<span id="index-2_0040--a_002daddr-_002d_002d-w1-w2--core"></span> <span id="index-2_0040"></span> <span id="index-2_0040-1"></span>

<div class="format">

``` format
2@       a-addr – w1 w2        core       “two-fetch”
```

</div>

*w2* is the content of the cell stored at *a-addr*, *w1* is the content of the next cell.

<span id="index-2_0021--w1-w2-a_002daddr-_002d_002d--core"></span> <span id="index-2_0021"></span> <span id="index-2_0021-1"></span>

<div class="format">

``` format
2!       w1 w2 a-addr –        core       “two-store”
```

</div>

Store *w2* into the cell at *c-addr* and *w1* into the next cell.

<span id="index-f_0040--f_002daddr-_002d_002d-r--float"></span> <span id="index-f_0040"></span> <span id="index-f_0040-1"></span>

<div class="format">

``` format
f@       f-addr – r        float       “f-fetch”
```

</div>

*r* is the float at address *f-addr*.

<span id="index-f_0021--r-f_002daddr-_002d_002d--float"></span> <span id="index-f_0021"></span> <span id="index-f_0021-1"></span>

<div class="format">

``` format
f!       r f-addr –        float       “f-store”
```

</div>

Store *r* into the float at address *f-addr*.

<span id="index-sf_0040--sf_002daddr-_002d_002d-r--float_002dext"></span> <span id="index-sf_0040"></span> <span id="index-sf_0040-1"></span>

<div class="format">

``` format
sf@       sf-addr – r        float-ext       “s-f-fetch”
```

</div>

Fetch the single-precision IEEE floating-point value *r* from the address *sf-addr*.

<span id="index-sf_0021--r-sf_002daddr-_002d_002d--float_002dext"></span> <span id="index-sf_0021"></span> <span id="index-sf_0021-1"></span>

<div class="format">

``` format
sf!       r sf-addr –        float-ext       “s-f-store”
```

</div>

Store *r* as single-precision IEEE floating-point value to the address *sf-addr*.

<span id="index-df_0040--df_002daddr-_002d_002d-r--float_002dext"></span> <span id="index-df_0040"></span> <span id="index-df_0040-1"></span>

<div class="format">

``` format
df@       df-addr – r        float-ext       “d-f-fetch”
```

</div>

Fetch the double-precision IEEE floating-point value *r* from the address *df-addr*.

<span id="index-df_0021--r-df_002daddr-_002d_002d--float_002dext"></span> <span id="index-df_0021"></span> <span id="index-df_0021-1"></span>

<div class="format">

``` format
df!       r df-addr –        float-ext       “d-f-store”
```

</div>

Store *r* as double-precision IEEE floating-point value to the address *df-addr*.

<span id="index-sw_0040--c_002daddr-_002d_002d-n--gforth"></span> <span id="index-sw_0040"></span> <span id="index-sw_0040-1"></span>

<div class="format">

``` format
sw@       c-addr – n        gforth       “s-w-fetch”
```

</div>

*n* is the sign-extended 16-bit value stored at *c\_addr*.

<span id="index-uw_0040--c_002daddr-_002d_002d-u--gforth"></span> <span id="index-uw_0040"></span> <span id="index-uw_0040-1"></span>

<div class="format">

``` format
uw@       c-addr – u        gforth       “u-w-fetch”
```

</div>

*u* is the zero-extended 16-bit value stored at *c\_addr*.

<span id="index-w_0021--w-c_002daddr-_002d_002d--gforth"></span> <span id="index-w_0021"></span> <span id="index-w_0021-1"></span>

<div class="format">

``` format
w!       w c-addr –        gforth       “w-store”
```

</div>

Store the bottom 16 bits of *w* at *c\_addr*.

<span id="index-sl_0040--c_002daddr-_002d_002d-n--gforth"></span> <span id="index-sl_0040"></span> <span id="index-sl_0040-1"></span>

<div class="format">

``` format
sl@       c-addr – n        gforth       “s-l-fetch”
```

</div>

*n* is the sign-extended 32-bit value stored at *c\_addr*.

<span id="index-ul_0040--c_002daddr-_002d_002d-u--gforth"></span> <span id="index-ul_0040"></span> <span id="index-ul_0040-1"></span>

<div class="format">

``` format
ul@       c-addr – u        gforth       “u-l-fetch”
```

</div>

*u* is the zero-extended 32-bit value stored at *c\_addr*.

<span id="index-l_0021--w-c_002daddr-_002d_002d--gforth"></span> <span id="index-l_0021"></span> <span id="index-l_0021-1"></span>

<div class="format">

``` format
l!       w c-addr –        gforth       “l-store”
```

</div>

Store the bottom 32 bits of *w* at *c\_addr*.

-----

<div class="header">

Next: [Address arithmetic](Address-arithmetic.html#Address-arithmetic), Previous: [Heap Allocation](Heap-Allocation.html#Heap-Allocation), Up: [Memory](Memory.html#Memory)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
