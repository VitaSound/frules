> Source: https://gforth.org/manual/C-interface-internals.html

<span id="C-interface-internals"></span>

<div class="header">

Next: [Low-Level C Interface Words](Low_002dLevel-C-Interface-Words.html#Low_002dLevel-C-Interface-Words), Previous: [Callbacks](Callbacks.html#Callbacks), Up: [C Interface](C-Interface.html#C-Interface)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="How-the-C-interface-works"></span>

#### 5.26.7 How the C interface works

The documented C interface works by generating a C code out of the declarations.

In particular, for every Forth word declared with `c-function`, it generates a wrapper function in C that takes the Forth data from the Forth stacks, and calls the target C function with these data as arguments. The C compiler then performs an implicit conversion between the Forth type from the stack, and the C type for the parameter, which is given by the C function prototype. After the C function returns, the return value is likewise implicitly converted to a Forth type and written back on the stack.

The `\c` lines are literally included in the C code (but without the `\c`), and provide the necessary declarations so that the C compiler knows the C types and has enough information to perform the conversion.

These wrapper functions are eventually compiled and dynamically linked into Gforth, and then they can be called.

The libraries added with `add-lib` are used in the compile command line to specify dependent libraries with `-llib`, causing these libraries to be dynamically linked when the wrapper function is linked.
