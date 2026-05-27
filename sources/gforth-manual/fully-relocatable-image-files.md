> Source: https://gforth.org/manual/Fully-Relocatable-Image-Files.html

<span id="Fully-Relocatable-Image-Files"></span>

<div class="header">

Next: [Stack and Dictionary Sizes](Stack-and-Dictionary-Sizes.html#Stack-and-Dictionary-Sizes), Previous: [Data-Relocatable Image Files](Data_002dRelocatable-Image-Files.html#Data_002dRelocatable-Image-Files), Up: [Image Files](Image-Files.html#Image-Files)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Fully-Relocatable-Image-Files-1"></span>

### 13.5 Fully Relocatable Image Files

<span id="index-fully-relocatable-image-files"></span> <span id="index-image-file_002c-fully-relocatable"></span> <span id="index-kern_002a_002efi_002c-relocatability"></span> <span id="index-gforth_002efi_002c-relocatability"></span>

These image files have relocatable data addresses, and tokens for code addresses. They can be used with different binaries (e.g., with and without debugging) on the same machine, and even across machines with the same data formats (byte order, cell size, floating point format), and they work with dynamic native code generation. However, they are usually specific to the version of Gforth they were created with. The files `gforth.fi` and `kernl*.fi` are fully relocatable.

There are two ways to create a fully relocatable image file:

|                                               |  |                |
| :-------------------------------------------- |  | :------------- |
| • [gforthmi](gforthmi.html#gforthmi):         |  | The normal way |
| • [cross.fs](cross_002efs.html#cross_002efs): |  | The hard way   |
