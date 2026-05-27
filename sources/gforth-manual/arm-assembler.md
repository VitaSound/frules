> Source: https://gforth.org/manual/ARM-Assembler.html

<span id="ARM-Assembler"></span>

<div class="header">

Next: [Other assemblers](Other-assemblers.html#Other-assemblers), Previous: [PowerPC assembler](PowerPC-assembler.html#PowerPC-assembler), Up: [Assembler and Code Words](Assembler-and-Code-Words.html#Assembler-and-Code-Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="ARM-Assembler-1"></span>

#### 5.27.9 ARM Assembler

The ARM assembler includes all instruction of ARM architecture version 4, and the BLX instruction from architecture 5. It does not (yet) have support for Thumb instructions. It also lacks support for any co-processors.

The assembler uses a postfix syntax with the same operand order as used in the ARM Architecture Reference Manual. Mnemonics are suffixed by a comma.

Registers are specified by their names `r0` through `r15`, with the aliases `pc`, `lr`, `sp`, `ip` and `fp` provided for convenience. Note that `ip` refers to the“intra procedure call scratch register” (`r12`) and does not refer to an instruction pointer. `sp` refers to the ARM ABI stack pointer (`r13`) and not the Forth stack pointer.

Condition codes can be specified anywhere in the instruction, but will be most readable if specified just in front of the mnemonic. The ’S’ flag is not a separate word, but encoded into instruction mnemonics, ie. just use `adds,` instead of `add,` if you want the status register to be updated.

The following table lists the syntax of operands for general instructions:

<div class="example">

``` example
Gforth          normal assembler      description
123 #           #123                  immediate
r12             r12                   register
r12 4 #LSL      r12, LSL #4           shift left by immediate
r12 r1 LSL      r12, LSL r1           shift left by register
r12 4 #LSR      r12, LSR #4           shift right by immediate
r12 r1 LSR      r12, LSR r1           shift right by register
r12 4 #ASR      r12, ASR #4           arithmetic shift right
r12 r1 ASR      r12, ASR r1           ... by register
r12 4 #ROR      r12, ROR #4           rotate right by immediate
r12 r1 ROR      r12, ROR r1           ... by register
r12 RRX         r12, RRX              rotate right with extend by 1
```

</div>

Memory operand syntax is listed in this table:

<div class="example">

``` example
Gforth            normal assembler      description
r4 ]              [r4]                  register
r4 4 #]           [r4, #+4]             register with immediate offset
r4 -4 #]          [r4, #-4]             with negative offset
r4 r1 +]          [r4, +r1]             register with register offset
r4 r1 -]          [r4, -r1]             with negated register offset
r4 r1 2 #LSL -]   [r4, -r1, LSL #2]     with negated and shifted offset
r4 4 #]!          [r4, #+4]!            immediate preincrement
r4 r1 +]!         [r4, +r1]!            register preincrement
r4 r1 -]!         [r4, +r1]!            register predecrement
r4 r1 2 #LSL +]!  [r4, +r1, LSL #2]!    shifted preincrement
r4 -4 ]#          [r4], #-4             immediate postdecrement
r4 r1 ]+          [r4], r1              register postincrement
r4 r1 ]-          [r4], -r1             register postdecrement
r4 r1 2 #LSL ]-   [r4], -r1, LSL #2     shifted postdecrement
' xyz >body [#]   xyz                   PC-relative addressing
```

</div>

Register lists for load/store multiple instructions are started and terminated by using the words `{` and `}` respectively. Between braces, register names can be listed one by one or register ranges can be formed by using the postfix operator `r-r`. The `^` flag is not encoded in the register list operand, but instead directly encoded into the instruction mnemonic, ie. use `^ldm,` and `^stm,`.

Addressing modes for load/store multiple are not encoded as instruction suffixes, but instead specified like an addressing mode, Use one of `DA`, `IA`, `DB`, `IB`, `DA!`, `IA!`, `DB!` or `IB!`.

The following table gives some examples:

<div class="example">

``` example
Gforth                           normal assembler
r4 ia  { r0 r7 r8 }  stm,        stmia    r4, {r0,r7,r8}
r4 db!  { r0 r7 r8 }  ldm,       ldmdb    r4!, {r0,r7,r8}
sp ia!  { r0 r15 r-r }  ^ldm,    ldmfd    sp!, {r0-r15}^
```

</div>

Control structure words typical for Forth assemblers are available: `if,` `ahead,` `then,` `else,` `begin,` `until,` `again,` `while,` `repeat,` `repeat-until,`. Conditions are specified in front of these words:

<div class="example">

``` example
r1 r2 cmp,    \ compare r1 and r2
eq if,        \ equal?
   ...          \ code executed if r1 == r2
then,
```

</div>

Example of a definition using the ARM assembler:

<div class="example">

``` example
abi-code my+ ( n1 n2 --  n3 )
   \ arm abi: r0=SP, r1=&FP, r2,r3,r12 saved by caller
   r0 IA!  { r2 r3 }  ldm,     \ pop r2 = n2, r3 = n1
   r3  r2  r3         add,     \ r3 = n1+n1
   r3  r0 -4 #]!      str,     \ push r3
   pc  lr             mov,     \ return to caller, new SP in r0
end-code
```

</div>

-----

<div class="header">

Next: [Other assemblers](Other-assemblers.html#Other-assemblers), Previous: [PowerPC assembler](PowerPC-assembler.html#PowerPC-assembler), Up: [Assembler and Code Words](Assembler-and-Code-Words.html#Assembler-and-Code-Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
