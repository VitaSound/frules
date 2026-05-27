> Source: https://gforth.org/manual/Word-Lists.html

<span id="Word-Lists"></span>

<div class="header">

Next: [Environmental Queries](Environmental-Queries.html#Environmental-Queries), Previous: [The Input Stream](The-Input-Stream.html#The-Input-Stream), Up: [Words](Words.html#Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Word-Lists-1"></span>

### 5.15 Word Lists

<span id="index-word-lists"></span> <span id="index-header-space"></span>

A wordlist is a list of named words; you can add new words and look up words by name (and you can remove words in a restricted way with markers). Every named (and `reveal`ed) word is in one wordlist.

<span id="index-search-order-stack"></span>

The text interpreter searches the wordlists present in the search order (a stack of wordlists), from the top to the bottom. Within each wordlist, the search starts conceptually at the newest word; i.e., if two words in a wordlist have the same name, the newer word is found.

<span id="index-compilation-word-list"></span>

New words are added to the *compilation wordlist* (aka current wordlist).

<span id="index-wid"></span>

A word list is identified by a cell-sized word list identifier (*wid*) in much the same way as a file is identified by a file handle. The numerical value of the wid has no (portable) meaning, and might change from session to session.

The Standard Forth “Search order” word set is intended to provide a set of low-level tools that allow various different schemes to be implemented. Gforth also provides `vocabulary`, a traditional Forth word. `compat/vocabulary.fs` provides an implementation in Standard Forth.

<span id="index-forth_002dwordlist--_002d_002d-wid--search"></span> <span id="index-forth_002dwordlist"></span> <span id="index-forth_002dwordlist-1"></span>

<div class="format">

``` format
forth-wordlist       – wid         search       “forth-wordlist”
```

</div>

`Constant` – *wid* identifies the word list that includes all of the standard words provided by Gforth. When Gforth is invoked, this word list is the compilation word list and is at the top of the search order.

<span id="index-definitions--_002d_002d--search"></span> <span id="index-definitions"></span> <span id="index-definitions-2"></span>

<div class="format">

``` format
definitions       –         search       “definitions”
```

</div>

Set the compilation word list to be the same as the word list that is currently at the top of the search order.

<span id="index-get_002dcurrent--_002d_002d-wid--search"></span> <span id="index-get_002dcurrent"></span> <span id="index-get_002dcurrent-1"></span>

<div class="format">

``` format
get-current       – wid         search       “get-current”
```

</div>

*wid* is the identifier of the current compilation word list.

<span id="index-set_002dcurrent--wid-_002d_002d--search"></span> <span id="index-set_002dcurrent"></span> <span id="index-set_002dcurrent-1"></span>

<div class="format">

``` format
set-current       wid –         search       “set-current”
```

</div>

Set the compilation word list to the word list identified by *wid*.

<span id="index-get_002dorder--_002d_002d-widn-_002e_002e-wid1-n--search"></span> <span id="index-get_002dorder"></span> <span id="index-get_002dorder-1"></span>

<div class="format">

``` format
get-order       – widn .. wid1 n         search       “get-order”
```

</div>

Copy the search order to the data stack. The current search order has *n* entries, of which *wid1* represents the wordlist that is searched first (the word list at the top of the search order) and *widn* represents the wordlist that is searched last.

<span id="index-set_002dorder--widn-_002e_002e-wid1-n-_002d_002d--search"></span> <span id="index-set_002dorder"></span> <span id="index-set_002dorder-1"></span>

<div class="format">

``` format
set-order       widn .. wid1 n –         search       “set-order”
```

</div>

If `n`=0, empty the search order. If `n`=-1, set the search order to the implementation-defined minimum search order (for Gforth, this is the word list `Root`). Otherwise, replace the existing search order with the `n` wid entries such that `wid1` represents the word list that will be searched first and `widn` represents the word list that will be searched last.

<span id="index-wordlist--_002d_002d-wid--search"></span> <span id="index-wordlist"></span> <span id="index-wordlist-1"></span>

<div class="format">

``` format
wordlist       – wid         search       “wordlist”
```

</div>

Create a new, empty word list represented by *wid*.

<span id="index-table--_002d_002d-wid--gforth"></span> <span id="index-table"></span> <span id="index-table-1"></span>

<div class="format">

``` format
table       – wid         gforth       “table”
```

</div>

Create a lookup table (case-sensitive, no warnings).

<span id="index-cs_002dwordlist--_002d_002d-wid--gforth"></span> <span id="index-cs_002dwordlist"></span> <span id="index-cs_002dwordlist-1"></span>

<div class="format">

``` format
cs-wordlist       – wid         gforth       “cs-wordlist”
```

</div>

Create a case-sensitive wordlist.

<span id="index-cs_002dvocabulary--_0022name_0022-_002d_002d--gforth"></span> <span id="index-cs_002dvocabulary"></span> <span id="index-cs_002dvocabulary-1"></span>

<div class="format">

``` format
cs-vocabulary       "name" –         gforth       “cs-vocabulary”
```

</div>

Create a case-senisitve vocabulary

<span id="index-_003eorder--wid-_002d_002d--gforth"></span> <span id="index-_003eorder"></span> <span id="index-_003eorder-1"></span>

<div class="format">

``` format
>order       wid –         gforth       “to-order”
```

</div>

Push `wid` on the search order.

<span id="index-previous--_002d_002d--search_002dext"></span> <span id="index-previous"></span> <span id="index-previous-1"></span>

<div class="format">

``` format
previous       –         search-ext       “previous”
```

</div>

Drop the wordlist at the top of the search order.

<span id="index-also--_002d_002d--search_002dext"></span> <span id="index-also"></span> <span id="index-also-1"></span>

<div class="format">

``` format
also       –         search-ext       “also”
```

</div>

Like `DUP` for the search order. Usually used before a vocabulary (e.g., `also Forth`); the combined effect is to push the wordlist represented by the vocabulary on the search order.

<span id="index-Forth--_002d_002d--search_002dext"></span> <span id="index-Forth"></span> <span id="index-Forth-1"></span>

<div class="format">

``` format
Forth       –         search-ext       “Forth”
```

</div>

Replace the *wid* at the top of the search order with the *wid* associated with the word list `forth-wordlist`.

<span id="index-Only--_002d_002d--search_002dext"></span> <span id="index-Only"></span> <span id="index-Only-1"></span>

<div class="format">

``` format
Only       –         search-ext       “Only”
```

</div>

Set the search order to the implementation-defined minimum search order (for Gforth, this is the word list `Root`).

<span id="index-order--_002d_002d--search_002dext"></span> <span id="index-order"></span> <span id="index-order-1"></span>

<div class="format">

``` format
order       –         search-ext       “order”
```

</div>

Print the search order and the compilation word list. The word lists are printed in the order in which they are searched (which is reversed with respect to the conventional way of displaying stacks). The compilation word list is displayed last.

<span id="index-find--c_002daddr-_002d_002d-xt-_002b_002d1-_007c-c_002daddr-0--core_002csearch"></span> <span id="index-find"></span> <span id="index-find-1"></span>

<div class="format">

``` format
find       c-addr – xt +-1 | c-addr 0         core,search       “find”
```

</div>

Search all word lists in the current search order for the definition named by the counted string at *c-addr*. If the definition is not found, return 0. If the definition is found return 1 (if the definition has non-default compilation semantics) or -1 (if the definition has default compilation semantics). The *xt* returned in interpret state represents the interpretation semantics. The *xt* returned in compile state represented either the compilation semantics (for non-default compilation semantics) or the run-time semantics that the compilation semantics would `compile,` (for default compilation semantics). The ANS Forth standard does not specify clearly what the returned *xt* represents (and also talks about immediacy instead of non-default compilation semantics), so this word is questionable in portable programs. If non-portability is ok, `find-name` and friends are better (see [Name token](Name-token.html#Name-token)).

<span id="index-search_002dwordlist--c_002daddr-count-wid-_002d_002d-0-_007c-xt-_002b_002d1--search"></span> <span id="index-search_002dwordlist"></span> <span id="index-search_002dwordlist-1"></span>

<div class="format">

``` format
search-wordlist       c-addr count wid – 0 | xt +-1         search       “search-wordlist”
```

</div>

Search the word list identified by *wid* for the definition named by the string at *c-addr count*. If the definition is not found, return 0. If the definition is found return 1 (if the definition is immediate) or -1 (if the definition is not immediate) together with the *xt*. In Gforth, the *xt* returned represents the interpretation semantics. ANS Forth does not specify clearly what *xt* represents.

<span id="index-words--_002d_002d--tools"></span> <span id="index-words-1"></span> <span id="index-words-2"></span>

<div class="format">

``` format
words       –         tools       “words”
```

</div>

Display a list of all of the definitions in the word list at the top of the search order.

<span id="index-vlist--_002d_002d--gforth"></span> <span id="index-vlist"></span> <span id="index-vlist-1"></span>

<div class="format">

``` format
vlist       –         gforth       “vlist”
```

</div>

Old (pre-Forth-83) name for `WORDS`.

<span id="index-Root--_002d_002d--gforth"></span> <span id="index-Root"></span> <span id="index-Root-1"></span>

<div class="format">

``` format
Root       –         gforth       “Root”
```

</div>

Add the root wordlist to the search order stack. This vocabulary makes up the minimum search order and contains only a search-order words.

<span id="index-Vocabulary--_0022name_0022-_002d_002d--gforth"></span> <span id="index-Vocabulary"></span> <span id="index-Vocabulary-1"></span>

<div class="format">

``` format
Vocabulary       "name" –         gforth       “Vocabulary”
```

</div>

Create a definition "name" and associate a new word list with it. The run-time effect of "name" is to replace the *wid* at the top of the search order with the *wid* associated with the new word list.

<span id="index-seal--_002d_002d--gforth"></span> <span id="index-seal"></span> <span id="index-seal-1"></span>

<div class="format">

``` format
seal       –         gforth       “seal”
```

</div>

Remove all word lists from the search order stack other than the word list that is currently on the top of the search order stack.

<span id="index-vocs--_002d_002d--gforth"></span> <span id="index-vocs"></span> <span id="index-vocs-1"></span>

<div class="format">

``` format
vocs       –         gforth       “vocs”
```

</div>

List vocabularies and wordlists defined in the system.

<span id="index-current--_002d_002d-addr--gforth"></span> <span id="index-current"></span> <span id="index-current-1"></span>

<div class="format">

``` format
current       – addr         gforth       “current”
```

</div>

`Variable` – holds the *wid* of the compilation word list.

<span id="index-context--_002d_002d-addr--gforth"></span> <span id="index-context"></span> <span id="index-context-1"></span>

<div class="format">

``` format
context       – addr         gforth       “context”
```

</div>

`context` `@` is the *wid* of the word list at the top of the search order.

|                                                                                |  |  |
| :----------------------------------------------------------------------------- |  | :- |
| • [Vocabularies](Vocabularies.html#Vocabularies):                              |  |  |
| • [Why use word lists?](Why-use-word-lists_003f.html#Why-use-word-lists_003f): |  |  |
| • [Word list example](Word-list-example.html#Word-list-example):               |  |  |

-----

<div class="header">

Next: [Environmental Queries](Environmental-Queries.html#Environmental-Queries), Previous: [The Input Stream](The-Input-Stream.html#The-Input-Stream), Up: [Words](Words.html#Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
