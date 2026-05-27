> Source: https://gforth.org/manual/Debugging.html

<span id="Debugging"></span>

<div class="header">

Next: [Assertions](Assertions.html#Assertions), Previous: [Forgetting words](Forgetting-words.html#Forgetting-words), Up: [Programming Tools](Programming-Tools.html#Programming-Tools)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Debugging-1"></span>

#### 5.24.3 Debugging

<span id="index-debugging"></span>

Languages with a slow edit/compile/link/test development loop tend to require sophisticated tracing/stepping debuggers to facilate debugging.

A much better (faster) way in fast-compiling languages is to add printing code at well-selected places, let the program run, look at the output, see where things went wrong, add more printing code, etc., until the bug is found.

The simple debugging aids provided in `debugs.fs` are meant to support this style of debugging.

The word `~~` prints debugging information (by default the source location and the stack contents). It is easy to insert. If you use Emacs it is also easy to remove (<span class="kbd">C-x \~</span> in the Emacs Forth mode to query-replace them with nothing). The deferred words `printdebugdata` and `.debugline` control the output of `~~`. The default source location output format works well with Emacs’ compilation mode, so you can step through the program at the source level using <span class="kbd">C-x \`</span> (the advantage over a stepping debugger is that you can step in any direction and you know where the crash has happened or where the strange data has occurred).

<span id="index-_007e_007e--_002d_002d--gforth"></span> <span id="index-_007e_007e"></span> <span id="index-_007e_007e-1"></span>

<div class="format">

``` format
~~       –         gforth       “tilde-tilde”
```

</div>

Prints the source code location of the `~~` and the stack contents with `.debugline`.

<span id="index-printdebugdata--_002d_002d--gforth"></span> <span id="index-printdebugdata"></span> <span id="index-printdebugdata-1"></span>

<div class="format">

``` format
printdebugdata       –         gforth       “print-debug-data”
```

</div>

<span id="index-_002edebugline--nfile-nline-_002d_002d--gforth"></span> <span id="index-_002edebugline"></span> <span id="index-_002edebugline-1"></span>

<div class="format">

``` format
.debugline       nfile nline –         gforth       “print-debug-line”
```

</div>

Print the source code location indicated by `nfile nline`, and additional debugging information; the default `.debugline` prints the additional information with `printdebugdata`.

<span id="index-debug_002dfid--_002d_002d-file_002did--gforth"></span> <span id="index-debug_002dfid"></span> <span id="index-debug_002dfid-1"></span>

<div class="format">

``` format
debug-fid       – file-id         gforth       “debug-fid”
```

</div>

<span id="index-filenames-in-_007e_007e-output"></span>

`~~` (and assertions) will usually print the wrong file name if a marker is executed in the same file after their occurance. They will print ‘`*somewhere*`’ as file name if a marker is executed in the same file before their occurance.

<span id="index-once--_002d_002d--unknown"></span> <span id="index-once"></span> <span id="index-once-1"></span>

<div class="format">

``` format
once       –         unknown       “once”
```

</div>

do the following up to THEN only once

<span id="index-_007e_007ebt--_002d_002d--unknown"></span> <span id="index-_007e_007ebt"></span> <span id="index-_007e_007ebt-1"></span>

<div class="format">

``` format
~~bt       –         unknown       “~~bt”
```

</div>

print stackdump and backtrace

<span id="index-_007e_007e1bt--_002d_002d--unknown"></span> <span id="index-_007e_007e1bt"></span> <span id="index-_007e_007e1bt-1"></span>

<div class="format">

``` format
~~1bt       –         unknown       “~~1bt”
```

</div>

print stackdump and backtrace once

<span id="index-_003f_003f_003f--_002d_002d--unknown"></span> <span id="index-_003f_003f_003f"></span> <span id="index-_003f_003f_003f-1"></span>

<div class="format">

``` format
???       –         unknown       “???”
```

</div>

Open a debuging shell

<span id="index-WTF_003f_003f--_002d_002d--unknown"></span> <span id="index-WTF_003f_003f"></span> <span id="index-WTF_003f_003f-1"></span>

<div class="format">

``` format
WTF??       –         unknown       “WTF??”
```

</div>

Open a debugging shell with backtrace and stack dump

<span id="index-_0021_0021FIXME_0021_0021--_002d_002d--unknown"></span> <span id="index-_0021_0021FIXME_0021_0021"></span> <span id="index-_0021_0021FIXME_0021_0021-1"></span>

<div class="format">

``` format
!!FIXME!!       –         unknown       “!!FIXME!!”
```

</div>

word that should never be reached

<span id="index-replace_002dword--xt1-xt2-_002d_002d--gforth"></span> <span id="index-replace_002dword"></span> <span id="index-replace_002dword-1"></span>

<div class="format">

``` format
replace-word       xt1 xt2 –         gforth       “replace-word”
```

</div>

make xt2 do xt1, both need to be colon definitions

<span id="index-_007e_007eVariable--_0022name_0022-_002d_002d--unknown"></span> <span id="index-_007e_007eVariable"></span> <span id="index-_007e_007eVariable-1"></span>

<div class="format">

``` format
~~Variable       "name" –         unknown       “~~Variable”
```

</div>

Variable that will be watched on every access

<span id="index-_007e_007eValue--n-_0022name_0022-_002d_002d--unknown"></span> <span id="index-_007e_007eValue"></span> <span id="index-_007e_007eValue-1"></span>

<div class="format">

``` format
~~Value       n "name" –         unknown       “~~Value”
```

</div>

Value that will be watched on every access

<span id="index-_002bltrace--_002d_002d--unknown"></span> <span id="index-_002bltrace"></span> <span id="index-_002bltrace-1"></span>

<div class="format">

``` format
+ltrace       –         unknown       “+ltrace”
```

</div>

turn on line tracing

<span id="index-_002dltrace--unknown--unknown"></span> <span id="index-_002dltrace"></span> <span id="index-_002dltrace-1"></span>

<div class="format">

``` format
-ltrace       unknown         unknown       “-ltrace”
```

</div>

turn off line tracing

doc-view <span id="index-locate--_0022name_0022-_002d_002d--unknown"></span> <span id="index-locate"></span> <span id="index-locate-1"></span>

<div class="format">

``` format
locate       "name" –         unknown       “locate”
```

</div>

<span id="index-edit--_0022name_0022-_002d_002d--unknown"></span> <span id="index-edit"></span> <span id="index-edit-1"></span>

<div class="format">

``` format
edit       "name" –         unknown       “edit”
```

</div>

Enter the editor at the place of "name"

<span id="index-_0023loc--nline-nchar-_0022file_0022-_002d_002d--unknown"></span> <span id="index-_0023loc"></span> <span id="index-_0023loc-1"></span>

<div class="format">

``` format
#loc       nline nchar "file" –         unknown       “#loc”
```

</div>

set next word’s location to `nline nchar` in `"file"`

-----

<div class="header">

Next: [Assertions](Assertions.html#Assertions), Previous: [Forgetting words](Forgetting-words.html#Forgetting-words), Up: [Programming Tools](Programming-Tools.html#Programming-Tools)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
