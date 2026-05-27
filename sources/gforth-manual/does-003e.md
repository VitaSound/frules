> Source: https://gforth.org/manual/DOES_003e.html

<span id="DOES_003e"></span>

<div class="header">

Previous: [Dynamic Superinstructions](Dynamic-Superinstructions.html#Dynamic-Superinstructions), Up: [Threading](Threading.html#Threading)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="DOES_003e-1"></span>

#### 14.2.4 DOES\>

<span id="index-DOES_003e-implementation"></span> <span id="index-dodoes-routine"></span> <span id="index-DOES_003e_002dcode"></span>

One of the most complex parts of a Forth engine is `dodoes`, i.e., the chunk of code executed by every word defined by a `CREATE`...`DOES>` pair; actually with primitive-centric code, this is only needed if the xt of the word is `execute`d. The main problem here is: How to find the Forth code to be executed, i.e. the code after the `DOES>` (the `DOES>`-code)? There are two solutions:

In fig-Forth the code field points directly to the `dodoes` and the `DOES>`-code address is stored in the cell after the code address (i.e. at `CFA cell+`). It may seem that this solution is illegal in the Forth-79 and all later standards, because in fig-Forth this address lies in the body (which is illegal in these standards). However, by making the code field larger for all words this solution becomes legal again. We use this approach. Leaving a cell unused in most words is a bit wasteful, but on the machines we are targeting this is hardly a problem.
