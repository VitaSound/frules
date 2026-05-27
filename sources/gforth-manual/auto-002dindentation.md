> Source: https://gforth.org/manual/Auto_002dIndentation.html

<span id="Auto_002dIndentation"></span>

<div class="header">

Next: [Blocks Files](Blocks-Files.html#Blocks-Files), Previous: [Hilighting](Hilighting.html#Hilighting), Up: [Emacs and Gforth](Emacs-and-Gforth.html#Emacs-and-Gforth)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Auto_002dIndentation-1"></span>

### 12.4 Auto-Indentation

<span id="index-auto_002dindentation-of-Forth-code-in-Emacs"></span> <span id="index-indentation-of-Forth-code-in-Emacs"></span>

`forth-mode` automatically tries to indent lines in a smart way, whenever you type `TAB` or break a line with <span class="kbd">C-m</span>.

Simple customization can be achieved by setting ‘forth-indent-level’ and ‘forth-minor-indent-level’ in your `.emacs` file. For historical reasons `gforth.el` indents per default by multiples of 4 columns. To use the more traditional 3-column indentation, add the following lines to your `.emacs`:

<div class="example">

``` example
(add-hook 'forth-mode-hook (function (lambda ()
   ;; customize variables here:
   (setq forth-indent-level 3)
   (setq forth-minor-indent-level 1)
)))
```

</div>

If you want indentation to recognize non-default words, customize it by setting ‘forth-custom-indent-words’ in your `.emacs`. See the docstring of ‘forth-indent-words’ for details (in Emacs, type <span class="kbd">C-h v forth-indent-words</span>).

To customize indentation in a file-specific manner, set ‘forth-local-indent-words’ in a local-variables section at the end of your source file (see [Variables](http://www.gnu.org/software/emacs/manual/html_node/emacs/Local-Variables-in-Files.html#Local-Variables-in-Files) in Emacs Manual).

Example:

<div class="example">

``` example
0 [IF]
   Local Variables:
   forth-local-indent-words:
      ((("t:") (0 . 2) (0 . 2))
       ((";t") (-2 . 0) (0 . -2)))
   End:
[THEN]
```

</div>
