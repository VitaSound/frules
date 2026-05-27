> Source: https://gforth.org/manual/Stack-Manipulation.html

<span id="Stack-Manipulation"></span>

<div class="header">

Next: [Memory](Memory.html#Memory), Previous: [Arithmetic](Arithmetic.html#Arithmetic), Up: [Words](Words.html#Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Stack-Manipulation-2"></span>

### 5.6 Stack Manipulation

<span id="index-stack-manipulation-words"></span> <span id="index-floating_002dpoint-stack-in-the-standard"></span>

Gforth maintains a number of separate stacks:

<span id="index-data-stack"></span> <span id="index-parameter-stack"></span>

  - A data stack (also known as the *parameter stack*) – for characters, cells, addresses, and double cells.
  - <span id="index-floating_002dpoint-stack"></span> A floating point stack – for holding floating point (FP) numbers.
  - <span id="index-return-stack"></span> A return stack – for holding the return addresses of colon definitions and other (non-FP) data.
  - <span id="index-locals-stack"></span> A locals stack – for holding local variables.

|                                                                                             |  |  |
| :------------------------------------------------------------------------------------------ |  | :- |
| • [Data stack](Data-stack.html#Data-stack):                                                 |  |  |
| • [Floating point stack](Floating-point-stack.html#Floating-point-stack):                   |  |  |
| • [Return stack](Return-stack.html#Return-stack):                                           |  |  |
| • [Locals stack](Locals-stack.html#Locals-stack):                                           |  |  |
| • [Stack pointer manipulation](Stack-pointer-manipulation.html#Stack-pointer-manipulation): |  |  |
