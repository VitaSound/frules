> Source: https://gforth.org/manual/Objects.html

<span id="Objects"></span>

<div class="header">

Next: [OOF](OOF.html#OOF), Previous: [Object-Oriented Terminology](Object_002dOriented-Terminology.html#Object_002dOriented-Terminology), Up: [Object-oriented Forth](Object_002doriented-Forth.html#Object_002doriented-Forth)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="The-objects_002efs-model"></span>

#### 5.23.3 The `objects.fs` model

<span id="index-objects"></span> <span id="index-object_002doriented-programming"></span> <span id="index-objects_002efs"></span> <span id="index-oof_002efs"></span>

This section describes the `objects.fs` package. This material also has been published in M. Anton Ertl, [Yet Another Forth Objects Package](http://www.complang.tuwien.ac.at/forth/objects/objects.html), Forth Dimensions 19(2), pages 37–43.

This section assumes that you have read [Structures](Structures.html#Structures).

The techniques on which this model is based have been used to implement the parser generator, Gray, and have also been used in Gforth for implementing the various flavours of word lists (hashed or not, case-sensitive or not, special-purpose word lists for locals etc.).

|                                                                                                                          |  |  |
| :----------------------------------------------------------------------------------------------------------------------- |  | :- |
| • [Properties of the Objects model](Properties-of-the-Objects-model.html#Properties-of-the-Objects-model):               |  |  |
| • [Basic Objects Usage](Basic-Objects-Usage.html#Basic-Objects-Usage):                                                   |  |  |
| • [The Objects base class](The-Objects-base-class.html#The-Objects-base-class):                                          |  |  |
| • [Creating objects](Creating-objects.html#Creating-objects):                                                            |  |  |
| • [Object-Oriented Programming Style](Object_002dOriented-Programming-Style.html#Object_002dOriented-Programming-Style): |  |  |
| • [Class Binding](Class-Binding.html#Class-Binding):                                                                     |  |  |
| • [Method conveniences](Method-conveniences.html#Method-conveniences):                                                   |  |  |
| • [Classes and Scoping](Classes-and-Scoping.html#Classes-and-Scoping):                                                   |  |  |
| • [Dividing classes](Dividing-classes.html#Dividing-classes):                                                            |  |  |
| • [Object Interfaces](Object-Interfaces.html#Object-Interfaces):                                                         |  |  |
| • [Objects Implementation](Objects-Implementation.html#Objects-Implementation):                                          |  |  |
| • [Objects Glossary](Objects-Glossary.html#Objects-Glossary):                                                            |  |  |

Marcel Hendrix provided helpful comments on this section.
