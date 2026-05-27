> Source: https://gforth.org/manual/Flags-and-Comparisons-Tutorial.html

<span id="Flags-and-Comparisons-Tutorial"></span>

<div class="header">

Next: [General Loops Tutorial](General-Loops-Tutorial.html#General-Loops-Tutorial), Previous: [Conditional execution Tutorial](Conditional-execution-Tutorial.html#Conditional-execution-Tutorial), Up: [Tutorial](Tutorial.html#Tutorial)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Flags-and-Comparisons"></span>

### 3.17 Flags and Comparisons

<span id="index-flags-tutorial"></span> <span id="index-comparison-tutorial"></span>

In a false-flag all bits are clear (0 when interpreted as integer). In a canonical true-flag all bits are set (-1 as a twos-complement signed integer); in many contexts (e.g., `if`) any non-zero value is treated as true flag.

<div class="example">

``` example
false .
true .
true hex u. decimal
```

</div>

Comparison words produce canonical flags:

<div class="example">

``` example
1 1 = .
1 0= .
0 1 < .
0 0 < .
-1 1 u< . \ type error, u< interprets -1 as large unsigned number
-1 1 < .
```

</div>

Gforth supports all combinations of the prefixes `0 u d d0 du f f0` (or none) and the comparisons `= <> < > <= >=`. Only a part of these combinations are standard (for details see the standard, [Numeric comparison](Numeric-comparison.html#Numeric-comparison), [Floating Point](Floating-Point.html#Floating-Point) or [Word Index](Word-Index.html#Word-Index)).

You can use `and or xor invert` as operations on canonical flags. Actually they are bitwise operations:

<div class="example">

``` example
1 2 and .
1 2 or .
1 3 xor .
1 invert .
```

</div>

You can convert a zero/non-zero flag into a canonical flag with `0<>` (and complement it on the way with `0=`).

<div class="example">

``` example
1 0= .
1 0<> .
```

</div>

You can use the all-bits-set feature of canonical flags and the bitwise operation of the Boolean operations to avoid `if`s:

<div class="example">

``` example
: foo ( n1 -- n2 )
  0= if
    14
  else
    0
  endif ;
0 foo .
1 foo .

: foo ( n1 -- n2 )
  0= 14 and ;
0 foo .
1 foo .
```

</div>

> **Assignment:** Write `min` without `if`.

For reference, see [Boolean Flags](Boolean-Flags.html#Boolean-Flags), [Numeric comparison](Numeric-comparison.html#Numeric-comparison), and [Bitwise operations](Bitwise-operations.html#Bitwise-operations).

-----

<div class="header">

Next: [General Loops Tutorial](General-Loops-Tutorial.html#General-Loops-Tutorial), Previous: [Conditional execution Tutorial](Conditional-execution-Tutorial.html#Conditional-execution-Tutorial), Up: [Tutorial](Tutorial.html#Tutorial)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
