> Source: https://gforth.org/manual/Comments.html

<span id="Comments"></span>

<div class="header">

Next: [Boolean Flags](Boolean-Flags.html#Boolean-Flags), Previous: [Case insensitivity](Case-insensitivity.html#Case-insensitivity), Up: [Words](Words.html#Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Comments-2"></span>

### 5.3 Comments

<span id="index-comments"></span>

Forth supports two styles of comment; the traditional *in-line* comment, `(` and its modern cousin, the *comment to end of line*; `\`.

<span id="index-_0028--compilation-_0027ccc_003cclose_002dparen_003e_0027-_002d_002d-_003b-run_002dtime-_002d_002d--core_002cfile"></span> <span id="index-_0028"></span> <span id="index-_0028-1"></span>

<div class="format">

``` format
(       compilation ’ccc<close-paren>’ – ; run-time –         core,file       “paren”
```

</div>

Comment, usually till the next `)`: parse and discard all subsequent characters in the parse area until ")" is encountered. During interactive input, an end-of-line also acts as a comment terminator. For file input, it does not; if the end-of-file is encountered whilst parsing for the ")" delimiter, Gforth will generate a warning.

<span id="index-_005c--compilation-_0027ccc_003cnewline_003e_0027-_002d_002d-_003b-run_002dtime-_002d_002d--core_002dext_002cblock_002dext"></span> <span id="index-_005c"></span> <span id="index-_005c-1"></span>

<div class="format">

``` format
\       compilation ’ccc<newline>’ – ; run-time –         core-ext,block-ext       “backslash”
```

</div>

Comment till the end of the line if `BLK` contains 0 (i.e., while not loading a block), parse and discard the remainder of the parse area. Otherwise, parse and discard all subsequent characters in the parse area corresponding to the current line.

<span id="index-_005cG--compilation-_0027ccc_003cnewline_003e_0027-_002d_002d-_003b-run_002dtime-_002d_002d--gforth"></span> <span id="index-_005cG"></span> <span id="index-_005cG-1"></span>

<div class="format">

``` format
\G       compilation ’ccc<newline>’ – ; run-time –         gforth       “backslash-gee”
```

</div>

Equivalent to `\` but used as a tag to annotate definition comments into documentation.
