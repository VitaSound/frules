> Source: https://gforth.org/manual/Pipes.html

<span id="Pipes"></span>

<div class="header">

Next: [Xchars and Unicode](Xchars-and-Unicode.html#Xchars-and-Unicode), Previous: [Line input and conversion](Line-input-and-conversion.html#Line-input-and-conversion), Up: [Other I/O](Other-I_002fO.html#Other-I_002fO)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Pipes-1"></span>

#### 5.19.9 Pipes

<span id="index-pipes_002c-creating-your-own"></span>

In addition to using Gforth in pipes created by other processes (see [Gforth in pipes](Gforth-in-pipes.html#Gforth-in-pipes)), you can create your own pipe with `open-pipe`, and read from or write to it.

<span id="index-open_002dpipe--c_002daddr-u-wfam-_002d_002d-wfileid-wior--gforth"></span> <span id="index-open_002dpipe"></span> <span id="index-open_002dpipe-1"></span>

<div class="format">

``` format
open-pipe       c-addr u wfam – wfileid wior        gforth       “open-pipe”
```

</div>

<span id="index-close_002dpipe--wfileid-_002d_002d-wretval-wior--gforth"></span> <span id="index-close_002dpipe"></span> <span id="index-close_002dpipe-1"></span>

<div class="format">

``` format
close-pipe       wfileid – wretval wior        gforth       “close-pipe”
```

</div>

If you write to a pipe, Gforth can throw a `broken-pipe-error`; if you don’t catch this exception, Gforth will catch it and exit, usually silently (see [Gforth in pipes](Gforth-in-pipes.html#Gforth-in-pipes)). Since you probably do not want this, you should wrap a `catch` or `try` block around the code from `open-pipe` to `close-pipe`, so you can deal with the problem yourself, and then return to regular processing.

<span id="index-broken_002dpipe_002derror--_002d_002d-n--gforth"></span> <span id="index-broken_002dpipe_002derror"></span> <span id="index-broken_002dpipe_002derror-1"></span>

<div class="format">

``` format
broken-pipe-error       – n         gforth       “broken-pipe-error”
```

</div>

the error number for a broken pipe
