> Source: https://gforth.org/manual/BEGIN-loops-with-multiple-exits.html

<span id="BEGIN-loops-with-multiple-exits"></span>

<div class="header">

Next: [General control structures with CASE](General-control-structures-with-CASE.html#General-control-structures-with-CASE), Previous: [Counted Loops](Counted-Loops.html#Counted-Loops), Up: [Control Structures](Control-Structures.html#Control-Structures)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Begin-loops-with-multiple-exits"></span>

#### 5.8.4 `Begin` loops with multiple exits

<span id="index-Multiple-exits-from-begin"></span>

For counted loops, you can use `leave` in several places. For `begin` loops, you have the following options:

Use `exit` (possibly several times) in the loop to leave not just the loop, but the whole colon definition. E.g.,:

<div class="example">

``` example
: foo
  begin
    condition1 while
      condition2 if
        exit-code2 exit then
      condition3 if
        exit-code3 exit then
    ...
  repeat
  exit-code1 ;
```

</div>

The disadvantage of this approach is that, if you want to have some common code afterwards, you either have to wrap `foo` in another word that contains the common code, or you have to call the common code several times, from each exit-code.

Another approach is to use several `while`s in a `begin` loop. You have to append a `then` behind the loop for every additional `while`. E.g.,;

<div class="example">

``` example
begin
  condition1 while
    condition2 while
      condition3 while
again then then then
```

</div>

Here I used `again` at the end of the loop so that I would have a `then` for each `while`; `repeat` would result in one less `then`, but otherwise the same behaviour. For an explanation of why this works, See [Arbitrary control structures](Arbitrary-control-structures.html#Arbitrary-control-structures).

We can have common code afterwards, but, as presented above, we cannot have different exit-codes for the different exits. You can have these different exit-codes, as follows:

<div class="example">

``` example
begin
  condition1 while
    condition2 while
      condition3 while
again then exit-code3
else exit-code2 then
else exit-code1 then
```

</div>

This is relatively hard to comprehend, because the exit-codes are relatively far from the exit conditions (it does not help that we are not used to such control structures, either).

-----

<div class="header">

Next: [General control structures with CASE](General-control-structures-with-CASE.html#General-control-structures-with-CASE), Previous: [Counted Loops](Counted-Loops.html#Counted-Loops), Up: [Control Structures](Control-Structures.html#Control-Structures)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
