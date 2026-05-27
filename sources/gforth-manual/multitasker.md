> Source: https://gforth.org/manual/Multitasker.html

<span id="Multitasker"></span>

<div class="header">

Next: [C Interface](C-Interface.html#C-Interface), Previous: [Programming Tools](Programming-Tools.html#Programming-Tools), Up: [Words](Words.html#Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Multitasker-1"></span>

### 5.25 Multitasker

<span id="index-multitasker"></span>

|                                       |  |                         |
| :------------------------------------ |  | :---------------------- |
| • [Pthreads](Pthreads.html#Pthreads): |  | Native Unix multitasker |

Gforth offers two multitasker: a traditional, cooperative round-robin multitasker, and a pthread-based multitasker which allows to run several threads concurrently on multi-core machines.
