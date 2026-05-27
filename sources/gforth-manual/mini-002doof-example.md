> Source: https://gforth.org/manual/Mini_002dOOF-Example.html

<span id="Mini_002dOOF-Example"></span>

<div class="header">

Next: [Mini-OOF Implementation](Mini_002dOOF-Implementation.html#Mini_002dOOF-Implementation), Previous: [Basic Mini-OOF Usage](Basic-Mini_002dOOF-Usage.html#Basic-Mini_002dOOF-Usage), Up: [Mini-OOF](Mini_002dOOF.html#Mini_002dOOF)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Mini_002dOOF-Example-1"></span>

#### 5.23.5.2 Mini-OOF Example

<span id="index-mini_002doof-example"></span>

A short example shows how to use this package. This example, in slightly extended form, is supplied as `moof-exm.fs`

<div class="example">

``` example
object class
  method init
  method draw
end-class graphical
```

</div>

This code defines a class `graphical` with an operation `draw`. We can perform the operation `draw` on any `graphical` object, e.g.:

<div class="example">

``` example
100 100 t-rex draw
```

</div>

where `t-rex` is an object or object pointer, created with e.g. `graphical new Constant t-rex`.

For concrete graphical objects, we define child classes of the class `graphical`, e.g.:

<div class="example">

``` example
graphical class
  cell var circle-radius
end-class circle \ "graphical" is the parent class

:noname ( x y -- )
  circle-radius @ draw-circle ; circle defines draw
:noname ( r -- )
  circle-radius ! ; circle defines init
```

</div>

There is no implicit init method, so we have to define one. The creation code of the object now has to call init explicitely.

<div class="example">

``` example
circle new Constant my-circle
50 my-circle init
```

</div>

It is also possible to add a function to create named objects with automatic call of `init`, given that all objects have `init` on the same place:

<div class="example">

``` example
: new: ( .. o "name" -- )
    new dup Constant init ;
80 circle new: large-circle
```

</div>

We can draw this new circle at (100,100) with:

<div class="example">

``` example
100 100 my-circle draw
```

</div>
