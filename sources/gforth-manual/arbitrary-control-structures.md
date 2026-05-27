> Source: https://gforth.org/manual/Arbitrary-control-structures.html

<span id="Arbitrary-control-structures"></span>

<div class="header">

Next: [Calls and returns](Calls-and-returns.html#Calls-and-returns), Previous: [General control structures with CASE](General-control-structures-with-CASE.html#General-control-structures-with-CASE), Up: [Control Structures](Control-Structures.html#Control-Structures)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Arbitrary-control-structures-1"></span>

#### 5.8.6 Arbitrary control structures

<span id="index-control-structures_002c-user_002ddefined"></span> <span id="index-control_002dflow-stack"></span>

Standard Forth permits and supports using control structures in a non-nested way. Information about incomplete control structures is stored on the control-flow stack. This stack may be implemented on the Forth data stack, and this is what we have done in Gforth.

<span id="index-orig_002c-control_002dflow-stack-item"></span> <span id="index-dest_002c-control_002dflow-stack-item"></span>

An *orig* entry represents an unresolved forward branch, a *dest* entry represents a backward branch target. A few words are the basis for building any control structure possible (except control structures that need storage, like calls, coroutines, and backtracking).

<span id="index-IF--compilation-_002d_002d-orig-_003b-run_002dtime-f-_002d_002d--core"></span> <span id="index-IF"></span> <span id="index-IF-1"></span>

<div class="format">

``` format
IF       compilation – orig ; run-time f –         core       “IF”
```

</div>

<span id="index-AHEAD--compilation-_002d_002d-orig-_003b-run_002dtime-_002d_002d--tools_002dext"></span> <span id="index-AHEAD"></span> <span id="index-AHEAD-1"></span>

<div class="format">

``` format
AHEAD       compilation – orig ; run-time –         tools-ext       “AHEAD”
```

</div>

<span id="index-THEN--compilation-orig-_002d_002d-_003b-run_002dtime-_002d_002d--core"></span> <span id="index-THEN"></span> <span id="index-THEN-1"></span>

<div class="format">

``` format
THEN       compilation orig – ; run-time –         core       “THEN”
```

</div>

<span id="index-BEGIN--compilation-_002d_002d-dest-_003b-run_002dtime-_002d_002d--core"></span> <span id="index-BEGIN"></span> <span id="index-BEGIN-1"></span>

<div class="format">

``` format
BEGIN       compilation – dest ; run-time –         core       “BEGIN”
```

</div>

<span id="index-UNTIL--compilation-dest-_002d_002d-_003b-run_002dtime-f-_002d_002d--core"></span> <span id="index-UNTIL"></span> <span id="index-UNTIL-1"></span>

<div class="format">

``` format
UNTIL       compilation dest – ; run-time f –         core       “UNTIL”
```

</div>

<span id="index-AGAIN--compilation-dest-_002d_002d-_003b-run_002dtime-_002d_002d--core_002dext"></span> <span id="index-AGAIN"></span> <span id="index-AGAIN-1"></span>

<div class="format">

``` format
AGAIN       compilation dest – ; run-time –         core-ext       “AGAIN”
```

</div>

<span id="index-CS_002dPICK--_002e_002e_002e-u-_002d_002d-_002e_002e_002e-destu--tools_002dext"></span> <span id="index-CS_002dPICK"></span> <span id="index-CS_002dPICK-1"></span>

<div class="format">

``` format
CS-PICK       ... u – ... destu         tools-ext       “c-s-pick”
```

</div>

<span id="index-CS_002dROLL--destu_002forigu-_002e_002e-dest0_002forig0-u-_002d_002d-_002e_002e-dest0_002forig0-destu_002forigu--tools_002dext"></span> <span id="index-CS_002dROLL"></span> <span id="index-CS_002dROLL-1"></span>

<div class="format">

``` format
CS-ROLL       destu/origu .. dest0/orig0 u – .. dest0/orig0 destu/origu         tools-ext       “c-s-roll”
```

</div>

The Standard words `CS-PICK` and `CS-ROLL` allow you to manipulate the control-flow stack in a portable way. Without them, you would need to know how many stack items are occupied by a control-flow entry (many systems use one cell. In Gforth they currently take three, but this may change in the future).

Some standard control structure words are built from these words:

<span id="index-ELSE--compilation-orig1-_002d_002d-orig2-_003b-run_002dtime-_002d_002d--core"></span> <span id="index-ELSE"></span> <span id="index-ELSE-1"></span>

<div class="format">

``` format
ELSE       compilation orig1 – orig2 ; run-time –         core       “ELSE”
```

</div>

<span id="index-WHILE--compilation-dest-_002d_002d-orig-dest-_003b-run_002dtime-f-_002d_002d--core"></span> <span id="index-WHILE"></span> <span id="index-WHILE-1"></span>

<div class="format">

``` format
WHILE       compilation dest – orig dest ; run-time f –         core       “WHILE”
```

</div>

<span id="index-REPEAT--compilation-orig-dest-_002d_002d-_003b-run_002dtime-_002d_002d--core"></span> <span id="index-REPEAT"></span> <span id="index-REPEAT-1"></span>

<div class="format">

``` format
REPEAT       compilation orig dest – ; run-time –         core       “REPEAT”
```

</div>

Gforth adds some more control-structure words:

<span id="index-ENDIF--compilation-orig-_002d_002d-_003b-run_002dtime-_002d_002d--gforth"></span> <span id="index-ENDIF"></span> <span id="index-ENDIF-1"></span>

<div class="format">

``` format
ENDIF       compilation orig – ; run-time –         gforth       “ENDIF”
```

</div>

<span id="index-_003fdup_002dIF--compilation-_002d_002d-orig-_003b-run_002dtime-n-_002d_002d-n_007c--gforth"></span> <span id="index-_003fdup_002dIF"></span> <span id="index-_003fdup_002dIF-1"></span>

<div class="format">

``` format
?dup-IF       compilation – orig ; run-time n – n|         gforth       “question-dupe-if”
```

</div>

This is the preferred alternative to the idiom "`?DUP IF`", since it can be better handled by tools like stack checkers. Besides, it’s faster.

<span id="index-_003fDUP_002d0_003d_002dIF--compilation-_002d_002d-orig-_003b-run_002dtime-n-_002d_002d-n_007c--gforth"></span> <span id="index-_003fDUP_002d0_003d_002dIF"></span> <span id="index-_003fDUP_002d0_003d_002dIF-1"></span>

<div class="format">

``` format
?DUP-0=-IF       compilation – orig ; run-time n – n|         gforth       “question-dupe-zero-equals-if”
```

</div>

Counted loop words constitute a separate group of words:

<span id="index-_003fDO--compilation-_002d_002d-do_002dsys-_003b-run_002dtime-w1-w2-_002d_002d-_007c-loop_002dsys--core_002dext"></span> <span id="index-_003fDO"></span> <span id="index-_003fDO-1"></span>

<div class="format">

``` format
?DO       compilation – do-sys ; run-time w1 w2 – | loop-sys         core-ext       “question-do”
```

</div>

<span id="index-_002bDO--compilation-_002d_002d-do_002dsys-_003b-run_002dtime-n1-n2-_002d_002d-_007c-loop_002dsys--gforth"></span> <span id="index-_002bDO"></span> <span id="index-_002bDO-1"></span>

<div class="format">

``` format
+DO       compilation – do-sys ; run-time n1 n2 – | loop-sys         gforth       “plus-do”
```

</div>

<span id="index-U_002bDO--compilation-_002d_002d-do_002dsys-_003b-run_002dtime-u1-u2-_002d_002d-_007c-loop_002dsys--gforth"></span> <span id="index-U_002bDO"></span> <span id="index-U_002bDO-1"></span>

<div class="format">

``` format
U+DO       compilation – do-sys ; run-time u1 u2 – | loop-sys         gforth       “u-plus-do”
```

</div>

<span id="index-_002dDO--compilation-_002d_002d-do_002dsys-_003b-run_002dtime-n1-n2-_002d_002d-_007c-loop_002dsys--gforth"></span> <span id="index-_002dDO"></span> <span id="index-_002dDO-1"></span>

<div class="format">

``` format
-DO       compilation – do-sys ; run-time n1 n2 – | loop-sys         gforth       “minus-do”
```

</div>

<span id="index-U_002dDO--compilation-_002d_002d-do_002dsys-_003b-run_002dtime-u1-u2-_002d_002d-_007c-loop_002dsys--gforth"></span> <span id="index-U_002dDO"></span> <span id="index-U_002dDO-1"></span>

<div class="format">

``` format
U-DO       compilation – do-sys ; run-time u1 u2 – | loop-sys         gforth       “u-minus-do”
```

</div>

<span id="index-DO--compilation-_002d_002d-do_002dsys-_003b-run_002dtime-w1-w2-_002d_002d-loop_002dsys--core"></span> <span id="index-DO"></span> <span id="index-DO-1"></span>

<div class="format">

``` format
DO       compilation – do-sys ; run-time w1 w2 – loop-sys         core       “DO”
```

</div>

<span id="index-FOR--compilation-_002d_002d-do_002dsys-_003b-run_002dtime-u-_002d_002d-loop_002dsys--gforth"></span> <span id="index-FOR"></span> <span id="index-FOR-1"></span>

<div class="format">

``` format
FOR       compilation – do-sys ; run-time u – loop-sys         gforth       “FOR”
```

</div>

<span id="index-LOOP--compilation-do_002dsys-_002d_002d-_003b-run_002dtime-loop_002dsys1-_002d_002d-_007c-loop_002dsys2--core"></span> <span id="index-LOOP"></span> <span id="index-LOOP-1"></span>

<div class="format">

``` format
LOOP       compilation do-sys – ; run-time loop-sys1 – | loop-sys2         core       “LOOP”
```

</div>

<span id="index-_002bLOOP--compilation-do_002dsys-_002d_002d-_003b-run_002dtime-loop_002dsys1-n-_002d_002d-_007c-loop_002dsys2--core"></span> <span id="index-_002bLOOP"></span> <span id="index-_002bLOOP-1"></span>

<div class="format">

``` format
+LOOP       compilation do-sys – ; run-time loop-sys1 n – | loop-sys2         core       “plus-loop”
```

</div>

<span id="index-_002dLOOP--compilation-do_002dsys-_002d_002d-_003b-run_002dtime-loop_002dsys1-u-_002d_002d-_007c-loop_002dsys2--gforth"></span> <span id="index-_002dLOOP"></span> <span id="index-_002dLOOP-1"></span>

<div class="format">

``` format
-LOOP       compilation do-sys – ; run-time loop-sys1 u – | loop-sys2         gforth       “minus-loop”
```

</div>

<span id="index-NEXT--compilation-do_002dsys-_002d_002d-_003b-run_002dtime-loop_002dsys1-_002d_002d-_007c-loop_002dsys2--gforth"></span> <span id="index-NEXT"></span> <span id="index-NEXT-1"></span>

<div class="format">

``` format
NEXT       compilation do-sys – ; run-time loop-sys1 – | loop-sys2         gforth       “NEXT”
```

</div>

<span id="index-LEAVE--compilation-_002d_002d-_003b-run_002dtime-loop_002dsys-_002d_002d--core"></span> <span id="index-LEAVE"></span> <span id="index-LEAVE-1"></span>

<div class="format">

``` format
LEAVE       compilation – ; run-time loop-sys –         core       “LEAVE”
```

</div>

<span id="index-_003fLEAVE--compilation-_002d_002d-_003b-run_002dtime-f-_007c-f-loop_002dsys-_002d_002d--gforth"></span> <span id="index-_003fLEAVE"></span> <span id="index-_003fLEAVE-1"></span>

<div class="format">

``` format
?LEAVE       compilation – ; run-time f | f loop-sys –         gforth       “question-leave”
```

</div>

<span id="index-unloop--R_003aw1-R_003aw2-_002d_002d--core"></span> <span id="index-unloop"></span> <span id="index-unloop-1"></span>

<div class="format">

``` format
unloop       R:w1 R:w2 –        core       “unloop”
```

</div>

<span id="index-DONE--compilation-orig-_002d_002d-_003b-run_002dtime-_002d_002d--gforth"></span> <span id="index-DONE"></span> <span id="index-DONE-1"></span>

<div class="format">

``` format
DONE       compilation orig – ; run-time –         gforth       “DONE”
```

</div>

resolves all LEAVEs up to the compilaton orig (from a BEGIN)

The standard does not allow using `CS-PICK` and `CS-ROLL` on *do-sys*. Gforth allows it, but it’s your job to ensure that for every `?DO` etc. there is exactly one `UNLOOP` on any path through the definition (`LOOP` etc. compile an `UNLOOP` on the fall-through path). Also, you have to ensure that all `LEAVE`s are resolved (by using one of the loop-ending words or `DONE`).

Another group of control structure words are:

<span id="index-case--compilation-_002d_002d-case_002dsys-_003b-run_002dtime-_002d_002d--core_002dext"></span> <span id="index-case"></span> <span id="index-case-1"></span>

<div class="format">

``` format
case       compilation  – case-sys ; run-time  –         core-ext       “case”
```

</div>

Start a `case` structure.

<span id="index-endcase--compilation-case_002dsys-_002d_002d-_003b-run_002dtime-x-_002d_002d--core_002dext"></span> <span id="index-endcase"></span> <span id="index-endcase-1"></span>

<div class="format">

``` format
endcase       compilation case-sys – ; run-time x –         core-ext       “end-case”
```

</div>

Finish the `case` structure; drop x, and continue behind the `endcase`. Dropping x is useful in the original `case` construct (with only `of`s), but you may have to supply an x in other cases (especially when using `?of`).

<span id="index-next_002dcase--compilation-case_002dsys-_002d_002d-_003b-run_002dtime-_002d_002d--gforth"></span> <span id="index-next_002dcase"></span> <span id="index-next_002dcase-1"></span>

<div class="format">

``` format
next-case       compilation case-sys – ; run-time –         gforth       “next-case”
```

</div>

Restart the `case` loop by jumping to the matching `case`. Note that `next-case` does not drop a cell, unlike `endcase`.

<span id="index-of--compilation-_002d_002d-of_002dsys-_003b-run_002dtime-x1-x2-_002d_002d-_007cx1--core_002dext"></span> <span id="index-of"></span> <span id="index-of-1"></span>

<div class="format">

``` format
of       compilation  – of-sys ; run-time x1 x2 – |x1         core-ext       “of”
```

</div>

If x1=x2, continue (dropping both); otherwise, leave x1 on the stack and jump behind `endof` or `contof`.

<span id="index-_003fof--compilation-_002d_002d-of_002dsys-_003b-run_002dtime-f-_002d_002d--gforth"></span> <span id="index-_003fof"></span> <span id="index-_003fof-1"></span>

<div class="format">

``` format
?of       compilation  – of-sys ; run-time  f –         gforth       “question-of”
```

</div>

If f is true, continue; otherwise, jump behind `endof` or `contof`.

<span id="index-endof--compilation-case_002dsys1-of_002dsys-_002d_002d-case_002dsys2-_003b-run_002dtime-_002d_002d--core_002dext"></span> <span id="index-endof"></span> <span id="index-endof-1"></span>

<div class="format">

``` format
endof       compilation case-sys1 of-sys – case-sys2 ; run-time  –         core-ext       “end-of”
```

</div>

Exit the enclosing `case` structure by jumping behind `endcase`/`next-case`.

<span id="index-contof--compilation-case_002dsys1-of_002dsys-_002d_002d-case_002dsys2-_003b-run_002dtime-_002d_002d--gforth"></span> <span id="index-contof"></span> <span id="index-contof-1"></span>

<div class="format">

``` format
contof       compilation case-sys1 of-sys – case-sys2 ; run-time  –         gforth       “cont-of”
```

</div>

Restart the `case` loop by jumping to the enclosing `case`.

Internally, *of-sys* is an `orig`; and *case-sys* is a cell and some stack-depth information, 0 or more `orig`s, and a `dest`.

<span id="Programming-Style"></span>

#### 5.8.6.1 Programming Style

<span id="index-control-structures-programming-style"></span> <span id="index-programming-style_002c-arbitrary-control-structures"></span>

In order to ensure readability we recommend that you do not create arbitrary control structures directly, but define new control structure words for the control structure you want and use these words in your program. For example, instead of writing:

<div class="example">

``` example
BEGIN
  ...
IF [ 1 CS-ROLL ]
  ...
AGAIN THEN
```

</div>

we recommend defining control structure words, e.g.,

<div class="example">

``` example
: WHILE ( DEST -- ORIG DEST )
 POSTPONE IF
 1 CS-ROLL ; immediate

: REPEAT ( orig dest -- )
 POSTPONE AGAIN
 POSTPONE THEN ; immediate
```

</div>

and then using these to create the control structure:

<div class="example">

``` example
BEGIN
  ...
WHILE
  ...
REPEAT
```

</div>

That’s much easier to read, isn’t it? Of course, `REPEAT` and `WHILE` are predefined, so in this example it would not be necessary to define them.

-----

<div class="header">

Next: [Calls and returns](Calls-and-returns.html#Calls-and-returns), Previous: [General control structures with CASE](General-control-structures-with-CASE.html#General-control-structures-with-CASE), Up: [Control Structures](Control-Structures.html#Control-Structures)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
