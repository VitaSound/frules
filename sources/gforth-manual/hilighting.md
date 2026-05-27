> Source: https://gforth.org/manual/Hilighting.html

<span id="Hilighting"></span>

<div class="header">

Next: [Auto-Indentation](Auto_002dIndentation.html#Auto_002dIndentation), Previous: [Emacs Tags](Emacs-Tags.html#Emacs-Tags), Up: [Emacs and Gforth](Emacs-and-Gforth.html#Emacs-and-Gforth)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Hilighting-1"></span>

### 12.3 Hilighting

<span id="index-hilighting-Forth-code-in-Emacs"></span> <span id="index-highlighting-Forth-code-in-Emacs"></span>

`gforth.el` comes with a custom source hilighting engine. When you open a file in `forth-mode`, it will be completely parsed, assigning faces to keywords, comments, strings etc. While you edit the file, modified regions get parsed and updated on-the-fly.

Use the variable ‘forth-hilight-level’ to change the level of decoration from 0 (no hilighting at all) to 3 (the default). Even if you set the hilighting level to 0, the parser will still work in the background, collecting information about whether regions of text are “compiled” or “interpreted”. Those information are required for auto-indentation to work properly. Set ‘forth-disable-parser’ to non-nil if your computer is too slow to handle parsing. This will have an impact on the smartness of the auto-indentation engine, though.

Sometimes Forth sources define new features that should be hilighted, new control structures, defining-words etc. You can use the variable ‘forth-custom-words’ to make `forth-mode` hilight additional words and constructs. See the docstring of ‘forth-words’ for details (in Emacs, type <span class="kbd">C-h v forth-words</span>).

‘forth-custom-words’ is meant to be customized in your `.emacs` file. To customize hilighing in a file-specific manner, set ‘forth-local-words’ in a local-variables section at the end of your source file (see [Variables](http://www.gnu.org/software/emacs/manual/html_node/emacs/Local-Variables-in-Files.html#Local-Variables-in-Files) in Emacs Manual).

Example:

<div class="example">

``` example
0 [IF]
   Local Variables:
   forth-local-words:
      ((("t:") definition-starter (font-lock-keyword-face . 1)
        "[ \t\n]" t name (font-lock-function-name-face . 3))
       ((";t") definition-ender (font-lock-keyword-face . 1)))
   End:
[THEN]
```

</div>
