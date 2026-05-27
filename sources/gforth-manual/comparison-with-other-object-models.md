> Source: https://gforth.org/manual/Comparison-with-other-object-models.html

<span id="Comparison-with-other-object-models"></span>

<div class="header">

Previous: [Mini-OOF](Mini_002dOOF.html#Mini_002dOOF), Up: [Object-oriented Forth](Object_002doriented-Forth.html#Object_002doriented-Forth)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Comparison-with-other-object-models-1"></span>

#### 5.23.6 Comparison with other object models

<span id="index-comparison-of-object-models"></span> <span id="index-object-models_002c-comparison"></span>

Many object-oriented Forth extensions have been proposed (A survey of object-oriented Forths (SIGPLAN Notices, April 1996) by Bradford J. Rodriguez and W. F. S. Poehlman lists 17). This section discusses the relation of the object models described here to two well-known and two closely-related (by the use of method maps) models. Andras Zsoter helped us with this section.

<span id="index-Neon-model"></span>

The most popular model currently seems to be the Neon model (see Object-oriented programming in ANS Forth (Forth Dimensions, March 1997) by Andrew McKewan) but this model has a number of limitations [<sup>35</sup>](#FOOT35):

  - It uses a `selector object` syntax, which makes it unnatural to pass objects on the stack.
  - It requires that the selector parses the input stream (at compile time); this leads to reduced extensibility and to bugs that are hard to find.
  - It allows using every selector on every object; this eliminates the need for interfaces, but makes it harder to create efficient implementations.

<span id="index-Pountain_0027s-object_002doriented-model"></span>

Another well-known publication is Object-Oriented Forth (Academic Press, London, 1987) by Dick Pountain. However, it is not really about object-oriented programming, because it hardly deals with late binding. Instead, it focuses on features like information hiding and overloading that are characteristic of modular languages like Ada (83).

<span id="index-Zsoter_0027s-object_002doriented-model"></span>

In [Does late binding have to be slow?](http://www.forth.org/oopf.html) (Forth Dimensions 18(1) 1996, pages 31-35) Andras Zsoter describes a model that makes heavy use of an active object (like `this` in `objects.fs`): The active object is not only used for accessing all fields, but also specifies the receiving object of every selector invocation; you have to change the active object explicitly with `{ ... }`, whereas in `objects.fs` it changes more or less implicitly at `m: ... ;m`. Such a change at the method entry point is unnecessary with Zsoter’s model, because the receiving object is the active object already. On the other hand, the explicit change is absolutely necessary in that model, because otherwise no one could ever change the active object. An Standard Forth implementation of this model is available through <http://www.forth.org/oopf.html>.

<span id="index-oof_002efs_002c-differences-to-other-models"></span>

The `oof.fs` model combines information hiding and overloading resolution (by keeping names in various word lists) with object-oriented programming. It sets the active object implicitly on method entry, but also allows explicit changing (with `>o...o>` or with `with...endwith`). It uses parsing and state-smart objects and classes for resolving overloading and for early binding: the object or class parses the selector and determines the method from this. If the selector is not parsed by an object or class, it performs a call to the selector for the active object (late binding), like Zsoter’s model. Fields are always accessed through the active object. The big disadvantage of this model is the parsing and the state-smartness, which reduces extensibility and increases the opportunities for subtle bugs; essentially, you are only safe if you never tick or `postpone` an object or class (Bernd disagrees, but I (Anton) am not convinced).

<span id="index-mini_002doof_002efs_002c-differences-to-other-models"></span>

The `mini-oof.fs` model is quite similar to a very stripped-down version of the `objects.fs` model, but syntactically it is a mixture of the `objects.fs` and `oof.fs` models.

<div class="footnote">

-----

#### Footnotes

### [(35)](#DOCF35)

A longer version of this critique can be found in On Standardizing Object-Oriented Forth Extensions (Forth Dimensions, May 1997) by Anton Ertl.

</div>

-----

<div class="header">

Previous: [Mini-OOF](Mini_002dOOF.html#Mini_002dOOF), Up: [Object-oriented Forth](Object_002doriented-Forth.html#Object_002doriented-Forth)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
