> Source: https://gforth.org/manual/Stacks-and-Postfix-notation.html

<span id="Stacks-and-Postfix-notation"></span>

<div class="header">

Next: [Your first definition](Your-first-definition.html#Your-first-definition), Previous: [Introducing the Text Interpreter](Introducing-the-Text-Interpreter.html#Introducing-the-Text-Interpreter), Up: [Introduction](Introduction.html#Introduction)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Stacks_002c-postfix-notation-and-parameter-passing"></span>

### 4.2 Stacks, postfix notation and parameter passing

<span id="index-text-interpreter-1"></span> <span id="index-outer-interpreter-1"></span>

In procedural programming languages (like C and Pascal), the building-block of programs is the *function* or *procedure*. These functions or procedures are called with *explicit parameters*. For example, in C we might write:

<div class="example">

``` example
total = total + new_volume(length,height,depth);
```

</div>

where new\_volume is a function-call to another piece of code, and total, length, height and depth are all variables. length, height and depth are parameters to the function-call.

In Forth, the equivalent of the function or procedure is the *definition* and parameters are implicitly passed between definitions using a shared stack that is visible to the programmer. Although Forth does support variables, the existence of the stack means that they are used far less often than in most other programming languages. When the text interpreter encounters a number, it will place (*push*) it on the stack. There are several stacks (the actual number is implementation-dependent ...) and the particular stack used for any operation is implied unambiguously by the operation being performed. The stack used for all integer operations is called the *data stack* and, since this is the stack used most commonly, references to “the data stack” are often abbreviated to “the stack”.

The stacks have a last-in, first-out (LIFO) organisation. If you type:

<div class="example">

``` example
1 2 3RET  ok
```

</div>

Then this instructs the text interpreter to placed three numbers on the (data) stack. An analogy for the behaviour of the stack is to take a pack of playing cards and deal out the ace (1), 2 and 3 into a pile on the table. The 3 was the last card onto the pile (“last-in”) and if you take a card off the pile then, unless you’re prepared to fiddle a bit, the card that you take off will be the 3 (“first-out”). The number that will be first-out of the stack is called the *top of stack*, which <span id="index-TOS-definition"></span> is often abbreviated to *TOS*.

To understand how parameters are passed in Forth, consider the behaviour of the definition `+` (pronounced “plus”). You will not be surprised to learn that this definition performs addition. More precisely, it adds two numbers together and produces a result. Where does it get the two numbers from? It takes the top two numbers off the stack. Where does it place the result? On the stack. You can act out the behaviour of `+` with your playing cards like this:

  - Pick up two cards from the stack on the table
  - Stare at them intently and ask yourself “what *is* the sum of these two numbers”
  - Decide that the answer is 5
  - Shuffle the two cards back into the pack and find a 5
  - Put a 5 on the remaining ace that’s on the table.

If you don’t have a pack of cards handy but you do have Forth running, you can use the definition `.s` to show the current state of the stack, without affecting the stack. Type:

<div class="example">

``` example
clearstacks 1 2 3RET ok
.sRET <3> 1 2 3  ok
```

</div>

The text interpreter looks up the word `clearstacks` and executes it; it tidies up the stacks (data and floating point stack) and removes any entries that may have been left on them by earlier examples. The text interpreter pushes each of the three numbers in turn onto the stack. Finally, the text interpreter looks up the word `.s` and executes it. The effect of executing `.s` is to print the “\<3\>” (the total number of items on the stack) followed by a list of all the items on the stack; the item on the far right-hand side is the TOS.

You can now type:

<div class="example">

``` example
+ .sRET <2> 1 5  ok
```

</div>

which is correct; there are now 2 items on the stack and the result of the addition is 5.

If you’re playing with cards, try doing a second addition: pick up the two cards, work out that their sum is 6, shuffle them into the pack, look for a 6 and place that on the table. You now have just one item on the stack. What happens if you try to do a third addition? Pick up the first card, pick up the second card – ah\! There is no second card. This is called a *stack underflow* and consitutes an error. If you try to do the same thing with Forth it often reports an error (probably a Stack Underflow or an Invalid Memory Address error).

The opposite situation to a stack underflow is a *stack overflow*, which simply accepts that there is a finite amount of storage space reserved for the stack. To stretch the playing card analogy, if you had enough packs of cards and you piled the cards up on the table, you would eventually be unable to add another card; you’d hit the ceiling. Gforth allows you to set the maximum size of the stacks. In general, the only time that you will get a stack overflow is because a definition has a bug in it and is generating data on the stack uncontrollably.

There’s one final use for the playing card analogy. If you model your stack using a pack of playing cards, the maximum number of items on your stack will be 52 (I assume you didn’t use the Joker). The maximum *value* of any item on the stack is 13 (the King). In fact, the only possible numbers are positive integer numbers 1 through 13; you can’t have (for example) 0 or 27 or 3.52 or -2. If you change the way you think about some of the cards, you can accommodate different numbers. For example, you could think of the Jack as representing 0, the Queen as representing -1 and the King as representing -2. Your *range* remains unchanged (you can still only represent a total of 13 numbers) but the numbers that you can represent are -2 through 10.

In that analogy, the limit was the amount of information that a single stack entry could hold, and Forth has a similar limit. In Forth, the size of a stack entry is called a *cell*. The actual size of a cell is implementation dependent and affects the maximum value that a stack entry can hold. A Standard Forth provides a cell size of at least 16-bits, and most desktop systems use a cell size of 32-bits.

Forth does not do any type checking for you, so you are free to manipulate and combine stack items in any way you wish. A convenient way of treating stack items is as 2’s complement signed integers, and that is what Standard words like `+` do. Therefore you can type:

<div class="example">

``` example
-5 12 + .sRET <1> 7  ok
```

</div>

If you use numbers and definitions like `+` in order to turn Forth into a great big pocket calculator, you will realise that it’s rather different from a normal calculator. Rather than typing 2 + 3 = you had to type 2 3 + (ignore the fact that you had to use `.s` to see the result). The terminology used to describe this difference is to say that your calculator uses *Infix Notation* (parameters and operators are mixed) whilst Forth uses *Postfix Notation* (parameters and operators are separate), also called *Reverse Polish Notation*.

Whilst postfix notation might look confusing to begin with, it has several important advantages:

  - it is unambiguous
  - it is more concise
  - it fits naturally with a stack-based system

To examine these claims in more detail, consider these sums:

<div class="example">

``` example
6 + 5 * 4 =
4 * 5 + 6 =
```

</div>

If you’re just learning maths or your maths is very rusty, you will probably come up with the answer 44 for the first and 26 for the second. If you are a bit of a whizz at maths you will remember the *convention* that multiplication takes precendence over addition, and you’d come up with the answer 26 both times. To explain the answer 26 to someone who got the answer 44, you’d probably rewrite the first sum like this:

<div class="example">

``` example
6 + (5 * 4) =
```

</div>

If what you really wanted was to perform the addition before the multiplication, you would have to use parentheses to force it.

If you did the first two sums on a pocket calculator you would probably get the right answers, unless you were very cautious and entered them using these keystroke sequences:

6 + 5 = \* 4 = 4 \* 5 = + 6 =

Postfix notation is unambiguous because the order that the operators are applied is always explicit; that also means that parentheses are never required. The operators are *active* (the act of quoting the operator makes the operation occur) which removes the need for “=”.

The sum 6 + 5 \* 4 can be written (in postfix notation) in two equivalent ways:

<div class="example">

``` example
6 5 4 * +      or:
5 4 * 6 +
```

</div>

An important thing that you should notice about this notation is that the *order* of the numbers does not change; if you want to subtract 2 from 10 you type `10 2 -`.

The reason that Forth uses postfix notation is very simple to explain: it makes the implementation extremely simple, and it follows naturally from using the stack as a mechanism for passing parameters. Another way of thinking about this is to realise that all Forth definitions are *active*; they execute as they are encountered by the text interpreter. The result of this is that the syntax of Forth is trivially simple.

-----

<div class="header">

Next: [Your first definition](Your-first-definition.html#Your-first-definition), Previous: [Introducing the Text Interpreter](Introducing-the-Text-Interpreter.html#Introducing-the-Text-Interpreter), Up: [Introduction](Introduction.html#Introduction)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
