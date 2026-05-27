> Source: https://gforth.org/manual/Address-arithmetic.html

<span id="Address-arithmetic"></span>

<div class="header">

Next: [Memory Blocks](Memory-Blocks.html#Memory-Blocks), Previous: [Memory Access](Memory-Access.html#Memory-Access), Up: [Memory](Memory.html#Memory)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Address-arithmetic-1"></span>

#### 5.7.5 Address arithmetic

<span id="index-address-arithmetic-words"></span>

Address arithmetic is the foundation on which you can build data structures like arrays, records (see [Structures](Structures.html#Structures)) and objects (see [Object-oriented Forth](Object_002doriented-Forth.html#Object_002doriented-Forth)).

<span id="index-address-unit"></span> <span id="index-au-_0028address-unit_0029"></span>

Standard Forth does not specify the sizes of the data types. Instead, it offers a number of words for computing sizes and doing address arithmetic. Address arithmetic is performed in terms of address units (aus); on most systems the address unit is one byte. Note that a character may have more than one au, so `chars` is no noop (on platforms where it is a noop, it compiles to nothing).

The basic address arithmetic words are `+` and `-`. E.g., if you have the address of a cell, perform `1 cells +`, and you will have the address of the next cell.

<span id="index-alignment-of-addresses-for-types"></span>

Standard Forth also defines words for aligning addresses for specific types. Many computers require that accesses to specific data types must only occur at specific addresses; e.g., that cells may only be accessed at addresses divisible by 4. Even if a machine allows unaligned accesses, it can usually perform aligned accesses faster.

For the performance-conscious: alignment operations are usually only necessary during the definition of a data structure, not during the (more frequent) accesses to it.

Standard Forth defines no words for character-aligning addresses; in Forth-2012 all addresses are character-aligned.

<span id="index-CREATE-and-alignment"></span>

Standard Forth guarantees that addresses returned by `CREATE`d words are cell-aligned; in addition, Gforth guarantees that these addresses are aligned for all purposes.

Note that the Standard Forth word `char` has nothing to do with address arithmetic.

<span id="index-chars--n1-_002d_002d-n2--core"></span> <span id="index-chars"></span> <span id="index-chars-1"></span>

<div class="format">

``` format
chars       n1 – n2         core       “chars”
```

</div>

*n2* is the number of address units of *n1* chars.""

<span id="index-char_002b--c_002daddr1-_002d_002d-c_002daddr2--core"></span> <span id="index-char_002b"></span> <span id="index-char_002b-1"></span>

<div class="format">

``` format
char+       c-addr1 – c-addr2        core       “char-plus”
```

</div>

`1 chars +`.

<span id="index-cells--n1-_002d_002d-n2--core"></span> <span id="index-cells"></span> <span id="index-cells-1"></span>

<div class="format">

``` format
cells       n1 – n2        core       “cells”
```

</div>

*n2* is the number of address units of *n1* cells.

<span id="index-cell_002b--a_002daddr1-_002d_002d-a_002daddr2--core"></span> <span id="index-cell_002b"></span> <span id="index-cell_002b-1"></span>

<div class="format">

``` format
cell+       a-addr1 – a-addr2        core       “cell-plus”
```

</div>

`1 cells +`

<span id="index-cell--_002d_002d-u--gforth"></span> <span id="index-cell"></span> <span id="index-cell-1"></span>

<div class="format">

``` format
cell       – u         gforth       “cell”
```

</div>

`Constant` – `1 cells`

<span id="index-aligned--c_002daddr-_002d_002d-a_002daddr--core"></span> <span id="index-aligned"></span> <span id="index-aligned-1"></span>

<div class="format">

``` format
aligned       c-addr – a-addr        core       “aligned”
```

</div>

*a-addr* is the first aligned address greater than or equal to *c-addr*.

<span id="index-floats--n1-_002d_002d-n2--float"></span> <span id="index-floats"></span> <span id="index-floats-1"></span>

<div class="format">

``` format
floats       n1 – n2        float       “floats”
```

</div>

*n2* is the number of address units of *n1* floats.

<span id="index-float_002b--f_002daddr1-_002d_002d-f_002daddr2--float"></span> <span id="index-float_002b"></span> <span id="index-float_002b-1"></span>

<div class="format">

``` format
float+       f-addr1 – f-addr2        float       “float-plus”
```

</div>

`1 floats +`.

<span id="index-float--_002d_002d-u--gforth"></span> <span id="index-float"></span> <span id="index-float-1"></span>

<div class="format">

``` format
float       – u         gforth       “float”
```

</div>

`Constant` – the number of address units corresponding to a floating-point number.

<span id="index-faligned--c_002daddr-_002d_002d-f_002daddr--float"></span> <span id="index-faligned"></span> <span id="index-faligned-1"></span>

<div class="format">

``` format
faligned       c-addr – f-addr        float       “f-aligned”
```

</div>

*f-addr* is the first float-aligned address greater than or equal to *c-addr*.

<span id="index-sfloats--n1-_002d_002d-n2--float_002dext"></span> <span id="index-sfloats"></span> <span id="index-sfloats-1"></span>

<div class="format">

``` format
sfloats       n1 – n2        float-ext       “s-floats”
```

</div>

*n2* is the number of address units of *n1* single-precision IEEE floating-point numbers.

<span id="index-sfloat_002b--sf_002daddr1-_002d_002d-sf_002daddr2--float_002dext"></span> <span id="index-sfloat_002b"></span> <span id="index-sfloat_002b-1"></span>

<div class="format">

``` format
sfloat+       sf-addr1 – sf-addr2         float-ext       “s-float-plus”
```

</div>

`1 sfloats +`.

<span id="index-sfaligned--c_002daddr-_002d_002d-sf_002daddr--float_002dext"></span> <span id="index-sfaligned"></span> <span id="index-sfaligned-1"></span>

<div class="format">

``` format
sfaligned       c-addr – sf-addr        float-ext       “s-f-aligned”
```

</div>

*sf-addr* is the first single-float-aligned address greater than or equal to *c-addr*.

<span id="index-dfloats--n1-_002d_002d-n2--float_002dext"></span> <span id="index-dfloats"></span> <span id="index-dfloats-1"></span>

<div class="format">

``` format
dfloats       n1 – n2        float-ext       “d-floats”
```

</div>

*n2* is the number of address units of *n1* double-precision IEEE floating-point numbers.

<span id="index-dfloat_002b--df_002daddr1-_002d_002d-df_002daddr2--float_002dext"></span> <span id="index-dfloat_002b"></span> <span id="index-dfloat_002b-1"></span>

<div class="format">

``` format
dfloat+       df-addr1 – df-addr2         float-ext       “d-float-plus”
```

</div>

`1 dfloats +`.

<span id="index-dfaligned--c_002daddr-_002d_002d-df_002daddr--float_002dext"></span> <span id="index-dfaligned"></span> <span id="index-dfaligned-1"></span>

<div class="format">

``` format
dfaligned       c-addr – df-addr        float-ext       “d-f-aligned”
```

</div>

*df-addr* is the first double-float-aligned address greater than or equal to *c-addr*.

<span id="index-maxaligned--addr1-_002d_002d-addr2--gforth"></span> <span id="index-maxaligned"></span> <span id="index-maxaligned-1"></span>

<div class="format">

``` format
maxaligned       addr1 – addr2         gforth       “maxaligned”
```

</div>

*addr2* is the first address after *addr1* that satisfies all alignment restrictions. maxaligned"

<span id="index-cfaligned--addr1-_002d_002d-addr2--gforth"></span> <span id="index-cfaligned"></span> <span id="index-cfaligned-1"></span>

<div class="format">

``` format
cfaligned       addr1 – addr2         gforth       “cfaligned”
```

</div>

*addr2* is the first address after *addr1* that is aligned for a code field (i.e., such that the corresponding body is maxaligned).

<span id="index-ADDRESS_002dUNIT_002dBITS--_002d_002d-n--environment"></span> <span id="index-ADDRESS_002dUNIT_002dBITS"></span> <span id="index-ADDRESS_002dUNIT_002dBITS-1"></span>

<div class="format">

``` format
ADDRESS-UNIT-BITS       – n         environment       “ADDRESS-UNIT-BITS”
```

</div>

Size of one address unit, in bits.

<span id="index-_002fw--_002d_002d-u--gforth"></span> <span id="index-_002fw"></span> <span id="index-_002fw-1"></span>

<div class="format">

``` format
/w       – u         gforth       “slash-w”
```

</div>

address units for a 16-bit value

<span id="index-_002fl--_002d_002d-u--gforth"></span> <span id="index-_002fl"></span> <span id="index-_002fl-1"></span>

<div class="format">

``` format
/l       – u         gforth       “slash-l”
```

</div>

address units for a 32-bit value

-----

<div class="header">

Next: [Memory Blocks](Memory-Blocks.html#Memory-Blocks), Previous: [Memory Access](Memory-Access.html#Memory-Access), Up: [Memory](Memory.html#Memory)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
