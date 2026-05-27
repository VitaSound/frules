> Source: https://gforth.org/manual/Formatted-numeric-output.html

<span id="Formatted-numeric-output"></span>

<div class="header">

Next: [String Formats](String-Formats.html#String-Formats), Previous: [Simple numeric output](Simple-numeric-output.html#Simple-numeric-output), Up: [Other I/O](Other-I_002fO.html#Other-I_002fO)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Formatted-numeric-output-1"></span>

#### 5.19.2 Formatted numeric output

<span id="index-formatted-numeric-output"></span> <span id="index-pictured-numeric-output"></span> <span id="index-numeric-output-_002d-formatted"></span>

Forth traditionally uses a technique called *pictured numeric output* for formatted printing of integers. In this technique, digits are extracted from the number (using the current output radix defined by `base`), converted to ASCII codes and appended to a string that is built in a scratch-pad area of memory (see [Implementation-defined options](core_002didef.html#core_002didef)). Arbitrary characters can be appended to the string during the extraction process. The completed string is specified by an address and length and can be manipulated (`TYPE`ed, copied, modified) under program control.

All of the integer output words described in the previous section (see [Simple numeric output](Simple-numeric-output.html#Simple-numeric-output)) are implemented in Gforth using pictured numeric output.

Three important things to remember about pictured numeric output:

  - It always operates on double-precision numbers; to display a single-precision number, convert it first (for ways of doing this see [Double precision](Double-precision.html#Double-precision)).
  - It always treats the double-precision number as though it were unsigned. The examples below show ways of printing signed numbers.
  - The string is built up from right to left; least significant digit first.

<span id="index-_003c_0023--_002d_002d--core"></span> <span id="index-_003c_0023"></span> <span id="index-_003c_0023-1"></span>

<div class="format">

``` format
<#       –         core       “less-number-sign”
```

</div>

Initialise/clear the pictured numeric output string.

<span id="index-_003c_003c_0023--_002d_002d--gforth"></span> <span id="index-_003c_003c_0023"></span> <span id="index-_003c_003c_0023-1"></span>

<div class="format">

``` format
<<#       –         gforth       “less-less-number-sign”
```

</div>

Start a hold area that ends with `#>>`. Can be nested in each other and in `<#`. Note: if you do not match up the `<<#`s with `#>>`s, you will eventually run out of hold area; you can reset the hold area to empty with `<#`.

<span id="index-_0023--ud1-_002d_002d-ud2--core"></span> <span id="index-_0023"></span> <span id="index-_0023-1"></span>

<div class="format">

``` format
#       ud1 – ud2         core       “number-sign”
```

</div>

Used within `<#` and `#>`. Add the next least-significant digit to the pictured numeric output string. This is achieved by dividing `ud1` by the number in `base` to leave quotient `ud2` and remainder `n`; `n` is converted to the appropriate display code (eg ASCII code) and appended to the string. If the number has been fully converted, `ud1` will be 0 and `#` will append a “0” to the string.

<span id="index-_0023s--ud-_002d_002d-0-0--core"></span> <span id="index-_0023s"></span> <span id="index-_0023s-1"></span>

<div class="format">

``` format
#s       ud – 0 0         core       “number-sign-s”
```

</div>

Used within `<#` and `#>`. Convert all remaining digits using the same algorithm as for `#`. `#s` will convert at least one digit. Therefore, if `ud` is 0, `#s` will append a “0” to the pictured numeric output string.

<span id="index-hold--char-_002d_002d--core"></span> <span id="index-hold"></span> <span id="index-hold-1"></span>

<div class="format">

``` format
hold       char –         core       “hold”
```

</div>

Used within `<#` and `#>`. Append the character `char` to the pictured numeric output string.

<span id="index-sign--n-_002d_002d--core"></span> <span id="index-sign"></span> <span id="index-sign-1"></span>

<div class="format">

``` format
sign       n –         core       “sign”
```

</div>

Used within `<#` and `#>`. If `n` (a `single` number) is negative, append the display code for a minus sign to the pictured numeric output string. Since the string is built up “backwards” this is usually used immediately prior to `#>`, as shown in the examples below.

<span id="index-_0023_003e--xd-_002d_002d-addr-u--core"></span> <span id="index-_0023_003e"></span> <span id="index-_0023_003e-1"></span>

<div class="format">

``` format
#>       xd – addr u         core       “number-sign-greater”
```

</div>

Complete the pictured numeric output string by discarding `xd` and returning `addr u`; the address and length of the formatted string. A Standard program may modify characters within the string.

<span id="index-_0023_003e_003e--_002d_002d--gforth"></span> <span id="index-_0023_003e_003e"></span> <span id="index-_0023_003e_003e-1"></span>

<div class="format">

``` format
#>>       –         gforth       “number-sign-greater-greater”
```

</div>

Release the hold area started with `<<#`.

<span id="index-represent--r-c_002daddr-u-_002d_002d-n-f1-f2--float"></span> <span id="index-represent"></span> <span id="index-represent-1"></span>

<div class="format">

``` format
represent       r c-addr u – n f1 f2        float       “represent”
```

</div>

<span id="index-f_003estr_002drdp--rf-_002bnr-_002bnd-_002bnp-_002d_002d-c_002daddr-nr--gforth"></span> <span id="index-f_003estr_002drdp"></span> <span id="index-f_003estr_002drdp-1"></span>

<div class="format">

``` format
f>str-rdp       rf +nr +nd +np – c-addr nr         gforth       “f>str-rdp”
```

</div>

Convert *rf* into a string at *c-addr nr*. The conversion rules and the meanings of *nr +nd np* are the same as for `f.rdp`. The result in in the pictured numeric output buffer and will be destroyed by anything destroying that buffer.

<span id="index-f_003ebuf_002drdp--rf-c_002daddr-_002bnr-_002bnd-_002bnp-_002d_002d--gforth"></span> <span id="index-f_003ebuf_002drdp"></span> <span id="index-f_003ebuf_002drdp-1"></span>

<div class="format">

``` format
f>buf-rdp       rf c-addr +nr +nd +np –         gforth       “f>buf-rdp”
```

</div>

Convert *rf* into a string at *c-addr nr*. The conversion rules and the meanings of *nr nd np* are the same as for `f.rdp`.

Here are some examples of using pictured numeric output:

<div class="example">

``` example
: my-u. ( u -- )
  \ Simplest use of pns.. behaves like Standard u. 
  0              \ convert to unsigned double
  <<#            \ start conversion
  #s             \ convert all digits
  #>             \ complete conversion
  TYPE SPACE     \ display, with trailing space
  #>> ;          \ release hold area

: cents-only ( u -- )
  0              \ convert to unsigned double
  <<#            \ start conversion
  # #            \ convert two least-significant digits
  #>             \ complete conversion, discard other digits
  TYPE SPACE     \ display, with trailing space
  #>> ;          \ release hold area

: dollars-and-cents ( u -- )
  0              \ convert to unsigned double
  <<#            \ start conversion
  # #            \ convert two least-significant digits
  [char] . hold  \ insert decimal point
  #s             \ convert remaining digits
  [char] $ hold  \ append currency symbol
  #>             \ complete conversion
  TYPE SPACE     \ display, with trailing space
  #>> ;          \ release hold area

: my-. ( n -- )
  \ handling negatives.. behaves like Standard .
  s>d            \ convert to signed double
  swap over dabs \ leave sign byte followed by unsigned double
  <<#            \ start conversion
  #s             \ convert all digits
  rot sign       \ get at sign byte, append "-" if needed
  #>             \ complete conversion
  TYPE SPACE     \ display, with trailing space
  #>> ;          \ release hold area

: account. ( n -- )
  \ accountants don't like minus signs, they use parentheses
  \ for negative numbers
  s>d            \ convert to signed double
  swap over dabs \ leave sign byte followed by unsigned double
  <<#            \ start conversion
  2 pick         \ get copy of sign byte
  0< IF [char] ) hold THEN \ right-most character of output
  #s             \ convert all digits
  rot            \ get at sign byte
  0< IF [char] ( hold THEN
  #>             \ complete conversion
  TYPE SPACE     \ display, with trailing space
  #>> ;          \ release hold area
```

</div>

Here are some examples of using these words:

<div class="example">

``` example
1 my-u. 1
hex -1 my-u. decimal FFFFFFFF
1 cents-only 01
1234 cents-only 34
2 dollars-and-cents $0.02
1234 dollars-and-cents $12.34
123 my-. 123
-123 my. -123
123 account. 123
-456 account. (456)
```

</div>

-----

<div class="header">

Next: [String Formats](String-Formats.html#String-Formats), Previous: [Simple numeric output](Simple-numeric-output.html#Simple-numeric-output), Up: [Other I/O](Other-I_002fO.html#Other-I_002fO)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
