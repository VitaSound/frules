> Source: https://gforth.org/manual/Properties-of-the-OOF-model.html

<span id="Properties-of-the-OOF-model"></span>

<div class="header">

Next: [Basic OOF Usage](Basic-OOF-Usage.html#Basic-OOF-Usage), Previous: [OOF](OOF.html#OOF), Up: [OOF](OOF.html#OOF)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Properties-of-the-oof_002efs-model"></span>

#### 5.23.4.1 Properties of the `oof.fs` model

<span id="index-oof_002efs-properties"></span>

  - This model combines object oriented programming with information hiding. It helps you writing large application, where scoping is necessary, because it provides class-oriented scoping.
  - Named objects, object pointers, and object arrays can be created, selector invocation uses the “object selector” syntax. Selector invocation to objects and/or selectors on the stack is a bit less convenient, but possible.
  - Selector invocation and instance variable usage of the active object is straightforward, since both make use of the active object.
  - Late binding is efficient and easy to use.
  - State-smart objects parse selectors. However, extensibility is provided using a (parsing) selector `postpone` and a selector `'`.
  - An implementation in Standard Forth is available.
