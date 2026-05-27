> Source: https://gforth.org/manual/Terminal-output.html

<span id="Terminal-output"></span>

<div class="header">

Next: [Single-key input](Single_002dkey-input.html#Single_002dkey-input), Previous: [String words](String-words.html#String-words), Up: [Other I/O](Other-I_002fO.html#Other-I_002fO)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Terminal-output-1"></span>

#### 5.19.6 Terminal output

<span id="index-output-to-terminal"></span> <span id="index-terminal-output"></span>

If you are outputting to a terminal, you may want to control the positioning of the cursor: <span id="index-cursor-positioning"></span>

<span id="index-at_002dxy--x-y-_002d_002d--unknown"></span> <span id="index-at_002dxy"></span> <span id="index-at_002dxy-1"></span>

<div class="format">

``` format
at-xy       x y –         unknown       “at-xy”
```

</div>

In order to know where to position the cursor, it is often helpful to know the size of the screen: <span id="index-terminal-size"></span>

<span id="index-form---unknown"></span> <span id="index-form"></span> <span id="index-form-1"></span>

<div class="format">

``` format
form              unknown       “form”
```

</div>

And sometimes you want to use: <span id="index-clear-screen"></span>

<span id="index-page--_002d_002d--unknown"></span> <span id="index-page"></span> <span id="index-page-1"></span>

<div class="format">

``` format
page       –         unknown       “page”
```

</div>

Note that on non-terminals you should use `12 emit`, not `page`, to get a form feed.
