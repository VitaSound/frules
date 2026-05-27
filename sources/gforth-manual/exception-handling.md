> Source: https://gforth.org/manual/Exception-Handling.html

<span id="Exception-Handling"></span>

<div class="header">

Previous: [Calls and returns](Calls-and-returns.html#Calls-and-returns), Up: [Control Structures](Control-Structures.html#Control-Structures)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Exception-Handling-1"></span>

#### 5.8.8 Exception Handling

<span id="index-exceptions"></span>

If a word detects an error condition that it cannot handle, it can `throw` an exception. In the simplest case, this will terminate your program, and report an appropriate error.

<span id="index-throw--y1-_002e_002e-ym-nerror-_002d_002d-y1-_002e_002e-ym-_002f-z1-_002e_002e-zn-error--exception"></span> <span id="index-throw"></span> <span id="index-throw-1"></span>

<div class="format">

``` format
throw       y1 .. ym nerror – y1 .. ym / z1 .. zn error         exception       “throw”
```

</div>

If *nerror* is 0, drop it and continue. Otherwise, transfer control to the next dynamically enclosing exception handler, reset the stacks accordingly, and push *nerror*.

`Throw` consumes a cell-sized error number on the stack. There are some predefined error numbers in Standard Forth (see `errors.fs`). In Gforth (and most other systems) you can use the iors produced by various words as error numbers (e.g., a typical use of `allocate` is `allocate throw`). Gforth also provides the word `exception` to define your own error numbers (with decent error reporting); a Standard Forth version of this word (but without the error messages) is available in `compat/except.fs`. And finally, you can use your own error numbers (anything outside the range -4095..0), but won’t get nice error messages, only numbers. For example, try:

<div class="example">

``` example
-10 throw                    \ Standard defined
-267 throw                   \ system defined
s" my error" exception throw \ user defined
7 throw                      \ arbitrary number
```

</div>

<span id="index-exception--addr-u-_002d_002d-n--gforth"></span> <span id="index-exception"></span> <span id="index-exception-1"></span>

<div class="format">

``` format
exception       addr u – n         gforth       “exception”
```

</div>

`n` is a previously unused `throw` value in the range (-4095...-256). Consecutive calls to `exception` return consecutive decreasing numbers. Gforth uses the string `addr u` as an error message.

A common idiom to `THROW` a specific error if a flag is true is this:

<div class="example">

``` example
( flag ) 0<> errno and throw
```

</div>

Your program can provide exception handlers to catch exceptions. An exception handler can be used to correct the problem, or to clean up some data structures and just throw the exception to the next exception handler. Note that `throw` jumps to the dynamically innermost exception handler. The system’s exception handler is outermost, and just prints an error and restarts command-line interpretation (or, in batch mode (i.e., while processing the shell command line), leaves Gforth).

The Standard Forth way to catch exceptions is `catch`:

<span id="index-catch--_002e_002e_002e-xt-_002d_002d-_002e_002e_002e-n--exception"></span> <span id="index-catch"></span> <span id="index-catch-1"></span>

<div class="format">

``` format
catch       ... xt – ... n         exception       “catch”
```

</div>

<span id="index-nothrow--_002d_002d--gforth"></span> <span id="index-nothrow"></span> <span id="index-nothrow-1"></span>

<div class="format">

``` format
nothrow       –         gforth       “nothrow”
```

</div>

Use this (or the standard sequence `['] false catch 2drop`) after a `catch` or `endtry` that does not rethrow; this ensures that the next `throw` will record a backtrace.

The most common use of exception handlers is to clean up the state when an error happens. E.g.,

<div class="example">

``` example
base @ >r hex \ actually the HEX should be inside foo to protect
              \ against exceptions between HEX and CATCH
['] foo catch ( nerror|0 )
r> base !
( nerror|0 ) throw \ pass it on
```

</div>

A use of `catch` for handling the error `myerror` might look like this:

<div class="example">

``` example
['] foo catch
CASE
  myerror OF ... ( do something about it ) nothrow ENDOF
  dup throw \ default: pass other errors on, do nothing on non-errors
ENDCASE
```

</div>

Having to wrap the code into a separate word is often cumbersome, therefore Gforth provides an alternative syntax:

<div class="example">

``` example
TRY
  code1
  IFERROR
    code2
  THEN
  code3
ENDTRY
```

</div>

This performs *code1*. If *code1* completes normally, execution continues with *code3*. If there is an exception in *code1* or before `endtry`, the stacks are reset to the depth during `try`, the throw value is pushed on the data stack, and execution continues at *code2*, and finally falls through to *code3*.

<span id="index-try--compilation-_002d_002d-orig-_003b-run_002dtime-_002d_002d-R_003asys1--gforth"></span> <span id="index-try"></span> <span id="index-try-1"></span>

<div class="format">

``` format
try       compilation  – orig ; run-time  – R:sys1         gforth       “try”
```

</div>

Start an exception-catching region.

<span id="index-endtry--compilation-_002d_002d-_003b-run_002dtime-R_003asys1-_002d_002d--gforth"></span> <span id="index-endtry"></span> <span id="index-endtry-1"></span>

<div class="format">

``` format
endtry       compilation  – ; run-time  R:sys1 –         gforth       “endtry”
```

</div>

End an exception-catching region.

<span id="index-iferror--compilation-orig1-_002d_002d-orig2-_003b-run_002dtime-_002d_002d--gforth"></span> <span id="index-iferror"></span> <span id="index-iferror-1"></span>

<div class="format">

``` format
iferror       compilation  orig1 – orig2 ; run-time  –         gforth       “iferror”
```

</div>

Starts the exception handling code (executed if there is an exception between `try` and `endtry`). This part has to be finished with `then`.

If you don’t need *code2*, you can write `restore` instead of `iferror then`:

<div class="example">

``` example
TRY
  code1
RESTORE
  code3
ENDTRY
```

</div>

<span id="index-unwind_002dprotect"></span>

The cleanup example from above in this syntax:

<div class="example">

``` example
base @ { oldbase }
TRY
  hex foo \ now the hex is placed correctly
  0       \ value for throw
RESTORE
  oldbase base !
ENDTRY
throw
```

</div>

An additional advantage of this variant is that an exception between `restore` and `endtry` (e.g., from the user pressing <span class="kbd">Ctrl-C</span>) restarts the execution of the code after `restore`, so the base will be restored under all circumstances.

However, you have to ensure that this code does not cause an exception itself, otherwise the `iferror`/`restore` code will loop. Moreover, you should also make sure that the stack contents needed by the `iferror`/`restore` code exist everywhere between `try` and `endtry`; in our example this is achived by putting the data in a local before the `try` (you cannot use the return stack because the exception frame (*sys1*) is in the way there).

This kind of usage corresponds to Lisp’s `unwind-protect`.

<span id="index-recover-_0028old-Gforth-versions_0029"></span>

If you do not want this exception-restarting behaviour, you achieve this as follows:

<div class="example">

``` example
TRY
  code1
ENDTRY-IFERROR
  code2
THEN
```

</div>

If there is an exception in *code1*, then *code2* is executed, otherwise execution continues behind the `then` (or in a possible `else` branch). This corresponds to the construct

<div class="example">

``` example
TRY
  code1
RECOVER
  code2
ENDTRY
```

</div>

in Gforth before version 0.7. So you can directly replace `recover`-using code; however, we recommend that you check if it would not be better to use one of the other `try` variants while you are at it.

To ease the transition, Gforth provides two compatibility files: `endtry-iferror.fs` provides the `try ... endtry-iferror ... then` syntax (but not `iferror` or `restore`) for old systems; `recover-endtry.fs` provides the `try ... recover ... endtry` syntax on new systems, so you can use that file as a stopgap to run old programs. Both files work on any system (they just do nothing if the system already has the syntax it implements), so you can unconditionally `require` one of these files, even if you use a mix old and new systems.

<span id="index-restore--compilation-orig1-_002d_002d-_003b-run_002dtime-_002d_002d--gforth"></span> <span id="index-restore"></span> <span id="index-restore-1"></span>

<div class="format">

``` format
restore       compilation  orig1 – ; run-time  –         gforth       “restore”
```

</div>

Starts restoring code, that is executed if there is an exception, and if there is no exception.

<span id="index-endtry_002diferror--compilation-orig1-_002d_002d-orig2-_003b-run_002dtime-R_003asys1-_002d_002d--gforth"></span> <span id="index-endtry_002diferror"></span> <span id="index-endtry_002diferror-1"></span>

<div class="format">

``` format
endtry-iferror       compilation  orig1 – orig2 ; run-time  R:sys1 –         gforth       “endtry-iferror”
```

</div>

End an exception-catching region while starting exception-handling code outside that region (executed if there is an exception between `try` and `endtry-iferror`). This part has to be finished with `then` (or `else`...`then`).

Here’s the error handling example:

<div class="example">

``` example
TRY
  foo
ENDTRY-IFERROR
  CASE
    myerror OF ... ( do something about it ) nothrow ENDOF
    throw \ pass other errors on
  ENDCASE
THEN
```

</div>

Programming style note: As usual, you should ensure that the stack depth is statically known at the end: either after the `throw` for passing on errors, or after the `ENDTRY` (or, if you use `catch`, after the end of the selection construct for handling the error).

There are two alternatives to `throw`: `Abort"` is conditional and you can provide an error message. `Abort` just produces an “Aborted” error.

The problem with these words is that exception handlers cannot differentiate between different `abort"`s; they just look like `-2 throw` to them (the error message cannot be accessed by standard programs). Similar `abort` looks like `-1 throw` to exception handlers.

<span id="index-ABORT_0022--compilation-_0027ccc_0022_0027-_002d_002d-_003b-run_002dtime-f-_002d_002d--core_002cexception_002dext"></span> <span id="index-ABORT_0022"></span> <span id="index-ABORT_0022-1"></span>

<div class="format">

``` format
ABORT"       compilation ’ccc"’ – ; run-time f –         core,exception-ext       “abort-quote”
```

</div>

If any bit of *f* is non-zero, perform the function of `-2 throw`, displaying the string *ccc* if there is no exception frame on the exception stack.

<span id="index-abort--_003f_003f-_002d_002d-_003f_003f--core_002cexception_002dext"></span> <span id="index-abort"></span> <span id="index-abort-1"></span>

<div class="format">

``` format
abort       ?? – ??         core,exception-ext       “abort”
```

</div>

`-1 throw`.

For problems that are not that awful that you need to abort execution, you can just display a warning. The variable `warnings` allows to tune how many warnings you see.

<span id="index-WARNING_0022--compilation-_0027ccc_0022_0027-_002d_002d-_003b-run_002dtime-f-_002d_002d--gforth"></span> <span id="index-WARNING_0022"></span> <span id="index-WARNING_0022-1"></span>

<div class="format">

``` format
WARNING"       compilation ’ccc"’ – ; run-time f –         gforth       “WARNING"”
```

</div>

if *f* is non-zero, display the string *ccc* as warning message.

<span id="index-warnings--_002d_002d-addr--gforth"></span> <span id="index-warnings"></span> <span id="index-warnings-1"></span>

<div class="format">

``` format
warnings       – addr         gforth       “warnings”
```

</div>

set warnings level to

  - `0`  
    turns warnings off

  - `-1`  
    turns normal warnings on

  - `-2`  
    turns beginner warnngs on

  - `-3`  
    pedantic warnings on

  - `-4`  
    turns warnings into errors (including beginner warnings)

-----

<div class="header">

Previous: [Calls and returns](Calls-and-returns.html#Calls-and-returns), Up: [Control Structures](Control-Structures.html#Control-Structures)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
