> Source: https://gforth.org/manual/Threading-Words.html

<span id="Threading-Words"></span>

<div class="header">

Next: [Passing Commands to the OS](Passing-Commands-to-the-OS.html#Passing-Commands-to-the-OS), Previous: [Assembler and Code Words](Assembler-and-Code-Words.html#Assembler-and-Code-Words), Up: [Words](Words.html#Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Threading-Words-1"></span>

### 5.28 Threading Words

<span id="index-threading-words"></span> <span id="index-code-address"></span>

These words provide access to code addresses and other threading stuff in Gforth (and, possibly, other interpretive Forths). It more or less abstracts away the differences between direct and indirect threading (and, for direct threading, the machine dependences). However, at present this wordset is still incomplete. It is also pretty low-level; some day it will hopefully be made unnecessary by an internals wordset that abstracts implementation details away completely.

The terminology used here stems from indirect threaded Forth systems; in such a system, the XT of a word is represented by the CFA (code field address) of a word; the CFA points to a cell that contains the code address. The code address is the address of some machine code that performs the run-time action of invoking the word (e.g., the `dovar:` routine pushes the address of the body of the word (a variable) on the stack ).

<span id="index-code-address-1"></span> <span id="index-code-field-address-1"></span>

In an indirect threaded Forth, you can get the code address of *name* with `' name @`; in Gforth you can get it with `' name >code-address`, independent of the threading method.

<span id="index-threading_002dmethod--_002d_002d-n--gforth"></span> <span id="index-threading_002dmethod"></span> <span id="index-threading_002dmethod-1"></span>

<div class="format">

``` format
threading-method       – n        gforth       “threading-method”
```

</div>

0 if the engine is direct threaded. Note that this may change during the lifetime of an image.

<span id="index-_003ecode_002daddress--xt-_002d_002d-c_005faddr--gforth"></span> <span id="index-_003ecode_002daddress"></span> <span id="index-_003ecode_002daddress-1"></span>

<div class="format">

``` format
>code-address       xt – c_addr         gforth       “>code-address”
```

</div>

*c-addr* is the code address of the word *xt*.

<span id="index-code_002daddress_0021--c_005faddr-xt-_002d_002d--gforth"></span> <span id="index-code_002daddress_0021"></span> <span id="index-code_002daddress_0021-1"></span>

<div class="format">

``` format
code-address!       c_addr xt –         gforth       “code-address!”
```

</div>

Create a code field with code address *c-addr* at *xt*.

<span id="index-does_003e_002dhandler"></span> <span id="index-does_003e_002dcode"></span>

For a word defined with `DOES>`, the code address usually points to a jump instruction (the *does-handler*) that jumps to the dodoes routine (in Gforth on some platforms, it can also point to the dodoes routine itself). What you are typically interested in, though, is whether a word is a `DOES>`-defined word, and what Forth code it executes; `>does-code` tells you that.

<span id="index-_003edoes_002dcode--xt-_002d_002d-a_005faddr--gforth"></span> <span id="index-_003edoes_002dcode"></span> <span id="index-_003edoes_002dcode-1"></span>

<div class="format">

``` format
>does-code       xt – a_addr         gforth       “>does-code”
```

</div>

If *xt* is the execution token of a child of a `DOES>` word, *a-addr* is the start of the Forth code after the `DOES>`; Otherwise *a-addr* is 0.

To create a `DOES>`-defined word with the following basic words, you have to set up a `DOES>`-handler with `does-handler!`; `/does-handler` aus behind you have to place your executable Forth code. Finally you have to create a word and modify its behaviour with `does-handler!`.

<span id="index-does_002dcode_0021--a_002daddr-xt-_002d_002d--gforth"></span> <span id="index-does_002dcode_0021"></span> <span id="index-does_002dcode_0021-1"></span>

<div class="format">

``` format
does-code!       a-addr xt –         gforth       “does-code!”
```

</div>

Create a code field at *xt* for a child of a `DOES>`-word; *a-addr* is the start of the Forth code after `DOES>`.

doc-does-handler\! <span id="index-_002fdoes_002dhandler--_002d_002d-n--gforth"></span> <span id="index-_002fdoes_002dhandler"></span> <span id="index-_002fdoes_002dhandler-1"></span>

<div class="format">

``` format
/does-handler       – n         gforth       “/does-handler”
```

</div>

The size of a `DOES>`-handler (includes possible padding).

The code addresses produced by various defining words are produced by the following words:

<span id="index-docol_003a--_002d_002d-addr--gforth"></span> <span id="index-docol_003a"></span> <span id="index-docol_003a-1"></span>

<div class="format">

``` format
docol:       – addr         gforth       “docol:”
```

</div>

The code address of a colon definition.

<span id="index-docon_003a--_002d_002d-addr--gforth"></span> <span id="index-docon_003a"></span> <span id="index-docon_003a-1"></span>

<div class="format">

``` format
docon:       – addr         gforth       “docon:”
```

</div>

The code address of a `CONSTANT`.

<span id="index-dovar_003a--_002d_002d-addr--gforth"></span> <span id="index-dovar_003a"></span> <span id="index-dovar_003a-1"></span>

<div class="format">

``` format
dovar:       – addr         gforth       “dovar:”
```

</div>

The code address of a `CREATE`d word.

<span id="index-douser_003a--_002d_002d-addr--gforth"></span> <span id="index-douser_003a"></span> <span id="index-douser_003a-1"></span>

<div class="format">

``` format
douser:       – addr         gforth       “douser:”
```

</div>

The code address of a `USER` variable.

<span id="index-dodefer_003a--_002d_002d-addr--gforth"></span> <span id="index-dodefer_003a"></span> <span id="index-dodefer_003a-1"></span>

<div class="format">

``` format
dodefer:       – addr         gforth       “dodefer:”
```

</div>

The code address of a `defer`ed word.

<span id="index-dofield_003a--_002d_002d-addr--gforth"></span> <span id="index-dofield_003a"></span> <span id="index-dofield_003a-1"></span>

<div class="format">

``` format
dofield:       – addr         gforth       “dofield:”
```

</div>

The code address of a `field`.

<span id="index-definer"></span>

The following two words generalize `>code-address`, `>does-code`, `code-address!`, and `does-code!`:

<span id="index-_003edefiner--xt-_002d_002d-definer--gforth"></span> <span id="index-_003edefiner"></span> <span id="index-_003edefiner-1"></span>

<div class="format">

``` format
>definer       xt – definer         gforth       “>definer”
```

</div>

`Definer` is a unique identifier for the way the `xt` was defined. Words defined with different `does>`-codes have different definers. The definer can be used for comparison and in `definer!`.

<span id="index-definer_0021--definer-xt-_002d_002d--gforth"></span> <span id="index-definer_0021"></span> <span id="index-definer_0021-1"></span>

<div class="format">

``` format
definer!       definer xt –         gforth       “definer!”
```

</div>

The word represented by `xt` changes its behaviour to the behaviour associated with `definer`.

-----

<div class="header">

Next: [Passing Commands to the OS](Passing-Commands-to-the-OS.html#Passing-Commands-to-the-OS), Previous: [Assembler and Code Words](Assembler-and-Code-Words.html#Assembler-and-Code-Words), Up: [Words](Words.html#Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
