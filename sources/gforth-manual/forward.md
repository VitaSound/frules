> Source: https://gforth.org/manual/Forward.html

<span id="Forward"></span>

<div class="header">

Next: [Aliases](Aliases.html#Aliases), Previous: [Deferred Words](Deferred-Words.html#Deferred-Words), Up: [Defining Words](Defining-Words.html#Defining-Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Forward-1"></span>

#### 5.9.11 Forward

The defining word `Forward` in `forward.fs` allows you to create forward references, which are resolved automatically, and do not incur additional costs like the indirection of `Defer`. However, these forward definitions only work for colon definitions.

doc-forward doc-.unresolved
