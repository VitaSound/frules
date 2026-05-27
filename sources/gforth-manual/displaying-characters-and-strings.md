> Source: https://gforth.org/manual/Displaying-characters-and-strings.html

<span id="Displaying-characters-and-strings"></span>

<div class="header">

Next: [String words](String-words.html#String-words), Previous: [String Formats](String-Formats.html#String-Formats), Up: [Other I/O](Other-I_002fO.html#Other-I_002fO)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Displaying-characters-and-strings-1"></span>

#### 5.19.4 Displaying characters and strings

<span id="index-characters-_002d-compiling-and-displaying"></span> <span id="index-character-strings-_002d-compiling-and-displaying"></span>

This section starts with a glossary of Forth words and ends with a set of examples.

<span id="index-bl--_002d_002d-c_002dchar--core"></span> <span id="index-bl"></span> <span id="index-bl-1"></span>

<div class="format">

``` format
bl       – c-char         core       “b-l”
```

</div>

*c-char* is the character value for a space.

<span id="index-space--_002d_002d--core"></span> <span id="index-space"></span> <span id="index-space-1"></span>

<div class="format">

``` format
space       –         core       “space”
```

</div>

Display one space.

<span id="index-spaces--u-_002d_002d--core"></span> <span id="index-spaces"></span> <span id="index-spaces-1"></span>

<div class="format">

``` format
spaces       u –         core       “spaces”
```

</div>

Display `n` spaces.

<span id="index-emit--c-_002d_002d--core"></span> <span id="index-emit"></span> <span id="index-emit-1"></span>

<div class="format">

``` format
emit       c –         core       “emit”
```

</div>

Display the character associated with character value c.

<span id="index-toupper--c1-_002d_002d-c2--gforth"></span> <span id="index-toupper"></span> <span id="index-toupper-1"></span>

<div class="format">

``` format
toupper       c1 – c2        gforth       “toupper”
```

</div>

If *c1* is a lower-case character (in the current locale), *c2* is the equivalent upper-case character. All other characters are unchanged.

<span id="index-_002e_0022--compilation-_0027ccc_0022_0027-_002d_002d-_003b-run_002dtime-_002d_002d--core"></span> <span id="index-_002e_0022"></span> <span id="index-_002e_0022-1"></span>

<div class="format">

``` format
."       compilation ’ccc"’ – ; run-time –         core       “dot-quote”
```

</div>

Compilation: Parse a string *ccc* delimited by a " (double quote). At run-time, display the string. Interpretation semantics for this word are undefined in ANS Forth. Gforth’s interpretation semantics are to display the string. This is the simplest way to display a string from within a definition; see examples below.

<span id="index-_002e_0028--compilation_0026interpretation-_0022ccc_003cparen_003e_0022-_002d_002d--core_002dext"></span> <span id="index-_002e_0028"></span> <span id="index-_002e_0028-1"></span>

<div class="format">

``` format
.(       compilation&interpretation "ccc<paren>" –         core-ext       “dot-paren”
```

</div>

Compilation and interpretation semantics: Parse a string *ccc* delimited by a `)` (right parenthesis). Display the string. This is often used to display progress information during compilation; see examples below.

<span id="index-_002e_005c_0022--compilation-_0027ccc_0022_0027-_002d_002d-_003b-run_002dtime-_002d_002d--gforth"></span> <span id="index-_002e_005c_0022"></span> <span id="index-_002e_005c_0022-1"></span>

<div class="format">

``` format
.\"       compilation ’ccc"’ – ; run-time –         gforth       “dot-backslash-quote”
```

</div>

Like `."`, but translates C-like \\-escape-sequences (see `S\"`).

<span id="index-type--c_002daddr-u-_002d_002d--core"></span> <span id="index-type"></span> <span id="index-type-1"></span>

<div class="format">

``` format
type       c-addr u –         core       “type”
```

</div>

If `u`\>0, display `u` characters from a string starting with the character stored at `c-addr`.

<span id="index-typewhite--addr-n-_002d_002d--gforth"></span> <span id="index-typewhite"></span> <span id="index-typewhite-1"></span>

<div class="format">

``` format
typewhite       addr n –         gforth       “typewhite”
```

</div>

Like type, but white space is printed instead of the characters.

<span id="index-cr--_002d_002d--core"></span> <span id="index-cr"></span> <span id="index-cr-1"></span>

<div class="format">

``` format
cr       –         core       “c-r”
```

</div>

Output a newline (of the favourite kind of the host OS). Note that due to the way the Forth command line interpreter inserts newlines, the preferred way to use `cr` is at the start of a piece of text; e.g., `cr ." hello, world"`.

<span id="index-cursor-control"></span> <span id="index-S_0022--compilation-_0027ccc_0022_0027-_002d_002d-_003b-run_002dtime-_002d_002d-c_002daddr-u--core_002cfile"></span> <span id="index-S_0022"></span> <span id="index-S_0022-1"></span>

<div class="format">

``` format
S"       compilation ’ccc"’ – ; run-time – c-addr u         core,file       “s-quote”
```

</div>

Compilation: Parse a string *ccc* delimited by a `"` (double quote). At run-time, return the length, *u*, and the start address, *c-addr* of the string. Interpretation: parse the string as before, and return *c-addr*, *u*. Gforth `allocate`s the string. The resulting memory leak is usually not a problem; the exception is if you create strings containing `S"` and `evaluate` them; then the leak is not bounded by the size of the interpreted files and you may want to `free` the strings. Forth-2012 only guarantees two buffers of 80 characters each, so in standard programs you should assume that the string lives only until the next-but-one `s"`.

<span id="index-s_005c_0022--compilation-_0027ccc_0022_0027-_002d_002d-_003b-run_002dtime-_002d_002d-c_002daddr-u--gforth"></span> <span id="index-s_005c_0022"></span> <span id="index-s_005c_0022-1"></span>

<div class="format">

``` format
s\"       compilation ’ccc"’ – ; run-time – c-addr u         gforth       “s-backslash-quote”
```

</div>

Like `S"`, but translates C-like \\-escape-sequences, as follows: `\a` BEL (alert), `\b` BS, `\e` ESC (not in C99), `\f` FF, `\n` newline, `\r` CR, `\t` HT, `\v` VT, `\"` ", `\\` \\, `\`\[0-7\]{1,3} octal numerical character value (non-standard), `\x`\[0-9a-f\]{0,2} hex numerical character value (standard only with two digits); a `\` before any other character is reserved.

<span id="index-C_0022--compilation-_0022ccc_003cquote_003e_0022-_002d_002d-_003b-run_002dtime-_002d_002d-c_002daddr--core_002dext"></span> <span id="index-C_0022"></span> <span id="index-C_0022-1"></span>

<div class="format">

``` format
C"       compilation "ccc<quote>" – ; run-time  – c-addr         core-ext       “c-quote”
```

</div>

Compilation: parse a string *ccc* delimited by a `"` (double quote). At run-time, return *c-addr* which specifies the counted string *ccc*. Interpretation semantics are undefined.

<span id="index-char--_0027_003cspaces_003eccc_0027-_002d_002d-c--core"></span> <span id="index-char"></span> <span id="index-char-1"></span>

<div class="format">

``` format
char       ’<spaces>ccc’ – c         core       “char”
```

</div>

Skip leading spaces. Parse the string *ccc* and return *c*, the display code representing the first character of *ccc*.

<span id="index-_005bChar_005d--compilation-_0027_003cspaces_003eccc_0027-_002d_002d-_003b-run_002dtime-_002d_002d-c--core"></span> <span id="index-_005bChar_005d"></span> <span id="index-_005bChar_005d-1"></span>

<div class="format">

``` format
[Char]       compilation ’<spaces>ccc’ – ; run-time – c         core       “bracket-char”
```

</div>

Compilation: skip leading spaces. Parse the string *ccc*. Run-time: return *c*, the display code representing the first character of *ccc*. Interpretation semantics for this word are undefined.

As an example, consider the following text, stored in a file `test.fs`:

<div class="example">

``` example
.( text-1)
: my-word
  ." text-2" cr
  .( text-3)
;

." text-4"

: my-char
  [char] ALPHABET emit
  char emit
;
```

</div>

When you load this code into Gforth, the following output is generated:

<div class="example">

``` example
include test.fs RET text-1text-3text-4 ok
```

</div>

  - Messages `text-1` and `text-3` are displayed because `.(` is an immediate word; it behaves in the same way whether it is used inside or outside a colon definition.
  - Message `text-4` is displayed because of Gforth’s added interpretation semantics for `."`.
  - Message `text-2` is *not* displayed, because the text interpreter performs the compilation semantics for `."` within the definition of `my-word`.

Here are some examples of executing `my-word` and `my-char`:

<div class="example">

``` example
my-word RET text-2
 ok
my-char fred RET Af ok
my-char jim RET Aj ok
```

</div>

  - Message `text-2` is displayed because of the run-time behaviour of `."`.
  - `[char]` compiles the “A” from “ALPHABET” and puts its display code on the stack at run-time. `emit` always displays the character when `my-char` is executed.
  - `char` parses a string at run-time and the second `emit` displays the first character of the string.
  - If you type `see my-char` you can see that `[char]` discarded the text “LPHABET” and only compiled the display code for “A” into the definition of `my-char`.

-----

<div class="header">

Next: [String words](String-words.html#String-words), Previous: [String Formats](String-Formats.html#String-Formats), Up: [Other I/O](Other-I_002fO.html#Other-I_002fO)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
