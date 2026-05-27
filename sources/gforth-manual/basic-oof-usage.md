> Source: https://gforth.org/manual/Basic-OOF-Usage.html

<span id="Basic-OOF-Usage"></span>

<div class="header">

Next: [The OOF base class](The-OOF-base-class.html#The-OOF-base-class), Previous: [Properties of the OOF model](Properties-of-the-OOF-model.html#Properties-of-the-OOF-model), Up: [OOF](OOF.html#OOF)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Basic-oof_002efs-Usage"></span>

#### 5.23.4.2 Basic `oof.fs` Usage

<span id="index-oof_002efs-usage"></span>

This section uses the same example as for `objects` (see [Basic Objects Usage](Basic-Objects-Usage.html#Basic-Objects-Usage)).

You can define a class for graphical objects like this:

<span id="index-class-usage-1"></span> <span id="index-class_003b-usage"></span> <span id="index-method-usage"></span>

<div class="example">

``` example
object class graphical \ "object" is the parent class
  method draw ( x y -- )
class;
```

</div>

This code defines a class `graphical` with an operation `draw`. We can perform the operation `draw` on any `graphical` object, e.g.:

<div class="example">

``` example
100 100 t-rex draw
```

</div>

where `t-rex` is an object or object pointer, created with e.g. `graphical : t-rex`.

<span id="index-abstract-class-1"></span>

How do we create a graphical object? With the present definitions, we cannot create a useful graphical object. The class `graphical` describes graphical objects in general, but not any concrete graphical object type (C++ users would call it an *abstract class*); e.g., there is no method for the selector `draw` in the class `graphical`.

For concrete graphical objects, we define child classes of the class `graphical`, e.g.:

<div class="example">

``` example
graphical class circle \ "graphical" is the parent class
  cell var circle-radius
how:
  : draw ( x y -- )
    circle-radius @ draw-circle ;

  : init ( n-radius -- )
    circle-radius ! ;
class;
```

</div>

Here we define a class `circle` as a child of `graphical`, with a field `circle-radius`; it defines new methods for the selectors `draw` and `init` (`init` is defined in `object`, the parent class of `graphical`).

Now we can create a circle in the dictionary with:

<div class="example">

``` example
50 circle : my-circle
```

</div>

`:` invokes `init`, thus initializing the field `circle-radius` with 50. We can draw this new circle at (100,100) with:

<div class="example">

``` example
100 100 my-circle draw
```

</div>

<span id="index-selector-invocation_002c-restrictions-1"></span> <span id="index-class-definition_002c-restrictions-1"></span>

Note: You can only invoke a selector if the receiving object belongs to the class where the selector was defined or one of its descendents; e.g., you can invoke `draw` only for objects belonging to `graphical` or its descendents (e.g., `circle`). The scoping mechanism will check if you try to invoke a selector that is not defined in this class hierarchy, so you’ll get an error at compilation time.

-----

<div class="header">

Next: [The OOF base class](The-OOF-base-class.html#The-OOF-base-class), Previous: [Properties of the OOF model](Properties-of-the-OOF-model.html#Properties-of-the-OOF-model), Up: [OOF](OOF.html#OOF)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
