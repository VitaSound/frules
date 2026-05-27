> Source: https://gforth.org/manual/Stack-Tutorial.html

<span id="Stack-Tutorial"></span>

<div class="header">

Next: [Arithmetics Tutorial](Arithmetics-Tutorial.html#Arithmetics-Tutorial), Previous: [Crash Course Tutorial](Crash-Course-Tutorial.html#Crash-Course-Tutorial), Up: [Tutorial](Tutorial.html#Tutorial)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Stack"></span>

### 3.4 Stack

<span id="index-stack-tutorial"></span>

The most obvious feature of Forth is the stack. When you type in a number, it is pushed on the stack. You can display the contents of the stack with `.s`.

<div class="example">

``` example
1 2 .s
3 .s
```

</div>

`.s` displays the top-of-stack to the right, i.e., the numbers appear in `.s` output as they appeared in the input.

You can print the top element of the stack with `.`.

<div class="example">

``` example
1 2 3 . . .
```

</div>

In general, words consume their stack arguments (`.s` is an exception).

> **Assignment:** What does the stack contain after `5 6 7 .`?
