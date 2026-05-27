> Source: https://gforth.org/manual/Colon-Definitions.html

<span id="Colon-Definitions"></span>

<div class="header">

Next: [Anonymous Definitions](Anonymous-Definitions.html#Anonymous-Definitions), Previous: [Values](Values.html#Values), Up: [Defining Words](Defining-Words.html#Defining-Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Colon-Definitions-2"></span>

#### 5.9.5 Colon Definitions

<span id="index-colon-definitions"></span>

<div class="example">

``` example
: name ( ... -- ... )
    word1 word2 word3 ;
```

</div>

Creates a word called `name` that, upon execution, executes `word1 word2 word3`. `name` is a *(colon) definition*.

The explanation above is somewhat superficial. For simple examples of colon definitions see [Your first definition](Your-first-definition.html#Your-first-definition). For an in-depth discussion of some of the issues involved, See [Interpretation and Compilation Semantics](Interpretation-and-Compilation-Semantics.html#Interpretation-and-Compilation-Semantics).

<span id="index-_003a--_0022name_0022-_002d_002d-colon_002dsys--core"></span> <span id="index-_003a"></span>

<div class="format">

``` format
:       "name" – colon-sys         core       “colon”
```

</div>

<span id="index-_003b--compilation-colon_002dsys-_002d_002d-_003b-run_002dtime-nest_002dsys--core"></span> <span id="index-_003b"></span> <span id="index-_003b-1"></span>

<div class="format">

``` format
;       compilation colon-sys – ; run-time nest-sys         core       “semicolon”
```

</div>
