# 3 Forth Tutorial

> Source: https://gforth.org/manual/Tutorial.html

The difference of this chapter from the Introduction (see Introduction) is that this tutorial is more fast-paced, should be used while sitting in front of a computer, and covers much more material, but does not explain how the Forth system works.

This tutorial can be used with any Standard-compliant Forth; any Gforth-specific features are marked as such and you can skip them if you work with another Forth. This tutorial does not explain all features of Forth, just enough to get you started and give you some ideas about the facilities available in Forth. Read the rest of the manual when you are through this.

The intended way to use this tutorial is that you work through it while sitting in front of the console, take a look at the examples and predict what they will do, then try them out; if the outcome is not as expected, find out why (e.g., by trying out variations of the example), so you understand what's going on. There are also some assignments that you should solve.

This tutorial assumes that you have programmed before and know what, e.g., a loop is.

## Sections

| § | File | Topic |
|---|------|-------|
| 3.1 | [starting-gforth.md](starting-gforth.md) | Starting Gforth |
| 3.2 | [syntax.md](syntax.md) | Syntax |
| 3.3 | [crash-course.md](crash-course.md) | Crash Course |
| 3.4 | [stack.md](stack.md) | Stack |
| 3.5 | [arithmetics.md](arithmetics.md) | Arithmetics |
| 3.6 | [stack-manipulation.md](stack-manipulation.md) | Stack Manipulation |
| 3.7 | [using-files.md](using-files.md) | Using files for Forth code |
| 3.8 | [comments.md](comments.md) | Comments |
| 3.9 | [colon-definitions.md](colon-definitions.md) | Colon Definitions |
| 3.10 | [decompilation.md](decompilation.md) | Decompilation |
| 3.11 | [stack-effect-comments.md](stack-effect-comments.md) | Stack-Effect Comments |
| 3.12 | [types.md](types.md) | Types |
| 3.13 | [factoring.md](factoring.md) | Factoring |
| 3.14 | [designing-stack-effect.md](designing-stack-effect.md) | Designing the stack effect |
| 3.15 | [local-variables.md](local-variables.md) | Local Variables |
| 3.16 | [conditional-execution.md](conditional-execution.md) | Conditional execution |
| 3.17 | [flags-and-comparisons.md](flags-and-comparisons.md) | Flags and Comparisons |
| 3.18 | [general-loops.md](general-loops.md) | General Loops |
| 3.19 | [counted-loops.md](counted-loops.md) | Counted loops |
| 3.20 | [recursion.md](recursion.md) | Recursion |
| 3.21 | [leaving-definitions-or-loops.md](leaving-definitions-or-loops.md) | Leaving definitions or loops |
| 3.22 | [return-stack.md](return-stack.md) | Return Stack |
| 3.23 | [memory.md](memory.md) | Memory |
| 3.24 | [characters-and-strings.md](characters-and-strings.md) | Characters and Strings |
| 3.25 | [alignment.md](alignment.md) | Alignment |
| 3.26 | [floating-point.md](floating-point.md) | Floating Point |
| 3.27 | [files.md](files.md) | Files |
| 3.28 | [interpretation-and-compilation.md](interpretation-and-compilation.md) | Interpretation and Compilation Semantics |
| 3.29 | [execution-tokens.md](execution-tokens.md) | Execution Tokens |
| 3.30 | [exceptions.md](exceptions.md) | Exceptions |
| 3.31 | [defining-words.md](defining-words.md) | Defining Words |
| 3.32 | [arrays-and-records.md](arrays-and-records.md) | Arrays and Records |
| 3.33 | [postpone.md](postpone.md) | POSTPONE |
| 3.34 | [literal.md](literal.md) | Literal |
| 3.35 | [advanced-macros.md](advanced-macros.md) | Advanced macros |
| 3.36 | [compilation-tokens.md](compilation-tokens.md) | Compilation Tokens |
| 3.37 | [wordlists-and-search-order.md](wordlists-and-search-order.md) | Wordlists and Search Order |
