> Source: https://gforth.org/manual/Automatic-Generation.html

<span id="Automatic-Generation"></span>

<div class="header">

Next: [TOS Optimization](TOS-Optimization.html#TOS-Optimization), Previous: [Primitives](Primitives.html#Primitives), Up: [Primitives](Primitives.html#Primitives)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Automatic-Generation-1"></span>

#### 14.3.1 Automatic Generation

<span id="index-primitives_002c-automatic-generation"></span> <span id="index-prims2x_002efs"></span>

Since the primitives are implemented in a portable language, there is no longer any need to minimize the number of primitives. On the contrary, having many primitives has an advantage: speed. In order to reduce the number of errors in primitives and to make programming them easier, we provide a tool, the primitive generator (`prims2x.fs` aka Vmgen, see [Introduction](../vmgen/index.html#Top) in Vmgen), that automatically generates most (and sometimes all) of the C code for a primitive from the stack effect notation. The source for a primitive has the following form:

<span id="index-primitive-source-format"></span>

<div class="format">

``` format
Forth-name  ( stack-effect )        category    [pronounc.]
[""glossary entry""]
C code
[:
Forth code]
```

</div>

The items in brackets are optional. The category and glossary fields are there for generating the documentation, the Forth code is there for manual implementations on machines without GNU C. E.g., the source for the primitive `+` is:

<div class="example">

``` example
+    ( n1 n2 -- n )   core    plus
n = n1+n2;
```

</div>

This looks like a specification, but in fact `n = n1+n2` is C code. Our primitive generation tool extracts a lot of information from the stack effect notations[<sup>39</sup>](#FOOT39): The number of items popped from and pushed on the stack, their type, and by what name they are referred to in the C code. It then generates a C code prelude and postlude for each primitive. The final C code for `+` looks like this:

<div class="example">

``` example
I_plus: /* + ( n1 n2 -- n ) */  /* label, stack effect */
/*  */                          /* documentation */
NAME("+")                       /* debugging output (with -DDEBUG) */
{
DEF_CA                          /* definition of variable ca (indirect threading) */
Cell n1;                        /* definitions of variables */
Cell n2;
Cell n;
NEXT_P0;                        /* NEXT part 0 */
n1 = (Cell) sp[1];              /* input */
n2 = (Cell) TOS;
sp += 1;                        /* stack adjustment */
{
n = n1+n2;                      /* C code taken from the source */
}
NEXT_P1;                        /* NEXT part 1 */
TOS = (Cell)n;                  /* output */
NEXT_P2;                        /* NEXT part 2 */
}
```

</div>

This looks long and inefficient, but the GNU C compiler optimizes quite well and produces optimal code for `+` on, e.g., the R3000 and the HP RISC machines: Defining the `n`s does not produce any code, and using them as intermediate storage also adds no cost.

There are also other optimizations that are not illustrated by this example: assignments between simple variables are usually for free (copy propagation). If one of the stack items is not used by the primitive (e.g. in `drop`), the compiler eliminates the load from the stack (dead code elimination). On the other hand, there are some things that the compiler does not do, therefore they are performed by `prims2x.fs`: The compiler does not optimize code away that stores a stack item to the place where it just came from (e.g., `over`).

While programming a primitive is usually easy, there are a few cases where the programmer has to take the actions of the generator into account, most notably `?dup`, but also words that do not (always) fall through to `NEXT`.

For more information

<div class="footnote">

-----

#### Footnotes

### [(39)](#DOCF39)

We use a one-stack notation, even though we have separate data and floating-point stacks; The separate notation can be generated easily from the unified notation.

</div>

-----

<div class="header">

Next: [TOS Optimization](TOS-Optimization.html#TOS-Optimization), Previous: [Primitives](Primitives.html#Primitives), Up: [Primitives](Primitives.html#Primitives)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
