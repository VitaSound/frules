> Source: https://gforth.org/manual/Produced-code.html

<span id="Produced-code"></span>

<div class="header">

Previous: [TOS Optimization](TOS-Optimization.html#TOS-Optimization), Up: [Primitives](Primitives.html#Primitives)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Produced-code-1"></span>

#### 14.3.3 Produced code

<span id="index-primitives_002c-assembly-code-listing"></span> <span id="index-engine_002es"></span>

To see what assembly code is produced for the primitives on your machine with your compiler and your flag settings, type `make engine.s` and look at the resulting file `engine.s`. Alternatively, you can also disassemble the code of primitives with `see` on some architectures.
