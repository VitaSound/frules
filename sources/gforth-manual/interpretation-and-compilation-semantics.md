> Source: https://gforth.org/manual/Interpretation-and-Compilation-Semantics.html

<span id="Interpretation-and-Compilation-Semantics"></span>

<div class="header">

Next: [Tokens for Words](Tokens-for-Words.html#Tokens-for-Words), Previous: [Defining Words](Defining-Words.html#Defining-Words), Up: [Words](Words.html#Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Interpretation-and-Compilation-Semantics-1"></span>

### 5.10 Interpretation and Compilation Semantics

<span id="index-semantics_002c-interpretation-and-compilation"></span> <span id="index-interpretation-semantics-1"></span>

The *interpretation semantics* of a (named) word are what the text interpreter does when it encounters the word in interpret state. It also appears in some other contexts, e.g., the execution token returned by `' word` identifies the interpretation semantics of *word* (in other words, `' word execute` is equivalent to interpret-state text interpretation of `word`).

<span id="index-compilation-semantics-1"></span>

The *compilation semantics* of a (named) word are what the text interpreter does when it encounters the word in compile state. It also appears in other contexts, e.g, `POSTPONE word` compiles[<sup>18</sup>](#FOOT18) the compilation semantics of *word*.

<span id="index-execution-semantics"></span>

The standard also talks about *execution semantics*. They are used only for defining the interpretation and compilation semantics of many words. By default, the interpretation semantics of a word are to `execute` its execution semantics, and the compilation semantics of a word are to `compile,` its execution semantics.[<sup>19</sup>](#FOOT19)

Unnamed words (see [Anonymous Definitions](Anonymous-Definitions.html#Anonymous-Definitions)) cannot be encountered by the text interpreter, ticked, or `postpone`d, so they have no interpretation or compilation semantics. Their behaviour is represented by their XT (see [Tokens for Words](Tokens-for-Words.html#Tokens-for-Words)), and we call it execution semantics, too.

<span id="index-immediate-words-1"></span> <span id="index-compile_002donly-words"></span>

You can change the semantics of the most-recently defined word:

<span id="index-immediate--_002d_002d--core"></span> <span id="index-immediate"></span> <span id="index-immediate-1"></span>

<div class="format">

``` format
immediate       –         core       “immediate”
```

</div>

Make the compilation semantics of a word be to `execute` the execution semantics.

<span id="index-compile_002donly--_002d_002d--gforth"></span> <span id="index-compile_002donly"></span> <span id="index-compile_002donly-1"></span>

<div class="format">

``` format
compile-only       –         gforth       “compile-only”
```

</div>

Mark the last definition as compile-only; as a result, the text interpreter and `'` will warn when they encounter such a word.

<span id="index-restrict--_002d_002d--gforth"></span> <span id="index-restrict"></span> <span id="index-restrict-1"></span>

<div class="format">

``` format
restrict       –         gforth       “restrict”
```

</div>

A synonym for `compile-only`

By convention, words with non-default compilation semantics (e.g., immediate words) often have names surrounded with brackets (e.g., `[']`, see [Execution token](Execution-token.html#Execution-token)).

Note that ticking (`'`) a compile-only word gives a warning (“\<word\> is compile-only”).

|                                                         |  |  |
| :------------------------------------------------------ |  | :- |
| • [Combined words](Combined-words.html#Combined-words): |  |  |

<div class="footnote">

-----

#### Footnotes

### [(18)](#DOCF18)

In standard terminology, “appends to the current definition”.

### [(19)](#DOCF19)

In standard terminology: The default interpretation semantics are its execution semantics; the default compilation semantics are to append its execution semantics to the execution semantics of the current definition.

</div>

-----

<div class="header">

Next: [Tokens for Words](Tokens-for-Words.html#Tokens-for-Words), Previous: [Defining Words](Defining-Words.html#Defining-Words), Up: [Words](Words.html#Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
