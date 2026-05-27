> Source: https://gforth.org/manual/Const_002ddoes_003e.html

<span id="Const_002ddoes_003e"></span>

<div class="header">

Previous: [Advanced does\> usage example](Advanced-does_003e-usage-example.html#Advanced-does_003e-usage-example), Up: [User-defined Defining Words](User_002ddefined-Defining-Words.html#User_002ddefined-Defining-Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Const_002ddoes_003e-1"></span>

#### 5.9.9.4 `Const-does>`

A frequent use of `create`...`does>` is for transferring some values from definition-time to run-time. Gforth supports this use with

<span id="index-const_002ddoes_003e--run_002dtime_003a-w_002auw-r_002aur-uw-ur-_0022name_0022-_002d_002d--gforth"></span> <span id="index-const_002ddoes_003e"></span> <span id="index-const_002ddoes_003e-1"></span>

<div class="format">

``` format
const-does>       run-time: w*uw r*ur uw ur "name" –         gforth       “const-does>”
```

</div>

Defines `name` and returns.

`name` execution: pushes `w*uw r*ur`, then performs the code following the `const-does>`.

A typical use of this word is:

<div class="example">

``` example
: curry+ ( n1 "name" -- )
1 0 CONST-DOES> ( n2 -- n1+n2 )
    + ;

3 curry+ 3+
```

</div>

Here the `1 0` means that 1 cell and 0 floats are transferred from definition to run-time.

The advantages of using `const-does>` are:

  - You don’t have to deal with storing and retrieving the values, i.e., your program becomes more writable and readable.
  - When using `does>`, you have to introduce a `@` that cannot be optimized away (because you could change the data using `>body`...`!`); `const-does>` avoids this problem.

A Standard Forth implementation of `const-does>` is available in `compat/const-does.fs`.
