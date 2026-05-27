> Source: https://gforth.org/manual/Wordlists-and-Search-Order-Tutorial.html

<span id="Wordlists-and-Search-Order-Tutorial"></span>

<div class="header">

Previous: [Compilation Tokens Tutorial](Compilation-Tokens-Tutorial.html#Compilation-Tokens-Tutorial), Up: [Tutorial](Tutorial.html#Tutorial)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Wordlists-and-Search-Order"></span>

### 3.37 Wordlists and Search Order

<span id="index-wordlists-tutorial"></span> <span id="index-search-order_002c-tutorial"></span>

The dictionary is not just a memory area that allows you to allocate memory with `allot`, it also contains the Forth words, arranged in several wordlists. When searching for a word in a wordlist, conceptually you start searching at the youngest and proceed towards older words (in reality most systems nowadays use hash-tables); i.e., if you define a word with the same name as an older word, the new word shadows the older word.

Which wordlists are searched in which order is determined by the search order. You can display the search order with `order`. It displays first the search order, starting with the wordlist searched first, then it displays the wordlist that will contain newly defined words.

You can create a new, empty wordlist with `wordlist ( -- wid )`:

<div class="example">

``` example
wordlist constant mywords
```

</div>

`Set-current ( wid -- )` sets the wordlist that will contain newly defined words (the *current* wordlist):

<div class="example">

``` example
mywords set-current
order
```

</div>

Gforth does not display a name for the wordlist in `mywords` because this wordlist was created anonymously with `wordlist`.

You can get the current wordlist with `get-current ( -- wid)`. If you want to put something into a specific wordlist without overall effect on the current wordlist, this typically looks like this:

<div class="example">

``` example
get-current mywords set-current ( wid )
create someword
( wid ) set-current
```

</div>

You can write the search order with `set-order ( wid1 .. widn n -- )` and read it with `get-order ( -- wid1 .. widn n )`. The first searched wordlist is topmost.

<div class="example">

``` example
get-order mywords swap 1+ set-order
order
```

</div>

Yes, the order of wordlists in the output of `order` is reversed from stack comments and the output of `.s` and thus unintuitive.

> **Assignment:** Define `>order ( wid -- )` which adds `wid` as first searched wordlist to the search order. Define `previous ( -- )`, which removes the first searched wordlist from the search order. Experiment with boundary conditions (you will see some crashes or situations that are hard or impossible to leave).

The search order is a powerful foundation for providing features similar to Modula-2 modules and C++ namespaces. However, trying to modularize programs in this way has disadvantages for debugging and reuse/factoring that overcome the advantages in my experience (I don’t do huge projects, though). These disadvantages are not so clear in other languages/programming environments, because these languages are not so strong in debugging and reuse.

Reference: [Word Lists](Word-Lists.html#Word-Lists).

-----

<div class="header">

Previous: [Compilation Tokens Tutorial](Compilation-Tokens-Tutorial.html#Compilation-Tokens-Tutorial), Up: [Tutorial](Tutorial.html#Tutorial)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
