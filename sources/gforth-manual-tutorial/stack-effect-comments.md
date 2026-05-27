### 3.11 Stack-Effect Comments

> Source: https://gforth.org/manual/Stack%5F002dEffect-Comments-Tutorial.html

By convention the comment after the name of a definition describes the stack effect: The part in front of the '--' describes the state of the stack before the execution of the definition, i.e., the parameters that are passed into the colon definition; the part behind the '--' is the state of the stack after the execution of the definition, i.e., the results of the definition. The stack comment only shows the top stack items that the definition accesses and/or changes.

You should put a correct stack effect on every definition, even if it is just `( -- )`. You should also add some descriptive comment to more complicated words (I usually do this in the lines following `:`). If you don't do this, your code becomes unreadable (because you have to work through every definition before you can understand any).

Assignment: The stack effect of `swap` can be written like this: `x1 x2 -- x2 x1`. Describe the stack effect of `-`, `drop`, `dup`, `over`, `rot`, `nip`, and `tuck`. Hint: When you are done, you can compare your stack effects to those in this manual (see Word Index).

Sometimes programmers put comments at various places in colon definitions that describe the contents of the stack at that place (stack comments); i.e., they are like the first part of a stack-effect comment. E.g.,

```
: cubed ( n -- n^3 )
   dup squared  ( n n^2 ) * ;
```

In this case the stack comment is pretty superfluous, because the word is simple enough. If you think it would be a good idea to add such a comment to increase readability, you should also consider factoring the word into several simpler words (see Factoring), which typically eliminates the need for the stack comment; however, if you decide not to refactor it, then having such a comment is better than not having it.

The names of the stack items in stack-effect and stack comments in the standard, in this manual, and in many programs specify the type through a type prefix, similar to Fortran and Hungarian notation. The most frequent prefixes are:

- `n` — signed integer
- `u` — unsigned integer
- `c` — character
- `f` — Boolean flags, i.e. `false` or `true`.
- `a-addr`, `a-` — Cell-aligned address
- `c-addr`, `c-` — Char-aligned address
- `xt` — Execution token, same size as Cell
- `w`, `x` — Cell, can contain an integer or an address
- `d` — signed double-cell integer
- `ud` — unsigned double-cell integer
- `r` — Float (on the FP stack)

You can find a more complete list in Notation.

Assignment: Write stack-effect comments for all definitions you have written up to now.
