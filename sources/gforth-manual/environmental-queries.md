> Source: https://gforth.org/manual/Environmental-Queries.html

<span id="Environmental-Queries"></span>

<div class="header">

Next: [Files](Files.html#Files), Previous: [Word Lists](Word-Lists.html#Word-Lists), Up: [Words](Words.html#Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Environmental-Queries-1"></span>

### 5.16 Environmental Queries

<span id="index-environmental-queries"></span>

Forth-94 introduced the idea of “environmental queries” as a way for a program running on a system to determine certain characteristics of the system. The Standard specifies a number of strings that might be recognised by a system.

The Standard requires that the header space used for environmental queries be distinct from the header space used for definitions.

Typically, environmental queries are supported by creating a set of definitions in a word list that is *only* used during environmental queries; that is what Gforth does. There is no Standard way of adding definitions to the set of recognised environmental queries, but any implementation that supports the loading of optional word sets must have some mechanism for doing this (after loading the word set, the associated environmental query string must return `true`). In Gforth, the word list used to honour environmental queries can be manipulated just like any other word list.

<span id="index-environment_003f--c_002daddr-u-_002d_002d-false-_002f-_002e_002e_002e-true--core"></span> <span id="index-environment_003f"></span> <span id="index-environment_003f-1"></span>

<div class="format">

``` format
environment?       c-addr u – false / ... true         core       “environment-query”
```

</div>

*c-addr, u* specify a counted string. If the string is not recognised, return a `false` flag. Otherwise return a `true` flag and some (string-specific) information about the queried string.

<span id="index-environment_002dwordlist--_002d_002d-wid--gforth"></span> <span id="index-environment_002dwordlist"></span> <span id="index-environment_002dwordlist-1"></span>

<div class="format">

``` format
environment-wordlist       – wid         gforth       “environment-wordlist”
```

</div>

*wid* identifies the word list that is searched by environmental queries.

<span id="index-gforth--_002d_002d-c_002daddr-u--gforth_002denvironment"></span> <span id="index-gforth"></span> <span id="index-gforth-1"></span>

<div class="format">

``` format
gforth       – c-addr u         gforth-environment       “gforth”
```

</div>

Counted string representing a version string for this version of Gforth (for versions\>0.3.0). The version strings of the various versions are guaranteed to be ordered lexicographically.

<span id="index-os_002dclass--_002d_002d-c_002daddr-u--gforth_002denvironment"></span> <span id="index-os_002dclass"></span> <span id="index-os_002dclass-1"></span>

<div class="format">

``` format
os-class       – c-addr u         gforth-environment       “os-class”
```

</div>

Counted string representing a description of the host operating system.

Note that, whilst the documentation for (e.g.) `gforth` shows it returning two items on the stack, querying it using `environment?` will return an additional item; the `true` flag that shows that the string was recognised.

Here are some examples of using environmental queries:

<div class="example">

``` example
s" address-unit-bits" environment? 0=
[IF]
     cr .( environmental attribute address-units-bits unknown... ) cr
[ELSE]
     drop \ ensure balanced stack effect
[THEN]

\ this might occur in the prelude of a standard program that uses THROW
s" exception" environment? [IF]
   0= [IF]
      : throw abort" exception thrown" ;
   [THEN]
[ELSE] \ we don't know, so make sure
   : throw abort" exception thrown" ;
[THEN]

s" gforth" environment? [IF] .( Gforth version ) TYPE
                        [ELSE] .( Not Gforth..) [THEN]

\ a program using v*
s" gforth" environment? [IF]
  s" 0.5.0" compare 0< [IF] \ v* is a primitive since 0.5.0
   : v* ( f_addr1 nstride1 f_addr2 nstride2 ucount -- r )
     >r swap 2swap swap 0e r> 0 ?DO
       dup f@ over + 2swap dup f@ f* f+ over + 2swap
     LOOP
     2drop 2drop ; 
  [THEN]
[ELSE] \ 
  : v* ( f_addr1 nstride1 f_addr2 nstride2 ucount -- r )
  ...
[THEN]
```

</div>

Here is an example of adding a definition to the environment word list:

<div class="example">

``` example
get-current environment-wordlist set-current
true constant block
true constant block-ext
set-current
```

</div>

You can see what definitions are in the environment word list like this:

<div class="example">

``` example
environment-wordlist >order words previous
```

</div>

-----

<div class="header">

Next: [Files](Files.html#Files), Previous: [Word Lists](Word-Lists.html#Word-Lists), Up: [Words](Words.html#Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
