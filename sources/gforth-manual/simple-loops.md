> Source: https://gforth.org/manual/Simple-Loops.html

<span id="Simple-Loops"></span>

<div class="header">

Next: [Counted Loops](Counted-Loops.html#Counted-Loops), Previous: [Selection](Selection.html#Selection), Up: [Control Structures](Control-Structures.html#Control-Structures)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Simple-Loops-1"></span>

#### 5.8.2 Simple Loops

<span id="index-simple-loops"></span> <span id="index-loops-without-count"></span> <span id="index-WHILE-loop"></span>

<div class="example">

``` example
BEGIN
  code1
  flag
WHILE
  code2
REPEAT
```

</div>

*code1* is executed and *flag* is computed. If it is true, *code2* is executed and the loop is restarted; If *flag* is false, execution continues after the `REPEAT`.

<span id="index-UNTIL-loop"></span>

<div class="example">

``` example
BEGIN
  code
  flag
UNTIL
```

</div>

*code* is executed. The loop is restarted if `flag` is false.

Programming style note: To keep the code understandable, a complete iteration of the loop should not change the number and types of the items on the stacks.

<span id="index-endless-loop"></span> <span id="index-loops_002c-endless"></span>

<div class="example">

``` example
BEGIN
  code
AGAIN
```

</div>

This is an endless loop.
