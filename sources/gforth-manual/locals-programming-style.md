> Source: https://gforth.org/manual/Locals-programming-style.html

<span id="Locals-programming-style"></span>

<div class="header">

Next: [Locals implementation](Locals-implementation.html#Locals-implementation), Previous: [How long do locals live?](How-long-do-locals-live_003f.html#How-long-do-locals-live_003f), Up: [Gforth locals](Gforth-locals.html#Gforth-locals)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Locals-programming-style-1"></span>

#### 5.21.1.3 Locals programming style

<span id="index-locals-programming-style"></span> <span id="index-programming-style_002c-locals"></span>

The freedom to define locals anywhere has the potential to change programming styles dramatically. In particular, the need to use the return stack for intermediate storage vanishes. Moreover, all stack manipulations (except `PICK`s and `ROLL`s with run-time determined arguments) can be eliminated: If the stack items are in the wrong order, just write a locals definition for all of them; then write the items in the order you want.

This seems a little far-fetched and eliminating stack manipulations is unlikely to become a conscious programming objective. Still, the number of stack manipulations will be reduced dramatically if local variables are used liberally (e.g., compare `max` (see [Gforth locals](Gforth-locals.html#Gforth-locals)) with a traditional implementation of `max`).

This shows one potential benefit of locals: making Forth programs more readable. Of course, this benefit will only be realized if the programmers continue to honour the principle of factoring instead of using the added latitude to make the words longer.

<span id="index-single_002dassignment-style-for-locals"></span>

Using `TO` can and should be avoided. Without `TO`, every value-flavoured local has only a single assignment and many advantages of functional languages apply to Forth. I.e., programs are easier to analyse, to optimize and to read: It is clear from the definition what the local stands for, it does not turn into something different later.

E.g., a definition using `TO` might look like this:

<div class="example">

``` example
: strcmp { addr1 u1 addr2 u2 -- n }
 u1 u2 min 0
 ?do
   addr1 c@ addr2 c@ -
   ?dup-if
     unloop exit
   then
   addr1 char+ TO addr1
   addr2 char+ TO addr2
 loop
 u1 u2 - ;
```

</div>

Here, `TO` is used to update `addr1` and `addr2` at every loop iteration. `strcmp` is a typical example of the readability problems of using `TO`. When you start reading `strcmp`, you think that `addr1` refers to the start of the string. Only near the end of the loop you realize that it is something else.

This can be avoided by defining two locals at the start of the loop that are initialized with the right value for the current iteration.

<div class="example">

``` example
: strcmp { addr1 u1 addr2 u2 -- n }
 addr1 addr2
 u1 u2 min 0 
 ?do { s1 s2 }
   s1 c@ s2 c@ -
   ?dup-if
     unloop exit
   then
   s1 char+ s2 char+
 loop
 2drop
 u1 u2 - ;
```

</div>

Here it is clear from the start that `s1` has a different value in every loop iteration.

-----

<div class="header">

Next: [Locals implementation](Locals-implementation.html#Locals-implementation), Previous: [How long do locals live?](How-long-do-locals-live_003f.html#How-long-do-locals-live_003f), Up: [Gforth locals](Gforth-locals.html#Gforth-locals)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
