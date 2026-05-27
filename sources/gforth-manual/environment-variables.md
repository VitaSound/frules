> Source: https://gforth.org/manual/Environment-variables.html

<span id="Environment-variables"></span>

<div class="header">

Next: [Gforth Files](Gforth-Files.html#Gforth-Files), Previous: [Command-line editing](Command_002dline-editing.html#Command_002dline-editing), Up: [Gforth Environment](Gforth-Environment.html#Gforth-Environment)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Environment-variables-1"></span>

### 2.4 Environment variables

<span id="index-environment-variables"></span>

Gforth uses these environment variables:

  - <span id="index-GFORTHHIST-_002d_002d-environment-variable"></span> `GFORTHHIST` – (Unix systems only) specifies the path for the history file `.gforth-history`. Default: `$HOME/.gforth-history`.
  - <span id="index-GFORTHPATH-_002d_002d-environment-variable"></span> `GFORTHPATH` – specifies the path used when searching for the gforth image file and for Forth source-code files (usually ‘`.`’, the current working directory). Path separator is ‘`:`’, a typical path would be `/usr/local/share/gforth/0.8.0:.`.
  - <span id="index-LANG-_002d_002d-environment-variable"></span> `LANG` – see `LC_CTYPE`
  - <span id="index-LC_005fALL-_002d_002d-environment-variable"></span> `LC_ALL` – see `LC_CTYPE`
  - <span id="index-LC_005fCTYPE-_002d_002d-environment-variable"></span> `LC_CTYPE` – If this variable contains “UTF-8” on Gforth startup, Gforth uses the UTF-8 encoding for strings internally and expects its input and produces its output in UTF-8 encoding, otherwise the encoding is 8bit (see see [Xchars and Unicode](Xchars-and-Unicode.html#Xchars-and-Unicode)). If this environment variable is unset, Gforth looks in `LC_ALL`, and if that is unset, in `LANG`.
  - <span id="index-GFORTHSYSTEMPREFIX-_002d_002d-environment-variable"></span> `GFORTHSYSTEMPREFIX` – specifies what to prepend to the argument of `system` before passing it to C’s `system()`. Default: `"./$COMSPEC /c "` on Windows, `""` on other OSs. The prefix and the command are directly concatenated, so if a space between them is necessary, append it to the prefix.
  - <span id="index-GFORTH-_002d_002d-environment-variable"></span> `GFORTH` – used by `gforthmi`, See [gforthmi](gforthmi.html#gforthmi).
  - <span id="index-GFORTHD-_002d_002d-environment-variable"></span> `GFORTHD` – used by `gforthmi`, See [gforthmi](gforthmi.html#gforthmi).
  - <span id="index-TMP_002c-TEMP-_002d-environment-variable"></span> `TMP`, `TEMP` - (non-Unix systems only) used as a potential location for the history file.

All the Gforth environment variables default to sensible values if they are not set.
