> Source: https://gforth.org/manual/gforthmi.html

<span id="gforthmi"></span>

<div class="header">

Next: [cross.fs](cross_002efs.html#cross_002efs), Previous: [Fully Relocatable Image Files](Fully-Relocatable-Image-Files.html#Fully-Relocatable-Image-Files), Up: [Fully Relocatable Image Files](Fully-Relocatable-Image-Files.html#Fully-Relocatable-Image-Files)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="gforthmi-1"></span>

#### 13.5.1 `gforthmi`

<span id="index-comp_002di_002efs"></span> <span id="index-gforthmi"></span>

You will usually use `gforthmi`. If you want to create an image *file* that contains everything you would load by invoking Gforth with `gforth options`, you simply say:

<div class="example">

``` example
gforthmi file options
```

</div>

E.g., if you want to create an image `asm.fi` that has the file `asm.fs` loaded in addition to the usual stuff, you could do it like this:

<div class="example">

``` example
gforthmi asm.fi asm.fs
```

</div>

`gforthmi` is implemented as a sh script and works like this: It produces two non-relocatable images for different addresses and then compares them. Its output reflects this: first you see the output (if any) of the two Gforth invocations that produce the non-relocatable image files, then you see the output of the comparing program: It displays the offset used for data addresses and the offset used for code addresses; moreover, for each cell that cannot be represented correctly in the image files, it displays a line like this:

<div class="example">

``` example
     78DC         BFFFFA50         BFFFFA40
```

</div>

This means that at offset $78dc from `forthstart`, one input image contains $bffffa50, and the other contains $bffffa40. Since these cells cannot be represented correctly in the output image, you should examine these places in the dictionary and verify that these cells are dead (i.e., not read before they are written).

<span id="index-_002d_002dapplication_002c-gforthmi-option"></span>

If you insert the option `--application` in front of the image file name, you will get an image that uses the `--appl-image` option instead of the `--image-file` option (see [Invoking Gforth](Invoking-Gforth.html#Invoking-Gforth)). When you execute such an image on Unix (by typing the image name as command), the Gforth engine will pass all options to the image instead of trying to interpret them as engine options.

If you type `gforthmi` with no arguments, it prints some usage instructions.

<span id="index-savesystem-during-gforthmi"></span> <span id="index-bye-during-gforthmi"></span> <span id="index-doubly-indirect-threaded-code"></span> <span id="index-environment-variables-1"></span> <span id="index-GFORTHD-_002d_002d-environment-variable-1"></span> <span id="index-GFORTH-_002d_002d-environment-variable-1"></span> <span id="index-gforth_002dditc"></span>

There are a few wrinkles: After processing the passed *options*, the words `savesystem` and `bye` must be visible. A special doubly indirect threaded version of the `gforth` executable is used for creating the non-relocatable images; you can pass the exact filename of this executable through the environment variable `GFORTHD` (default: `gforth-ditc`); if you pass a version that is not doubly indirect threaded, you will not get a fully relocatable image, but a data-relocatable image (see [Data-Relocatable Image Files](Data_002dRelocatable-Image-Files.html#Data_002dRelocatable-Image-Files)), because there is no code address offset). The normal `gforth` executable is used for creating the relocatable image; you can pass the exact filename of this executable through the environment variable `GFORTH`.

-----

<div class="header">

Next: [cross.fs](cross_002efs.html#cross_002efs), Previous: [Fully Relocatable Image Files](Fully-Relocatable-Image-Files.html#Fully-Relocatable-Image-Files), Up: [Fully Relocatable Image Files](Fully-Relocatable-Image-Files.html#Fully-Relocatable-Image-Files)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
