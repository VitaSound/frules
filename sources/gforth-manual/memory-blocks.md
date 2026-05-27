> Source: https://gforth.org/manual/Memory-Blocks.html

<span id="Memory-Blocks"></span>

<div class="header">

Previous: [Address arithmetic](Address-arithmetic.html#Address-arithmetic), Up: [Memory](Memory.html#Memory)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Memory-Blocks-1"></span>

#### 5.7.6 Memory Blocks

<span id="index-memory-block-words"></span> <span id="index-character-strings-_002d-moving-and-copying"></span>

Memory blocks often represent character strings; For ways of storing character strings in memory see [String Formats](String-Formats.html#String-Formats). For other string-processing words see [Displaying characters and strings](Displaying-characters-and-strings.html#Displaying-characters-and-strings).

A few of these words work on address unit blocks. In that case, you usually have to insert `CHARS` before the word when working on character strings. Most words work on character blocks, and expect a char-aligned address.

When copying characters between overlapping memory regions, use `chars move` or choose carefully between `cmove` and `cmove>`.

<span id="index-move--c_002dfrom-c_002dto-ucount-_002d_002d--core"></span> <span id="index-move"></span> <span id="index-move-1"></span>

<div class="format">

``` format
move       c-from c-to ucount –        core       “move”
```

</div>

Copy the contents of *ucount* aus at *c-from* to *c-to*. `move` works correctly even if the two areas overlap.

<span id="index-erase--addr-u-_002d_002d--core_002dext"></span> <span id="index-erase"></span> <span id="index-erase-1"></span>

<div class="format">

``` format
erase       addr u –         core-ext       “erase”
```

</div>

Clear all bits in *u* aus starting at *addr*.

<span id="index-cmove--c_002dfrom-c_002dto-u-_002d_002d--string"></span> <span id="index-cmove"></span> <span id="index-cmove-1"></span>

<div class="format">

``` format
cmove       c-from c-to u –        string       “c-move”
```

</div>

Copy the contents of *ucount* characters from data space at *c-from* to *c-to*. The copy proceeds `char`-by-`char` from low address to high address; i.e., for overlapping areas it is safe if *c-to*\<=*c-from*.

<span id="index-cmove_003e--c_002dfrom-c_002dto-u-_002d_002d--string"></span> <span id="index-cmove_003e"></span> <span id="index-cmove_003e-1"></span>

<div class="format">

``` format
cmove>       c-from c-to u –        string       “c-move-up”
```

</div>

Copy the contents of *ucount* characters from data space at *c-from* to *c-to*. The copy proceeds `char`-by-`char` from high address to low address; i.e., for overlapping areas it is safe if *c-to*\>=*c-from*.

<span id="index-fill--c_002daddr-u-c-_002d_002d--core"></span> <span id="index-fill"></span> <span id="index-fill-1"></span>

<div class="format">

``` format
fill       c-addr u c –        core       “fill”
```

</div>

Store *c* in *u* chars starting at *c-addr*.

<span id="index-blank--c_002daddr-u-_002d_002d--string"></span> <span id="index-blank"></span> <span id="index-blank-1"></span>

<div class="format">

``` format
blank       c-addr u –         string       “blank”
```

</div>

Store the space character into *u* chars starting at *c-addr*.

<span id="index-compare--c_002daddr1-u1-c_002daddr2-u2-_002d_002d-n--string"></span> <span id="index-compare"></span> <span id="index-compare-1"></span>

<div class="format">

``` format
compare       c-addr1 u1 c-addr2 u2 – n        string       “compare”
```

</div>

Compare two strings lexicographically. If they are equal, *n* is 0; if the first string is smaller, *n* is -1; if the first string is larger, *n* is 1. Currently this is based on the machine’s character comparison. In the future, this may change to consider the current locale and its collation order.

<span id="index-str_003d--c_002daddr1-u1-c_002daddr2-u2-_002d_002d-f--gforth"></span> <span id="index-str_003d"></span> <span id="index-str_003d-1"></span>

<div class="format">

``` format
str=       c-addr1 u1 c-addr2 u2 – f         gforth       “str=”
```

</div>

<span id="index-str_003c--c_002daddr1-u1-c_002daddr2-u2-_002d_002d-f--gforth"></span> <span id="index-str_003c"></span> <span id="index-str_003c-1"></span>

<div class="format">

``` format
str<       c-addr1 u1 c-addr2 u2 – f         gforth       “str<”
```

</div>

<span id="index-string_002dprefix_003f--c_002daddr1-u1-c_002daddr2-u2-_002d_002d-f--gforth"></span> <span id="index-string_002dprefix_003f"></span> <span id="index-string_002dprefix_003f-1"></span>

<div class="format">

``` format
string-prefix?       c-addr1 u1 c-addr2 u2 – f         gforth       “string-prefix?”
```

</div>

Is `c-addr2 u2` a prefix of `c-addr1 u1`?

<span id="index-search--c_002daddr1-u1-c_002daddr2-u2-_002d_002d-c_002daddr3-u3-flag--string"></span> <span id="index-search"></span> <span id="index-search-1"></span>

<div class="format">

``` format
search       c-addr1 u1 c-addr2 u2 – c-addr3 u3 flag         string       “search”
```

</div>

Search the string specified by *c-addr1, u1* for the string specified by *c-addr2, u2*. If *flag* is true: match was found at *c-addr3* with *u3* characters remaining. If *flag* is false: no match was found; *c-addr3, u3* are equal to *c-addr1, u1*.

<span id="index-_002dtrailing--c_005faddr-u1-_002d_002d-c_005faddr-u2--string"></span> <span id="index-_002dtrailing"></span> <span id="index-_002dtrailing-1"></span>

<div class="format">

``` format
-trailing       c_addr u1 – c_addr u2         string       “dash-trailing”
```

</div>

Adjust the string specified by *c-addr, u1* to remove all trailing spaces. *u2* is the length of the modified string.

<span id="index-_002fstring--c_002daddr1-u1-n-_002d_002d-c_002daddr2-u2--string"></span> <span id="index-_002fstring"></span> <span id="index-_002fstring-1"></span>

<div class="format">

``` format
/string       c-addr1 u1 n – c-addr2 u2        string       “slash-string”
```

</div>

Adjust the string specified by *c-addr1, u1* to remove *n* characters from the start of the string.

<span id="index-bounds--addr-u-_002d_002d-addr_002bu-addr--gforth"></span> <span id="index-bounds"></span> <span id="index-bounds-1"></span>

<div class="format">

``` format
bounds       addr u – addr+u addr         gforth       “bounds”
```

</div>

Given a memory block represented by starting address *addr* and length *u* in aus, produce the end address *addr+u* and the start address in the right order for `u+do` or `?do`.

<span id="index-pad--_002d_002d-c_002daddr--core_002dext"></span> <span id="index-pad"></span> <span id="index-pad-1"></span>

<div class="format">

``` format
pad       – c-addr         core-ext       “pad”
```

</div>

`c-addr` is the address of a transient region that can be used as temporary data storage. At least 84 characters of space is available.

-----

<div class="header">

Previous: [Address arithmetic](Address-arithmetic.html#Address-arithmetic), Up: [Memory](Memory.html#Memory)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
