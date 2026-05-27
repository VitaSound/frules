> Source: https://gforth.org/manual/Portability.html

<span id="Portability"></span>

<div class="header">

Next: [Threading](Threading.html#Threading), Previous: [Engine](Engine.html#Engine), Up: [Engine](Engine.html#Engine)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Portability-1"></span>

### 14.1 Portability

<span id="index-engine-portability"></span>

An important goal of the Gforth Project is availability across a wide range of personal machines. fig-Forth, and, to a lesser extent, F83, achieved this goal by manually coding the engine in assembly language for several then-popular processors. This approach is very labor-intensive and the results are short-lived due to progress in computer architecture.

<span id="index-C_002c-using-C-for-the-engine"></span>

Others have avoided this problem by coding in C, e.g., Mitch Bradley (cforth), Mikael Patel (TILE) and Dirk Zoller (pfe). This approach is particularly popular for UNIX-based Forths due to the large variety of architectures of UNIX machines. Unfortunately an implementation in C does not mix well with the goals of efficiency and with using traditional techniques: Indirect or direct threading cannot be expressed in C, and switch threading, the fastest technique available in C, is significantly slower. Another problem with C is that it is very cumbersome to express double integer arithmetic.

<span id="index-GNU-C-for-the-engine"></span> <span id="index-long-long"></span>

Fortunately, there is a portable language that does not have these limitations: GNU C, the version of C processed by the GNU C compiler (see [Extensions to the C Language Family](http://gcc.gnu.org/onlinedocs/gcc/C-Extensions.html#C-Extensions) in GNU C Manual). Its labels as values feature (see [Labels as Values](http://gcc.gnu.org/onlinedocs/gcc/Labels-as-Values.html#Labels-as-Values) in GNU C Manual) makes direct and indirect threading possible, its `long long` type (see [Double-Word Integers](http://gcc.gnu.org/onlinedocs/gcc/Long-Long.html#Long-Long) in GNU C Manual) corresponds to Forth’s double numbers on many systems. GNU C is freely available on all important (and many unimportant) UNIX machines, VMS, 80386s running MS-DOS, the Amiga, and the Atari ST, so a Forth written in GNU C can run on all these machines.

Writing in a portable language has the reputation of producing code that is slower than assembly. For our Forth engine we repeatedly looked at the code produced by the compiler and eliminated most compiler-induced inefficiencies by appropriate changes in the source code.

<span id="index-explicit-register-declarations"></span> <span id="index-_002d_002denable_002dforce_002dreg_002c-configuration-flag"></span> <span id="index-_002dDFORCE_005fREG"></span>

However, register allocation cannot be portably influenced by the programmer, leading to some inefficiencies on register-starved machines. We use explicit register declarations (see [Variables in Specified Registers](http://gcc.gnu.org/onlinedocs/gcc/Explicit-Reg-Vars.html#Explicit-Reg-Vars) in GNU C Manual) to improve the speed on some machines. They are turned on by using the configuration flag `--enable-force-reg` (`gcc` switch `-DFORCE_REG`). Unfortunately, this feature not only depends on the machine, but also on the compiler version: On some machines some compiler versions produce incorrect code when certain explicit register declarations are used. So by default `-DFORCE_REG` is not used.

-----

<div class="header">

Next: [Threading](Threading.html#Threading), Previous: [Engine](Engine.html#Engine), Up: [Engine](Engine.html#Engine)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
