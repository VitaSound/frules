> Source: https://gforth.org/manual/locals_002didef.html

<span id="locals_002didef"></span>

<div class="header">

Next: [locals-ambcond](locals_002dambcond.html#locals_002dambcond), Previous: [The optional Locals word set](The-optional-Locals-word-set.html#The-optional-Locals-word-set), Up: [The optional Locals word set](The-optional-Locals-word-set.html#The-optional-Locals-word-set)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Implementation-Defined-Options-6"></span>

#### 8.8.1 Implementation Defined Options

<span id="index-implementation_002ddefined-options_002c-locals-words"></span> <span id="index-locals-words_002c-implementation_002ddefined-options"></span>

  - *maximum number of locals in a definition:*  
    <span id="index-maximum-number-of-locals-in-a-definition"></span> <span id="index-locals_002c-maximum-number-in-a-definition"></span>
    
    `s" #locals" environment? drop .`. Currently 15. This is a lower bound, e.g., on a 32-bit machine there can be 41 locals of up to 8 characters. The number of locals in a definition is bounded by the size of locals-buffer, which contains the names of the locals.
