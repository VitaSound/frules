> Source: https://gforth.org/manual/OS-command-line-arguments.html

<span id="OS-command-line-arguments"></span>

<div class="header">

Next: [Locals](Locals.html#Locals), Previous: [Other I/O](Other-I_002fO.html#Other-I_002fO), Up: [Words](Words.html#Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="OS-command-line-arguments-1"></span>

### 5.20 OS command line arguments

<span id="index-OS-command-line-arguments"></span> <span id="index-command-line-arguments_002c-OS"></span> <span id="index-arguments_002c-OS-command-line"></span>

The usual way to pass arguments to Gforth programs on the command line is via the `-e` option, e.g.

<div class="example">

``` example
gforth -e "123 456" foo.fs -e bye
```

</div>

However, you may want to interpret the command-line arguments directly. In that case, you can access the (image-specific) command-line arguments through `next-arg`:

<span id="index-next_002darg--_002d_002d-addr-u--gforth"></span> <span id="index-next_002darg"></span> <span id="index-next_002darg-1"></span>

<div class="format">

``` format
next-arg       – addr u         gforth       “next-arg”
```

</div>

get the next argument from the OS command line, consuming it; if there is no argument left, return `0 0`.

Here’s an example program `echo.fs` for `next-arg`:

<div class="example">

``` example
: echo ( -- )
    begin
    next-arg 2dup 0 0 d<> while
        type space
    repeat
    2drop ;

echo cr bye
```

</div>

This can be invoked with

<div class="example">

``` example
gforth echo.fs hello world
```

</div>

and it will print

<div class="example">

``` example
hello world
```

</div>

The next lower level of dealing with the OS command line are the following words:

<span id="index-arg--u-_002d_002d-addr-count--gforth"></span> <span id="index-arg"></span> <span id="index-arg-1"></span>

<div class="format">

``` format
arg       u – addr count         gforth       “arg”
```

</div>

Return the string for the *u*th command-line argument; returns `0 0` if the access is beyond the last argument. `0 arg` is the program name with which you started Gforth. The next unprocessed argument is always `1 arg`, the one after that is `2 arg` etc. All arguments already processed by the system are deleted. After you have processed an argument, you can delete it with `shift-args`.

<span id="index-shift_002dargs--_002d_002d--gforth"></span> <span id="index-shift_002dargs"></span> <span id="index-shift_002dargs-1"></span>

<div class="format">

``` format
shift-args       –         gforth       “shift-args”
```

</div>

`1 arg` is deleted, shifting all following OS command line parameters to the left by 1, and reducing `argc @`. This word can change `argv @`.

Finally, at the lowest level Gforth provides the following words:

<span id="index-argc--_002d_002d-addr--gforth"></span> <span id="index-argc"></span> <span id="index-argc-1"></span>

<div class="format">

``` format
argc       – addr         gforth       “argc”
```

</div>

`Variable` – the number of command-line arguments (including the command name). Changed by `next-arg` and `shift-args`.

<span id="index-argv--_002d_002d-addr--gforth"></span> <span id="index-argv"></span> <span id="index-argv-1"></span>

<div class="format">

``` format
argv       – addr         gforth       “argv”
```

</div>

`Variable` – a pointer to a vector of pointers to the command-line arguments (including the command-name). Each argument is represented as a C-style zero-terminated string. Changed by `next-arg` and `shift-args`.

-----

<div class="header">

Next: [Locals](Locals.html#Locals), Previous: [Other I/O](Other-I_002fO.html#Other-I_002fO), Up: [Words](Words.html#Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
