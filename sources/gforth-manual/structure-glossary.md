> Source: https://gforth.org/manual/Structure-Glossary.html

<span id="Structure-Glossary"></span>

<div class="header">

Next: [Forth200x Structures](Forth200x-Structures.html#Forth200x-Structures), Previous: [Structure Implementation](Structure-Implementation.html#Structure-Implementation), Up: [Structures](Structures.html#Structures)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Structure-Glossary-1"></span>

#### 5.22.5 Structure Glossary

<span id="index-structure-glossary"></span> <span id="index-_0025align--align-size-_002d_002d--gforth"></span> <span id="index-_0025align"></span> <span id="index-_0025align-1"></span>

<div class="format">

``` format
%align       align size –         gforth       “%align”
```

</div>

Align the data space pointer to the alignment `align`.

<span id="index-_0025alignment--align-size-_002d_002d-align--gforth"></span> <span id="index-_0025alignment"></span> <span id="index-_0025alignment-1"></span>

<div class="format">

``` format
%alignment       align size – align         gforth       “%alignment”
```

</div>

The alignment of the structure.

<span id="index-_0025alloc--align-size-_002d_002d-addr--gforth"></span> <span id="index-_0025alloc"></span> <span id="index-_0025alloc-1"></span>

<div class="format">

``` format
%alloc       align size – addr         gforth       “%alloc”
```

</div>

Allocate `size` address units with alignment `align`, giving a data block at `addr`; `throw` an ior code if not successful.

<span id="index-_0025allocate--align-size-_002d_002d-addr-ior--gforth"></span> <span id="index-_0025allocate"></span> <span id="index-_0025allocate-1"></span>

<div class="format">

``` format
%allocate       align size – addr ior         gforth       “%allocate”
```

</div>

Allocate `size` address units with alignment `align`, similar to `allocate`.

<span id="index-_0025allot--align-size-_002d_002d-addr--gforth"></span> <span id="index-_0025allot"></span> <span id="index-_0025allot-1"></span>

<div class="format">

``` format
%allot       align size – addr         gforth       “%allot”
```

</div>

Allot `size` address units of data space with alignment `align`; the resulting block of data is found at `addr`.

<span id="index-cell_0025--_002d_002d-align-size--gforth"></span> <span id="index-cell_0025"></span> <span id="index-cell_0025-1"></span>

<div class="format">

``` format
cell%       – align size         gforth       “cell%”
```

</div>

<span id="index-char_0025--_002d_002d-align-size--gforth"></span> <span id="index-char_0025"></span> <span id="index-char_0025-1"></span>

<div class="format">

``` format
char%       – align size         gforth       “char%”
```

</div>

<span id="index-dfloat_0025--_002d_002d-align-size--gforth"></span> <span id="index-dfloat_0025"></span> <span id="index-dfloat_0025-1"></span>

<div class="format">

``` format
dfloat%       – align size         gforth       “dfloat%”
```

</div>

<span id="index-double_0025--_002d_002d-align-size--gforth"></span> <span id="index-double_0025"></span> <span id="index-double_0025-1"></span>

<div class="format">

``` format
double%       – align size         gforth       “double%”
```

</div>

<span id="index-end_002dstruct--align-size-_0022name_0022-_002d_002d--gforth"></span> <span id="index-end_002dstruct"></span> <span id="index-end_002dstruct-1"></span>

<div class="format">

``` format
end-struct       align size "name" –         gforth       “end-struct”
```

</div>

Define a structure/type descriptor `name` with alignment `align` and size `size1` (`size` rounded up to be a multiple of `align`).  
`name` execution: – `align size1`  

<span id="index-field--align1-offset1-align-size-_0022name_0022-_002d_002d-align2-offset2--gforth"></span> <span id="index-field"></span> <span id="index-field-1"></span>

<div class="format">

``` format
field       align1 offset1 align size "name" –  align2 offset2         gforth       “field”
```

</div>

Create a field `name` with offset `offset1`, and the type given by `align size`. `offset2` is the offset of the next field, and `align2` is the alignment of all fields.  
`name` execution: `addr1` – `addr2`.  
`addr2`=`addr1`+`offset1`

<span id="index-float_0025--_002d_002d-align-size--gforth"></span> <span id="index-float_0025"></span> <span id="index-float_0025-1"></span>

<div class="format">

``` format
float%       – align size         gforth       “float%”
```

</div>

<span id="index-naligned--addr1-n-_002d_002d-addr2--gforth"></span> <span id="index-naligned"></span> <span id="index-naligned-1"></span>

<div class="format">

``` format
naligned       addr1 n – addr2         gforth       “naligned”
```

</div>

`addr2` is the aligned version of `addr1` with respect to the alignment `n`.

<span id="index-sfloat_0025--_002d_002d-align-size--gforth"></span> <span id="index-sfloat_0025"></span> <span id="index-sfloat_0025-1"></span>

<div class="format">

``` format
sfloat%       – align size         gforth       “sfloat%”
```

</div>

<span id="index-_0025size--align-size-_002d_002d-size--gforth"></span> <span id="index-_0025size"></span> <span id="index-_0025size-1"></span>

<div class="format">

``` format
%size       align size – size         gforth       “%size”
```

</div>

The size of the structure.

<span id="index-struct--_002d_002d-align-size--gforth"></span> <span id="index-struct"></span> <span id="index-struct-1"></span>

<div class="format">

``` format
struct       – align size         gforth       “struct”
```

</div>

An empty structure, used to start a structure definition.

-----

<div class="header">

Next: [Forth200x Structures](Forth200x-Structures.html#Forth200x-Structures), Previous: [Structure Implementation](Structure-Implementation.html#Structure-Implementation), Up: [Structures](Structures.html#Structures)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
