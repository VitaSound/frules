> Source: https://gforth.org/manual/Calling-C-Functions.html

<span id="Calling-C-Functions"></span>

<div class="header">

Next: [Declaring C Functions](Declaring-C-Functions.html#Declaring-C-Functions), Previous: [C Interface](C-Interface.html#C-Interface), Up: [C Interface](C-Interface.html#C-Interface)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Calling-C-functions"></span>

#### 5.26.1 Calling C functions

<span id="index-C-functions_002c-calls-to"></span> <span id="index-calling-C-functions"></span>

Once a C function is declared (see see [Declaring C Functions](Declaring-C-Functions.html#Declaring-C-Functions)), you can call it as follows: You push the arguments on the stack(s), and then call the word for the C function. The arguments have to be pushed in the same order as the arguments appear in the C documentation (i.e., the first argument is deepest on the stack). Integer and pointer arguments have to be pushed on the data stack, floating-point arguments on the FP stack; these arguments are consumed by the called C function.

On returning from the C function, the return value, if any, resides on the appropriate stack: an integer return value is pushed on the data stack, an FP return value on the FP stack, and a void return value results in not pushing anything. Note that most C functions have a return value, even if that is often not used in C; in Forth, you have to `drop` this return value explicitly if you do not use it.

The C interface automatically converts between the C type and the Forth type as necessary, on a best-effort basis (in some cases, there may be some loss).

As an example, consider the POSIX function `lseek()`:

<div class="example">

``` example
off_t lseek(int fd, off_t offset, int whence);
```

</div>

This function takes three integer arguments, and returns an integer argument, so a Forth call for setting the current file offset to the start of the file could look like this:

<div class="example">

``` example
fd @ 0 SEEK_SET lseek -1 = if
  ... \ error handling
then
```

</div>

You might be worried that an `off_t` does not fit into a cell, so you could not pass larger offsets to lseek, and might get only a part of the return values. In that case, in your declaration of the function (see [Declaring C Functions](Declaring-C-Functions.html#Declaring-C-Functions)) you should declare it to use double-cells for the off\_t argument and return value, and maybe give the resulting Forth word a different name, like `dlseek`; the result could be called like this:

<div class="example">

``` example
fd @ 0. SEEK_SET dlseek -1. d= if
  ... \ error handling
then
```

</div>

Passing and returning structs or unions is currently not supported by our interface[<sup>36</sup>](#FOOT36).

Calling functions with a variable number of arguments (*variadic* functions, e.g., `printf()`) is only supported by having you declare one function-calling word for each argument pattern, and calling the appropriate word for the desired pattern.

<div class="footnote">

-----

#### Footnotes

### [(36)](#DOCF36)

If you know the calling convention of your C compiler, you usually can call such functions in some way, but that way is usually not portable between platforms, and sometimes not even between C compilers.

</div>

-----

<div class="header">

Next: [Declaring C Functions](Declaring-C-Functions.html#Declaring-C-Functions), Previous: [C Interface](C-Interface.html#C-Interface), Up: [C Interface](C-Interface.html#C-Interface)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
