> Source: https://gforth.org/manual/Word-list-example.html

<span id="Word-list-example"></span>

<div class="header">

Previous: [Why use word lists?](Why-use-word-lists_003f.html#Why-use-word-lists_003f), Up: [Word Lists](Word-Lists.html#Word-Lists)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Word-list-example-1"></span>

#### 5.15.3 Word list example

<span id="index-word-lists-_002d-example"></span>

The following example is from the [garbage collector](http://www.complang.tuwien.ac.at/forth/garbage-collection.zip) and uses wordlists to separate public words from helper words:

<div class="example">

``` example
get-current ( wid )
vocabulary garbage-collector also garbage-collector definitions
... \ define helper words
( wid ) set-current \ restore original (i.e., public) compilation wordlist
... \ define the public (i.e., API) words
    \ they can refer to the helper words
previous \ restore original search order (helper words become invisible)
```

</div>
