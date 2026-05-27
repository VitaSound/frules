> Source: https://gforth.org/manual/Quotations.html

<span id="Quotations"></span>

<div class="header">

Next: [Supplying names](Supplying-names.html#Supplying-names), Previous: [Anonymous Definitions](Anonymous-Definitions.html#Anonymous-Definitions), Up: [Defining Words](Defining-Words.html#Defining-Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Quotations-1"></span>

#### 5.9.7 Quotations

<span id="index-quotations"></span> <span id="index-nested-colon-definitions"></span> <span id="index-colon-definitions_002c-nesting"></span>

A quotation is an anonymous colon definition inside another colon definition. Quotations are useful when dealing with words that consume an execution token, like `catch` or `outfile-execute`. E.g. consider the following example of using `outfile-execute` (see [Redirection](Redirection.html#Redirection)):

<div class="example">

``` example
: some-warning ( n -- )
    cr ." warning# " . ;

: print-some-warning ( n -- )
    ['] some-warning stderr outfile-execute ;
```

</div>

Here we defined `some-warning` as a helper word whose xt we could pass to outfile-execute. Instead, we can use a quotation to define such a word anonymously inside `print-some-warning`:

<div class="example">

``` example
: print-some-warning ( n -- )
  [: cr ." warning# " . ;] stderr outfile-execute ;
```

</div>

The quotation is bouded by `[:` and `;]`. It produces an execution token at run-time.

<span id="index-_005b_003a--compile_002dtime_003a-_002d_002d-quotation_002dsys-flag-colon_002dsys--gforth"></span> <span id="index-_005b_003a"></span> <span id="index-_005b_003a-1"></span>

<div class="format">

``` format
[:       compile-time: – quotation-sys flag colon-sys         gforth       “bracket-colon”
```

</div>

Starts a quotation

<span id="index-_003b_005d--compile_002dtime_003a-quotation_002dsys-_002d_002d-_003b-run_002dtime_003a-_002d_002d-xt--gforth"></span> <span id="index-_003b_005d"></span> <span id="index-_003b_005d-1"></span>

<div class="format">

``` format
;]       compile-time: quotation-sys – ; run-time: – xt         gforth       “semi-bracket”
```

</div>

ends a quotation
