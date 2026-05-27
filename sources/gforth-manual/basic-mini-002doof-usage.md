> Source: https://gforth.org/manual/Basic-Mini_002dOOF-Usage.html

<span id="Basic-Mini_002dOOF-Usage"></span>

<div class="header">

Next: [Mini-OOF Example](Mini_002dOOF-Example.html#Mini_002dOOF-Example), Previous: [Mini-OOF](Mini_002dOOF.html#Mini_002dOOF), Up: [Mini-OOF](Mini_002dOOF.html#Mini_002dOOF)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Basic-mini_002doof_002efs-Usage"></span>

#### 5.23.5.1 Basic `mini-oof.fs` Usage

<span id="index-mini_002doof-usage"></span>

There is a base class (`class`, which allocates one cell for the object pointer) plus seven other words: to define a method, a variable, a class; to end a class, to resolve binding, to allocate an object and to compile a class method.

<span id="index-object--_002d_002d-a_002daddr--mini_002doof"></span> <span id="index-object-2"></span> <span id="index-object-4"></span>

<div class="format">

``` format
object       – a-addr         mini-oof       “object”
```

</div>

`object` is the base class of all objects.

<span id="index-method--m-v-_0022name_0022-_002d_002d-m_0027-v--mini_002doof"></span> <span id="index-method-3"></span> <span id="index-method-6"></span>

<div class="format">

``` format
method       m v "name" – m’ v         mini-oof       “method”
```

</div>

Define a selector.

<span id="index-var--m-v-size-_0022name_0022-_002d_002d-m-v_0027--mini_002doof"></span> <span id="index-var-1"></span> <span id="index-var-3"></span>

<div class="format">

``` format
var       m v size "name" – m v’         mini-oof       “var”
```

</div>

Define a variable with `size` bytes.

<span id="index-class--class-_002d_002d-class-selectors-vars--mini_002doof"></span> <span id="index-class-3"></span> <span id="index-class-6"></span>

<div class="format">

``` format
class       class – class selectors vars         mini-oof       “class”
```

</div>

Start the definition of a class.

<span id="index-end_002dclass--class-selectors-vars-_0022name_0022-_002d_002d--mini_002doof"></span> <span id="index-end_002dclass-1"></span> <span id="index-end_002dclass-3"></span>

<div class="format">

``` format
end-class       class selectors vars "name" –         mini-oof       “end-class”
```

</div>

End the definition of a class.

<span id="index-defines--xt-class-_0022name_0022-_002d_002d--mini_002doof"></span> <span id="index-defines"></span> <span id="index-defines-1"></span>

<div class="format">

``` format
defines       xt class "name" –         mini-oof       “defines”
```

</div>

Bind `xt` to the selector `name` in class `class`.

<span id="index-new--class-_002d_002d-o--mini_002doof"></span> <span id="index-new-1"></span> <span id="index-new-3"></span>

<div class="format">

``` format
new       class – o         mini-oof       “new”
```

</div>

Create a new incarnation of the class `class`.

<span id="index-_003a_003a--class-_0022name_0022-_002d_002d--mini_002doof"></span> <span id="index-_003a_003a-1"></span>

<div class="format">

``` format
::       class "name" –         mini-oof       “colon-colon”
```

</div>

Compile the method for the selector `name` of the class `class` (not immediate\!).
