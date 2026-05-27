> Source: https://gforth.org/manual/Structure-Implementation.html

<span id="Structure-Implementation"></span>

<div class="header">

Next: [Structure Glossary](Structure-Glossary.html#Structure-Glossary), Previous: [Structure Naming Convention](Structure-Naming-Convention.html#Structure-Naming-Convention), Up: [Structures](Structures.html#Structures)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Structure-Implementation-1"></span>

#### 5.22.4 Structure Implementation

<span id="index-structure-implementation"></span> <span id="index-implementation-of-structures"></span>

The central idea in the implementation is to pass the data about the structure being built on the stack, not in some global variable. Everything else falls into place naturally once this design decision is made.

The type description on the stack is of the form *align size*. Keeping the size on the top-of-stack makes dealing with arrays very simple.

`field` is a defining word that uses `Create` and `DOES>`. The body of the field contains the offset of the field, and the normal `DOES>` action is simply:

<div class="example">

``` example
@ +
```

</div>

i.e., add the offset to the address, giving the stack effect *addr1 – addr2* for a field.

<span id="index-first-field-optimization_002c-implementation"></span>

This simple structure is slightly complicated by the optimization for fields with offset 0, which requires a different `DOES>`-part (because we cannot rely on there being something on the stack if such a field is invoked during compilation). Therefore, we put the different `DOES>`-parts in separate words, and decide which one to invoke based on the offset. For a zero offset, the field is basically a noop; it is immediate, and therefore no code is generated when it is compiled.
