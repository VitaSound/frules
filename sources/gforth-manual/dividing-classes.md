> Source: https://gforth.org/manual/Dividing-classes.html

<span id="Dividing-classes"></span>

<div class="header">

Next: [Object Interfaces](Object-Interfaces.html#Object-Interfaces), Previous: [Classes and Scoping](Classes-and-Scoping.html#Classes-and-Scoping), Up: [Objects](Objects.html#Objects)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Dividing-classes-1"></span>

#### 5.23.3.9 Dividing classes

<span id="index-Dividing-classes"></span> <span id="index-methods_002e_002e_002eend_002dmethods"></span>

You may want to do the definition of methods separate from the definition of the class, its selectors, fields, and instance variables, i.e., separate the implementation from the definition. You can do this in the following way:

<div class="example">

``` example
graphical class
  inst-value radius
end-class circle

... \ do some other stuff

circle methods \ now we are ready

m: ( x y circle -- )
  radius draw-circle ;m
overrides draw

m: ( n-radius circle -- )
  [to-inst] radius ;m
overrides construct

end-methods
```

</div>

You can use several `methods`...`end-methods` sections. The only things you can do to the class in these sections are: defining methods, and overriding the class’s selectors. You must not define new selectors or fields.

Note that you often have to override a selector before using it. In particular, you usually have to override `construct` with a new method before you can invoke `heap-new` and friends. E.g., you must not create a circle before the `overrides construct` sequence in the example above.
