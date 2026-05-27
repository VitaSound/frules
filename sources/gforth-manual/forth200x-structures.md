> Source: https://gforth.org/manual/Forth200x-Structures.html

<span id="Forth200x-Structures"></span>

<div class="header">

Previous: [Structure Glossary](Structure-Glossary.html#Structure-Glossary), Up: [Structures](Structures.html#Structures)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Forth200x-Structures-1"></span>

#### 5.22.6 Forth200x Structures

<span id="index-Structures-in-Forth200x"></span>

The Forth 2012 standard defines a slightly less convenient form of structures. In general (when using `field+`, you have to perform the alignment yourself, but there are a number of convenience words (e.g., `field:` that perform the alignment for you.

A typical usage example is:

<div class="example">

``` example
0
  field:                   s-a
  faligned 2 floats +field s-b
constant s-struct
```

</div>

An alternative way of writing this structure is:

<div class="example">

``` example
begin-structure s-struct
  field:                   s-a
  faligned 2 floats +field s-b
end-structure
```

</div>

<span id="index-begin_002dstructure--_0022name_0022-_002d_002d-struct_002dsys-0--X_003astructures"></span> <span id="index-begin_002dstructure"></span> <span id="index-begin_002dstructure-1"></span>

<div class="format">

``` format
begin-structure       "name" – struct-sys 0         X:structures       “begin-structure”
```

</div>

<span id="index-end_002dstructure--struct_002dsys-_002bn-_002d_002d--X_003astructures"></span> <span id="index-end_002dstructure"></span> <span id="index-end_002dstructure-1"></span>

<div class="format">

``` format
end-structure       struct-sys +n –         X:structures       “end-structure”
```

</div>

<span id="index-_002bfield--unknown--unknown"></span> <span id="index-_002bfield"></span> <span id="index-_002bfield-1"></span>

<div class="format">

``` format
+field       unknown         unknown       “+field”
```

</div>

<span id="index-cfield_003a--u1-_0022name_0022-_002d_002d-u2--X_003astructures"></span> <span id="index-cfield_003a"></span> <span id="index-cfield_003a-1"></span>

<div class="format">

``` format
cfield:       u1 "name" – u2         X:structures       “cfield:”
```

</div>

<span id="index-field_003a--u1-_0022name_0022-_002d_002d-u2--X_003astructures"></span> <span id="index-field_003a"></span> <span id="index-field_003a-1"></span>

<div class="format">

``` format
field:       u1 "name" – u2         X:structures       “field:”
```

</div>

<span id="index-2field_003a--u1-_0022name_0022-_002d_002d-u2--gforth"></span> <span id="index-2field_003a"></span> <span id="index-2field_003a-1"></span>

<div class="format">

``` format
2field:       u1 "name" – u2         gforth       “2field:”
```

</div>

<span id="index-ffield_003a--u1-_0022name_0022-_002d_002d-u2--X_003astructures"></span> <span id="index-ffield_003a"></span> <span id="index-ffield_003a-1"></span>

<div class="format">

``` format
ffield:       u1 "name" – u2         X:structures       “ffield:”
```

</div>

<span id="index-sffield_003a--u1-_0022name_0022-_002d_002d-u2--X_003astructures"></span> <span id="index-sffield_003a"></span> <span id="index-sffield_003a-1"></span>

<div class="format">

``` format
sffield:       u1 "name" – u2         X:structures       “sffield:”
```

</div>

<span id="index-dffield_003a--u1-_0022name_0022-_002d_002d-u2--X_003astructures"></span> <span id="index-dffield_003a"></span> <span id="index-dffield_003a-1"></span>

<div class="format">

``` format
dffield:       u1 "name" – u2         X:structures       “dffield:”
```

</div>
