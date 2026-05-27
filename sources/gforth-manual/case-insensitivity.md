> Source: https://gforth.org/manual/Case-insensitivity.html

<span id="Case-insensitivity"></span>

<div class="header">

Next: [Comments](Comments.html#Comments), Previous: [Notation](Notation.html#Notation), Up: [Words](Words.html#Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Case-insensitivity-1"></span>

### 5.2 Case insensitivity

<span id="index-case-sensitivity"></span> <span id="index-upper-and-lower-case"></span>

Gforth is case-insensitive; you can enter definitions and invoke Standard words using upper, lower or mixed case (however, see [Implementation-defined options](core_002didef.html#core_002didef)).

Standard Forth only *requires* implementations to recognise Standard words when they are typed entirely in upper case. Therefore, a Standard program must use upper case for all Standard words. You can use whatever case you like for words that you define, but in a Standard program you have to use the words in the same case that you defined them.

Gforth supports case sensitivity through `table`s (case-sensitive wordlists, see [Word Lists](Word-Lists.html#Word-Lists)).

Two people have asked how to convert Gforth to be case-sensitive; while we think this is a bad idea, you can change all wordlists into tables like this:

<div class="example">

``` example
' table-find forth-wordlist wordlist-map  !
```

</div>

Note that you now have to type the predefined words in the same case that we defined them, which are varying. You may want to convert them to your favourite case before doing this operation (I won’t explain how, because if you are even contemplating doing this, you’d better have enough knowledge of Forth systems to know this already).
