> Source: https://gforth.org/manual/Combined-words.html

<span id="Combined-words"></span>

<div class="header">

Previous: [Interpretation and Compilation Semantics](Interpretation-and-Compilation-Semantics.html#Interpretation-and-Compilation-Semantics), Up: [Interpretation and Compilation Semantics](Interpretation-and-Compilation-Semantics.html#Interpretation-and-Compilation-Semantics)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Combined-Words"></span>

#### 5.10.1 Combined Words

<span id="index-combined-words"></span>

Gforth allows you to define *combined words* – words that have an arbitrary combination of interpretation and compilation semantics.

<span id="index-interpret_002fcompile_003a--interp_002dxt-comp_002dxt-_0022name_0022-_002d_002d--gforth"></span> <span id="index-interpret_002fcompile_003a"></span> <span id="index-interpret_002fcompile_003a-1"></span>

<div class="format">

``` format
interpret/compile:       interp-xt comp-xt "name" –         gforth       “interpret/compile:”
```

</div>

This feature was introduced for implementing `TO` and `S"`. I recommend that you do not define such words, as cute as they may be: they make it hard to get at both parts of the word in some contexts. E.g., assume you want to get an execution token for the compilation part. Instead, define two words, one that embodies the interpretation part, and one that embodies the compilation part. Once you have done that, you can define a combined word with `interpret/compile:` for the convenience of your users.

You might try to use this feature to provide an optimizing implementation of the default compilation semantics of a word. For example, by defining:

<div class="example">

``` example
:noname
   foo bar ;
:noname
   POSTPONE foo POSTPONE bar ;
interpret/compile: opti-foobar
```

</div>

as an optimizing version of:

<div class="example">

``` example
: foobar
    foo bar ;
```

</div>

Unfortunately, this does not work correctly with `[compile]`, because `[compile]` assumes that the compilation semantics of all `interpret/compile:` words are non-default. I.e., `[compile] opti-foobar` would compile compilation semantics, whereas `[compile] foobar` would compile interpretation semantics.

<span id="index-state_002dsmart-words-_0028are-a-bad-idea_0029"></span> <span id="state_002dsmartness"></span>

Some people try to use *state-smart* words to emulate the feature provided by `interpret/compile:` (words are state-smart if they check `STATE` during execution). E.g., they would try to code `foobar` like this:

<div class="example">

``` example
: foobar
  STATE @
  IF ( compilation state )
    POSTPONE foo POSTPONE bar
  ELSE
    foo bar
  ENDIF ; immediate
```

</div>

Although this works if `foobar` is only processed by the text interpreter, it does not work in other contexts (like `'` or `POSTPONE`). E.g., `' foobar` will produce an execution token for a state-smart word, not for the interpretation semantics of the original `foobar`; when you execute this execution token (directly with `EXECUTE` or indirectly through `COMPILE,`) in compile state, the result will not be what you expected (i.e., it will not perform `foo bar`). State-smart words are a bad idea. Simply don’t write them[<sup>20</sup>](#FOOT20)\!

<span id="index-defining-words-with-arbitrary-semantics-combinations"></span>

It is also possible to write defining words that define words with arbitrary combinations of interpretation and compilation semantics. In general, they look like this:

<div class="example">

``` example
: def-word
    create-interpret/compile
    code1
interpretation>
    code2
<interpretation
compilation>
    code3
<compilation ;
```

</div>

For a *word* defined with `def-word`, the interpretation semantics are to push the address of the body of *word* and perform *code2*, and the compilation semantics are to push the address of the body of *word* and perform *code3*. E.g., `constant` can also be defined like this (except that the defined constants don’t behave correctly when `[compile]`d):

<div class="example">

``` example
: constant ( n "name" -- )
    create-interpret/compile
    ,
interpretation> ( -- n )
    @
<interpretation
compilation> ( compilation. -- ; run-time. -- n )
    @ postpone literal
<compilation ;
```

</div>

doc-create-interpret/compile doc-interpretation\> doc-\<interpretation doc-compilation\> doc-\<compilation

Words defined with `interpret/compile:` and `create-interpret/compile` have an extended header structure that differs from other words; however, unless you try to access them with plain address arithmetic, you should not notice this. Words for accessing the header structure usually know how to deal with this; e.g., `'` *word* `>body` also gives you the body of a word created with `create-interpret/compile`.

<div class="footnote">

-----

#### Footnotes

### [(20)](#DOCF20)

For a more detailed discussion of this topic, see M. Anton Ertl, [`State`-smartness—Why it is Evil and How to Exorcise it](http://www.complang.tuwien.ac.at/papers/ertl98.ps.gz), EuroForth ’98.

</div>

-----

<div class="header">

Previous: [Interpretation and Compilation Semantics](Interpretation-and-Compilation-Semantics.html#Interpretation-and-Compilation-Semantics), Up: [Interpretation and Compilation Semantics](Interpretation-and-Compilation-Semantics.html#Interpretation-and-Compilation-Semantics)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
