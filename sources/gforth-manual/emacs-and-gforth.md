> Source: https://gforth.org/manual/Emacs-and-Gforth.html

<span id="Emacs-and-Gforth"></span>

<div class="header">

Next: [Image Files](Image-Files.html#Image-Files), Previous: [Integrating Gforth](Integrating-Gforth.html#Integrating-Gforth), Up: [Top](index.html#Top)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Emacs-and-Gforth-1"></span>

## 12 Emacs and Gforth

<span id="index-Emacs-and-Gforth"></span> <span id="index-gforth_002eel"></span> <span id="index-forth_002eel"></span> <span id="index-Rydqvist_002c-Goran"></span> <span id="index-Kuehling_002c-David"></span> <span id="index-comment-editing-commands"></span> <span id="index-_005c_002c-editing-with-Emacs"></span> <span id="index-debug-tracer-editing-commands"></span> <span id="index-_007e_007e_002c-removal-with-Emacs"></span> <span id="index-Forth-mode-in-Emacs"></span>

Gforth comes with `gforth.el`, an improved version of `forth.el` by Goran Rydqvist (included in the TILE package). The improvements are:

  - A better handling of indentation.
  - A custom hilighting engine for Forth-code.
  - Comment paragraph filling (<span class="kbd">M-q</span>)
  - Commenting (<span class="kbd">C-x \\</span>) and uncommenting (<span class="kbd">C-u C-x \\</span>) of regions
  - Removal of debugging tracers (<span class="kbd">C-x \~</span>, see [Debugging](Debugging.html#Debugging)).
  - Support of the `info-lookup` feature for looking up the documentation of a word.
  - Support for reading and writing blocks files.

To get a basic description of these features, enter Forth mode and type <span class="kbd">C-h m</span>.

<span id="index-source-location-of-error-or-debugging-output-in-Emacs"></span> <span id="index-error-output_002c-finding-the-source-location-in-Emacs"></span> <span id="index-debugging-output_002c-finding-the-source-location-in-Emacs"></span>

In addition, Gforth supports Emacs quite well: The source code locations given in error messages, debugging output (from `~~`) and failed assertion messages are in the right format for Emacs’ compilation mode (see [Running Compilations under Emacs](http://www.gnu.org/software/emacs/manual/html_node/emacs/Compilation.html#Compilation) in Emacs Manual) so the source location corresponding to an error or other message is only a few keystrokes away (<span class="kbd">C-x \`</span> for the next error, <span class="kbd">C-c C-c</span> for the error under the cursor).

<span id="index-viewing-the-documentation-of-a-word-in-Emacs"></span> <span id="index-context_002dsensitive-help"></span>

Moreover, for words documented in this manual, you can look up the glossary entry quickly by using <span class="kbd">C-h TAB</span> (`info-lookup-symbol`, see [Documentation Commands](http://www.gnu.org/software/emacs/manual/html_node/emacs/Documentation.html#Documentation) in Emacs Manual). This feature requires Emacs 20.3 or later and does not work for words containing `:`.

|                                                                                   |  |                                        |
| :-------------------------------------------------------------------------------- |  | :------------------------------------- |
| • [Installing gforth.el](Installing-gforth_002eel.html#Installing-gforth_002eel): |  | Making Emacs aware of Forth.           |
| • [Emacs Tags](Emacs-Tags.html#Emacs-Tags):                                       |  | Viewing the source of a word in Emacs. |
| • [Hilighting](Hilighting.html#Hilighting):                                       |  | Making Forth code look prettier.       |
| • [Auto-Indentation](Auto_002dIndentation.html#Auto_002dIndentation):             |  | Customizing auto-indentation.          |
| • [Blocks Files](Blocks-Files.html#Blocks-Files):                                 |  | Reading and writing blocks files.      |

-----

<div class="header">

Next: [Image Files](Image-Files.html#Image-Files), Previous: [Integrating Gforth](Integrating-Gforth.html#Integrating-Gforth), Up: [Top](index.html#Top)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
