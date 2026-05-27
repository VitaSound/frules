> Source: https://gforth.org/manual/Name-token.html

<span id="Name-token"></span>

<div class="header">

Previous: [Compilation token](Compilation-token.html#Compilation-token), Up: [Tokens for Words](Tokens-for-Words.html#Tokens-for-Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Name-token-1"></span>

#### 5.11.3 Name token

<span id="index-name-token"></span>

Gforth represents named words by the *name token*, (*nt*). Name token is an abstract data type that occurs as argument or result of the words below.

<span id="index-name-field-address"></span> <span id="index-NFA"></span>

The closest thing to the nt in older Forth systems is the name field address (NFA), but there are significant differences: in older Forth systems each word had a unique NFA, LFA, CFA and PFA (in this order, or LFA, NFA, CFA, PFA) and there were words for getting from one to the next. In contrast, in Gforth 0…n nts correspond to one xt; there is a link field in the structure identified by the name token, but searching usually uses a hash table external to these structures; the name in Gforth has a cell-wide count-and-flags field, and the nt is not implemented as the address of that count field.

<span id="index-find_002dname--c_002daddr-u-_002d_002d-nt-_007c-0--gforth"></span> <span id="index-find_002dname"></span> <span id="index-find_002dname-1"></span>

<div class="format">

``` format
find-name       c-addr u – nt | 0         gforth       “find-name”
```

</div>

Find the name *c-addr u* in the current search order. Return its *nt*, if found, otherwise 0.

<span id="index-find_002dname_002din--c_002daddr-u-wid-_002d_002d-nt-_007c-0--unknown"></span> <span id="index-find_002dname_002din"></span> <span id="index-find_002dname_002din-1"></span>

<div class="format">

``` format
find-name-in       c-addr u wid – nt | 0         unknown       “find-name-in”
```

</div>

search the word list identified by *wid* for the definition named by the string at *c-addr u*. Return its *nt*, if found, otherwise 0.

<span id="index-latest--_002d_002d-nt--gforth"></span> <span id="index-latest"></span> <span id="index-latest-1"></span>

<div class="format">

``` format
latest       – nt         gforth       “latest”
```

</div>

`nt` is the name token of the last word defined; it is 0 if the last word has no name.

<span id="index-_003ename--xt-_002d_002d-nt_007c0--gforth"></span> <span id="index-_003ename"></span> <span id="index-_003ename-1"></span>

<div class="format">

``` format
>name       xt – nt|0         gforth       “to-name”
```

</div>

tries to find the name token `nt` of the word represented by `xt`; returns 0 if it fails. This word is not absolutely reliable, it may give false positives and produce wrong nts.

<span id="index-name_003einterpret--nt-_002d_002d-xt_007c0--unknown"></span> <span id="index-name_003einterpret"></span> <span id="index-name_003einterpret-1"></span>

<div class="format">

``` format
name>interpret       nt – xt|0         unknown       “name>interpret”
```

</div>

*xt* represents the interpretation semantics *nt*; returns 0 if *nt* has no interpretation semantics

<span id="index-name_003ecompile--nt-_002d_002d-w-xt--unknown"></span> <span id="index-name_003ecompile"></span> <span id="index-name_003ecompile-1"></span>

<div class="format">

``` format
name>compile       nt – w xt         unknown       “name>compile”
```

</div>

*w xt* is the compilation token for the word *nt*.

<span id="index-name_003eint--nt-_002d_002d-xt--gforth"></span> <span id="index-name_003eint"></span> <span id="index-name_003eint-1"></span>

<div class="format">

``` format
name>int       nt – xt         gforth       “name-to-int”
```

</div>

*xt* represents the interpretation semantics of the word *nt*.

<span id="index-name_003fint--nt-_002d_002d-xt--gforth_002dobsolete"></span> <span id="index-name_003fint"></span> <span id="index-name_003fint-1"></span>

<div class="format">

``` format
name?int       nt – xt         gforth-obsolete       “name-question-int”
```

</div>

Like `name>int`, but warns when encountering a word marked compile-only

<span id="index-name_003ecomp--nt-_002d_002d-w-xt--gforth"></span> <span id="index-name_003ecomp"></span> <span id="index-name_003ecomp-1"></span>

<div class="format">

``` format
name>comp       nt – w xt         gforth       “name-to-comp”
```

</div>

*w xt* is the compilation token for the word *nt*.

<span id="index-name_003estring--nt-_002d_002d-addr-count--gforth"></span> <span id="index-name_003estring"></span> <span id="index-name_003estring-1"></span>

<div class="format">

``` format
name>string       nt – addr count         gforth       “name-to-string”
```

</div>

*addr count* is the name of the word represented by *nt*.

<span id="index-id_002e--nt-_002d_002d--gforth"></span> <span id="index-id_002e"></span> <span id="index-id_002e-1"></span>

<div class="format">

``` format
id.       nt –         gforth       “i-d-dot”
```

</div>

Print the name of the word represented by `nt`.

<span id="index-_002ename--nt-_002d_002d--gforth_002dobsolete"></span> <span id="index-_002ename"></span> <span id="index-_002ename-1"></span>

<div class="format">

``` format
.name       nt –         gforth-obsolete       “dot-name”
```

</div>

Gforth \<=0.5.0 name for `id.`.

<span id="index-_002eid--nt-_002d_002d--F83"></span> <span id="index-_002eid"></span> <span id="index-_002eid-1"></span>

<div class="format">

``` format
.id       nt –         F83       “dot-i-d”
```

</div>

F83 name for `id.`.

-----

<div class="header">

Previous: [Compilation token](Compilation-token.html#Compilation-token), Up: [Tokens for Words](Tokens-for-Words.html#Tokens-for-Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
