> Source: https://gforth.org/manual/Boolean-Flags.html

<span id="Boolean-Flags"></span>

<div class="header">

Next: [Arithmetic](Arithmetic.html#Arithmetic), Previous: [Comments](Comments.html#Comments), Up: [Words](Words.html#Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Boolean-Flags-1"></span>

### 5.4 Boolean Flags

<span id="index-Boolean-flags"></span>

A Boolean flag is cell-sized. A cell with all bits clear represents the flag `false` and a flag with all bits set represents the flag `true`. Words that check a flag (for example, `IF`) will treat a cell that has *any* bit set as `true`.

<span id="index-true--_002d_002d-f--core_002dext"></span> <span id="index-true"></span> <span id="index-true-1"></span>

<div class="format">

``` format
true       – f         core-ext       “true”
```

</div>

`Constant` – *f* is a cell with all bits set.

<span id="index-false--_002d_002d-f--core_002dext"></span> <span id="index-false"></span> <span id="index-false-1"></span>

<div class="format">

``` format
false       – f         core-ext       “false”
```

</div>

`Constant` – *f* is a cell with all bits clear.

<span id="index-on--a_002daddr-_002d_002d--gforth"></span> <span id="index-on"></span> <span id="index-on-1"></span>

<div class="format">

``` format
on       a-addr –         gforth       “on”
```

</div>

Set the (value of the) variable at *a-addr* to `true`.

<span id="index-off--a_002daddr-_002d_002d--gforth"></span> <span id="index-off"></span> <span id="index-off-1"></span>

<div class="format">

``` format
off       a-addr –         gforth       “off”
```

</div>

Set the (value of the) variable at *a-addr* to `false`.
