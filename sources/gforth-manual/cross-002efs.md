> Source: https://gforth.org/manual/cross_002efs.html

<span id="cross_002efs"></span>

<div class="header">

Previous: [gforthmi](gforthmi.html#gforthmi), Up: [Fully Relocatable Image Files](Fully-Relocatable-Image-Files.html#Fully-Relocatable-Image-Files)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="cross_002efs-1"></span>

#### 13.5.2 `cross.fs`

<span id="index-cross_002efs"></span> <span id="index-cross_002dcompiler"></span> <span id="index-metacompiler"></span> <span id="index-target-compiler"></span>

You can also use `cross`, a batch compiler that accepts a Forth-like programming language (see [Cross Compiler](Cross-Compiler.html#Cross-Compiler)).

`cross` allows you to create image files for machines with different data sizes and data formats than the one used for generating the image file. You can also use it to create an application image that does not contain a Forth compiler. These features are bought with restrictions and inconveniences in programming. E.g., addresses have to be stored in memory with special words (`A!`, `A,`, etc.) in order to make the code relocatable.
