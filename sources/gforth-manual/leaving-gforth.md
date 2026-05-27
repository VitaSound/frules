> Source: https://gforth.org/manual/Leaving-Gforth.html

<span id="Leaving-Gforth"></span>

<div class="header">

Next: [Command-line editing](Command_002dline-editing.html#Command_002dline-editing), Previous: [Invoking Gforth](Invoking-Gforth.html#Invoking-Gforth), Up: [Gforth Environment](Gforth-Environment.html#Gforth-Environment)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Leaving-Gforth-1"></span>

### 2.2 Leaving Gforth

<span id="index-Gforth-_002d-leaving"></span> <span id="index-leaving-Gforth"></span>

You can leave Gforth by typing `bye` or <span class="kbd">Ctrl-d</span> (at the start of a line) or (if you invoked Gforth with the `--die-on-signal` option) <span class="kbd">Ctrl-c</span>. When you leave Gforth, all of your definitions and data are discarded. For ways of saving the state of the system before leaving Gforth see [Image Files](Image-Files.html#Image-Files).

<span id="index-bye--_002d_002d--unknown"></span> <span id="index-bye"></span> <span id="index-bye-1"></span>

<div class="format">

``` format
bye       –         unknown       “bye”
```

</div>
