> Source: https://gforth.org/manual/Migrating-the-C-interface-from-earlier-Gforth.html

<span id="Migrating-the-C-interface-from-earlier-Gforth"></span>

<div class="header">

Previous: [Low-Level C Interface Words](Low_002dLevel-C-Interface-Words.html#Low_002dLevel-C-Interface-Words), Up: [C Interface](C-Interface.html#C-Interface)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Migrating-from-Gforth-0_002e7"></span>

#### 5.26.9 Migrating from Gforth 0.7

<span id="index-Must-now-be-used-inside-C_002dLIBRARY_002c-see-C-interface-doc"></span>

In this version, you can use `\c`, `c-function` and `add-lib` only inside `c-library`...`end-c-library`. `add-lib` now always starts from a clean slate inside a `c-library`, so you don’t need to use `clear-libs` in most cases.

If you have a program that uses these words outside `c-library`...`end-c-library`, just wrap them in `c-library`...`end-c-library`. You may have to add some instances of `add-lib`, however.
