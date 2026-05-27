> Source: https://gforth.org/manual/Error-messages.html

<span id="Error-messages"></span>

<div class="header">

Next: [Tools](Tools.html#Tools), Previous: [Words](Words.html#Words), Up: [Top](index.html#Top)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Error-messages-1"></span>

## 6 Error messages

<span id="index-error-messages"></span> <span id="index-backtrace"></span>

A typical Gforth error message looks like this:

<div class="example">

``` example
in file included from \evaluated string/:-1
in file included from ./yyy.fs:1
./xxx.fs:4: Invalid memory address
>>>bar<<<
Backtrace:
$400E664C @
$400E6664 foo
```

</div>

The message identifying the error is `Invalid memory address`. The error happened when text-interpreting line 4 of the file `./xxx.fs`. This line is given (it contains `bar`), and the word on the line where the error happened, is pointed out (with `>>>` and `<<<`).

The file containing the error was included in line 1 of `./yyy.fs`, and `yyy.fs` was included from a non-file (in this case, by giving `yyy.fs` as command-line parameter to Gforth).

At the end of the error message you find a return stack dump that can be interpreted as a backtrace (possibly empty). On top you find the top of the return stack when the `throw` happened, and at the bottom you find the return stack entry just above the return stack of the topmost text interpreter.

To the right of most return stack entries you see a guess for the word that pushed that return stack entry as its return address. This gives a backtrace. In our case we see that `bar` called `foo`, and `foo` called `@` (and `@` had an *Invalid memory address* exception).

Note that the backtrace is not perfect: We don’t know which return stack entries are return addresses (so we may get false positives); and in some cases (e.g., for `abort"`) we cannot determine from the return address the word that pushed the return address, so for some return addresses you see no names in the return stack dump.

<span id="index-catch-and-backtraces"></span>

The return stack dump represents the return stack at the time when a specific `throw` was executed. In programs that make use of `catch`, it is not necessarily clear which `throw` should be used for the return stack dump (e.g., consider one `throw` that indicates an error, which is caught, and during recovery another error happens; which `throw` should be used for the stack dump?). Gforth presents the return stack dump for the first `throw` after the last executed (not returned-to) `catch` or `nothrow`; this works well in the usual case. To get the right backtrace, you usually want to insert `nothrow` or `['] false catch 2drop` after a `catch` if the error is not rethrown.

<span id="index-gforth_002dfast-and-backtraces"></span> <span id="index-gforth_002dfast_002c-difference-from-gforth"></span> <span id="index-backtraces-with-gforth_002dfast"></span> <span id="index-return-stack-dump-with-gforth_002dfast"></span>

`Gforth` is able to do a return stack dump for throws generated from primitives (e.g., invalid memory address, stack empty etc.); `gforth-fast` is only able to do a return stack dump from a directly called `throw` (including `abort` etc.). Given an exception caused by a primitive in `gforth-fast`, you will typically see no return stack dump at all; however, if the exception is caught by `catch` (e.g., for restoring some state), and then `throw`n again, the return stack dump will be for the first such `throw`.

-----

<div class="header">

Next: [Tools](Tools.html#Tools), Previous: [Words](Words.html#Words), Up: [Top](index.html#Top)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
