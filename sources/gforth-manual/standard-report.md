> Source: https://gforth.org/manual/Standard-Report.html

<span id="Standard-Report"></span>

<div class="header">

Next: [Stack depth changes](Stack-depth-changes.html#Stack-depth-changes), Previous: [Tools](Tools.html#Tools), Up: [Tools](Tools.html#Tools)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="ans_002dreport_002efs_003a-Report-the-words-used_002c-sorted-by-wordset"></span>

### 7.1 `ans-report.fs`: Report the words used, sorted by wordset

<span id="index-ans_002dreport_002efs"></span> <span id="index-report-the-words-used-in-your-program"></span> <span id="index-words-used-in-your-program"></span>

If you want to label a Forth program as Standard Program, you must document which wordsets the program uses.

The `ans-report.fs` tool makes it easy for you to determine which words from which wordset and which non-standard words your application uses. You simply have to include `ans-report.fs` before loading the program you want to check. After loading your program, you can get the report with `print-ans-report`. A typical use is to run this as batch job like this:

<div class="example">

``` example
gforth ans-report.fs myprog.fs -e "print-ans-report bye"
```

</div>

The output looks like this (for `compat/control.fs`):

<div class="example">

``` example
The program uses the following words
from CORE :
: POSTPONE THEN ; immediate ?dup IF 0= 
from BLOCK-EXT :
\ 
from FILE :
( 
```

</div>

`ans-report.fs` reports both Forth-94 and Forth-2012 wordsets. For words that are in both standards, it reports the wordset without suffix (e.g., `CORE-EXT`). For Forth-2012-only words, it reports the wordset with a `-2012` suffix (e.g., `CORE-EXT-2012`); and likewise for the words that are Forth-94-only (i.e., that have been removed in Forth-2012).

<span id="Caveats"></span>

#### 7.1.1 Caveats

Note that `ans-report.fs` just checks which words are used, not whether they are used in a standard-conforming way\!

Some words are defined in several wordsets in the standard. `ans-report.fs` reports them for only one of the wordsets, and not necessarily the one you expect. It depends on usage which wordset is the right one to specify. E.g., if you only use the compilation semantics of `S"`, it is a Core word; if you also use its interpretation semantics, it is a File word.

-----

<div class="header">

Next: [Stack depth changes](Stack-depth-changes.html#Stack-depth-changes), Previous: [Tools](Tools.html#Tools), Up: [Tools](Tools.html#Tools)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
