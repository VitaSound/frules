> Source: https://gforth.org/manual/Non_002dRelocatable-Image-Files.html

<span id="Non_002dRelocatable-Image-Files"></span>

<div class="header">

Next: [Data-Relocatable Image Files](Data_002dRelocatable-Image-Files.html#Data_002dRelocatable-Image-Files), Previous: [Image File Background](Image-File-Background.html#Image-File-Background), Up: [Image Files](Image-Files.html#Image-Files)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Non_002dRelocatable-Image-Files-1"></span>

### 13.3 Non-Relocatable Image Files

<span id="index-non_002drelocatable-image-files"></span> <span id="index-image-file_002c-non_002drelocatable"></span>

These files are simple memory dumps of the dictionary. They are specific to the executable (i.e., `gforth` file) they were created with. What’s worse, they are specific to the place on which the dictionary resided when the image was created. Now, there is no guarantee that the dictionary will reside at the same place the next time you start Gforth, so there’s no guarantee that a non-relocatable image will work the next time (Gforth will complain instead of crashing, though). Indeed, on OSs with (enabled) address-space randomization non-relocatable images are unlikely to work.

You can create a non-relocatable image file with `savesystem`, e.g.:

<div class="example">

``` example
gforth app.fs -e "savesystem app.fi bye"
```

</div>

<span id="index-savesystem--_0022name_0022-_002d_002d--gforth"></span> <span id="index-savesystem"></span> <span id="index-savesystem-1"></span>

<div class="format">

``` format
savesystem       "name" –         gforth       “savesystem”
```

</div>
