> Source: https://gforth.org/manual/Leaving-definitions-or-loops-Tutorial.html

<span id="Leaving-definitions-or-loops-Tutorial"></span>

<div class="header">

Next: [Return Stack Tutorial](Return-Stack-Tutorial.html#Return-Stack-Tutorial), Previous: [Recursion Tutorial](Recursion-Tutorial.html#Recursion-Tutorial), Up: [Tutorial](Tutorial.html#Tutorial)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Leaving-definitions-or-loops"></span>

### 3.21 Leaving definitions or loops

<span id="index-leaving-definitions_002c-tutorial"></span> <span id="index-leaving-loops_002c-tutorial"></span>

`EXIT` exits the current definition right away. For every counted loop that is left in this way, an `UNLOOP` has to be performed before the `EXIT`:

<div class="example">

``` example
: ...
 ... u+do
   ... if
     ... unloop exit
   endif
   ...
 loop
 ... ;
```

</div>

`LEAVE` leaves the innermost counted loop right away:

<div class="example">

``` example
: ...
 ... u+do
   ... if
     ... leave
   endif
   ...
 loop
 ... ;
```

</div>

Reference: [Calls and returns](Calls-and-returns.html#Calls-and-returns), [Counted Loops](Counted-Loops.html#Counted-Loops).
