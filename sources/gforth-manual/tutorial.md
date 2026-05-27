> Source: https://gforth.org/manual/Tutorial.html

<span id="Tutorial"></span>

<div class="header">

Next: [Introduction](Introduction.html#Introduction), Previous: [Gforth Environment](Gforth-Environment.html#Gforth-Environment), Up: [Top](index.html#Top)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Forth-Tutorial"></span>

## 3 Forth Tutorial

<span id="index-Tutorial"></span> <span id="index-Forth-Tutorial"></span>

The difference of this chapter from the Introduction (see [Introduction](Introduction.html#Introduction)) is that this tutorial is more fast-paced, should be used while sitting in front of a computer, and covers much more material, but does not explain how the Forth system works.

This tutorial can be used with any Standard-compliant Forth; any Gforth-specific features are marked as such and you can skip them if you work with another Forth. This tutorial does not explain all features of Forth, just enough to get you started and give you some ideas about the facilities available in Forth. Read the rest of the manual when you are through this.

The intended way to use this tutorial is that you work through it while sitting in front of the console, take a look at the examples and predict what they will do, then try them out; if the outcome is not as expected, find out why (e.g., by trying out variations of the example), so you understand what’s going on. There are also some assignments that you should solve.

This tutorial assumes that you have programmed before and know what, e.g., a loop is.

|                                                                                                                                                                                                            |  |  |
| :--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |  | :- |
| • [Starting Gforth Tutorial](Starting-Gforth-Tutorial.html#Starting-Gforth-Tutorial):                                                                                                                      |  |  |
| • [Syntax Tutorial](Syntax-Tutorial.html#Syntax-Tutorial):                                                                                                                                                 |  |  |
| • [Crash Course Tutorial](Crash-Course-Tutorial.html#Crash-Course-Tutorial):                                                                                                                               |  |  |
| • [Stack Tutorial](Stack-Tutorial.html#Stack-Tutorial):                                                                                                                                                    |  |  |
| • [Arithmetics Tutorial](Arithmetics-Tutorial.html#Arithmetics-Tutorial):                                                                                                                                  |  |  |
| • [Stack Manipulation Tutorial](Stack-Manipulation-Tutorial.html#Stack-Manipulation-Tutorial):                                                                                                             |  |  |
| • [Using files for Forth code Tutorial](Using-files-for-Forth-code-Tutorial.html#Using-files-for-Forth-code-Tutorial):                                                                                     |  |  |
| • [Comments Tutorial](Comments-Tutorial.html#Comments-Tutorial):                                                                                                                                           |  |  |
| • [Colon Definitions Tutorial](Colon-Definitions-Tutorial.html#Colon-Definitions-Tutorial):                                                                                                                |  |  |
| • [Decompilation Tutorial](Decompilation-Tutorial.html#Decompilation-Tutorial):                                                                                                                            |  |  |
| • [Stack-Effect Comments Tutorial](Stack_002dEffect-Comments-Tutorial.html#Stack_002dEffect-Comments-Tutorial):                                                                                            |  |  |
| • [Types Tutorial](Types-Tutorial.html#Types-Tutorial):                                                                                                                                                    |  |  |
| • [Factoring Tutorial](Factoring-Tutorial.html#Factoring-Tutorial):                                                                                                                                        |  |  |
| • [Designing the stack effect Tutorial](Designing-the-stack-effect-Tutorial.html#Designing-the-stack-effect-Tutorial):                                                                                     |  |  |
| • [Local Variables Tutorial](Local-Variables-Tutorial.html#Local-Variables-Tutorial):                                                                                                                      |  |  |
| • [Conditional execution Tutorial](Conditional-execution-Tutorial.html#Conditional-execution-Tutorial):                                                                                                    |  |  |
| • [Flags and Comparisons Tutorial](Flags-and-Comparisons-Tutorial.html#Flags-and-Comparisons-Tutorial):                                                                                                    |  |  |
| • [General Loops Tutorial](General-Loops-Tutorial.html#General-Loops-Tutorial):                                                                                                                            |  |  |
| • [Counted loops Tutorial](Counted-loops-Tutorial.html#Counted-loops-Tutorial):                                                                                                                            |  |  |
| • [Recursion Tutorial](Recursion-Tutorial.html#Recursion-Tutorial):                                                                                                                                        |  |  |
| • [Leaving definitions or loops Tutorial](Leaving-definitions-or-loops-Tutorial.html#Leaving-definitions-or-loops-Tutorial):                                                                               |  |  |
| • [Return Stack Tutorial](Return-Stack-Tutorial.html#Return-Stack-Tutorial):                                                                                                                               |  |  |
| • [Memory Tutorial](Memory-Tutorial.html#Memory-Tutorial):                                                                                                                                                 |  |  |
| • [Characters and Strings Tutorial](Characters-and-Strings-Tutorial.html#Characters-and-Strings-Tutorial):                                                                                                 |  |  |
| • [Alignment Tutorial](Alignment-Tutorial.html#Alignment-Tutorial):                                                                                                                                        |  |  |
| • [Floating Point Tutorial](Floating-Point-Tutorial.html#Floating-Point-Tutorial):                                                                                                                         |  |  |
| • [Files Tutorial](Files-Tutorial.html#Files-Tutorial):                                                                                                                                                    |  |  |
| • [Interpretation and Compilation Semantics and Immediacy Tutorial](Interpretation-and-Compilation-Semantics-and-Immediacy-Tutorial.html#Interpretation-and-Compilation-Semantics-and-Immediacy-Tutorial): |  |  |
| • [Execution Tokens Tutorial](Execution-Tokens-Tutorial.html#Execution-Tokens-Tutorial):                                                                                                                   |  |  |
| • [Exceptions Tutorial](Exceptions-Tutorial.html#Exceptions-Tutorial):                                                                                                                                     |  |  |
| • [Defining Words Tutorial](Defining-Words-Tutorial.html#Defining-Words-Tutorial):                                                                                                                         |  |  |
| • [Arrays and Records Tutorial](Arrays-and-Records-Tutorial.html#Arrays-and-Records-Tutorial):                                                                                                             |  |  |
| • [POSTPONE Tutorial](POSTPONE-Tutorial.html#POSTPONE-Tutorial):                                                                                                                                           |  |  |
| • [Literal Tutorial](Literal-Tutorial.html#Literal-Tutorial):                                                                                                                                              |  |  |
| • [Advanced macros Tutorial](Advanced-macros-Tutorial.html#Advanced-macros-Tutorial):                                                                                                                      |  |  |
| • [Compilation Tokens Tutorial](Compilation-Tokens-Tutorial.html#Compilation-Tokens-Tutorial):                                                                                                             |  |  |
| • [Wordlists and Search Order Tutorial](Wordlists-and-Search-Order-Tutorial.html#Wordlists-and-Search-Order-Tutorial):                                                                                     |  |  |

-----

<div class="header">

Next: [Introduction](Introduction.html#Introduction), Previous: [Gforth Environment](Gforth-Environment.html#Gforth-Environment), Up: [Top](index.html#Top)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
