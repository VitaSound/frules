> Source: https://gforth.org/manual/Arrays-and-Records-Tutorial.html

<span id="Arrays-and-Records-Tutorial"></span>

<div class="header">

Next: [POSTPONE Tutorial](POSTPONE-Tutorial.html#POSTPONE-Tutorial), Previous: [Defining Words Tutorial](Defining-Words-Tutorial.html#Defining-Words-Tutorial), Up: [Tutorial](Tutorial.html#Tutorial)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Arrays-and-Records"></span>

### 3.32 Arrays and Records

<span id="index-arrays-tutorial"></span> <span id="index-records-tutorial"></span> <span id="index-structs-tutorial"></span>

Forth has no standard words for defining arrays, but you can build them yourself based on address arithmetic. You can also define words for defining arrays and records (see [Defining Words](Defining-Words-Tutorial.html#Defining-Words-Tutorial)).

One of the first projects a Forth newcomer sets out upon when learning about defining words is an array defining word (possibly for n-dimensional arrays). Go ahead and do it, I did it, too; you will learn something from it. However, don’t be disappointed when you later learn that you have little use for these words (inappropriate use would be even worse). I have not found a set of useful array words yet; the needs are just too diverse, and named, global arrays (the result of naive use of defining words) are often not flexible enough (e.g., consider how to pass them as parameters). Another such project is a set of words to help dealing with strings.

On the other hand, there is a useful set of record words, and it has been defined in `compat/struct.fs`; these words are predefined in Gforth. They are explained in depth elsewhere in this manual (see see [Structures](Structures.html#Structures)). The `simple-field` example above is simplified variant of fields in this package.
