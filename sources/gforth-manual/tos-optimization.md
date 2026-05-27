> Source: https://gforth.org/manual/TOS-Optimization.html

<span id="TOS-Optimization"></span>

<div class="header">

Next: [Produced code](Produced-code.html#Produced-code), Previous: [Automatic Generation](Automatic-Generation.html#Automatic-Generation), Up: [Primitives](Primitives.html#Primitives)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="TOS-Optimization-1"></span>

#### 14.3.2 TOS Optimization

<span id="index-TOS-optimization-for-primitives"></span> <span id="index-primitives_002c-keeping-the-TOS-in-a-register"></span>

An important optimization for stack machine emulators, e.g., Forth engines, is keeping one or more of the top stack items in registers. If a word has the stack effect *in1*...*inx* `--` *out1*...*outy*, keeping the top *n* items in registers

  - is better than keeping *n-1* items, if *x\>=n* and *y\>=n*, due to fewer loads from and stores to the stack.
  - is slower than keeping *n-1* items, if *x\<\>y* and *x\<n* and *y\<n*, due to additional moves between registers.

<span id="index-_002dDUSE_005fTOS"></span> <span id="index-_002dDUSE_005fNO_005fTOS"></span>

In particular, keeping one item in a register is never a disadvantage, if there are enough registers. Keeping two items in registers is a disadvantage for frequent words like `?branch`, constants, variables, literals and `i`. Therefore our generator only produces code that keeps zero or one items in registers. The generated C code covers both cases; the selection between these alternatives is made at C-compile time using the switch `-DUSE_TOS`. `TOS` in the C code for `+` is just a simple variable name in the one-item case, otherwise it is a macro that expands into `sp[0]`. Note that the GNU C compiler tries to keep simple variables like `TOS` in registers, and it usually succeeds, if there are enough registers.

<span id="index-_002dDUSE_005fFTOS"></span> <span id="index-_002dDUSE_005fNO_005fFTOS"></span>

The primitive generator performs the TOS optimization for the floating-point stack, too (`-DUSE_FTOS`). For floating-point operations the benefit of this optimization is even larger: floating-point operations take quite long on most processors, but can be performed in parallel with other operations as long as their results are not used. If the FP-TOS is kept in a register, this works. If it is kept on the stack, i.e., in memory, the store into memory has to wait for the result of the floating-point operation, lengthening the execution time of the primitive considerably.

The TOS optimization makes the automatic generation of primitives a bit more complicated. Just replacing all occurrences of `sp[0]` by `TOS` is not sufficient. There are some special cases to consider:

  - In the case of `dup ( w -- w w )` the generator must not eliminate the store to the original location of the item on the stack, if the TOS optimization is turned on.
  - Primitives with stack effects of the form `--` *out1*...*outy* must store the TOS to the stack at the start. Likewise, primitives with the stack effect *in1*...*inx* `--` must load the TOS from the stack at the end. But for the null stack effect `--` no stores or loads should be generated.

-----

<div class="header">

Next: [Produced code](Produced-code.html#Produced-code), Previous: [Automatic Generation](Automatic-Generation.html#Automatic-Generation), Up: [Primitives](Primitives.html#Primitives)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
