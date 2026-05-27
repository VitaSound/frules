> Source: https://gforth.org/manual/Compilation-Tokens-Tutorial.html

<span id="Compilation-Tokens-Tutorial"></span>

<div class="header">

Next: [Wordlists and Search Order Tutorial](Wordlists-and-Search-Order-Tutorial.html#Wordlists-and-Search-Order-Tutorial), Previous: [Advanced macros Tutorial](Advanced-macros-Tutorial.html#Advanced-macros-Tutorial), Up: [Tutorial](Tutorial.html#Tutorial)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Compilation-Tokens"></span>

### 3.36 Compilation Tokens

<span id="index-compilation-tokens_002c-tutorial"></span> <span id="index-CT_002c-tutorial"></span>

This section is Gforth-specific. You can skip it.

`' word compile,` compiles the interpretation semantics. For words with default compilation semantics this is the same as performing the compilation semantics. To represent the compilation semantics of other words (e.g., words like `if` that have no interpretation semantics), Gforth has the concept of a compilation token (CT, consisting of two cells), and words `comp'` and `[comp']`. You can perform the compilation semantics represented by a CT with `execute`:

<div class="example">

``` example
: foo2 ( n1 n2 -- n )
   [ comp' + execute ] ;
see foo
```

</div>

You can compile the compilation semantics represented by a CT with `postpone,`:

<div class="example">

``` example
: foo3 ( -- )
  [ comp' + postpone, ] ;
see foo3
```

</div>

`[ comp' word postpone, ]` is equivalent to `POSTPONE word`. `comp'` is particularly useful for words that have no interpretation semantics:

<div class="example">

``` example
' if
comp' if .s 2drop
```

</div>

Reference: [Tokens for Words](Tokens-for-Words.html#Tokens-for-Words).
