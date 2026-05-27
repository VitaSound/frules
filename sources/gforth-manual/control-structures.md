> Source: https://gforth.org/manual/Control-Structures.html

<span id="Control-Structures"></span>

<div class="header">

Next: [Defining Words](Defining-Words.html#Defining-Words), Previous: [Memory](Memory.html#Memory), Up: [Words](Words.html#Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Control-Structures-1"></span>

### 5.8 Control Structures

<span id="index-control-structures"></span>

Control structures in Forth cannot be used interpretively, only in a colon definition[<sup>11</sup>](#FOOT11). We do not like this limitation, but have not seen a satisfying way around it yet, although many schemes have been proposed.

|                                                                                                                           |  |                       |
| :------------------------------------------------------------------------------------------------------------------------ |  | :-------------------- |
| • [Selection](Selection.html#Selection):                                                                                  |  | IF ... ELSE ... ENDIF |
| • [Simple Loops](Simple-Loops.html#Simple-Loops):                                                                         |  | BEGIN ...             |
| • [Counted Loops](Counted-Loops.html#Counted-Loops):                                                                      |  | DO                    |
| • [BEGIN loops with multiple exits](BEGIN-loops-with-multiple-exits.html#BEGIN-loops-with-multiple-exits):                |  |                       |
| • [General control structures with CASE](General-control-structures-with-CASE.html#General-control-structures-with-CASE): |  |                       |
| • [Arbitrary control structures](Arbitrary-control-structures.html#Arbitrary-control-structures):                         |  |                       |
| • [Calls and returns](Calls-and-returns.html#Calls-and-returns):                                                          |  |                       |
| • [Exception Handling](Exception-Handling.html#Exception-Handling):                                                       |  |                       |

<div class="footnote">

-----

#### Footnotes

### [(11)](#DOCF11)

To be precise, they have no interpretation semantics (see [Interpretation and Compilation Semantics](Interpretation-and-Compilation-Semantics.html#Interpretation-and-Compilation-Semantics)).

</div>
