> Source: https://gforth.org/manual/Common-Disassembler.html

<span id="Common-Disassembler"></span>

<div class="header">

Next: [386 Assembler](386-Assembler.html#g_t386-Assembler), Previous: [Common Assembler](Common-Assembler.html#Common-Assembler), Up: [Assembler and Code Words](Assembler-and-Code-Words.html#Assembler-and-Code-Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Common-Disassembler-1"></span>

#### 5.27.3 Common Disassembler

<span id="index-disassembler_002c-general"></span> <span id="index-gdb-disassembler"></span>

You can disassemble a `code` word with `see` (see [Debugging](Debugging.html#Debugging)). You can disassemble a section of memory with

<span id="index-discode--addr-u-_002d_002d--gforth"></span> <span id="index-discode"></span> <span id="index-discode-1"></span>

<div class="format">

``` format
discode       addr u –         gforth       “discode”
```

</div>

hook for the disassembler: disassemble u bytes of code at addr

There are two kinds of disassembler for Gforth: The Forth disassembler (available on some CPUs) and the gdb disassembler (available on platforms with `gdb` and `mktemp`). If both are available, the Forth disassembler is used by default. If you prefer the gdb disassembler, say

<div class="example">

``` example
' disasm-gdb is discode
```

</div>

If neither is available, `discode` performs `dump`.

The Forth disassembler generally produces output that can be fed into the assembler (i.e., same syntax, etc.). It also includes additional information in comments. In particular, the address of the instruction is given in a comment before the instruction.

The gdb disassembler produces output in the same format as the gdb `disassemble` command (see [Source and machine code](http://sourceware.org/gdb/current/onlinedocs/gdb/Machine-Code.html#Machine-Code) in Debugging with GDB), in the default flavour (AT\&T syntax for the 386 and AMD64 architectures).

`See` may display more or less than the actual code of the word, because the recognition of the end of the code is unreliable. You can use `discode` if it did not display enough. It may display more, if the code word is not immediately followed by a named word. If you have something else there, you can follow the word with `align latest ,` to ensure that the end is recognized.

-----

<div class="header">

Next: [386 Assembler](386-Assembler.html#g_t386-Assembler), Previous: [Common Assembler](Common-Assembler.html#Common-Assembler), Up: [Assembler and Code Words](Assembler-and-Code-Words.html#Assembler-and-Code-Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
