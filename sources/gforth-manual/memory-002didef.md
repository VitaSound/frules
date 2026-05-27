> Source: https://gforth.org/manual/memory_002didef.html

<span id="memory_002didef"></span>

<div class="header">

Previous: [The optional Memory-Allocation word set](The-optional-Memory_002dAllocation-word-set.html#The-optional-Memory_002dAllocation-word-set), Up: [The optional Memory-Allocation word set](The-optional-Memory_002dAllocation-word-set.html#The-optional-Memory_002dAllocation-word-set)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Implementation-Defined-Options-7"></span>

#### 8.9.1 Implementation Defined Options

<span id="index-implementation_002ddefined-options_002c-memory_002dallocation-words"></span> <span id="index-memory_002dallocation-words_002c-implementation_002ddefined-options"></span>

  - *values and meaning of *ior*:*  
    <span id="index-ior-values-and-meaning-1"></span>
    
    The *ior*s returned by the file and memory allocation words are intended as throw codes. They typically are in the range -512--2047 of OS errors. The mapping from OS error numbers to *ior*s is -512-*errno*.
