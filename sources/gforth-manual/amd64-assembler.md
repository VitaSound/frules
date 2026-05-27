> Source: https://gforth.org/manual/AMD64-Assembler.html

<span id="AMD64-Assembler"></span>

<div class="header">

Next: [Alpha Assembler](Alpha-Assembler.html#Alpha-Assembler), Previous: [386 Assembler](386-Assembler.html#g_t386-Assembler), Up: [Assembler and Code Words](Assembler-and-Code-Words.html#Assembler-and-Code-Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="AMD64-_0028x86_005f64_0029-Assembler"></span>

#### 5.27.5 AMD64 (x86\_64) Assembler

The AMD64 assembler is a slightly modified version of the 386 assembler, and as such shares most of the syntax. Two new prefixes, `.q` and `.qa`, are provided to select 64-bit operand and address sizes respectively. 64-bit sizes are the default, so normally you only have to use the other prefixes. Also there are additional register operands `R8`-`R15`.

The registers lack the ’e’ or ’r’ prefix; even in 64 bit mode, `rax` is called `ax`. Additional register operands are available to refer to the lowest-significant byte of all registers: `R8L`-`R15L`, `SPL`, `BPL`, `SIL`, `DIL`.

The Linux-AMD64 calling convention is to pass the first 6 integer parameters in rdi, rsi, rdx, rcx, r8 and r9 and to return the result in rax and rdx; to pass the first 8 FP parameters in xmm0–xmm7 and to return FP results in xmm0–xmm1. So `abi-code` words get the data stack pointer in `di` and the address of the FP stack pointer in `si`, and return the data stack pointer in `ax`. The other caller-saved registers are: r10, r11, xmm8-xmm15. This calling convention reportedly is also used in other non-Microsoft OSs.

Windows x64 passes the first four integer parameters in rcx, rdx, r8 and r9 and return the integer result in rax. The other caller-saved registers are r10 and r11.

Here is an example of an AMD64 `abi-code` word:

<div class="example">

``` example
abi-code my+  ( n1 n2 -- n3 )
\ SP passed in di, returned in ax,  address of FP passed in si
8 di d) ax lea        \ compute new sp in result reg
di )    dx mov        \ get old tos
dx    ax ) add        \ add to new tos
ret
end-code
```

</div>

Here’s a AMD64 example that deals with FP values:

<div class="example">

``` example
abi-code my-f+  ( r1 r2 -- r )
\ SP passed in di, returned in ax,  address of FP passed in si
si )       dx mov         \ load fp
8 dx d)  xmm0 movsd       \ r2
dx )     xmm0 addsd       \ r1+r2
xmm0  8 dx d) movsd       \ store r
8 #      si ) add         \ update fp
di         ax mov         \ sp into return reg
ret
end-code
```

</div>

-----

<div class="header">

Next: [Alpha Assembler](Alpha-Assembler.html#Alpha-Assembler), Previous: [386 Assembler](386-Assembler.html#g_t386-Assembler), Up: [Assembler and Code Words](Assembler-and-Code-Words.html#Assembler-and-Code-Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
