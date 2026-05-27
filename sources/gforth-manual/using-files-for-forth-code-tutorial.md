> Source: https://gforth.org/manual/Using-files-for-Forth-code-Tutorial.html

<span id="Using-files-for-Forth-code-Tutorial"></span>

<div class="header">

Next: [Comments Tutorial](Comments-Tutorial.html#Comments-Tutorial), Previous: [Stack Manipulation Tutorial](Stack-Manipulation-Tutorial.html#Stack-Manipulation-Tutorial), Up: [Tutorial](Tutorial.html#Tutorial)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Using-files-for-Forth-code"></span>

### 3.7 Using files for Forth code

<span id="index-loading-Forth-code_002c-tutorial"></span> <span id="index-files-containing-Forth-code_002c-tutorial"></span>

While working at the Forth command line is convenient for one-line examples and short one-off code, you probably want to store your source code in files for convenient editing and persistence. You can use your favourite editor (Gforth includes Emacs support, see [Emacs and Gforth](Emacs-and-Gforth.html#Emacs-and-Gforth)) to create `file.fs` and use

<div class="example">

``` example
s" file.fs" included
```

</div>

to load it into your Forth system. The file name extension I use for Forth files is ‘`.fs`’.

You can easily start Gforth with some files loaded like this:

<div class="example">

``` example
gforth file1.fs file2.fs
```

</div>

If an error occurs during loading these files, Gforth terminates, whereas an error during `INCLUDED` within Gforth usually gives you a Gforth command line. Starting the Forth system every time gives you a clean start every time, without interference from the results of earlier tries.

I often put all the tests in a file, then load the code and run the tests with

<div class="example">

``` example
gforth code.fs tests.fs -e bye
```

</div>

(often by performing this command with <span class="kbd">C-x C-e</span> in Emacs). The `-e bye` ensures that Gforth terminates afterwards so that I can restart this command without ado.

The advantage of this approach is that the tests can be repeated easily every time the program ist changed, making it easy to catch bugs introduced by the change.

Reference: [Forth source files](Forth-source-files.html#Forth-source-files).
