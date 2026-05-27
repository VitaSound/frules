> Source: https://gforth.org/manual/Syntax-Tutorial.html

<span id="Syntax-Tutorial"></span>

<div class="header">

Next: [Crash Course Tutorial](Crash-Course-Tutorial.html#Crash-Course-Tutorial), Previous: [Starting Gforth Tutorial](Starting-Gforth-Tutorial.html#Starting-Gforth-Tutorial), Up: [Tutorial](Tutorial.html#Tutorial)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Syntax"></span>

### 3.2 Syntax

<span id="index-syntax-tutorial"></span>

A *word* is a sequence of arbitrary characters (except white space). Words are separated by white space. E.g., each of the following lines contains exactly one word:

<div class="example">

``` example
word
!@#$%^&*()
1234567890
5!a
```

</div>

A frequent beginner’s error is to leave out necessary white space, resulting in an error like ‘`Undefined word`’; so if you see such an error, check if you have put spaces wherever necessary.

<div class="example">

``` example
." hello, world" \ correct
."hello, world"  \ gives an "Undefined word" error
```

</div>

Gforth and most other Forth systems ignore differences in case (they are case-insensitive), i.e., ‘`word`’ is the same as ‘`Word`’. If your system is case-sensitive, you may have to type all the examples given here in upper case.
