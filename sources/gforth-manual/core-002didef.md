> Source: https://gforth.org/manual/core_002didef.html

<span id="core_002didef"></span>

<div class="header">

Next: [core-ambcond](core_002dambcond.html#core_002dambcond), Previous: [The Core Words](The-Core-Words.html#The-Core-Words), Up: [The Core Words](The-Core-Words.html#The-Core-Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Implementation-Defined-Options"></span>

#### 8.1.1 Implementation Defined Options

<span id="index-core-words_002c-implementation_002ddefined-options"></span> <span id="index-implementation_002ddefined-options_002c-core-words"></span>

  - *(Cell) aligned addresses:*  
    <span id="index-cell_002daligned-addresses"></span> <span id="index-aligned-addresses"></span>
    
    processor-dependent. Gforth’s alignment words perform natural alignment (e.g., an address aligned for a datum of size 8 is divisible by 8). Unaligned accesses usually result in a `-23 THROW`.

  - *`EMIT` and non-graphic characters:*  
    <span id="index-EMIT-and-non_002dgraphic-characters"></span> <span id="index-non_002dgraphic-characters-and-EMIT"></span>
    
    The character is output using the C library function (actually, macro) `putc`.

  - *character editing of `ACCEPT` and `EXPECT`:*  
    <span id="index-character-editing-of-ACCEPT-and-EXPECT"></span> <span id="index-editing-in-ACCEPT-and-EXPECT"></span> <span id="index-ACCEPT_002c-editing"></span> <span id="index-EXPECT_002c-editing"></span>
    
    This is modeled on the GNU readline library (see [Command Line Editing](http://cnswww.cns.cwru.edu/php/chet/readline/readline.html#Readline-Interaction) in The GNU Readline Library) with Emacs-like key bindings. <span class="kbd">Tab</span> deviates a little by producing a full word completion every time you type it (instead of producing the common prefix of all completions). See [Command-line editing](Command_002dline-editing.html#Command_002dline-editing).

  - *character set:*  
    <span id="index-character-set"></span>
    
    The character set of your computer and display device. Gforth is 8-bit-clean (but some other component in your system may make trouble).

  - *Character-aligned address requirements:*  
    <span id="index-character_002daligned-address-requirements"></span>
    
    installation-dependent. Currently a character is represented by a C `unsigned char`; in the future we might switch to `wchar_t` (Comments on that requested).

  - *character-set extensions and matching of names:*  
    <span id="index-character_002dset-extensions-and-matching-of-names"></span> <span id="index-case_002dsensitivity-for-name-lookup"></span> <span id="index-name-lookup_002c-case_002dsensitivity"></span> <span id="index-locale-and-case_002dsensitivity"></span>
    
    Any character except the ASCII NUL character can be used in a name. Matching is case-insensitive (except in `TABLE`s). The matching is performed using the C library function `strncasecmp`, whose function is probably influenced by the locale. E.g., the `C` locale does not know about accents and umlauts, so they are matched case-sensitively in that locale. For portability reasons it is best to write programs such that they work in the `C` locale. Then one can use libraries written by a Polish programmer (who might use words containing ISO Latin-2 encoded characters) and by a French programmer (ISO Latin-1) in the same program (of course, `WORDS` will produce funny results for some of the words (which ones, depends on the font you are using)). Also, the locale you prefer may not be available in other operating systems. Hopefully, Unicode will solve these problems one day.

  - *conditions under which control characters match a space delimiter:*  
    <span id="index-space-delimiters"></span> <span id="index-control-characters-as-delimiters"></span>
    
    If `word` is called with the space character as a delimiter, all white-space characters (as identified by the C macro `isspace()`) are delimiters. `Parse`, on the other hand, treats space like other delimiters. `Parse-name`, which is used by the outer interpreter (aka text interpreter) by default, treats all white-space characters as delimiters.

  - *format of the control-flow stack:*  
    <span id="index-control_002dflow-stack_002c-format"></span>
    
    The data stack is used as control-flow stack. The size of a control-flow stack item in cells is given by the constant `cs-item-size`. At the time of this writing, an item consists of a (pointer to a) locals list (third), an address in the code (second), and a tag for identifying the item (TOS). The following tags are used: `defstart`, `live-orig`, `dead-orig`, `dest`, `do-dest`, `scopestart`.

  - *conversion of digits \> 35*  
    <span id="index-digits-_003e-35"></span>
    
    The characters `[\]^_'` are the digits with the decimal value 36-41. There is no way to input many of the larger digits.

  - *display after input terminates in `ACCEPT` and `EXPECT`:*  
    <span id="index-EXPECT_002c-display-after-end-of-input"></span> <span id="index-ACCEPT_002c-display-after-end-of-input"></span>
    
    The cursor is moved to the end of the entered string. If the input is terminated using the <span class="kbd">Return</span> key, a space is typed.

  - *exception abort sequence of `ABORT"`:*  
    <span id="index-exception-abort-sequence-of-ABORT_0022"></span> <span id="index-ABORT_0022_002c-exception-abort-sequence"></span>
    
    The error string is stored into the variable `"error` and a `-2 throw` is performed.

  - *input line terminator:*  
    <span id="index-input-line-terminator"></span> <span id="index-line-terminator-on-input"></span> <span id="index-newline-character-on-input"></span>
    
    For interactive input, <span class="kbd">C-m</span> (CR) and <span class="kbd">C-j</span> (LF) terminate lines. One of these characters is typically produced when you type the <span class="kbd">Enter</span> or <span class="kbd">Return</span> key.

  - *maximum size of a counted string:*  
    <span id="index-maximum-size-of-a-counted-string"></span> <span id="index-counted-string_002c-maximum-size"></span>
    
    `s" /counted-string" environment? drop .`. Currently 255 characters on all platforms, but this may change.

  - *maximum size of a parsed string:*  
    <span id="index-maximum-size-of-a-parsed-string"></span> <span id="index-parsed-string_002c-maximum-size"></span>
    
    Given by the constant `/line`. Currently 255 characters.

  - *maximum size of a definition name, in characters:*  
    <span id="index-maximum-size-of-a-definition-name_002c-in-characters"></span> <span id="index-name_002c-maximum-length"></span>
    
    MAXU/8

  - *maximum string length for `ENVIRONMENT?`, in characters:*  
    <span id="index-maximum-string-length-for-ENVIRONMENT_003f_002c-in-characters"></span> <span id="index-ENVIRONMENT_003f-string-length_002c-maximum"></span>
    
    MAXU/8

  - *method of selecting the user input device:*  
    <span id="index-user-input-device_002c-method-of-selecting"></span>
    
    The user input device is the standard input. There is currently no way to change it from within Gforth. However, the input can typically be redirected in the command line that starts Gforth.

  - *method of selecting the user output device:*  
    <span id="index-user-output-device_002c-method-of-selecting"></span>
    
    `EMIT` and `TYPE` output to the file-id stored in the value `outfile-id` (`stdout` by default). Gforth uses unbuffered output when the user output device is a terminal, otherwise the output is buffered.

  - *methods of dictionary compilation:*  
    What are we expected to document here?

  - *number of bits in one address unit:*  
    <span id="index-number-of-bits-in-one-address-unit"></span> <span id="index-address-unit_002c-size-in-bits"></span>
    
    `s" address-units-bits" environment? drop .`. 8 in all current platforms.

  - *number representation and arithmetic:*  
    <span id="index-number-representation-and-arithmetic"></span>
    
    Processor-dependent. Binary two’s complement on all current platforms.

  - *ranges for integer types:*  
    <span id="index-ranges-for-integer-types"></span> <span id="index-integer-types_002c-ranges"></span>
    
    Installation-dependent. Make environmental queries for `MAX-N`, `MAX-U`, `MAX-D` and `MAX-UD`. The lower bounds for unsigned (and positive) types is 0. The lower bound for signed types on two’s complement and one’s complement machines machines can be computed by adding 1 to the upper bound.

  - *read-only data space regions:*  
    <span id="index-read_002donly-data-space-regions"></span> <span id="index-data_002dspace_002c-read_002donly-regions"></span>
    
    The whole Forth data space is writable.

  - *size of buffer at `WORD`:*  
    <span id="index-size-of-buffer-at-WORD"></span> <span id="index-WORD-buffer-size"></span>
    
    `PAD HERE - .`. 104 characters on 32-bit machines. The buffer is shared with the pictured numeric output string. If overwriting `PAD` is acceptable, it is as large as the remaining dictionary space, although only as much can be sensibly used as fits in a counted string.

  - *size of one cell in address units:*  
    <span id="index-cell-size"></span>
    
    `1 cells .`.

  - *size of one character in address units:*  
    <span id="index-char-size"></span>
    
    `1 chars .`. 1 on all current platforms.

  - *size of the keyboard terminal buffer:*  
    <span id="index-size-of-the-keyboard-terminal-buffer"></span> <span id="index-terminal-buffer_002c-size"></span>
    
    Varies. You can determine the size at a specific time using `lp@ tib - .`. It is shared with the locals stack and TIBs of files that include the current file. You can change the amount of space for TIBs and locals stack at Gforth startup with the command line option `-l`.

  - *size of the pictured numeric output buffer:*  
    <span id="index-size-of-the-pictured-numeric-output-buffer"></span> <span id="index-pictured-numeric-output-buffer_002c-size"></span>
    
    `PAD HERE - .`. 104 characters on 32-bit machines. The buffer is shared with `WORD`.

  - *size of the scratch area returned by `PAD`:*  
    <span id="index-size-of-the-scratch-area-returned-by-PAD"></span> <span id="index-PAD-size"></span>
    
    The remainder of dictionary space. `unused pad here - - .`.

  - *system case-sensitivity characteristics:*  
    <span id="index-case_002dsensitivity-characteristics"></span>
    
    Dictionary searches are case-insensitive (except in `TABLE`s). However, as explained above under *character-set extensions*, the matching for non-ASCII characters is determined by the locale you are using. In the default `C` locale all non-ASCII characters are matched case-sensitively.

  - *system prompt:*  
    <span id="index-system-prompt"></span> <span id="index-prompt"></span>
    
    `  ok ` in interpret state, `  compiled ` in compile state.

  - *division rounding:*  
    <span id="index-division-rounding"></span>
    
    The ordinary division words `/ mod /mod */ */mod` perform floored division (with the default installation of Gforth). You can check this with `s" floored" environment? drop .`. If you write programs that need a specific division rounding, best use `fm/mod` or `sm/rem` for portability.

  - *values of `STATE` when true:*  
    <span id="index-STATE-values"></span>
    
    \-1.

  - *values returned after arithmetic overflow:*  
    On two’s complement machines, arithmetic is performed modulo 2\*\*bits-per-cell for single arithmetic and 4\*\*bits-per-cell for double arithmetic (with appropriate mapping for signed types). Division by zero typically results in a `-55 throw` (Floating-point unidentified fault) or `-10 throw` (divide by zero). Integer division overflow can result in these throws, or in `-11 throw`; in `gforth-fast` division overflow and divide by zero may also result in returning bogus results without producing an exception.

  - *whether the current definition can be found after `DOES>`:*  
    <span id="index-DOES_003e_002c-visibility-of-current-definition"></span>
    
    No.

-----

<div class="header">

Next: [core-ambcond](core_002dambcond.html#core_002dambcond), Previous: [The Core Words](The-Core-Words.html#The-Core-Words), Up: [The Core Words](The-Core-Words.html#The-Core-Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
