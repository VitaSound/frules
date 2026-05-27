> Source: https://gforth.org/manual/Heap-Allocation.html

<span id="Heap-Allocation"></span>

<div class="header">

Next: [Memory Access](Memory-Access.html#Memory-Access), Previous: [Dictionary allocation](Dictionary-allocation.html#Dictionary-allocation), Up: [Memory](Memory.html#Memory)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Heap-allocation"></span>

#### 5.7.3 Heap allocation

<span id="index-heap-allocation"></span> <span id="index-dynamic-allocation-of-memory"></span> <span id="index-memory_002dallocation-word-set"></span> <span id="index-contiguous-regions-and-heap-allocation"></span>

Heap allocation supports deallocation of allocated memory in any order. Dictionary allocation is not affected by it (i.e., it does not end a contiguous region). In Gforth, these words are implemented using the standard C library calls malloc(), free() and realloc().

The memory region produced by one invocation of `allocate` or `resize` is internally contiguous. There is no contiguity between such a region and any other region (including others allocated from the heap).

<span id="index-allocate--u-_002d_002d-a_002daddr-wior--memory"></span> <span id="index-allocate"></span> <span id="index-allocate-1"></span>

<div class="format">

``` format
allocate       u – a-addr wior        memory       “allocate”
```

</div>

Allocate *u* address units of contiguous data space. The initial contents of the data space is undefined. If the allocation is successful, *a-addr* is the start address of the allocated region and *wior* is 0. If the allocation fails, *a-addr* is undefined and *wior* is a non-zero I/O result code.

<span id="index-free--a_002daddr-_002d_002d-wior--memory"></span> <span id="index-free"></span> <span id="index-free-1"></span>

<div class="format">

``` format
free       a-addr – wior        memory       “free”
```

</div>

Return the region of data space starting at *a-addr* to the system. The region must originally have been obtained using `allocate` or `resize`. If the operational is successful, *wior* is 0. If the operation fails, *wior* is a non-zero I/O result code.

<span id="index-resize--a_002daddr1-u-_002d_002d-a_002daddr2-wior--memory"></span> <span id="index-resize"></span> <span id="index-resize-1"></span>

<div class="format">

``` format
resize       a-addr1 u – a-addr2 wior        memory       “resize”
```

</div>

Change the size of the allocated area at *a-addr1* to *u* address units, possibly moving the contents to a different area. *a-addr2* is the address of the resulting area. If the operation is successful, *wior* is 0. If the operation fails, *wior* is a non-zero I/O result code. If *a-addr1* is 0, Gforth’s (but not the Standard) `resize` `allocate`s *u* address units.

-----

<div class="header">

Next: [Memory Access](Memory-Access.html#Memory-Access), Previous: [Dictionary allocation](Dictionary-allocation.html#Dictionary-allocation), Up: [Memory](Memory.html#Memory)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
