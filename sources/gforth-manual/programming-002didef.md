> Source: https://gforth.org/manual/programming_002didef.html

<span id="programming_002didef"></span>

<div class="header">

Next: [programming-ambcond](programming_002dambcond.html#programming_002dambcond), Previous: [The optional Programming-Tools word set](The-optional-Programming_002dTools-word-set.html#The-optional-Programming_002dTools-word-set), Up: [The optional Programming-Tools word set](The-optional-Programming_002dTools-word-set.html#The-optional-Programming_002dTools-word-set)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Implementation-Defined-Options-8"></span>

#### 8.10.1 Implementation Defined Options

<span id="index-implementation_002ddefined-options_002c-programming_002dtools-words"></span> <span id="index-programming_002dtools-words_002c-implementation_002ddefined-options"></span>

  - *ending sequence for input following `;CODE` and `CODE`:*  
    <span id="index-_003bCODE-ending-sequence"></span> <span id="index-CODE-ending-sequence"></span>
    
    `END-CODE`

  - *manner of processing input following `;CODE` and `CODE`:*  
    <span id="index-_003bCODE_002c-processing-input"></span> <span id="index-CODE_002c-processing-input"></span>
    
    The `ASSEMBLER` vocabulary is pushed on the search order stack, and the input is processed by the text interpreter, (starting) in interpret state.

  - *search order capability for `EDITOR` and `ASSEMBLER`:*  
    <span id="index-ASSEMBLER_002c-search-order-capability"></span>
    
    The Search-Order word set.

  - *source and format of display by `SEE`:*  
    <span id="index-SEE_002c-source-and-format-of-output"></span>
    
    The source for `see` is the executable code used by the inner interpreter. The current `see` tries to output Forth source code (and on some platforms, assembly code for primitives) as well as possible.
