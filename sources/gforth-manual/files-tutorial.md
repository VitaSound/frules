> Source: https://gforth.org/manual/Files-Tutorial.html

<span id="Files-Tutorial"></span>

<div class="header">

Next: [Interpretation and Compilation Semantics and Immediacy Tutorial](Interpretation-and-Compilation-Semantics-and-Immediacy-Tutorial.html#Interpretation-and-Compilation-Semantics-and-Immediacy-Tutorial), Previous: [Floating Point Tutorial](Floating-Point-Tutorial.html#Floating-Point-Tutorial), Up: [Tutorial](Tutorial.html#Tutorial)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Files-1"></span>

### 3.27 Files

<span id="index-files-tutorial"></span>

This section gives a short introduction into how to use files inside Forth. It’s broken up into five easy steps:

1.  Open an ASCII text file for input
2.  Open a file for output
3.  Read input file until string matches (or some other condition is met)
4.  Write some lines from input (modified or not) to output
5.  Close the files.

Reference: [General files](General-files.html#General-files).

<span id="Open-file-for-input"></span>

#### 3.27.1 Open file for input

<div class="example">

``` example
s" foo.in"  r/o open-file throw Value fd-in
```

</div>

<span id="Create-file-for-output"></span>

#### 3.27.2 Create file for output

<div class="example">

``` example
s" foo.out" w/o create-file throw Value fd-out
```

</div>

The available file modes are r/o for read-only access, r/w for read-write access, and w/o for write-only access. You could open both files with r/w, too, if you like. All file words return error codes; for most applications, it’s best to pass there error codes with `throw` to the outer error handler.

If you want words for opening and assigning, define them as follows:

<div class="example">

``` example
0 Value fd-in
0 Value fd-out
: open-input ( addr u -- )  r/o open-file throw to fd-in ;
: open-output ( addr u -- )  w/o create-file throw to fd-out ;
```

</div>

Usage example:

<div class="example">

``` example
s" foo.in" open-input
s" foo.out" open-output
```

</div>

<span id="Scan-file-for-a-particular-line"></span>

#### 3.27.3 Scan file for a particular line

<div class="example">

``` example
256 Constant max-line
Create line-buffer  max-line 2 + allot

: scan-file ( addr u -- )
  begin
      line-buffer max-line fd-in read-line throw
  while
         >r 2dup line-buffer r> compare 0=
     until
  else
     drop
  then
  2drop ;
```

</div>

`read-line ( addr u1 fd -- u2 flag ior )` reads up to u1 bytes into the buffer at addr, and returns the number of bytes read, a flag that is false when the end of file is reached, and an error code.

`compare ( addr1 u1 addr2 u2 -- n )` compares two strings and returns zero if both strings are equal. It returns a positive number if the first string is lexically greater, a negative if the second string is lexically greater.

We haven’t seen this loop here; it has two exits. Since the `while` exits with the number of bytes read on the stack, we have to clean up that separately; that’s after the `else`.

Usage example:

<div class="example">

``` example
s" The text I search is here" scan-file
```

</div>

<span id="Copy-input-to-output"></span>

#### 3.27.4 Copy input to output

<div class="example">

``` example
: copy-file ( -- )
  begin
      line-buffer max-line fd-in read-line throw
  while
      line-buffer swap fd-out write-line throw
  repeat 
  drop ;
```

</div>

<span id="Close-files"></span>

#### 3.27.5 Close files

<div class="example">

``` example
fd-in close-file throw
fd-out close-file throw
```

</div>

Likewise, you can put that into definitions, too:

<div class="example">

``` example
: close-input ( -- )  fd-in close-file throw ;
: close-output ( -- )  fd-out close-file throw ;
```

</div>

> **Assignment:** How could you modify `copy-file` so that it copies until a second line is matched? Can you write a program that extracts a section of a text file, given the line that starts and the line that terminates that section?

-----

<div class="header">

Next: [Interpretation and Compilation Semantics and Immediacy Tutorial](Interpretation-and-Compilation-Semantics-and-Immediacy-Tutorial.html#Interpretation-and-Compilation-Semantics-and-Immediacy-Tutorial), Previous: [Floating Point Tutorial](Floating-Point-Tutorial.html#Floating-Point-Tutorial), Up: [Tutorial](Tutorial.html#Tutorial)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
