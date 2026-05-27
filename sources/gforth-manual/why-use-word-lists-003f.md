> Source: https://gforth.org/manual/Why-use-word-lists_003f.html

<span id="Why-use-word-lists_003f"></span>

<div class="header">

Next: [Word list example](Word-list-example.html#Word-list-example), Previous: [Vocabularies](Vocabularies.html#Vocabularies), Up: [Word Lists](Word-Lists.html#Word-Lists)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Why-use-word-lists_003f-1"></span>

#### 5.15.2 Why use word lists?

<span id="index-word-lists-_002d-why-use-them_003f"></span>

Here are some reasons why people use wordlists:

  - To prevent a set of words from being used outside the context in which they are valid. Two classic examples of this are an integrated editor (all of the edit commands are defined in a separate word list; the search order is set to the editor word list when the editor is invoked; the old search order is restored when the editor is terminated) and an integrated assembler (the op-codes for the machine are defined in a separate word list which is used when a `CODE` word is defined).
  - To organize the words of an application or library into a user-visible set (in `forth-wordlist` or some other common wordlist) and a set of helper words used just for the implementation (hidden in a separate wordlist). This keeps `words`’ output smaller, separates implementation and interface, and reduces the chance of name conflicts within the common wordlist.
  - To prevent a name-space clash between multiple definitions with the same name. For example, when building a cross-compiler you might have a word `IF` that generates conditional code for your target system. By placing this definition in a different word list you can control whether the host system’s `IF` or the target system’s `IF` get used in any particular context by controlling the order of the word lists on the search order stack.

The downsides of using wordlists are:

  - Debugging becomes more cumbersome.
  - Name conflicts worked around with wordlists are still there, and you have to arrange the search order carefully to get the desired results; if you forget to do that, you get hard-to-find errors (as in any case where you read the code differently from the compiler; `see` can help seeing which of several possible words the name resolves to in such cases). `See` displays just the name of the words, not what wordlist they belong to, so it might be misleading. Using unique names is a better approach to avoid name conflicts.
  - You have to explicitly undo any changes to the search order. In many cases it would be more convenient if this happened implicitly. Gforth currently does not provide such a feature, but it may do so in the future.

-----

<div class="header">

Next: [Word list example](Word-list-example.html#Word-list-example), Previous: [Vocabularies](Vocabularies.html#Vocabularies), Up: [Word Lists](Word-Lists.html#Word-Lists)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
