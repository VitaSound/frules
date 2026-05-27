> Source: https://gforth.org/manual/Counted-loops-Tutorial.html

<span id="Counted-loops-Tutorial"></span>

<div class="header">

Next: [Recursion Tutorial](Recursion-Tutorial.html#Recursion-Tutorial), Previous: [General Loops Tutorial](General-Loops-Tutorial.html#General-Loops-Tutorial), Up: [Tutorial](Tutorial.html#Tutorial)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Counted-loops"></span>

### 3.19 Counted loops

<span id="index-loops_002c-counted_002c-tutorial"></span>

<div class="example">

``` example
: ^ ( n1 u -- n )
\ n = the uth power of n1
  1 swap 0 u+do
    over *
  loop
  nip ;
3 2 ^ .
4 3 ^ .
```

</div>

`U+do` (from `compat/loops.fs`, if your Forth system doesn’t have it) takes two numbers of the stack `( u3 u4 -- )`, and then performs the code between `u+do` and `loop` for `u3-u4` times (or not at all, if `u3-u4<0`).

You can see the stack effect design rules at work in the stack effect of the loop start words: Since the start value of the loop is more frequently constant than the end value, the start value is passed on the top-of-stack.

You can access the counter of a counted loop with `i`:

<div class="example">

``` example
: fac ( u -- u! )
  1 swap 1+ 1 u+do
    i *
  loop ;
5 fac .
7 fac .
```

</div>

There is also `+do`, which expects signed numbers (important for deciding whether to enter the loop).

> **Assignment:** Write a definition for computing the nth Fibonacci number.

You can also use increments other than 1:

<div class="example">

``` example
: up2 ( n1 n2 -- )
  +do
    i .
  2 +loop ;
10 0 up2

: down2 ( n1 n2 -- )
  -do
    i .
  2 -loop ;
0 10 down2
```

</div>

Reference: [Counted Loops](Counted-Loops.html#Counted-Loops).
