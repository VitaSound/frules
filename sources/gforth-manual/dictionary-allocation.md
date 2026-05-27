> Source: https://gforth.org/manual/Dictionary-allocation.html

<span id="Dictionary-allocation"></span>

<div class="header">

Next: [Heap Allocation](Heap-Allocation.html#Heap-Allocation), Previous: [Memory model](Memory-model.html#Memory-model), Up: [Memory](Memory.html#Memory)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Dictionary-allocation-1"></span>

#### 5.7.2 Dictionary allocation

<span id="index-reserving-data-space"></span> <span id="index-data-space-_002d-reserving-some"></span>

Dictionary allocation is a stack-oriented allocation scheme, i.e., if you want to deallocate X, you also deallocate everything allocated after X.

<span id="index-contiguous-regions-in-dictionary-allocation"></span>

The allocations using the words below are contiguous and grow the region towards increasing addresses. Other words that allocate dictionary memory of any kind (i.e., defining words including `:noname`) end the contiguous region and start a new one.

In Standard Forth only `create`d words are guaranteed to produce an address that is the start of the following contiguous region. In particular, the cell allocated by `variable` is not guaranteed to be contiguous with following `allot`ed memory.

You can deallocate memory by using `allot` with a negative argument (with some restrictions, see `allot`). For larger deallocations use `marker`.

<span id="index-here--_002d_002d-addr--core"></span> <span id="index-here"></span> <span id="index-here-1"></span>

<div class="format">

``` format
here       – addr         core       “here”
```

</div>

Return the address of the next free location in data space.

<span id="index-unused--_002d_002d-u--core_002dext"></span> <span id="index-unused"></span> <span id="index-unused-1"></span>

<div class="format">

``` format
unused       – u         core-ext       “unused”
```

</div>

Return the amount of free space remaining (in address units) in the region addressed by `here`.

<span id="index-allot--n-_002d_002d--core"></span> <span id="index-allot"></span> <span id="index-allot-1"></span>

<div class="format">

``` format
allot       n –         core       “allot”
```

</div>

Reserve *n* address units of data space without initialization. *n* is a signed number, passing a negative *n* releases memory. In ANS Forth you can only deallocate memory from the current contiguous region in this way. In Gforth you can deallocate anything in this way but named words. The system does not check this restriction.

<span id="index-c_002c--c-_002d_002d--core"></span> <span id="index-c_002c"></span> <span id="index-c_002c-1"></span>

<div class="format">

``` format
c,       c –         core       “c-comma”
```

</div>

Reserve data space for one char and store *c* in the space.

<span id="index-f_002c--f-_002d_002d--gforth"></span> <span id="index-f_002c"></span> <span id="index-f_002c-1"></span>

<div class="format">

``` format
f,       f –         gforth       “f,”
```

</div>

Reserve data space for one floating-point number and store *f* in the space.

<span id="index-_002c--w-_002d_002d--core"></span> <span id="index-_002c"></span> <span id="index-_002c-1"></span>

<div class="format">

``` format
,       w –         core       “comma”
```

</div>

Reserve data space for one cell and store *w* in the space.

<span id="index-2_002c--w1-w2-_002d_002d--gforth"></span> <span id="index-2_002c"></span> <span id="index-2_002c-1"></span>

<div class="format">

``` format
2,       w1 w2 –         gforth       “2,”
```

</div>

Reserve data space for two cells and store the double *w1 w2* there, *w2* first (lower address).

Memory accesses have to be aligned (see [Address arithmetic](Address-arithmetic.html#Address-arithmetic)). So of course you should allocate memory in an aligned way, too. I.e., before allocating allocating a cell, `here` must be cell-aligned, etc. The words below align `here` if it is not already. Basically it is only already aligned for a type, if the last allocation was a multiple of the size of this type and if `here` was aligned for this type before.

After freshly `create`ing a word, `here` is `align`ed in Standard Forth (`maxalign`ed in Gforth).

<span id="index-align--_002d_002d--core"></span> <span id="index-align"></span> <span id="index-align-1"></span>

<div class="format">

``` format
align       –         core       “align”
```

</div>

If the data-space pointer is not aligned, reserve enough space to align it.

<span id="index-falign--_002d_002d--float"></span> <span id="index-falign"></span> <span id="index-falign-1"></span>

<div class="format">

``` format
falign       –         float       “f-align”
```

</div>

If the data-space pointer is not float-aligned, reserve enough space to align it.

<span id="index-sfalign--_002d_002d--float_002dext"></span> <span id="index-sfalign"></span> <span id="index-sfalign-1"></span>

<div class="format">

``` format
sfalign       –         float-ext       “s-f-align”
```

</div>

If the data-space pointer is not single-float-aligned, reserve enough space to align it.

<span id="index-dfalign--_002d_002d--float_002dext"></span> <span id="index-dfalign"></span> <span id="index-dfalign-1"></span>

<div class="format">

``` format
dfalign       –         float-ext       “d-f-align”
```

</div>

If the data-space pointer is not double-float-aligned, reserve enough space to align it.

<span id="index-maxalign--_002d_002d--gforth"></span> <span id="index-maxalign"></span> <span id="index-maxalign-1"></span>

<div class="format">

``` format
maxalign       –         gforth       “maxalign”
```

</div>

Align data-space pointer for all alignment requirements.

<span id="index-cfalign--_002d_002d--gforth"></span> <span id="index-cfalign"></span> <span id="index-cfalign-1"></span>

<div class="format">

``` format
cfalign       –         gforth       “cfalign”
```

</div>

Align data-space pointer for code field requirements (i.e., such that the corresponding body is maxaligned).

-----

<div class="header">

Next: [Heap Allocation](Heap-Allocation.html#Heap-Allocation), Previous: [Memory model](Memory-model.html#Memory-model), Up: [Memory](Memory.html#Memory)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
