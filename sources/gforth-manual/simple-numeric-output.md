> Source: https://gforth.org/manual/Simple-numeric-output.html

<span id="Simple-numeric-output"></span>

<div class="header">

Next: [Formatted numeric output](Formatted-numeric-output.html#Formatted-numeric-output), Previous: [Other I/O](Other-I_002fO.html#Other-I_002fO), Up: [Other I/O](Other-I_002fO.html#Other-I_002fO)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Simple-numeric-output-1"></span>

#### 5.19.1 Simple numeric output

<span id="index-numeric-output-_002d-simple_002ffree_002dformat"></span>

The simplest output functions are those that display numbers from the data or floating-point stacks. Floating-point output is always displayed using base 10. Numbers displayed from the data stack use the value stored in `base`.

<span id="index-_002e--n-_002d_002d--core"></span> <span id="index-_002e"></span> <span id="index-_002e-1"></span>

<div class="format">

``` format
.       n –         core       “dot”
```

</div>

Display (the signed single number) `n` in free-format, followed by a space.

<span id="index-dec_002e--n-_002d_002d--gforth"></span> <span id="index-dec_002e"></span> <span id="index-dec_002e-1"></span>

<div class="format">

``` format
dec.       n –         gforth       “dec.”
```

</div>

Display *n* as a signed decimal number, followed by a space.

<span id="index-hex_002e--u-_002d_002d--gforth"></span> <span id="index-hex_002e"></span> <span id="index-hex_002e-1"></span>

<div class="format">

``` format
hex.       u –         gforth       “hex.”
```

</div>

Display *u* as an unsigned hex number, prefixed with a "$" and followed by a space.

<span id="index-u_002e--u-_002d_002d--core"></span> <span id="index-u_002e"></span> <span id="index-u_002e-1"></span>

<div class="format">

``` format
u.       u –         core       “u-dot”
```

</div>

Display (the unsigned single number) `u` in free-format, followed by a space.

<span id="index-_002er--n1-n2-_002d_002d--core_002dext"></span> <span id="index-_002er"></span> <span id="index-_002er-1"></span>

<div class="format">

``` format
.r       n1 n2 –         core-ext       “dot-r”
```

</div>

Display `n1` right-aligned in a field `n2` characters wide. If more than `n2` characters are needed to display the number, all digits are displayed. If appropriate, `n2` must include a character for a leading “-”.

<span id="index-u_002er--u-n-_002d_002d--core_002dext"></span> <span id="index-u_002er"></span> <span id="index-u_002er-1"></span>

<div class="format">

``` format
u.r       u n –         core-ext       “u-dot-r”
```

</div>

Display `u` right-aligned in a field `n` characters wide. If more than `n` characters are needed to display the number, all digits are displayed.

<span id="index-d_002e--d-_002d_002d--double"></span> <span id="index-d_002e"></span> <span id="index-d_002e-1"></span>

<div class="format">

``` format
d.       d –         double       “d-dot”
```

</div>

Display (the signed double number) `d` in free-format. followed by a space.

<span id="index-ud_002e--ud-_002d_002d--gforth"></span> <span id="index-ud_002e"></span> <span id="index-ud_002e-1"></span>

<div class="format">

``` format
ud.       ud –         gforth       “u-d-dot”
```

</div>

Display (the signed double number) `ud` in free-format, followed by a space.

<span id="index-d_002er--d-n-_002d_002d--double"></span> <span id="index-d_002er"></span> <span id="index-d_002er-1"></span>

<div class="format">

``` format
d.r       d n –         double       “d-dot-r”
```

</div>

Display `d` right-aligned in a field `n` characters wide. If more than `n` characters are needed to display the number, all digits are displayed. If appropriate, `n` must include a character for a leading “-”.

<span id="index-ud_002er--ud-n-_002d_002d--gforth"></span> <span id="index-ud_002er"></span> <span id="index-ud_002er-1"></span>

<div class="format">

``` format
ud.r       ud n –         gforth       “u-d-dot-r”
```

</div>

Display `ud` right-aligned in a field `n` characters wide. If more than `n` characters are needed to display the number, all digits are displayed.

<span id="index-f_002e--r-_002d_002d--float_002dext"></span> <span id="index-f_002e"></span> <span id="index-f_002e-1"></span>

<div class="format">

``` format
f.       r –         float-ext       “f-dot”
```

</div>

Display (the floating-point number) *r* without exponent, followed by a space.

<span id="index-fe_002e--r-_002d_002d--float_002dext"></span> <span id="index-fe_002e"></span> <span id="index-fe_002e-1"></span>

<div class="format">

``` format
fe.       r –         float-ext       “f-e-dot”
```

</div>

Display *r* using engineering notation (with exponent dividable by 3), followed by a space.

<span id="index-fs_002e--r-_002d_002d--gforth"></span> <span id="index-fs_002e"></span> <span id="index-fs_002e-1"></span>

<div class="format">

``` format
fs.       r –         gforth       “f-s-dot”
```

</div>

Display *r* using scientific notation (with exponent), followed by a space.

<span id="index-fp_002e--r-_002d_002d--float_002dext"></span> <span id="index-fp_002e"></span> <span id="index-fp_002e-1"></span>

<div class="format">

``` format
fp.       r –         float-ext       “f-e-dot”
```

</div>

Display *r* using SI prefix notation (with exponent dividable by 3, converted into SI prefixes if available), followed by a space.

Examples of printing the number 1234.5678E23 in the different floating-point output formats are shown below.

<div class="example">

``` example
f. 123456780000000000000000000.
fe. 123.456780000000E24
fs. 1.23456780000000E26
fp. 123.456780000000Y
```

</div>

<span id="index-precision--_002d_002d-u--float_002dext"></span> <span id="index-precision"></span> <span id="index-precision-1"></span>

<div class="format">

``` format
precision       – u         float-ext       “precision”
```

</div>

*u* is the number of significant digits currently used by `F.` `FE.` and `FS.`

<span id="index-set_002dprecision--u-_002d_002d--float_002dext"></span> <span id="index-set_002dprecision"></span> <span id="index-set_002dprecision-1"></span>

<div class="format">

``` format
set-precision       u –         float-ext       “set-precision”
```

</div>

Set the number of significant digits currently used by `F.` `FE.` and `FS.` to *u*.

<span id="index-f_002erdp--rf-_002bnr-_002bnd-_002bnp-_002d_002d--gforth"></span> <span id="index-f_002erdp"></span> <span id="index-f_002erdp-1"></span>

<div class="format">

``` format
f.rdp       rf +nr +nd +np –         gforth       “f.rdp”
```

</div>

Print float *rf* formatted. The total width of the output is *nr*. For fixed-point notation, the number of digits after the decimal point is *+nd* and the minimum number of significant digits is *np*. `Set-precision` has no effect on `f.rdp`. Fixed-point notation is used if the number of siginicant digits would be at least *np* and if the number of digits before the decimal point would fit. If fixed-point notation is not used, exponential notation is used, and if that does not fit, asterisks are printed. We recommend using *nr*\>=7 to avoid the risk of numbers not fitting at all. We recommend *nr*\>=*np*+5 to avoid cases where `f.rdp` switches to exponential notation because fixed-point notation would have too few significant digits, yet exponential notation offers fewer significant digits. We recommend *nr*\>=*nd*+2, if you want to have fixed-point notation for some numbers; the smaller the value of *np*, the more cases are shown in fixed-point notation (cases where few or no significant digits remain in fixed-point notation). We recommend *np*\>*nr*, if you want to have exponential notation for all numbers.

For `f.rdp` the output depends on the parameters. To give you a better intuition of how they influence the output, here are some examples of parameter combinations; in each line the same number is printed, in each column the same parameter combination is used for printing:

<div class="example">

``` example
    12 13 0    7 3 4   7 3 0   7 3 1   7 5 1   7 7 1   7 0 2  4 2 1
|-1.234568E-6|-1.2E-6| -0.000|-1.2E-6|-1.2E-6|-1.2E-6|-1.2E-6|****|
|-1.234568E-5|-1.2E-5| -0.000|-1.2E-5|-.00001|-1.2E-5|-1.2E-5|****|
|-1.234568E-4|-1.2E-4| -0.000|-1.2E-4|-.00012|-1.2E-4|-1.2E-4|****|
|-1.234568E-3|-1.2E-3| -0.001| -0.001|-.00123|-1.2E-3|-1.2E-3|****|
|-1.234568E-2|-1.2E-2| -0.012| -0.012|-.01235|-1.2E-2|-1.2E-2|-.01|
|-1.234568E-1|-1.2E-1| -0.123| -0.123|-.12346|-1.2E-1|-1.2E-1|-.12|
|-1.2345679E0| -1.235| -1.235| -1.235|-1.23E0|-1.23E0|-1.23E0|-1E0|
|-1.2345679E1|-12.346|-12.346|-12.346|-1.23E1|-1.23E1|   -12.|-1E1|
|-1.2345679E2|-1.23E2|-1.23E2|-1.23E2|-1.23E2|-1.23E2|  -123.|-1E2|
|-1.2345679E3|-1.23E3|-1.23E3|-1.23E3|-1.23E3|-1.23E3| -1235.|-1E3|
|-1.2345679E4|-1.23E4|-1.23E4|-1.23E4|-1.23E4|-1.23E4|-12346.|-1E4|
|-1.2345679E5|-1.23E5|-1.23E5|-1.23E5|-1.23E5|-1.23E5|-1.23E5|-1E5|
```

</div>

-----

<div class="header">

Next: [Formatted numeric output](Formatted-numeric-output.html#Formatted-numeric-output), Previous: [Other I/O](Other-I_002fO.html#Other-I_002fO), Up: [Other I/O](Other-I_002fO.html#Other-I_002fO)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
