> Source: https://gforth.org/manual/CREATE.html

<span id="CREATE"></span>

<div class="header">

Next: [Variables](Variables.html#Variables), Previous: [Defining Words](Defining-Words.html#Defining-Words), Up: [Defining Words](Defining-Words.html#Defining-Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="CREATE-1"></span>

#### 5.9.1 `CREATE`

<span id="index-simple-defining-words"></span> <span id="index-defining-words_002c-simple"></span>

Defining words are used to create new entries in the dictionary. The simplest defining word is `CREATE`. `CREATE` is used like this:

<div class="example">

``` example
CREATE new-word1
```

</div>

`CREATE` is a parsing word, i.e., it takes an argument from the input stream (`new-word1` in our example). It generates a dictionary entry for `new-word1`. When `new-word1` is executed, all that it does is leave an address on the stack. The address represents the value of the data space pointer (`HERE`) at the time that `new-word1` was defined. Therefore, `CREATE` is a way of associating a name with the address of a region of memory.

<span id="index-Create--_0022name_0022-_002d_002d--core"></span> <span id="index-Create"></span> <span id="index-Create-1"></span>

<div class="format">

``` format
Create       "name" –         core       “Create”
```

</div>

Note that Standard Forth guarantees only for `create` that its body is in dictionary data space (i.e., where `here`, `allot` etc. work, see [Dictionary allocation](Dictionary-allocation.html#Dictionary-allocation)). Also, in Standard Forth only `create`d words can be modified with `does>` (see [User-defined Defining Words](User_002ddefined-Defining-Words.html#User_002ddefined-Defining-Words)). And in Standard Forth `>body` can only be applied to `create`d words.

By extending this example to reserve some memory in data space, we end up with something like a *variable*. Here are two different ways to do it:

<div class="example">

``` example
CREATE new-word2 1 cells allot  \ reserve 1 cell - initial value undefined
CREATE new-word3 4 ,            \ reserve 1 cell and initialise it (to 4)
```

</div>

The variable can be examined and modified using `@` (“fetch”) and `!` (“store”) like this:

<div class="example">

``` example
new-word2 @ .      \ get address, fetch from it and display
1234 new-word2 !   \ new value, get address, store to it
```

</div>

<span id="index-arrays"></span>

A similar mechanism can be used to create arrays. For example, an 80-character text input buffer:

<div class="example">

``` example
CREATE text-buf 80 chars allot

text-buf 0 chars + c@ \ the 1st character (offset 0)
text-buf 3 chars + c@ \ the 4th character (offset 3)
```

</div>

You can build arbitrarily complex data structures by allocating appropriate areas of memory. For further discussions of this, and to learn about some Gforth tools that make it easier, See [Structures](Structures.html#Structures).

-----

<div class="header">

Next: [Variables](Variables.html#Variables), Previous: [Defining Words](Defining-Words.html#Defining-Words), Up: [Defining Words](Defining-Words.html#Defining-Words)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
