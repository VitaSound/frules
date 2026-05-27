> Source: https://gforth.org/manual/Using-the-Cross-Compiler.html

<span id="Using-the-Cross-Compiler"></span>

<div class="header">

Next: [How the Cross Compiler Works](How-the-Cross-Compiler-Works.html#How-the-Cross-Compiler-Works), Previous: [Cross Compiler](Cross-Compiler.html#Cross-Compiler), Up: [Cross Compiler](Cross-Compiler.html#Cross-Compiler)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Using-the-Cross-Compiler-1"></span>

### 15.1 Using the Cross Compiler

The cross compiler uses a language that resembles Forth, but isn’t. The main difference is that you can execute Forth code after definition, while you usually can’t execute the code compiled by cross, because the code you are compiling is typically for a different computer than the one you are compiling on.

The Makefile is already set up to allow you to create kernels for new architectures with a simple make command. The generic kernels using the GCC compiled virtual machine are created in the normal build process with `make`. To create a embedded Gforth executable for e.g. the 8086 processor (running on a DOS machine), type

<div class="example">

``` example
make kernl-8086.fi
```

</div>

This will use the machine description from the `arch/8086` directory to create a new kernel. A machine file may look like that:

<div class="example">

``` example
\ Parameter for target systems                         06oct92py

    4 Constant cell             \ cell size in bytes
    2 Constant cell<<           \ cell shift to bytes
    5 Constant cell>bit         \ cell shift to bits
    8 Constant bits/char        \ bits per character
    8 Constant bits/byte        \ bits per byte [default: 8]
    8 Constant float            \ bytes per float
    8 Constant /maxalign        \ maximum alignment in bytes
false Constant bigendian        \ byte order
( true=big, false=little )

include machpc.fs               \ feature list
```

</div>

This part is obligatory for the cross compiler itself, the feature list is used by the kernel to conditionally compile some features in and out, depending on whether the target supports these features.

There are some optional features, if you define your own primitives, have an assembler, or need special, nonstandard preparation to make the boot process work. `asm-include` includes an assembler, `prims-include` includes primitives, and `>boot` prepares for booting.

<div class="example">

``` example
: asm-include    ." Include assembler" cr
  s" arch/8086/asm.fs" included ;

: prims-include  ." Include primitives" cr
  s" arch/8086/prim.fs" included ;

: >boot          ." Prepare booting" cr
  s" ' boot >body into-forth 1+ !" evaluate ;
```

</div>

These words are used as sort of macro during the cross compilation in the file `kernel/main.fs`. Instead of using these macros, it would be possible — but more complicated — to write a new kernel project file, too.

`kernel/main.fs` expects the machine description file name on the stack; the cross compiler itself (`cross.fs`) assumes that either `mach-file` leaves a counted string on the stack, or `machine-file` leaves an address, count pair of the filename on the stack.

The feature list is typically controlled using `SetValue`, generic files that are used by several projects can use `DefaultValue` instead. Both functions work like `Value`, when the value isn’t defined, but `SetValue` works like `to` if the value is defined, and `DefaultValue` doesn’t set anything, if the value is defined.

<div class="example">

``` example
\ generic mach file for pc gforth                       03sep97jaw

true DefaultValue NIL  \ relocating

>ENVIRON

true DefaultValue file          \ controls the presence of the
                                \ file access wordset
true DefaultValue OS            \ flag to indicate a operating system

true DefaultValue prims         \ true: primitives are c-code

true DefaultValue floating      \ floating point wordset is present

true DefaultValue glocals       \ gforth locals are present
                                \ will be loaded
true DefaultValue dcomps        \ double number comparisons

true DefaultValue hash          \ hashing primitives are loaded/present

true DefaultValue xconds        \ used together with glocals,
                                \ special conditionals supporting gforths'
                                \ local variables
true DefaultValue header        \ save a header information

true DefaultValue backtrace     \ enables backtrace code

false DefaultValue ec
false DefaultValue crlf

cell 2 = [IF] &32 [ELSE] &256 [THEN] KB DefaultValue kernel-size

&16 KB          DefaultValue stack-size
&15 KB &512 +   DefaultValue fstack-size
&15 KB          DefaultValue rstack-size
&14 KB &512 +   DefaultValue lstack-size
```

</div>

-----

<div class="header">

Next: [How the Cross Compiler Works](How-the-Cross-Compiler-Works.html#How-the-Cross-Compiler-Works), Previous: [Cross Compiler](Cross-Compiler.html#Cross-Compiler), Up: [Cross Compiler](Cross-Compiler.html#Cross-Compiler)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
