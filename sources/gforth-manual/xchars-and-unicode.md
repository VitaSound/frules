> Source: https://gforth.org/manual/Xchars-and-Unicode.html

<span id="Xchars-and-Unicode"></span>

<div class="header">

Previous: [Pipes](Pipes.html#Pipes), Up: [Other I/O](Other-I_002fO.html#Other-I_002fO)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Xchars-and-Unicode-1"></span>

#### 5.19.10 Xchars and Unicode

ASCII is only appropriate for the English language. Most western languages however fit somewhat into the Forth frame, since a byte is sufficient to encode the few special characters in each (though not always the same encoding can be used; latin-1 is most widely used, though). For other languages, different char-sets have to be used, several of them variable-width. Most prominent representant is UTF-8. Let’s call these extended characters xchars. The primitive fixed-size characters stored as bytes are called pchars in this section.

The xchar words add a few data types:

  - `xc` is an extended char (xchar) on the stack. It occupies one cell, and is a subset of unsigned cell. Note: UTF-8 can not store more that 31 bits; on 16 bit systems, only the UCS16 subset of the UTF-8 character set can be used.
  - `xc-addr` is the address of an xchar in memory. Alignment requirements are the same as `c-addr`. The memory representation of an xchar differs from the stack representation, and depends on the encoding used. An xchar may use a variable number of pchars in memory.
  - `xc-addr` `u` is a buffer of xchars in memory, starting at `xc-addr`, `u` pchars long.

<span id="index-xc_002dsize--xc-_002d_002d-u--xchar_002dext"></span> <span id="index-xc_002dsize"></span> <span id="index-xc_002dsize-1"></span>

<div class="format">

``` format
xc-size       xc – u         xchar-ext       “xc-size”
```

</div>

Computes the memory size of the xchar `xc` in pchars.

<span id="index-x_002dsize--xc_002daddr-u1-_002d_002d-u2--xchar"></span> <span id="index-x_002dsize"></span> <span id="index-x_002dsize-1"></span>

<div class="format">

``` format
x-size       xc-addr u1 – u2         xchar       “x-size”
```

</div>

Computes the memory size of the first xchar stored at `xc-addr` in pchars.

<span id="index-xc_0040_002b--xc_002daddr1-_002d_002d-xc_002daddr2-xc--xchar_002dext"></span> <span id="index-xc_0040_002b"></span> <span id="index-xc_0040_002b-1"></span>

<div class="format">

``` format
xc@+       xc-addr1 – xc-addr2 xc         xchar-ext       “xc-fetch-plus”
```

</div>

Fetchs the xchar `xc` at `xc-addr1`. `xc-addr2` points to the first memory location after `xc`.

<span id="index-xc_0021_002b_003f--xc-xc_002daddr1-u1-_002d_002d-xc_002daddr2-u2-f--xchar_002dext"></span> <span id="index-xc_0021_002b_003f"></span> <span id="index-xc_0021_002b_003f-1"></span>

<div class="format">

``` format
xc!+?       xc xc-addr1 u1 – xc-addr2 u2 f         xchar-ext       “xc-store-plus-query”
```

</div>

Stores the xchar `xc` into the buffer starting at address `xc-addr1`, `u1` pchars large. `xc-addr2` points to the first memory location after `xc`, `u2` is the remaining size of the buffer. If the xchar `xc` did fit into the buffer, `f` is true, otherwise `f` is false, and `xc-addr2` `u2` equal `xc-addr1` `u1`. XC\!+? is safe for buffer overflows, and therefore preferred over XC\!+.

<span id="index-xchar_002b--xc_002daddr1-_002d_002d-xc_002daddr2--xchar_002dext"></span> <span id="index-xchar_002b"></span> <span id="index-xchar_002b-1"></span>

<div class="format">

``` format
xchar+       xc-addr1 – xc-addr2         xchar-ext       “xchar+”
```

</div>

Adds the size of the xchar stored at `xc-addr1` to this address, giving `xc-addr2`.

<span id="index-xchar_002d--xc_002daddr1-_002d_002d-xc_002daddr2--xchar_002dext"></span> <span id="index-xchar_002d"></span> <span id="index-xchar_002d-1"></span>

<div class="format">

``` format
xchar-       xc-addr1 – xc-addr2         xchar-ext       “xchar-”
```

</div>

Goes backward from `xc_addr1` until it finds an xchar so that the size of this xchar added to `xc_addr2` gives `xc_addr1`.

<span id="index-_002bx_002fstring--xc_002daddr1-u1-_002d_002d-xc_002daddr2-u2--xchar"></span> <span id="index-_002bx_002fstring"></span> <span id="index-_002bx_002fstring-1"></span>

<div class="format">

``` format
+x/string       xc-addr1 u1 – xc-addr2 u2         xchar       “plus-x-slash-string”
```

</div>

Step forward by one xchar in the buffer defined by address `xc-addr1`, size `u1` pchars. `xc-addr2` is the address and u2 the size in pchars of the remaining buffer after stepping over the first xchar in the buffer.

<span id="index-x_005cstring_002d--xc_002daddr1-u1-_002d_002d-xc_002daddr1-u2--xchar"></span> <span id="index-x_005cstring_002d"></span> <span id="index-x_005cstring_002d-1"></span>

<div class="format">

``` format
x\string-       xc-addr1 u1 – xc-addr1 u2         xchar       “x-back-string-minus”
```

</div>

Step backward by one xchar in the buffer defined by address `xc-addr1` and size `u1` in pchars, starting at the end of the buffer. `xc-addr1` is the address and `u2` the size in pchars of the remaining buffer after stepping backward over the last xchar in the buffer.

<span id="index-_002dtrailing_002dgarbage--xc_002daddr-u1-_002d_002d-addr-u2--xchar_002dext"></span> <span id="index-_002dtrailing_002dgarbage"></span> <span id="index-_002dtrailing_002dgarbage-1"></span>

<div class="format">

``` format
-trailing-garbage       xc-addr u1 – addr u2         xchar-ext       “-trailing-garbage”
```

</div>

Examine the last XCHAR in the buffer `xc-addr` `u1`—if the encoding is correct and it repesents a full pchar, `u2` equals `u1`, otherwise, `u2` represents the string without the last (garbled) xchar.

<span id="index-x_002dwidth--xc_002daddr-u-_002d_002d-n--xchar_002dext"></span> <span id="index-x_002dwidth"></span> <span id="index-x_002dwidth-1"></span>

<div class="format">

``` format
x-width       xc-addr u – n         xchar-ext       “x-width”
```

</div>

`n` is the number of monospace ASCII pchars that take the same space to display as the the xchar string starting at `xc-addr`, using `u` pchars; assuming a monospaced display font, i.e. pchar width is always an integer multiple of the width of an ASCII pchar.

<span id="index-xkey--_002d_002d-xc--xchar_002dext"></span> <span id="index-xkey"></span> <span id="index-xkey-1"></span>

<div class="format">

``` format
xkey       – xc         xchar-ext       “xkey”
```

</div>

Reads an xchar from the terminal. This will discard all input events up to the completion of the xchar.

<span id="index-xemit--xc-_002d_002d--xchar_002dext"></span> <span id="index-xemit"></span> <span id="index-xemit-1"></span>

<div class="format">

``` format
xemit       xc –         xchar-ext       “xemit”
```

</div>

Prints an xchar on the terminal.

There’s a new environment query

<span id="index-xchar_002dencoding--_002d_002d-addr-u--xchar_002dext"></span> <span id="index-xchar_002dencoding"></span> <span id="index-xchar_002dencoding-1"></span>

<div class="format">

``` format
xchar-encoding       – addr u         xchar-ext       “xchar-encoding”
```

</div>

Returns a printable ASCII string that reperesents the encoding, and use the preferred MIME name (if any) or the name in <http://www.iana.org/assignments/character-sets> like “ISO-LATIN-1” or “UTF-8”, with the exception of “ASCII”, where we prefer the alias “ASCII”.

-----

<div class="header">

Previous: [Pipes](Pipes.html#Pipes), Up: [Other I/O](Other-I_002fO.html#Other-I_002fO)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
