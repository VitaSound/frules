> Source: https://gforth.org/manual/Class-Declaration.html

<span id="Class-Declaration"></span>

<div class="header">

Next: [Class Implementation](Class-Implementation.html#Class-Implementation), Previous: [The OOF base class](The-OOF-base-class.html#The-OOF-base-class), Up: [OOF](OOF.html#OOF)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Class-Declaration-1"></span>

#### 5.23.4.4 Class Declaration

<span id="index-class-declaration"></span>

  - Instance variables <span id="index-var--size-_002d_002d--oof"></span> <span id="index-var"></span> <span id="index-var-2"></span>
    
    <div class="format">
    
    ``` format
    var       size –         oof       “var”
    ```
    
    </div>
    
    Create an instance variable

  - Object pointers <span id="index-ptr--_002d_002d--oof"></span> <span id="index-ptr-1"></span> <span id="index-ptr-3"></span>
    
    <div class="format">
    
    ``` format
    ptr       –         oof       “ptr”
    ```
    
    </div>
    
    Create an instance pointer
    
    <span id="index-asptr--class-_002d_002d--oof"></span> <span id="index-asptr-1"></span> <span id="index-asptr-3"></span>
    
    <div class="format">
    
    ``` format
    asptr       class –         oof       “asptr”
    ```
    
    </div>
    
    Create an alias to an instance pointer, cast to another class.

  - Instance defers <span id="index-defer--_002d_002d--oof"></span> <span id="index-defer"></span> <span id="index-defer-1"></span>
    
    <div class="format">
    
    ``` format
    defer       –         oof       “defer”
    ```
    
    </div>
    
    Create an instance defer

  - Method selectors <span id="index-early--_002d_002d--oof"></span> <span id="index-early"></span> <span id="index-early-1"></span>
    
    <div class="format">
    
    ``` format
    early       –         oof       “early”
    ```
    
    </div>
    
    Create a method selector for early binding.
    
    <span id="index-method--_002d_002d--oof"></span> <span id="index-method-2"></span> <span id="index-method-5"></span>
    
    <div class="format">
    
    ``` format
    method       –         oof       “method”
    ```
    
    </div>
    
    Create a method selector.

  - Class-wide variables <span id="index-static--_002d_002d--oof"></span> <span id="index-static"></span> <span id="index-static-1"></span>
    
    <div class="format">
    
    ``` format
    static       –         oof       “static”
    ```
    
    </div>
    
    Create a class-wide cell-sized variable.

  - End declaration <span id="index-how_003a--_002d_002d--oof"></span> <span id="index-how_003a"></span> <span id="index-how_003a-1"></span>
    
    <div class="format">
    
    ``` format
    how:       –         oof       “how-to”
    ```
    
    </div>
    
    End declaration, start implementation
    
    <span id="index-class_003b--_002d_002d--oof"></span> <span id="index-class_003b"></span> <span id="index-class_003b-1"></span>
    
    <div class="format">
    
    ``` format
    class;       –         oof       “end-class”
    ```
    
    </div>
    
    End class declaration or implementation
