> Source: https://gforth.org/manual/Classes-and-Scoping.html

<span id="Classes-and-Scoping"></span>

<div class="header">

Next: [Dividing classes](Dividing-classes.html#Dividing-classes), Previous: [Method conveniences](Method-conveniences.html#Method-conveniences), Up: [Objects](Objects.html#Objects)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Classes-and-Scoping-1"></span>

#### 5.23.3.8 Classes and Scoping

<span id="index-classes-and-scoping"></span> <span id="index-scoping-and-classes"></span>

Inheritance is frequent, unlike structure extension. This exacerbates the problem with the field name convention (see [Structure Naming Convention](Structure-Naming-Convention.html#Structure-Naming-Convention)): One always has to remember in which class the field was originally defined; changing a part of the class structure would require changes for renaming in otherwise unaffected code.

<span id="index-inst_002dvar-visibility"></span> <span id="index-inst_002dvalue-visibility"></span>

To solve this problem, I added a scoping mechanism (which was not in my original charter): A field defined with `inst-var` (or `inst-value`) is visible only in the class where it is defined and in the descendent classes of this class. Using such fields only makes sense in `m:`-defined methods in these classes anyway.

This scoping mechanism allows us to use the unadorned field name, because name clashes with unrelated words become much less likely.

<span id="index-protected-discussion"></span> <span id="index-private-discussion"></span>

Once we have this mechanism, we can also use it for controlling the visibility of other words: All words defined after `protected` are visible only in the current class and its descendents. `public` restores the compilation (i.e. `current`) word list that was in effect before. If you have several `protected`s without an intervening `public` or `set-current`, `public` will restore the compilation word list in effect before the first of these `protected`s.
