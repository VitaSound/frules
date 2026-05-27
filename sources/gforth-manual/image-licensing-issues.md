> Source: https://gforth.org/manual/Image-Licensing-Issues.html

<span id="Image-Licensing-Issues"></span>

<div class="header">

Next: [Image File Background](Image-File-Background.html#Image-File-Background), Previous: [Image Files](Image-Files.html#Image-Files), Up: [Image Files](Image-Files.html#Image-Files)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Image-Licensing-Issues-1"></span>

### 13.1 Image Licensing Issues

<span id="index-license-for-images"></span> <span id="index-image-license"></span>

An image created with `gforthmi` (see [gforthmi](gforthmi.html#gforthmi)) or `savesystem` (see [Non-Relocatable Image Files](Non_002dRelocatable-Image-Files.html#Non_002dRelocatable-Image-Files)) includes the original image; i.e., according to copyright law it is a derived work of the original image.

Since Gforth is distributed under the GNU GPL, the newly created image falls under the GNU GPL, too. In particular, this means that if you distribute the image, you have to make all of the sources for the image available, including those you wrote. For details see [GNU General Public License (Section 3)](Copying.html#Copying).

If you create an image with `cross` (see [cross.fs](cross_002efs.html#cross_002efs)), the image contains only code compiled from the sources you gave it; if none of these sources is under the GPL, the terms discussed above do not apply to the image. However, if your image needs an engine (a gforth binary) that is under the GPL, you should make sure that you distribute both in a way that is at most a *mere aggregation*, if you don’t want the terms of the GPL to apply to the image.
