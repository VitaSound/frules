> Source: https://gforth.org/manual/Decompilation-Tutorial.html

<span id="Decompilation-Tutorial"></span>

<div class="header">

Next: [Stack-Effect Comments Tutorial](Stack_002dEffect-Comments-Tutorial.html#Stack_002dEffect-Comments-Tutorial), Previous: [Colon Definitions Tutorial](Colon-Definitions-Tutorial.html#Colon-Definitions-Tutorial), Up: [Tutorial](Tutorial.html#Tutorial)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Decompilation"></span>

### 3.10 Decompilation

<span id="index-decompilation-tutorial"></span> <span id="index-see-tutorial"></span>

You can decompile colon definitions with `see`:

<div class="example">

``` example
see squared
see cubed
```

</div>

In Gforth `see` shows you a reconstruction of the source code from the executable code. Informations that were present in the source, but not in the executable code, are lost (e.g., comments).

You can also decompile the predefined words:

<div class="example">

``` example
see .
see +
```

</div>
