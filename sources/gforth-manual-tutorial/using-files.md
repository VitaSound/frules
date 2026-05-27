### 3.7 Using files for Forth code

> Source: https://gforth.org/manual/Using-files-for-Forth-code-Tutorial.html

While working at the Forth command line is convenient for one-line examples and short one-off code, you probably want to store your source code in files for convenient editing and persistence. You can use your favourite editor (Gforth includes Emacs support, see Emacs and Gforth) to create file.fs and use

```
s" file.fs" included
```

to load it into your Forth system. The file name extension I use for Forth files is '.fs'.

You can easily start Gforth with some files loaded like this:

```
gforth file1.fs file2.fs
```

If an error occurs during loading these files, Gforth terminates, whereas an error during `INCLUDED` within Gforth usually gives you a Gforth command line. Starting the Forth system every time gives you a clean start every time, without interference from the results of earlier tries.

I often put all the tests in a file, then load the code and run the tests with

```
gforth code.fs tests.fs -e bye
```

(often by performing this command with C-x C-e in Emacs). The `-e bye` ensures that Gforth terminates afterwards so that I can restart this command without ado.

The advantage of this approach is that the tests can be repeated easily every time the program ist changed, making it easy to catch bugs introduced by the change.

Reference: Forth source files.
