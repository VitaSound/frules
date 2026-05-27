> Source: https://gforth.org/manual/Advanced-does_003e-usage-example.html

<span id="Advanced-does_003e-usage-example"></span>

<div class="header">

Next: [Const-does\>](Const_002ddoes_003e.html#Const_002ddoes_003e), Previous: [CREATE..DOES\> details](CREATE_002e_002eDOES_003e-details.html#CREATE_002e_002eDOES_003e-details), Up: [User-defined Defining Words](User_002ddefined-Defining-Words.html#User_002ddefined-Defining-Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Advanced-does_003e-usage-example-1"></span>

#### 5.9.9.3 Advanced does\> usage example

The MIPS disassembler (`arch/mips/disasm.fs`) contains many words for disassembling instructions, that follow a very repetetive scheme:

<div class="example">

``` example
:noname disasm-operands s" inst-name" type ;
entry-num cells table + !
```

</div>

Of course, this inspires the idea to factor out the commonalities to allow a definition like

<div class="example">

``` example
disasm-operands entry-num table define-inst inst-name
```

</div>

The parameters `disasm-operands` and `table` are usually correlated. Moreover, before I wrote the disassembler, there already existed code that defines instructions like this:

<div class="example">

``` example
entry-num inst-format inst-name
```

</div>

This code comes from the assembler and resides in `arch/mips/insts.fs`.

So I had to define the `inst-format` words that performed the scheme above when executed. At first I chose to use run-time code-generation:

<div class="example">

``` example
: inst-format ( entry-num "name" -- ; compiled code: addr w -- )
  :noname Postpone disasm-operands
  name Postpone sliteral Postpone type Postpone ;
  swap cells table + ! ;
```

</div>

Note that this supplies the other two parameters of the scheme above.

An alternative would have been to write this using `create`/`does>`:

<div class="example">

``` example
: inst-format ( entry-num "name" -- )
  here name string, ( entry-num c-addr ) \ parse and save "name"
  noname create , ( entry-num )
  latestxt swap cells table + !
does> ( addr w -- )
  \ disassemble instruction w at addr
  @ >r 
  disasm-operands
  r> count type ;
```

</div>

Somehow the first solution is simpler, mainly because it’s simpler to shift a string from definition-time to use-time with `sliteral` than with `string,` and friends.

I wrote a lot of words following this scheme and soon thought about factoring out the commonalities among them. Note that this uses a two-level defining word, i.e., a word that defines ordinary defining words.

This time a solution involving `postpone` and friends seemed more difficult (try it as an exercise), so I decided to use a `create`/`does>` word; since I was already at it, I also used `create`/`does>` for the lower level (try using `postpone` etc. as an exercise), resulting in the following definition:

<div class="example">

``` example
: define-format ( disasm-xt table-xt -- )
    \ define an instruction format that uses disasm-xt for
    \ disassembling and enters the defined instructions into table
    \ table-xt
    create 2,
does> ( u "inst" -- )
    \ defines an anonymous word for disassembling instruction inst,
    \ and enters it as u-th entry into table-xt
    2@ swap here name string, ( u table-xt disasm-xt c-addr ) \ remember string
    noname create 2,      \ define anonymous word
    execute latestxt swap ! \ enter xt of defined word into table-xt
does> ( addr w -- )
    \ disassemble instruction w at addr
    2@ >r ( addr w disasm-xt R: c-addr )
    execute ( R: c-addr ) \ disassemble operands
    r> count type ; \ print name 
```

</div>

Note that the tables here (in contrast to above) do the `cells +` by themselves (that’s why you have to pass an xt). This word is used in the following way:

<div class="example">

``` example
' disasm-operands ' table define-format inst-format
```

</div>

As shown above, the defined instruction format is then used like this:

<div class="example">

``` example
entry-num inst-format inst-name
```

</div>

In terms of currying, this kind of two-level defining word provides the parameters in three stages: first `disasm-operands` and `table`, then `entry-num` and `inst-name`, finally `addr w`, i.e., the instruction to be disassembled.

Of course this did not quite fit all the instruction format names used in `insts.fs`, so I had to define a few wrappers that conditioned the parameters into the right form.

If you have trouble following this section, don’t worry. First, this is involved and takes time (and probably some playing around) to understand; second, this is the first two-level `create`/`does>` word I have written in seventeen years of Forth; and if I did not have `insts.fs` to start with, I may well have elected to use just a one-level defining word (with some repeating of parameters when using the defining word). So it is not necessary to understand this, but it may improve your understanding of Forth.

-----

<div class="header">

Next: [Const-does\>](Const_002ddoes_003e.html#Const_002ddoes_003e), Previous: [CREATE..DOES\> details](CREATE_002e_002eDOES_003e-details.html#CREATE_002e_002eDOES_003e-details), Up: [User-defined Defining Words](User_002ddefined-Defining-Words.html#User_002ddefined-Defining-Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
