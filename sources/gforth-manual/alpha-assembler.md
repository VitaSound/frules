> Source: https://gforth.org/manual/Alpha-Assembler.html

<span id="Alpha-Assembler"></span>

<div class="header">

Next: [MIPS assembler](MIPS-assembler.html#MIPS-assembler), Previous: [AMD64 Assembler](AMD64-Assembler.html#AMD64-Assembler), Up: [Assembler and Code Words](Assembler-and-Code-Words.html#Assembler-and-Code-Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Alpha-Assembler-1"></span>

#### 5.27.6 Alpha Assembler

The Alpha assembler and disassembler were originally written by Bernd Thallner.

The register names `a0`–`a5` are not available to avoid shadowing hex numbers.

Immediate forms of arithmetic instructions are distinguished by a `#` just before the `,`, e.g., `and#,` (note: `lda,` does not count as arithmetic instruction).

You have to specify all operands to an instruction, even those that other assemblers consider optional, e.g., the destination register for `br,`, or the destination register and hint for `jmp,`.

You can specify conditions for `if,` by removing the first `b` and the trailing `,` from a branch with a corresponding name; e.g.,

<div class="example">

``` example
11 fgt if, \ if F11>0e
  ...
endif,
```

</div>

`fbgt,` gives `fgt`.
