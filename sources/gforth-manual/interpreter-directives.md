> Source: https://gforth.org/manual/Interpreter-Directives.html

<span id="Interpreter-Directives"></span>

<div class="header">

Next: [Recognizers](Recognizers.html#Recognizers), Previous: [Interpret/Compile states](Interpret_002fCompile-states.html#Interpret_002fCompile-states), Up: [The Text Interpreter](The-Text-Interpreter.html#The-Text-Interpreter)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Interpreter-Directives-1"></span>

#### 5.13.4 Interpreter Directives

<span id="index-interpreter-directives"></span> <span id="index-conditional-compilation"></span>

These words are usually used in interpret state; typically to control which parts of a source file are processed by the text interpreter. There are only a few Standard Forth Standard words, but Gforth supplements these with a rich set of immediate control structure words to compensate for the fact that the non-immediate versions can only be used in compile state (see [Control Structures](Control-Structures.html#Control-Structures)). Typical usages:

<div class="example">

``` example
FALSE Constant HAVE-ASSEMBLER
.
.
HAVE-ASSEMBLER [IF]
: ASSEMBLER-FEATURE
  ...
;
[ENDIF]
.
.
: SEE
  ... \ general-purpose SEE code
  [ HAVE-ASSEMBLER [IF] ]
  ... \ assembler-specific SEE code
  [ [ENDIF] ]
;
```

</div>

<span id="index-_005bIF_005d--flag-_002d_002d-_002f-parser--tools_002dext"></span> <span id="index-_005bIF_005d"></span> <span id="index-_005bIF_005d-1"></span>

<div class="format">

``` format
[IF]       flag – / parser         tools-ext       “bracket-if”
```

</div>

If flag is `TRUE` do nothing (and therefore execute subsequent words as normal). If flag is `FALSE`, parse and discard words from the parse area (refilling it if necessary using `REFILL`) including nested instances of `[IF]`.. `[ELSE]`.. `[THEN]` and `[IF]`.. `[THEN]` until the balancing `[ELSE]` or `[THEN]` has been parsed and discarded. Immediate word.

<span id="index-_005bELSE_005d--_002d_002d--tools_002dext"></span> <span id="index-_005bELSE_005d"></span> <span id="index-_005bELSE_005d-1"></span>

<div class="format">

``` format
[ELSE]       –         tools-ext       “bracket-else”
```

</div>

Parse and discard words from the parse area (refilling it if necessary using `REFILL`) including nested instances of `[IF]`.. `[ELSE]`.. `[THEN]` and `[IF]`.. `[THEN]` until the balancing `[THEN]` has been parsed and discarded. `[ELSE]` only gets executed if the balancing `[IF]` was `TRUE`; if it was `FALSE`, `[IF]` would have parsed and discarded the `[ELSE]`, leaving the subsequent words to be executed as normal. Immediate word.

<span id="index-_005bTHEN_005d--_002d_002d--tools_002dext"></span> <span id="index-_005bTHEN_005d"></span> <span id="index-_005bTHEN_005d-1"></span>

<div class="format">

``` format
[THEN]       –         tools-ext       “bracket-then”
```

</div>

Do nothing; used as a marker for other words to parse and discard up to. Immediate word.

<span id="index-_005bENDIF_005d--_002d_002d--gforth"></span> <span id="index-_005bENDIF_005d"></span> <span id="index-_005bENDIF_005d-1"></span>

<div class="format">

``` format
[ENDIF]       –         gforth       “bracket-end-if”
```

</div>

Do nothing; synonym for `[THEN]`

<span id="index-_005bIFDEF_005d--_0022_003cspaces_003ename_0022-_002d_002d--gforth"></span> <span id="index-_005bIFDEF_005d"></span> <span id="index-_005bIFDEF_005d-1"></span>

<div class="format">

``` format
[IFDEF]       "<spaces>name" –         gforth       “bracket-if-def”
```

</div>

If name is found in the current search-order, behave like `[IF]` with a `TRUE` flag, otherwise behave like `[IF]` with a `FALSE` flag. Immediate word.

<span id="index-_005bIFUNDEF_005d--_0022_003cspaces_003ename_0022-_002d_002d--gforth"></span> <span id="index-_005bIFUNDEF_005d"></span> <span id="index-_005bIFUNDEF_005d-1"></span>

<div class="format">

``` format
[IFUNDEF]       "<spaces>name" –         gforth       “bracket-if-un-def”
```

</div>

If name is not found in the current search-order, behave like `[IF]` with a `TRUE` flag, otherwise behave like `[IF]` with a `FALSE` flag. Immediate word.

<span id="index-_005b_003fDO_005d--n_002dlimit-n_002dindex-_002d_002d--gforth"></span> <span id="index-_005b_003fDO_005d"></span> <span id="index-_005b_003fDO_005d-1"></span>

<div class="format">

``` format
[?DO]       n-limit n-index –         gforth       “bracket-question-do”
```

</div>

<span id="index-_005bDO_005d--n_002dlimit-n_002dindex-_002d_002d--gforth"></span> <span id="index-_005bDO_005d"></span> <span id="index-_005bDO_005d-1"></span>

<div class="format">

``` format
[DO]       n-limit n-index –         gforth       “bracket-do”
```

</div>

<span id="index-_005bFOR_005d--n-_002d_002d--gforth"></span> <span id="index-_005bFOR_005d"></span> <span id="index-_005bFOR_005d-1"></span>

<div class="format">

``` format
[FOR]       n –         gforth       “bracket-for”
```

</div>

<span id="index-_005bLOOP_005d--_002d_002d--gforth"></span> <span id="index-_005bLOOP_005d"></span> <span id="index-_005bLOOP_005d-1"></span>

<div class="format">

``` format
[LOOP]       –         gforth       “bracket-loop”
```

</div>

<span id="index-_005b_002bLOOP_005d--n-_002d_002d--gforth"></span> <span id="index-_005b_002bLOOP_005d"></span> <span id="index-_005b_002bLOOP_005d-1"></span>

<div class="format">

``` format
[+LOOP]       n –         gforth       “bracket-question-plus-loop”
```

</div>

<span id="index-_005bNEXT_005d--n-_002d_002d--gforth"></span> <span id="index-_005bNEXT_005d"></span> <span id="index-_005bNEXT_005d-1"></span>

<div class="format">

``` format
[NEXT]       n –         gforth       “bracket-next”
```

</div>

<span id="index-_005bBEGIN_005d--_002d_002d--gforth"></span> <span id="index-_005bBEGIN_005d"></span> <span id="index-_005bBEGIN_005d-1"></span>

<div class="format">

``` format
[BEGIN]       –         gforth       “bracket-begin”
```

</div>

<span id="index-_005bUNTIL_005d--flag-_002d_002d--gforth"></span> <span id="index-_005bUNTIL_005d"></span> <span id="index-_005bUNTIL_005d-1"></span>

<div class="format">

``` format
[UNTIL]       flag –         gforth       “bracket-until”
```

</div>

<span id="index-_005bAGAIN_005d--_002d_002d--gforth"></span> <span id="index-_005bAGAIN_005d"></span> <span id="index-_005bAGAIN_005d-1"></span>

<div class="format">

``` format
[AGAIN]       –         gforth       “bracket-again”
```

</div>

<span id="index-_005bWHILE_005d--flag-_002d_002d--gforth"></span> <span id="index-_005bWHILE_005d"></span> <span id="index-_005bWHILE_005d-1"></span>

<div class="format">

``` format
[WHILE]       flag –         gforth       “bracket-while”
```

</div>

<span id="index-_005bREPEAT_005d--_002d_002d--gforth"></span> <span id="index-_005bREPEAT_005d"></span> <span id="index-_005bREPEAT_005d-1"></span>

<div class="format">

``` format
[REPEAT]       –         gforth       “bracket-repeat”
```

</div>

-----

<div class="header">

Next: [Recognizers](Recognizers.html#Recognizers), Previous: [Interpret/Compile states](Interpret_002fCompile-states.html#Interpret_002fCompile-states), Up: [The Text Interpreter](The-Text-Interpreter.html#The-Text-Interpreter)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
