> Source: https://gforth.org/manual/Standard-Forth-locals.html

<span id="Standard-Forth-locals"></span>

<div class="header">

Previous: [Gforth locals](Gforth-locals.html#Gforth-locals), Up: [Locals](Locals.html#Locals)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Standard-Forth-locals-1"></span>

#### 5.21.2 Standard Forth locals

<span id="index-locals_002c-Standard-Forth-style"></span>

\!\!The Standard Forth locals wordset does not define a syntax for locals, but words that make it possible to define various syntaxes. One of the possible syntaxes is a subset of the syntax we used in the Gforth locals wordset, i.e.:

<div class="example">

``` example
{ local1 local2 ... -- comment }
```

</div>

or

<div class="example">

``` example
{ local1 local2 ... }
```

</div>

The order of the locals corresponds to the order in a stack comment. The restrictions are:

  - Locals can only be cell-sized values (no type specifiers are allowed).
  - Locals can be defined only outside control structures.
  - Locals can interfere with explicit usage of the return stack. For the exact (and long) rules, see the standard. If you don’t use return stack accessing words in a definition using locals, you will be all right. The purpose of this rule is to make locals implementation on the return stack easier.
  - The whole definition must be in one line.

Locals defined in Standard Forth behave like `VALUE`s (see [Values](Values.html#Values)). I.e., they are initialized from the stack. Using their name produces their value. Their value can be changed using `TO`.

Since the syntax above is supported by Gforth directly, you need not do anything to use it. If you want to port a program using this syntax to another ANS Forth system, use `compat/anslocal.fs` to implement the syntax on the other system.

Note that a syntax shown in the standard, section A.13 looks similar, but is quite different in having the order of locals reversed. Beware\!

The Standard Forth locals wordset itself consists of one word:

<span id="index-_0028local_0029--addr-u-_002d_002d--local"></span> <span id="index-_0028local_0029"></span> <span id="index-_0028local_0029-1"></span>

<div class="format">

``` format
(local)       addr u –         local       “paren-local-paren”
```

</div>

The ANS Forth locals extension wordset defines a syntax using `locals|`, but it is so awful that we strongly recommend not to use it. We have implemented this syntax to make porting to Gforth easy, but do not document it here. The problem with this syntax is that the locals are defined in an order reversed with respect to the standard stack comment notation, making programs harder to read, and easier to misread and miswrite. The only merit of this syntax is that it is easy to implement using the ANS Forth locals wordset.

-----

<div class="header">

Previous: [Gforth locals](Gforth-locals.html#Gforth-locals), Up: [Locals](Locals.html#Locals)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
