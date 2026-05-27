### 3.6 Stack Manipulation

> Source: https://gforth.org/manual/Stack-Manipulation-Tutorial.html

Stack manipulation words rearrange the data on the stack.

```
1 .s drop .s
1 .s dup .s drop drop .s
1 2 .s over .s drop drop drop
1 2 .s swap .s drop drop
1 2 3 .s rot .s drop drop drop
```

These are the most important stack manipulation words. There are also variants that manipulate twice as many stack items:

```
1 2 3 4 .s 2swap .s 2drop 2drop
```

Two more stack manipulation words are:

```
1 2 .s nip .s drop
1 2 .s tuck .s 2drop drop
```

Assignment: Replace `nip` and `tuck` with combinations of other stack manipulation words.

```
Given:          How do you get:
1 2 3           3 2 1
1 2 3           1 2 3 2
1 2 3           1 2 3 3
1 2 3           1 3 3
1 2 3           2 1 3
1 2 3 4         4 3 2 1
1 2 3           1 2 3 1 2 3
1 2 3 4         1 2 3 4 1 2
1 2 3
1 2 3           1 2 3 4
1 2 3           1 3
```

```
5 dup * .
```

Assignment: Write 17^3 and 17^4 in Forth, without writing `17` more than once. Write a piece of Forth code that expects two numbers on the stack (a and b, with b on top) and computes `(a-b)(a+1)`.

Reference: Stack Manipulation.
