> Source: https://gforth.org/manual/Characters-and-Strings-Tutorial.html

<span id="Characters-and-Strings-Tutorial"></span>

<div class="header">

Next: [Alignment Tutorial](Alignment-Tutorial.html#Alignment-Tutorial), Previous: [Memory Tutorial](Memory-Tutorial.html#Memory-Tutorial), Up: [Tutorial](Tutorial.html#Tutorial)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Characters-and-Strings"></span>

### 3.24 Characters and Strings

<span id="index-strings-tutorial"></span> <span id="index-characters-tutorial"></span>

On the stack characters take up a cell, like numbers. In memory they have their own size (one 8-bit byte on most systems), and therefore require their own words for memory access:

<div class="example">

``` example
create v4 
  104 c, 97 c, 108 c, 108 c, 111 c,
v4 4 chars + c@ .
v4 5 chars dump
```

</div>

The preferred representation of strings on the stack is `addr u-count`, where `addr` is the address of the first character and `u-count` is the number of characters in the string.

<div class="example">

``` example
v4 5 type
```

</div>

You get a string constant with

<div class="example">

``` example
s" hello, world" .s
type
```

</div>

Make sure you have a space between `s"` and the string; `s"` is a normal Forth word and must be delimited with white space (try what happens when you remove the space).

However, this interpretive use of `s"` is quite restricted: the string exists only until the next call of `s"` (some Forth systems keep more than one of these strings, but usually they still have a limited lifetime).

<div class="example">

``` example
s" hello," s" world" .s
type
type
```

</div>

You can also use `s"` in a definition, and the resulting strings then live forever (well, for as long as the definition):

<div class="example">

``` example
: foo s" hello," s" world" ;
foo .s
type
type
```

</div>

> **Assignment:** `Emit ( c -- )` types `c` as character (not a number). Implement `type ( addr u -- )`.

Reference: [Memory Blocks](Memory-Blocks.html#Memory-Blocks).
