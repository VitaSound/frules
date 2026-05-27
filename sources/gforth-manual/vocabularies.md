> Source: https://gforth.org/manual/Vocabularies.html

<span id="Vocabularies"></span>

<div class="header">

Next: [Why use word lists?](Why-use-word-lists_003f.html#Why-use-word-lists_003f), Previous: [Word Lists](Word-Lists.html#Word-Lists), Up: [Word Lists](Word-Lists.html#Word-Lists)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Vocabularies-1"></span>

#### 5.15.1 Vocabularies

<span id="index-Vocabularies_002c-detailed-explanation"></span>

Here is an example of creating and using a new wordlist using Standard Forth words:

<div class="example">

``` example
wordlist constant my-new-words-wordlist
: my-new-words get-order nip my-new-words-wordlist swap set-order ;

\ add it to the search order
also my-new-words

\ alternatively, add it to the search order and make it
\ the compilation word list
also my-new-words definitions
\ type "order" to see the problem
```

</div>

The problem with this example is that `order` has no way to associate the name `my-new-words` with the wid of the word list (in Gforth, `order` and `vocs` will display `???` for a wid that has no associated name). There is no Standard way of associating a name with a wid.

In Gforth, this example can be re-coded using `vocabulary`, which associates a name with a wid:

<div class="example">

``` example
vocabulary my-new-words

\ add it to the search order
also my-new-words

\ alternatively, add it to the search order and make it
\ the compilation word list
my-new-words definitions
\ type "order" to see that the problem is solved
```

</div>
