> Source: https://gforth.org/manual/Introducing-the-Text-Interpreter.html

<span id="Introducing-the-Text-Interpreter"></span>

<div class="header">

Next: [Stacks and Postfix notation](Stacks-and-Postfix-notation.html#Stacks-and-Postfix-notation), Previous: [Introduction](Introduction.html#Introduction), Up: [Introduction](Introduction.html#Introduction)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Introducing-the-Text-Interpreter-1"></span>

### 4.1 Introducing the Text Interpreter

<span id="index-text-interpreter"></span> <span id="index-outer-interpreter"></span>

When you invoke the Forth image, you will see a startup banner printed and nothing else (if you have Gforth installed on your system, try invoking it now, by typing <span class="kbd">gforth<span class="key">RET</span></span>). Forth is now running its command line interpreter, which is called the *Text Interpreter* (also known as the *Outer Interpreter*). (You will learn a lot about the text interpreter as you read through this chapter, for more detail see [The Text Interpreter](The-Text-Interpreter.html#The-Text-Interpreter)).

Although it’s not obvious, Forth is actually waiting for your input. Type a number and press the `RET` key:

<div class="example">

``` example
45RET  ok
```

</div>

Rather than give you a prompt to invite you to input something, the text interpreter prints a status message *after* it has processed a line of input. The status message in this case (“`  ok `” followed by carriage-return) indicates that the text interpreter was able to process all of your input successfully. Now type something illegal:

<div class="example">

``` example
qwer341RET
*the terminal*:2: Undefined word
>>>qwer341<<<
Backtrace:
$2A95B42A20 throw 
$2A95B57FB8 no.extensions 
```

</div>

The exact text, other than the “Undefined word” may differ slightly on your system, but the effect is the same; when the text interpreter detects an error, it discards any remaining text on a line, resets certain internal state and prints an error message. For a detailed description of error messages see [Error messages](Error-messages.html#Error-messages).

The text interpreter waits for you to press carriage-return, and then processes your input line. Starting at the beginning of the line, it breaks the line into groups of characters separated by spaces. For each group of characters in turn, it makes two attempts to do something:

  - <span id="index-name-dictionary"></span> It tries to treat it as a command. It does this by searching a *name dictionary*. If the group of characters matches an entry in the name dictionary, the name dictionary provides the text interpreter with information that allows the text interpreter to perform some actions. In Forth jargon, we say that the group <span id="index-word"></span> <span id="index-definition"></span> <span id="index-execution-token"></span> <span id="index-xt"></span> of characters names a *word*, that the dictionary search returns an *execution token (xt)* corresponding to the *definition* of the word, and that the text interpreter executes the xt. Often, the terms *word* and *definition* are used interchangeably.
  - If the text interpreter fails to find a match in the name dictionary, it tries to treat the group of characters as a number in the current number base (when you start up Forth, the current number base is base 10). If the group of characters legitimately represents a number, the text interpreter pushes the number onto a stack (we’ll learn more about that in the next section).

If the text interpreter is unable to do either of these things with any group of characters, it discards the group of characters and the rest of the line, then prints an error message. If the text interpreter reaches the end of the line without error, it prints the status message “`  ok `” followed by carriage-return.

This is the simplest command we can give to the text interpreter:

<div class="example">

``` example
RET  ok
```

</div>

The text interpreter did everything we asked it to do (nothing) without an error, so it said that everything is “`  ok `”. Try a slightly longer command:

<div class="example">

``` example
12 dup fred dupRET
*the terminal*:3: Undefined word
12 dup >>>fred<<< dup
Backtrace:
$2A95B42A20 throw 
$2A95B57FB8 no.extensions 
```

</div>

When you press the carriage-return key, the text interpreter starts to work its way along the line:

  - When it gets to the space after the `2`, it takes the group of characters `12` and looks them up in the name dictionary[<sup>5</sup>](#FOOT5). There is no match for this group of characters in the name dictionary, so it tries to treat them as a number. It is able to do this successfully, so it puts the number, 12, “on the stack” (whatever that means).
  - The text interpreter resumes scanning the line and gets the next group of characters, `dup`. It looks it up in the name dictionary and (you’ll have to take my word for this) finds it, and executes the word `dup` (whatever that means).
  - Once again, the text interpreter resumes scanning the line and gets the group of characters `fred`. It looks them up in the name dictionary, but can’t find them. It tries to treat them as a number, but they don’t represent any legal number.

At this point, the text interpreter gives up and prints an error message. The error message shows exactly how far the text interpreter got in processing the line. In particular, it shows that the text interpreter made no attempt to do anything with the final character group, `dup`, even though we have good reason to believe that the text interpreter would have no problem looking that word up and executing it a second time.

<div class="footnote">

-----

#### Footnotes

### [(5)](#DOCF5)

We can’t tell if it found them or not, but assume for now that it did not

</div>

-----

<div class="header">

Next: [Stacks and Postfix notation](Stacks-and-Postfix-notation.html#Stacks-and-Postfix-notation), Previous: [Introduction](Introduction.html#Introduction), Up: [Introduction](Introduction.html#Introduction)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
