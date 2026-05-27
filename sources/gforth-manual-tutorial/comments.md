### 3.8 Comments

> Source: https://gforth.org/manual/Comments-Tutorial.html

```
\ That's a comment; it ends at the end of the line
( Another comment; it ends here: )  .s
```

`\` and `(` are ordinary Forth words and therefore have to be separated with white space from the following text.

```
\This gives an "Undefined word" error
```

The first `)` ends a comment started with `(`, so you cannot nest `(`-comments; and you cannot comment out text containing a `)` with `( ... )`.

I use `\`-comments for descriptive text and for commenting out code of one or more line; I use `(`-comments for describing the stack effect, the stack contents, or for commenting out sub-line pieces of code.

The Emacs mode gforth.el (see Emacs and Gforth) supports these uses by commenting out a region with C-x \, uncommenting a region with C-u C-x \, and filling a `\`-commented region with M-q.

Therefore it's a good idea to avoid `)` in word names.
