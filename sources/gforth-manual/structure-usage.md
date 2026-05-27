> Source: https://gforth.org/manual/Structure-Usage.html

<span id="Structure-Usage"></span>

<div class="header">

Next: [Structure Naming Convention](Structure-Naming-Convention.html#Structure-Naming-Convention), Previous: [Why explicit structure support?](Why-explicit-structure-support_003f.html#Why-explicit-structure-support_003f), Up: [Structures](Structures.html#Structures)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Structure-Usage-1"></span>

#### 5.22.2 Structure Usage

<span id="index-structure-usage"></span> <span id="index-field-usage"></span> <span id="index-struct-usage"></span> <span id="index-end_002dstruct-usage"></span>

You can define a structure for a (data-less) linked list with:

<div class="example">

``` example
struct
    cell% field list-next
end-struct list%
```

</div>

With the address of the list node on the stack, you can compute the address of the field that contains the address of the next node with `list-next`. E.g., you can determine the length of a list with:

<div class="example">

``` example
: list-length ( list -- n )
\ "list" is a pointer to the first element of a linked list
\ "n" is the length of the list
    0 BEGIN ( list1 n1 )
        over
    WHILE ( list1 n1 )
        1+ swap list-next @ swap
    REPEAT
    nip ;
```

</div>

You can reserve memory for a list node in the dictionary with `list% %allot`, which leaves the address of the list node on the stack. For the equivalent allocation on the heap you can use `list% %alloc` (or, for an `allocate`-like stack effect (i.e., with ior), use `list% %allocate`). You can get the the size of a list node with `list% %size` and its alignment with `list% %alignment`.

Note that in Standard Forth the body of a `create`d word is `aligned` but not necessarily `faligned`; therefore, if you do a:

<div class="example">

``` example
create name foo% %allot drop
```

</div>

then the memory alloted for `foo%` is guaranteed to start at the body of `name` only if `foo%` contains only character, cell and double fields. Therefore, if your structure contains floats, better use

<div class="example">

``` example
foo% %allot constant name
```

</div>

<span id="index-structures-containing-structures"></span>

You can include a structure `foo%` as a field of another structure, like this:

<div class="example">

``` example
struct
...
    foo% field ...
...
end-struct ...
```

</div>

<span id="index-structure-extension"></span> <span id="index-extended-records"></span>

Instead of starting with an empty structure, you can extend an existing structure. E.g., a plain linked list without data, as defined above, is hardly useful; You can extend it to a linked list of integers, like this:[<sup>32</sup>](#FOOT32)

<div class="example">

``` example
list%
    cell% field intlist-int
end-struct intlist%
```

</div>

`intlist%` is a structure with two fields: `list-next` and `intlist-int`.

<span id="index-structures-containing-arrays"></span>

You can specify an array type containing *n* elements of type `foo%` like this:

<div class="example">

``` example
foo% n *
```

</div>

You can use this array type in any place where you can use a normal type, e.g., when defining a `field`, or with `%allot`.

<span id="index-first-field-optimization"></span>

The first field is at the base address of a structure and the word for this field (e.g., `list-next`) actually does not change the address on the stack. You may be tempted to leave it away in the interest of run-time and space efficiency. This is not necessary, because the structure package optimizes this case: If you compile a first-field words, no code is generated. So, in the interest of readability and maintainability you should include the word for the field when accessing the field.

<div class="footnote">

-----

#### Footnotes

### [(32)](#DOCF32)

This feature is also known as *extended records*. It is the main innovation in the Oberon language; in other words, adding this feature to Modula-2 led Wirth to create a new language, write a new compiler etc. Adding this feature to Forth just required a few lines of code.

</div>

-----

<div class="header">

Next: [Structure Naming Convention](Structure-Naming-Convention.html#Structure-Naming-Convention), Previous: [Why explicit structure support?](Why-explicit-structure-support_003f.html#Why-explicit-structure-support_003f), Up: [Structures](Structures.html#Structures)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
