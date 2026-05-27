> Source: https://gforth.org/manual/Modifying-the-Startup-Sequence.html

<span id="Modifying-the-Startup-Sequence"></span>

<div class="header">

Previous: [Running Image Files](Running-Image-Files.html#Running-Image-Files), Up: [Image Files](Image-Files.html#Image-Files)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Modifying-the-Startup-Sequence-1"></span>

### 13.8 Modifying the Startup Sequence

<span id="index-startup-sequence-for-image-file"></span> <span id="index-image-file-initialization-sequence"></span> <span id="index-initialization-sequence-of-image-file"></span>

You can add your own initialization to the startup sequence of an image through the deferred word `'cold`. `'cold` is invoked just before the image-specific command line processing (i.e., loading files and evaluating (`-e`) strings) starts.

A sequence for adding your initialization usually looks like this:

<div class="example">

``` example
:noname
    Defers 'cold \ do other initialization stuff (e.g., rehashing wordlists)
    ... \ your stuff
; IS 'cold
```

</div>

After `'cold`, Gforth processes the image options (see [Invoking Gforth](Invoking-Gforth.html#Invoking-Gforth)), and then it performs `bootmessage`, another deferred word. This normally prints Gforth’s startup message and does nothing else.

<span id="index-turnkey-image-files"></span> <span id="index-image-file_002c-turnkey-applications"></span>

So, if you want to make a turnkey image (i.e., an image for an application instead of an extended Forth system), you can do this in two ways:

  - If you want to do your interpretation of the OS command-line arguments, hook into `'cold`. In that case you probably also want to build the image with `gforthmi --application` (see [gforthmi](gforthmi.html#gforthmi)) to keep the engine from processing OS command line options. You can then do your own command-line processing with `next-arg`
  - If you want to have the normal Gforth processing of OS command-line arguments, hook into `bootmessage`.

In either case, you probably do not want the word that you execute in these hooks to exit normally, but use `bye` or `throw`. Otherwise the Gforth startup process would continue and eventually present the Forth command line to the user.

<span id="index-_0027cold--_002d_002d--gforth"></span> <span id="index-_0027cold"></span> <span id="index-_0027cold-1"></span>

<div class="format">

``` format
'cold       –         gforth       “tick-cold”
```

</div>

Hook (deferred word) for things to do right before interpreting the OS command-line arguments. Normally does some initializations that you also want to perform.

<span id="index-bootmessage--_002d_002d--gforth"></span> <span id="index-bootmessage"></span> <span id="index-bootmessage-1"></span>

<div class="format">

``` format
bootmessage       –         gforth       “bootmessage”
```

</div>

Hook (deferred word) executed right after interpreting the OS command-line arguments. Normally prints the Gforth startup message.

-----

<div class="header">

Previous: [Running Image Files](Running-Image-Files.html#Running-Image-Files), Up: [Image Files](Image-Files.html#Image-Files)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
