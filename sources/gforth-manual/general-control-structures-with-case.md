> Source: https://gforth.org/manual/General-control-structures-with-CASE.html

<span id="General-control-structures-with-CASE"></span>

<div class="header">

Next: [Arbitrary control structures](Arbitrary-control-structures.html#Arbitrary-control-structures), Previous: [BEGIN loops with multiple exits](BEGIN-loops-with-multiple-exits.html#BEGIN-loops-with-multiple-exits), Up: [Control Structures](Control-Structures.html#Control-Structures)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="General-control-structures-with-case"></span>

#### 5.8.5 General control structures with `case`

<span id="index-case-as-generalized-control-structure"></span> <span id="index-general-control-structures-_0028case_0029"></span>

Gforth provides an extended `case` that solves the problems of the multi-exit loops discussed above, and offers additional options. You can find a portable implementation of this extended `case` in `compat/caseext.fs`.

There are three additional words in the extension. The first is `?of` which allows general tests (rather than just testing for equality) in a `case`; e.g.,

<div class="example">

``` example
: sgn ( n -- -1|0|1 )
  ( n ) case
    dup 0 < ?of drop -1 endof
    dup 0 > ?of drop 1  endof
    \ otherwise leave the 0 on the stack
  0 endcase ;
```

</div>

Note that `endcase` drops a value, which works fine much of the time with `of`, but usually not with `?of`, so we leave a 0 on the stack for `endcase` to drop. The n that is passed into `sgn` is also 0 if neither `?of` triggers, and that is then passed out.

The second additional word is `next-case`, which allows turning `case` into a loop. Our triple-exit loop becomes:

<div class="example">

``` example
case
  condition1 ?of exit-code1 endof
  condition2 ?of exit-code2 endof
  condition3 ?of exit-code3 endof
  ...
next-case
common code afterwards
```

</div>

As you can see, this solves both problems of the variants discussed above (see [BEGIN loops with multiple exits](BEGIN-loops-with-multiple-exits.html#BEGIN-loops-with-multiple-exits)). Note that `next-case` does not drop a value, unlike `endcase`.[<sup>13</sup>](#FOOT13)

The last additional word is `contof`, which is used instead of `endof` and starts the next iteration instead of leaving the loop. This can be used in ways similar to Dijkstra’s guarded command *do*, e.g.:

<div class="example">

``` example
: gcd ( n1 n2 -- n )
    case
        2dup > ?of tuck - contof
        2dup < ?of over - contof
    endcase ;
```

</div>

Here the two `?of`s have different ways of continuing the loop; when neither `?of` triggers, the two numbers are equal and are the gcd. `Endcase` drops one of them, leaving the other as n.

You can also combine these words. Here’s an example that uses each of the `case` words once, except `endcase`:

<div class="example">

``` example
: collatz ( u -- )
    \ print the 3n+1 sequence starting at u until we reach 1
    case
        dup .
        1 of endof
        dup 1 and ?of 3 * 1+ contof
        2/
    next-case ;
```

</div>

This example keeps the current value of the sequence on the stack. If it is 1, the `of` triggers, drops the value, and leaves the `case` structure. For odd numbers, the `?of` triggers, computes 3n+1, and starts the next iteration with `contof`. Otherwise, if the number is even, it is divided by 2, and the loop is restarted with `next-case`.

<div class="footnote">

-----

#### Footnotes

### [(13)](#DOCF13)

`Next-case` has a `-`, unlike the other `case` words, because VFX Forth contains a `nextcase` that drops a value.

</div>

-----

<div class="header">

Next: [Arbitrary control structures](Arbitrary-control-structures.html#Arbitrary-control-structures), Previous: [BEGIN loops with multiple exits](BEGIN-loops-with-multiple-exits.html#BEGIN-loops-with-multiple-exits), Up: [Control Structures](Control-Structures.html#Control-Structures)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
