> Source: https://gforth.org/manual/General-Search-Paths.html

<span id="General-Search-Paths"></span>

<div class="header">

Previous: [Source Search Paths](Source-Search-Paths.html#Source-Search-Paths), Up: [Search Paths](Search-Paths.html#Search-Paths)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="General-Search-Paths-1"></span>

#### 5.17.5.2 General Search Paths

<span id="index-search-path-control_002c-source-files-1"></span>

Your application may need to search files in several directories, like `included` does. To facilitate this, Gforth allows you to define and use your own search paths, by providing generic equivalents of the Forth search path words:

<span id="index-open_002dpath_002dfile--addr1-u1-path_002daddr-_002d_002d-wfileid-addr2-u2-0-_007c-ior--gforth"></span> <span id="index-open_002dpath_002dfile"></span> <span id="index-open_002dpath_002dfile-1"></span>

<div class="format">

``` format
open-path-file       addr1 u1 path-addr – wfileid addr2 u2 0 | ior         gforth       “open-path-file”
```

</div>

Look in path `path-addr` for the file specified by `addr1 u1`. If found, the resulting path and and (read-only) open file descriptor are returned. If the file is not found, `ior` is what came back from the last attempt at opening the file (in the current implementation).

doc-path-allot <span id="index-clear_002dpath--path_002daddr-_002d_002d--gforth"></span> <span id="index-clear_002dpath"></span> <span id="index-clear_002dpath-1"></span>

<div class="format">

``` format
clear-path       path-addr –         gforth       “clear-path”
```

</div>

Set the path *path-addr* to empty.

<span id="index-also_002dpath--c_002daddr-len-path_002daddr-_002d_002d--gforth"></span> <span id="index-also_002dpath"></span> <span id="index-also_002dpath-1"></span>

<div class="format">

``` format
also-path       c-addr len path-addr –         gforth       “also-path”
```

</div>

add the directory *c-addr len* to *path-addr*.

<span id="index-_002epath--path_002daddr-_002d_002d--gforth"></span> <span id="index-_002epath"></span> <span id="index-_002epath-1"></span>

<div class="format">

``` format
.path       path-addr –         gforth       “.path”
```

</div>

Display the contents of the search path `path-addr`.

<span id="index-path_002b--path_002daddr-_0022dir_0022-_002d_002d--gforth"></span> <span id="index-path_002b"></span> <span id="index-path_002b-1"></span>

<div class="format">

``` format
path+       path-addr  "dir" –         gforth       “path+”
```

</div>

Add the directory `dir` to the search path `path-addr`.

<span id="index-path_003d--path_002daddr-_0022dir1_007cdir2_007cdir3_0022--gforth"></span> <span id="index-path_003d"></span> <span id="index-path_003d-1"></span>

<div class="format">

``` format
path=       path-addr "dir1|dir2|dir3"         gforth       “path=”
```

</div>

Make a complete new search path; the path separator is |.

Here’s an example of creating an empty search path:

<div class="example">

``` example
create mypath 500 path-allot \ maximum length 500 chars (is checked)
```

</div>

-----

<div class="header">

Previous: [Source Search Paths](Source-Search-Paths.html#Source-Search-Paths), Up: [Search Paths](Search-Paths.html#Search-Paths)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
