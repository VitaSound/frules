> Source: https://gforth.org/manual/Review-_002d-elements-of-a-Forth-system.html

<span id="Review-_002d-elements-of-a-Forth-system"></span>

<div class="header">

Next: [Where to go next](Where-to-go-next.html#Where-to-go-next), Previous: [Forth is written in Forth](Forth-is-written-in-Forth.html#Forth-is-written-in-Forth), Up: [Introduction](Introduction.html#Introduction)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Review-_002d-elements-of-a-Forth-system-1"></span>

### 4.6 Review - elements of a Forth system

<span id="index-elements-of-a-Forth-system"></span>

To summarise this chapter:

  - Forth programs use *factoring* to break a problem down into small fragments called *words* or *definitions*.
  - Forth program development is an interactive process.
  - The main command loop that accepts input, and controls both interpretation and compilation, is called the *text interpreter* (also known as the *outer interpreter*).
  - Forth has a very simple syntax, consisting of words and numbers separated by spaces or carriage-return characters. Any additional syntax is imposed by *parsing words*.
  - Forth uses a stack to pass parameters between words. As a result, it uses postfix notation.
  - To use a word that has previously been defined, the text interpreter searches for the word in the *name dictionary*.
  - Words have *interpretation semantics* and *compilation semantics*.
  - The text interpreter uses the value of `state` to select between the use of the *interpretation semantics* and the *compilation semantics* of a word that it encounters.
  - The relationship between the *interpretation semantics* and *compilation semantics* for a word depends upon the way in which the word was defined (for example, whether it is an *immediate* word).
  - Forth definitions can be implemented in Forth (called *high-level definitions*) or in some other way (usually a lower-level language and as a result often called *low-level definitions*, *code definitions* or *primitives*).
  - Many Forth systems are implemented mainly in Forth.
