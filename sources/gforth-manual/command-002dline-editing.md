> Source: https://gforth.org/manual/Command_002dline-editing.html

<span id="Command_002dline-editing"></span>

<div class="header">

Next: [Environment variables](Environment-variables.html#Environment-variables), Previous: [Leaving Gforth](Leaving-Gforth.html#Leaving-Gforth), Up: [Gforth Environment](Gforth-Environment.html#Gforth-Environment)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Command_002dline-editing-1"></span>

### 2.3 Command-line editing

<span id="index-command_002dline-editing"></span>

Gforth maintains a history file that records every line that you type to the text interpreter. This file is preserved between sessions, and is used to provide a command-line recall facility; if you type <span class="kbd">Ctrl-P</span> repeatedly you can recall successively older commands from this (or previous) session(s). The full list of command-line editing facilities is:

  - <span class="kbd">Ctrl-p</span> (“previous”) (or up-arrow) to recall successively older commands from the history buffer.
  - <span class="kbd">Ctrl-n</span> (“next”) (or down-arrow) to recall successively newer commands from the history buffer.
  - <span class="kbd">Ctrl-f</span> (or right-arrow) to move the cursor right, non-destructively.
  - <span class="kbd">Ctrl-b</span> (or left-arrow) to move the cursor left, non-destructively.
  - <span class="kbd">Ctrl-h</span> (backspace) to delete the character to the left of the cursor, closing up the line.
  - <span class="kbd">Ctrl-k</span> to delete (“kill”) from the cursor to the end of the line.
  - <span class="kbd">Ctrl-a</span> to move the cursor to the start of the line.
  - <span class="kbd">Ctrl-e</span> to move the cursor to the end of the line.
  - `RET` (<span class="kbd">Ctrl-m</span>) or `LFD` (<span class="kbd">Ctrl-j</span>) to submit the current line.
  - `TAB` to step through all possible full-word completions of the word currently being typed.
  - <span class="kbd">Ctrl-d</span> on an empty line line to terminate Gforth (gracefully, using `bye`).
  - <span class="kbd">Ctrl-x</span> (or `Ctrl-d` on a non-empty line) to delete the character under the cursor.

When editing, displayable characters are inserted to the left of the cursor position; the line is always in “insert” (as opposed to “overstrike”) mode.

<span id="index-history-file"></span> <span id="index-_002egforth_002dhistory"></span>

On Unix systems, the history file is `~/.gforth-history` by default[<sup>2</sup>](#FOOT2). You can find out the name and location of your history file using:

<div class="example">

``` example
history-file type \ Unix-class systems

history-file type \ Other systems
history-dir  type
```

</div>

If you enter long definitions by hand, you can use a text editor to paste them out of the history file into a Forth source file for reuse at a later time.

Gforth never trims the size of the history file, so you should do this periodically, if necessary.

<div class="footnote">

-----

#### Footnotes

### [(2)](#DOCF2)

i.e. it is stored in the user’s home directory.

</div>

-----

<div class="header">

Next: [Environment variables](Environment-variables.html#Environment-variables), Previous: [Leaving Gforth](Leaving-Gforth.html#Leaving-Gforth), Up: [Gforth Environment](Gforth-Environment.html#Gforth-Environment)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
