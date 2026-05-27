> Source: https://gforth.org/manual/Properties-of-the-Objects-model.html

<span id="Properties-of-the-Objects-model"></span>

<div class="header">

Next: [Basic Objects Usage](Basic-Objects-Usage.html#Basic-Objects-Usage), Previous: [Objects](Objects.html#Objects), Up: [Objects](Objects.html#Objects)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Properties-of-the-objects_002efs-model"></span>

#### 5.23.3.1 Properties of the `objects.fs` model

<span id="index-objects_002efs-properties"></span>

  - It is straightforward to pass objects on the stack. Passing selectors on the stack is a little less convenient, but possible.
  - Objects are just data structures in memory, and are referenced by their address. You can create words for objects with normal defining words like `constant`. Likewise, there is no difference between instance variables that contain objects and those that contain other data.
  - Late binding is efficient and easy to use.
  - It avoids parsing, and thus avoids problems with state-smartness and reduced extensibility; for convenience there are a few parsing words, but they have non-parsing counterparts. There are also a few defining words that parse. This is hard to avoid, because all standard defining words parse (except `:noname`); however, such words are not as bad as many other parsing words, because they are not state-smart.
  - It does not try to incorporate everything. It does a few things and does them well (IMO). In particular, this model was not designed to support information hiding (although it has features that may help); you can use a separate package for achieving this.
  - It is layered; you don’t have to learn and use all features to use this model. Only a few features are necessary (see [Basic Objects Usage](Basic-Objects-Usage.html#Basic-Objects-Usage), see [The Objects base class](The-Objects-base-class.html#The-Objects-base-class), see [Creating objects](Creating-objects.html#Creating-objects).), the others are optional and independent of each other.
  - An implementation in Standard Forth is available.
