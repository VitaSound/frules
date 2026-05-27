> Source: https://gforth.org/manual/Declaring-OS_002dlevel-libraries.html

<span id="Declaring-OS_002dlevel-libraries"></span>

<div class="header">

Next: [Callbacks](Callbacks.html#Callbacks), Previous: [Defining library interfaces](Defining-library-interfaces.html#Defining-library-interfaces), Up: [C Interface](C-Interface.html#C-Interface)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Declaring-OS_002dlevel-libraries-1"></span>

#### 5.26.5 Declaring OS-level libraries

<span id="index-Shared-libraries-in-C-interface"></span> <span id="index-Dynamically-linked-libraries-in-C-interface"></span> <span id="index-Libraries-in-C-interface"></span>

For calling some C functions, you need to link with a specific OS-level library that contains that function. E.g., the `sin` function requires linking a special library by using the command line switch `-lm`. In our C iterface you do the equivalent thing by calling `add-lib` as follows:

<div class="example">

``` example
clear-libs
s" m" add-lib
\c #include <math.h>
c-function sin sin r -- r
```

</div>

First, you clear any libraries that may have been declared earlier (you don’t need them for `sin`); then you add the `m` library (actually `libm.so` or somesuch) to the currently declared libraries; you can add as many as you need. Finally you declare the function as shown above. Typically you will use the same set of library declarations for many function declarations; you need to write only one set for that, right at the beginning.

Note that you must not call `clear-libs` inside `c-library...end-c-library`; however, `c-library` performs the function of `clear-libs`, so `clear-libs` is not necessary, and you usually want to put `add-lib` calls inside `c-library...end-c-library`.

<span id="index-clear_002dlibs--_002d_002d--gforth"></span> <span id="index-clear_002dlibs"></span> <span id="index-clear_002dlibs-1"></span>

<div class="format">

``` format
clear-libs       –         gforth       “clear-libs”
```

</div>

Clear the list of libs

<span id="index-add_002dlib--c_002daddr-u-_002d_002d--gforth"></span> <span id="index-add_002dlib"></span> <span id="index-add_002dlib-1"></span>

<div class="format">

``` format
add-lib       c-addr u –         gforth       “add-lib”
```

</div>

Add library lib*string* to the list of libraries, where *string* is represented by *c-addr u*.
