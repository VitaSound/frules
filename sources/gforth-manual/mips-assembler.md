> Source: https://gforth.org/manual/MIPS-assembler.html

<span id="MIPS-assembler"></span>

<div class="header">

Next: [PowerPC assembler](PowerPC-assembler.html#PowerPC-assembler), Previous: [Alpha Assembler](Alpha-Assembler.html#Alpha-Assembler), Up: [Assembler and Code Words](Assembler-and-Code-Words.html#Assembler-and-Code-Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="MIPS-assembler-1"></span>

#### 5.27.7 MIPS assembler

The MIPS assembler was originally written by Christian Pirker.

Currently the assembler and disassembler covers most of the MIPS32 architecture and doesn’t support FP instructions.

The register names `$a0`–`$a3` are not available to avoid shadowing hex numbers. Use register numbers `$4`–`$7` instead.

Nothing distinguishes registers from immediate values. Use explicit opcode names with the `i` suffix for instructions with immediate argument. E.g. `addiu,` in place of `addu,`.

Where the architecture manual specifies several formats for the instruction (e.g., for `jalr,`),use the one with more arguments (i.e. two for `jalr,`). When in doubt, see `arch/mips/testasm.fs` for an example of correct use.

Branches and jumps in the MIPS architecture have a delay slot. You have to fill it manually (the simplest way is to use `nop,`), the assembler does not do it for you (unlike `as`). Even `if,`, `ahead,`, `until,`, `again,`, `while,`, `else,` and `repeat,` need a delay slot. Since `begin,` and `then,` just specify branch targets, they are not affected. For branches the argument specifying the target is a relative address. Add the address of the delay slot to get the absolute address.

Note that you must not put branches nor jumps (nor control-flow instructions) into the delay slot. Also it is a bad idea to put pseudo-ops such as `li,` into a delay slot, as these may expand to several instructions. The MIPS I architecture also had load delay slots, and newer MIPSes still have restrictions on using `mfhi,` and `mflo,`. Be careful to satisfy these restrictions, the assembler does not do it for you.

Some example of instructions are:

<div class="example">

``` example
$ra  12 $sp  sw,         \ sw    ra,12(sp)
$4    8 $s0  lw,         \ lw    a0,8(s0)
$v0  $0  lui,            \ lui   v0,0x0
$s0  $s4  $12  addiu,    \ addiu s0,s4,0x12
$s0  $s4  $4  addu,      \ addu  s0,s4,$a0
$ra  $t9  jalr,          \ jalr  t9
```

</div>

You can specify the conditions for `if,` etc. by taking a conditional branch and leaving away the `b` at the start and the `,` at the end. E.g.,

<div class="example">

``` example
4 5 eq if,
  ... \ do something if $4 equals $5
then,
```

</div>

The calling conventions for 32-bit MIPS machines is to pass the first 4 arguments in registers `$4`..`$7`, and to use `$v0`-`$v1` for return values. In addition to these registers, it is ok to clobber registers `$t0`-`$t8` without saving and restoring them.

If you use `jalr,` to call into dynamic library routines, you must first load the called function’s address into `$t9`, which is used by position-indirect code to do relative memory accesses.

Here is an example of a MIPS32 `abi-code` word:

<div class="example">

``` example
abi-code my+  ( n1 n2 -- n3 )
  \ SP passed in $4, returned in $v0
  $t0  4 $4  lw,         \ load n1, n2 from stack
  $t1  0 $4  lw,    
  $t0  $t0  $t1  addu,   \ add n1+n2, result in $t0
  $t0  4 $4  sw,         \ store result (overwriting n1)
  $ra  jr,               \ return to caller
  $v0  $4  4  addiu,     \ (delay slot) return uptated SP in $v0
end-code
```

</div>

-----

<div class="header">

Next: [PowerPC assembler](PowerPC-assembler.html#PowerPC-assembler), Previous: [Alpha Assembler](Alpha-Assembler.html#Alpha-Assembler), Up: [Assembler and Code Words](Assembler-and-Code-Words.html#Assembler-and-Code-Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
