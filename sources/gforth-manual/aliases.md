> Source: https://gforth.org/manual/Aliases.html

<span id="Aliases"></span>

<div class="header">

Previous: [Forward](Forward.html#Forward), Up: [Defining Words](Defining-Words.html#Defining-Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Aliases-1"></span>

#### 5.9.12 Aliases

<span id="index-aliases"></span>

The defining word `Alias` allows you to define a word by name that has the same behaviour as some other word. Here are two situation where this can be useful:

  - When you want access to a word’s definition from a different word list (for an example of this, see the definition of the `Root` word list in the Gforth source).
  - When you want to create a synonym; a definition that can be known by either of two names (for example, `THEN` and `ENDIF` are aliases).

Like deferred words, an alias has default compilation and interpretation semantics at the beginning (not the modifications of the other word), but you can change them in the usual ways (`immediate`, `compile-only`). For example:

<div class="example">

``` example
: foo ... ; immediate

' foo Alias bar \ bar is not an immediate word
' foo Alias fooby immediate \ fooby is an immediate word
```

</div>

Words that are aliases have the same xt, different headers in the dictionary, and consequently different name tokens (see [Tokens for Words](Tokens-for-Words.html#Tokens-for-Words)) and possibly different immediate flags. An alias can only have default or immediate compilation semantics; you can define aliases for combined words with `interpret/compile:` – see [Combined words](Combined-words.html#Combined-words).

<span id="index-Alias--xt-_0022name_0022-_002d_002d--gforth"></span> <span id="index-Alias"></span> <span id="index-Alias-1"></span>

<div class="format">

``` format
Alias       xt "name" –         gforth       “Alias”
```

</div>
