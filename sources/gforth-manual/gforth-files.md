> Source: https://gforth.org/manual/Gforth-Files.html

<span id="Gforth-Files"></span>

<div class="header">

Next: [Gforth in pipes](Gforth-in-pipes.html#Gforth-in-pipes), Previous: [Environment variables](Environment-variables.html#Environment-variables), Up: [Gforth Environment](Gforth-Environment.html#Gforth-Environment)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Gforth-files"></span>

### 2.5 Gforth files

<span id="index-Gforth-files"></span>

When you install Gforth on a Unix system, it installs files in these locations by default:

  - `/usr/local/bin/gforth`
  - `/usr/local/bin/gforthmi`
  - `/usr/local/man/man1/gforth.1` - man page.
  - `/usr/local/info` - the Info version of this manual.
  - `/usr/local/lib/gforth/<version>/...` - Gforth `.fi` files.
  - `/usr/local/share/gforth/<version>/TAGS` - Emacs TAGS file.
  - `/usr/local/share/gforth/<version>/...` - Gforth source files.
  - `.../emacs/site-lisp/gforth.el` - Emacs gforth mode.

You can select different places for installation by using `configure` options (listed with `configure --help`).
