> Source: https://gforth.org/manual/General-files.html

<span id="General-files"></span>

<div class="header">

Next: [Redirection](Redirection.html#Redirection), Previous: [Forth source files](Forth-source-files.html#Forth-source-files), Up: [Files](Files.html#Files)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="General-files-1"></span>

#### 5.17.2 General files

<span id="index-general-files"></span> <span id="index-file_002dhandling"></span>

Files are opened/created by name and type. The following file access methods (FAMs) are recognised:

<span id="index-fam-_0028file-access-method_0029"></span> <span id="index-r_002fo--_002d_002d-fam--file"></span> <span id="index-r_002fo"></span> <span id="index-r_002fo-1"></span>

<div class="format">

``` format
r/o       – fam         file       “r-o”
```

</div>

<span id="index-r_002fw--_002d_002d-fam--file"></span> <span id="index-r_002fw"></span> <span id="index-r_002fw-1"></span>

<div class="format">

``` format
r/w       – fam         file       “r-w”
```

</div>

<span id="index-w_002fo--_002d_002d-fam--file"></span> <span id="index-w_002fo"></span> <span id="index-w_002fo-1"></span>

<div class="format">

``` format
w/o       – fam         file       “w-o”
```

</div>

<span id="index-bin--fam1-_002d_002d-fam2--file"></span> <span id="index-bin"></span> <span id="index-bin-1"></span>

<div class="format">

``` format
bin       fam1 – fam2         file       “bin”
```

</div>

When a file is opened/created, it returns a file identifier, *wfileid* that is used for all other file commands. All file commands also return a status value, *wior*, that is 0 for a successful operation and an implementation-defined non-zero value in the case of an error.

<span id="index-open_002dfile--c_002daddr-u-wfam-_002d_002d-wfileid-wior--file"></span> <span id="index-open_002dfile"></span> <span id="index-open_002dfile-1"></span>

<div class="format">

``` format
open-file       c-addr u wfam – wfileid wior        file       “open-file”
```

</div>

<span id="index-create_002dfile--c_002daddr-u-wfam-_002d_002d-wfileid-wior--file"></span> <span id="index-create_002dfile"></span> <span id="index-create_002dfile-1"></span>

<div class="format">

``` format
create-file       c-addr u wfam – wfileid wior        file       “create-file”
```

</div>

<span id="index-close_002dfile--wfileid-_002d_002d-wior--file"></span> <span id="index-close_002dfile"></span> <span id="index-close_002dfile-1"></span>

<div class="format">

``` format
close-file       wfileid – wior        file       “close-file”
```

</div>

<span id="index-delete_002dfile--c_002daddr-u-_002d_002d-wior--file"></span> <span id="index-delete_002dfile"></span> <span id="index-delete_002dfile-1"></span>

<div class="format">

``` format
delete-file       c-addr u – wior        file       “delete-file”
```

</div>

<span id="index-rename_002dfile--c_002daddr1-u1-c_002daddr2-u2-_002d_002d-wior--file_002dext"></span> <span id="index-rename_002dfile"></span> <span id="index-rename_002dfile-1"></span>

<div class="format">

``` format
rename-file       c-addr1 u1 c-addr2 u2 – wior        file-ext       “rename-file”
```

</div>

Rename file *c\_addr1 u1* to new name *c\_addr2 u2*

<span id="index-read_002dfile--c_002daddr-u1-wfileid-_002d_002d-u2-wior--file"></span> <span id="index-read_002dfile"></span> <span id="index-read_002dfile-1"></span>

<div class="format">

``` format
read-file       c-addr u1 wfileid – u2 wior        file       “read-file”
```

</div>

<span id="index-read_002dline--c_005faddr-u1-wfileid-_002d_002d-u2-flag-wior--file"></span> <span id="index-read_002dline"></span> <span id="index-read_002dline-1"></span>

<div class="format">

``` format
read-line       c_addr u1 wfileid – u2 flag wior         file       “read-line”
```

</div>

<span id="index-key_002dfile--fd-_002d_002d-key--unknown"></span> <span id="index-key_002dfile"></span> <span id="index-key_002dfile-1"></span>

<div class="format">

``` format
key-file       fd – key         unknown       “key-file”
```

</div>

Read one character *n* from *wfileid*. This word disables buffering for *wfileid*. If you want to read characters from a terminal in non-canonical (raw) mode, you have to put the terminal in non-canonical mode yourself (using the C interface); the exception is `stdin`: Gforth automatically puts it into non-canonical mode.

<span id="index-key_003f_002dfile--wfileid-_002d_002d-f--gforth"></span> <span id="index-key_003f_002dfile"></span> <span id="index-key_003f_002dfile-1"></span>

<div class="format">

``` format
key?-file       wfileid – f        gforth       “key-q-file”
```

</div>

*f* is true if at least one character can be read from *wfileid* without blocking. If you also want to use `read-file` or `read-line` on the file, you have to call `key?-file` or `key-file` first (these two words disable buffering).

<span id="index-write_002dfile--c_002daddr-u1-wfileid-_002d_002d-wior--file"></span> <span id="index-write_002dfile"></span> <span id="index-write_002dfile-1"></span>

<div class="format">

``` format
write-file       c-addr u1 wfileid – wior        file       “write-file”
```

</div>

<span id="index-write_002dline--c_002daddr-u-wfileid-_002d_002d-ior--file"></span> <span id="index-write_002dline"></span> <span id="index-write_002dline-1"></span>

<div class="format">

``` format
write-line       c-addr u wfileid – ior         file       “write-line”
```

</div>

<span id="index-emit_002dfile--c-wfileid-_002d_002d-wior--gforth"></span> <span id="index-emit_002dfile"></span> <span id="index-emit_002dfile-1"></span>

<div class="format">

``` format
emit-file       c wfileid – wior        gforth       “emit-file”
```

</div>

<span id="index-flush_002dfile--wfileid-_002d_002d-wior--file_002dext"></span> <span id="index-flush_002dfile"></span> <span id="index-flush_002dfile-1"></span>

<div class="format">

``` format
flush-file       wfileid – wior        file-ext       “flush-file”
```

</div>

<span id="index-file_002dstatus--c_002daddr-u-_002d_002d-wfam-wior--file_002dext"></span> <span id="index-file_002dstatus"></span> <span id="index-file_002dstatus-1"></span>

<div class="format">

``` format
file-status       c-addr u – wfam wior        file-ext       “file-status”
```

</div>

<span id="index-file_002dposition--wfileid-_002d_002d-ud-wior--file"></span> <span id="index-file_002dposition"></span> <span id="index-file_002dposition-1"></span>

<div class="format">

``` format
file-position       wfileid – ud wior        file       “file-position”
```

</div>

<span id="index-reposition_002dfile--ud-wfileid-_002d_002d-wior--file"></span> <span id="index-reposition_002dfile"></span> <span id="index-reposition_002dfile-1"></span>

<div class="format">

``` format
reposition-file       ud wfileid – wior        file       “reposition-file”
```

</div>

<span id="index-file_002dsize--wfileid-_002d_002d-ud-wior--file"></span> <span id="index-file_002dsize"></span> <span id="index-file_002dsize-1"></span>

<div class="format">

``` format
file-size       wfileid – ud wior        file       “file-size”
```

</div>

<span id="index-resize_002dfile--ud-wfileid-_002d_002d-wior--file"></span> <span id="index-resize_002dfile"></span> <span id="index-resize_002dfile-1"></span>

<div class="format">

``` format
resize-file       ud wfileid – wior        file       “resize-file”
```

</div>

<span id="index-slurp_002dfile--c_002daddr1-u1-_002d_002d-c_002daddr2-u2--gforth"></span> <span id="index-slurp_002dfile"></span> <span id="index-slurp_002dfile-1"></span>

<div class="format">

``` format
slurp-file       c-addr1 u1 – c-addr2 u2         gforth       “slurp-file”
```

</div>

`c-addr1 u1` is the filename, `c-addr2 u2` is the file’s contents

<span id="index-slurp_002dfid--fid-_002d_002d-addr-u--gforth"></span> <span id="index-slurp_002dfid"></span> <span id="index-slurp_002dfid-1"></span>

<div class="format">

``` format
slurp-fid       fid – addr u         gforth       “slurp-fid”
```

</div>

`addr u` is the content of the file `fid`

<span id="index-stdin--_002d_002d-wfileid--gforth"></span> <span id="index-stdin"></span> <span id="index-stdin-1"></span>

<div class="format">

``` format
stdin       – wfileid        gforth       “stdin”
```

</div>

The standard input file of the Gforth process.

<span id="index-stdout--_002d_002d-wfileid--gforth"></span> <span id="index-stdout"></span> <span id="index-stdout-1"></span>

<div class="format">

``` format
stdout       – wfileid        gforth       “stdout”
```

</div>

The standard output file of the Gforth process.

<span id="index-stderr--_002d_002d-wfileid--gforth"></span> <span id="index-stderr"></span> <span id="index-stderr-1"></span>

<div class="format">

``` format
stderr       – wfileid        gforth       “stderr”
```

</div>

The standard error output file of the Gforth process.

-----

<div class="header">

Next: [Redirection](Redirection.html#Redirection), Previous: [Forth source files](Forth-source-files.html#Forth-source-files), Up: [Files](Files.html#Files)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
