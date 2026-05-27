> Source: https://gforth.org/manual/Basic-Objects-Usage.html

<span id="Basic-Objects-Usage"></span>

<div class="header">

Next: [The Objects base class](The-Objects-base-class.html#The-Objects-base-class), Previous: [Properties of the Objects model](Properties-of-the-Objects-model.html#Properties-of-the-Objects-model), Up: [Objects](Objects.html#Objects)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Basic-objects_002efs-Usage"></span>

#### 5.23.3.2 Basic `objects.fs` Usage

<span id="index-basic-objects-usage"></span> <span id="index-objects_002c-basic-usage"></span>

You can define a class for graphical objects like this:

<span id="index-class-usage"></span> <span id="index-end_002dclass-usage"></span> <span id="index-selector-usage"></span>

<div class="example">

``` example
object class \ "object" is the parent class
  selector draw ( x y graphical -- )
end-class graphical
```

</div>

This code defines a class `graphical` with an operation `draw`. We can perform the operation `draw` on any `graphical` object, e.g.:

<div class="example">

``` example
100 100 t-rex draw
```

</div>

where `t-rex` is a word (say, a constant) that produces a graphical object.

<span id="index-abstract-class"></span>

How do we create a graphical object? With the present definitions, we cannot create a useful graphical object. The class `graphical` describes graphical objects in general, but not any concrete graphical object type (C++ users would call it an *abstract class*); e.g., there is no method for the selector `draw` in the class `graphical`.

For concrete graphical objects, we define child classes of the class `graphical`, e.g.:

<span id="index-overrides-usage"></span> <span id="index-field-usage-in-class-definition"></span>

<div class="example">

``` example
graphical class \ "graphical" is the parent class
  cell% field circle-radius

:noname ( x y circle -- )
  circle-radius @ draw-circle ;
overrides draw

:noname ( n-radius circle -- )
  circle-radius ! ;
overrides construct

end-class circle
```

</div>

Here we define a class `circle` as a child of `graphical`, with field `circle-radius` (which behaves just like a field (see [Structures](Structures.html#Structures)); it defines (using `overrides`) new methods for the selectors `draw` and `construct` (`construct` is defined in `object`, the parent class of `graphical`).

Now we can create a circle on the heap (i.e., `allocate`d memory) with:

<span id="index-heap_002dnew-usage"></span>

<div class="example">

``` example
50 circle heap-new constant my-circle
```

</div>

`heap-new` invokes `construct`, thus initializing the field `circle-radius` with 50. We can draw this new circle at (100,100) with:

<div class="example">

``` example
100 100 my-circle draw
```

</div>

<span id="index-selector-invocation_002c-restrictions"></span> <span id="index-class-definition_002c-restrictions"></span>

Note: You can only invoke a selector if the object on the TOS (the receiving object) belongs to the class where the selector was defined or one of its descendents; e.g., you can invoke `draw` only for objects belonging to `graphical` or its descendents (e.g., `circle`). Immediately before `end-class`, the search order has to be the same as immediately after `class`.

-----

<div class="header">

Next: [The Objects base class](The-Objects-base-class.html#The-Objects-base-class), Previous: [Properties of the Objects model](Properties-of-the-Objects-model.html#Properties-of-the-Objects-model), Up: [Objects](Objects.html#Objects)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
