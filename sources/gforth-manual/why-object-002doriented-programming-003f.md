> Source: https://gforth.org/manual/Why-object_002doriented-programming_003f.html

<span id="Why-object_002doriented-programming_003f"></span>

<div class="header">

Next: [Object-Oriented Terminology](Object_002dOriented-Terminology.html#Object_002dOriented-Terminology), Previous: [Object-oriented Forth](Object_002doriented-Forth.html#Object_002doriented-Forth), Up: [Object-oriented Forth](Object_002doriented-Forth.html#Object_002doriented-Forth)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Why-object_002doriented-programming_003f-1"></span>

#### 5.23.1 Why object-oriented programming?

<span id="index-object_002doriented-programming-motivation"></span> <span id="index-motivation-for-object_002doriented-programming"></span>

Often we have to deal with several data structures (*objects*), that have to be treated similarly in some respects, but differently in others. Graphical objects are the textbook example: circles, triangles, dinosaurs, icons, and others, and we may want to add more during program development. We want to apply some operations to any graphical object, e.g., `draw` for displaying it on the screen. However, `draw` has to do something different for every kind of object.

We could implement `draw` as a big `CASE` control structure that executes the appropriate code depending on the kind of object to be drawn. This would be not be very elegant, and, moreover, we would have to change `draw` every time we add a new kind of graphical object (say, a spaceship).

What we would rather do is: When defining spaceships, we would tell the system: “Here’s how you `draw` a spaceship; you figure out the rest”.

This is the problem that all systems solve that (rightfully) call themselves object-oriented; the object-oriented packages presented here solve this problem (and not much else).
