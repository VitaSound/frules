> Source: https://gforth.org/manual/386-Assembler.html

<span id="g_t386-Assembler"></span>

<div class="header">

Next: [AMD64 Assembler](AMD64-Assembler.html#AMD64-Assembler), Previous: [Common Disassembler](Common-Disassembler.html#Common-Disassembler), Up: [Assembler and Code Words](Assembler-and-Code-Words.html#Assembler-and-Code-Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="g_t386-Assembler-1"></span>

#### 5.27.4 386 Assembler

The 386 assembler included in Gforth was written by Bernd Paysan, it’s available under GPL, and originally part of bigFORTH.

The 386 disassembler included in Gforth was written by Andrew McKewan and is in the public domain.

The disassembler displays code in an Intel-like prefix syntax.

The assembler uses a postfix syntax with AT\&T-style parameter order (i.e., destination last).

The assembler includes all instruction of the Athlon, i.e. 486 core instructions, Pentium and PPro extensions, floating point, MMX, 3Dnow\!, but not ISSE. It’s an integrated 16- and 32-bit assembler. Default is 32 bit, you can switch to 16 bit with .86 and back to 32 bit with .386.

There are several prefixes to switch between different operation sizes, `.b` for byte accesses, `.w` for word accesses, `.d` for double-word accesses. Addressing modes can be switched with `.wa` for 16 bit addresses, and `.da` for 32 bit addresses. You don’t need a prefix for byte register names (`AL` et al).

For floating point operations, the prefixes are `.fs` (IEEE single), `.fl` (IEEE double), `.fx` (extended), `.fw` (word), `.fd` (double-word), and `.fq` (quad-word). The default is `.fx`, so you need to specify `.fl` explicitly when dealing with Gforth FP values.

The MMX opcodes don’t have size prefixes, they are spelled out like in the Intel assembler. Instead of move from and to memory, there are PLDQ/PLDD and PSTQ/PSTD.

The registers lack the ’e’ prefix; even in 32 bit mode, eax is called ax. Immediate values are indicated by postfixing them with `#`, e.g., `3 #`. Here are some examples of addressing modes in various syntaxes:

<div class="example">

``` example
Gforth          Intel (NASM)   AT&T (gas)      Name
.w ax           ax             %ax             register (16 bit)
ax              eax            %eax            register (32 bit)
3 #             offset 3       $3              immediate
1000 #)         byte ptr 1000  1000            displacement
bx )            [ebx]          (%ebx)          base
100 di d)       100[edi]       100(%edi)       base+displacement
20 ax *4 i#)    20[eax*4]      20(,%eax,4)     (index*scale)+displacement
di ax *4 i)     [edi][eax*4]   (%edi,%eax,4)   base+(index*scale)
4 bx cx di)     4[ebx][ecx]    4(%ebx,%ecx)    base+index+displacement
12 sp ax *2 di) 12[esp][eax*2] 12(%esp,%eax,2) base+(index*scale)+displacement
```

</div>

You can use `L)` and `LI)` instead of `D)` and `DI)` to enforce 32-bit displacement fields (useful for later patching).

Some example of instructions are:

<div class="example">

``` example
ax bx mov             \ move ebx,eax
3 # ax mov            \ mov eax,3
100 di d) ax mov      \ mov eax,100[edi]
4 bx cx di) ax mov    \ mov eax,4[ebx][ecx]
.w ax bx mov          \ mov bx,ax
```

</div>

The following forms are supported for binary instructions:

<div class="example">

``` example
<reg> <reg> <inst>
<n> # <reg> <inst>
<mem> <reg> <inst>
<reg> <mem> <inst>
<n> # <mem> <inst>
```

</div>

The shift/rotate syntax is:

<div class="example">

``` example
<reg/mem> 1 # shl \ shortens to shift without immediate
<reg/mem> 4 # shl
<reg/mem> cl shl
```

</div>

Precede string instructions (`movs` etc.) with `.b` to get the byte version.

The control structure words `IF` `UNTIL` etc. must be preceded by one of these conditions: `vs vc u< u>= 0= 0<> u<= u> 0< 0>= ps pc < >= <= >`. (Note that most of these words shadow some Forth words when `assembler` is in front of `forth` in the search path, e.g., in `code` words). Currently the control structure words use one stack item, so you have to use `roll` instead of `cs-roll` to shuffle them (you can also use `swap` etc.).

Based on the Intel ABI (used in Linux), `abi-code` words can find the data stack pointer at `4 sp d)`, and the address of the FP stack pointer at `8 sp d)`; the data stack pointer is returned in `ax`; `Ax`, `cx`, and `dx` are caller-saved, so you do not need to preserve their values inside the word. You can return from the word with `ret`, the parameters are cleaned up by the caller.

For examples of 386 `abi-code` words, see [Assembler Definitions](Assembler-Definitions.html#Assembler-Definitions).

-----

<div class="header">

Next: [AMD64 Assembler](AMD64-Assembler.html#AMD64-Assembler), Previous: [Common Disassembler](Common-Disassembler.html#Common-Disassembler), Up: [Assembler and Code Words](Assembler-and-Code-Words.html#Assembler-and-Code-Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
