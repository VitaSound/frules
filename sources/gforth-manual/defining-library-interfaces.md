> Source: https://gforth.org/manual/Defining-library-interfaces.html

<span id="Defining-library-interfaces"></span>

<div class="header">

Next: [Declaring OS-level libraries](Declaring-OS_002dlevel-libraries.html#Declaring-OS_002dlevel-libraries), Previous: [Calling C function pointers](Calling-C-function-pointers.html#Calling-C-function-pointers), Up: [C Interface](C-Interface.html#C-Interface)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Defining-library-interfaces-1"></span>

#### 5.26.4 Defining library interfaces

<span id="index-giving-a-name-to-a-library-interface"></span> <span id="index-library-interface-names"></span>

You can give a name to a bunch of C function declarations (a library interface), as follows:

<div class="example">

``` example
c-library lseek-lib
\c #define _FILE_OFFSET_BITS 64
...
end-c-library
```

</div>

The effect of giving such a name to the interface is that the names of the generated files will contain that name, and when you use the interface a second time, it will use the existing files instead of generating and compiling them again, saving you time. The generated file contains a 128 bit hash (not cryptographically safe, but good enough for that purpose) of the source code, so changing the declarations will cause a new compilation. Normally these files are cached in `$HOME/.gforth/``architecture``/libcc-named`, so if you experience problems or have other reasons to force a recompilation, you can delete the files there.

Note that you should use `c-library` before everything else having anything to do with that library, as it resets some setup stuff. The idea is that the typical use is to put each `c-library`...`end-c-library` unit in its own file, and to be able to include these files in any order. All other words dealing with the C interface are hidden in the vocabulary `c-lib`, which is put on top o the search stack by `c-library` and removed by `end-c-library`.

Note that the library name is not allocated in the dictionary and therefore does not shadow dictionary names. It is used in the file system, so you have to use naming conventions appropriate for file systems. The name is also used as part of the C symbols, but characters outside the legal C symbol names are replaced with underscores. Also, you shall not call a function you declare after `c-library` before you perform `end-c-library`.

A major benefit of these named library interfaces is that, once they are generated, the tools used to generated them (in particular, the C compiler and libtool) are no longer needed, so the interface can be used even on machines that do not have the tools installed. The build system of Gforth can even cross-compile these libraries, so that the libraries are available for plattforms on which build tools aren’t installed.

<span id="index-c_002dlibrary_002dname--c_002daddr-u-_002d_002d--gforth"></span> <span id="index-c_002dlibrary_002dname"></span> <span id="index-c_002dlibrary_002dname-1"></span>

<div class="format">

``` format
c-library-name       c-addr u –         gforth       “c-library-name”
```

</div>

Start a C library interface with name *c-addr u*.

<span id="index-c_002dlibrary--_0022name_0022-_002d_002d--gforth"></span> <span id="index-c_002dlibrary"></span> <span id="index-c_002dlibrary-1"></span>

<div class="format">

``` format
c-library       "name" –         gforth       “c-library”
```

</div>

Parsing version of `c-library-name`

<span id="index-end_002dc_002dlibrary--_002d_002d--gforth"></span> <span id="index-end_002dc_002dlibrary"></span> <span id="index-end_002dc_002dlibrary-1"></span>

<div class="format">

``` format
end-c-library       –         gforth       “end-c-library”
```

</div>

Finish and (if necessary) build the latest C library interface.

-----

<div class="header">

Next: [Declaring OS-level libraries](Declaring-OS_002dlevel-libraries.html#Declaring-OS_002dlevel-libraries), Previous: [Calling C function pointers](Calling-C-function-pointers.html#Calling-C-function-pointers), Up: [C Interface](C-Interface.html#C-Interface)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
