> Source: https://gforth.org/manual/Creating-objects.html

<span id="Creating-objects"></span>

<div class="header">

Next: [Object-Oriented Programming Style](Object_002dOriented-Programming-Style.html#Object_002dOriented-Programming-Style), Previous: [The Objects base class](The-Objects-base-class.html#The-Objects-base-class), Up: [Objects](Objects.html#Objects)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Creating-objects-1"></span>

#### 5.23.3.4 Creating objects

<span id="index-creating-objects"></span> <span id="index-object-creation"></span> <span id="index-object-allocation-options"></span> <span id="index-heap_002dnew-discussion"></span> <span id="index-dict_002dnew-discussion"></span> <span id="index-construct-discussion"></span>

You can create and initialize an object of a class on the heap with `heap-new` ( ... class – object ) and in the dictionary (allocation with `allot`) with `dict-new` ( ... class – object ). Both words invoke `construct`, which consumes the stack items indicated by "..." above.

<span id="index-init_002dobject-discussion"></span> <span id="index-class_002dinst_002dsize-discussion"></span>

If you want to allocate memory for an object yourself, you can get its alignment and size with `class-inst-size 2@` ( class – align size ). Once you have memory for an object, you can initialize it with `init-object` ( ... class object – ); `construct` does only a part of the necessary work.
