> Source: https://gforth.org/manual/Data_002dRelocatable-Image-Files.html

<span id="Data_002dRelocatable-Image-Files"></span>

<div class="header">

Next: [Fully Relocatable Image Files](Fully-Relocatable-Image-Files.html#Fully-Relocatable-Image-Files), Previous: [Non-Relocatable Image Files](Non_002dRelocatable-Image-Files.html#Non_002dRelocatable-Image-Files), Up: [Image Files](Image-Files.html#Image-Files)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Data_002dRelocatable-Image-Files-1"></span>

### 13.4 Data-Relocatable Image Files

<span id="index-data_002drelocatable-image-files"></span> <span id="index-image-file_002c-data_002drelocatable"></span>

These files contain relocatable data addresses, but fixed code addresses (instead of tokens). They are specific to the executable (i.e., `gforth` file) they were created with. Also, they disable dynamic native code generation (typically a factor of 2 in speed). You get a data-relocatable image, if you pass the engine you want to use through the `GFORTHD` environment variable to `gforthmi` (see [gforthmi](gforthmi.html#gforthmi)), e.g.

<div class="example">

``` example
GFORTHD="/usr/bin/gforth-fast --no-dynamic" gforthmi myimage.fi source.fs
```

</div>

Note that the `--no-dynamic` is required here for the image to work (otherwise it will contain references to dynamically generated code that is not saved in the image).
