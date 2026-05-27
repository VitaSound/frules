> Source: https://gforth.org/manual/Miscellaneous-Words.html

<span id="Miscellaneous-Words"></span>

<div class="header">

Previous: [Keeping track of Time](Keeping-track-of-Time.html#Keeping-track-of-Time), Up: [Words](Words.html#Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Miscellaneous-Words-1"></span>

### 5.31 Miscellaneous Words

<span id="index-miscellaneous-words"></span>

This section lists the Standard Forth words that are not documented elsewhere in this manual. Ultimately, they all need proper homes.

<span id="index-quit--_003f_003f-_002d_002d-_003f_003f--core"></span> <span id="index-quit"></span> <span id="index-quit-1"></span>

<div class="format">

``` format
quit       ?? – ??         core       “quit”
```

</div>

Empty the return stack, make the user input device the input source, enter interpret state and start the text interpreter.

The following Standard Forth words are not currently supported by Gforth (see [Standard conformance](Standard-conformance.html#Standard-conformance)):

`EDITOR` `EMIT?` `FORGET`
