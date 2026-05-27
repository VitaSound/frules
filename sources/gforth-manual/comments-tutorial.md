> Source: https://gforth.org/manual/Comments-Tutorial.html

<span id="Comments-Tutorial"></span>

<div class="header">

Next: [Colon Definitions Tutorial](Colon-Definitions-Tutorial.html#Colon-Definitions-Tutorial), Previous: [Using files for Forth code Tutorial](Using-files-for-Forth-code-Tutorial.html#Using-files-for-Forth-code-Tutorial), Up: [Tutorial](Tutorial.html#Tutorial)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Comments-1"></span>

### 3.8 Comments

<span id="index-comments-tutorial"></span>

<div class="example">

``` example
\ That's a comment; it ends at the end of the line
( Another comment; it ends here: )  .s
```

</div>

`\` and `(` are ordinary Forth words and therefore have to be separated with white space from the following text.

<div class="example">

``` example
\This gives an "Undefined word" error
```

</div>

The first `)` ends a comment started with `(`, so you cannot nest `(`-comments; and you cannot comment out text containing a `)` with `( ... )`[<sup>4</sup>](#FOOT4).

I use `\`-comments for descriptive text and for commenting out code of one or more line; I use `(`-comments for describing the stack effect, the stack contents, or for commenting out sub-line pieces of code.

The Emacs mode `gforth.el` (see [Emacs and Gforth](Emacs-and-Gforth.html#Emacs-and-Gforth)) supports these uses by commenting out a region with <span class="kbd">C-x \\</span>, uncommenting a region with <span class="kbd">C-u C-x \\</span>, and filling a `\`-commented region with <span class="kbd">M-q</span>.

Reference: [Comments](Comments.html#Comments).

<div class="footnote">

-----

#### Footnotes

### [(4)](#DOCF4)

therefore it’s a good idea to avoid `)` in word names.

</div>
