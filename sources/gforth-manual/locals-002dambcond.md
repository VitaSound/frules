> Source: https://gforth.org/manual/locals_002dambcond.html

<span id="locals_002dambcond"></span>

<div class="header">

Previous: [locals-idef](locals_002didef.html#locals_002didef), Up: [The optional Locals word set](The-optional-Locals-word-set.html#The-optional-Locals-word-set)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Ambiguous-conditions-6"></span>

#### 8.8.2 Ambiguous conditions

<span id="index-locals-words_002c-ambiguous-conditions"></span> <span id="index-ambiguous-conditions_002c-locals-words"></span>

  - *executing a named local in interpretation state:*  
    <span id="index-local-in-interpretation-state"></span> <span id="index-Interpreting-a-compile_002donly-word_002c-for-a-local"></span>
    
    Compiles the local into the current definition (just as in compile state); in addition text-interpreting a local in interpretation state gives an “is compile-only” warning.

  - **name* not defined by `VALUE` or `(LOCAL)` (`TO`):*  
    <span id="index-name-not-defined-by-VALUE-or-_0028LOCAL_0029-used-by-TO"></span> <span id="index-TO-on-non_002dVALUEs-and-non_002dlocals"></span> <span id="index-Invalid-name-argument_002c-TO-1"></span>
    
    `-32 throw` (Invalid name argument)
