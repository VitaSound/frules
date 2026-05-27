> Source: https://gforth.org/manual/Defining-Words-Tutorial.html

<span id="Defining-Words-Tutorial"></span>

<div class="header">

Next: [Arrays and Records Tutorial](Arrays-and-Records-Tutorial.html#Arrays-and-Records-Tutorial), Previous: [Exceptions Tutorial](Exceptions-Tutorial.html#Exceptions-Tutorial), Up: [Tutorial](Tutorial.html#Tutorial)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Defining-Words-1"></span>

### 3.31 Defining Words

<span id="index-defining-words-tutorial"></span> <span id="index-does_003e-tutorial"></span> <span id="index-create_002e_002e_002edoes_003e-tutorial"></span>

`:`, `create`, and `variable` are definition words: They define other words. `Constant` is another definition word:

<div class="example">

``` example
5 constant foo
foo .
```

</div>

You can also use the prefixes `2` (double-cell) and `f` (floating point) with `variable` and `constant`.

You can also define your own defining words. E.g.:

<div class="example">

``` example
: variable ( "name" -- )
  create 0 , ;
```

</div>

You can also define defining words that create words that do something other than just producing their address:

<div class="example">

``` example
: constant ( n "name" -- )
  create ,
does> ( -- n )
  ( addr ) @ ;

5 constant foo
foo .
```

</div>

The definition of `constant` above ends at the `does>`; i.e., `does>` replaces `;`, but it also does something else: It changes the last defined word such that it pushes the address of the body of the word and then performs the code after the `does>` whenever it is called.

In the example above, `constant` uses `,` to store 5 into the body of `foo`. When `foo` executes, it pushes the address of the body onto the stack, then (in the code after the `does>`) fetches the 5 from there.

The stack comment near the `does>` reflects the stack effect of the defined word, not the stack effect of the code after the `does>` (the difference is that the code expects the address of the body that the stack comment does not show).

You can use these definition words to do factoring in cases that involve (other) definition words. E.g., a field offset is always added to an address. Instead of defining

<div class="example">

``` example
2 cells constant offset-field1
```

</div>

and using this like

<div class="example">

``` example
( addr ) offset-field1 +
```

</div>

you can define a definition word

<div class="example">

``` example
: simple-field ( n "name" -- )
  create ,
does> ( n1 -- n1+n )
  ( addr ) @ + ;
```

</div>

Definition and use of field offsets now look like this:

<div class="example">

``` example
2 cells simple-field field1
create mystruct 4 cells allot
mystruct .s field1 .s drop
```

</div>

If you want to do something with the word without performing the code after the `does>`, you can access the body of a `create`d word with `>body ( xt -- addr )`:

<div class="example">

``` example
: value ( n "name" -- )
  create ,
does> ( -- n1 )
  @ ;
: to ( n "name" -- )
  ' >body ! ;

5 value foo
foo .
7 to foo
foo .
```

</div>

> **Assignment:** Define `defer ( "name" -- )`, which creates a word that stores an XT (at the start the XT of `abort`), and upon execution `execute`s the XT. Define `is ( xt "name" -- )` that stores `xt` into `name`, a word defined with `defer`. Indirect recursion is one application of `defer`.

Reference: [User-defined Defining Words](User_002ddefined-Defining-Words.html#User_002ddefined-Defining-Words).

-----

<div class="header">

Next: [Arrays and Records Tutorial](Arrays-and-Records-Tutorial.html#Arrays-and-Records-Tutorial), Previous: [Exceptions Tutorial](Exceptions-Tutorial.html#Exceptions-Tutorial), Up: [Tutorial](Tutorial.html#Tutorial)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
