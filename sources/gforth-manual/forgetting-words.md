> Source: https://gforth.org/manual/Forgetting-words.html

<span id="Forgetting-words"></span>

<div class="header">

Next: [Debugging](Debugging.html#Debugging), Previous: [Examining](Examining.html#Examining), Up: [Programming Tools](Programming-Tools.html#Programming-Tools)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Forgetting-words-1"></span>

#### 5.24.2 Forgetting words

<span id="index-words_002c-forgetting"></span> <span id="index-forgeting-words"></span>

Forth allows you to forget words (and everything that was alloted in the dictonary after them) in a LIFO manner.

<span id="index-marker--_0022_003cspaces_003e-name_0022-_002d_002d--core_002dext"></span> <span id="index-marker"></span> <span id="index-marker-1"></span>

<div class="format">

``` format
marker       "<spaces> name" –         core-ext       “marker”
```

</div>

Create a definition, *name* (called a *mark*) whose execution semantics are to remove itself and everything defined after it.

The most common use of this feature is during progam development: when you change a source file, forget all the words it defined and load it again (since you also forget everything defined after the source file was loaded, you have to reload that, too). Note that effects like storing to variables and destroyed system words are not undone when you forget words. With a system like Gforth, that is fast enough at starting up and compiling, I find it more convenient to exit and restart Gforth, as this gives me a clean slate.

Here’s an example of using `marker` at the start of a source file that you are debugging; it ensures that you only ever have one copy of the file’s definitions compiled at any time:

<div class="example">

``` example
[IFDEF] my-code
    my-code
[ENDIF]

marker my-code
init-included-files

\ .. definitions start here
\ .
\ .
\ end
```

</div>
