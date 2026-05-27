> Source: https://gforth.org/manual/Object_002dOriented-Programming-Style.html

<span id="Object_002dOriented-Programming-Style"></span>

<div class="header">

Next: [Class Binding](Class-Binding.html#Class-Binding), Previous: [Creating objects](Creating-objects.html#Creating-objects), Up: [Objects](Objects.html#Objects)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Object_002dOriented-Programming-Style-1"></span>

#### 5.23.3.5 Object-Oriented Programming Style

<span id="index-object_002doriented-programming-style"></span> <span id="index-programming-style_002c-object_002doriented"></span>

This section is not exhaustive.

<span id="index-stack-effects-of-selectors"></span> <span id="index-selectors-and-stack-effects"></span>

In general, it is a good idea to ensure that all methods for the same selector have the same stack effect: when you invoke a selector, you often have no idea which method will be invoked, so, unless all methods have the same stack effect, you will not know the stack effect of the selector invocation.

One exception to this rule is methods for the selector `construct`. We know which method is invoked, because we specify the class to be constructed at the same place. Actually, I defined `construct` as a selector only to give the users a convenient way to specify initialization. The way it is used, a mechanism different from selector invocation would be more natural (but probably would take more code and more space to explain).
