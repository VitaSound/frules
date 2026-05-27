> Source: https://gforth.org/manual/Why-explicit-structure-support_003f.html

<span id="Why-explicit-structure-support_003f"></span>

<div class="header">

Next: [Structure Usage](Structure-Usage.html#Structure-Usage), Previous: [Structures](Structures.html#Structures), Up: [Structures](Structures.html#Structures)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Why-explicit-structure-support_003f-1"></span>

#### 5.22.1 Why explicit structure support?

<span id="index-address-arithmetic-for-structures"></span> <span id="index-structures-using-address-arithmetic"></span>

If we want to use a structure containing several fields, we could simply reserve memory for it, and access the fields using address arithmetic (see [Address arithmetic](Address-arithmetic.html#Address-arithmetic)). As an example, consider a structure with the following fields

  - `a`  
    is a float

  - `b`  
    is a cell

  - `c`  
    is a float

Given the (float-aligned) base address of the structure we get the address of the field

  - `a`  
    without doing anything further.

  - `b`  
    with `float+`

  - `c`  
    with `float+ cell+ faligned`

It is easy to see that this can become quite tiring.

Moreover, it is not very readable, because seeing a `cell+` tells us neither which kind of structure is accessed nor what field is accessed; we have to somehow infer the kind of structure, and then look up in the documentation, which field of that structure corresponds to that offset.

Finally, this kind of address arithmetic also causes maintenance troubles: If you add or delete a field somewhere in the middle of the structure, you have to find and change all computations for the fields afterwards.

So, instead of using `cell+` and friends directly, how about storing the offsets in constants:

<div class="example">

``` example
0 constant a-offset
0 float+ constant b-offset
0 float+ cell+ faligned c-offset
```

</div>

Now we can get the address of field `x` with `x-offset +`. This is much better in all respects. Of course, you still have to change all later offset definitions if you add a field. You can fix this by declaring the offsets in the following way:

<div class="example">

``` example
0 constant a-offset
a-offset float+ constant b-offset
b-offset cell+ faligned constant c-offset
```

</div>

Since we always use the offsets with `+`, we could use a defining word `cfield` that includes the `+` in the action of the defined word:

<div class="example">

``` example
: cfield ( n "name" -- )
    create ,
does> ( name execution: addr1 -- addr2 )
    @ + ;

0 cfield a
0 a float+ cfield b
0 b cell+ faligned cfield c
```

</div>

Instead of `x-offset +`, we now simply write `x`.

The structure field words now can be used quite nicely. However, their definition is still a bit cumbersome: We have to repeat the name, the information about size and alignment is distributed before and after the field definitions etc. The structure package presented here addresses these problems.

-----

<div class="header">

Next: [Structure Usage](Structure-Usage.html#Structure-Usage), Previous: [Structures](Structures.html#Structures), Up: [Structures](Structures.html#Structures)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
