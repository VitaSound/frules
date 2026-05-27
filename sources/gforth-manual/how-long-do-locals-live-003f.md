> Source: https://gforth.org/manual/How-long-do-locals-live_003f.html

<span id="How-long-do-locals-live_003f"></span>

<div class="header">

Next: [Locals programming style](Locals-programming-style.html#Locals-programming-style), Previous: [Where are locals visible by name?](Where-are-locals-visible-by-name_003f.html#Where-are-locals-visible-by-name_003f), Up: [Gforth locals](Gforth-locals.html#Gforth-locals)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="How-long-do-locals-live_003f-1"></span>

#### 5.21.1.2 How long do locals live?

<span id="index-locals-lifetime"></span> <span id="index-lifetime-of-locals"></span>

The right answer for the lifetime question would be: A local lives at least as long as it can be accessed. For a value-flavoured local this means: until the end of its visibility. However, a variable-flavoured local could be accessed through its address far beyond its visibility scope. Ultimately, this would mean that such locals would have to be garbage collected. Since this entails un-Forth-like implementation complexities, I adopted the same cowardly solution as some other languages (e.g., C): The local lives only as long as it is visible; afterwards its address is invalid (and programs that access it afterwards are erroneous).
