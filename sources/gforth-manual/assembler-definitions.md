> Source: https://gforth.org/manual/Assembler-Definitions.html

<span id="Assembler-Definitions"></span>

<div class="header">

Next: [Common Assembler](Common-Assembler.html#Common-Assembler), Previous: [Assembler and Code Words](Assembler-and-Code-Words.html#Assembler-and-Code-Words), Up: [Assembler and Code Words](Assembler-and-Code-Words.html#Assembler-and-Code-Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Definitions-in-assembly-language"></span>

#### 5.27.1 Definitions in assembly language

Gforth provides ways to implement words in assembly language (using `abi-code`...`end-code`), and also ways to define defining words with arbitrary run-time behaviour (like `does>`), where (unlike `does>`) the behaviour is not defined in Forth, but in assembly language (with `;code`).

However, the machine-independent nature of Gforth poses a few problems: First of all, Gforth runs on several architectures, so it can provide no standard assembler. It does provide assemblers for several of the architectures it runs on, though. Moreover, you can use a system-independent assembler in Gforth, or compile machine code directly with `,` and `c,`.

Another problem is that the virtual machine registers of Gforth (the stack pointers and the virtual machine instruction pointer) depend on the installation and engine. Also, which registers are free to use also depend on the installation and engine. So any code written to run in the context of the Gforth virtual machine is essentially limited to the installation and engine it was developed for (it may run elsewhere, but you cannot rely on that).

Fortunately, you can define `abi-code` words in Gforth that are portable to any Gforth running on a platform with the same calling convention (ABI); typically this means portability to the same architecture/OS combination, sometimes crossing OS boundaries).

<span id="index-assembler--_002d_002d--tools_002dext"></span> <span id="index-assembler-1"></span> <span id="index-assembler-2"></span>

<div class="format">

``` format
assembler       –         tools-ext       “assembler”
```

</div>

A vocubulary: Replaces the wordlist at the top of the search order with the assembler wordlist.

<span id="index-init_002dasm--_002d_002d--gforth"></span> <span id="index-init_002dasm"></span> <span id="index-init_002dasm-1"></span>

<div class="format">

``` format
init-asm       –         gforth       “init-asm”
```

</div>

Pushes the assembler wordlist on the search order.

<span id="index-abi_002dcode--_0022name_0022-_002d_002d-colon_002dsys--gforth"></span> <span id="index-abi_002dcode"></span> <span id="index-abi_002dcode-1"></span>

<div class="format">

``` format
abi-code       "name" – colon-sys         gforth       “abi-code”
```

</div>

Start a native code definition that is called using the platform’s ABI conventions corresponding to the C-prototype:

<div class="example">

``` example
Cell *function(Cell *sp, Float **fpp);
```

</div>

The FP stack pointer is passed in by providing a reference to a memory location containing the FP stack pointer and is passed out by storing the changed FP stack pointer there (if necessary).

<span id="index-end_002dcode--colon_002dsys-_002d_002d--gforth"></span> <span id="index-end_002dcode"></span> <span id="index-end_002dcode-1"></span>

<div class="format">

``` format
end-code       colon-sys –         gforth       “end-code”
```

</div>

End a code definition. Note that you have to assemble the return from the ABI call (for `abi-code`) or the dispatch to the next VM instruction (for `code` and `;code`) yourself.

<span id="index-code--_0022name_0022-_002d_002d-colon_002dsys--tools_002dext"></span> <span id="index-code"></span> <span id="index-code-1"></span>

<div class="format">

``` format
code       "name" – colon-sys         tools-ext       “code”
```

</div>

Start a native code definition that runs in the context of the Gforth virtual machine (engine). Such a definition is not portable between Gforth installations, so we recommend using `abi-code` instead of `code`. You have to end a `code` definition with a dispatch to the next virtual machine instruction.

<span id="index-_003bcode--compilation_002e-colon_002dsys1-_002d_002d-colon_002dsys2--tools_002dext"></span> <span id="index-_003bcode"></span> <span id="index-_003bcode-1"></span>

<div class="format">

``` format
;code       compilation. colon-sys1 – colon-sys2         tools-ext       “semicolon-code”
```

</div>

The code after `;code` becomes the behaviour of the last defined word (which must be a `create`d word). The same caveats apply as for `code`, so we recommend using `;abi-code` instead.

<span id="index-flush_002dicache--c_002daddr-u-_002d_002d--gforth"></span> <span id="index-flush_002dicache"></span> <span id="index-flush_002dicache-1"></span>

<div class="format">

``` format
flush-icache       c-addr u –        gforth       “flush-icache”
```

</div>

Make sure that the instruction cache of the processor (if there is one) does not contain stale data at *c-addr* and *u* bytes afterwards. `END-CODE` performs a `flush-icache` automatically. Caveat: `flush-icache` might not work on your installation; this is usually the case if direct threading is not supported on your machine (take a look at your `machine.h`) and your machine has a separate instruction cache. In such cases, `flush-icache` does nothing instead of flushing the instruction cache.

If `flush-icache` does not work correctly, `abi-code` words etc. will not work (reliably), either.

The typical usage of these words can be shown most easily by analogy to the equivalent high-level defining words:

<div class="example">

``` example
: foo                              abi-code foo
   <high-level Forth words>              <assembler>
;                                  end-code
                                
: bar                              : bar
   <high-level Forth words>           <high-level Forth words>
   CREATE                             CREATE
      <high-level Forth words>           <high-level Forth words>
   DOES>                              ;code
      <high-level Forth words>           <assembler>
;                                  end-code
```

</div>

For using `abi-code`, take a look at the ABI documentation of your platform to see how the parameters are passed (so you know where you get the stack pointers) and how the return value is passed (so you know where the data stack pointer is returned). The ABI documentation also tells you which registers are saved by the caller (caller-saved), so you are free to destroy them in your code, and which registers have to be preserved by the called word (callee-saved), so you have to save them before using them, and restore them afterwards. For some architectures and OSs we give short summaries of the parts of the calling convention in the appropriate sections. More reverse-engineering oriented people can also find out about the passing and returning of the stack pointers through `see abi-call`.

Most ABIs pass the parameters through registers, but some (in particular the most common 386 (aka IA-32) calling conventions) pass them on the architectural stack. The common ABIs all pass the return value in a register.

Other things you need to know for using `abi-code` is that both the data and the FP stack grow downwards (towards lower addresses) in Gforth, with `1 cells` size per cell, and `1 floats` size per FP value.

Here’s an example of using `abi-code` on the 386 architecture:

<div class="example">

``` example
abi-code my+ ( n1 n2 -- n )
4 sp d) ax mov \ sp into return reg
ax )    cx mov \ tos
4 #     ax add \ update sp (pop)
cx    ax ) add \ sec = sec+tos
ret            \ return from my+
end-code
```

</div>

An AMD64 variant of this example can be found in [AMD64 Assembler](AMD64-Assembler.html#AMD64-Assembler).

Here’s a 386 example that deals with FP values:

<div class="example">

``` example
abi-code my-f+ ( r1 r2 -- r )
8 sp d) cx mov  \ load address of fp
cx )    dx mov  \ load fp
.fl dx )   fld  \ r2
8 #     dx add  \ update fp
.fl dx )   fadd \ r1+r2
.fl dx )   fstp \ store r
dx    cx ) mov  \ store new fp
4 sp d) ax mov  \ sp into return reg
ret             \ return from my-f+
end-code
```

</div>

-----

<div class="header">

Next: [Common Assembler](Common-Assembler.html#Common-Assembler), Previous: [Assembler and Code Words](Assembler-and-Code-Words.html#Assembler-and-Code-Words), Up: [Assembler and Code Words](Assembler-and-Code-Words.html#Assembler-and-Code-Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
