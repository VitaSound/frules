> Source: https://gforth.org/manual/Alignment-Tutorial.html

<span id="Alignment-Tutorial"></span>

<div class="header">

Next: [Floating Point Tutorial](Floating-Point-Tutorial.html#Floating-Point-Tutorial), Previous: [Characters and Strings Tutorial](Characters-and-Strings-Tutorial.html#Characters-and-Strings-Tutorial), Up: [Tutorial](Tutorial.html#Tutorial)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Alignment"></span>

### 3.25 Alignment

<span id="index-alignment-tutorial"></span> <span id="index-memory-alignment-tutorial"></span>

On many processors cells have to be aligned in memory, if you want to access them with `@` and `!` (and even if the processor does not require alignment, access to aligned cells is faster).

`Create` aligns `here` (i.e., the place where the next allocation will occur, and that the `create`d word points to). Likewise, the memory produced by `allocate` starts at an aligned address. Adding a number of `cells` to an aligned address produces another aligned address.

However, address arithmetic involving `char+` and `chars` can create an address that is not cell-aligned. `Aligned ( addr -- a-addr )` produces the next aligned address:

<div class="example">

``` example
v3 char+ aligned .s @ .
v3 char+ .s @ .
```

</div>

Similarly, `align` advances `here` to the next aligned address:

<div class="example">

``` example
create v5 97 c,
here .
align here .
1000 ,
```

</div>

Note that you should use aligned addresses even if your processor does not require them, if you want your program to be portable.

Reference: [Address arithmetic](Address-arithmetic.html#Address-arithmetic).
