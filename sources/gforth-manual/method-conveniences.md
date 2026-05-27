> Source: https://gforth.org/manual/Method-conveniences.html

<span id="Method-conveniences"></span>

<div class="header">

Next: [Classes and Scoping](Classes-and-Scoping.html#Classes-and-Scoping), Previous: [Class Binding](Class-Binding.html#Class-Binding), Up: [Objects](Objects.html#Objects)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Method-conveniences-1"></span>

#### 5.23.3.7 Method conveniences

<span id="index-method-conveniences"></span>

In a method you usually access the receiving object pretty often. If you define the method as a plain colon definition (e.g., with `:noname`), you may have to do a lot of stack gymnastics. To avoid this, you can define the method with `m: ... ;m`. E.g., you could define the method for `draw`ing a `circle` with

<span id="index-this-usage"></span> <span id="index-m_003a-usage"></span> <span id="index-_003bm-usage"></span>

<div class="example">

``` example
m: ( x y circle -- )
  ( x y ) this circle-radius @ draw-circle ;m
```

</div>

<span id="index-exit-in-m_003a-_002e_002e_002e-_003bm"></span> <span id="index-exitm-discussion"></span> <span id="index-catch-in-m_003a-_002e_002e_002e-_003bm"></span>

When this method is executed, the receiver object is removed from the stack; you can access it with `this` (admittedly, in this example the use of `m: ... ;m` offers no advantage). Note that I specify the stack effect for the whole method (i.e. including the receiver object), not just for the code between `m:` and `;m`. You cannot use `exit` in `m:...;m`; instead, use `exitm`.[<sup>33</sup>](#FOOT33)

<span id="index-inst_002dvar-usage"></span>

You will frequently use sequences of the form `this field` (in the example above: `this circle-radius`). If you use the field only in this way, you can define it with `inst-var` and eliminate the `this` before the field name. E.g., the `circle` class above could also be defined with:

<div class="example">

``` example
graphical class
  cell% inst-var radius

m: ( x y circle -- )
  radius @ draw-circle ;m
overrides draw

m: ( n-radius circle -- )
  radius ! ;m
overrides construct

end-class circle
```

</div>

`radius` can only be used in `circle` and its descendent classes and inside `m:...;m`.

<span id="index-inst_002dvalue-usage"></span>

You can also define fields with `inst-value`, which is to `inst-var` what `value` is to `variable`. You can change the value of such a field with `[to-inst]`. E.g., we could also define the class `circle` like this:

<div class="example">

``` example
graphical class
  inst-value radius

m: ( x y circle -- )
  radius draw-circle ;m
overrides draw

m: ( n-radius circle -- )
  [to-inst] radius ;m
overrides construct

end-class circle
```

</div>

<div class="footnote">

-----

#### Footnotes

### [(33)](#DOCF33)

Moreover, for any word that calls `catch` and was defined before loading `objects.fs`, you have to redefine it like I redefined `catch`: `: catch this >r catch r> to-this ;`

</div>

-----

<div class="header">

Next: [Classes and Scoping](Classes-and-Scoping.html#Classes-and-Scoping), Previous: [Class Binding](Class-Binding.html#Class-Binding), Up: [Objects](Objects.html#Objects)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
