> Source: https://gforth.org/manual/Standard-vs-Extensions.html

<span id="Standard-vs-Extensions"></span>

<div class="header">

Next: [Model](Model.html#Model), Previous: [Standard conformance](Standard-conformance.html#Standard-conformance), Up: [Top](index.html#Top)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Should-I-use-Gforth-extensions_003f"></span>

## 9 Should I use Gforth extensions?

<span id="index-Gforth-extensions"></span>

As you read through the rest of this manual, you will see documentation for *Standard* words, and documentation for some appealing Gforth *extensions*. You might ask yourself the question: *“Should I restrict myself to the standard, or should I use the extensions?”*

The answer depends on the goals you have for the program you are working on:

  - Is it just for yourself or do you want to share it with others?
  - If you want to share it, do the others all use Gforth?
  - If it is just for yourself, do you want to restrict yourself to Gforth?

If restricting the program to Gforth is ok, then there is no reason not to use extensions. It is still a good idea to keep to the standard where it is easy, in case you want to reuse these parts in another program that you want to be portable.

If you want to be able to port the program to other Forth systems, there are the following points to consider:

  - Most Forth systems that are being maintained support Standard Forth. So if your program complies with the standard, it will be portable among many systems.
  - A number of the Gforth extensions can be implemented in Standard Forth using public-domain files provided in the `compat/` directory. These are mentioned in the text in passing. There is no reason not to use these extensions, your program will still be Standard Forth compliant; just include the appropriate compat files with your program.
  - The tool `ans-report.fs` (see [Standard Report](Standard-Report.html#Standard-Report)) makes it easy to analyse your program and determine what non-Standard words it relies upon. However, it does not check whether you use standard words in a non-standard way.
  - Some techniques are not standardized by Standard Forth, and are hard or impossible to implement in a standard way, but can be implemented in most Forth systems easily, and usually in similar ways (e.g., accessing word headers). Forth has a rich historical precedent for programmers taking advantage of implementation-dependent features of their tools (for example, relying on a knowledge of the dictionary structure). Sometimes these techniques are necessary to extract every last bit of performance from the hardware, sometimes they are just a programming shorthand.
  - Does using a Gforth extension save more work than the porting this part to other Forth systems (if any) will cost?
  - Is the additional functionality worth the reduction in portability and the additional porting problems?

In order to perform these considerations, you need to know what’s standard and what’s not. This manual generally states if something is non-standard, but the authoritative source is the [standard document](http://www.taygeta.com/forth/dpans.html). Appendix A of the Standard (`Rationale`) provides a valuable insight into the thought processes of the technical committee.

Note also that portability between Forth systems is not the only portability issue; there is also the issue of portability between different platforms (processor/OS combinations).

-----

<div class="header">

Next: [Model](Model.html#Model), Previous: [Standard conformance](Standard-conformance.html#Standard-conformance), Up: [Top](index.html#Top)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
