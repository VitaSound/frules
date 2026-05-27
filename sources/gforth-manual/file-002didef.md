> Source: https://gforth.org/manual/file_002didef.html

<span id="file_002didef"></span>

<div class="header">

Next: [file-ambcond](file_002dambcond.html#file_002dambcond), Previous: [The optional File-Access word set](The-optional-File_002dAccess-word-set.html#The-optional-File_002dAccess-word-set), Up: [The optional File-Access word set](The-optional-File_002dAccess-word-set.html#The-optional-File_002dAccess-word-set)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Implementation-Defined-Options-4"></span>

#### 8.6.1 Implementation Defined Options

<span id="index-implementation_002ddefined-options_002c-file-words"></span> <span id="index-file-words_002c-implementation_002ddefined-options"></span>

  - *file access methods used:*  
    <span id="index-file-access-methods-used"></span>
    
    `R/O`, `R/W` and `BIN` work as you would expect. `W/O` translates into the C file opening mode `w` (or `wb`): The file is cleared, if it exists, and created, if it does not (with both `open-file` and `create-file`). Under Unix `create-file` creates a file with 666 permissions modified by your umask.

  - *file exceptions:*  
    <span id="index-file-exceptions"></span>
    
    The file words do not raise exceptions (except, perhaps, memory access faults when you pass illegal addresses or file-ids).

  - *file line terminator:*  
    <span id="index-file-line-terminator"></span>
    
    System-dependent. Gforth uses C’s newline character as line terminator. What the actual character code(s) of this are is system-dependent.

  - *file name format:*  
    <span id="index-file-name-format"></span>
    
    System dependent. Gforth just uses the file name format of your OS.

  - *information returned by `FILE-STATUS`:*  
    <span id="index-FILE_002dSTATUS_002c-returned-information"></span>
    
    `FILE-STATUS` returns the most powerful file access mode allowed for the file: Either `R/O`, `W/O` or `R/W`. If the file cannot be accessed, `R/O BIN` is returned. `BIN` is applicable along with the returned mode.

  - *input file state after an exception when including source:*  
    <span id="index-exception-when-including-source"></span>
    
    All files that are left via the exception are closed.

  - **ior* values and meaning:*  
    <span id="index-ior-values-and-meaning"></span> <span id="index-wior-values-and-meaning"></span>
    
    The *ior*s returned by the file and memory allocation words are intended as throw codes. They typically are in the range -512--2047 of OS errors. The mapping from OS error numbers to *ior*s is -512-*errno*.

  - *maximum depth of file input nesting:*  
    <span id="index-maximum-depth-of-file-input-nesting"></span> <span id="index-file-input-nesting_002c-maximum-depth"></span>
    
    limited by the amount of return stack, locals/TIB stack, and the number of open files available. This should not give you troubles.

  - *maximum size of input line:*  
    <span id="index-maximum-size-of-input-line"></span> <span id="index-input-line-size_002c-maximum"></span>
    
    `/line`. Currently 255.

  - *methods of mapping block ranges to files:*  
    <span id="index-mapping-block-ranges-to-files"></span> <span id="index-files-containing-blocks"></span> <span id="index-blocks-in-files"></span>
    
    By default, blocks are accessed in the file `blocks.fb` in the current working directory. The file can be switched with `USE`.

  - *number of string buffers provided by `S"`:*  
    <span id="index-S_0022_002c-number-of-string-buffers"></span>
    
    As many as memory available; the strings are stored in memory blocks allocated with ALLOCATE indefinitely.

  - *size of string buffer used by `S"`:*  
    <span id="index-S_0022_002c-size-of-string-buffer"></span>
    
    `/line`. currently 255.

-----

<div class="header">

Next: [file-ambcond](file_002dambcond.html#file_002dambcond), Previous: [The optional File-Access word set](The-optional-File_002dAccess-word-set.html#The-optional-File_002dAccess-word-set), Up: [The optional File-Access word set](The-optional-File_002dAccess-word-set.html#The-optional-File_002dAccess-word-set)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
