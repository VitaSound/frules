> Source: https://gforth.org/manual/Callbacks.html

<span id="Callbacks"></span>

<div class="header">

Next: [C interface internals](C-interface-internals.html#C-interface-internals), Previous: [Declaring OS-level libraries](Declaring-OS_002dlevel-libraries.html#Declaring-OS_002dlevel-libraries), Up: [C Interface](C-Interface.html#C-Interface)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Callbacks-1"></span>

#### 5.26.6 Callbacks

<span id="index-Callback-functions-written-in-Forth"></span> <span id="index-C-function-pointers-to-Forth-words"></span>

In some cases you have to pass a function pointer to a C function, i.e., the library wants to call back to your application (and the pointed-to function is called a callback function). You can pass the address of an existing C function (that you get with `lib-sym`, see [Low-Level C Interface Words](Low_002dLevel-C-Interface-Words.html#Low_002dLevel-C-Interface-Words)), but if there is no appropriate C function, you probably want to define the function as a Forth word. Then you need to generate a callback as described below:

You can generate C callbacks from Forth code with `c-callback`.

<span id="index-c_002dcallback--_0022forth_002dname_0022-_0022_007btype_007d_0022-_0022_002d_002d_002d_0022-_0022type_0022-_002d_002d--gforth"></span> <span id="index-c_002dcallback"></span> <span id="index-c_002dcallback-1"></span>

<div class="format">

``` format
c-callback       "forth-name" "{type}" "—" "type" –         gforth       “c-callback”
```

</div>

Define a callback instantiator with the given signature. The callback instantiator *forth-name* `( xt -- addr )` takes an `xt`, and returns the `addr`ess of the C function handling that callback.

This precompiles a number of callback functions (up to the value `callback#`). The prototype of the C function is deduced from its Forth signature. If this is not sufficient, you can add types in curly braces after the Forth type.

<div class="example">

``` example
c-callback vector4double: f f f f -- void
c-callback vector4single: f{float} f{float} f{float} f{float} -- void
```

</div>
