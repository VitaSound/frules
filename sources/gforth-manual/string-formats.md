> Source: https://gforth.org/manual/String-Formats.html

<span id="String-Formats"></span>

<div class="header">

Next: [Displaying characters and strings](Displaying-characters-and-strings.html#Displaying-characters-and-strings), Previous: [Formatted numeric output](Formatted-numeric-output.html#Formatted-numeric-output), Up: [Other I/O](Other-I_002fO.html#Other-I_002fO)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="String-Formats-1"></span>

#### 5.19.3 String Formats

<span id="index-strings-_002d-see-character-strings"></span> <span id="index-character-strings-_002d-formats"></span> <span id="index-I_002fO-_002d-see-character-strings"></span> <span id="index-counted-strings"></span>

Forth commonly uses two different methods for representing character strings:

  - <span id="index-address-of-counted-string"></span> <span id="index-counted-string"></span> As a *counted string*, represented by a *c-addr*. The char addressed by *c-addr* contains a character-count, *n*, of the string and the string occupies the subsequent *n* char addresses in memory.
  - As cell pair on the stack; *c-addr u*, where *u* is the length of the string in characters, and *c-addr* is the address of the first byte of the string.

Standard Forth encourages the use of the cell pair format when representing strings.

<span id="index-count--c_002daddr1-_002d_002d-c_002daddr2-u--core"></span> <span id="index-count"></span> <span id="index-count-1"></span>

<div class="format">

``` format
count       c-addr1 – c-addr2 u        core       “count”
```

</div>

*c-addr2* is the first character and *u* the length of the counted string at *c-addr1*.

For words that move, copy and search for strings see [Memory Blocks](Memory-Blocks.html#Memory-Blocks). For words that display characters and strings see [Displaying characters and strings](Displaying-characters-and-strings.html#Displaying-characters-and-strings).
