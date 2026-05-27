> Source: https://gforth.org/manual/Recursion-Tutorial.html

<span id="Recursion-Tutorial"></span>

<div class="header">

Next: [Leaving definitions or loops Tutorial](Leaving-definitions-or-loops-Tutorial.html#Leaving-definitions-or-loops-Tutorial), Previous: [Counted loops Tutorial](Counted-loops-Tutorial.html#Counted-loops-Tutorial), Up: [Tutorial](Tutorial.html#Tutorial)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Recursion"></span>

### 3.20 Recursion

<span id="index-recursion-tutorial"></span>

Usually the name of a definition is not visible in the definition; but earlier definitions are usually visible:

<div class="example">

``` example
1 0 / . \ "Floating-point unidentified fault" in Gforth on some platforms
: / ( n1 n2 -- n )
  dup 0= if
    -10 throw \ report division by zero
  endif
  /           \ old version
;
1 0 /
```

</div>

For recursive definitions you can use `recursive` (non-standard) or `recurse`:

<div class="example">

``` example
: fac1 ( n -- n! ) recursive
 dup 0> if
   dup 1- fac1 *
 else
   drop 1
 endif ;
7 fac1 .

: fac2 ( n -- n! )
 dup 0> if
   dup 1- recurse *
 else
   drop 1
 endif ;
8 fac2 .
```

</div>

> **Assignment:** Write a recursive definition for computing the nth Fibonacci number.

Reference (including indirect recursion): See [Calls and returns](Calls-and-returns.html#Calls-and-returns).
