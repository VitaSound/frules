> Source: https://gforth.org/manual/Memory-Tutorial.html

<span id="Memory-Tutorial"></span>

<div class="header">

Next: [Characters and Strings Tutorial](Characters-and-Strings-Tutorial.html#Characters-and-Strings-Tutorial), Previous: [Return Stack Tutorial](Return-Stack-Tutorial.html#Return-Stack-Tutorial), Up: [Tutorial](Tutorial.html#Tutorial)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Memory-1"></span>

### 3.23 Memory

<span id="index-memory-access_002fallocation-tutorial"></span>

You can create a global variable `v` with

<div class="example">

``` example
variable v ( -- addr )
```

</div>

`v` pushes the address of a cell in memory on the stack. This cell was reserved by `variable`. You can use `!` (store) to store values into this cell and `@` (fetch) to load the value from the stack into memory:

<div class="example">

``` example
v .
5 v ! .s
v @ .
```

</div>

You can see a raw dump of memory with `dump`:

<div class="example">

``` example
v 1 cells .s dump
```

</div>

`Cells ( n1 -- n2 )` gives you the number of bytes (or, more generally, address units (aus)) that `n1 cells` occupy. You can also reserve more memory:

<div class="example">

``` example
create v2 20 cells allot
v2 20 cells dump
```

</div>

creates a variable-like word `v2` and reserves 20 uninitialized cells; the address pushed by `v2` points to the start of these 20 cells (see [CREATE](CREATE.html#CREATE)). You can use address arithmetic to access these cells:

<div class="example">

``` example
3 v2 5 cells + !
v2 20 cells dump
```

</div>

You can reserve and initialize memory with `,`:

<div class="example">

``` example
create v3
  5 , 4 , 3 , 2 , 1 ,
v3 @ .
v3 cell+ @ .
v3 2 cells + @ .
v3 5 cells dump
```

</div>

> **Assignment:** Write a definition `vsum ( addr u -- n )` that computes the sum of `u` cells, with the first of these cells at `addr`, the next one at `addr cell+` etc.

The difference between `variable` and `create` is that `variable` allots a cell, and that you cannot allot additional memory to a variable in standard Forth.

You can also reserve memory without creating a new word:

<div class="example">

``` example
here 10 cells allot .
here .
```

</div>

The first `here` pushes the start address of the memory area, the second `here` the address after the dictionary area. You should store the start address somewhere, or you will have a hard time finding the memory area again.

`Allot` manages dictionary memory. The dictionary memory contains the system’s data structures for words etc. on Gforth and most other Forth systems. It is managed like a stack: You can free the memory that you have just `allot`ed with

<div class="example">

``` example
-10 cells allot
here .
```

</div>

Note that you cannot do this if you have created a new word in the meantime (because then your `allot`ed memory is no longer on the top of the dictionary “stack”).

Alternatively, you can use `allocate` and `free` which allow freeing memory in any order:

<div class="example">

``` example
10 cells allocate throw .s
20 cells allocate throw .s
swap
free throw
free throw
```

</div>

The `throw`s deal with errors (e.g., out of memory).

And there is also a [garbage collector](http://www.complang.tuwien.ac.at/forth/garbage-collection.zip), which eliminates the need to `free` memory explicitly.

Reference: [Memory](Memory.html#Memory).

-----

<div class="header">

Next: [Characters and Strings Tutorial](Characters-and-Strings-Tutorial.html#Characters-and-Strings-Tutorial), Previous: [Return Stack Tutorial](Return-Stack-Tutorial.html#Return-Stack-Tutorial), Up: [Tutorial](Tutorial.html#Tutorial)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
