> Source: https://gforth.org/manual/Class-Binding.html

<span id="Class-Binding"></span>

<div class="header">

Next: [Method conveniences](Method-conveniences.html#Method-conveniences), Previous: [Object-Oriented Programming Style](Object_002dOriented-Programming-Style.html#Object_002dOriented-Programming-Style), Up: [Objects](Objects.html#Objects)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Class-Binding-1"></span>

#### 5.23.3.6 Class Binding

<span id="index-class-binding"></span> <span id="index-early-binding"></span> <span id="index-late-binding"></span>

Normal selector invocations determine the method at run-time depending on the class of the receiving object. This run-time selection is called *late binding*.

Sometimes it’s preferable to invoke a different method. For example, you might want to use the simple method for `print`ing `object`s instead of the possibly long-winded `print` method of the receiver class. You can achieve this by replacing the invocation of `print` with:

<span id="index-_005bbind_005d-usage"></span>

<div class="example">

``` example
[bind] object print
```

</div>

in compiled code or:

<span id="index-bind-usage"></span>

<div class="example">

``` example
bind object print
```

</div>

<span id="index-class-binding_002c-alternative-to"></span>

in interpreted code. Alternatively, you can define the method with a name (e.g., `print-object`), and then invoke it through the name. Class binding is just a (often more convenient) way to achieve the same effect; it avoids name clutter and allows you to invoke methods directly without naming them first.

<span id="index-superclass-binding"></span> <span id="index-parent-class-binding"></span>

A frequent use of class binding is this: When we define a method for a selector, we often want the method to do what the selector does in the parent class, and a little more. There is a special word for this purpose: `[parent]`; `[parent] selector` is equivalent to `[bind] parent selector`, where `parent` is the parent class of the current class. E.g., a method definition might look like:

<span id="index-_005bparent_005d-usage"></span>

<div class="example">

``` example
:noname
  dup [parent] foo \ do parent's foo on the receiving object
  ... \ do some more
; overrides foo
```

</div>

<span id="index-class-binding-as-optimization"></span>

In Object-oriented programming in ANS Forth (Forth Dimensions, March 1997), Andrew McKewan presents class binding as an optimization technique. I recommend not using it for this purpose unless you are in an emergency. Late binding is pretty fast with this model anyway, so the benefit of using class binding is small; the cost of using class binding where it is not appropriate is reduced maintainability.

While we are at programming style questions: You should bind selectors only to ancestor classes of the receiving object. E.g., say, you know that the receiving object is of class `foo` or its descendents; then you should bind only to `foo` and its ancestors.

-----

<div class="header">

Next: [Method conveniences](Method-conveniences.html#Method-conveniences), Previous: [Object-Oriented Programming Style](Object_002dOriented-Programming-Style.html#Object_002dOriented-Programming-Style), Up: [Objects](Objects.html#Objects)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
