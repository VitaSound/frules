> Source: https://gforth.org/manual/core_002dother.html

<span id="core_002dother"></span>

<div class="header">

Previous: [core-ambcond](core_002dambcond.html#core_002dambcond), Up: [The Core Words](The-Core-Words.html#The-Core-Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Other-system-documentation"></span>

#### 8.1.3 Other system documentation

<span id="index-other-system-documentation_002c-core-words"></span> <span id="index-core-words_002c-other-system-documentation"></span>

  - *nonstandard words using `PAD`:*  
    <span id="index-PAD-use-by-nonstandard-words"></span>
    
    None.

  - *operator’s terminal facilities available:*  
    <span id="index-operator_0027s-terminal-facilities-available"></span>
    
    After processing the OS’s command line, Gforth goes into interactive mode, and you can give commands to Gforth interactively. The actual facilities available depend on how you invoke Gforth.

  - *program data space available:*  
    <span id="index-program-data-space-available"></span> <span id="index-data-space-available"></span>
    
    `UNUSED .` gives the remaining dictionary space. The total dictionary space can be specified with the `-m` switch (see [Invoking Gforth](Invoking-Gforth.html#Invoking-Gforth)) when Gforth starts up.

  - *return stack space available:*  
    <span id="index-return-stack-space-available"></span>
    
    You can compute the total return stack space in cells with `s" RETURN-STACK-CELLS" environment? drop .`. You can specify it at startup time with the `-r` switch (see [Invoking Gforth](Invoking-Gforth.html#Invoking-Gforth)).

  - *stack space available:*  
    <span id="index-stack-space-available"></span>
    
    You can compute the total data stack space in cells with `s" STACK-CELLS" environment? drop .`. You can specify it at startup time with the `-d` switch (see [Invoking Gforth](Invoking-Gforth.html#Invoking-Gforth)).

  - *system dictionary space required, in address units:*  
    <span id="index-system-dictionary-space-required_002c-in-address-units"></span>
    
    Type `here forthstart - .` after startup. At the time of this writing, this gives 80080 (bytes) on a 32-bit system.
