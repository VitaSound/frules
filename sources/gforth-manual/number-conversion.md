> Source: https://gforth.org/manual/Number-Conversion.html

<span id="Number-Conversion"></span>

<div class="header">

Next: [Interpret/Compile states](Interpret_002fCompile-states.html#Interpret_002fCompile-states), Previous: [Input Sources](Input-Sources.html#Input-Sources), Up: [The Text Interpreter](The-Text-Interpreter.html#The-Text-Interpreter)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Number-Conversion-1"></span>

#### 5.13.2 Number Conversion

<span id="index-number-conversion"></span> <span id="index-double_002dcell-numbers_002c-input-format"></span> <span id="index-input-format-for-double_002dcell-numbers"></span> <span id="index-single_002dcell-numbers_002c-input-format"></span> <span id="index-input-format-for-single_002dcell-numbers"></span> <span id="index-floating_002dpoint-numbers_002c-input-format"></span> <span id="index-input-format-for-floating_002dpoint-numbers"></span>

This section describes the rules that the text interpreter uses when it tries to convert a string into a number.

Let \<digit\> represent any character that is a legal digit in the current number base[<sup>28</sup>](#FOOT28).

Let \<decimal digit\> represent any character in the range 0-9.

Let {*a b*} represent the *optional* presence of any of the characters in the braces (*a* or *b* or neither).

Let \* represent any number of instances of the previous character (including none).

Let any other character represent itself.

Now, the conversion rules are:

  - A string of the form \<digit\>\<digit\>\* is treated as a single-precision (cell-sized) positive integer. Examples are 0 123 6784532 32343212343456 42
  - A string of the form -\<digit\>\<digit\>\* is treated as a single-precision (cell-sized) negative integer, and is represented using 2’s-complement arithmetic. Examples are -45 -5681 -0
  - A string of the form \<digit\>\<digit\>\*.\<digit\>\* is treated as a double-precision (double-cell-sized) positive integer. Examples are 3465. 3.465 34.65 (all three of these represent the same number).
  - A string of the form -\<digit\>\<digit\>\*.\<digit\>\* is treated as a double-precision (double-cell-sized) negative integer, and is represented using 2’s-complement arithmetic. Examples are -3465. -3.465 -34.65 (all three of these represent the same number).
  - A string of the form {+ -}\<decimal digit\>{.}\<decimal digit\>\*{e E}{+ -}\<decimal digit\>\<decimal digit\>\* is treated as a floating-point number. Examples are 1e 1e0 1.e 1.e0 +1e+0 (which all represent the same number) +12.E-4

By default, the number base used for integer number conversion is given by the contents of the variable `base`. Note that a lot of confusion can result from unexpected values of `base`. If you change `base` anywhere, make sure to save the old value and restore it afterwards; better yet, use `base-execute`, which does this for you. In general I recommend keeping `base` decimal, and using the prefixes described below for the popular non-decimal bases.

<span id="index-dpl--_002d_002d-a_002daddr--gforth"></span> <span id="index-dpl"></span> <span id="index-dpl-1"></span>

<div class="format">

``` format
dpl       – a-addr         gforth       “dpl”
```

</div>

`User` variable – *a-addr* is the address of a cell that stores the position of the decimal point in the most recent numeric conversion. Initialised to -1. After the conversion of a number containing no decimal point, `dpl` is -1. After the conversion of `2.` it holds 0. After the conversion of 234123.9 it contains 1, and so forth.

<span id="index-base_002dexecute--i_002ax-xt-u-_002d_002d-j_002ax--gforth"></span> <span id="index-base_002dexecute"></span> <span id="index-base_002dexecute-1"></span>

<div class="format">

``` format
base-execute       i*x xt u – j*x         gforth       “base-execute”
```

</div>

execute *xt* with the content of `BASE` being *u*, and restoring the original `BASE` afterwards.

<span id="index-base--_002d_002d-a_002daddr--core"></span> <span id="index-base"></span> <span id="index-base-1"></span>

<div class="format">

``` format
base       – a-addr         core       “base”
```

</div>

`User` variable – *a-addr* is the address of a cell that stores the number base used by default for number conversion during input and output. Don’t store to `base`, use `base-execute` instead.

<span id="index-hex--_002d_002d--core_002dext"></span> <span id="index-hex"></span> <span id="index-hex-1"></span>

<div class="format">

``` format
hex       –         core-ext       “hex”
```

</div>

Set `base` to &16 (hexadecimal). Don’t use `hex`, use `base-execute` instead.

<span id="index-decimal--_002d_002d--core"></span> <span id="index-decimal"></span> <span id="index-decimal-1"></span>

<div class="format">

``` format
decimal       –         core       “decimal”
```

</div>

Set `base` to &10 (decimal). Don’t use `decimal`, use `base-execute` instead.

<span id="index-_0027_002dprefix-for-character-strings"></span> <span id="index-_0026_002dprefix-for-decimal-numbers"></span> <span id="index-_0023_002dprefix-for-decimal-numbers"></span> <span id="index-_0025_002dprefix-for-binary-numbers"></span> <span id="index-_0024_002dprefix-for-hexadecimal-numbers"></span> <span id="index-0x_002dprefix-for-hexadecimal-numbers"></span>

Gforth allows you to override the value of `base` by using a prefix[<sup>29</sup>](#FOOT29) before the first digit of an (integer) number. The following prefixes are supported:

  - `&` – decimal
  - `#` – decimal
  - `%` – binary
  - `$` – hexadecimal
  - `0x` – hexadecimal, if base\<33.
  - `'` – numeric value (e.g., ASCII code) of next character; an optional `'` may be present after the character.

Here are some examples, with the equivalent decimal number shown after in braces:

\-$41 (-65), %1001101 (205), %1001.0001 (145 - a double-precision number), ’A (65), -’a’ (-97), &905 (905), $abc (2478), $ABC (2478).

<span id="index-number-conversion-_002d-traps-for-the-unwary"></span>

Number conversion has a number of traps for the unwary:

  - You cannot determine the current number base using the code sequence `base @ .` – the number base is always 10 in the current number base. Instead, use something like `base @ dec.`
  - If the number base is set to a value greater than 14 (for example, hexadecimal), the number 123E4 is ambiguous; the conversion rules allow it to be intepreted as either a single-precision integer or a floating-point number (Gforth treats it as an integer). The ambiguity can be resolved by explicitly stating the sign of the mantissa and/or exponent: 123E+4 or +123E4 – if the number base is decimal, no ambiguity arises; either representation will be treated as a floating-point number.
  - There is a word `bin` but it does *not* set the number base\! It is used to specify file types.
  - Standard Forth requires the `.` of a double-precision number to be the final character in the string. Gforth allows the `.` to be anywhere after the first digit.
  - The number conversion process does not check for overflow.
  - In a Standard Forth program `base` is required to be decimal when converting floating-point numbers. In Gforth, number conversion to floating-point numbers always uses base &10, irrespective of the value of `base`.

You can read numbers into your programs with the words described in [Line input and conversion](Line-input-and-conversion.html#Line-input-and-conversion).

<div class="footnote">

-----

#### Footnotes

### [(28)](#DOCF28)

For example, 0-9 when the number base is decimal or 0-9, A-F when the number base is hexadecimal.

### [(29)](#DOCF29)

Some Forth implementations provide a similar scheme by implementing `$` etc. as parsing words that process the subsequent number in the input stream and push it onto the stack. For example, see Number Conversion and Literals, by Wil Baden; Forth Dimensions 20(3) pages 26–27. In such implementations, unlike in Gforth, a space is required between the prefix and the number.

</div>

-----

<div class="header">

Next: [Interpret/Compile states](Interpret_002fCompile-states.html#Interpret_002fCompile-states), Previous: [Input Sources](Input-Sources.html#Input-Sources), Up: [The Text Interpreter](The-Text-Interpreter.html#The-Text-Interpreter)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
