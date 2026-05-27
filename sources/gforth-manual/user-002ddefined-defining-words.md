> Source: https://gforth.org/manual/User_002ddefined-Defining-Words.html

<span id="User_002ddefined-Defining-Words"></span>

<div class="header">

Next: [Deferred Words](Deferred-Words.html#Deferred-Words), Previous: [Supplying names](Supplying-names.html#Supplying-names), Up: [Defining Words](Defining-Words.html#Defining-Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="User_002ddefined-Defining-Words-1"></span>

#### 5.9.9 User-defined Defining Words

<span id="index-user_002ddefined-defining-words"></span> <span id="index-defining-words_002c-user_002ddefined"></span>

You can create a new defining word by wrapping defining-time code around an existing defining word and putting the sequence in a colon definition.

For example, suppose that you have a word `stats` that gathers statistics about colon definitions given the *xt* of the definition, and you want every colon definition in your application to make a call to `stats`. You can define and use a new version of `:` like this:

<div class="example">

``` example
: stats ( xt -- ) DUP ." (Gathering statistics for " . ." )"
  ... ;  \ other code

: my: : latestxt postpone literal ['] stats compile, ;

my: foo + - ;
```

</div>

When `foo` is defined using `my:` these steps occur:

  - `my:` is executed.
  - The `:` within the definition (the one between `my:` and `latestxt`) is executed, and does just what it always does; it parses the input stream for a name, builds a dictionary header for the name `foo` and switches `state` from interpret to compile.
  - The word `latestxt` is executed. It puts the *xt* for the word that is being defined – `foo` – onto the stack.
  - The code that was produced by `postpone literal` is executed; this causes the value on the stack to be compiled as a literal in the code area of `foo`.
  - The code `['] stats` compiles a literal into the definition of `my:`. When `compile,` is executed, that literal – the execution token for `stats` – is layed down in the code area of `foo` , following the literal[<sup>15</sup>](#FOOT15).
  - At this point, the execution of `my:` is complete, and control returns to the text interpreter. The text interpreter is in compile state, so subsequent text `+ -` is compiled into the definition of `foo` and the `;` terminates the definition as always.

You can use `see` to decompile a word that was defined using `my:` and see how it is different from a normal `:` definition. For example:

<div class="example">

``` example
: bar + - ;  \ like foo but using : rather than my:
see bar
: bar
  + - ;
see foo
: foo
  107645672 stats + - ;

\ use ' foo . to show that 107645672 is the xt for foo
```

</div>

You can use techniques like this to make new defining words in terms of *any* existing defining word.

<span id="index-defining-defining-words"></span> <span id="index-CREATE-_002e_002e_002e-DOES_003e"></span>

If you want the words defined with your defining words to behave differently from words defined with standard defining words, you can write your defining word like this:

<div class="example">

``` example
: def-word ( "name" -- )
    CREATE code1
DOES> ( ... -- ... )
    code2 ;

def-word name
```

</div>

<span id="index-child-words"></span>

This fragment defines a *defining word* `def-word` and then executes it. When `def-word` executes, it `CREATE`s a new word, `name`, and executes the code *code1*. The code *code2* is not executed at this time. The word `name` is sometimes called a *child* of `def-word`.

When you execute `name`, the address of the body of `name` is put on the data stack and *code2* is executed (the address of the body of `name` is the address `HERE` returns immediately after the `CREATE`, i.e., the address a `create`d word returns by default).

You can use `def-word` to define a set of child words that behave similarly; they all have a common run-time behaviour determined by *code2*. Typically, the *code1* sequence builds a data area in the body of the child word. The structure of the data is common to all children of `def-word`, but the data values are specific – and private – to each child word. When a child word is executed, the address of its private data area is passed as a parameter on TOS to be used and manipulated[<sup>16</sup>](#FOOT16) by *code2*.

The two fragments of code that make up the defining words act (are executed) at two completely separate times:

  - At *define time*, the defining word executes *code1* to generate a child word
  - At *child execution time*, when a child word is invoked, *code2* is executed, using parameters (data) that are private and specific to the child word.

Another way of understanding the behaviour of `def-word` and `name` is to say that, if you make the following definitions:

<div class="example">

``` example
: def-word1 ( "name" -- )
    CREATE code1 ;

: action1 ( ... -- ... )
    code2 ;

def-word1 name1
```

</div>

Then using `name1 action1` is equivalent to using `name`.

The classic example is that you can define `CONSTANT` in this way:

<div class="example">

``` example
: CONSTANT ( w "name" -- )
    CREATE ,
DOES> ( -- w )
    @ ;
```

</div>

When you create a constant with `5 CONSTANT five`, a set of define-time actions take place; first a new word `five` is created, then the value 5 is laid down in the body of `five` with `,`. When `five` is executed, the address of the body is put on the stack, and `@` retrieves the value 5. The word `five` has no code of its own; it simply contains a data field and a pointer to the code that follows `DOES>` in its defining word. That makes words created in this way very compact.

The final example in this section is intended to remind you that space reserved in `CREATE`d words is *data* space and therefore can be both read and written by a Standard program[<sup>17</sup>](#FOOT17):

<div class="example">

``` example
: foo ( "name" -- )
    CREATE -1 ,
DOES> ( -- )
    @ . ;

foo first-word
foo second-word

123 ' first-word >BODY !
```

</div>

If `first-word` had been a `CREATE`d word, we could simply have executed it to get the address of its data field. However, since it was defined to have `DOES>` actions, its execution semantics are to perform those `DOES>` actions. To get the address of its data field it’s necessary to use `'` to get its xt, then `>BODY` to translate the xt into the address of the data field. When you execute `first-word`, it will display `123`. When you execute `second-word` it will display `-1`.

<span id="index-stack-effect-of-DOES_003e_002dparts"></span> <span id="index-DOES_003e_002dparts_002c-stack-effect"></span>

In the examples above the stack comment after the `DOES>` specifies the stack effect of the defined words, not the stack effect of the following code (the following code expects the address of the body on the top of stack, which is not reflected in the stack comment). This is the convention that I use and recommend (it clashes a bit with using locals declarations for stack effect specification, though).

|                                                                                                                      |  |  |
| :------------------------------------------------------------------------------------------------------------------- |  | :- |
| • [CREATE..DOES\> applications](CREATE_002e_002eDOES_003e-applications.html#CREATE_002e_002eDOES_003e-applications): |  |  |
| • [CREATE..DOES\> details](CREATE_002e_002eDOES_003e-details.html#CREATE_002e_002eDOES_003e-details):                |  |  |
| • [Advanced does\> usage example](Advanced-does_003e-usage-example.html#Advanced-does_003e-usage-example):           |  |  |
| • [Const-does\>](Const_002ddoes_003e.html#Const_002ddoes_003e):                                                      |  |  |

<div class="footnote">

-----

#### Footnotes

### [(15)](#DOCF15)

Strictly speaking, the mechanism that `compile,` uses to convert an *xt* into something in the code area is implementation-dependent. A threaded implementation might spit out the execution token directly whilst another implementation might spit out a native code sequence.

### [(16)](#DOCF16)

It is legitimate both to read and write to this data area.

### [(17)](#DOCF17)

Exercise: use this example as a starting point for your own implementation of `Value` and `TO` – if you get stuck, investigate the behaviour of `'` and `[']`.

</div>

-----

<div class="header">

Next: [Deferred Words](Deferred-Words.html#Deferred-Words), Previous: [Supplying names](Supplying-names.html#Supplying-names), Up: [Defining Words](Defining-Words.html#Defining-Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
