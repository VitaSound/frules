> Source: https://gforth.org/manual/search_002dambcond.html

<span id="search_002dambcond"></span>

<div class="header">

Previous: [search-idef](search_002didef.html#search_002didef), Up: [The optional Search-Order word set](The-optional-Search_002dOrder-word-set.html#The-optional-Search_002dOrder-word-set)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Ambiguous-conditions-8"></span>

#### 8.11.2 Ambiguous conditions

<span id="index-search_002dorder-words_002c-ambiguous-conditions"></span> <span id="index-ambiguous-conditions_002c-search_002dorder-words"></span>

  - *changing the compilation word list (during compilation):*  
    <span id="index-changing-the-compilation-word-list-_0028during-compilation_0029"></span> <span id="index-compilation-word-list_002c-change-before-definition-ends"></span>
    
    The word is entered into the word list that was the compilation word list at the start of the definition. Any changes to the name field (e.g., `immediate`) or the code field (e.g., when executing `DOES>`) are applied to the latest defined word (as reported by `latest` or `latestxt`), if possible, irrespective of the compilation word list.

  - *search order empty (`previous`):*  
    <span id="index-previous_002c-search-order-empty"></span> <span id="index-vocstack-empty_002c-previous"></span>
    
    `abort" Vocstack empty"`.

  - *too many word lists in search order (`also`):*  
    <span id="index-also_002c-too-many-word-lists-in-search-order"></span> <span id="index-vocstack-full_002c-also"></span>
    
    `abort" Vocstack full"`.
