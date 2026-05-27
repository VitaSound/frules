> Source: https://gforth.org/manual/Compilation-token.html

<span id="Compilation-token"></span>

<div class="header">

Next: [Name token](Name-token.html#Name-token), Previous: [Execution token](Execution-token.html#Execution-token), Up: [Tokens for Words](Tokens-for-Words.html#Tokens-for-Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Compilation-token-1"></span>

#### 5.11.2 Compilation token

<span id="index-compilation-token"></span> <span id="index-CT-_0028compilation-token_0029"></span>

Gforth represents the compilation semantics of a named word by a *compilation token* consisting of two cells: *w xt*. The top cell *xt* is an execution token. The compilation semantics represented by the compilation token can be performed with `execute`, which consumes the whole compilation token, with an additional stack effect determined by the represented compilation semantics.

At present, the *w* part of a compilation token is an execution token, and the *xt* part represents either `execute` or `compile,`[<sup>21</sup>](#FOOT21). However, don’t rely on that knowledge, unless necessary; future versions of Gforth may introduce unusual compilation tokens (e.g., a compilation token that represents the compilation semantics of a literal).

You can perform the compilation semantics represented by the compilation token with `execute`. You can compile the compilation semantics with `postpone,`. I.e., `COMP' word postpone,` is equivalent to `postpone word`.

<span id="index-_005bCOMP_0027_005d--compilation-_0022name_0022-_002d_002d-_003b-run_002dtime-_002d_002d-w-xt--gforth"></span> <span id="index-_005bCOMP_0027_005d"></span> <span id="index-_005bCOMP_0027_005d-1"></span>

<div class="format">

``` format
[COMP']       compilation "name" – ; run-time – w xt         gforth       “bracket-comp-tick”
```

</div>

Compilation token *w xt* represents *name*’s compilation semantics.

<span id="index-COMP_0027--_0022name_0022-_002d_002d-w-xt--gforth"></span> <span id="index-COMP_0027"></span> <span id="index-COMP_0027-1"></span>

<div class="format">

``` format
COMP'       "name" – w xt         gforth       “comp-tick”
```

</div>

Compilation token *w xt* represents *name*’s compilation semantics.

<span id="index-postpone_002c--w-xt-_002d_002d--gforth"></span> <span id="index-postpone_002c"></span> <span id="index-postpone_002c-1"></span>

<div class="format">

``` format
postpone,       w xt –         gforth       “postpone-comma”
```

</div>

Compile the compilation semantics represented by the compilation token *w xt*.

<div class="footnote">

-----

#### Footnotes

### [(21)](#DOCF21)

Depending upon the compilation semantics of the word. If the word has default compilation semantics, the *xt* will represent `compile,`. Otherwise (e.g., for immediate words), the *xt* will represent `execute`.

</div>
