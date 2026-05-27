> Source: https://gforth.org/manual/Counted-Loops.html

<span id="Counted-Loops"></span>

<div class="header">

Next: [BEGIN loops with multiple exits](BEGIN-loops-with-multiple-exits.html#BEGIN-loops-with-multiple-exits), Previous: [Simple Loops](Simple-Loops.html#Simple-Loops), Up: [Control Structures](Control-Structures.html#Control-Structures)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Counted-Loops-1"></span>

#### 5.8.3 Counted Loops

<span id="index-counted-loops"></span> <span id="index-loops_002c-counted"></span> <span id="index-DO-loops"></span>

The basic counted loop is:

<div class="example">

``` example
limit start
?DO
  body
LOOP
```

</div>

This performs one iteration for every integer, starting from *start* and up to, but excluding *limit*. The counter, or *index*, can be accessed with `i`. For example, the loop:

<div class="example">

``` example
10 0 ?DO
  i .
LOOP
```

</div>

prints `0 1 2 3 4 5 6 7 8 9`

The index of the innermost loop can be accessed with `i`, the index of the next loop with `j`, and the index of the third loop with `k`.

<span id="index-i--R_003an-_002d_002d-R_003an-n--core"></span> <span id="index-i"></span> <span id="index-i-1"></span>

<div class="format">

``` format
i       R:n – R:n n        core       “i”
```

</div>

<span id="index-j--R_003aw-R_003aw1-R_003aw2-_002d_002d-w-R_003aw-R_003aw1-R_003aw2--core"></span> <span id="index-j"></span> <span id="index-j-1"></span>

<div class="format">

``` format
j       R:w R:w1 R:w2 – w R:w R:w1 R:w2        core       “j”
```

</div>

<span id="index-k--R_003aw-R_003aw1-R_003aw2-R_003aw3-R_003aw4-_002d_002d-w-R_003aw-R_003aw1-R_003aw2-R_003aw3-R_003aw4--gforth"></span> <span id="index-k"></span> <span id="index-k-1"></span>

<div class="format">

``` format
k       R:w R:w1 R:w2 R:w3 R:w4 – w R:w R:w1 R:w2 R:w3 R:w4        gforth       “k”
```

</div>

The loop control data are kept on the return stack, so there are some restrictions on mixing return stack accesses and counted loop words. In particuler, if you put values on the return stack outside the loop, you cannot read them inside the loop[<sup>12</sup>](#FOOT12). If you put values on the return stack within a loop, you have to remove them before the end of the loop and before accessing the index of the loop.

There are several variations on the counted loop:

  - `LEAVE` leaves the innermost counted loop immediately; execution continues after the associated `LOOP` or `NEXT`. For example:
    
    <div class="example">
    
    ``` example
    10 0 ?DO  i DUP . 3 = IF LEAVE THEN LOOP
    ```
    
    </div>
    
    prints `0 1 2 3`

  - `UNLOOP` prepares for an abnormal loop exit, e.g., via `EXIT`. `UNLOOP` removes the loop control parameters from the return stack so `EXIT` can get to its return address. For example:
    
    <div class="example">
    
    ``` example
    : demo 10 0 ?DO i DUP . 3 = IF UNLOOP EXIT THEN LOOP ." Done" ;
    ```
    
    </div>
    
    prints `0 1 2 3`

  - If *start* is greater than *limit*, a `?DO` loop is entered (and `LOOP` iterates until they become equal by wrap-around arithmetic). This behaviour is usually not what you want. Therefore, Gforth offers `+DO` and `U+DO` (as replacements for `?DO`), which do not enter the loop if *start* is greater than *limit*; `+DO` is for signed loop parameters, `U+DO` for unsigned loop parameters.

  - `?DO` can be replaced by `DO`. `DO` always enters the loop, independent of the loop parameters. Do not use `DO`, even if you know that the loop is entered in any case. Such knowledge tends to become invalid during maintenance of a program, and then the `DO` will make trouble.

  - `LOOP` can be replaced with `n +LOOP`; this updates the index by *n* instead of by 1. The loop is terminated when the border between *limit-1* and *limit* is crossed. E.g.:
    
    <div class="example">
    
    ``` example
    4 0 +DO  i .  2 +LOOP
    ```
    
    </div>
    
    prints `0 2`
    
    <div class="example">
    
    ``` example
    4 1 +DO  i .  2 +LOOP
    ```
    
    </div>
    
    prints `1 3`

  - <span id="index-negative-increment-for-counted-loops"></span> <span id="index-counted-loops-with-negative-increment"></span> The behaviour of `n +LOOP` is peculiar when *n* is negative:
    
    <div class="example">
    
    ``` example
    -1 0 ?DO  i .  -1 +LOOP
    ```
    
    </div>
    
    prints `0 -1`
    
    <div class="example">
    
    ``` example
    0 0 ?DO  i .  -1 +LOOP
    ```
    
    </div>
    
    prints nothing.
    
    Therefore we recommend avoiding `n +LOOP` with negative *n*. One alternative is `u -LOOP`, which reduces the index by *u* each iteration. The loop is terminated when the border between *limit+1* and *limit* is crossed. Gforth also provides `-DO` and `U-DO` for down-counting loops. E.g.:
    
    <div class="example">
    
    ``` example
    -2 0 -DO  i .  1 -LOOP
    ```
    
    </div>
    
    prints `0 -1`
    
    <div class="example">
    
    ``` example
    -1 0 -DO  i .  1 -LOOP
    ```
    
    </div>
    
    prints `0`
    
    <div class="example">
    
    ``` example
    0 0 -DO  i .  1 -LOOP
    ```
    
    </div>
    
    prints nothing.

Unfortunately, `+DO`, `U+DO`, `-DO`, `U-DO` and `-LOOP` are not defined in Standard Forth. However, an implementation for these words that uses only standard words is provided in `compat/loops.fs`.

<span id="index-FOR-loops"></span>

Another counted loop is:

<div class="example">

``` example
n
FOR
  body
NEXT
```

</div>

This is the preferred loop of native code compiler writers who are too lazy to optimize `?DO` loops properly. This loop structure is not defined in Standard Forth. In Gforth, this loop iterates *n+1* times; `i` produces values starting with *n* and ending with 0. Other Forth systems may behave differently, even if they support `FOR` loops. To avoid problems, don’t use `FOR` loops.

<div class="footnote">

-----

#### Footnotes

### [(12)](#DOCF12)

well, not in a way that is portable.

</div>

-----

<div class="header">

Next: [BEGIN loops with multiple exits](BEGIN-loops-with-multiple-exits.html#BEGIN-loops-with-multiple-exits), Previous: [Simple Loops](Simple-Loops.html#Simple-Loops), Up: [Control Structures](Control-Structures.html#Control-Structures)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
