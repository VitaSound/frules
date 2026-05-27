> Source: https://gforth.org/manual/The-Input-Stream.html

<span id="The-Input-Stream"></span>

<div class="header">

Next: [Word Lists](Word-Lists.html#Word-Lists), Previous: [The Text Interpreter](The-Text-Interpreter.html#The-Text-Interpreter), Up: [Words](Words.html#Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="The-Input-Stream-1"></span>

### 5.14 The Input Stream

<span id="index-input-stream"></span>

The text interpreter reads from the input stream, which can come from several sources (see [Input Sources](Input-Sources.html#Input-Sources)). Some words, in particular defining words, but also words like `'`, read parameters from the input stream instead of from the stack.

Such words are called parsing words, because they parse the input stream. Parsing words are hard to use in other words, because it is hard to pass program-generated parameters through the input stream. They also usually have an unintuitive combination of interpretation and compilation semantics when implemented naively, leading to various approaches that try to produce a more intuitive behaviour (see [Combined words](Combined-words.html#Combined-words)).

It should be obvious by now that parsing words are a bad idea. If you want to implement a parsing word for convenience, also provide a factor of the word that does not parse, but takes the parameters on the stack. To implement the parsing word on top if it, you can use the following words:

<span id="index-parse--char-_0022ccc_003cchar_003e_0022-_002d_002d-c_002daddr-u--core_002dext"></span> <span id="index-parse"></span> <span id="index-parse-1"></span>

<div class="format">

``` format
parse       char "ccc<char>" – c-addr u         core-ext       “parse”
```

</div>

Parse *ccc*, delimited by *char*, in the parse area. *c-addr u* specifies the parsed string within the parse area. If the parse area was empty, *u* is 0.

<span id="index-parse_002dname--_0022name_0022-_002d_002d-c_002daddr-u--gforth"></span> <span id="index-parse_002dname"></span> <span id="index-parse_002dname-1"></span>

<div class="format">

``` format
parse-name       "name" – c-addr u         gforth       “parse-name”
```

</div>

Get the next word from the input buffer

<span id="index-parse_002dword--_002d_002d-c_002daddr-u--gforth_002dobsolete"></span> <span id="index-parse_002dword"></span> <span id="index-parse_002dword-1"></span>

<div class="format">

``` format
parse-word       – c-addr u         gforth-obsolete       “parse-word”
```

</div>

old name for `parse-name`

<span id="index-name--_002d_002d-c_002daddr-u--gforth_002dobsolete"></span> <span id="index-name"></span> <span id="index-name-1"></span>

<div class="format">

``` format
name       – c-addr u         gforth-obsolete       “name”
```

</div>

old name for `parse-name`

<span id="index-word--char-_0022_003cchars_003eccc_003cchar_003e_002d_002d-c_002daddr--core"></span> <span id="index-word-1"></span> <span id="index-word-2"></span>

<div class="format">

``` format
word       char "<chars>ccc<char>– c-addr         core       “word”
```

</div>

Skip leading delimiters. Parse *ccc*, delimited by *char*, in the parse area. *c-addr* is the address of a transient region containing the parsed string in counted-string format. If the parse area was empty or contained no characters other than delimiters, the resulting string has zero length. A program may replace characters within the counted string. OBSOLESCENT: the counted string has a trailing space that is not included in its length.

<span id="index-refill--_002d_002d-flag--core_002dext_002cblock_002dext_002cfile_002dext"></span> <span id="index-refill"></span> <span id="index-refill-1"></span>

<div class="format">

``` format
refill       – flag         core-ext,block-ext,file-ext       “refill”
```

</div>

Attempt to fill the input buffer from the input source. When the input source is the user input device, attempt to receive input into the terminal input device. If successful, make the result the input buffer, set `>IN` to 0 and return true; otherwise return false. When the input source is a block, add 1 to the value of `BLK` to make the next block the input source and current input buffer, and set `>IN` to 0; return true if the new value of `BLK` is a valid block number, false otherwise. When the input source is a text file, attempt to read the next line from the file. If successful, make the result the current input buffer, set `>IN` to 0 and return true; otherwise, return false. A successful result includes receipt of a line containing 0 characters.

Conversely, if you have the bad luck (or lack of foresight) to have to deal with parsing words without having such factors, how do you pass a string that is not in the input stream to it?

<span id="index-execute_002dparsing--_002e_002e_002e-addr-u-xt-_002d_002d-_002e_002e_002e--gforth"></span> <span id="index-execute_002dparsing"></span> <span id="index-execute_002dparsing-1"></span>

<div class="format">

``` format
execute-parsing       ... addr u xt – ...         gforth       “execute-parsing”
```

</div>

Make *addr u* the current input source, execute *xt `( ... -- ... )`*, then restore the previous input source.

A definition of this word in Standard Forth is provided in `compat/execute-parsing.fs`.

If you want to run a parsing word on a file, the following word should help:

<span id="index-execute_002dparsing_002dfile--i_002ax-fileid-xt-_002d_002d-j_002ax--gforth"></span> <span id="index-execute_002dparsing_002dfile"></span> <span id="index-execute_002dparsing_002dfile-1"></span>

<div class="format">

``` format
execute-parsing-file       i*x fileid xt – j*x         gforth       “execute-parsing-file”
```

</div>

Make *fileid* the current input source, execute *xt `( i*x -- j*x )`*, then restore the previous input source.

-----

<div class="header">

Next: [Word Lists](Word-Lists.html#Word-Lists), Previous: [The Text Interpreter](The-Text-Interpreter.html#The-Text-Interpreter), Up: [Words](Words.html#Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
