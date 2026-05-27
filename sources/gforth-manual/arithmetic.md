> Source: https://gforth.org/manual/Arithmetic.html

<span id="Arithmetic"></span>

<div class="header">

Next: [Stack Manipulation](Stack-Manipulation.html#Stack-Manipulation), Previous: [Boolean Flags](Boolean-Flags.html#Boolean-Flags), Up: [Words](Words.html#Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Arithmetic-1"></span>

### 5.5 Arithmetic

<span id="index-arithmetic-words"></span> <span id="index-division-with-potentially-negative-operands"></span>

Forth arithmetic is not checked, i.e., you will not hear about integer overflow on addition or multiplication, you may hear about division by zero if you are lucky. The operator is written after the operands, but the operands are still in the original order. I.e., the infix `2-1` corresponds to `2 1 -`. Forth offers a variety of division operators. If you perform division with potentially negative operands, you do not want to use `/` or `/mod` with its undefined behaviour, but rather `fm/mod` or `sm/mod` (probably the former, see [Mixed precision](Mixed-precision.html#Mixed-precision)).

|                                                                     |  |                                                 |
| :------------------------------------------------------------------ |  | :---------------------------------------------- |
| • [Single precision](Single-precision.html#Single-precision):       |  |                                                 |
| • [Double precision](Double-precision.html#Double-precision):       |  | Double-cell integer arithmetic                  |
| • [Bitwise operations](Bitwise-operations.html#Bitwise-operations): |  |                                                 |
| • [Numeric comparison](Numeric-comparison.html#Numeric-comparison): |  |                                                 |
| • [Mixed precision](Mixed-precision.html#Mixed-precision):          |  | Operations with single and double-cell integers |
| • [Floating Point](Floating-Point.html#Floating-Point):             |  |                                                 |
