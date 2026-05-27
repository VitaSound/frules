> Source: https://gforth.org/manual/Constants.html

<span id="Constants"></span>

<div class="header">

Next: [Values](Values.html#Values), Previous: [Variables](Variables.html#Variables), Up: [Defining Words](Defining-Words.html#Defining-Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Constants-1"></span>

#### 5.9.3 Constants

<span id="index-constants"></span>

`Constant` allows you to declare a fixed value and refer to it by name. For example:

<div class="example">

``` example
12 Constant INCHES-PER-FOOT
3E+08 fconstant SPEED-O-LIGHT
```

</div>

A `Variable` can be both read and written, so its run-time behaviour is to supply an address through which its current value can be manipulated. In contrast, the value of a `Constant` cannot be changed once it has been declared[<sup>14</sup>](#FOOT14) so it’s not necessary to supply the address – it is more efficient to return the value of the constant directly. That’s exactly what happens; the run-time effect of a constant is to put its value on the top of the stack (You can find one way of implementing `Constant` in [User-defined Defining Words](User_002ddefined-Defining-Words.html#User_002ddefined-Defining-Words)).

Forth also provides `2Constant` and `fconstant` for defining double and floating-point constants, respectively.

<span id="index-Constant--w-_0022name_0022-_002d_002d--core"></span> <span id="index-Constant"></span> <span id="index-Constant-1"></span>

<div class="format">

``` format
Constant       w "name" –         core       “Constant”
```

</div>

Define a constant *name* with value *w*.

*name* execution: *– w*

<span id="index-2Constant--w1-w2-_0022name_0022-_002d_002d--double"></span> <span id="index-2Constant"></span> <span id="index-2Constant-1"></span>

<div class="format">

``` format
2Constant       w1 w2 "name" –         double       “two-constant”
```

</div>

<span id="index-fconstant--r-_0022name_0022-_002d_002d--float"></span> <span id="index-fconstant"></span> <span id="index-fconstant-1"></span>

<div class="format">

``` format
fconstant       r "name" –         float       “f-constant”
```

</div>

Constants in Forth behave differently from their equivalents in other programming languages. In other languages, a constant (such as an EQU in assembler or a \#define in C) only exists at compile-time; in the executable program the constant has been translated into an absolute number and, unless you are using a symbolic debugger, it’s impossible to know what abstract thing that number represents. In Forth a constant has an entry in the header space and remains there after the code that uses it has been defined. In fact, it must remain in the dictionary since it has run-time duties to perform. For example:

<div class="example">

``` example
12 Constant INCHES-PER-FOOT
: FEET-TO-INCHES ( n1 -- n2 ) INCHES-PER-FOOT * ;
```

</div>

<span id="index-in_002dlining-of-constants"></span>

When `FEET-TO-INCHES` is executed, it will in turn execute the xt associated with the constant `INCHES-PER-FOOT`. If you use `see` to decompile the definition of `FEET-TO-INCHES`, you can see that it makes a call to `INCHES-PER-FOOT`. Some Forth compilers attempt to optimise constants by in-lining them where they are used. You can force Gforth to in-line a constant like this:

<div class="example">

``` example
: FEET-TO-INCHES ( n1 -- n2 ) [ INCHES-PER-FOOT ] LITERAL * ;
```

</div>

If you use `see` to decompile *this* version of `FEET-TO-INCHES`, you can see that `INCHES-PER-FOOT` is no longer present. To understand how this works, read [Interpret/Compile states](Interpret_002fCompile-states.html#Interpret_002fCompile-states), and [Literals](Literals.html#Literals).

In-lining constants in this way might improve execution time fractionally, and can ensure that a constant is now only referenced at compile-time. However, the definition of the constant still remains in the dictionary. Some Forth compilers provide a mechanism for controlling a second dictionary for holding transient words such that this second dictionary can be deleted later in order to recover memory space. However, there is no standard way of doing this.

<div class="footnote">

-----

#### Footnotes

### [(14)](#DOCF14)

Well, often it can be – but not in a Standard, portable way. It’s safer to use a `Value` (read on).

</div>

-----

<div class="header">

Next: [Values](Values.html#Values), Previous: [Variables](Variables.html#Variables), Up: [Defining Words](Defining-Words.html#Defining-Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
