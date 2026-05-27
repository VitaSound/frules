> Source: https://gforth.org/manual/Crash-Course-Tutorial.html

<span id="Crash-Course-Tutorial"></span>

<div class="header">

Next: [Stack Tutorial](Stack-Tutorial.html#Stack-Tutorial), Previous: [Syntax Tutorial](Syntax-Tutorial.html#Syntax-Tutorial), Up: [Tutorial](Tutorial.html#Tutorial)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Crash-Course"></span>

### 3.3 Crash Course

Forth does not prevent you from shooting yourself in the foot. Let’s try a few ways to crash Gforth:

<div class="example">

``` example
0 0 !
here execute
' catch >body 20 erase abort
' (quit) >body 20 erase
```

</div>

The last two examples are guaranteed to destroy important parts of Gforth (and most other systems), so you better leave Gforth afterwards (if it has not finished by itself). On some systems you may have to kill gforth from outside (e.g., in Unix with `kill`).

You will find out later what these lines do and then you will get an idea why they produce crashes.

Now that you know how to produce crashes (and that there’s not much to them), let’s learn how to produce meaningful programs.
