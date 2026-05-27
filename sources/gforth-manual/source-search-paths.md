> Source: https://gforth.org/manual/Source-Search-Paths.html

<span id="Source-Search-Paths"></span>

<div class="header">

Next: [General Search Paths](General-Search-Paths.html#General-Search-Paths), Previous: [Search Paths](Search-Paths.html#Search-Paths), Up: [Search Paths](Search-Paths.html#Search-Paths)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Source-Search-Paths-1"></span>

#### 5.17.5.1 Source Search Paths

<span id="index-search-path-control_002c-source-files"></span>

The search path is initialized when you start Gforth (see [Invoking Gforth](Invoking-Gforth.html#Invoking-Gforth)). You can display it and change it using `fpath` in combination with the general path handling words.

<span id="index-fpath--_002d_002d-path_002daddr--gforth"></span> <span id="index-fpath"></span> <span id="index-fpath-1"></span>

<div class="format">

``` format
fpath       – path-addr         gforth       “fpath”
```

</div>

Here is an example of using `fpath` and `require`:

<div class="example">

``` example
fpath path= /usr/lib/forth/|./
require timer.fs
```

</div>
