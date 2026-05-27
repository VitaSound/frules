> Source: https://gforth.org/manual/Cross-Compiler.html

<span id="Cross-Compiler"></span>

<div class="header">

Next: [Bugs](Bugs.html#Bugs), Previous: [Engine](Engine.html#Engine), Up: [Top](index.html#Top)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Cross-Compiler-1"></span>

## 15 Cross Compiler

<span id="index-cross_002efs-1"></span> <span id="index-cross_002dcompiler-1"></span> <span id="index-metacompiler-1"></span> <span id="index-target-compiler-1"></span>

The cross compiler is used to bootstrap a Forth kernel. Since Gforth is mostly written in Forth, including crucial parts like the outer interpreter and compiler, it needs compiled Forth code to get started. The cross compiler allows to create new images for other architectures, even running under another Forth system.

|                                                                                                   |  |  |
| :------------------------------------------------------------------------------------------------ |  | :- |
| • [Using the Cross Compiler](Using-the-Cross-Compiler.html#Using-the-Cross-Compiler):             |  |  |
| • [How the Cross Compiler Works](How-the-Cross-Compiler-Works.html#How-the-Cross-Compiler-Works): |  |  |
