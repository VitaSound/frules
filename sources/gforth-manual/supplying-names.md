> Source: https://gforth.org/manual/Supplying-names.html

<span id="Supplying-names"></span>

<div class="header">

Next: [User-defined Defining Words](User_002ddefined-Defining-Words.html#User_002ddefined-Defining-Words), Previous: [Quotations](Quotations.html#Quotations), Up: [Defining Words](Defining-Words.html#Defining-Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Supplying-the-name-of-a-defined-word"></span>

#### 5.9.8 Supplying the name of a defined word

<span id="index-names-for-defined-words"></span> <span id="index-defining-words_002c-name-given-in-a-string"></span>

By default, a defining word takes the name for the defined word from the input stream. Sometimes you want to supply the name from a string. You can do this with:

<span id="index-nextname--c_002daddr-u-_002d_002d--gforth"></span> <span id="index-nextname"></span> <span id="index-nextname-1"></span>

<div class="format">

``` format
nextname       c-addr u –         gforth       “nextname”
```

</div>

The next defined word will have the name `c-addr u`; the defining word will leave the input stream alone.

For example:

<div class="example">

``` example
s" foo" nextname create
```

</div>

is equivalent to:

<div class="example">

``` example
create foo
```

</div>

`nextname` works with any defining word.
