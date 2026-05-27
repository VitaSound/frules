> Source: https://gforth.org/manual/Where-to-go-next.html

<span id="Where-to-go-next"></span>

<div class="header">

Next: [Exercises](Exercises.html#Exercises), Previous: [Review - elements of a Forth system](Review-_002d-elements-of-a-Forth-system.html#Review-_002d-elements-of-a-Forth-system), Up: [Introduction](Introduction.html#Introduction)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Where-To-Go-Next"></span>

### 4.7 Where To Go Next

<span id="index-where-to-go-next"></span>

Amazing as it may seem, if you have read (and understood) this far, you know almost all the fundamentals about the inner workings of a Forth system. You certainly know enough to be able to read and understand the rest of this manual and the Standard Forth document, to learn more about the facilities that Forth in general and Gforth in particular provide. Even scarier, you know almost enough to implement your own Forth system. However, that’s not a good idea just yet... better to try writing some programs in Gforth.

Forth has such a rich vocabulary that it can be hard to know where to start in learning it. This section suggests a few sets of words that are enough to write small but useful programs. Use the word index in this document to learn more about each word, then try it out and try to write small definitions using it. Start by experimenting with these words:

  - Arithmetic: `+ - * / /MOD */ ABS INVERT`
  - Comparison: `MIN MAX =`
  - Logic: `AND OR XOR NOT`
  - Stack manipulation: `DUP DROP SWAP OVER`
  - Loops and decisions: `IF ELSE ENDIF ?DO I LOOP`
  - Input/Output: `. ." EMIT CR KEY`
  - Defining words: `: ; CREATE`
  - Memory allocation words: `ALLOT ,`
  - Tools: `SEE WORDS .S MARKER`

When you have mastered those, go on to:

  - More defining words: `VARIABLE CONSTANT VALUE TO CREATE DOES>`
  - Memory access: `@ !`

When you have mastered these, there’s nothing for it but to read through the whole of this manual and find out what you’ve missed.

-----

<div class="header">

Next: [Exercises](Exercises.html#Exercises), Previous: [Review - elements of a Forth system](Review-_002d-elements-of-a-Forth-system.html#Review-_002d-elements-of-a-Forth-system), Up: [Introduction](Introduction.html#Introduction)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
