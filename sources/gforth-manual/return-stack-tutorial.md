> Source: https://gforth.org/manual/Return-Stack-Tutorial.html

<span id="Return-Stack-Tutorial"></span>

<div class="header">

Next: [Memory Tutorial](Memory-Tutorial.html#Memory-Tutorial), Previous: [Leaving definitions or loops Tutorial](Leaving-definitions-or-loops-Tutorial.html#Leaving-definitions-or-loops-Tutorial), Up: [Tutorial](Tutorial.html#Tutorial)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Return-Stack"></span>

### 3.22 Return Stack

<span id="index-return-stack-tutorial"></span>

In addition to the data stack Forth also has a second stack, the return stack; most Forth systems store the return addresses of procedure calls there (thus its name). Programmers can also use this stack:

<div class="example">

``` example
: foo ( n1 n2 -- )
 .s
 >r .s
 r@ .
 >r .s
 r@ .
 r> .
 r@ .
 r> . ;
1 2 foo
```

</div>

`>r` takes an element from the data stack and pushes it onto the return stack; conversely, `r>` moves an element from the return to the data stack; `r@` pushes a copy of the top of the return stack on the data stack.

Forth programmers usually use the return stack for storing data temporarily, if using the data stack alone would be too complex, and factoring and locals are not an option:

<div class="example">

``` example
: 2swap ( x1 x2 x3 x4 -- x3 x4 x1 x2 )
 rot >r rot r> ;
```

</div>

The return address of the definition and the loop control parameters of counted loops usually reside on the return stack, so you have to take all items, that you have pushed on the return stack in a colon definition or counted loop, from the return stack before the definition or loop ends. You cannot access items that you pushed on the return stack outside some definition or loop within the definition of loop.

If you miscount the return stack items, this usually ends in a crash:

<div class="example">

``` example
: crash ( n -- )
  >r ;
5 crash
```

</div>

You cannot mix using locals and using the return stack (according to the standard; Gforth has no problem). However, they solve the same problems, so this shouldn’t be an issue.

> **Assignment:** Can you rewrite any of the definitions you wrote until now in a better way using the return stack?

Reference: [Return stack](Return-stack.html#Return-stack).

-----

<div class="header">

Next: [Memory Tutorial](Memory-Tutorial.html#Memory-Tutorial), Previous: [Leaving definitions or loops Tutorial](Leaving-definitions-or-loops-Tutorial.html#Leaving-definitions-or-loops-Tutorial), Up: [Tutorial](Tutorial.html#Tutorial)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
