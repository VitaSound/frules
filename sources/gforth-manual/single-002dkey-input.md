> Source: https://gforth.org/manual/Single_002dkey-input.html

<span id="Single_002dkey-input"></span>

<div class="header">

Next: [Line input and conversion](Line-input-and-conversion.html#Line-input-and-conversion), Previous: [Terminal output](Terminal-output.html#Terminal-output), Up: [Other I/O](Other-I_002fO.html#Other-I_002fO)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Single_002dkey-input-1"></span>

#### 5.19.7 Single-key input

<span id="index-single_002dkey-input"></span> <span id="index-input_002c-single_002dkey"></span>

If you want to get a single printable character, you can use `key`; to check whether a character is available for `key`, you can use `key?`.

<span id="index-key--_002d_002d-char--unknown"></span> <span id="index-key"></span> <span id="index-key-1"></span>

<div class="format">

``` format
key       – char         unknown       “key”
```

</div>

Receive (but do not display) one character, `char`.

<span id="index-key_003f--_002d_002d-flag--facility"></span> <span id="index-key_003f"></span> <span id="index-key_003f-1"></span>

<div class="format">

``` format
key?       – flag         facility       “key-question”
```

</div>

Determine whether a character is available. If a character is available, `flag` is true; the next call to `key` will yield the character. Once `key?` returns true, subsequent calls to `key?` before calling `key` or `ekey` will also return true.

If you want to process a mix of printable and non-printable characters, you can do that with `ekey` and friends. `Ekey` produces a keyboard event that you have to convert into a character with `ekey>char` or into a key identifier with `ekey>fkey`.

Typical code for using EKEY looks like this:

<div class="example">

``` example
ekey ekey>char if ( c )
  ... \ do something with the character
else ekey>fkey if ( key-id )
  case
    k-up                                  of ... endof
    k-f1                                  of ... endof
    k-left k-shift-mask or k-ctrl-mask or of ... endof
    ...
  endcase
else ( keyboard-event )
  drop \ just ignore an unknown keyboard event type
then then
```

</div>

<span id="index-ekey--_002d_002d-u--facility_002dext"></span> <span id="index-ekey"></span> <span id="index-ekey-1"></span>

<div class="format">

``` format
ekey       – u         facility-ext       “e-key”
```

</div>

Receive a keyboard event `u` (encoding implementation-defined).

<span id="index-ekey_003echar--u-_002d_002d-u-false-_007c-c-true--facility_002dext"></span> <span id="index-ekey_003echar"></span> <span id="index-ekey_003echar-1"></span>

<div class="format">

``` format
ekey>char       u – u false | c true         facility-ext       “e-key-to-char”
```

</div>

Convert keyboard event `u` into character `c` if possible.

<span id="index-ekey_003efkey--u1-_002d_002d-u2-f--X_003aekeys"></span> <span id="index-ekey_003efkey"></span> <span id="index-ekey_003efkey-1"></span>

<div class="format">

``` format
ekey>fkey       u1 – u2 f         X:ekeys       “ekey>fkey”
```

</div>

If u1 is a keyboard event in the special key set, convert keyboard event `u1` into key id `u2` and return true; otherwise return `u1` and false.

<span id="index-ekey_003f--_002d_002d-flag--facility_002dext"></span> <span id="index-ekey_003f"></span> <span id="index-ekey_003f-1"></span>

<div class="format">

``` format
ekey?       – flag         facility-ext       “e-key-question”
```

</div>

True if a keyboard event is available.

The key identifiers for cursor keys are:

<span id="index-k_002dleft--_002d_002d-u--X_003aekeys"></span> <span id="index-k_002dleft"></span> <span id="index-k_002dleft-1"></span>

<div class="format">

``` format
k-left       – u         X:ekeys       “k-left”
```

</div>

<span id="index-k_002dright--_002d_002d-u--X_003aekeys"></span> <span id="index-k_002dright"></span> <span id="index-k_002dright-1"></span>

<div class="format">

``` format
k-right       – u         X:ekeys       “k-right”
```

</div>

<span id="index-k_002dup--_002d_002d-u--X_003aekeys"></span> <span id="index-k_002dup"></span> <span id="index-k_002dup-1"></span>

<div class="format">

``` format
k-up       – u         X:ekeys       “k-up”
```

</div>

<span id="index-k_002ddown--_002d_002d-u--X_003aekeys"></span> <span id="index-k_002ddown"></span> <span id="index-k_002ddown-1"></span>

<div class="format">

``` format
k-down       – u         X:ekeys       “k-down”
```

</div>

<span id="index-k_002dhome--_002d_002d-u--X_003aekeys"></span> <span id="index-k_002dhome"></span> <span id="index-k_002dhome-1"></span>

<div class="format">

``` format
k-home       – u         X:ekeys       “k-home”
```

</div>

aka Pos1

<span id="index-k_002dend--_002d_002d-u--X_003aekeys"></span> <span id="index-k_002dend"></span> <span id="index-k_002dend-1"></span>

<div class="format">

``` format
k-end       – u         X:ekeys       “k-end”
```

</div>

<span id="index-k_002dprior--_002d_002d-u--X_003aekeys"></span> <span id="index-k_002dprior"></span> <span id="index-k_002dprior-1"></span>

<div class="format">

``` format
k-prior       – u         X:ekeys       “k-prior”
```

</div>

aka PgUp

<span id="index-k_002dnext--_002d_002d-u--X_003aekeys"></span> <span id="index-k_002dnext"></span> <span id="index-k_002dnext-1"></span>

<div class="format">

``` format
k-next       – u         X:ekeys       “k-next”
```

</div>

aka PgDn

<span id="index-k_002dinsert--_002d_002d-u--X_003aekeys"></span> <span id="index-k_002dinsert"></span> <span id="index-k_002dinsert-1"></span>

<div class="format">

``` format
k-insert       – u         X:ekeys       “k-insert”
```

</div>

<span id="index-k_002ddelete--_002d_002d-u--X_003aekeys"></span> <span id="index-k_002ddelete"></span> <span id="index-k_002ddelete-1"></span>

<div class="format">

``` format
k-delete       – u         X:ekeys       “k-delete”
```

</div>

The key identifiers for function keys (aka keypad keys) are:

<span id="index-k_002df1--_002d_002d-u--X_003aekeys"></span> <span id="index-k_002df1"></span> <span id="index-k_002df1-1"></span>

<div class="format">

``` format
k-f1       – u         X:ekeys       “k-f1”
```

</div>

<span id="index-k_002df2--_002d_002d-u--X_003aekeys"></span> <span id="index-k_002df2"></span> <span id="index-k_002df2-1"></span>

<div class="format">

``` format
k-f2       – u         X:ekeys       “k-f2”
```

</div>

<span id="index-k_002df3--_002d_002d-u--X_003aekeys"></span> <span id="index-k_002df3"></span> <span id="index-k_002df3-1"></span>

<div class="format">

``` format
k-f3       – u         X:ekeys       “k-f3”
```

</div>

<span id="index-k_002df4--_002d_002d-u--X_003aekeys"></span> <span id="index-k_002df4"></span> <span id="index-k_002df4-1"></span>

<div class="format">

``` format
k-f4       – u         X:ekeys       “k-f4”
```

</div>

<span id="index-k_002df5--_002d_002d-u--X_003aekeys"></span> <span id="index-k_002df5"></span> <span id="index-k_002df5-1"></span>

<div class="format">

``` format
k-f5       – u         X:ekeys       “k-f5”
```

</div>

<span id="index-k_002df6--_002d_002d-u--X_003aekeys"></span> <span id="index-k_002df6"></span> <span id="index-k_002df6-1"></span>

<div class="format">

``` format
k-f6       – u         X:ekeys       “k-f6”
```

</div>

<span id="index-k_002df7--_002d_002d-u--X_003aekeys"></span> <span id="index-k_002df7"></span> <span id="index-k_002df7-1"></span>

<div class="format">

``` format
k-f7       – u         X:ekeys       “k-f7”
```

</div>

<span id="index-k_002df8--_002d_002d-u--X_003aekeys"></span> <span id="index-k_002df8"></span> <span id="index-k_002df8-1"></span>

<div class="format">

``` format
k-f8       – u         X:ekeys       “k-f8”
```

</div>

<span id="index-k_002df9--_002d_002d-u--X_003aekeys"></span> <span id="index-k_002df9"></span> <span id="index-k_002df9-1"></span>

<div class="format">

``` format
k-f9       – u         X:ekeys       “k-f9”
```

</div>

<span id="index-k_002df10--_002d_002d-u--X_003aekeys"></span> <span id="index-k_002df10"></span> <span id="index-k_002df10-1"></span>

<div class="format">

``` format
k-f10       – u         X:ekeys       “k-f10”
```

</div>

<span id="index-k_002df11--_002d_002d-u--X_003aekeys"></span> <span id="index-k_002df11"></span> <span id="index-k_002df11-1"></span>

<div class="format">

``` format
k-f11       – u         X:ekeys       “k-f11”
```

</div>

<span id="index-k_002df12--_002d_002d-u--X_003aekeys"></span> <span id="index-k_002df12"></span> <span id="index-k_002df12-1"></span>

<div class="format">

``` format
k-f12       – u         X:ekeys       “k-f12”
```

</div>

Note that `k-f11` and `k-f12` are not as widely available.

You can combine these key identifiers with masks for various shift keys:

<span id="index-k_002dshift_002dmask--_002d_002d-u--X_003aekeys"></span> <span id="index-k_002dshift_002dmask"></span> <span id="index-k_002dshift_002dmask-1"></span>

<div class="format">

``` format
k-shift-mask       – u         X:ekeys       “k-shift-mask”
```

</div>

<span id="index-k_002dctrl_002dmask--_002d_002d-u--X_003aekeys"></span> <span id="index-k_002dctrl_002dmask"></span> <span id="index-k_002dctrl_002dmask-1"></span>

<div class="format">

``` format
k-ctrl-mask       – u         X:ekeys       “k-ctrl-mask”
```

</div>

<span id="index-k_002dalt_002dmask--_002d_002d-u--X_003aekeys"></span> <span id="index-k_002dalt_002dmask"></span> <span id="index-k_002dalt_002dmask-1"></span>

<div class="format">

``` format
k-alt-mask       – u         X:ekeys       “k-alt-mask”
```

</div>

Note that, even if a Forth system has `ekey>fkey` and the key identifier words, the keys are not necessarily available or it may not necessarily be able to report all the keys and all the possible combinations with shift masks. Therefore, write your programs in such a way that they are still useful even if the keys and key combinations cannot be pressed or are not recognized.

Examples: Older keyboards often do not have an F11 and F12 key. If you run Gforth in an xterm, the xterm catches a number of combinations (e.g., `Shift-Up`), and never passes it to Gforth. Finally, Gforth currently does not recognize and report combinations with multiple shift keys (so the `shift-ctrl-left` case in the example above would never be entered).

Gforth recognizes various keys available on ANSI terminals (in MS-DOS you need the ANSI.SYS driver to get that behaviour); it works by recognizing the escape sequences that ANSI terminals send when such a key is pressed. If you have a terminal that sends other escape sequences, you will not get useful results on Gforth. Other Forth systems may work in a different way.

Gforth also provides a few words for outputting names of function keys:

<span id="index-fkey_002e--u-_002d_002d--gforth"></span> <span id="index-fkey_002e"></span> <span id="index-fkey_002e-1"></span>

<div class="format">

``` format
fkey.       u –         gforth       “fkey-dot”
```

</div>

Print a string representation for the function key *u*. *U* must be a function key (possibly with modifier masks), otherwise there may be an exception.

<span id="index-simple_002dfkey_002dstring--u1-_002d_002d-c_002daddr-u--gforth"></span> <span id="index-simple_002dfkey_002dstring"></span> <span id="index-simple_002dfkey_002dstring-1"></span>

<div class="format">

``` format
simple-fkey-string       u1 – c-addr u         gforth       “simple-fkey-string”
```

</div>

*c-addr u* is the string name of the function key *u1*. Only works for simple function keys without modifier masks. Any *u1* that does not correspond to a simple function key currently produces an exception.

-----

<div class="header">

Next: [Line input and conversion](Line-input-and-conversion.html#Line-input-and-conversion), Previous: [Terminal output](Terminal-output.html#Terminal-output), Up: [Other I/O](Other-I_002fO.html#Other-I_002fO)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
