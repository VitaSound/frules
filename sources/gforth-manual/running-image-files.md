> Source: https://gforth.org/manual/Running-Image-Files.html

<span id="Running-Image-Files"></span>

<div class="header">

Next: [Modifying the Startup Sequence](Modifying-the-Startup-Sequence.html#Modifying-the-Startup-Sequence), Previous: [Stack and Dictionary Sizes](Stack-and-Dictionary-Sizes.html#Stack-and-Dictionary-Sizes), Up: [Image Files](Image-Files.html#Image-Files)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Running-Image-Files-1"></span>

### 13.7 Running Image Files

<span id="index-running-image-files"></span> <span id="index-invoking-image-files"></span> <span id="index-image-file-invocation"></span> <span id="index-_002di_002c-invoke-image-file"></span> <span id="index-_002d_002dimage-file_002c-invoke-image-file"></span>

You can invoke Gforth with an image file *image* instead of the default `gforth.fi` with the `-i` flag (see [Invoking Gforth](Invoking-Gforth.html#Invoking-Gforth)):

<div class="example">

``` example
gforth -i image
```

</div>

<span id="index-executable-image-file"></span> <span id="index-image-file_002c-executable"></span>

If your operating system supports starting scripts with a line of the form `#! ...`, you just have to type the image file name to start Gforth with this image file (note that the file extension `.fi` is just a convention). I.e., to run Gforth with the image file *image*, you can just type *image* instead of `gforth -i image`. This works because every `.fi` file starts with a line of this format:

<div class="example">

``` example
#! /usr/local/bin/gforth-0.4.0 -i
```

</div>

The file and pathname for the Gforth engine specified on this line is the specific Gforth executable that it was built against; i.e. the value of the environment variable `GFORTH` at the time that `gforthmi` was executed.

You can make use of the same shell capability to make a Forth source file into an executable. For example, if you place this text in a file:

<div class="example">

``` example
#! /usr/local/bin/gforth

." Hello, world" CR
bye
```

</div>

and then make the file executable (chmod +x in Unix), you can run it directly from the command line. The sequence `#!` is used in two ways; firstly, it is recognised as a “magic sequence” by the operating system[<sup>38</sup>](#FOOT38) secondly it is treated as a comment character by Gforth. Because of the second usage, a space is required between `#!` and the path to the executable (moreover, some Unixes require the sequence `#! /`).

Most Unix systems (including Linux) support exactly one option after the binary name. If that is not enough, you can use the following trick:

<div class="example">

``` example
#! /bin/sh
: ## ; 0 [if]
exec gforth -m 10M -d 1M $0 "$@"
[then]
." Hello, world" cr
bye \ caution: this prevents (further) processing of "$@"
```

</div>

First this script is interpreted as shell script, which treats the first two lines as (mostly) comments, then performs the third line, which invokes gforth with this script (`$0`) as parameter and its parameters as additional parameters (`"$@"`). Then this script is interpreted as Forth script, which first defines a colon definition `##`, then ignores everything up to `[then]` and finally processes the following Forth code. You can also use

<div class="example">

``` example
#0 [if]
```

</div>

in the second line, but this works only in Gforth-0.7.0 and later.

The `gforthmi` approach is the fastest one, the shell-based one is slowest (needs to start an additional shell). An additional advantage of the shell approach is that it is unnecessary to know where the Gforth binary resides, as long as it is in the `$PATH`.

<span id="index-_0023_0021--_002d_002d--gforth"></span> <span id="index-_0023_0021"></span> <span id="index-_0023_0021-1"></span>

<div class="format">

``` format
#!       –         gforth       “hash-bang”
```

</div>

An alias for `\`

<div class="footnote">

-----

#### Footnotes

### [(38)](#DOCF38)

The Unix kernel actually recognises two types of files: executable files and files of data, where the data is processed by an interpreter that is specified on the “interpreter line” – the first line of the file, starting with the sequence \#\!. There may be a small limit (e.g., 32) on the number of characters that may be specified on the interpreter line.

</div>

-----

<div class="header">

Next: [Modifying the Startup Sequence](Modifying-the-Startup-Sequence.html#Modifying-the-Startup-Sequence), Previous: [Stack and Dictionary Sizes](Stack-and-Dictionary-Sizes.html#Stack-and-Dictionary-Sizes), Up: [Image Files](Image-Files.html#Image-Files)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
