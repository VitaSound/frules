> Source: https://gforth.org/manual/Blocks-Files.html

<span id="Blocks-Files"></span>

<div class="header">

Previous: [Auto-Indentation](Auto_002dIndentation.html#Auto_002dIndentation), Up: [Emacs and Gforth](Emacs-and-Gforth.html#Emacs-and-Gforth)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Blocks-Files-1"></span>

### 12.5 Blocks Files

<span id="index-blocks-files_002c-use-with-Emacs"></span>

`forth-mode` Autodetects blocks files by checking whether the length of the first line exceeds 1023 characters. It then tries to convert the file into normal text format. When you save the file, it will be written to disk as normal stream-source file.

If you want to write blocks files, use `forth-blocks-mode`. It inherits all the features from `forth-mode`, plus some additions:

  - Files are written to disk in blocks file format.
  - Screen numbers are displayed in the mode line (enumerated beginning with the value of ‘forth-block-base’)
  - Warnings are displayed when lines exceed 64 characters.
  - The beginning of the currently edited block is marked with an overlay-arrow.

There are some restrictions you should be aware of. When you open a blocks file that contains tabulator or newline characters, these characters will be translated into spaces when the file is written back to disk. If tabs or newlines are encountered during blocks file reading, an error is output to the echo area. So have a look at the ‘\*Messages\*’ buffer, when Emacs’ bell rings during reading.

Please consult the docstring of `forth-blocks-mode` for more information by typing <span class="kbd">C-h v forth-blocks-mode</span>).
