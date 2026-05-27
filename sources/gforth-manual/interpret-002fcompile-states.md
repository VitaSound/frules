> Source: https://gforth.org/manual/Interpret_002fCompile-states.html

<span id="Interpret_002fCompile-states"></span>

<div class="header">

Next: [Interpreter Directives](Interpreter-Directives.html#Interpreter-Directives), Previous: [Number Conversion](Number-Conversion.html#Number-Conversion), Up: [The Text Interpreter](The-Text-Interpreter.html#The-Text-Interpreter)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Interpret_002fCompile-states-1"></span>

#### 5.13.3 Interpret/Compile states

<span id="index-Interpret_002fCompile-states"></span>

A standard program is not permitted to change `state` explicitly. However, it can change `state` implicitly, using the words `[` and `]`. When `[` is executed it switches `state` to interpret state, and therefore the text interpreter starts interpreting. When `]` is executed it switches `state` to compile state and therefore the text interpreter starts compiling. The most common usage for these words is for switching into interpret state and back from within a colon definition; this technique can be used to compile a literal (for an example, see [Literals](Literals.html#Literals)) or for conditional compilation (for an example, see [Interpreter Directives](Interpreter-Directives.html#Interpreter-Directives)).
