> Source: https://gforth.org/manual/exception_002didef.html

<span id="exception_002didef"></span>

<div class="header">

Previous: [The optional Exception word set](The-optional-Exception-word-set.html#The-optional-Exception-word-set), Up: [The optional Exception word set](The-optional-Exception-word-set.html#The-optional-Exception-word-set)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Implementation-Defined-Options-2"></span>

#### 8.4.1 Implementation Defined Options

<span id="index-implementation_002ddefined-options_002c-exception-words"></span> <span id="index-exception-words_002c-implementation_002ddefined-options"></span>

  - *`THROW`-codes used in the system:*  
    <span id="index-THROW_002dcodes-used-in-the-system"></span>
    
    The codes -256--511 are used for reporting signals. The mapping from OS signal numbers to throw codes is -256-*signal*. The codes -512--2047 are used for OS errors (for file and memory allocation operations). The mapping from OS error numbers to throw codes is -512-`errno`. One side effect of this mapping is that undefined OS errors produce a message with a strange number; e.g., `-1000 THROW` results in `Unknown error 488` on my system.
