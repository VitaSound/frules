> Source: https://gforth.org/manual/Image-File-Background.html

<span id="Image-File-Background"></span>

<div class="header">

Next: [Non-Relocatable Image Files](Non_002dRelocatable-Image-Files.html#Non_002dRelocatable-Image-Files), Previous: [Image Licensing Issues](Image-Licensing-Issues.html#Image-Licensing-Issues), Up: [Image Files](Image-Files.html#Image-Files)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Image-File-Background-1"></span>

### 13.2 Image File Background

<span id="index-image-file-background"></span>

Gforth consists not only of primitives (in the engine), but also of definitions written in Forth. Since the Forth compiler itself belongs to those definitions, it is not possible to start the system with the engine and the Forth source alone. Therefore we provide the Forth code as an image file in nearly executable form. When Gforth starts up, a C routine loads the image file into memory, optionally relocates the addresses, then sets up the memory (stacks etc.) according to information in the image file, and (finally) starts executing Forth code.

The default image file is `gforth.fi` (in the `GFORTHPATH`). You can use a different image by using the `-i`, `--image-file` or `--appl-image` options (see [Invoking Gforth](Invoking-Gforth.html#Invoking-Gforth)), e.g.:

<div class="example">

``` example
gforth-fast -i myimage.fi
```

</div>

There are different variants of image files, and they represent different compromises between the goals of making it easy to generate image files and making them portable.

<span id="index-relocation-at-run_002dtime"></span>

Win32Forth 3.4 and Mitch Bradley’s `cforth` use relocation at run-time. This avoids many of the complications discussed below (image files are data relocatable without further ado), but costs performance (one addition per memory access) and makes it difficult to pass addresses between Forth and library calls or other programs.

<span id="index-relocation-at-load_002dtime"></span>

By contrast, the Gforth loader performs relocation at image load time. The loader also has to replace tokens that represent primitive calls with the appropriate code-field addresses (or code addresses in the case of direct threading).

There are three kinds of image files, with different degrees of relocatability: non-relocatable, data-relocatable, and fully relocatable image files.

<span id="index-image-file-loader"></span> <span id="index-relocating-loader"></span> <span id="index-loader-for-image-files"></span>

These image file variants have several restrictions in common; they are caused by the design of the image file loader:

  - There is only one segment; in particular, this means, that an image file cannot represent `ALLOCATE`d memory chunks (and pointers to them). The contents of the stacks are not represented, either.

  - The only kinds of relocation supported are: adding the same offset to all cells that represent data addresses; and replacing special tokens with code addresses or with pieces of machine code.
    
    If any complex computations involving addresses are performed, the results cannot be represented in the image file. Several applications that use such computations come to mind:
    
      - \- Hashing addresses (or data structures which contain addresses) for table lookup. If you use Gforth’s `table`s or `wordlist`s for this purpose, you will have no problem, because the hash tables are recomputed automatically when the system is started. If you use your own hash tables, you will have to do something similar.
      - \- There’s a cute implementation of doubly-linked lists that uses `XOR`ed addresses. You could represent such lists as singly-linked in the image file, and restore the doubly-linked representation on startup.[<sup>37</sup>](#FOOT37)
      - \- The code addresses of run-time routines like `docol:` cannot be represented in the image file (because their tokens would be replaced by machine code in direct threaded implementations). As a workaround, compute these addresses at run-time with `>code-address` from the executions tokens of appropriate words (see the definitions of `docol:` and friends in `kernel/getdoers.fs`).
      - \- On many architectures addresses are represented in machine code in some shifted or mangled form. You cannot put `CODE` words that contain absolute addresses in this form in a relocatable image file. Workarounds are representing the address in some relative form (e.g., relative to the CFA, which is present in some register), or loading the address from a place where it is stored in a non-mangled form.

<div class="footnote">

-----

#### Footnotes

### [(37)](#DOCF37)

In my opinion, though, you should think thrice before using a doubly-linked list (whatever implementation).

</div>

-----

<div class="header">

Next: [Non-Relocatable Image Files](Non_002dRelocatable-Image-Files.html#Non_002dRelocatable-Image-Files), Previous: [Image Licensing Issues](Image-Licensing-Issues.html#Image-Licensing-Issues), Up: [Image Files](Image-Files.html#Image-Files)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
