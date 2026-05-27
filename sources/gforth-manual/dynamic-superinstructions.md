> Source: https://gforth.org/manual/Dynamic-Superinstructions.html

<span id="Dynamic-Superinstructions"></span>

<div class="header">

Next: [DOES\>](DOES_003e.html#DOES_003e), Previous: [Direct or Indirect Threaded?](Direct-or-Indirect-Threaded_003f.html#Direct-or-Indirect-Threaded_003f), Up: [Threading](Threading.html#Threading)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Dynamic-Superinstructions-1"></span>

#### 14.2.3 Dynamic Superinstructions

<span id="index-Dynamic-superinstructions-with-replication"></span> <span id="index-Superinstructions"></span> <span id="index-Replication"></span>

The engines `gforth` and `gforth-fast` use another optimization: Dynamic superinstructions with replication. As an example, consider the following colon definition:

<div class="example">

``` example
: squared ( n1 -- n2 )
  dup * ;
```

</div>

Gforth compiles this into the threaded code sequence

<div class="example">

``` example
dup
*
;s
```

</div>

In normal direct threaded code there is a code address occupying one cell for each of these primitives. Each code address points to a machine code routine, and the interpreter jumps to this machine code in order to execute the primitive. The routines for these three primitives are (in `gforth-fast` on the 386):

<div class="example">

``` example
Code dup  
( $804B950 )  add     esi , # -4  \ $83 $C6 $FC 
( $804B953 )  add     ebx , # 4  \ $83 $C3 $4 
( $804B956 )  mov     dword ptr 4 [esi] , ecx  \ $89 $4E $4 
( $804B959 )  jmp     dword ptr FC [ebx]  \ $FF $63 $FC 
end-code
Code *  
( $804ACC4 )  mov     eax , dword ptr 4 [esi]  \ $8B $46 $4 
( $804ACC7 )  add     esi , # 4  \ $83 $C6 $4 
( $804ACCA )  add     ebx , # 4  \ $83 $C3 $4 
( $804ACCD )  imul    ecx , eax  \ $F $AF $C8 
( $804ACD0 )  jmp     dword ptr FC [ebx]  \ $FF $63 $FC 
end-code
Code ;s  
( $804A693 )  mov     eax , dword ptr [edi]  \ $8B $7 
( $804A695 )  add     edi , # 4  \ $83 $C7 $4 
( $804A698 )  lea     ebx , dword ptr 4 [eax]  \ $8D $58 $4 
( $804A69B )  jmp     dword ptr FC [ebx]  \ $FF $63 $FC 
end-code
```

</div>

With dynamic superinstructions and replication the compiler does not just lay down the threaded code, but also copies the machine code fragments, usually without the jump at the end.

<div class="example">

``` example
( $4057D27D )  add     esi , # -4  \ $83 $C6 $FC 
( $4057D280 )  add     ebx , # 4  \ $83 $C3 $4 
( $4057D283 )  mov     dword ptr 4 [esi] , ecx  \ $89 $4E $4 
( $4057D286 )  mov     eax , dword ptr 4 [esi]  \ $8B $46 $4 
( $4057D289 )  add     esi , # 4  \ $83 $C6 $4 
( $4057D28C )  add     ebx , # 4  \ $83 $C3 $4 
( $4057D28F )  imul    ecx , eax  \ $F $AF $C8 
( $4057D292 )  mov     eax , dword ptr [edi]  \ $8B $7 
( $4057D294 )  add     edi , # 4  \ $83 $C7 $4 
( $4057D297 )  lea     ebx , dword ptr 4 [eax]  \ $8D $58 $4 
( $4057D29A )  jmp     dword ptr FC [ebx]  \ $FF $63 $FC 
```

</div>

Only when a threaded-code control-flow change happens (e.g., in `;s`), the jump is appended. This optimization eliminates many of these jumps and makes the rest much more predictable. The speedup depends on the processor and the application; on the Athlon and Pentium III this optimization typically produces a speedup by a factor of 2.

The code addresses in the direct-threaded code are set to point to the appropriate points in the copied machine code, in this example like this:

<div class="example">

``` example
primitive  code address
   dup       $4057D27D
   *         $4057D286
   ;s        $4057D292
```

</div>

Thus there can be threaded-code jumps to any place in this piece of code. This also simplifies decompilation quite a bit.

<span id="index-_002d_002dno_002ddynamic-command_002dline-option"></span> <span id="index-_002d_002dno_002dsuper-command_002dline-option"></span>

You can disable this optimization with `--no-dynamic`. You can use the copying without eliminating the jumps (i.e., dynamic replication, but without superinstructions) with `--no-super`; this gives the branch prediction benefit alone; the effect on performance depends on the CPU; on the Athlon and Pentium III the speedup is a little less than for dynamic superinstructions with replication.

<span id="index-patching-threaded-code"></span>

One use of these options is if you want to patch the threaded code. With superinstructions, many of the dispatch jumps are eliminated, so patching often has no effect. These options preserve all the dispatch jumps.

<span id="index-_002d_002ddynamic-command_002dline-option"></span>

On some machines dynamic superinstructions are disabled by default, because it is unsafe on these machines. However, if you feel adventurous, you can enable it with `--dynamic`.

-----

<div class="header">

Next: [DOES\>](DOES_003e.html#DOES_003e), Previous: [Direct or Indirect Threaded?](Direct-or-Indirect-Threaded_003f.html#Direct-or-Indirect-Threaded_003f), Up: [Threading](Threading.html#Threading)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
