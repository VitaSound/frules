> Source: https://gforth.org/manual/Where-are-locals-visible-by-name_003f.html

<span id="Where-are-locals-visible-by-name_003f"></span>

<div class="header">

Next: [How long do locals live?](How-long-do-locals-live_003f.html#How-long-do-locals-live_003f), Previous: [Gforth locals](Gforth-locals.html#Gforth-locals), Up: [Gforth locals](Gforth-locals.html#Gforth-locals)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Where-are-locals-visible-by-name_003f-1"></span>

#### 5.21.1.1 Where are locals visible by name?

<span id="index-locals-visibility"></span> <span id="index-visibility-of-locals"></span> <span id="index-scope-of-locals"></span>

Basically, the answer is that locals are visible where you would expect it in block-structured languages, and sometimes a little longer. If you want to restrict the scope of a local, enclose its definition in `SCOPE`...`ENDSCOPE`.

<span id="index-scope--compilation-_002d_002d-scope-_003b-run_002dtime-_002d_002d--gforth"></span> <span id="index-scope"></span> <span id="index-scope-1"></span>

<div class="format">

``` format
scope       compilation  – scope ; run-time  –         gforth       “scope”
```

</div>

<span id="index-endscope--compilation-scope-_002d_002d-_003b-run_002dtime-_002d_002d--gforth"></span> <span id="index-endscope"></span> <span id="index-endscope-1"></span>

<div class="format">

``` format
endscope       compilation scope – ; run-time  –         gforth       “endscope”
```

</div>

These words behave like control structure words, so you can use them with `CS-PICK` and `CS-ROLL` to restrict the scope in arbitrary ways.

If you want a more exact answer to the visibility question, here’s the basic principle: A local is visible in all places that can only be reached through the definition of the local[<sup>31</sup>](#FOOT31). In other words, it is not visible in places that can be reached without going through the definition of the local. E.g., locals defined in `IF`...`ENDIF` are visible until the `ENDIF`, locals defined in `BEGIN`...`UNTIL` are visible after the `UNTIL` (until, e.g., a subsequent `ENDSCOPE`).

The reasoning behind this solution is: We want to have the locals visible as long as it is meaningful. The user can always make the visibility shorter by using explicit scoping. In a place that can only be reached through the definition of a local, the meaning of a local name is clear. In other places it is not: How is the local initialized at the control flow path that does not contain the definition? Which local is meant, if the same name is defined twice in two independent control flow paths?

This should be enough detail for nearly all users, so you can skip the rest of this section. If you really must know all the gory details and options, read on.

In order to implement this rule, the compiler has to know which places are unreachable. It knows this automatically after `AHEAD`, `AGAIN`, `EXIT` and `LEAVE`; in other cases (e.g., after most `THROW`s), you can use the word `UNREACHABLE` to tell the compiler that the control flow never reaches that place. If `UNREACHABLE` is not used where it could, the only consequence is that the visibility of some locals is more limited than the rule above says. If `UNREACHABLE` is used where it should not (i.e., if you lie to the compiler), buggy code will be produced.

<span id="index-UNREACHABLE--_002d_002d--gforth"></span> <span id="index-UNREACHABLE"></span> <span id="index-UNREACHABLE-1"></span>

<div class="format">

``` format
UNREACHABLE       –         gforth       “UNREACHABLE”
```

</div>

Another problem with this rule is that at `BEGIN`, the compiler does not know which locals will be visible on the incoming back-edge. All problems discussed in the following are due to this ignorance of the compiler (we discuss the problems using `BEGIN` loops as examples; the discussion also applies to `?DO` and other loops). Perhaps the most insidious example is:

<div class="example">

``` example
AHEAD
BEGIN
  x
[ 1 CS-ROLL ] THEN
  { x }
  ...
UNTIL
```

</div>

This should be legal according to the visibility rule. The use of `x` can only be reached through the definition; but that appears textually below the use.

From this example it is clear that the visibility rules cannot be fully implemented without major headaches. Our implementation treats common cases as advertised and the exceptions are treated in a safe way: The compiler makes a reasonable guess about the locals visible after a `BEGIN`; if it is too pessimistic, the user will get a spurious error about the local not being defined; if the compiler is too optimistic, it will notice this later and issue a warning. In the case above the compiler would complain about `x` being undefined at its use. You can see from the obscure examples in this section that it takes quite unusual control structures to get the compiler into trouble, and even then it will often do fine.

If the `BEGIN` is reachable from above, the most optimistic guess is that all locals visible before the `BEGIN` will also be visible after the `BEGIN`. This guess is valid for all loops that are entered only through the `BEGIN`, in particular, for normal `BEGIN`...`WHILE`...`REPEAT` and `BEGIN`...`UNTIL` loops and it is implemented in our compiler. When the branch to the `BEGIN` is finally generated by `AGAIN` or `UNTIL`, the compiler checks the guess and warns the user if it was too optimistic:

<div class="example">

``` example
IF
  { x }
BEGIN
  \ x ? 
[ 1 cs-roll ] THEN
  ...
UNTIL
```

</div>

Here, `x` lives only until the `BEGIN`, but the compiler optimistically assumes that it lives until the `THEN`. It notices this difference when it compiles the `UNTIL` and issues a warning. The user can avoid the warning, and make sure that `x` is not used in the wrong area by using explicit scoping:

<div class="example">

``` example
IF
  SCOPE
  { x }
  ENDSCOPE
BEGIN
[ 1 cs-roll ] THEN
  ...
UNTIL
```

</div>

Since the guess is optimistic, there will be no spurious error messages about undefined locals.

If the `BEGIN` is not reachable from above (e.g., after `AHEAD` or `EXIT`), the compiler cannot even make an optimistic guess, as the locals visible after the `BEGIN` may be defined later. Therefore, the compiler assumes that no locals are visible after the `BEGIN`. However, the user can use `ASSUME-LIVE` to make the compiler assume that the same locals are visible at the BEGIN as at the point where the top control-flow stack item was created.

<span id="index-ASSUME_002dLIVE--orig-_002d_002d-orig--gforth"></span> <span id="index-ASSUME_002dLIVE"></span> <span id="index-ASSUME_002dLIVE-1"></span>

<div class="format">

``` format
ASSUME-LIVE       orig – orig         gforth       “ASSUME-LIVE”
```

</div>

E.g.,

<div class="example">

``` example
{ x }
AHEAD
ASSUME-LIVE
BEGIN
  x
[ 1 CS-ROLL ] THEN
  ...
UNTIL
```

</div>

Other cases where the locals are defined before the `BEGIN` can be handled by inserting an appropriate `CS-ROLL` before the `ASSUME-LIVE` (and changing the control-flow stack manipulation behind the `ASSUME-LIVE`).

Cases where locals are defined after the `BEGIN` (but should be visible immediately after the `BEGIN`) can only be handled by rearranging the loop. E.g., the “most insidious” example above can be arranged into:

<div class="example">

``` example
BEGIN
  { x }
  ... 0=
WHILE
  x
REPEAT
```

</div>

<div class="footnote">

-----

#### Footnotes

### [(31)](#DOCF31)

In compiler construction terminology, all places dominated by the definition of the local.

</div>

-----

<div class="header">

Next: [How long do locals live?](How-long-do-locals-live_003f.html#How-long-do-locals-live_003f), Previous: [Gforth locals](Gforth-locals.html#Gforth-locals), Up: [Gforth locals](Gforth-locals.html#Gforth-locals)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
