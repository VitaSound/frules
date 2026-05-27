> Source: https://gforth.org/manual/core_002dambcond.html

<span id="core_002dambcond"></span>

<div class="header">

Next: [core-other](core_002dother.html#core_002dother), Previous: [core-idef](core_002didef.html#core_002didef), Up: [The Core Words](The-Core-Words.html#The-Core-Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Ambiguous-conditions"></span>

#### 8.1.2 Ambiguous conditions

<span id="index-core-words_002c-ambiguous-conditions"></span> <span id="index-ambiguous-conditions_002c-core-words"></span>

  - *a name is neither a word nor a number:*  
    <span id="index-name-not-found"></span> <span id="index-undefined-word"></span>
    
    `-13 throw` (Undefined word).

  - *a definition name exceeds the maximum length allowed:*  
    <span id="index-word-name-too-long"></span>
    
    `-19 throw` (Word name too long)

  - *addressing a region not inside the various data spaces of the forth system:*  
    <span id="index-Invalid-memory-address"></span>
    
    The stacks, code space and header space are accessible. Machine code space is typically readable. Accessing other addresses gives results dependent on the operating system. On decent systems: `-9 throw` (Invalid memory address).

  - *argument type incompatible with parameter:*  
    <span id="index-argument-type-mismatch"></span>
    
    This is usually not caught. Some words perform checks, e.g., the control flow words, and issue a `ABORT"` or `-12 THROW` (Argument type mismatch).

  - *attempting to obtain the execution token of a word with undefined execution semantics:*  
    <span id="index-compile_002donly-warning_002c-for-_0027-etc_002e"></span> <span id="index-execution-token-of-words-with-undefined-execution-semantics"></span>
    
    The execution token represents the interpretation semantics of the word. Gforth defines interpretation semantics for all words; for words where the standard does not define interpretation semantics, but defines the execution semantics (except `LEAVE`), the interpretation semantics are to perform the execution semantics. For words where the standard defines no interprtation semantics, but defined compilation semantics (plus `LEAVE`), the interpretation semantics are to perform the compilation semantics. Some words are marked as compile-only, and `'` gives a warning for these words.

  - *dividing by zero:*  
    <span id="index-dividing-by-zero"></span> <span id="index-floating-point-unidentified-fault_002c-integer-division"></span>
    
    On some platforms, this produces a `-10 throw` (Division by zero); on other systems, this typically results in a `-55 throw` (Floating-point unidentified fault).

  - *insufficient data stack or return stack space:*  
    <span id="index-insufficient-data-stack-or-return-stack-space"></span> <span id="index-stack-overflow"></span> <span id="index-address-alignment-exception_002c-stack-overflow"></span> <span id="index-Invalid-memory-address_002c-stack-overflow"></span>
    
    Depending on the operating system, the installation, and the invocation of Gforth, this is either checked by the memory management hardware, or it is not checked. If it is checked, you typically get a `-3 throw` (Stack overflow), `-5 throw` (Return stack overflow), or `-9 throw` (Invalid memory address) (depending on the platform and how you achieved the overflow) as soon as the overflow happens. If it is not checked, overflows typically result in mysterious illegal memory accesses, producing `-9 throw` (Invalid memory address) or `-23 throw` (Address alignment exception); they might also destroy the internal data structure of `ALLOCATE` and friends, resulting in various errors in these words.

  - *insufficient space for loop control parameters:*  
    <span id="index-insufficient-space-for-loop-control-parameters"></span>
    
    Like other return stack overflows.

  - *insufficient space in the dictionary:*  
    <span id="index-insufficient-space-in-the-dictionary"></span> <span id="index-dictionary-overflow"></span>
    
    If you try to allot (either directly with `allot`, or indirectly with `,`, `create` etc.) more memory than available in the dictionary, you get a `-8 throw` (Dictionary overflow). If you try to access memory beyond the end of the dictionary, the results are similar to stack overflows.

  - *interpreting a word with undefined interpretation semantics:*  
    <span id="index-interpreting-a-word-with-undefined-interpretation-semantics"></span> <span id="index-Interpreting-a-compile_002donly-word"></span>
    
    Gforth defines interpretation semantics for all words; for words where the standard defines execution semantics (except `LEAVE`), the interpretation semantics are to perform the execution semantics. For words where the standard defines no interprtation semantics, but defined compilation semantics (plus `LEAVE`), the interpretation semantics are to perform the compilation semantics. Some words are marked as compile-only, and text-interpreting them gives a warning.

  - *modifying the contents of the input buffer or a string literal:*  
    <span id="index-modifying-the-contents-of-the-input-buffer-or-a-string-literal"></span>
    
    These are located in writable memory and can be modified.

  - *overflow of the pictured numeric output string:*  
    <span id="index-overflow-of-the-pictured-numeric-output-string"></span> <span id="index-pictured-numeric-output-string_002c-overflow"></span>
    
    `-17 throw` (Pictured numeric ouput string overflow).

  - *parsed string overflow:*  
    <span id="index-parsed-string-overflow"></span>
    
    `PARSE` cannot overflow. `WORD` does not check for overflow.

  - *producing a result out of range:*  
    <span id="index-result-out-of-range"></span>
    
    On two’s complement machines, arithmetic is performed modulo 2\*\*bits-per-cell for single arithmetic and 4\*\*bits-per-cell for double arithmetic (with appropriate mapping for signed types). Division by zero typically results in a `-10 throw` (divide by zero) or `-55 throw` (floating point unidentified fault). Overflow on division may result in these errors or in `-11 throw` (result out of range). `Gforth-fast` may silently produce bogus results on division overflow or division by zero. `Convert` and `>number` currently overflow silently.

  - *reading from an empty data or return stack:*  
    <span id="index-stack-empty"></span> <span id="index-stack-underflow"></span> <span id="index-return-stack-underflow"></span>
    
    The data stack is checked by the outer (aka text) interpreter after every word executed. If it has underflowed, a `-4 throw` (Stack underflow) is performed. Apart from that, stacks may be checked or not, depending on operating system, installation, and invocation. If they are caught by a check, they typically result in `-4 throw` (Stack underflow), `-6 throw` (Return stack underflow) or `-9 throw` (Invalid memory address), depending on the platform and which stack underflows and by how much. Note that even if the system uses checking (through the MMU), your program may have to underflow by a significant number of stack items to trigger the reaction (the reason for this is that the MMU, and therefore the checking, works with a page-size granularity). If there is no checking, the symptoms resulting from an underflow are similar to those from an overflow. Unbalanced return stack errors can result in a variety of symptoms, including `-9 throw` (Invalid memory address) and Illegal Instruction (typically `-260 throw`).

  - *unexpected end of the input buffer, resulting in an attempt to use a zero-length string as a name:*  
    <span id="index-unexpected-end-of-the-input-buffer"></span> <span id="index-zero_002dlength-string-as-a-name"></span> <span id="index-Attempt-to-use-zero_002dlength-string-as-a-name"></span>
    
    `Create` and its descendants perform a `-16 throw` (Attempt to use zero-length string as a name). Words like `'` probably will not find what they search. Note that it is possible to create zero-length names with `nextname` (should it not?).

  - *`>IN` greater than input buffer:*  
    <span id="index-_003eIN-greater-than-input-buffer"></span>
    
    The next invocation of a parsing word returns a string with length 0.

  - *`RECURSE` appears after `DOES>`:*  
    <span id="index-RECURSE-appears-after-DOES_003e"></span>
    
    Compiles a recursive call to the code after `DOES>`.

  - *argument input source different than current input source for `RESTORE-INPUT`:*  
    <span id="index-argument-input-source-different-than-current-input-source-for-RESTORE_002dINPUT"></span> <span id="index-argument-type-mismatch_002c-RESTORE_002dINPUT"></span> <span id="index-RESTORE_002dINPUT_002c-Argument-type-mismatch"></span>
    
    `-12 THROW`. Note that, once an input file is closed (e.g., because the end of the file was reached), its source-id may be reused. Therefore, restoring an input source specification referencing a closed file may lead to unpredictable results instead of a `-12 THROW`.
    
    In the future, Gforth may be able to restore input source specifications from other than the current input source.

  - *data space containing definitions gets de-allocated:*  
    <span id="index-data-space-containing-definitions-gets-de_002dallocated"></span>
    
    Deallocation with `allot` is not checked. This typically results in memory access faults or execution of illegal instructions.

  - *data space read/write with incorrect alignment:*  
    <span id="index-data-space-read_002fwrite-with-incorrect-alignment"></span> <span id="index-alignment-faults"></span> <span id="index-address-alignment-exception"></span>
    
    Processor-dependent. Typically results in a `-23 throw` (Address alignment exception). Under Linux-Intel on a 486 or later processor with alignment turned on, incorrect alignment results in a `-9 throw` (Invalid memory address). There are reportedly some processors with alignment restrictions that do not report violations.

  - *data space pointer not properly aligned, `,`, `C,`:*  
    <span id="index-data-space-pointer-not-properly-aligned_002c-_002c_002c-C_002c"></span>
    
    Like other alignment errors.

  - *less than u+2 stack items (`PICK` and `ROLL`):*  
    Like other stack underflows.

  - *loop control parameters not available:*  
    <span id="index-loop-control-parameters-not-available"></span>
    
    Not checked. The counted loop words simply assume that the top of return stack items are loop control parameters and behave accordingly.

  - *most recent definition does not have a name (`IMMEDIATE`):*  
    <span id="index-most-recent-definition-does-not-have-a-name-_0028IMMEDIATE_0029"></span> <span id="index-last-word-was-headerless"></span>
    
    `abort" last word was headerless"`.

  - *name not defined by `VALUE` used by `TO`:*  
    <span id="index-name-not-defined-by-VALUE-used-by-TO"></span> <span id="index-TO-on-non_002dVALUEs"></span> <span id="index-Invalid-name-argument_002c-TO"></span>
    
    `-32 throw` (Invalid name argument) (unless name is a local or was defined by `CONSTANT`; in the latter case it just changes the constant).

  - *name not found (`'`, `POSTPONE`, `[']`, `[COMPILE]`):*  
    <span id="index-name-not-found-_0028_0027_002c-POSTPONE_002c-_005b_0027_005d_002c-_005bCOMPILE_005d_0029"></span> <span id="index-undefined-word_002c-_0027_002c-POSTPONE_002c-_005b_0027_005d_002c-_005bCOMPILE_005d"></span>
    
    `-13 throw` (Undefined word)

  - *parameters are not of the same type (`DO`, `?DO`, `WITHIN`):*  
    <span id="index-parameters-are-not-of-the-same-type-_0028DO_002c-_003fDO_002c-WITHIN_0029"></span>
    
    Gforth behaves as if they were of the same type. I.e., you can predict the behaviour by interpreting all parameters as, e.g., signed.

  - *`POSTPONE` or `[COMPILE]` applied to `TO`:*  
    <span id="index-POSTPONE-or-_005bCOMPILE_005d-applied-to-TO"></span>
    
    Assume `: X POSTPONE TO ; IMMEDIATE`. `X` performs the compilation semantics of `TO`.

  - *String longer than a counted string returned by `WORD`:*  
    <span id="index-string-longer-than-a-counted-string-returned-by-WORD"></span> <span id="index-WORD_002c-string-overflow"></span>
    
    Not checked. The string will be ok, but the count will, of course, contain only the least significant bits of the length.

  - *u greater than or equal to the number of bits in a cell (`LSHIFT`, `RSHIFT`):*  
    <span id="index-LSHIFT_002c-large-shift-counts"></span> <span id="index-RSHIFT_002c-large-shift-counts"></span>
    
    Processor-dependent. Typical behaviours are returning 0 and using only the low bits of the shift count.

  - *word not defined via `CREATE`:*  
    <span id="index-_003eBODY-of-non_002dCREATEd-words"></span>
    
    `>BODY` produces the PFA of the word no matter how it was defined.
    
    <span id="index-DOES_003e-of-non_002dCREATEd-words"></span>
    
    `DOES>` changes the execution semantics of the last defined word no matter how it was defined. E.g., `CONSTANT DOES>` is equivalent to `CREATE , DOES>`.

  - *words improperly used outside `<#` and `#>`:*  
    Not checked. As usual, you can expect memory faults.

-----

<div class="header">

Next: [core-other](core_002dother.html#core_002dother), Previous: [core-idef](core_002didef.html#core_002didef), Up: [The Core Words](The-Core-Words.html#The-Core-Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
