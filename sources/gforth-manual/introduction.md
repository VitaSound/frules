> Source: https://gforth.org/manual/Introduction.html

<span id="Introduction"></span>

<div class="header">

Next: [Words](Words.html#Words), Previous: [Tutorial](Tutorial.html#Tutorial), Up: [Top](index.html#Top)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="An-Introduction-to-Standard-Forth"></span>

## 4 An Introduction to Standard Forth

<span id="index-Forth-_002d-an-introduction"></span>

The difference of this chapter from the Tutorial (see [Tutorial](Tutorial.html#Tutorial)) is that it is slower-paced in its examples, but uses them to dive deep into explaining Forth internals (not covered by the Tutorial). Apart from that, this chapter covers far less material. It is suitable for reading without using a computer.

The primary purpose of this manual is to document Gforth. However, since Forth is not a widely-known language and there is a lack of up-to-date teaching material, it seems worthwhile to provide some introductory material. For other sources of Forth-related information, see [Forth-related information](Forth_002drelated-information.html#Forth_002drelated-information).

The examples in this section should work on any Standard Forth; the output shown was produced using Gforth. Each example attempts to reproduce the exact output that Gforth produces. If you try out the examples (and you should), what you should type is shown <span class="kbd">like this</span> and Gforth’s response is shown `like this`. The single exception is that, where the example shows `RET` it means that you should press the “carriage return” key. Unfortunately, some output formats for this manual cannot show the difference between <span class="kbd">this</span> and `this` which will make trying out the examples harder (but not impossible).

Forth is an unusual language. It provides an interactive development environment which includes both an interpreter and compiler. Forth programming style encourages you to break a problem down into many <span id="index-factoring"></span> small fragments (*factoring*), and then to develop and test each fragment interactively. Forth advocates assert that breaking the edit-compile-test cycle used by conventional programming languages can lead to great productivity improvements.

|                                                                                                                                |  |  |
| :----------------------------------------------------------------------------------------------------------------------------- |  | :- |
| • [Introducing the Text Interpreter](Introducing-the-Text-Interpreter.html#Introducing-the-Text-Interpreter):                  |  |  |
| • [Stacks and Postfix notation](Stacks-and-Postfix-notation.html#Stacks-and-Postfix-notation):                                 |  |  |
| • [Your first definition](Your-first-definition.html#Your-first-definition):                                                   |  |  |
| • [How does that work?](How-does-that-work_003f.html#How-does-that-work_003f):                                                 |  |  |
| • [Forth is written in Forth](Forth-is-written-in-Forth.html#Forth-is-written-in-Forth):                                       |  |  |
| • [Review - elements of a Forth system](Review-_002d-elements-of-a-Forth-system.html#Review-_002d-elements-of-a-Forth-system): |  |  |
| • [Where to go next](Where-to-go-next.html#Where-to-go-next):                                                                  |  |  |
| • [Exercises](Exercises.html#Exercises):                                                                                       |  |  |

-----

<div class="header">

Next: [Words](Words.html#Words), Previous: [Tutorial](Tutorial.html#Tutorial), Up: [Top](index.html#Top)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
