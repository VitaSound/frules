> Source: https://gforth.org/manual/Emacs-Tags.html

<span id="Emacs-Tags"></span>

<div class="header">

Next: [Hilighting](Hilighting.html#Hilighting), Previous: [Installing gforth.el](Installing-gforth_002eel.html#Installing-gforth_002eel), Up: [Emacs and Gforth](Emacs-and-Gforth.html#Emacs-and-Gforth)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Emacs-Tags-1"></span>

### 12.2 Emacs Tags

<span id="index-TAGS-file"></span> <span id="index-etags_002efs"></span> <span id="index-viewing-the-source-of-a-word-in-Emacs"></span> <span id="index-require_002c-placement-in-files"></span> <span id="index-include_002c-placement-in-files"></span>

If you `require` `etags.fs`, a new `TAGS` file will be produced (see [Tags Tables](http://www.gnu.org/software/emacs/manual/html_node/emacs/Tags.html#Tags) in Emacs Manual) that contains the definitions of all words defined afterwards. You can then find the source for a word using <span class="kbd">M-.</span>. Note that Emacs can use several tags files at the same time (e.g., one for the Gforth sources and one for your program, see [Selecting a Tags Table](http://www.gnu.org/software/emacs/manual/html_node/emacs/Select-Tags-Table.html#Select-Tags-Table) in Emacs Manual). The TAGS file for the preloaded words is `$(datadir)/gforth/$(VERSION)/TAGS` (e.g., `/usr/local/share/gforth/0.2.0/TAGS`). To get the best behaviour with `etags.fs`, you should avoid putting definitions both before and after `require` etc., otherwise you will see the same file visited several times by commands like `tags-search`.
