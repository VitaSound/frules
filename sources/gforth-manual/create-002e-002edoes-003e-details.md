> Source: https://gforth.org/manual/CREATE_002e_002eDOES_003e-details.html

<span id="CREATE_002e_002eDOES_003e-details"></span>

<div class="header">

Next: [Advanced does\> usage example](Advanced-does_003e-usage-example.html#Advanced-does_003e-usage-example), Previous: [CREATE..DOES\> applications](CREATE_002e_002eDOES_003e-applications.html#CREATE_002e_002eDOES_003e-applications), Up: [User-defined Defining Words](User_002ddefined-Defining-Words.html#User_002ddefined-Defining-Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="The-gory-details-of-CREATE_002e_002eDOES_003e"></span>

#### 5.9.9.2 The gory details of `CREATE..DOES>`

<span id="index-CREATE-_002e_002e_002e-DOES_003e_002c-details"></span> <span id="index-DOES_003e--compilation-colon_002dsys1-_002d_002d-colon_002dsys2--unknown"></span> <span id="index-DOES_003e"></span> <span id="index-DOES_003e-1"></span>

<div class="format">

``` format
DOES>       compilation colon-sys1 – colon-sys2         unknown       “DOES>”
```

</div>

<span id="index-DOES_003e-in-a-separate-definition"></span>

This means that you need not use `CREATE` and `DOES>` in the same definition; you can put the `DOES>`-part in a separate definition. This allows us to, e.g., select among different `DOES>`-parts:

<div class="example">

``` example
: does1 
DOES> ( ... -- ... )
    ... ;

: does2
DOES> ( ... -- ... )
    ... ;

: def-word ( ... -- ... )
    create ...
    IF
       does1
    ELSE
       does2
    ENDIF ;
```

</div>

In this example, the selection of whether to use `does1` or `does2` is made at definition-time; at the time that the child word is `CREATE`d.

<span id="index-DOES_003e-in-interpretation-state"></span>

In a standard program you can apply a `DOES>`-part only if the last word was defined with `CREATE`. In Gforth, the `DOES>`-part will override the behaviour of the last word defined in any case. In a standard program, you can use `DOES>` only in a colon definition. In Gforth, you can also use it in interpretation state, in a kind of one-shot mode; for example:

<div class="example">

``` example
CREATE name ( ... -- ... )
  initialization
DOES>
  code ;
```

</div>

is equivalent to the standard:

<div class="example">

``` example
:noname
DOES>
    code ;
CREATE name EXECUTE ( ... -- ... )
    initialization
```

</div>

<span id="index-_003ebody--xt-_002d_002d-a_005faddr--core"></span> <span id="index-_003ebody"></span> <span id="index-_003ebody-1"></span>

<div class="format">

``` format
>body       xt – a_addr         core       “to-body”
```

</div>

Get the address of the body of the word represented by *xt* (the address of the word’s data field).
