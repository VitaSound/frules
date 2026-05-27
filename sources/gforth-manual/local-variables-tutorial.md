> Source: https://gforth.org/manual/Local-Variables-Tutorial.html

<span id="Local-Variables-Tutorial"></span>

<div class="header">

Next: [Conditional execution Tutorial](Conditional-execution-Tutorial.html#Conditional-execution-Tutorial), Previous: [Designing the stack effect Tutorial](Designing-the-stack-effect-Tutorial.html#Designing-the-stack-effect-Tutorial), Up: [Tutorial](Tutorial.html#Tutorial)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Local-Variables"></span>

### 3.15 Local Variables

<span id="index-local-variables_002c-tutorial"></span>

You can define local variables (*locals*) in a colon definition:

<div class="example">

``` example
: swap { a b -- b a }
  b a ;
1 2 swap .s 2drop
```

</div>

(If your Forth system does not support this syntax, include `compat/anslocal.fs` first).

In this example `{ a b -- b a }` is the locals definition; it takes two cells from the stack, puts the top of stack in `b` and the next stack element in `a`. `--` starts a comment ending with `}`. After the locals definition, using the name of the local will push its value on the stack. You can omit the comment part (`-- b a`):

<div class="example">

``` example
: swap ( x1 x2 -- x2 x1 )
  { a b } b a ;
```

</div>

In Gforth you can have several locals definitions, anywhere in a colon definition; in contrast, in a standard program you can have only one locals definition per colon definition, and that locals definition must be outside any control structure.

With locals you can write slightly longer definitions without running into stack trouble. However, I recommend trying to write colon definitions without locals for exercise purposes to help you gain the essential factoring skills.

> **Assignment:** Rewrite your definitions until now with locals

Reference: [Locals](Locals.html#Locals).
