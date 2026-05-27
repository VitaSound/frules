> Source: https://gforth.org/manual/Threading.html

<span id="Threading"></span>

<div class="header">

Next: [Primitives](Primitives.html#Primitives), Previous: [Portability](Portability.html#Portability), Up: [Engine](Engine.html#Engine)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Threading-1"></span>

### 14.2 Threading

<span id="index-inner-interpreter-implementation"></span> <span id="index-threaded-code-implementation"></span> <span id="index-labels-as-values"></span>

GNU C’s labels as values extension (available since `gcc-2.0`, see [Labels as Values](http://gcc.gnu.org/onlinedocs/gcc/Labels-as-Values.html#Labels-as-Values) in GNU C Manual) makes it possible to take the address of *label* by writing `&&label`. This address can then be used in a statement like `goto *address`. I.e., `goto *&&x` is the same as `goto x`.

<span id="index-NEXT_002c-indirect-threaded"></span> <span id="index-indirect-threaded-inner-interpreter"></span> <span id="index-inner-interpreter_002c-indirect-threaded"></span>

With this feature an indirect threaded `NEXT` looks like:

<div class="example">

``` example
cfa = *ip++;
ca = *cfa;
goto *ca;
```

</div>

<span id="index-instruction-pointer"></span>

For those unfamiliar with the names: `ip` is the Forth instruction pointer; the `cfa` (code-field address) corresponds to Standard Forth’s execution token and points to the code field of the next word to be executed; The `ca` (code address) fetched from there points to some executable code, e.g., a primitive or the colon definition handler `docol`.

<span id="index-NEXT_002c-direct-threaded"></span> <span id="index-direct-threaded-inner-interpreter"></span> <span id="index-inner-interpreter_002c-direct-threaded"></span>

Direct threading is even simpler:

<div class="example">

``` example
ca = *ip++;
goto *ca;
```

</div>

Of course we have packaged the whole thing neatly in macros called `NEXT` and `NEXT1` (the part of `NEXT` after fetching the cfa).

|                                                                                                           |  |  |
| :-------------------------------------------------------------------------------------------------------- |  | :- |
| • [Scheduling](Scheduling.html#Scheduling):                                                               |  |  |
| • [Direct or Indirect Threaded?](Direct-or-Indirect-Threaded_003f.html#Direct-or-Indirect-Threaded_003f): |  |  |
| • [Dynamic Superinstructions](Dynamic-Superinstructions.html#Dynamic-Superinstructions):                  |  |  |
| • [DOES\>](DOES_003e.html#DOES_003e):                                                                     |  |  |
