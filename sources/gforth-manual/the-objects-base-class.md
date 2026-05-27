> Source: https://gforth.org/manual/The-Objects-base-class.html

<span id="The-Objects-base-class"></span>

<div class="header">

Next: [Creating objects](Creating-objects.html#Creating-objects), Previous: [Basic Objects Usage](Basic-Objects-Usage.html#Basic-Objects-Usage), Up: [Objects](Objects.html#Objects)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="The-object_002efs-base-class"></span>

#### 5.23.3.3 The `object.fs` base class

<span id="index-object-class"></span>

When you define a class, you have to specify a parent class. So how do you start defining classes? There is one class available from the start: `object`. It is ancestor for all classes and so is the only class that has no parent. It has two selectors: `construct` and `print`.
