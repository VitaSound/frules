> Source: https://gforth.org/manual/PowerPC-assembler.html

<span id="PowerPC-assembler"></span>

<div class="header">

Next: [ARM Assembler](ARM-Assembler.html#ARM-Assembler), Previous: [MIPS assembler](MIPS-assembler.html#MIPS-assembler), Up: [Assembler and Code Words](Assembler-and-Code-Words.html#Assembler-and-Code-Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="PowerPC-assembler-1"></span>

#### 5.27.8 PowerPC assembler

The PowerPC assembler and disassembler were contributed by Michal Revucky.

This assembler does not follow the convention of ending mnemonic names with a “,”, so some mnemonic names shadow regular Forth words (in particular: `and or xor fabs`); so if you want to use the Forth words, you have to make them visible first, e.g., with `also forth`.

Registers are referred to by their number, e.g., `9` means the integer register 9 or the FP register 9 (depending on the instruction).

Because there is no way to distinguish registers from immediate values, you have to explicitly use the immediate forms of instructions, i.e., `addi,`, not just `add,`.

The assembler and disassembler usually support the most general form of an instruction, but usually not the shorter forms (especially for branches).
