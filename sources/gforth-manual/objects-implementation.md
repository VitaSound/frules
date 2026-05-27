> Source: https://gforth.org/manual/Objects-Implementation.html

<span id="Objects-Implementation"></span>

<div class="header">

Next: [Objects Glossary](Objects-Glossary.html#Objects-Glossary), Previous: [Object Interfaces](Object-Interfaces.html#Object-Interfaces), Up: [Objects](Objects.html#Objects)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="objects_002efs-Implementation"></span>

#### 5.23.3.11 `objects.fs` Implementation

<span id="index-objects_002efs-implementation"></span> <span id="index-object_002dmap-discussion"></span>

An object is a piece of memory, like one of the data structures described with `struct...end-struct`. It has a field `object-map` that points to the method map for the object’s class.

<span id="index-method-map"></span> <span id="index-virtual-function-table"></span>

The *method map*[<sup>34</sup>](#FOOT34) is an array that contains the execution tokens (*xt*s) of the methods for the object’s class. Each selector contains an offset into a method map.

<span id="index-selector-implementation_002c-class"></span>

`selector` is a defining word that uses `CREATE` and `DOES>`. The body of the selector contains the offset; the `DOES>` action for a class selector is, basically:

<div class="example">

``` example
( object addr ) @ over object-map @ + @ execute
```

</div>

Since `object-map` is the first field of the object, it does not generate any code. As you can see, calling a selector has a small, constant cost.

<span id="index-current_002dinterface-discussion"></span> <span id="index-class-implementation-and-representation"></span>

A class is basically a `struct` combined with a method map. During the class definition the alignment and size of the class are passed on the stack, just as with `struct`s, so `field` can also be used for defining class fields. However, passing more items on the stack would be inconvenient, so `class` builds a data structure in memory, which is accessed through the variable `current-interface`. After its definition is complete, the class is represented on the stack by a pointer (e.g., as parameter for a child class definition).

A new class starts off with the alignment and size of its parent, and a copy of the parent’s method map. Defining new fields extends the size and alignment; likewise, defining new selectors extends the method map. `overrides` just stores a new *xt* in the method map at the offset given by the selector.

<span id="index-class-binding_002c-implementation"></span>

Class binding just gets the *xt* at the offset given by the selector from the class’s method map and `compile,`s (in the case of `[bind]`) it.

<span id="index-this-implementation"></span> <span id="index-catch-and-this"></span> <span id="index-this-and-catch"></span>

I implemented `this` as a `value`. At the start of an `m:...;m` method the old `this` is stored to the return stack and restored at the end; and the object on the TOS is stored `TO this`. This technique has one disadvantage: If the user does not leave the method via `;m`, but via `throw` or `exit`, `this` is not restored (and `exit` may crash). To deal with the `throw` problem, I have redefined `catch` to save and restore `this`; the same should be done with any word that can catch an exception. As for `exit`, I simply forbid it (as a replacement, there is `exitm`).

<span id="index-inst_002dvar-implementation"></span>

`inst-var` is just the same as `field`, with a different `DOES>` action:

<div class="example">

``` example
@ this +
```

</div>

Similar for `inst-value`.

<span id="index-class-scoping-implementation"></span>

Each class also has a word list that contains the words defined with `inst-var` and `inst-value`, and its protected words. It also has a pointer to its parent. `class` pushes the word lists of the class and all its ancestors onto the search order stack, and `end-class` drops them.

<span id="index-interface-implementation"></span>

An interface is like a class without fields, parent and protected words; i.e., it just has a method map. If a class implements an interface, its method map contains a pointer to the method map of the interface. The positive offsets in the map are reserved for class methods, therefore interface map pointers have negative offsets. Interfaces have offsets that are unique throughout the system, unlike class selectors, whose offsets are only unique for the classes where the selector is available (invokable).

This structure means that interface selectors have to perform one indirection more than class selectors to find their method. Their body contains the interface map pointer offset in the class method map, and the method offset in the interface method map. The `does>` action for an interface selector is, basically:

<div class="example">

``` example
( object selector-body )
2dup selector-interface @ ( object selector-body object interface-offset )
swap object-map @ + @ ( object selector-body map )
swap selector-offset @ + @ execute
```

</div>

where `object-map` and `selector-offset` are first fields and generate no code.

As a concrete example, consider the following code:

<div class="example">

``` example
interface
  selector if1sel1
  selector if1sel2
end-interface if1

object class
  if1 implementation
  selector cl1sel1
  cell% inst-var cl1iv1

' m1 overrides construct
' m2 overrides if1sel1
' m3 overrides if1sel2
' m4 overrides cl1sel2
end-class cl1

create obj1 object dict-new drop
create obj2 cl1    dict-new drop
```

</div>

The data structure created by this code (including the data structure for `object`) is shown in the [figure](objects-implementation.eps), assuming a cell size of 4.

<div class="footnote">

-----

#### Footnotes

### [(34)](#DOCF34)

This is Self terminology; in C++ terminology: virtual function table.

</div>

-----

<div class="header">

Next: [Objects Glossary](Objects-Glossary.html#Objects-Glossary), Previous: [Object Interfaces](Object-Interfaces.html#Object-Interfaces), Up: [Objects](Objects.html#Objects)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
