> Source: https://gforth.org/manual/Input-Sources.html

<span id="Input-Sources"></span>

<div class="header">

Next: [Number Conversion](Number-Conversion.html#Number-Conversion), Previous: [The Text Interpreter](The-Text-Interpreter.html#The-Text-Interpreter), Up: [The Text Interpreter](The-Text-Interpreter.html#The-Text-Interpreter)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Input-Sources-1"></span>

#### 5.13.1 Input Sources

<span id="index-input-sources"></span> <span id="index-text-interpreter-_002d-input-sources-1"></span>

By default, the text interpreter processes input from the user input device (the keyboard) when Forth starts up. The text interpreter can process input from any of these sources:

  - The user input device – the keyboard.
  - A file, using the words described in [Forth source files](Forth-source-files.html#Forth-source-files).
  - A block, using the words described in [Blocks](Blocks.html#Blocks).
  - A text string, using `evaluate`.

A program can identify the current input device from the values of `source-id` and `blk`.

<span id="index-source_002did--_002d_002d-0-_007c-_002d1-_007c-fileid--core_002dext_002cfile"></span> <span id="index-source_002did"></span> <span id="index-source_002did-1"></span>

<div class="format">

``` format
source-id       – 0 | -1 | fileid         core-ext,file       “source-i-d”
```

</div>

Return 0 (the input source is the user input device), -1 (the input source is a string being processed by `evaluate`) or a *fileid* (the input source is the file specified by *fileid*).

<span id="index-blk--_002d_002d-addr--block"></span> <span id="index-blk"></span> <span id="index-blk-1"></span>

<div class="format">

``` format
blk       – addr         block       “b-l-k”
```

</div>

`uvar` variable – This cell contains the current block number (or 0 if the current input source is not a block).

<span id="index-save_002dinput--_002d_002d-x1-_002e_002e-xn-n--core_002dext"></span> <span id="index-save_002dinput"></span> <span id="index-save_002dinput-1"></span>

<div class="format">

``` format
save-input       – x1 .. xn n         core-ext       “save-input”
```

</div>

The *n* entries *xn - x1* describe the current state of the input source specification, in some platform-dependent way that can be used by `restore-input`.

<span id="index-restore_002dinput--x1-_002e_002e-xn-n-_002d_002d-flag--core_002dext"></span> <span id="index-restore_002dinput"></span> <span id="index-restore_002dinput-1"></span>

<div class="format">

``` format
restore-input       x1 .. xn n – flag         core-ext       “restore-input”
```

</div>

Attempt to restore the input source specification to the state described by the *n* entries *xn - x1*. *flag* is true if the restore fails. In Gforth with the new input code, it fails only with a flag that can be used to throw again; it is also possible to save and restore between different active input streams. Note that closing the input streams must happen in the reverse order as they have been opened, but in between everything is allowed.

<span id="index-evaluate--_002e_002e_002e-addr-u-_002d_002d-_002e_002e_002e--core_002cblock"></span> <span id="index-evaluate"></span> <span id="index-evaluate-1"></span>

<div class="format">

``` format
evaluate       ... addr u – ...         core,block       “evaluate”
```

</div>

Save the current input source specification. Store `-1` in `source-id` and `0` in `blk`. Set `>IN` to `0` and make the string *c-addr u* the input source and input buffer. Interpret. When the parse area is empty, restore the input source specification.

<span id="index-query--_002d_002d--core_002dext_002dobsolescent"></span> <span id="index-query"></span> <span id="index-query-1"></span>

<div class="format">

``` format
query       –         core-ext-obsolescent       “query”
```

</div>

Make the user input device the input source. Receive input into the Terminal Input Buffer. Set `>IN` to zero. OBSOLESCENT: superceeded by `accept`.

-----

<div class="header">

Next: [Number Conversion](Number-Conversion.html#Number-Conversion), Previous: [The Text Interpreter](The-Text-Interpreter.html#The-Text-Interpreter), Up: [The Text Interpreter](The-Text-Interpreter.html#The-Text-Interpreter)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
