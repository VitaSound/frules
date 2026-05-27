> Source: https://gforth.org/manual/Performance.html

<span id="Performance"></span>

<div class="header">

Previous: [Primitives](Primitives.html#Primitives), Up: [Engine](Engine.html#Engine)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Performance-1"></span>

### 14.4 Performance

<span id="index-performance-of-some-Forth-interpreters"></span> <span id="index-engine-performance"></span> <span id="index-benchmarking-Forth-systems"></span> <span id="index-Gforth-performance"></span>

On RISCs the Gforth engine is very close to optimal; i.e., it is usually impossible to write a significantly faster threaded-code engine.

On register-starved machines like the 386 architecture processors improvements are possible, because `gcc` does not utilize the registers as well as a human, even with explicit register declarations; e.g., Bernd Beuster wrote a Forth system fragment in assembly language and hand-tuned it for the 486; this system is 1.19 times faster on the Sieve benchmark on a 486DX2/66 than Gforth compiled with `gcc-2.6.3` with `-DFORCE_REG`. The situation has improved with gcc-2.95 and gforth-0.4.9; now the most important virtual machine registers fit in real registers (and we can even afford to use the TOS optimization), resulting in a speedup of 1.14 on the sieve over the earlier results. And dynamic superinstructions provide another speedup (but only around a factor 1.2 on the 486).

<span id="index-Win32Forth-performance"></span> <span id="index-NT-Forth-performance"></span> <span id="index-eforth-performance"></span> <span id="index-ThisForth-performance"></span> <span id="index-PFE-performance"></span> <span id="index-TILE-performance"></span>

The potential advantage of assembly language implementations is not necessarily realized in complete Forth systems: We compared Gforth-0.5.9 (direct threaded, compiled with `gcc-2.95.1` and `-DFORCE_REG`) with Win32Forth 1.2093 (newer versions are reportedly much faster), LMI’s NT Forth (Beta, May 1994) and Eforth (with and without peephole (aka pinhole) optimization of the threaded code); all these systems were written in assembly language. We also compared Gforth with three systems written in C: PFE-0.9.14 (compiled with `gcc-2.6.3` with the default configuration for Linux: `-O2 -fomit-frame-pointer -DUSE_REGS -DUNROLL_NEXT`), ThisForth Beta (compiled with `gcc-2.6.3 -O3 -fomit-frame-pointer`; ThisForth employs peephole optimization of the threaded code) and TILE (compiled with `make opt`). We benchmarked Gforth, PFE, ThisForth and TILE on a 486DX2/66 under Linux. Kenneth O’Heskin kindly provided the results for Win32Forth and NT Forth on a 486DX2/66 with similar memory performance under Windows NT. Marcel Hendrix ported Eforth to Linux, then extended it to run the benchmarks, added the peephole optimizer, ran the benchmarks and reported the results.

We used four small benchmarks: the ubiquitous Sieve; bubble-sorting and matrix multiplication come from the Stanford integer benchmarks and have been translated into Forth by Martin Fraeman; we used the versions included in the TILE Forth package, but with bigger data set sizes; and a recursive Fibonacci number computation for benchmarking calling performance. The following table shows the time taken for the benchmarks scaled by the time taken by Gforth (in other words, it shows the speedup factor that Gforth achieved over the other systems).

<div class="example">

``` example
relative       Win32-    NT       eforth       This-      
time     Gforth Forth Forth eforth  +opt   PFE Forth  TILE
sieve      1.00  2.16  1.78   2.16  1.32  2.46  4.96 13.37
bubble     1.00  1.93  2.07   2.18  1.29  2.21        5.70
matmul     1.00  1.92  1.76   1.90  0.96  2.06        5.32
fib        1.00  2.32  2.03   1.86  1.31  2.64  4.55  6.54
```

</div>

You may be quite surprised by the good performance of Gforth when compared with systems written in assembly language. One important reason for the disappointing performance of these other systems is probably that they are not written optimally for the 486 (e.g., they use the `lods` instruction). In addition, Win32Forth uses a comfortable, but costly method for relocating the Forth image: like `cforth`, it computes the actual addresses at run time, resulting in two address computations per `NEXT` (see [Image File Background](Image-File-Background.html#Image-File-Background)).

The speedup of Gforth over PFE, ThisForth and TILE can be easily explained with the self-imposed restriction of the latter systems to standard C, which makes efficient threading impossible (however, the measured implementation of PFE uses a GNU C extension: see [Defining Global Register Variables](http://gcc.gnu.org/onlinedocs/gcc/Global-Reg-Vars.html#Global-Reg-Vars) in GNU C Manual). Moreover, current C compilers have a hard time optimizing other aspects of the ThisForth and the TILE source.

The performance of Gforth on 386 architecture processors varies widely with the version of `gcc` used. E.g., `gcc-2.5.8` failed to allocate any of the virtual machine registers into real machine registers by itself and would not work correctly with explicit register declarations, giving a significantly slower engine (on a 486DX2/66 running the Sieve) than the one measured above.

Note that there have been several releases of Win32Forth since the release presented here, so the results presented above may have little predictive value for the performance of Win32Forth today (results for the current release on an i486DX2/66 are welcome).

<span id="index-Benchres"></span>

In [Translating Forth to Efficient C](http://www.complang.tuwien.ac.at/papers/ertl&maierhofer95.ps.gz) by M. Anton Ertl and Martin Maierhofer (presented at EuroForth ’95), an indirect threaded version of Gforth is compared with Win32Forth, NT Forth, PFE, ThisForth, and several native code systems; that version of Gforth is slower on a 486 than the version used here. You can find a newer version of these measurements at <http://www.complang.tuwien.ac.at/forth/performance.html>. You can find numbers for Gforth on various machines in `Benchres`.

-----

<div class="header">

Previous: [Primitives](Primitives.html#Primitives), Up: [Engine](Engine.html#Engine)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
