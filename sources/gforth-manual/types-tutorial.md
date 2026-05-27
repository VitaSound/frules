> Source: https://gforth.org/manual/Types-Tutorial.html

<span id="Types-Tutorial"></span>

<div class="header">

Next: [Factoring Tutorial](Factoring-Tutorial.html#Factoring-Tutorial), Previous: [Stack-Effect Comments Tutorial](Stack_002dEffect-Comments-Tutorial.html#Stack_002dEffect-Comments-Tutorial), Up: [Tutorial](Tutorial.html#Tutorial)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Types"></span>

### 3.12 Types

<span id="index-types-tutorial"></span>

In Forth the names of the operations are not overloaded; so similar operations on different types need different names; e.g., `+` adds integers, and you have to use `f+` to add floating-point numbers. The following prefixes are often used for related operations on different types:

  - `(none)`  
    signed integer

  - `u`  
    unsigned integer

  - `c`  
    character

  - `d`  
    signed double-cell integer

  - `ud, du`  
    unsigned double-cell integer

  - `2`  
    two cells (not-necessarily double-cell numbers)

  - `m, um`  
    mixed single-cell and double-cell operations

  - `f`  
    floating-point (note that in stack comments ‘`f`’ represents flags, and ‘`r`’ represents FP numbers; also, you need to include the exponent part in literal FP numbers, see [Floating Point Tutorial](Floating-Point-Tutorial.html#Floating-Point-Tutorial)).

If there are no differences between the signed and the unsigned variant (e.g., for `+`), there is only the prefix-less variant.

Forth does not perform type checking, neither at compile time, nor at run time. If you use the wrong operation, the data are interpreted incorrectly:

<div class="example">

``` example
-1 u.
```

</div>

If you have only experience with type-checked languages until now, and have heard how important type-checking is, don’t panic\! In my experience (and that of other Forthers), type errors in Forth code are usually easy to find (once you get used to it), the increased vigilance of the programmer tends to catch some harder errors in addition to most type errors, and you never have to work around the type system, so in most situations the lack of type-checking seems to be a win (projects to add type checking to Forth have not caught on).

-----

<div class="header">

Next: [Factoring Tutorial](Factoring-Tutorial.html#Factoring-Tutorial), Previous: [Stack-Effect Comments Tutorial](Stack_002dEffect-Comments-Tutorial.html#Stack_002dEffect-Comments-Tutorial), Up: [Tutorial](Tutorial.html#Tutorial)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
