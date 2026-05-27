> Source: https://gforth.org/manual/Objects-Glossary.html

<span id="Objects-Glossary"></span>

<div class="header">

Previous: [Objects Implementation](Objects-Implementation.html#Objects-Implementation), Up: [Objects](Objects.html#Objects)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="objects_002efs-Glossary"></span>

#### 5.23.3.12 `objects.fs` Glossary

<span id="index-objects_002efs-Glossary"></span> <span id="index-bind--_002e_002e_002e-_0022class_0022-_0022selector_0022-_002d_002d-_002e_002e_002e--objects"></span> <span id="index-bind"></span> <span id="index-bind-2"></span>

<div class="format">

``` format
bind       ... "class" "selector" – ...         objects       “bind”
```

</div>

Execute the method for `selector` in `class`.

<span id="index-_003cbind_003e--class-selector_002dxt-_002d_002d-xt--objects"></span> <span id="index-_003cbind_003e"></span> <span id="index-_003cbind_003e-1"></span>

<div class="format">

``` format
<bind>       class selector-xt – xt         objects       “<bind>”
```

</div>

`xt` is the method for the selector `selector-xt` in `class`.

<span id="index-bind_0027--_0022class_0022-_0022selector_0022-_002d_002d-xt--objects"></span> <span id="index-bind_0027"></span> <span id="index-bind_0027-1"></span>

<div class="format">

``` format
bind'       "class" "selector" – xt         objects       “bind”’
```

</div>

`xt` is the method for `selector` in `class`.

<span id="index-_005bbind_005d--compile_002dtime_003a-_0022class_0022-_0022selector_0022-_002d_002d-_003b-run_002dtime_003a-_002e_002e_002e-object-_002d_002d-_002e_002e_002e--objects"></span> <span id="index-_005bbind_005d"></span> <span id="index-_005bbind_005d-1"></span>

<div class="format">

``` format
[bind]       compile-time: "class" "selector" – ; run-time: ... object – ...         objects       “[bind]”
```

</div>

Compile the method for `selector` in `class`.

<span id="index-class--parent_002dclass-_002d_002d-align-offset--objects"></span> <span id="index-class-1"></span> <span id="index-class-4"></span>

<div class="format">

``` format
class       parent-class – align offset         objects       “class”
```

</div>

Start a new class definition as a child of `parent-class`. `align offset` are for use by `field` etc.

<span id="index-class_002d_003emap--class-_002d_002d-map--objects"></span> <span id="index-class_002d_003emap"></span> <span id="index-class_002d_003emap-1"></span>

<div class="format">

``` format
class->map       class – map         objects       “class->map”
```

</div>

`map` is the pointer to `class`’s method map; it points to the place in the map to which the selector offsets refer (i.e., where `object-map`s point to).

<span id="index-class_002dinst_002dsize--class-_002d_002d-addr--objects"></span> <span id="index-class_002dinst_002dsize"></span> <span id="index-class_002dinst_002dsize-1"></span>

<div class="format">

``` format
class-inst-size       class – addr         objects       “class-inst-size”
```

</div>

Give the size specification for an instance (i.e. an object) of `class`; used as `class-inst-size 2 ( class -- align size )`.

<span id="index-class_002doverride_0021--xt-sel_002dxt-class_002dmap-_002d_002d--objects"></span> <span id="index-class_002doverride_0021"></span> <span id="index-class_002doverride_0021-1"></span>

<div class="format">

``` format
class-override!       xt sel-xt class-map –         objects       “class-override!”
```

</div>

`xt` is the new method for the selector `sel-xt` in `class-map`.

<span id="index-class_002dprevious--class-_002d_002d--objects"></span> <span id="index-class_002dprevious"></span> <span id="index-class_002dprevious-1"></span>

<div class="format">

``` format
class-previous       class –         objects       “class-previous”
```

</div>

Drop `class`’s wordlists from the search order. No checking is made whether `class`’s wordlists are actually on the search order.

<span id="index-class_003eorder--class-_002d_002d--objects"></span> <span id="index-class_003eorder"></span> <span id="index-class_003eorder-1"></span>

<div class="format">

``` format
class>order       class –         objects       “class>order”
```

</div>

Add `class`’s wordlists to the head of the search-order.

<span id="index-construct--_002e_002e_002e-object-_002d_002d--objects"></span> <span id="index-construct"></span> <span id="index-construct-1"></span>

<div class="format">

``` format
construct       ... object –         objects       “construct”
```

</div>

Initialize the data fields of `object`. The method for the class `object` just does nothing: `( object -- )`.

<span id="index-current_0027--_0022selector_0022-_002d_002d-xt--objects"></span> <span id="index-current_0027"></span> <span id="index-current_0027-1"></span>

<div class="format">

``` format
current'       "selector" – xt         objects       “current”’
```

</div>

`xt` is the method for `selector` in the current class.

<span id="index-_005bcurrent_005d--compile_002dtime_003a-_0022selector_0022-_002d_002d-_003b-run_002dtime_003a-_002e_002e_002e-object-_002d_002d-_002e_002e_002e--objects"></span> <span id="index-_005bcurrent_005d"></span> <span id="index-_005bcurrent_005d-1"></span>

<div class="format">

``` format
[current]       compile-time: "selector" – ; run-time: ... object – ...         objects       “[current]”
```

</div>

Compile the method for `selector` in the current class.

<span id="index-current_002dinterface--_002d_002d-addr--objects"></span> <span id="index-current_002dinterface"></span> <span id="index-current_002dinterface-1"></span>

<div class="format">

``` format
current-interface       – addr         objects       “current-interface”
```

</div>

Variable: contains the class or interface currently being defined.

<span id="index-dict_002dnew--_002e_002e_002e-class-_002d_002d-object--objects"></span> <span id="index-dict_002dnew"></span> <span id="index-dict_002dnew-1"></span>

<div class="format">

``` format
dict-new       ... class – object         objects       “dict-new”
```

</div>

`allot` and initialize an object of class `class` in the dictionary.

<span id="index-end_002dclass--align-offset-_0022name_0022-_002d_002d--objects"></span> <span id="index-end_002dclass"></span> <span id="index-end_002dclass-2"></span>

<div class="format">

``` format
end-class       align offset "name" –         objects       “end-class”
```

</div>

`name` execution: `-- class`  
End a class definition. The resulting class is `class`.

<span id="index-end_002dclass_002dnoname--align-offset-_002d_002d-class--objects"></span> <span id="index-end_002dclass_002dnoname"></span> <span id="index-end_002dclass_002dnoname-1"></span>

<div class="format">

``` format
end-class-noname       align offset – class         objects       “end-class-noname”
```

</div>

End a class definition. The resulting class is `class`.

<span id="index-end_002dinterface--_0022name_0022-_002d_002d--objects"></span> <span id="index-end_002dinterface"></span> <span id="index-end_002dinterface-1"></span>

<div class="format">

``` format
end-interface       "name" –         objects       “end-interface”
```

</div>

`name` execution: `-- interface`  
End an interface definition. The resulting interface is `interface`.

<span id="index-end_002dinterface_002dnoname--_002d_002d-interface--objects"></span> <span id="index-end_002dinterface_002dnoname"></span> <span id="index-end_002dinterface_002dnoname-1"></span>

<div class="format">

``` format
end-interface-noname       – interface         objects       “end-interface-noname”
```

</div>

End an interface definition. The resulting interface is `interface`.

<span id="index-end_002dmethods--_002d_002d--objects"></span> <span id="index-end_002dmethods"></span> <span id="index-end_002dmethods-1"></span>

<div class="format">

``` format
end-methods       –         objects       “end-methods”
```

</div>

Switch back from defining methods of a class to normal mode (currently this just restores the old search order).

<span id="index-exitm--_002d_002d--objects"></span> <span id="index-exitm"></span> <span id="index-exitm-1"></span>

<div class="format">

``` format
exitm       –         objects       “exitm”
```

</div>

`exit` from a method; restore old `this`.

<span id="index-heap_002dnew--_002e_002e_002e-class-_002d_002d-object--objects"></span> <span id="index-heap_002dnew"></span> <span id="index-heap_002dnew-1"></span>

<div class="format">

``` format
heap-new       ... class – object         objects       “heap-new”
```

</div>

`allocate` and initialize an object of class `class`.

<span id="index-implementation--interface-_002d_002d--objects"></span> <span id="index-implementation"></span> <span id="index-implementation-1"></span>

<div class="format">

``` format
implementation       interface –         objects       “implementation”
```

</div>

The current class implements `interface`. I.e., you can use all selectors of the interface in the current class and its descendents.

<span id="index-init_002dobject--_002e_002e_002e-class-object-_002d_002d--objects"></span> <span id="index-init_002dobject"></span> <span id="index-init_002dobject-1"></span>

<div class="format">

``` format
init-object       ... class object –         objects       “init-object”
```

</div>

Initialize a chunk of memory (`object`) to an object of class `class`; then performs `construct`.

<span id="index-inst_002dvalue--align1-offset1-_0022name_0022-_002d_002d-align2-offset2--objects"></span> <span id="index-inst_002dvalue"></span> <span id="index-inst_002dvalue-1"></span>

<div class="format">

``` format
inst-value       align1 offset1 "name" – align2 offset2         objects       “inst-value”
```

</div>

`name` execution: `-- w`  
`w` is the value of the field `name` in `this` object.

<span id="index-inst_002dvar--align1-offset1-align-size-_0022name_0022-_002d_002d-align2-offset2--objects"></span> <span id="index-inst_002dvar"></span> <span id="index-inst_002dvar-1"></span>

<div class="format">

``` format
inst-var       align1 offset1 align size "name" – align2 offset2         objects       “inst-var”
```

</div>

`name` execution: `-- addr`  
`addr` is the address of the field `name` in `this` object.

<span id="index-interface--_002d_002d--objects"></span> <span id="index-interface"></span> <span id="index-interface-1"></span>

<div class="format">

``` format
interface       –         objects       “interface”
```

</div>

Start an interface definition.

<span id="index-m_003a--_002d_002d-xt-colon_002dsys_003b-run_002dtime_003a-object-_002d_002d--objects"></span> <span id="index-m_003a"></span> <span id="index-m_003a-1"></span>

<div class="format">

``` format
m:       – xt colon-sys; run-time: object –         objects       “m:”
```

</div>

Start a method definition; `object` becomes new `this`.

<span id="index-_003am--_0022name_0022-_002d_002d-xt_003b-run_002dtime_003a-object-_002d_002d--objects"></span> <span id="index-_003am"></span>

<div class="format">

``` format
:m       "name" – xt; run-time: object –         objects       “:m”
```

</div>

Start a named method definition; `object` becomes new `this`. Has to be ended with `;m`.

<span id="index-_003bm--colon_002dsys-_002d_002d_003b-run_002dtime_003a-_002d_002d--objects"></span> <span id="index-_003bm"></span> <span id="index-_003bm-1"></span>

<div class="format">

``` format
;m       colon-sys –; run-time: –         objects       “;m”
```

</div>

End a method definition; restore old `this`.

<span id="index-method--xt-_0022name_0022-_002d_002d--objects"></span> <span id="index-method-1"></span> <span id="index-method-4"></span>

<div class="format">

``` format
method       xt "name" –         objects       “method”
```

</div>

`name` execution: `... object -- ...`  
Create selector `name` and makes `xt` its method in the current class.

<span id="index-methods--class-_002d_002d--objects"></span> <span id="index-methods"></span> <span id="index-methods-1"></span>

<div class="format">

``` format
methods       class –         objects       “methods”
```

</div>

Makes `class` the current class. This is intended to be used for defining methods to override selectors; you cannot define new fields or selectors.

<span id="index-object--_002d_002d-class--objects"></span> <span id="index-object-1"></span> <span id="index-object-3"></span>

<div class="format">

``` format
object       – class         objects       “object”
```

</div>

the ancestor of all classes.

<span id="index-overrides--xt-_0022selector_0022-_002d_002d--objects"></span> <span id="index-overrides"></span> <span id="index-overrides-1"></span>

<div class="format">

``` format
overrides       xt "selector" –         objects       “overrides”
```

</div>

replace default method for `selector` in the current class with `xt`. `overrides` must not be used during an interface definition.

<span id="index-_005bparent_005d--compile_002dtime_003a-_0022selector_0022-_002d_002d-_003b-run_002dtime_003a-_002e_002e_002e-object-_002d_002d-_002e_002e_002e--objects"></span> <span id="index-_005bparent_005d"></span> <span id="index-_005bparent_005d-1"></span>

<div class="format">

``` format
[parent]       compile-time: "selector" – ; run-time: ... object – ...         objects       “[parent]”
```

</div>

Compile the method for `selector` in the parent of the current class.

<span id="index-print--object-_002d_002d--objects"></span> <span id="index-print"></span> <span id="index-print-1"></span>

<div class="format">

``` format
print       object –         objects       “print”
```

</div>

Print the object. The method for the class `object` prints the address of the object and the address of its class.

<span id="index-protected--_002d_002d--objects"></span> <span id="index-protected"></span> <span id="index-protected-1"></span>

<div class="format">

``` format
protected       –         objects       “protected”
```

</div>

Set the compilation wordlist to the current class’s wordlist

<span id="index-public--_002d_002d--objects"></span> <span id="index-public"></span> <span id="index-public-1"></span>

<div class="format">

``` format
public       –         objects       “public”
```

</div>

Restore the compilation wordlist that was in effect before the last `protected` that actually changed the compilation wordlist.

<span id="index-selector--_0022name_0022-_002d_002d--objects"></span> <span id="index-selector-1"></span> <span id="index-selector-2"></span>

<div class="format">

``` format
selector       "name" –         objects       “selector”
```

</div>

`name` execution: `... object -- ...`  
Create selector `name` for the current class and its descendents; you can set a method for the selector in the current class with `overrides`.

<span id="index-this--_002d_002d-object--objects"></span> <span id="index-this"></span> <span id="index-this-1"></span>

<div class="format">

``` format
this       – object         objects       “this”
```

</div>

the receiving object of the current method (aka active object).

<span id="index-_003cto_002dinst_003e--w-xt-_002d_002d--objects"></span> <span id="index-_003cto_002dinst_003e"></span> <span id="index-_003cto_002dinst_003e-1"></span>

<div class="format">

``` format
<to-inst>       w xt –         objects       “<to-inst>”
```

</div>

store `w` into the field `xt` in `this` object.

<span id="index-_005bto_002dinst_005d--compile_002dtime_003a-_0022name_0022-_002d_002d-_003b-run_002dtime_003a-w-_002d_002d--objects"></span> <span id="index-_005bto_002dinst_005d"></span> <span id="index-_005bto_002dinst_005d-1"></span>

<div class="format">

``` format
[to-inst]       compile-time: "name" – ; run-time: w –         objects       “[to-inst]”
```

</div>

store `w` into field `name` in `this` object.

<span id="index-to_002dthis--object-_002d_002d--objects"></span> <span id="index-to_002dthis"></span> <span id="index-to_002dthis-1"></span>

<div class="format">

``` format
to-this       object –         objects       “to-this”
```

</div>

Set `this` (used internally, but useful when debugging).

<span id="index-xt_002dnew--_002e_002e_002e-class-xt-_002d_002d-object--objects"></span> <span id="index-xt_002dnew"></span> <span id="index-xt_002dnew-1"></span>

<div class="format">

``` format
xt-new       ... class xt – object         objects       “xt-new”
```

</div>

Make a new object, using `xt ( align size -- addr )` to get memory.

-----

<div class="header">

Previous: [Objects Implementation](Objects-Implementation.html#Objects-Implementation), Up: [Objects](Objects.html#Objects)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
