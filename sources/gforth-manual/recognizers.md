> Source: https://gforth.org/manual/Recognizers.html

<span id="Recognizers"></span>

<div class="header">

Previous: [Interpreter Directives](Interpreter-Directives.html#Interpreter-Directives), Up: [The Text Interpreter](The-Text-Interpreter.html#The-Text-Interpreter)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Recognizers-1"></span>

#### 5.13.5 Recognizers

<span id="index-recongizers"></span>

The standard Forth text interpreter recognizes the following types of tokens: words in the dictionary, integer numbers, and floating point numbers. Defining new types of tokens isn’t yet standardized. Gforth provides recognizers to make the text interpreter extensible as well.

Recognizers take a string and return some data and a “table” for interpreting that data. Gforth implements that table as xt (which means any xt is a valid result of a recognizer), but other Forth systems can implement it as actual table, with three xts inside. The first xt is the interpretation/run-time xt, it performs the interpretation semantics on the data (usually, this means it just leaves the data on the stack). The second xt performs the compilation semantics, it gets the data and the run-time semantics xt. The third xt perfoms the postpone semantics, it also gets the data and the run-time semantics xt. You can use `post,` to postpone the run-time xt.

Recognizers are organized as stack, so you can arrange the sequence of recognizers in the same way as the vocabulary stack.

doc-r:fail doc-rec:word doc-rec:num doc-rec:float <span id="index-get_002drecognizers--_002d_002d-xt1-_002e_002e-xtn-n--unknown"></span> <span id="index-get_002drecognizers"></span> <span id="index-get_002drecognizers-1"></span>

<div class="format">

``` format
get-recognizers       – xt1 .. xtn n         unknown       “get-recognizers”
```

</div>

push the content on the recognizer stack

<span id="index-set_002drecognizers--xt1-_002e_002e-xtn-n--unknown"></span> <span id="index-set_002drecognizers"></span> <span id="index-set_002drecognizers-1"></span>

<div class="format">

``` format
set-recognizers       xt1 .. xtn n         unknown       “set-recognizers”
```

</div>

set the recognizer stack from content on the stack

doc-do-recognizer doc-recognizer
