> Source: https://gforth.org/manual/Memory-model.html

<span id="Memory-model"></span>

<div class="header">

Next: [Dictionary allocation](Dictionary-allocation.html#Dictionary-allocation), Previous: [Memory](Memory.html#Memory), Up: [Memory](Memory.html#Memory)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Memory-model-1"></span>

#### 5.7.1 Memory model

Standard Forth considers a Forth system as consisting of several address spaces, of which only *data space* is managed and accessible with the memory words. Memory not necessarily in data space includes the stacks, the code (called code space) and the headers (called name space). In Gforth everything is in data space, but the code for the primitives is usually read-only.

Data space is divided into a number of areas: The (data space portion of the) dictionary[<sup>10</sup>](#FOOT10), the heap, and a number of system-allocated buffers.

Gforth provides one big address space, and address arithmetic can be performed between any addresses. However, in the dictionary headers or code are interleaved with data, so almost the only contiguous data space regions there are those described by Standard Forth as contiguous; but you can be sure that the dictionary is allocated towards increasing addresses even between contiguous regions. The memory order of allocations in the heap is platform-dependent (and possibly different from one run to the next).

<div class="footnote">

-----

#### Footnotes

### [(10)](#DOCF10)

Sometimes, the term *dictionary* is used to refer to the search data structure embodied in word lists and headers, because it is used for looking up names, just as you would in a conventional dictionary.

</div>
