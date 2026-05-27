> Source: https://gforth.org/manual/Stack-depth-changes.html

<span id="Stack-depth-changes"></span>

<div class="header">

Previous: [Standard Report](Standard-Report.html#Standard-Report), Up: [Tools](Tools.html#Tools)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Stack-depth-changes-during-interpretation"></span>

### 7.2 Stack depth changes during interpretation

<span id="index-depth_002dchanges_002efs"></span> <span id="index-depth-changes-during-interpretation"></span> <span id="index-stack-depth-changes-during-interpretation"></span> <span id="index-items-on-the-stack-after-interpretation"></span>

Sometimes you notice that, after loading a file, there are items left on the stack. The tool `depth-changes.fs` helps you find out quickly where in the file these stack items are coming from.

The simplest way of using `depth-changes.fs` is to include it before the file(s) you want to check, e.g.:

<div class="example">

``` example
gforth depth-changes.fs my-file.fs
```

</div>

This will compare the stack depths of the data and FP stack at every empty line (in interpretation state) against these depths at the last empty line (in interpretation state). If the depths are not equal, the position in the file and the stack contents are printed with `~~` (see [Debugging](Debugging.html#Debugging)). This indicates that a stack depth change has occured in the paragraph of non-empty lines before the indicated line. It is a good idea to leave an empty line at the end of the file, so the last paragraph is checked, too.

Checking only at empty lines usually works well, but sometimes you have big blocks of non-empty lines (e.g., when building a big table), and you want to know where in this block the stack depth changed. You can check all interpreted lines with

<div class="example">

``` example
gforth depth-changes.fs -e "' all-lines is depth-changes-filter" my-file.fs
```

</div>

This checks the stack depth at every end-of-line. So the depth change occured in the line reported by the `~~` (not in the line before).

Note that, while this offers better accuracy in indicating where the stack depth changes, it will often report many intentional stack depth changes (e.g., when an interpreted computation stretches across several lines). You can suppress the checking of some lines by putting backslashes at the end of these lines (not followed by white space), and using

<div class="example">

``` example
gforth depth-changes.fs -e "' most-lines is depth-changes-filter" my-file.fs
```

</div>

-----

<div class="header">

Previous: [Standard Report](Standard-Report.html#Standard-Report), Up: [Tools](Tools.html#Tools)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
