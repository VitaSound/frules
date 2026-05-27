> Source: https://gforth.org/manual/Your-first-definition.html

<span id="Your-first-definition"></span>

<div class="header">

Next: [How does that work?](How-does-that-work_003f.html#How-does-that-work_003f), Previous: [Stacks and Postfix notation](Stacks-and-Postfix-notation.html#Stacks-and-Postfix-notation), Up: [Introduction](Introduction.html#Introduction)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Your-first-Forth-definition"></span>

### 4.3 Your first Forth definition

<span id="index-first-definition"></span>

Until now, the examples we’ve seen have been trivial; we’ve just been using Forth as a bigger-than-pocket calculator. Also, each calculation we’ve shown has been a “one-off” – to repeat it we’d need to type it in again[<sup>6</sup>](#FOOT6) In this section we’ll see how to add new words to Forth’s vocabulary.

The easiest way to create a new word is to use a *colon definition*. We’ll define a few and try them out before worrying too much about how they work. Try typing in these examples; be careful to copy the spaces accurately:

<div class="example">

``` example
: add-two 2 + . ;
: greet ." Hello and welcome" ;
: demo 5 add-two ;
```

</div>

Now try them out:

<div class="example">

``` example
greetRET Hello and welcome  ok
greet greetRET Hello and welcomeHello and welcome  ok
4 add-twoRET 6  ok
demoRET 7  ok
9 greet demo add-twoRET Hello and welcome7 11  ok
```

</div>

The first new thing that we’ve introduced here is the pair of words `:` and `;`. These are used to start and terminate a new definition, respectively. The first word after the `:` is the name for the new definition.

As you can see from the examples, a definition is built up of words that have already been defined; Forth makes no distinction between definitions that existed when you started the system up, and those that you define yourself.

The examples also introduce the words `.` (dot), `."` (dot-quote) and `dup` (dewp). Dot takes the value from the top of the stack and displays it. It’s like `.s` except that it only displays the top item of the stack and it is destructive; after it has executed, the number is no longer on the stack. There is always one space printed after the number, and no spaces before it. Dot-quote defines a string (a sequence of characters) that will be printed when the word is executed. The string can contain any printable characters except `"`. A `"` has a special function; it is not a Forth word but it acts as a delimiter (the way that delimiters work is described in the next section). Finally, `dup` duplicates the value at the top of the stack. Try typing `5 dup .s` to see what it does.

We already know that the text interpreter searches through the dictionary to locate names. If you’ve followed the examples earlier, you will already have a definition called `add-two`. Lets try modifying it by typing in a new definition:

<div class="example">

``` example
: add-two dup . ." + 2 = " 2 + . ;RET redefined add-two  ok
```

</div>

Forth recognised that we were defining a word that already exists, and printed a message to warn us of that fact. Let’s try out the new definition:

<div class="example">

``` example
9 add-twoRET 9 + 2 = 11  ok
```

</div>

All that we’ve actually done here, though, is to create a new definition, with a particular name. The fact that there was already a definition with the same name did not make any difference to the way that the new definition was created (except that Forth printed a warning message). The old definition of add-two still exists (try `demo` again to see that this is true). Any new definition will use the new definition of `add-two`, but old definitions continue to use the version that already existed at the time that they were `compiled`.

Before you go on to the next section, try defining and redefining some words of your own.

<div class="footnote">

-----

#### Footnotes

### [(6)](#DOCF6)

That’s not quite true. If you press the up-arrow key on your keyboard you should be able to scroll back to any earlier command, edit it and re-enter it.

</div>

-----

<div class="header">

Next: [How does that work?](How-does-that-work_003f.html#How-does-that-work_003f), Previous: [Stacks and Postfix notation](Stacks-and-Postfix-notation.html#Stacks-and-Postfix-notation), Up: [Introduction](Introduction.html#Introduction)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
