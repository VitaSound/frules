> Source: https://gforth.org/manual/block_002dambcond.html

<span id="block_002dambcond"></span>

<div class="header">

Next: [block-other](block_002dother.html#block_002dother), Previous: [block-idef](block_002didef.html#block_002didef), Up: [The optional Block word set](The-optional-Block-word-set.html#The-optional-Block-word-set)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Ambiguous-conditions-1"></span>

#### 8.2.2 Ambiguous conditions

<span id="index-block-words_002c-ambiguous-conditions"></span> <span id="index-ambiguous-conditions_002c-block-words"></span>

  - *correct block read was not possible:*  
    <span id="index-block-read-not-possible"></span>
    
    Typically results in a `throw` of some OS-derived value (between -512 and -2048). If the blocks file was just not long enough, blanks are supplied for the missing portion.

  - *I/O exception in block transfer:*  
    <span id="index-I_002fO-exception-in-block-transfer"></span> <span id="index-block-transfer_002c-I_002fO-exception"></span>
    
    Typically results in a `throw` of some OS-derived value (between -512 and -2048).

  - *invalid block number:*  
    <span id="index-invalid-block-number"></span> <span id="index-block-number-invalid"></span>
    
    `-35 throw` (Invalid block number)

  - *a program directly alters the contents of `BLK`:*  
    <span id="index-BLK_002c-altering-BLK"></span>
    
    The input stream is switched to that other block, at the same position. If the storing to `BLK` happens when interpreting non-block input, the system will get quite confused when the block ends.

  - *no current block buffer for `UPDATE`:*  
    <span id="index-UPDATE_002c-no-current-block-buffer"></span>
    
    `UPDATE` has no effect.
