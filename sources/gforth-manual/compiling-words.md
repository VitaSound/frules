> Source: https://gforth.org/manual/Compiling-words.html

<span id="Compiling-words"></span>

<div class="header">

Next: [The Text Interpreter](The-Text-Interpreter.html#The-Text-Interpreter), Previous: [Tokens for Words](Tokens-for-Words.html#Tokens-for-Words), Up: [Words](Words.html#Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Compiling-words-1"></span>

### 5.12 Compiling words

<span id="index-compiling-words"></span> <span id="index-macros"></span>

In contrast to most other languages, Forth has no strict boundary between compilation and run-time. E.g., you can run arbitrary code between defining words (or for computing data used by defining words like `constant`). Moreover, `Immediate` (see [Interpretation and Compilation Semantics](Interpretation-and-Compilation-Semantics.html#Interpretation-and-Compilation-Semantics) and `[`...`]` (see below) allow running arbitrary code while compiling a colon definition (exception: you must not allot dictionary space).

|                                       |  |                       |
| :------------------------------------ |  | :-------------------- |
| • [Literals](Literals.html#Literals): |  | Compiling data values |
| • [Macros](Macros.html#Macros):       |  | Compiling words       |
