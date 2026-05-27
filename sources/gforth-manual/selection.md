> Source: https://gforth.org/manual/Selection.html

<span id="Selection"></span>

<div class="header">

Next: [Simple Loops](Simple-Loops.html#Simple-Loops), Previous: [Control Structures](Control-Structures.html#Control-Structures), Up: [Control Structures](Control-Structures.html#Control-Structures)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Selection-1"></span>

#### 5.8.1 Selection

<span id="index-selection-control-structures"></span> <span id="index-control-structures-for-selection"></span> <span id="index-IF-control-structure"></span>

<div class="example">

``` example
flag
IF
  code
ENDIF
```

</div>

If *flag* is non-zero (as far as `IF` etc. are concerned, a cell with any bit set represents truth) *code* is executed.

<div class="example">

``` example
flag
IF
  code1
ELSE
  code2
ENDIF
```

</div>

If `flag` is true, *code1* is executed, otherwise *code2* is executed.

You can use `THEN` instead of `ENDIF`. Indeed, `THEN` is standard, and `ENDIF` is not, although it is quite popular. We recommend using `ENDIF`, because it is less confusing for people who also know other languages (and is not prone to reinforcing negative prejudices against Forth in these people). Adding `ENDIF` to a system that only supplies `THEN` is simple:

<div class="example">

``` example
: ENDIF   POSTPONE then ; immediate
```

</div>

\[According to Webster’s New Encyclopedic Dictionary, *then (adv.)* has the following meanings:

> ... 2b: following next after in order ... 3d: as a necessary consequence (if you were there, then you saw them).

Forth’s `THEN` has the meaning 2b, whereas `THEN` in Pascal and many other programming languages has the meaning 3d.\]

Gforth also provides the words `?DUP-IF` and `?DUP-0=-IF`, so you can avoid using `?dup`. Using these alternatives is also more efficient than using `?dup`. Definitions in Standard Forth for `ENDIF`, `?DUP-IF` and `?DUP-0=-IF` are provided in `compat/control.fs`.

<span id="index-CASE-control-structure"></span>

<div class="example">

``` example
x
CASE
  x1 OF code1 ENDOF
  x2 OF code2 ENDOF
  …
  ( x ) default-code ( x )
ENDCASE ( )
```

</div>

Executes the first *codei*, where the *xi* is equal to *x*. If no *xi* matches, the optional *default-code* is executed. The optional default case can be added by simply writing the code after the last `ENDOF`. It may use *x*, which is on top of the stack, but must not consume it. The value *x* is consumed by this construction (either by an `OF` that matches, or by the `ENDCASE`, if no OF matches). Example:

<div class="example">

``` example
: num-name ( n -- c-addr u )
 case
   0 of s" zero " endof
   1 of s" one "  endof
   2 of s" two "  endof
   \ default case:
   s" other number" 
   rot \ get n on top so ENDCASE can drop it
 endcase ;
```

</div>

You can also use (the non-standard) `?of` to use `case` as a general selection structure for more than two alternatives. `?Of` takes a flag. Example:

<div class="example">

``` example
: sgn ( n1 -- n2 )
    \ sign function
    case
    dup 0< ?of drop -1 endof
    dup 0> ?of drop 1 endof
    dup \ n1=0 -> n2=0; dup an item, to be consumed by ENDCASE
    endcase ;
```

</div>

Programming style note: To keep the code understandable, you should ensure that you change the stack in the same way (wrt. number and types of stack items consumed and pushed) on all paths through a selection structure.

-----

<div class="header">

Next: [Simple Loops](Simple-Loops.html#Simple-Loops), Previous: [Control Structures](Control-Structures.html#Control-Structures), Up: [Control Structures](Control-Structures.html#Control-Structures)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
