> Source: https://gforth.org/manual/Stack-and-Dictionary-Sizes.html

<span id="Stack-and-Dictionary-Sizes"></span>

<div class="header">

Next: [Running Image Files](Running-Image-Files.html#Running-Image-Files), Previous: [Fully Relocatable Image Files](Fully-Relocatable-Image-Files.html#Fully-Relocatable-Image-Files), Up: [Image Files](Image-Files.html#Image-Files)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Stack-and-Dictionary-Sizes-1"></span>

### 13.6 Stack and Dictionary Sizes

<span id="index-image-file_002c-stack-and-dictionary-sizes"></span> <span id="index-dictionary-size-default"></span> <span id="index-stack-size-default"></span>

If you invoke Gforth with a command line flag for the size (see [Invoking Gforth](Invoking-Gforth.html#Invoking-Gforth)), the size you specify is stored in the dictionary. If you save the dictionary with `savesystem` or create an image with `gforthmi`, this size will become the default for the resulting image file. E.g., the following will create a fully relocatable version of `gforth.fi` with a 1MB dictionary:

<div class="example">

``` example
gforthmi gforth.fi -m 1M
```

</div>

In other words, if you want to set the default size for the dictionary and the stacks of an image, just invoke `gforthmi` with the appropriate options when creating the image.

<span id="index-stack-size_002c-cache_002dfriendly"></span>

Note: For cache-friendly behaviour (i.e., good performance), you should make the sizes of the stacks modulo, say, 2K, somewhat different. E.g., the default stack sizes are: data: 16k (mod 2k=0); fp: 15.5k (mod 2k=1.5k); return: 15k(mod 2k=1k); locals: 14.5k (mod 2k=0.5k).
