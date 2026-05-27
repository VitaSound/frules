> Source: https://gforth.org/manual/Scheduling.html

<span id="Scheduling"></span>

<div class="header">

Next: [Direct or Indirect Threaded?](Direct-or-Indirect-Threaded_003f.html#Direct-or-Indirect-Threaded_003f), Previous: [Threading](Threading.html#Threading), Up: [Threading](Threading.html#Threading)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Scheduling-1"></span>

#### 14.2.1 Scheduling

<span id="index-inner-interpreter-optimization"></span>

There is a little complication: Pipelined and superscalar processors, i.e., RISC and some modern CISC machines can process independent instructions while waiting for the results of an instruction. The compiler usually reorders (schedules) the instructions in a way that achieves good usage of these delay slots. However, on our first tries the compiler did not do well on scheduling primitives. E.g., for `+` implemented as

<div class="example">

``` example
n=sp[0]+sp[1];
sp++;
sp[0]=n;
NEXT;
```

</div>

the `NEXT` comes strictly after the other code, i.e., there is nearly no scheduling. After a little thought the problem becomes clear: The compiler cannot know that `sp` and `ip` point to different addresses (and the version of `gcc` we used would not know it even if it was possible), so it could not move the load of the cfa above the store to the TOS. Indeed the pointers could be the same, if code on or very near the top of stack were executed. In the interest of speed we chose to forbid this probably unused “feature” and helped the compiler in scheduling: `NEXT` is divided into several parts: `NEXT_P0`, `NEXT_P1` and `NEXT_P2`). `+` now looks like:

<div class="example">

``` example
NEXT_P0;
n=sp[0]+sp[1];
sp++;
NEXT_P1;
sp[0]=n;
NEXT_P2;
```

</div>

There are various schemes that distribute the different operations of NEXT between these parts in several ways; in general, different schemes perform best on different processors. We use a scheme for most architectures that performs well for most processors of this architecture; in the future we may switch to benchmarking and chosing the scheme on installation time.

-----

<div class="header">

Next: [Direct or Indirect Threaded?](Direct-or-Indirect-Threaded_003f.html#Direct-or-Indirect-Threaded_003f), Previous: [Threading](Threading.html#Threading), Up: [Threading](Threading.html#Threading)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
