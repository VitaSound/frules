> Source: https://gforth.org/manual/Locals-implementation.html

<span id="Locals-implementation"></span>

<div class="header">

Previous: [Locals programming style](Locals-programming-style.html#Locals-programming-style), Up: [Gforth locals](Gforth-locals.html#Gforth-locals)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Locals-implementation-1"></span>

#### 5.21.1.4 Locals implementation

<span id="index-locals-implementation"></span> <span id="index-implementation-of-locals"></span> <span id="index-locals-stack-1"></span>

Gforth uses an extra locals stack. The most compelling reason for this is that the return stack is not float-aligned; using an extra stack also eliminates the problems and restrictions of using the return stack as locals stack. Like the other stacks, the locals stack grows toward lower addresses. A few primitives allow an efficient implementation:

<span id="index-_0040local_0023--_0023noffset-_002d_002d-w--gforth"></span> <span id="index-_0040local_0023"></span> <span id="index-_0040local_0023-1"></span>

<div class="format">

``` format
@local#       #noffset – w        gforth       “fetch-local-number”
```

</div>

<span id="index-f_0040local_0023--_0023noffset-_002d_002d-r--gforth"></span> <span id="index-f_0040local_0023"></span> <span id="index-f_0040local_0023-1"></span>

<div class="format">

``` format
f@local#       #noffset – r        gforth       “f-fetch-local-number”
```

</div>

<span id="index-laddr_0023--_0023noffset-_002d_002d-c_002daddr--gforth"></span> <span id="index-laddr_0023"></span> <span id="index-laddr_0023-1"></span>

<div class="format">

``` format
laddr#       #noffset – c-addr        gforth       “laddr-number”
```

</div>

<span id="index-lp_002b_0021_0023--_0023noffset-_002d_002d--gforth"></span> <span id="index-lp_002b_0021_0023"></span> <span id="index-lp_002b_0021_0023-1"></span>

<div class="format">

``` format
lp+!#       #noffset –        gforth       “lp-plus-store-number”
```

</div>

used with negative immediate values it allocates memory on the local stack, a positive immediate argument drops memory from the local stack

<span id="index-lp_0021--c_002daddr-_002d_002d--gforth-1"></span> <span id="index-lp_0021-1"></span> <span id="index-lp_0021-3"></span>

<div class="format">

``` format
lp!       c-addr –        gforth       “lp-store”
```

</div>

<span id="index-_003el--w-_002d_002d--gforth"></span> <span id="index-_003el"></span> <span id="index-_003el-1"></span>

<div class="format">

``` format
>l       w –        gforth       “to-l”
```

</div>

<span id="index-f_003el--r-_002d_002d--gforth"></span> <span id="index-f_003el"></span> <span id="index-f_003el-1"></span>

<div class="format">

``` format
f>l       r –        gforth       “f-to-l”
```

</div>

In addition to these primitives, some specializations of these primitives for commonly occurring inline arguments are provided for efficiency reasons, e.g., `@local0` as specialization of `@local#` for the inline argument 0. The following compiling words compile the right specialized version, or the general version, as appropriate:

<span id="index-compile_002dlp_002b_0021--n-_002d_002d--gforth"></span> <span id="index-compile_002dlp_002b_0021"></span> <span id="index-compile_002dlp_002b_0021-1"></span>

<div class="format">

``` format
compile-lp+!       n –         gforth       “compile-l-p-plus-store”
```

</div>

Combinations of conditional branches and `lp+!#` like `?branch-lp+!#` (the locals pointer is only changed if the branch is taken) are provided for efficiency and correctness in loops.

A special area in the dictionary space is reserved for keeping the local variable names. `{` switches the dictionary pointer to this area and `}` switches it back and generates the locals initializing code. `W:` etc. are normal defining words. This special area is cleared at the start of every colon definition.

<span id="index-word-list-for-defining-locals"></span>

A special feature of Gforth’s dictionary is used to implement the definition of locals without type specifiers: every word list (aka vocabulary) has its own methods for searching etc. (see [Word Lists](Word-Lists.html#Word-Lists)). For the present purpose we defined a word list with a special search method: When it is searched for a word, it actually creates that word using `W:`. `{` changes the search order to first search the word list containing `}`, `W:` etc., and then the word list for defining locals without type specifiers.

The lifetime rules support a stack discipline within a colon definition: The lifetime of a local is either nested with other locals lifetimes or it does not overlap them.

At `BEGIN`, `IF`, and `AHEAD` no code for locals stack pointer manipulation is generated. Between control structure words locals definitions can push locals onto the locals stack. `AGAIN` is the simplest of the other three control flow words. It has to restore the locals stack depth of the corresponding `BEGIN` before branching. The code looks like this:

<div class="format">

``` format
lp+!# current-locals-size - dest-locals-size
branch <begin>
```

</div>

`UNTIL` is a little more complicated: If it branches back, it must adjust the stack just like `AGAIN`. But if it falls through, the locals stack must not be changed. The compiler generates the following code:

<div class="format">

``` format
?branch-lp+!# <begin> current-locals-size - dest-locals-size
```

</div>

The locals stack pointer is only adjusted if the branch is taken.

`THEN` can produce somewhat inefficient code:

<div class="format">

``` format
lp+!# current-locals-size - orig-locals-size
<orig target>:
lp+!# orig-locals-size - new-locals-size
```

</div>

The second `lp+!#` adjusts the locals stack pointer from the level at the *orig* point to the level after the `THEN`. The first `lp+!#` adjusts the locals stack pointer from the current level to the level at the orig point, so the complete effect is an adjustment from the current level to the right level after the `THEN`.

<span id="index-locals-information-on-the-control_002dflow-stack"></span> <span id="index-control_002dflow-stack-items_002c-locals-information"></span>

In a conventional Forth implementation a dest control-flow stack entry is just the target address and an orig entry is just the address to be patched. Our locals implementation adds a word list to every orig or dest item. It is the list of locals visible (or assumed visible) at the point described by the entry. Our implementation also adds a tag to identify the kind of entry, in particular to differentiate between live and dead (reachable and unreachable) orig entries.

A few unusual operations have to be performed on locals word lists:

<span id="index-common_002dlist--list1-list2-_002d_002d-list3--unknown"></span> <span id="index-common_002dlist"></span> <span id="index-common_002dlist-1"></span>

<div class="format">

``` format
common-list       list1 list2 – list3         unknown       “common-list”
```

</div>

<span id="index-sub_002dlist_003f--list1-list2-_002d_002d-f--unknown"></span> <span id="index-sub_002dlist_003f"></span> <span id="index-sub_002dlist_003f-1"></span>

<div class="format">

``` format
sub-list?       list1 list2 – f         unknown       “sub-list?”
```

</div>

<span id="index-list_002dsize--list-_002d_002d-u--gforth_002dinternal"></span> <span id="index-list_002dsize"></span> <span id="index-list_002dsize-1"></span>

<div class="format">

``` format
list-size       list – u         gforth-internal       “list-size”
```

</div>

Several features of our locals word list implementation make these operations easy to implement: The locals word lists are organised as linked lists; the tails of these lists are shared, if the lists contain some of the same locals; and the address of a name is greater than the address of the names behind it in the list.

Another important implementation detail is the variable `dead-code`. It is used by `BEGIN` and `THEN` to determine if they can be reached directly or only through the branch that they resolve. `dead-code` is set by `UNREACHABLE`, `AHEAD`, `EXIT` etc., and cleared at the start of a colon definition, by `BEGIN` and usually by `THEN`.

Counted loops are similar to other loops in most respects, but `LEAVE` requires special attention: It performs basically the same service as `AHEAD`, but it does not create a control-flow stack entry. Therefore the information has to be stored elsewhere; traditionally, the information was stored in the target fields of the branches created by the `LEAVE`s, by organizing these fields into a linked list. Unfortunately, this clever trick does not provide enough space for storing our extended control flow information. Therefore, we introduce another stack, the leave stack. It contains the control-flow stack entries for all unresolved `LEAVE`s.

Local names are kept until the end of the colon definition, even if they are no longer visible in any control-flow path. In a few cases this may lead to increased space needs for the locals name area, but usually less than reclaiming this space would cost in code size.

-----

<div class="header">

Previous: [Locals programming style](Locals-programming-style.html#Locals-programming-style), Up: [Gforth locals](Gforth-locals.html#Gforth-locals)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
