> Source: https://gforth.org/manual/Structure-Naming-Convention.html

<span id="Structure-Naming-Convention"></span>

<div class="header">

Next: [Structure Implementation](Structure-Implementation.html#Structure-Implementation), Previous: [Structure Usage](Structure-Usage.html#Structure-Usage), Up: [Structures](Structures.html#Structures)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Structure-Naming-Convention-1"></span>

#### 5.22.3 Structure Naming Convention

<span id="index-structure-naming-convention"></span>

The field names that come to (my) mind are often quite generic, and, if used, would cause frequent name clashes. E.g., many structures probably contain a `counter` field. The structure names that come to (my) mind are often also the logical choice for the names of words that create such a structure.

Therefore, I have adopted the following naming conventions:

  - <span id="index-field-naming-convention"></span> The names of fields are of the form `struct-field`, where `struct` is the basic name of the structure, and `field` is the basic name of the field. You can think of field words as converting the (address of the) structure into the (address of the) field.
  - <span id="index-structure-naming-convention-1"></span> The names of structures are of the form `struct%`, where `struct` is the basic name of the structure.

This naming convention does not work that well for fields of extended structures; e.g., the integer list structure has a field `intlist-int`, but has `list-next`, not `intlist-next`.
