> Source: https://gforth.org/manual/Anonymous-Definitions.html

<span id="Anonymous-Definitions"></span>

<div class="header">

Next: [Quotations](Quotations.html#Quotations), Previous: [Colon Definitions](Colon-Definitions.html#Colon-Definitions), Up: [Defining Words](Defining-Words.html#Defining-Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Anonymous-Definitions-1"></span>

#### 5.9.6 Anonymous Definitions

<span id="index-colon-definitions-1"></span> <span id="index-defining-words-without-name"></span>

Sometimes you want to define an *anonymous word*; a word without a name. You can do this with:

<span id="index-_003anoname--_002d_002d-xt-colon_002dsys--core_002dext"></span> <span id="index-_003anoname"></span>

<div class="format">

``` format
:noname       – xt colon-sys         core-ext       “colon-no-name”
```

</div>

This leaves the execution token for the word on the stack after the closing `;`. Here’s an example in which a deferred word is initialised with an `xt` from an anonymous colon definition:

<div class="example">

``` example
Defer deferred
:noname ( ... -- ... )
  ... ;
IS deferred
```

</div>

Gforth provides an alternative way of doing this, using two separate words:

<span id="index-noname--_002d_002d--gforth"></span> <span id="index-noname"></span> <span id="index-noname-1"></span>

<div class="format">

``` format
noname       –         gforth       “noname”
```

</div>

The next defined word will be anonymous. The defining word will leave the input stream alone. The xt of the defined word will be given by `latestxt`.

<span id="index-execution-token-of-last-defined-word"></span> <span id="index-latestxt--_002d_002d-xt--gforth"></span> <span id="index-latestxt"></span> <span id="index-latestxt-1"></span>

<div class="format">

``` format
latestxt       – xt         gforth       “latestxt”
```

</div>

*xt* is the execution token of the last word defined.

The previous example can be rewritten using `noname` and `latestxt`:

<div class="example">

``` example
Defer deferred
noname : ( ... -- ... )
  ... ;
latestxt IS deferred
```

</div>

`noname` works with any defining word, not just `:`.

`latestxt` also works when the last word was not defined as `noname`. It does not work for combined words, though. It also has the useful property that is is valid as soon as the header for a definition has been built. Thus:

<div class="example">

``` example
latestxt . : foo [ latestxt . ] ; ' foo .
```

</div>

prints 3 numbers; the last two are the same.
