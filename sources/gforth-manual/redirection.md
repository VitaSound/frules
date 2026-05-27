> Source: https://gforth.org/manual/Redirection.html

<span id="Redirection"></span>

<div class="header">

Next: [Directories](Directories.html#Directories), Previous: [General files](General-files.html#General-files), Up: [Files](Files.html#Files)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Redirection-1"></span>

#### 5.17.3 Redirection

<span id="index-Redirection"></span> <span id="index-Input-Redirection"></span> <span id="index-Output-Redirection"></span>

You can redirect the output of `type` and `emit` and all the words that use them (all output words that don’t have an explicit target file) to an arbitrary file with the `outfile-execute`, used like this:

<div class="example">

``` example
: some-warning ( n -- )
    cr ." warning# " . ;

: print-some-warning ( n -- )
    ['] some-warning stderr outfile-execute ;
```

</div>

After `some-warning` is executed, the original output direction is restored; this construct is safe against exceptions. Similarly, there is `infile-execute` for redirecting the input of `key` and its users (any input word that does not take a file explicitly).

<span id="index-outfile_002dexecute--_002e_002e_002e-xt-file_002did-_002d_002d-_002e_002e_002e--gforth"></span> <span id="index-outfile_002dexecute"></span> <span id="index-outfile_002dexecute-1"></span>

<div class="format">

``` format
outfile-execute       ... xt file-id – ...         gforth       “outfile-execute”
```

</div>

execute *xt* with the output of `type` etc. redirected to *file-id*.

<span id="index-infile_002dexecute--_002e_002e_002e-xt-file_002did-_002d_002d-_002e_002e_002e--gforth"></span> <span id="index-infile_002dexecute"></span> <span id="index-infile_002dexecute-1"></span>

<div class="format">

``` format
infile-execute       ... xt file-id – ...         gforth       “infile-execute”
```

</div>

execute *xt* with the input of `key` etc. redirected to *file-id*.

If you do not want to redirect the input or output to a file, you can also make use of the fact that `key`, `emit` and `type` are deferred words (see [Deferred Words](Deferred-Words.html#Deferred-Words)). However, in that case you have to worry about the restoration and the protection against exceptions yourself; also, note that for redirecting the output in this way, you have to redirect both `emit` and `type`.
