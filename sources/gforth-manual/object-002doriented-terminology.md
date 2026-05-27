> Source: https://gforth.org/manual/Object_002dOriented-Terminology.html

<span id="Object_002dOriented-Terminology"></span>

<div class="header">

Next: [Objects](Objects.html#Objects), Previous: [Why object-oriented programming?](Why-object_002doriented-programming_003f.html#Why-object_002doriented-programming_003f), Up: [Object-oriented Forth](Object_002doriented-Forth.html#Object_002doriented-Forth)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Object_002dOriented-Terminology-1"></span>

#### 5.23.2 Object-Oriented Terminology

<span id="index-object_002doriented-terminology"></span> <span id="index-terminology-for-object_002doriented-programming"></span>

This section is mainly for reference, so you don’t have to understand all of it right away. The terminology is mainly Smalltalk-inspired. In short:

<span id="index-class"></span>

*class*

a data structure definition with some extras.

<span id="index-object"></span>

*object*

an instance of the data structure described by the class definition.

<span id="index-instance-variables"></span>

*instance variables*

fields of the data structure.

<span id="index-selector"></span> <span id="index-method-selector"></span> <span id="index-virtual-function"></span>

*selector*

(or *method selector*) a word (e.g., `draw`) that performs an operation on a variety of data structures (classes). A selector describes *what* operation to perform. In C++ terminology: a (pure) virtual function.

<span id="index-method"></span>

*method*

the concrete definition that performs the operation described by the selector for a specific class. A method specifies *how* the operation is performed for a specific class.

<span id="index-selector-invocation"></span> <span id="index-message-send"></span> <span id="index-invoking-a-selector"></span>

*selector invocation*

a call of a selector. One argument of the call (the TOS (top-of-stack)) is used for determining which method is used. In Smalltalk terminology: a message (consisting of the selector and the other arguments) is sent to the object.

<span id="index-receiving-object"></span>

*receiving object*

the object used for determining the method executed by a selector invocation. In the `objects.fs` model, it is the object that is on the TOS when the selector is invoked. (*Receiving* comes from the Smalltalk *message* terminology.)

<span id="index-child-class"></span> <span id="index-parent-class"></span> <span id="index-inheritance"></span>

*child class*

a class that has (*inherits*) all properties (instance variables, selectors, methods) from a *parent class*. In Smalltalk terminology: The subclass inherits from the superclass. In C++ terminology: The derived class inherits from the base class.

-----

<div class="header">

Next: [Objects](Objects.html#Objects), Previous: [Why object-oriented programming?](Why-object_002doriented-programming_003f.html#Why-object_002doriented-programming_003f), Up: [Object-oriented Forth](Object_002doriented-Forth.html#Object_002doriented-Forth)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
