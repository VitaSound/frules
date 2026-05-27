> Source: https://gforth.org/manual/The-OOF-base-class.html

<span id="The-OOF-base-class"></span>

<div class="header">

Next: [Class Declaration](Class-Declaration.html#Class-Declaration), Previous: [Basic OOF Usage](Basic-OOF-Usage.html#Basic-OOF-Usage), Up: [OOF](OOF.html#OOF)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="The-oof_002efs-base-class"></span>

#### 5.23.4.3 The `oof.fs` base class

<span id="index-oof_002efs-base-class"></span>

When you define a class, you have to specify a parent class. So how do you start defining classes? There is one class available from the start: `object`. You have to use it as ancestor for all classes. It is the only class that has no parent. Classes are also objects, except that they don’t have instance variables; class manipulation such as inheritance or changing definitions of a class is handled through selectors of the class `object`.

`object` provides a number of selectors:

  - `class` for subclassing, `definitions` to add definitions later on, and `class?` to get type informations (is the class a subclass of the class passed on the stack?). <span id="index-class--_0022name_0022-_002d_002d--oof"></span> <span id="index-class-2"></span> <span id="index-class-5"></span>
    <div class="format">
    ``` format
    class       "name" –         oof       “class”
    ```
    </div>
    <span id="index-definitions--_002d_002d--oof"></span> <span id="index-definitions-1"></span> <span id="index-definitions-3"></span>
    <div class="format">
    ``` format
    definitions       –         oof       “definitions”
    ```
    </div>
    <span id="index-class_003f--o-_002d_002d-flag--oof"></span> <span id="index-class_003f"></span> <span id="index-class_003f-1"></span>
    <div class="format">
    ``` format
    class?       o – flag         oof       “class-query”
    ```
    </div>
  - `init` and `dispose` as constructor and destructor of the object. `init` is invocated after the object’s memory is allocated, while `dispose` also handles deallocation. Thus if you redefine `dispose`, you have to call the parent’s dispose with `super dispose`, too. <span id="index-init--_002e_002e_002e-_002d_002d--oof"></span> <span id="index-init"></span> <span id="index-init-1"></span>
    <div class="format">
    ``` format
    init       ... –         oof       “init”
    ```
    </div>
    <span id="index-dispose--_002d_002d--oof"></span> <span id="index-dispose"></span> <span id="index-dispose-1"></span>
    <div class="format">
    ``` format
    dispose       –         oof       “dispose”
    ```
    </div>
  - `new`, `new[]`, `:`, `ptr`, `asptr`, and `[]` to create named and unnamed objects and object arrays or object pointers. <span id="index-new--_002d_002d-o--oof"></span> <span id="index-new"></span> <span id="index-new-2"></span>
    <div class="format">
    ``` format
    new       – o         oof       “new”
    ```
    </div>
    <span id="index-new_005b_005d--n-_002d_002d-o--oof"></span> <span id="index-new_005b_005d"></span> <span id="index-new_005b_005d-1"></span>
    <div class="format">
    ``` format
    new[]       n – o         oof       “new-array”
    ```
    </div>
    <span id="index-_003a--_0022name_0022-_002d_002d--oof"></span> <span id="index-_003a-1"></span>
    <div class="format">
    ``` format
    :       "name" –         oof       “define”
    ```
    </div>
    <span id="index-ptr--_0022name_0022-_002d_002d--oof"></span> <span id="index-ptr"></span> <span id="index-ptr-2"></span>
    <div class="format">
    ``` format
    ptr       "name" –         oof       “ptr”
    ```
    </div>
    <span id="index-asptr--o-_0022name_0022-_002d_002d--oof"></span> <span id="index-asptr"></span> <span id="index-asptr-2"></span>
    <div class="format">
    ``` format
    asptr       o "name" –         oof       “asptr”
    ```
    </div>
    <span id="index-_005b_005d--n-_0022name_0022-_002d_002d--oof"></span> <span id="index-_005b_005d"></span> <span id="index-_005b_005d-1"></span>
    <div class="format">
    ``` format
    []       n "name" –         oof       “array”
    ```
    </div>
  - `::` and `super` for explicit scoping. You should use explicit scoping only for super classes or classes with the same set of instance variables. Explicitly-scoped selectors use early binding. <span id="index-_003a_003a--_0022name_0022-_002d_002d--oof"></span> <span id="index-_003a_003a"></span>
    <div class="format">
    ``` format
    ::       "name" –         oof       “scope”
    ```
    </div>
    <span id="index-super--_0022name_0022-_002d_002d--oof"></span> <span id="index-super"></span> <span id="index-super-1"></span>
    <div class="format">
    ``` format
    super       "name" –         oof       “super”
    ```
    </div>
  - `self` to get the address of the object <span id="index-self--_002d_002d-o--oof"></span> <span id="index-self"></span> <span id="index-self-1"></span>
    <div class="format">
    ``` format
    self       – o         oof       “self”
    ```
    </div>
  - `bind`, `bound`, `link`, and `is` to assign object pointers and instance defers. <span id="index-bind--o-_0022name_0022-_002d_002d--oof"></span> <span id="index-bind-1"></span> <span id="index-bind-3"></span>
    <div class="format">
    ``` format
    bind       o "name" –         oof       “bind”
    ```
    </div>
    <span id="index-bound--class-addr-_0022name_0022-_002d_002d--oof"></span> <span id="index-bound"></span> <span id="index-bound-1"></span>
    <div class="format">
    ``` format
    bound       class addr "name" –         oof       “bound”
    ```
    </div>
    <span id="index-link--_0022name_0022-_002d_002d-class-addr--oof"></span> <span id="index-link"></span> <span id="index-link-1"></span>
    <div class="format">
    ``` format
    link       "name" – class addr         oof       “link”
    ```
    </div>
    <span id="index-is--xt-_0022name_0022-_002d_002d--oof"></span> <span id="index-is"></span> <span id="index-is-1"></span>
    <div class="format">
    ``` format
    is       xt "name" –         oof       “is”
    ```
    </div>
  - `'` to obtain selector tokens, `send` to invocate selectors form the stack, and `postpone` to generate selector invocation code. <span id="index-_0027--_0022name_0022-_002d_002d-xt--oof"></span> <span id="index-_0027-1"></span> <span id="index-_0027-3"></span>
    <div class="format">
    ``` format
    '       "name" – xt         oof       “tick”
    ```
    </div>
    <span id="index-postpone--_0022name_0022-_002d_002d--oof"></span> <span id="index-postpone-1"></span> <span id="index-postpone-3"></span>
    <div class="format">
    ``` format
    postpone       "name" –         oof       “postpone”
    ```
    </div>
  - `with` and `endwith` to select the active object from the stack, and enable its scope. Using `with` and `endwith` also allows you to create code using selector `postpone` without being trapped by the state-smart objects. <span id="index-with--o-_002d_002d--oof"></span> <span id="index-with"></span> <span id="index-with-1"></span>
    <div class="format">
    ``` format
    with       o –         oof       “with”
    ```
    </div>
    <span id="index-endwith--_002d_002d--oof"></span> <span id="index-endwith"></span> <span id="index-endwith-1"></span>
    <div class="format">
    ``` format
    endwith       –         oof       “endwith”
    ```
    </div>

-----

<div class="header">

Next: [Class Declaration](Class-Declaration.html#Class-Declaration), Previous: [Basic OOF Usage](Basic-OOF-Usage.html#Basic-OOF-Usage), Up: [OOF](OOF.html#OOF)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
