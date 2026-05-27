> Source: https://gforth.org/manual/Calls-and-returns.html

<span id="Calls-and-returns"></span>

<div class="header">

Next: [Exception Handling](Exception-Handling.html#Exception-Handling), Previous: [Arbitrary control structures](Arbitrary-control-structures.html#Arbitrary-control-structures), Up: [Control Structures](Control-Structures.html#Control-Structures)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Calls-and-returns-1"></span>

#### 5.8.7 Calls and returns

<span id="index-calling-a-definition"></span> <span id="index-returning-from-a-definition"></span> <span id="index-recursive-definitions"></span>

A definition can be called simply be writing the name of the definition to be called. Normally a definition is invisible during its own definition. If you want to write a directly recursive definition, you can use `recursive` to make the current definition visible, or `recurse` to call the current definition directly.

<span id="index-recursive--compilation-_002d_002d-_003b-run_002dtime-_002d_002d--gforth"></span> <span id="index-recursive"></span> <span id="index-recursive-1"></span>

<div class="format">

``` format
recursive       compilation – ; run-time –         gforth       “recursive”
```

</div>

Make the current definition visible, enabling it to call itself recursively.

<span id="index-recurse---unknown"></span> <span id="index-recurse"></span> <span id="index-recurse-1"></span>

<div class="format">

``` format
recurse              unknown       “recurse”
```

</div>

Alias to the current definition.

> Programming style note: I prefer using `recursive` to `recurse`, because calling the definition by name is more descriptive (if the name is well-chosen) than the somewhat cryptic `recurse`. E.g., in a quicksort implementation, it is much better to read (and think) “now sort the partitions” than to read “now do a recursive call”.

For mutual recursion, use `Defer`red words, like this:

<div class="example">

``` example
Defer foo

: bar ( ... -- ... )
 ... foo ... ;

:noname ( ... -- ... )
 ... bar ... ;
IS foo
```

</div>

Deferred words are discussed in more detail in [Deferred Words](Deferred-Words.html#Deferred-Words).

The current definition returns control to the calling definition when the end of the definition is reached or `EXIT` is encountered.

<span id="index-EXIT--compilation-_002d_002d-_003b-run_002dtime-nest_002dsys-_002d_002d--core"></span> <span id="index-EXIT"></span> <span id="index-EXIT-1"></span>

<div class="format">

``` format
EXIT       compilation – ; run-time nest-sys –         core       “EXIT”
```

</div>

Return to the calling definition; usually used as a way of forcing an early return from a definition. Before `EXIT`ing you must clean up the return stack and `UNLOOP` any outstanding `?DO`...`LOOP`s. Use `;s` for a tickable word that behaves like `exit` in the absence of locals.

<span id="index-_003bs--R_003aw-_002d_002d--gforth"></span> <span id="index-_003bs"></span> <span id="index-_003bs-1"></span>

<div class="format">

``` format
;s       R:w –        gforth       “semis”
```

</div>

The primitive compiled by `EXIT`.

-----

<div class="header">

Next: [Exception Handling](Exception-Handling.html#Exception-Handling), Previous: [Arbitrary control structures](Arbitrary-control-structures.html#Arbitrary-control-structures), Up: [Control Structures](Control-Structures.html#Control-Structures)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
