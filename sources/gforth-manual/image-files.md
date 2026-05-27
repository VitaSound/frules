> Source: https://gforth.org/manual/Image-Files.html

<span id="Image-Files"></span>

<div class="header">

Next: [Engine](Engine.html#Engine), Previous: [Emacs and Gforth](Emacs-and-Gforth.html#Emacs-and-Gforth), Up: [Top](index.html#Top)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Image-Files-1"></span>

## 13 Image Files

<span id="index-image-file"></span> <span id="index-_002efi-files"></span> <span id="index-precompiled-Forth-code"></span> <span id="index-dictionary-in-persistent-form"></span> <span id="index-persistent-form-of-dictionary"></span>

An image file is a file containing an image of the Forth dictionary, i.e., compiled Forth code and data residing in the dictionary. By convention, we use the extension `.fi` for image files.

|                                                                                                           |  |                                         |
| :-------------------------------------------------------------------------------------------------------- |  | :-------------------------------------- |
| • [Image Licensing Issues](Image-Licensing-Issues.html#Image-Licensing-Issues):                           |  | Distribution terms for images.          |
| • [Image File Background](Image-File-Background.html#Image-File-Background):                              |  | Why have image files?                   |
| • [Non-Relocatable Image Files](Non_002dRelocatable-Image-Files.html#Non_002dRelocatable-Image-Files):    |  | don’t always work.                      |
| • [Data-Relocatable Image Files](Data_002dRelocatable-Image-Files.html#Data_002dRelocatable-Image-Files): |  | are better.                             |
| • [Fully Relocatable Image Files](Fully-Relocatable-Image-Files.html#Fully-Relocatable-Image-Files):      |  | better yet.                             |
| • [Stack and Dictionary Sizes](Stack-and-Dictionary-Sizes.html#Stack-and-Dictionary-Sizes):               |  | Setting the default sizes for an image. |
| • [Running Image Files](Running-Image-Files.html#Running-Image-Files):                                    |  | `gforth -i file` or *file*.             |
| • [Modifying the Startup Sequence](Modifying-the-Startup-Sequence.html#Modifying-the-Startup-Sequence):   |  | and turnkey applications.               |
