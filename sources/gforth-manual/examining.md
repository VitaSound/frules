> Source: https://gforth.org/manual/Examining.html

<span id="Examining"></span>

<div class="header">

Next: [Forgetting words](Forgetting-words.html#Forgetting-words), Previous: [Programming Tools](Programming-Tools.html#Programming-Tools), Up: [Programming Tools](Programming-Tools.html#Programming-Tools)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Examining-data-and-code"></span>

#### 5.24.1 Examining data and code

<span id="index-examining-data-and-code"></span> <span id="index-data-examination"></span> <span id="index-code-examination"></span>

The following words inspect the stack non-destructively:

<span id="index-_002es--_002d_002d--tools"></span> <span id="index-_002es"></span> <span id="index-_002es-1"></span>

<div class="format">

``` format
.s       –         tools       “dot-s”
```

</div>

Display the number of items on the data stack, followed by a list of the items (but not more than specified by `maxdepth-.s`; TOS is the right-most item.

<span id="index-f_002es--_002d_002d--gforth"></span> <span id="index-f_002es"></span> <span id="index-f_002es-1"></span>

<div class="format">

``` format
f.s       –         gforth       “f-dot-s”
```

</div>

Display the number of items on the floating-point stack, followed by a list of the items (but not more than specified by `maxdepth-.s`; TOS is the right-most item.

<span id="index-maxdepth_002d_002es--_002d_002d-addr--gforth"></span> <span id="index-maxdepth_002d_002es"></span> <span id="index-maxdepth_002d_002es-1"></span>

<div class="format">

``` format
maxdepth-.s       – addr         gforth       “maxdepth-dot-s”
```

</div>

A variable containing 9 by default. `.s` and `f.s` display at most that many stack items.

There is a word `.r` but it does *not* display the return stack\! It is used for formatted numeric output (see [Simple numeric output](Simple-numeric-output.html#Simple-numeric-output)).

<span id="index-depth--_002d_002d-_002bn--core"></span> <span id="index-depth"></span> <span id="index-depth-1"></span>

<div class="format">

``` format
depth       – +n         core       “depth”
```

</div>

`+n` is the number of values that were on the data stack before `+n` itself was placed on the stack.

<span id="index-fdepth--_002d_002d-_002bn--float"></span> <span id="index-fdepth"></span> <span id="index-fdepth-1"></span>

<div class="format">

``` format
fdepth       – +n         float       “f-depth”
```

</div>

*+n* is the current number of (floating-point) values on the floating-point stack.

<span id="index-clearstack--_002e_002e_002e-_002d_002d--gforth"></span> <span id="index-clearstack"></span> <span id="index-clearstack-1"></span>

<div class="format">

``` format
clearstack       ... –         gforth       “clear-stack”
```

</div>

remove and discard all/any items from the data stack.

<span id="index-clearstacks--_002e_002e_002e-_002d_002d--gforth"></span> <span id="index-clearstacks"></span> <span id="index-clearstacks-1"></span>

<div class="format">

``` format
clearstacks       ... –         gforth       “clear-stacks”
```

</div>

empty data and FP stack

The following words inspect memory.

<span id="index-_003f--a_002daddr-_002d_002d--tools"></span> <span id="index-_003f"></span> <span id="index-_003f-1"></span>

<div class="format">

``` format
?       a-addr –         tools       “question”
```

</div>

Display the contents of address `a-addr` in the current number base.

<span id="index-dump--addr-u-_002d_002d--unknown"></span> <span id="index-dump"></span> <span id="index-dump-1"></span>

<div class="format">

``` format
dump       addr u –         unknown       “dump”
```

</div>

And finally, `see` allows to inspect code:

<span id="index-see--_0022_003cspaces_003ename_0022-_002d_002d--tools"></span> <span id="index-see"></span> <span id="index-see-1"></span>

<div class="format">

``` format
see       "<spaces>name" –         tools       “see”
```

</div>

Locate `name` using the current search order. Display the definition of `name`. Since this is achieved by decompiling the definition, the formatting is mechanised and some source information (comments, interpreted sequences within definitions etc.) is lost.

<span id="index-xt_002dsee--xt-_002d_002d--gforth"></span> <span id="index-xt_002dsee"></span> <span id="index-xt_002dsee-1"></span>

<div class="format">

``` format
xt-see       xt –         gforth       “xt-see”
```

</div>

Decompile the definition represented by *xt*.

<span id="index-simple_002dsee--_0022name_0022-_002d_002d--gforth"></span> <span id="index-simple_002dsee"></span> <span id="index-simple_002dsee-1"></span>

<div class="format">

``` format
simple-see       "name" –         gforth       “simple-see”
```

</div>

a simple decompiler that’s closer to `dump` than `see`.

<span id="index-simple_002dsee_002drange--addr1-addr2-_002d_002d--gforth"></span> <span id="index-simple_002dsee_002drange"></span> <span id="index-simple_002dsee_002drange-1"></span>

<div class="format">

``` format
simple-see-range       addr1 addr2 –         gforth       “simple-see-range”
```

</div>

<span id="index-see_002dcode--_0022name_0022-_002d_002d--gforth"></span> <span id="index-see_002dcode"></span> <span id="index-see_002dcode-1"></span>

<div class="format">

``` format
see-code       "name" –         gforth       “see-code”
```

</div>

like `simple-see`, but also shows the dynamic native code for the inlined primitives (except for the last).

<span id="index-see_002dcode_002drange--addr1-addr2-_002d_002d--gforth"></span> <span id="index-see_002dcode_002drange"></span> <span id="index-see_002dcode_002drange-1"></span>

<div class="format">

``` format
see-code-range       addr1 addr2 –         gforth       “see-code-range”
```

</div>

-----

<div class="header">

Next: [Forgetting words](Forgetting-words.html#Forgetting-words), Previous: [Programming Tools](Programming-Tools.html#Programming-Tools), Up: [Programming Tools](Programming-Tools.html#Programming-Tools)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
