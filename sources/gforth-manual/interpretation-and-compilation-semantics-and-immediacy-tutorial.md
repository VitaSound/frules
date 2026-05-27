> Source: https://gforth.org/manual/Interpretation-and-Compilation-Semantics-and-Immediacy-Tutorial.html

<span id="Interpretation-and-Compilation-Semantics-and-Immediacy-Tutorial"></span>

<div class="header">

Next: [Execution Tokens Tutorial](Execution-Tokens-Tutorial.html#Execution-Tokens-Tutorial), Previous: [Files Tutorial](Files-Tutorial.html#Files-Tutorial), Up: [Tutorial](Tutorial.html#Tutorial)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Interpretation-and-Compilation-Semantics-and-Immediacy"></span>

### 3.28 Interpretation and Compilation Semantics and Immediacy

<span id="index-semantics-tutorial"></span> <span id="index-interpretation-semantics-tutorial"></span> <span id="index-compilation-semantics-tutorial"></span> <span id="index-immediate_002c-tutorial"></span>

When a word is compiled, it behaves differently from being interpreted. E.g., consider `+`:

<div class="example">

``` example
1 2 + .
: foo + ;
```

</div>

These two behaviours are known as compilation and interpretation semantics. For normal words (e.g., `+`), the compilation semantics is to append the interpretation semantics to the currently defined word (`foo` in the example above). I.e., when `foo` is executed later, the interpretation semantics of `+` (i.e., adding two numbers) will be performed.

However, there are words with non-default compilation semantics, e.g., the control-flow words like `if`. You can use `immediate` to change the compilation semantics of the last defined word to be equal to the interpretation semantics:

<div class="example">

``` example
: [FOO] ( -- )
 5 . ; immediate

[FOO]
: bar ( -- )
  [FOO] ;
bar
see bar
```

</div>

Two conventions to mark words with non-default compilation semantics are names with brackets (more frequently used) and to write them all in upper case (less frequently used).

For some words, such as `if`, using their interpretation semantics is usually a mistake, so we mark them as `compile-only`, and you get a warning when you interpret them.

<div class="example">

``` example
: flip ( -- )
 6 . ; compile-only \ but not immediate
flip

: flop ( -- )
 flip ;
flop
```

</div>

In this example, first the interpretation semantics of `flip` is used (and you get a warning); the second use of `flip` uses the compilation semantics (and you get no warning). You can also see in this example that compile-only is a property that is evaluated at text interpretation time, not at run-time.

The text interpreter has two states: in interpret state, it performs the interpretation semantics of words it encounters; in compile state, it performs the compilation semantics of these words.

Among other things, `:` switches into compile state, and `;` switches back to interpret state. They contain the factors `]` (switch to compile state) and `[` (switch to interpret state), that do nothing but switch the state.

<div class="example">

``` example
: xxx ( -- )
  [ 5 . ]
;

xxx
see xxx
```

</div>

These brackets are also the source of the naming convention mentioned above.

Reference: [Interpretation and Compilation Semantics](Interpretation-and-Compilation-Semantics.html#Interpretation-and-Compilation-Semantics).

-----

<div class="header">

Next: [Execution Tokens Tutorial](Execution-Tokens-Tutorial.html#Execution-Tokens-Tutorial), Previous: [Files Tutorial](Files-Tutorial.html#Files-Tutorial), Up: [Tutorial](Tutorial.html#Tutorial)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
