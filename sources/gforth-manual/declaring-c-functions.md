> Source: https://gforth.org/manual/Declaring-C-Functions.html

<span id="Declaring-C-Functions"></span>

<div class="header">

Next: [Calling C function pointers](Calling-C-function-pointers.html#Calling-C-function-pointers), Previous: [Calling C Functions](Calling-C-Functions.html#Calling-C-Functions), Up: [C Interface](C-Interface.html#C-Interface)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Declaring-C-Functions-1"></span>

#### 5.26.2 Declaring C Functions

<span id="index-C-functions_002c-declarations"></span> <span id="index-declaring-C-functions"></span>

Before you can call `lseek` or `dlseek`, you have to declare it. The declaration consists of two parts:

  - **The C part**  
    is the C declaration of the function, or more typically and portably, a C-style `#include` of a file that contains the declaration of the C function.

  - **The Forth part**  
    declares the Forth types of the parameters and the Forth word name corresponding to the C function.

For the words `lseek` and `dlseek` mentioned earlier, the declarations are:

<div class="example">

``` example
\c #define _FILE_OFFSET_BITS 64
\c #include <sys/types.h>
\c #include <unistd.h>
c-function lseek lseek n n n -- n
c-function dlseek lseek n d n -- d
```

</div>

The C part of the declarations is prefixed by `\c`, and the rest of the line is ordinary C code. You can use as many lines of C declarations as you like, and they are visible for all further function declarations.

The Forth part declares each interface word with `c-function`, followed by the Forth name of the word, the C name of the called function, and the stack effect of the word. The stack effect contains an arbitrary number of types of parameters, then `--`, and then exactly one type for the return value. The possible types are:

  - `n`  
    single-cell integer

  - `a`  
    address (single-cell)

  - `d`  
    double-cell integer

  - `r`  
    floating-point value

  - `func`  
    C function pointer

  - `void`  
    no value (used as return type for void functions)

<span id="index-variadic-C-functions"></span>

To deal with variadic C functions, you can declare one Forth word for every pattern you want to use, e.g.:

<div class="example">

``` example
\c #include <stdio.h>
c-function printf-nr printf a n r -- n
c-function printf-rn printf a r n -- n
```

</div>

Note that with C functions declared as variadic (or if you don’t provide a prototype), the C interface has no C type to convert to, so no automatic conversion happens, which may lead to portability problems in some cases. You can add the C type cast in curly braces after the Forth type. This also allows to pass e.g. structs to C functions, which in Forth cannot live on the stack.

<div class="example">

``` example
c-function printfll printf a n{(long long)} -- n
c-function pass-struct pass_struct a{*(struct foo *)} -- n
```

</div>

This typecasting is not available to return values, as C does not allow typecasts for lvalues.

<span id="index-_005cc--_0022rest_002dof_002dline_0022-_002d_002d--gforth"></span> <span id="index-_005cc"></span> <span id="index-_005cc-1"></span>

<div class="format">

``` format
\c       "rest-of-line" –         gforth       “backslash-c”
```

</div>

One line of C declarations for the C interface

<span id="index-c_002dfunction--_0022forth_002dname_0022-_0022c_002dname_0022-_0022_007btype_007d_0022-_0022_002d_002d_002d_0022-_0022type_0022-_002d_002d--gforth"></span> <span id="index-c_002dfunction"></span> <span id="index-c_002dfunction-1"></span>

<div class="format">

``` format
c-function       "forth-name" "c-name" "{type}" "—" "type" –         gforth       “c-function”
```

</div>

Define a Forth word *forth-name*. *Forth-name* has the specified stack effect and calls the C function `c-name`.

<span id="index-c_002dvalue--_0022forth_002dname_0022-_0022c_002dname_0022-_0022_002d_002d_002d_0022-_0022type_0022-_002d_002d--gforth"></span> <span id="index-c_002dvalue"></span> <span id="index-c_002dvalue-1"></span>

<div class="format">

``` format
c-value       "forth-name" "c-name" "—" "type" –         gforth       “c-value”
```

</div>

Define a Forth word *forth-name*. *Forth-name* has the specified stack effect and gives the C value of `c-name`.

<span id="index-c_002dvariable--_0022forth_002dname_0022-_0022c_002dname_0022-_002d_002d--gforth"></span> <span id="index-c_002dvariable"></span> <span id="index-c_002dvariable-1"></span>

<div class="format">

``` format
c-variable       "forth-name" "c-name" –         gforth       “c-variable”
```

</div>

Define a Forth word *forth-name*. *Forth-name* returns the address of `c-name`.

In order to work, this C interface invokes GCC at run-time and uses dynamic linking. If these features are not available, there are other, less convenient and less portable C interfaces in `lib.fs` and `oldlib.fs`. These interfaces are mostly undocumented and mostly incompatible with each other and with the documented C interface; you can find some examples for the `lib.fs` interface in `lib.fs`.

-----

<div class="header">

Next: [Calling C function pointers](Calling-C-function-pointers.html#Calling-C-function-pointers), Previous: [Calling C Functions](Calling-C-Functions.html#Calling-C-Functions), Up: [C Interface](C-Interface.html#C-Interface)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
