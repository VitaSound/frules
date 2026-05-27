> Source: https://gforth.org/manual/Stack-Manipulation-Tutorial.html

<span id="Stack-Manipulation-Tutorial"></span>

<div class="header">

Next: [Using files for Forth code Tutorial](Using-files-for-Forth-code-Tutorial.html#Using-files-for-Forth-code-Tutorial), Previous: [Arithmetics Tutorial](Arithmetics-Tutorial.html#Arithmetics-Tutorial), Up: [Tutorial](Tutorial.html#Tutorial)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Stack-Manipulation-1"></span>

### 3.6 Stack Manipulation

<span id="index-stack-manipulation-tutorial"></span>

Stack manipulation words rearrange the data on the stack.

<div class="example">

``` example
1 .s drop .s
1 .s dup .s drop drop .s
1 2 .s over .s drop drop drop
1 2 .s swap .s drop drop
1 2 3 .s rot .s drop drop drop
```

</div>

These are the most important stack manipulation words. There are also variants that manipulate twice as many stack items:

<div class="example">

``` example
1 2 3 4 .s 2swap .s 2drop 2drop
```

</div>

Two more stack manipulation words are:

<div class="example">

``` example
1 2 .s nip .s drop
1 2 .s tuck .s 2drop drop
```

</div>

> **Assignment:** Replace `nip` and `tuck` with combinations of other stack manipulation words.
> 
> <div class="example">
> 
> ``` example
> Given:          How do you get:
> 1 2 3           3 2 1           
> 1 2 3           1 2 3 2                 
> 1 2 3           1 2 3 3                 
> 1 2 3           1 3 3           
> 1 2 3           2 1 3           
> 1 2 3 4         4 3 2 1         
> 1 2 3           1 2 3 1 2 3             
> 1 2 3 4         1 2 3 4 1 2             
> 1 2 3
> 1 2 3           1 2 3 4                 
> 1 2 3           1 3             
> ```
> 
> </div>

<div class="example">

``` example
5 dup * .
```

</div>

> **Assignment:** Write 17^3 and 17^4 in Forth, without writing `17` more than once. Write a piece of Forth code that expects two numbers on the stack (`a` and `b`, with `b` on top) and computes `(a-b)(a+1)`.

Reference: [Stack Manipulation](Stack-Manipulation.html#Stack-Manipulation).
