> Source: https://gforth.org/manual/General-Loops-Tutorial.html

<span id="General-Loops-Tutorial"></span>

<div class="header">

Next: [Counted loops Tutorial](Counted-loops-Tutorial.html#Counted-loops-Tutorial), Previous: [Flags and Comparisons Tutorial](Flags-and-Comparisons-Tutorial.html#Flags-and-Comparisons-Tutorial), Up: [Tutorial](Tutorial.html#Tutorial)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="General-Loops"></span>

### 3.18 General Loops

<span id="index-loops_002c-indefinite_002c-tutorial"></span>

The endless loop is the most simple one:

<div class="example">

``` example
: endless ( -- )
  0 begin
    dup . 1+
  again ;
endless
```

</div>

Terminate this loop by pressing <span class="kbd">Ctrl-C</span> (in Gforth). `begin` does nothing at run-time, `again` jumps back to `begin`.

A loop with one exit at any place looks like this:

<div class="example">

``` example
: log2 ( +n1 -- n2 )
\ logarithmus dualis of n1>0, rounded down to the next integer
  assert( dup 0> )
  2/ 0 begin
    over 0> while
      1+ swap 2/ swap
  repeat
  nip ;
7 log2 .
8 log2 .
```

</div>

At run-time `while` consumes a flag; if it is 0, execution continues behind the `repeat`; if the flag is non-zero, execution continues behind the `while`. `Repeat` jumps back to `begin`, just like `again`.

In Forth there are a number of combinations/abbreviations, like `1+`. However, `2/` is not one of them; it shifts its argument right by one bit (arithmetic shift right), and viewed as division that always rounds towards negative infinity (floored division). In contrast, `/` rounds towards zero on some systems (not on default installations of gforth (\>=0.7.0), however).

<div class="example">

``` example
-5 2 / . \ -2 or -3
-5 2/ .  \ -3
```

</div>

`assert(` is no standard word, but you can get it on systems other than Gforth by including `compat/assert.fs`. You can see what it does by trying

<div class="example">

``` example
0 log2 .
```

</div>

Here’s a loop with an exit at the end:

<div class="example">

``` example
: log2 ( +n1 -- n2 )
\ logarithmus dualis of n1>0, rounded down to the next integer
  assert( dup 0 > )
  -1 begin
    1+ swap 2/ swap
    over 0 <=
  until
  nip ;
```

</div>

`Until` consumes a flag; if it is zero, execution continues at the `begin`, otherwise after the `until`.

> **Assignment:** Write a definition for computing the greatest common divisor.

Reference: [Simple Loops](Simple-Loops.html#Simple-Loops).

-----

<div class="header">

Next: [Counted loops Tutorial](Counted-loops-Tutorial.html#Counted-loops-Tutorial), Previous: [Flags and Comparisons Tutorial](Flags-and-Comparisons-Tutorial.html#Flags-and-Comparisons-Tutorial), Up: [Tutorial](Tutorial.html#Tutorial)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
