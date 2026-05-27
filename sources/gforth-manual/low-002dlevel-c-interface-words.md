> Source: https://gforth.org/manual/Low_002dLevel-C-Interface-Words.html

<span id="Low_002dLevel-C-Interface-Words"></span>

<div class="header">

Next: [Migrating the C interface from earlier Gforth](Migrating-the-C-interface-from-earlier-Gforth.html#Migrating-the-C-interface-from-earlier-Gforth), Previous: [C interface internals](C-interface-internals.html#C-interface-internals), Up: [C Interface](C-Interface.html#C-Interface)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Low_002dLevel-C-Interface-Words-1"></span>

#### 5.26.8 Low-Level C Interface Words

<span id="index-open_002dlib--c_002daddr1-u1-_002d_002d-u2--gforth"></span> <span id="index-open_002dlib"></span> <span id="index-open_002dlib-1"></span>

<div class="format">

``` format
open-lib       c-addr1 u1 – u2        gforth       “open-lib”
```

</div>

<span id="index-lib_002dsym--c_002daddr1-u1-u2-_002d_002d-u3--gforth"></span> <span id="index-lib_002dsym"></span> <span id="index-lib_002dsym-1"></span>

<div class="format">

``` format
lib-sym       c-addr1 u1 u2 – u3        gforth       “lib-sym”
```

</div>

<span id="index-lib_002derror--_002d_002d-c_002daddr-u--gforth"></span> <span id="index-lib_002derror"></span> <span id="index-lib_002derror-1"></span>

<div class="format">

``` format
lib-error       – c-addr u        gforth       “lib-error”
```

</div>

Error message for last failed `open-lib` or `lib-sym`.

<span id="index-call_002dc--_002e_002e_002e-w-_002d_002d-_002e_002e_002e--gforth"></span> <span id="index-call_002dc"></span> <span id="index-call_002dc-1"></span>

<div class="format">

``` format
call-c       ... w – ...        gforth       “call-c”
```

</div>

Call the C function pointed to by *w*. The C function has to access the stack itself. The stack pointers are exported into a ptrpair structure passed to the C function, and returned in that form.
