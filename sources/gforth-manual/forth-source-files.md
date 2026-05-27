> Source: https://gforth.org/manual/Forth-source-files.html

<span id="Forth-source-files"></span>

<div class="header">

Next: [General files](General-files.html#General-files), Previous: [Files](Files.html#Files), Up: [Files](Files.html#Files)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Forth-source-files-1"></span>

#### 5.17.1 Forth source files

<span id="index-including-files"></span> <span id="index-Forth-source-files"></span>

The simplest way to interpret the contents of a file is to use one of these two formats:

<div class="example">

``` example
include mysource.fs
s" mysource.fs" included
```

</div>

You usually want to include a file only if it is not included already (by, say, another source file). In that case, you can use one of these three formats:

<div class="example">

``` example
require mysource.fs
needs mysource.fs
s" mysource.fs" required
```

</div>

<span id="index-stack-effect-of-included-files"></span> <span id="index-including-files_002c-stack-effect"></span>

It is good practice to write your source files such that interpreting them does not change the stack. Source files designed in this way can be used with `required` and friends without complications. For example:

<div class="example">

``` example
1024 require foo.fs drop
```

</div>

Here you want to pass the argument 1024 (e.g., a buffer size) to `foo.fs`. Interpreting `foo.fs` has the stack effect ( n – n ), which allows its use with `require`. Of course with such parameters to required files, you have to ensure that the first `require` fits for all uses (i.e., `require` it early in the master load file).

<span id="index-include_002dfile--i_002ax-wfileid-_002d_002d-j_002ax--file"></span> <span id="index-include_002dfile"></span> <span id="index-include_002dfile-1"></span>

<div class="format">

``` format
include-file       i*x wfileid – j*x         file       “include-file”
```

</div>

Interpret (process using the text interpreter) the contents of the file `wfileid`.

<span id="index-included--i_002ax-c_002daddr-u-_002d_002d-j_002ax--file"></span> <span id="index-included"></span> <span id="index-included-1"></span>

<div class="format">

``` format
included       i*x c-addr u – j*x         file       “included”
```

</div>

`include-file` the file whose name is given by the string `c-addr u`.

<span id="index-included_003f--c_002daddr-u-_002d_002d-f--gforth"></span> <span id="index-included_003f"></span> <span id="index-included_003f-1"></span>

<div class="format">

``` format
included?       c-addr u – f         gforth       “included?”
```

</div>

True only if the file `c-addr u` is in the list of earlier included files. If the file has been loaded, it may have been specified as, say, `foo.fs` and found somewhere on the Forth search path. To return `true` from `included?`, you must specify the exact path to the file, even if that is `./foo.fs`

<span id="index-include--_002e_002e_002e-_0022file_0022-_002d_002d-_002e_002e_002e--gforth"></span> <span id="index-include"></span> <span id="index-include-1"></span>

<div class="format">

``` format
include       ... "file" – ...         gforth       “include”
```

</div>

`include-file` the file `file`.

<span id="index-required--i_002ax-addr-u-_002d_002d-i_002ax--gforth"></span> <span id="index-required"></span> <span id="index-required-1"></span>

<div class="format">

``` format
required       i*x addr u – i*x         gforth       “required”
```

</div>

`include-file` the file with the name given by `addr u`, if it is not `included` (or `required`) already. Currently this works by comparing the name of the file (with path) against the names of earlier included files.

<span id="index-require--_002e_002e_002e-_0022file_0022-_002d_002d-_002e_002e_002e--gforth"></span> <span id="index-require"></span> <span id="index-require-1"></span>

<div class="format">

``` format
require       ... "file" – ...         gforth       “require”
```

</div>

`include-file` `file` only if it is not included already.

<span id="index-needs--_002e_002e_002e-_0022name_0022-_002d_002d-_002e_002e_002e--gforth"></span> <span id="index-needs"></span> <span id="index-needs-1"></span>

<div class="format">

``` format
needs       ... "name" – ...         gforth       “needs”
```

</div>

An alias for `require`; exists on other systems (e.g., Win32Forth).

<span id="index-sourcefilename--_002d_002d-c_002daddr-u--gforth"></span> <span id="index-sourcefilename"></span> <span id="index-sourcefilename-1"></span>

<div class="format">

``` format
sourcefilename       – c-addr u         gforth       “sourcefilename”
```

</div>

The name of the source file which is currently the input source. The result is valid only while the file is being loaded. If the current input source is no (stream) file, the result is undefined. In Gforth, the result is valid during the whole session (but not across `savesystem` etc.).

<span id="index-sourceline_0023--_002d_002d-u--gforth"></span> <span id="index-sourceline_0023"></span> <span id="index-sourceline_0023-1"></span>

<div class="format">

``` format
sourceline#       – u         gforth       “sourceline-number”
```

</div>

The line number of the line that is currently being interpreted from a (stream) file. The first line has the number 1. If the current input source is not a (stream) file, the result is undefined.

A definition in Standard Forth for `required` is provided in `compat/required.fs`.

-----

<div class="header">

Next: [General files](General-files.html#General-files), Previous: [Files](Files.html#Files), Up: [Files](Files.html#Files)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
