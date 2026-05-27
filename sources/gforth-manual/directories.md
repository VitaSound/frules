> Source: https://gforth.org/manual/Directories.html

<span id="Directories"></span>

<div class="header">

Next: [Search Paths](Search-Paths.html#Search-Paths), Previous: [Redirection](Redirection.html#Redirection), Up: [Files](Files.html#Files)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Directories-1"></span>

#### 5.17.4 Directories

<span id="index-Directories"></span>

You can open and read directories similar to files. Reading gives you one directory entry at a time; you can match that to a filename (with wildcards).

<span id="index-open_002ddir--c_002daddr-u-_002d_002d-wdirid-wior--gforth"></span> <span id="index-open_002ddir"></span> <span id="index-open_002ddir-1"></span>

<div class="format">

``` format
open-dir       c-addr u – wdirid wior        gforth       “open-dir”
```

</div>

Open the directory specified by *c-addr, u* and return *dir-id* for futher access to it.

<span id="index-read_002ddir--c_002daddr-u1-wdirid-_002d_002d-u2-flag-wior--gforth"></span> <span id="index-read_002ddir"></span> <span id="index-read_002ddir-1"></span>

<div class="format">

``` format
read-dir       c-addr u1 wdirid – u2 flag wior        gforth       “read-dir”
```

</div>

Attempt to read the next entry from the directory specified by *dir-id* to the buffer of length *u1* at address *c-addr*. If the attempt fails because there is no more entries, *ior*=0, *flag*=0, *u2*=0, and the buffer is unmodified. If the attempt to read the next entry fails because of any other reason, return *ior*\<\>0. If the attempt succeeds, store file name to the buffer at *c-addr* and return *ior*=0, *flag*=true and *u2* equal to the size of the file name. If the length of the file name is greater than *u1*, store first *u1* characters from file name into the buffer and indicate "name too long" with *ior*, *flag*=true, and *u2*=*u1*.

<span id="index-close_002ddir--wdirid-_002d_002d-wior--gforth"></span> <span id="index-close_002ddir"></span> <span id="index-close_002ddir-1"></span>

<div class="format">

``` format
close-dir       wdirid – wior        gforth       “close-dir”
```

</div>

Close the directory specified by *dir-id*.

<span id="index-filename_002dmatch--c_002daddr1-u1-c_002daddr2-u2-_002d_002d-flag--gforth"></span> <span id="index-filename_002dmatch"></span> <span id="index-filename_002dmatch-1"></span>

<div class="format">

``` format
filename-match       c-addr1 u1 c-addr2 u2 – flag        gforth       “match-file”
```

</div>

<span id="index-get_002ddir--c_002daddr1-u1-_002d_002d-c_002daddr2-u2--gforth"></span> <span id="index-get_002ddir"></span> <span id="index-get_002ddir-1"></span>

<div class="format">

``` format
get-dir       c-addr1 u1 – c-addr2 u2        gforth       “get-dir”
```

</div>

Store the current directory in the buffer specified by *c-addr1, u1*. If the buffer size is not sufficient, return 0 0

<span id="index-set_002ddir--c_002daddr-u-_002d_002d-wior--gforth"></span> <span id="index-set_002ddir"></span> <span id="index-set_002ddir-1"></span>

<div class="format">

``` format
set-dir       c-addr u – wior        gforth       “set-dir”
```

</div>

Change the current directory to *c-addr, u*. Return an error if this is not possible

<span id="index-_003dmkdir--c_002daddr-u-wmode-_002d_002d-wior--gforth"></span> <span id="index-_003dmkdir"></span> <span id="index-_003dmkdir-1"></span>

<div class="format">

``` format
=mkdir       c-addr u wmode – wior        gforth       “equals-mkdir”
```

</div>

Create directory *c-addr u* with mode *wmode*.

<span id="index-mkdir_002dparents--c_002daddr-u-mode-_002d_002d-ior--unknown"></span> <span id="index-mkdir_002dparents"></span> <span id="index-mkdir_002dparents-1"></span>

<div class="format">

``` format
mkdir-parents       c-addr u mode – ior         unknown       “mkdir-parents”
```

</div>

create the directory *c-addr u* and all its parents with mode *mode* (modified by umask)

-----

<div class="header">

Next: [Search Paths](Search-Paths.html#Search-Paths), Previous: [Redirection](Redirection.html#Redirection), Up: [Files](Files.html#Files)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
