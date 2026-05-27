> Source: https://gforth.org/manual/Colon-Definitions-Tutorial.html

<span id="Colon-Definitions-Tutorial"></span>

<div class="header">

Next: [Decompilation Tutorial](Decompilation-Tutorial.html#Decompilation-Tutorial), Previous: [Comments Tutorial](Comments-Tutorial.html#Comments-Tutorial), Up: [Tutorial](Tutorial.html#Tutorial)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Colon-Definitions-1"></span>

### 3.9 Colon Definitions

<span id="index-colon-definitions_002c-tutorial"></span> <span id="index-definitions_002c-tutorial"></span> <span id="index-procedures_002c-tutorial"></span> <span id="index-functions_002c-tutorial"></span>

are similar to procedures and functions in other programming languages.

<div class="example">

``` example
: squared ( n -- n^2 )
   dup * ;
5 squared .
7 squared .
```

</div>

`:` starts the colon definition; its name is `squared`. The following comment describes its stack effect. The words `dup *` are not executed, but compiled into the definition. `;` ends the colon definition.

The newly-defined word can be used like any other word, including using it in other definitions:

<div class="example">

``` example
: cubed ( n -- n^3 )
   dup squared * ;
-5 cubed .
: fourth-power ( n -- n^4 )
   squared squared ;
3 fourth-power .
```

</div>

> **Assignment:** Write colon definitions for `nip`, `tuck`, `negate`, and `/mod` in terms of other Forth words, and check if they work (hint: test your tests on the originals first). Don’t let the ‘`redefined`’-Messages spook you, they are just warnings.

Reference: [Colon Definitions](Colon-Definitions.html#Colon-Definitions).
