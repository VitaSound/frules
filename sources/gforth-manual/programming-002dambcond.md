> Source: https://gforth.org/manual/programming_002dambcond.html

<span id="programming_002dambcond"></span>

<div class="header">

Previous: [programming-idef](programming_002didef.html#programming_002didef), Up: [The optional Programming-Tools word set](The-optional-Programming_002dTools-word-set.html#The-optional-Programming_002dTools-word-set)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Ambiguous-conditions-7"></span>

#### 8.10.2 Ambiguous conditions

<span id="index-programming_002dtools-words_002c-ambiguous-conditions"></span> <span id="index-ambiguous-conditions_002c-programming_002dtools-words"></span>

  - *deleting the compilation word list (`FORGET`):*  
    <span id="index-FORGET_002c-deleting-the-compilation-word-list"></span>
    
    Not implemented (yet).

  - *fewer than *u*+1 items on the control-flow stack (`CS-PICK`, `CS-ROLL`):*  
    <span id="index-CS_002dPICK_002c-fewer-than-u_002b1-items-on-the-control-flow_002dstack"></span> <span id="index-CS_002dROLL_002c-fewer-than-u_002b1-items-on-the-control-flow_002dstack"></span> <span id="index-control_002dflow-stack-underflow"></span>
    
    This typically results in an `abort"` with a descriptive error message (may change into a `-22 throw` (Control structure mismatch) in the future). You may also get a memory access error. If you are unlucky, this ambiguous condition is not caught.

  - **name* can’t be found (`FORGET`):*  
    <span id="index-FORGET_002c-name-can_0027t-be-found"></span>
    
    Not implemented (yet).

  - **name* not defined via `CREATE`:*  
    <span id="index-_003bCODE_002c-name-not-defined-via-CREATE"></span>
    
    `;CODE` behaves like `DOES>` in this respect, i.e., it changes the execution semantics of the last defined word no matter how it was defined.

  - *`POSTPONE` applied to `[IF]`:*  
    <span id="index-POSTPONE-applied-to-_005bIF_005d"></span> <span id="index-_005bIF_005d-and-POSTPONE"></span>
    
    After defining `: X POSTPONE [IF] ; IMMEDIATE`. `X` is equivalent to `[IF]`.

  - *reaching the end of the input source before matching `[ELSE]` or `[THEN]`:*  
    <span id="index-_005bIF_005d_002c-end-of-the-input-source-before-matching-_005bELSE_005d-or-_005bTHEN_005d"></span>
    
    Continue in the same state of conditional compilation in the next outer input source. Currently there is no warning to the user about this.

  - *removing a needed definition (`FORGET`):*  
    <span id="index-FORGET_002c-removing-a-needed-definition"></span>
    
    Not implemented (yet).
