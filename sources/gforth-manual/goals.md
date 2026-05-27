> Source: https://gforth.org/manual/Goals.html

<span id="Goals"></span>

<div class="header">

Next: [Gforth Environment](Gforth-Environment.html#Gforth-Environment), Previous: [Top](index.html#Top), Up: [Top](index.html#Top)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Goals-of-Gforth"></span>

## 1 Goals of Gforth

<span id="index-goals-of-the-Gforth-project"></span>

The goal of the Gforth Project is to develop a standard model for Standard Forth. This can be split into several subgoals:

  - Gforth should conform to the Forth Standard.
  - It should be a model, i.e. it should define all the implementation-dependent things.
  - It should become standard, i.e. widely accepted and used. This goal is the most difficult one.

To achieve these goals Gforth should be

  - Similar to previous models (fig-Forth, F83)
  - Powerful. It should provide for all the things that are considered necessary today and even some that are not yet considered necessary.
  - Efficient. It should not get the reputation of being exceptionally slow.
  - Free.
  - Available on many machines/easy to port.

Have we achieved these goals? Gforth conforms to the Forth-94 (ANS Forth) and Forth-2012 standards. It may be considered a model, but we have not yet documented which parts of the model are stable and which parts we are likely to change. It certainly has not yet become a de facto standard, but it appears to be quite popular. It has some similarities to and some differences from previous models. It has some powerful features, but not yet everything that we envisioned. We certainly have achieved our execution speed goals (see [Performance](Performance.html#Performance))[<sup>1</sup>](#FOOT1). It is free and available on many machines.

<div class="footnote">

-----

#### Footnotes

### [(1)](#DOCF1)

However, in 1998 the bar was raised when the major commercial Forth vendors switched to native code compilers.

</div>
