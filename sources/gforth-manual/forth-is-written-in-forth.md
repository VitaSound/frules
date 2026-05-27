> Source: https://gforth.org/manual/Forth-is-written-in-Forth.html

<span id="Forth-is-written-in-Forth"></span>

<div class="header">

Next: [Review - elements of a Forth system](Review-_002d-elements-of-a-Forth-system.html#Review-_002d-elements-of-a-Forth-system), Previous: [How does that work?](How-does-that-work_003f.html#How-does-that-work_003f), Up: [Introduction](Introduction.html#Introduction)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Forth-is-written-in-Forth-1"></span>

### 4.5 Forth is written in Forth

<span id="index-structure-of-Forth-programs"></span>

When you start up a Forth compiler, a large number of definitions already exist. In Forth, you develop a new application using bottom-up programming techniques to create new definitions that are defined in terms of existing definitions. As you create each definition you can test and debug it interactively.

If you have tried out the examples in this section, you will probably have typed them in by hand; when you leave Gforth, your definitions will be lost. You can avoid this by using a text editor to enter Forth source code into a file, and then loading code from the file using `include` (see [Forth source files](Forth-source-files.html#Forth-source-files)). A Forth source file is processed by the text interpreter, just as though you had typed it in by hand[<sup>7</sup>](#FOOT7).

Gforth also supports the traditional Forth alternative to using text files for program entry (see [Blocks](Blocks.html#Blocks)).

In common with many, if not most, Forth compilers, most of Gforth is actually written in Forth. All of the `.fs` files in the installation directory[<sup>8</sup>](#FOOT8) are Forth source files, which you can study to see examples of Forth programming.

Gforth maintains a history file that records every line that you type to the text interpreter. This file is preserved between sessions, and is used to provide a command-line recall facility. If you enter long definitions by hand, you can use a text editor to paste them out of the history file into a Forth source file for reuse at a later time (for more information see [Command-line editing](Command_002dline-editing.html#Command_002dline-editing)).

<div class="footnote">

-----

#### Footnotes

### [(7)](#DOCF7)

Actually, there are some subtle differences – see [The Text Interpreter](The-Text-Interpreter.html#The-Text-Interpreter).

### [(8)](#DOCF8)

For example, `/usr/local/share/gforth...`

</div>

-----

<div class="header">

Next: [Review - elements of a Forth system](Review-_002d-elements-of-a-Forth-system.html#Review-_002d-elements-of-a-Forth-system), Previous: [How does that work?](How-does-that-work_003f.html#How-does-that-work_003f), Up: [Introduction](Introduction.html#Introduction)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
