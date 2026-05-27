> Source: https://gforth.org/manual/C-Interface.html

<span id="C-Interface"></span>

<div class="header">

Next: [Assembler and Code Words](Assembler-and-Code-Words.html#Assembler-and-Code-Words), Previous: [Multitasker](Multitasker.html#Multitasker), Up: [Words](Words.html#Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="C-Interface-1"></span>

### 5.26 C Interface

<span id="index-C-interface"></span> <span id="index-foreign-language-interface"></span> <span id="index-interface-to-C-functions"></span>

The C interface is now mostly complete, callbacks have been added, but for structs, we use Forth2012 structs, which don’t have independent scopes. The offsets of those structs are extracted from header files with a SWIG plugin, which is still not completed.

|                                                                                                                                                      |  |  |
| :--------------------------------------------------------------------------------------------------------------------------------------------------- |  | :- |
| • [Calling C Functions](Calling-C-Functions.html#Calling-C-Functions):                                                                               |  |  |
| • [Declaring C Functions](Declaring-C-Functions.html#Declaring-C-Functions):                                                                         |  |  |
| • [Calling C function pointers](Calling-C-function-pointers.html#Calling-C-function-pointers):                                                       |  |  |
| • [Defining library interfaces](Defining-library-interfaces.html#Defining-library-interfaces):                                                       |  |  |
| • [Declaring OS-level libraries](Declaring-OS_002dlevel-libraries.html#Declaring-OS_002dlevel-libraries):                                            |  |  |
| • [Callbacks](Callbacks.html#Callbacks):                                                                                                             |  |  |
| • [C interface internals](C-interface-internals.html#C-interface-internals):                                                                         |  |  |
| • [Low-Level C Interface Words](Low_002dLevel-C-Interface-Words.html#Low_002dLevel-C-Interface-Words):                                               |  |  |
| • [Migrating the C interface from earlier Gforth](Migrating-the-C-interface-from-earlier-Gforth.html#Migrating-the-C-interface-from-earlier-Gforth): |  |  |
