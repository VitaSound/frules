> Source: https://gforth.org/manual/CREATE_002e_002eDOES_003e-applications.html

<span id="CREATE_002e_002eDOES_003e-applications"></span>

<div class="header">

Next: [CREATE..DOES\> details](CREATE_002e_002eDOES_003e-details.html#CREATE_002e_002eDOES_003e-details), Previous: [User-defined Defining Words](User_002ddefined-Defining-Words.html#User_002ddefined-Defining-Words), Up: [User-defined Defining Words](User_002ddefined-Defining-Words.html#User_002ddefined-Defining-Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Applications-of-CREATE_002e_002eDOES_003e"></span>

#### 5.9.9.1 Applications of `CREATE..DOES>`

<span id="index-CREATE-_002e_002e_002e-DOES_003e_002c-applications"></span>

You may wonder how to use this feature. Here are some usage patterns:

<span id="index-factoring-similar-colon-definitions"></span>

When you see a sequence of code occurring several times, and you can identify a meaning, you will factor it out as a colon definition. When you see similar colon definitions, you can factor them using `CREATE..DOES>`. E.g., an assembler usually defines several words that look very similar:

<div class="example">

``` example
: ori, ( reg-target reg-source n -- )
    0 asm-reg-reg-imm ;
: andi, ( reg-target reg-source n -- )
    1 asm-reg-reg-imm ;
```

</div>

This could be factored with:

<div class="example">

``` example
: reg-reg-imm ( op-code -- )
    CREATE ,
DOES> ( reg-target reg-source n -- )
    @ asm-reg-reg-imm ;

0 reg-reg-imm ori,
1 reg-reg-imm andi,
```

</div>

<span id="index-currying"></span>

Another view of `CREATE..DOES>` is to consider it as a crude way to supply a part of the parameters for a word (known as *currying* in the functional language community). E.g., `+` needs two parameters. Creating versions of `+` with one parameter fixed can be done like this:

<div class="example">

``` example
: curry+ ( n1 "name" -- )
    CREATE ,
DOES> ( n2 -- n1+n2 )
    @ + ;

 3 curry+ 3+
-2 curry+ 2-
```

</div>
