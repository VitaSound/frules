> Source: https://gforth.org/manual/Gforth-locals.html

<span id="Gforth-locals"></span>

<div class="header">

Next: [Standard Forth locals](Standard-Forth-locals.html#Standard-Forth-locals), Previous: [Locals](Locals.html#Locals), Up: [Locals](Locals.html#Locals)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Gforth-locals-1"></span>

#### 5.21.1 Gforth locals

<span id="index-Gforth-locals"></span> <span id="index-locals_002c-Gforth-style"></span>

Locals can be defined with

<div class="example">

``` example
{ local1 local2 ... -- comment }
```

</div>

or

<div class="example">

``` example
{ local1 local2 ... }
```

</div>

E.g.,

<div class="example">

``` example
: max { n1 n2 -- n3 }
 n1 n2 > if
   n1
 else
   n2
 endif ;
```

</div>

The similarity of locals definitions with stack comments is intended. A locals definition often replaces the stack comment of a word. The order of the locals corresponds to the order in a stack comment and everything after the `--` is really a comment.

This similarity has one disadvantage: It is too easy to confuse locals declarations with stack comments, causing bugs and making them hard to find. However, this problem can be avoided by appropriate coding conventions: Do not use both notations in the same program. If you do, they should be distinguished using additional means, e.g. by position.

<span id="index-types-of-locals"></span> <span id="index-locals-types"></span>

The name of the local may be preceded by a type specifier, e.g., `F:` for a floating point value:

<div class="example">

``` example
: CX* { F: Ar F: Ai F: Br F: Bi -- Cr Ci }
\ complex multiplication
 Ar Br f* Ai Bi f* f-
 Ar Bi f* Ai Br f* f+ ;
```

</div>

<span id="index-flavours-of-locals"></span> <span id="index-locals-flavours"></span> <span id="index-value_002dflavoured-locals"></span> <span id="index-variable_002dflavoured-locals"></span>

Gforth currently supports cells (`W:`, `W^`), doubles (`D:`, `D^`), floats (`F:`, `F^`) and characters (`C:`, `C^`) in two flavours: a value-flavoured local (defined with `W:`, `D:` etc.) produces its value and can be changed with `TO`. A variable-flavoured local (defined with `W^` etc.) produces its address (which becomes invalid when the variable’s scope is left). E.g., the standard word `emit` can be defined in terms of `type` like this:

<div class="example">

``` example
: emit { C^ char* -- }
    char* 1 type ;
```

</div>

<span id="index-default-type-of-locals"></span> <span id="index-locals_002c-default-type"></span>

A local without type specifier is a `W:` local. Both flavours of locals are initialized with values from the data or FP stack.

Currently there is no way to define locals with user-defined data structures, but we are working on it.

Gforth allows defining locals everywhere in a colon definition. This poses the following questions:

|                                                                                                                          |  |  |
| :----------------------------------------------------------------------------------------------------------------------- |  | :- |
| • [Where are locals visible by name?](Where-are-locals-visible-by-name_003f.html#Where-are-locals-visible-by-name_003f): |  |  |
| • [How long do locals live?](How-long-do-locals-live_003f.html#How-long-do-locals-live_003f):                            |  |  |
| • [Locals programming style](Locals-programming-style.html#Locals-programming-style):                                    |  |  |
| • [Locals implementation](Locals-implementation.html#Locals-implementation):                                             |  |  |

-----

<div class="header">

Next: [Standard Forth locals](Standard-Forth-locals.html#Standard-Forth-locals), Previous: [Locals](Locals.html#Locals), Up: [Locals](Locals.html#Locals)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
