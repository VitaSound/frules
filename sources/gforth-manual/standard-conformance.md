> Source: https://gforth.org/manual/Standard-conformance.html

<span id="Standard-conformance"></span>

<div class="header">

Next: [Standard vs Extensions](Standard-vs-Extensions.html#Standard-vs-Extensions), Previous: [Tools](Tools.html#Tools), Up: [Top](index.html#Top)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Standard-conformance-1"></span>

## 8 Standard conformance

<span id="index-Standard-conformance-of-Gforth"></span>

To the best of our knowledge, Gforth is a

ANS Forth System and a Forth-2012 System

  - providing the Core Extensions word set
  - providing the Block word set
  - providing the Block Extensions word set
  - providing the Double-Number word set
  - providing the Double-Number Extensions word set
  - providing the Exception word set
  - providing the Exception Extensions word set
  - providing the Facility word set
  - providing the Facility Extensions word set, except `EMIT?`
  - providing the File Access word set
  - providing the File Access Extensions word set
  - providing the Floating-Point word set
  - providing the Floating-Point Extensions word set
  - providing the Locals word set
  - providing the Locals Extensions word set
  - providing the Memory-Allocation word set
  - providing the Memory-Allocation Extensions word set
  - providing the Programming-Tools word set
  - providing the Programming-Tools Extensions word set, except `EDITOR` and `FORGET`
  - providing the Search-Order word set
  - providing the Search-Order Extensions word set
  - providing the String word set
  - providing the String Extensions word set
  - providing the Extended-Character wordset

Gforth has the following environmental restrictions:

<span id="index-environmental-restrictions"></span>

  - While processing the OS command line, if an exception is not caught, Gforth exits with a non-zero exit code instead of performing QUIT.
  - When an `throw` is performed after a `query`, Gforth does not always restore the input source specification in effect at the corresponding catch.

<span id="index-system-documentation"></span>

In addition, Standard Forth systems are required to document certain implementation choices. This chapter tries to meet these requirements. In many cases it gives a way to ask the system for the information instead of providing the information directly, in particular, if the information depends on the processor, the operating system or the installation options chosen, or if they are likely to change during the maintenance of Gforth.

|                                                                                                                                            |  |  |
| :----------------------------------------------------------------------------------------------------------------------------------------- |  | :- |
| • [The Core Words](The-Core-Words.html#The-Core-Words):                                                                                    |  |  |
| • [The optional Block word set](The-optional-Block-word-set.html#The-optional-Block-word-set):                                             |  |  |
| • [The optional Double Number word set](The-optional-Double-Number-word-set.html#The-optional-Double-Number-word-set):                     |  |  |
| • [The optional Exception word set](The-optional-Exception-word-set.html#The-optional-Exception-word-set):                                 |  |  |
| • [The optional Facility word set](The-optional-Facility-word-set.html#The-optional-Facility-word-set):                                    |  |  |
| • [The optional File-Access word set](The-optional-File_002dAccess-word-set.html#The-optional-File_002dAccess-word-set):                   |  |  |
| • [The optional Floating-Point word set](The-optional-Floating_002dPoint-word-set.html#The-optional-Floating_002dPoint-word-set):          |  |  |
| • [The optional Locals word set](The-optional-Locals-word-set.html#The-optional-Locals-word-set):                                          |  |  |
| • [The optional Memory-Allocation word set](The-optional-Memory_002dAllocation-word-set.html#The-optional-Memory_002dAllocation-word-set): |  |  |
| • [The optional Programming-Tools word set](The-optional-Programming_002dTools-word-set.html#The-optional-Programming_002dTools-word-set): |  |  |
| • [The optional Search-Order word set](The-optional-Search_002dOrder-word-set.html#The-optional-Search_002dOrder-word-set):                |  |  |

-----

<div class="header">

Next: [Standard vs Extensions](Standard-vs-Extensions.html#Standard-vs-Extensions), Previous: [Tools](Tools.html#Tools), Up: [Top](index.html#Top)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
