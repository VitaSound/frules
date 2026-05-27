> Source: https://gforth.org/manual/file_002dambcond.html

<span id="file_002dambcond"></span>

<div class="header">

Previous: [file-idef](file_002didef.html#file_002didef), Up: [The optional File-Access word set](The-optional-File_002dAccess-word-set.html#The-optional-File_002dAccess-word-set)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Ambiguous-conditions-4"></span>

#### 8.6.2 Ambiguous conditions

<span id="index-file-words_002c-ambiguous-conditions"></span> <span id="index-ambiguous-conditions_002c-file-words"></span>

  - *attempting to position a file outside its boundaries:*  
    <span id="index-REPOSITION_002dFILE_002c-outside-the-file_0027s-boundaries"></span>
    
    `REPOSITION-FILE` is performed as usual: Afterwards, `FILE-POSITION` returns the value given to `REPOSITION-FILE`.

  - *attempting to read from file positions not yet written:*  
    <span id="index-reading-from-file-positions-not-yet-written"></span>
    
    End-of-file, i.e., zero characters are read and no error is reported.

  - **file-id* is invalid (`INCLUDE-FILE`):*  
    <span id="index-INCLUDE_002dFILE_002c-file_002did-is-invalid"></span>
    
    An appropriate exception may be thrown, but a memory fault or other problem is more probable.

  - *I/O exception reading or closing *file-id* (`INCLUDE-FILE`, `INCLUDED`):*  
    <span id="index-INCLUDE_002dFILE_002c-I_002fO-exception-reading-or-closing-file_002did"></span> <span id="index-INCLUDED_002c-I_002fO-exception-reading-or-closing-file_002did"></span>
    
    The *ior* produced by the operation, that discovered the problem, is thrown.

  - *named file cannot be opened (`INCLUDED`):*  
    <span id="index-INCLUDED_002c-named-file-cannot-be-opened"></span>
    
    The *ior* produced by `open-file` is thrown.

  - *requesting an unmapped block number:*  
    <span id="index-unmapped-block-numbers"></span>
    
    There are no unmapped legal block numbers. On some operating systems, writing a block with a large number may overflow the file system and have an error message as consequence.

  - *using `source-id` when `blk` is non-zero:*  
    <span id="index-SOURCE_002dID_002c-behaviour-when-BLK-is-non_002dzero"></span>
    
    `source-id` performs its function. Typically it will give the id of the source which loaded the block. (Better ideas?)
