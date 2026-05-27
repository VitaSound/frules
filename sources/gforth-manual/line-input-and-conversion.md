> Source: https://gforth.org/manual/Line-input-and-conversion.html

<span id="Line-input-and-conversion"></span>

<div class="header">

Next: [Pipes](Pipes.html#Pipes), Previous: [Single-key input](Single_002dkey-input.html#Single_002dkey-input), Up: [Other I/O](Other-I_002fO.html#Other-I_002fO)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Line-input-and-conversion-1"></span>

#### 5.19.8 Line input and conversion

<span id="index-line-input-from-terminal"></span> <span id="index-input_002c-linewise-from-terminal"></span> <span id="index-convertin-strings-to-numbers"></span> <span id="index-I_002fO-_002d-see-input"></span>

For ways of storing character strings in memory see [String Formats](String-Formats.html#String-Formats).

Words for inputting one line from the keyboard:

<span id="index-accept--c_002daddr-_002bn1-_002d_002d-_002bn2--core"></span> <span id="index-accept"></span> <span id="index-accept-1"></span>

<div class="format">

``` format
accept       c-addr +n1 – +n2         core       “accept”
```

</div>

Get a string of up to `n1` characters from the user input device and store it at `c-addr`. `n2` is the length of the received string. The user indicates the end by pressing `RET`. Gforth supports all the editing functions available on the Forth command line (including history and word completion) in `accept`.

<span id="index-edit_002dline--c_002daddr-n1-n2-_002d_002d-n3--gforth"></span> <span id="index-edit_002dline"></span> <span id="index-edit_002dline-1"></span>

<div class="format">

``` format
edit-line       c-addr n1 n2 – n3         gforth       “edit-line”
```

</div>

edit the string with length `n2` in the buffer `c-addr n1`, like `accept`.

Conversion words:

<span id="index-s_003enumber_003f--addr-u-_002d_002d-d-f--gforth"></span> <span id="index-s_003enumber_003f"></span> <span id="index-s_003enumber_003f-1"></span>

<div class="format">

``` format
s>number?       addr u – d f         gforth       “s>number?”
```

</div>

converts string addr u into d, flag indicates success

<span id="index-s_003eunumber_003f--c_002daddr-u-_002d_002d-ud-flag--gforth"></span> <span id="index-s_003eunumber_003f"></span> <span id="index-s_003eunumber_003f-1"></span>

<div class="format">

``` format
s>unumber?       c-addr u – ud flag         gforth       “s>unumber?”
```

</div>

converts string c-addr u into ud, flag indicates success

<span id="index-_003enumber--ud1-c_002daddr1-u1-_002d_002d-ud2-c_002daddr2-u2--core"></span> <span id="index-_003enumber"></span> <span id="index-_003enumber-1"></span>

<div class="format">

``` format
>number       ud1 c-addr1 u1 – ud2 c-addr2 u2         core       “to-number”
```

</div>

Attempt to convert the character string `c-addr1 u1` to an unsigned number in the current number base. The double `ud1` accumulates the result of the conversion to form `ud2`. Conversion continues, left-to-right, until the whole string is converted or a character that is not convertable in the current number base is encountered (including + or -). For each convertable character, `ud1` is first multiplied by the value in `BASE` and then incremented by the value represented by the character. `c-addr2` is the location of the first unconverted character (past the end of the string if the whole string was converted). `u2` is the number of unconverted characters in the string. Overflow is not detected.

<span id="index-_003efloat--c_002daddr-u-_002d_002d-f_003a_002e_002e_002e-flag--float"></span> <span id="index-_003efloat"></span> <span id="index-_003efloat-1"></span>

<div class="format">

``` format
>float       c-addr u – f:... flag        float       “to-float”
```

</div>

Actual stack effect: ( c\_addr u – r t | f ). Attempt to convert the character string *c-addr u* to internal floating-point representation. If the string represents a valid floating-point number *r* is placed on the floating-point stack and *flag* is true. Otherwise, *flag* is false. A string of blanks is a special case and represents the floating-point number 0.

<span id="index-_003efloat1--c_002daddr-u-c-_002d_002d-f_003a_002e_002e_002e-flag--gforth"></span> <span id="index-_003efloat1"></span> <span id="index-_003efloat1-1"></span>

<div class="format">

``` format
>float1       c-addr u c – f:... flag        gforth       “to-float1”
```

</div>

Actual stack effect: ( c\_addr u c – r t | f ). Attempt to convert the character string *c-addr u* to internal floating-point representation. If the string represents a valid floating-point number *r* is placed on the floating-point stack and *flag* is true. Otherwise, *flag* is false. A string of blanks is a special case and represents the floating-point number 0.

Obsolescent input and conversion words:

<span id="index-convert--ud1-c_002daddr1-_002d_002d-ud2-c_002daddr2--core_002dext_002dobsolescent"></span> <span id="index-convert"></span> <span id="index-convert-1"></span>

<div class="format">

``` format
convert       ud1 c-addr1 – ud2 c-addr2         core-ext-obsolescent       “convert”
```

</div>

Obsolescent: superseded by `>number`.

<span id="index-expect--c_002daddr-_002bn-_002d_002d--core_002dext_002dobsolescent"></span> <span id="index-expect"></span> <span id="index-expect-1"></span>

<div class="format">

``` format
expect       c-addr +n –         core-ext-obsolescent       “expect”
```

</div>

Receive a string of at most *+n* characters, and store it in memory starting at *c-addr*. The string is displayed. Input terminates when the \<return\> key is pressed or *+n* characters have been received. The normal Gforth line editing capabilites are available. The length of the string is stored in `span`; it does not include the \<return\> character. OBSOLESCENT: superceeded by `accept`.

<span id="index-span--_002d_002d-c_002daddr--core_002dext_002dobsolescent"></span> <span id="index-span"></span> <span id="index-span-1"></span>

<div class="format">

``` format
span       – c-addr         core-ext-obsolescent       “span”
```

</div>

`Variable` – *c-addr* is the address of a cell that stores the length of the last string received by `expect`. OBSOLESCENT.

-----

<div class="header">

Next: [Pipes](Pipes.html#Pipes), Previous: [Single-key input](Single_002dkey-input.html#Single_002dkey-input), Up: [Other I/O](Other-I_002fO.html#Other-I_002fO)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
