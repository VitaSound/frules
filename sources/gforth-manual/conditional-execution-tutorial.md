> Source: https://gforth.org/manual/Conditional-execution-Tutorial.html

<span id="Conditional-execution-Tutorial"></span>

<div class="header">

Next: [Flags and Comparisons Tutorial](Flags-and-Comparisons-Tutorial.html#Flags-and-Comparisons-Tutorial), Previous: [Local Variables Tutorial](Local-Variables-Tutorial.html#Local-Variables-Tutorial), Up: [Tutorial](Tutorial.html#Tutorial)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Conditional-execution"></span>

### 3.16 Conditional execution

<span id="index-conditionals_002c-tutorial"></span> <span id="index-if_002c-tutorial"></span>

In Forth you can use control structures only inside colon definitions. An `if`-structure looks like this:

<div class="example">

``` example
: abs ( n1 -- +n2 )
    dup 0 < if
        negate
    endif ;
5 abs .
-5 abs .
```

</div>

`if` takes a flag from the stack. If the flag is non-zero (true), the following code is performed, otherwise execution continues after the `endif` (or `else`). `<` compares the top two stack elements and produces a flag:

<div class="example">

``` example
1 2 < .
2 1 < .
1 1 < .
```

</div>

Actually the standard name for `endif` is `then`. This tutorial presents the examples using `endif`, because this is often less confusing for people familiar with other programming languages where `then` has a different meaning. If your system does not have `endif`, define it with

<div class="example">

``` example
: endif postpone then ; immediate
```

</div>

You can optionally use an `else`-part:

<div class="example">

``` example
: min ( n1 n2 -- n )
  2dup < if
    drop
  else
    nip
  endif ;
2 3 min .
3 2 min .
```

</div>

> **Assignment:** Write `min` without `else`-part (hint: what’s the definition of `nip`?).

Reference: [Selection](Selection.html#Selection).
