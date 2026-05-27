> Source: https://gforth.org/manual/Arithmetics-Tutorial.html

<span id="Arithmetics-Tutorial"></span>

<div class="header">

Next: [Stack Manipulation Tutorial](Stack-Manipulation-Tutorial.html#Stack-Manipulation-Tutorial), Previous: [Stack Tutorial](Stack-Tutorial.html#Stack-Tutorial), Up: [Tutorial](Tutorial.html#Tutorial)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Arithmetics"></span>

### 3.5 Arithmetics

<span id="index-arithmetics-tutorial"></span>

The words `+`, `-`, `*`, `/`, and `mod` always operate on the top two stack items:

<div class="example">

``` example
2 2 .s
+ .s
.
2 1 - .
7 3 mod .
```

</div>

The operands of `-`, `/`, and `mod` are in the same order as in the corresponding infix expression (this is generally the case in Forth).

Parentheses are superfluous (and not available), because the order of the words unambiguously determines the order of evaluation and the operands:

<div class="example">

``` example
3 4 + 5 * .
3 4 5 * + .
```

</div>

> **Assignment:** What are the infix expressions corresponding to the Forth code above? Write `6-7*8+9` in Forth notation[<sup>3</sup>](#FOOT3).

To change the sign, use `negate`:

<div class="example">

``` example
2 negate .
```

</div>

> **Assignment:** Convert -(-3)\*4-5 to Forth.

`/mod` performs both `/` and `mod`.

<div class="example">

``` example
7 3 /mod . .
```

</div>

Reference: [Arithmetic](Arithmetic.html#Arithmetic).

<div class="footnote">

-----

#### Footnotes

### [(3)](#DOCF3)

This notation is also known as Postfix or RPN (Reverse Polish Notation).

</div>
