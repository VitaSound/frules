> Source: https://gforth.org/manual/Direct-or-Indirect-Threaded_003f.html

<span id="Direct-or-Indirect-Threaded_003f"></span>

<div class="header">

Next: [Dynamic Superinstructions](Dynamic-Superinstructions.html#Dynamic-Superinstructions), Previous: [Scheduling](Scheduling.html#Scheduling), Up: [Threading](Threading.html#Threading)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Direct-or-Indirect-Threaded_003f-1"></span>

#### 14.2.2 Direct or Indirect Threaded?

<span id="index-threading_002c-direct-or-indirect_003f"></span>

Threaded forth code consists of references to primitives (simple machine code routines like `+`) and to non-primitives (e.g., colon definitions, variables, constants); for a specific class of non-primitives (e.g., variables) there is one code routine (e.g., `dovar`), but each variable needs a separate reference to its data.

Traditionally Forth has been implemented as indirect threaded code, because this allows to use only one cell to reference a non-primitive (basically you point to the data, and find the code address there).

<span id="index-primitive_002dcentric-threaded-code"></span>

However, threaded code in Gforth (since 0.6.0) uses two cells for non-primitives, one for the code address, and one for the data address; the data pointer is an immediate argument for the virtual machine instruction represented by the code address. We call this *primitive-centric* threaded code, because all code addresses point to simple primitives. E.g., for a variable, the code address is for `lit` (also used for integer literals like `99`).

Primitive-centric threaded code allows us to use (faster) direct threading as dispatch method, completely portably (direct threaded code in Gforth before 0.6.0 required architecture-specific code). It also eliminates the performance problems related to I-cache consistency that 386 implementations have with direct threaded code, and allows additional optimizations.

<span id="index-hybrid-direct_002findirect-threaded-code"></span>

There is a catch, however: the `xt` parameter of `execute` can occupy only one cell, so how do we pass non-primitives with their code *and* data addresses to them? Our answer is to use indirect threaded dispatch for `execute` and other words that use a single-cell xt. So, normal threaded code in colon definitions uses direct threading, and `execute` and similar words, which dispatch to xts on the data stack, use indirect threaded code. We call this *hybrid direct/indirect* threaded code.

<span id="index-engines_002c-gforth-vs_002e-gforth_002dfast-vs_002e-gforth_002ditc"></span> <span id="index-gforth-engine"></span> <span id="index-gforth_002dfast-engine"></span>

The engines `gforth` and `gforth-fast` use hybrid direct/indirect threaded code. This means that with these engines you cannot use `,` to compile an xt. Instead, you have to use `compile,`.

<span id="index-gforth_002ditc-engine"></span>

If you want to compile xts with `,`, use `gforth-itc`. This engine uses plain old indirect threaded code. It still compiles in a primitive-centric style, so you cannot use `compile,` instead of `,` (e.g., for producing tables of xts with `] word1 word2 ... [`). If you want to do that, you have to use `gforth-itc` and execute `' , is compile,`. Your program can check if it is running on a hybrid direct/indirect threaded engine or a pure indirect threaded engine with `threading-method` (see [Threading Words](Threading-Words.html#Threading-Words)).

-----

<div class="header">

Next: [Dynamic Superinstructions](Dynamic-Superinstructions.html#Dynamic-Superinstructions), Previous: [Scheduling](Scheduling.html#Scheduling), Up: [Threading](Threading.html#Threading)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
