> Source: https://gforth.org/manual/Gforth-in-pipes.html

<span id="Gforth-in-pipes"></span>

<div class="header">

Next: [Startup speed](Startup-speed.html#Startup-speed), Previous: [Gforth Files](Gforth-Files.html#Gforth-Files), Up: [Gforth Environment](Gforth-Environment.html#Gforth-Environment)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Gforth-in-pipes-1"></span>

### 2.6 Gforth in pipes

<span id="index-pipes_002c-Gforth-as-part-of"></span>

Gforth can be used in pipes created elsewhere (described here). It can also create pipes on its own (see [Pipes](Pipes.html#Pipes)).

<span id="index-input-from-pipes"></span>

If you pipe into Gforth, your program should read with `read-file` or `read-line` from `stdin` (see [General files](General-files.html#General-files)). `Key` does not recognize the end of input. Words like `accept` echo the input and are therefore usually not useful for reading from a pipe. You have to invoke the Forth program with an OS command-line option, as you have no chance to use the Forth command line (the text interpreter would try to interpret the pipe input).

<span id="index-output-in-pipes"></span>

You can output to a pipe with `type`, `emit`, `cr` etc.

<span id="index-silent-exiting-from-Gforth"></span>

When you write to a pipe that has been closed at the other end, Gforth receives a SIGPIPE signal (“pipe broken”). Gforth translates this into the exception `broken-pipe-error`. If your application does not catch that exception, the system catches it and exits, usually silently (unless you were working on the Forth command line; then it prints an error message and exits). This is usually the desired behaviour.

If you do not like this behaviour, you have to catch the exception yourself, and react to it.

Here’s an example of an invocation of Gforth that is usable in a pipe:

<div class="example">

``` example
gforth -e ": foo begin pad dup 10 stdin read-file throw dup while \
 type repeat ; foo bye"
```

</div>

This example just copies the input verbatim to the output. A very simple pipe containing this example looks like this:

<div class="example">

``` example
cat startup.fs |
gforth -e ": foo begin pad dup 80 stdin read-file throw dup while \
 type repeat ; foo bye"|
head
```

</div>

<span id="index-stderr-and-pipes"></span>

Pipes involving Gforth’s `stderr` output do not work.

-----

<div class="header">

Next: [Startup speed](Startup-speed.html#Startup-speed), Previous: [Gforth Files](Gforth-Files.html#Gforth-Files), Up: [Gforth Environment](Gforth-Environment.html#Gforth-Environment)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
