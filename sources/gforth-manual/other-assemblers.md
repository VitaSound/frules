> Source: https://gforth.org/manual/Other-assemblers.html

<span id="Other-assemblers"></span>

<div class="header">

Previous: [ARM Assembler](ARM-Assembler.html#ARM-Assembler), Up: [Assembler and Code Words](Assembler-and-Code-Words.html#Assembler-and-Code-Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Other-assemblers-1"></span>

#### 5.27.10 Other assemblers

If you want to contribute another assembler/disassembler, please contact us (<anton@mips.complang.tuwien.ac.at>) to check if we have such an assembler already. If you are writing them from scratch, please use a similar syntax style as the one we use (i.e., postfix, commas at the end of the instruction names, see [Common Assembler](Common-Assembler.html#Common-Assembler)); make the output of the disassembler be valid input for the assembler, and keep the style similar to the style we used.

Hints on implementation: The most important part is to have a good test suite that contains all instructions. Once you have that, the rest is easy. For actual coding you can take a look at `arch/mips/disasm.fs` to get some ideas on how to use data for both the assembler and disassembler, avoiding redundancy and some potential bugs. You can also look at that file (and see [Advanced does\> usage example](Advanced-does_003e-usage-example.html#Advanced-does_003e-usage-example)) to get ideas how to factor a disassembler.

Start with the disassembler, because it’s easier to reuse data from the disassembler for the assembler than the other way round.

For the assembler, take a look at `arch/alpha/asm.fs`, which shows how simple it can be.
