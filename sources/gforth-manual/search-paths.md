> Source: https://gforth.org/manual/Search-Paths.html

<span id="Search-Paths"></span>

<div class="header">

Previous: [Directories](Directories.html#Directories), Up: [Files](Files.html#Files)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Search-Paths-1"></span>

#### 5.17.5 Search Paths

<span id="index-path-for-included"></span> <span id="index-file-search-path"></span> <span id="index-include-search-path"></span> <span id="index-search-path-for-files"></span>

If you specify an absolute filename (i.e., a filename starting with `/` or `~`, or with `:` in the second position (as in ‘`C:...`’)) for `included` and friends, that file is included just as you would expect.

If the filename starts with `./`, this refers to the directory that the present file was `included` from. This allows files to include other files relative to their own position (irrespective of the current working directory or the absolute position). This feature is essential for libraries consisting of several files, where a file may include other files from the library. It corresponds to `#include "..."` in C. If the current input source is not a file, `.` refers to the directory of the innermost file being included, or, if there is no file being included, to the current working directory.

For relative filenames (not starting with `./`), Gforth uses a search path similar to Forth’s search order (see [Word Lists](Word-Lists.html#Word-Lists)). It tries to find the given filename in the directories present in the path, and includes the first one it finds. There are separate search paths for Forth source files and general files. If the search path contains the directory `.`, this refers to the directory of the current file, or the working directory, as if the file had been specified with `./`.

Use `~+` to refer to the current working directory (as in the `bash`).

|                                                                           |  |  |
| :------------------------------------------------------------------------ |  | :- |
| • [Source Search Paths](Source-Search-Paths.html#Source-Search-Paths):    |  |  |
| • [General Search Paths](General-Search-Paths.html#General-Search-Paths): |  |  |

-----

<div class="header">

Previous: [Directories](Directories.html#Directories), Up: [Files](Files.html#Files)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
