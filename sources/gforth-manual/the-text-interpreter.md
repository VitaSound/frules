> Source: https://gforth.org/manual/The-Text-Interpreter.html

<span id="The-Text-Interpreter"></span>

<div class="header">

Next: [The Input Stream](The-Input-Stream.html#The-Input-Stream), Previous: [Compiling words](Compiling-words.html#Compiling-words), Up: [Words](Words.html#Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="The-Text-Interpreter-1"></span>

### 5.13 The Text Interpreter

<span id="index-interpreter-_002d-outer"></span> <span id="index-text-interpreter-2"></span> <span id="index-outer-interpreter-2"></span>

The text interpreter[<sup>23</sup>](#FOOT23) is an endless loop that processes input from the current input device. It is also called the outer interpreter, in contrast to the inner interpreter (see [Engine](Engine.html#Engine)) which executes the compiled Forth code on interpretive implementations.

<span id="index-interpret-state"></span> <span id="index-compile-state"></span>

The text interpreter operates in one of two states: *interpret state* and *compile state*. The current state is defined by the aptly-named variable `state`.

This section starts by describing how the text interpreter behaves when it is in interpret state, processing input from the user input device – the keyboard. This is the mode that a Forth system is in after it starts up.

<span id="index-input-buffer"></span> <span id="index-terminal-input-buffer"></span>

The text interpreter works from an area of memory called the *input buffer*[<sup>24</sup>](#FOOT24), which stores your keyboard input when you press the `RET` key. Starting at the beginning of the input buffer, it skips leading spaces (called *delimiters*) then parses a string (a sequence of non-space characters) until it reaches either a space character or the end of the buffer. Having parsed a string, it makes two attempts to process it:

<span id="index-dictionary"></span>

  - It looks for the string in a *dictionary* of definitions. If the string is found, the string names a *definition* (also known as a *word*) and the dictionary search returns information that allows the text interpreter to perform the word’s *interpretation semantics*. In most cases, this simply means that the word will be executed.
  - If the string is not found in the dictionary, the text interpreter attempts to treat it as a number, using the rules described in [Number Conversion](Number-Conversion.html#Number-Conversion). If the string represents a legal number in the current radix, the number is pushed onto a parameter stack (the data stack for integers, the floating-point stack for floating-point numbers).

If both attempts fail, the text interpreter discards the remainder of the input buffer, issues an error message and waits for more input. If one of the attempts succeeds, the text interpreter repeats the parsing process until the whole of the input buffer has been processed, at which point it prints the status message “`  ok `” and waits for more input.

<span id="index-parse-area"></span>

The text interpreter keeps track of its position in the input buffer by updating a variable called `>IN` (pronounced “to-in”). The value of `>IN` starts out as 0, indicating an offset of 0 from the start of the input buffer. The region from offset `>IN @` to the end of the input buffer is called the *parse area*[<sup>25</sup>](#FOOT25). This example shows how `>IN` changes as the text interpreter parses the input buffer:

<div class="example">

``` example
: remaining source >in @ /string
  cr ." ->" type ." <-" ; immediate 

1 2 3 remaining + remaining . 

: foo 1 2 3 remaining swap remaining ;
```

</div>

The result is:

<div class="example">

``` example
->+ remaining .<-
->.<-5  ok

->SWAP remaining ;-<
->;<-  ok
```

</div>

<span id="index-parsing-words-2"></span>

The value of `>IN` can also be modified by a word in the input buffer that is executed by the text interpreter. This means that a word can “trick” the text interpreter into either skipping a section of the input buffer[<sup>26</sup>](#FOOT26) or into parsing a section twice. For example:

<div class="example">

``` example
: lat ." <<foo>>" ;
: flat ." <<bar>>" >IN DUP @ 3 - SWAP ! ;
```

</div>

When `flat` is executed, this output is produced[<sup>27</sup>](#FOOT27):

<div class="example">

``` example
<<bar>><<foo>>
```

</div>

This technique can be used to work around some of the interoperability problems of parsing words. Of course, it’s better to avoid parsing words where possible.

Two important notes about the behaviour of the text interpreter:

  - It processes each input string to completion before parsing additional characters from the input buffer.
  - It treats the input buffer as a read-only region (and so must your code).

When the text interpreter is in compile state, its behaviour changes in these ways:

  - If a parsed string is found in the dictionary, the text interpreter will perform the word’s *compilation semantics*. In most cases, this simply means that the execution semantics of the word will be appended to the current definition.
  - When a number is encountered, it is compiled into the current definition (as a literal) rather than being pushed onto a parameter stack.
  - If an error occurs, `state` is modified to put the text interpreter back into interpret state.
  - Each time a line is entered from the keyboard, Gforth prints “`  compiled `” rather than “ `ok`”.

<span id="index-text-interpreter-_002d-input-sources"></span>

When the text interpreter is using an input device other than the keyboard, its behaviour changes in these ways:

  - When the parse area is empty, the text interpreter attempts to refill the input buffer from the input source. When the input source is exhausted, the input source is set back to the previous input source.
  - It doesn’t print out “`  ok `” or “`  compiled `” messages each time the parse area is emptied.
  - If an error occurs, the input source is set back to the user input device.

You can read about this in more detail in [Input Sources](Input-Sources.html#Input-Sources).

<span id="index-_003ein--_002d_002d-addr--core"></span> <span id="index-_003ein"></span> <span id="index-_003ein-1"></span>

<div class="format">

``` format
>in       – addr         core       “to-in”
```

</div>

`uvar` variable – *a-addr* is the address of a cell containing the char offset from the start of the input buffer to the start of the parse area.

<span id="index-source--_002d_002d-addr-u--core"></span> <span id="index-source"></span> <span id="index-source-1"></span>

<div class="format">

``` format
source       – addr u         core       “source”
```

</div>

Return address *addr* and length *u* of the current input buffer

<span id="index-tib--_002d_002d-addr--core_002dext_002dobsolescent"></span> <span id="index-tib"></span> <span id="index-tib-1"></span>

<div class="format">

``` format
tib       – addr         core-ext-obsolescent       “t-i-b”
```

</div>

<span id="index-_0023tib--_002d_002d-addr--core_002dext_002dobsolescent"></span> <span id="index-_0023tib"></span> <span id="index-_0023tib-1"></span>

<div class="format">

``` format
#tib       – addr         core-ext-obsolescent       “number-t-i-b”
```

</div>

`uvar` variable – *a-addr* is the address of a cell containing the number of characters in the terminal input buffer. OBSOLESCENT: `source` superceeds the function of this word.

|                                                                                               |  |  |
| :-------------------------------------------------------------------------------------------- |  | :- |
| • [Input Sources](Input-Sources.html#Input-Sources):                                          |  |  |
| • [Number Conversion](Number-Conversion.html#Number-Conversion):                              |  |  |
| • [Interpret/Compile states](Interpret_002fCompile-states.html#Interpret_002fCompile-states): |  |  |
| • [Interpreter Directives](Interpreter-Directives.html#Interpreter-Directives):               |  |  |
| • [Recognizers](Recognizers.html#Recognizers):                                                |  |  |

<div class="footnote">

-----

#### Footnotes

### [(23)](#DOCF23)

This is an expanded version of the material in [Introducing the Text Interpreter](Introducing-the-Text-Interpreter.html#Introducing-the-Text-Interpreter).

### [(24)](#DOCF24)

When the text interpreter is processing input from the keyboard, this area of memory is called the *terminal input buffer* (TIB) and is addressed by the (obsolescent) words `TIB` and `#TIB`.

### [(25)](#DOCF25)

In other words, the text interpreter processes the contents of the input buffer by parsing strings from the parse area until the parse area is empty.

### [(26)](#DOCF26)

This is how parsing words work.

### [(27)](#DOCF27)

Exercise for the reader: what would happen if the `3` were replaced with `4`?

</div>

-----

<div class="header">

Next: [The Input Stream](The-Input-Stream.html#The-Input-Stream), Previous: [Compiling words](Compiling-words.html#Compiling-words), Up: [Words](Words.html#Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
