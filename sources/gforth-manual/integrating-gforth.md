> Source: https://gforth.org/manual/Integrating-Gforth.html

<span id="Integrating-Gforth"></span>

<div class="header">

Next: [Emacs and Gforth](Emacs-and-Gforth.html#Emacs-and-Gforth), Previous: [Model](Model.html#Model), Up: [Top](index.html#Top)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Integrating-Gforth-into-C-programs"></span>

## 11 Integrating Gforth into C programs

Several people like to use Forth as scripting language for applications that are otherwise written in C, C++, or some other language.

The Forth system ATLAST provides facilities for embedding it into applications; unfortunately it has several disadvantages: most importantly, it is not based on Standard Forth, and it is apparently dead (i.e., not developed further and not supported). The facilities provided by Gforth in this area are inspired by ATLAST’s facilities, so making the switch should not be hard.

We also tried to design the interface such that it can easily be implemented by other Forth systems, so that we may one day arrive at a standardized interface. Such a standard interface would allow you to replace the Forth system without having to rewrite C code.

You embed the Gforth interpreter by linking with the library `libgforth.a` or `libgforth.so` (give the compiler the option `-lgforth`, or for one of the other engines `-lgforth-fast`, `-lgforth-itc`, or `-lgforth-ditc`). All global symbols in this library that belong to the interface, have the prefix `gforth_`; if a common interface emerges, the functions may also be available through `#define`s with the prefix `forth_`.

You can include the declarations of Forth types, the functions and variables of the interface with `#include <gforth.h>`.

You can now run a Gforth session by either calling `gforth_main` or using the components:

<div class="example">

``` example
Cell gforth_main(int argc, char **argv, char **env)
{
  Cell retvalue=gforth_start(argc, argv);

  if(retvalue == -56) { /* throw-code for quit */
    gforth_setwinch();        // set winch signal handler
    gforth_bootmessage();     // show boot message
    retvalue = gforth_quit(); // run quit loop
  }
  gforth_cleanup();
  gforth_printmetrics();
  // gforth_free_dict(); // if you want to restart, do this

  return retvalue;
}
```

</div>

To interact with the Forth interpreter, there’s `Xt gforth_find(Char * name)` and `Cell gforth_execute(Xt xt)`.

More documentation needs to be put here.

<span id="Types-1"></span>

### 11.1 Types

`Cell`, `UCell`: data stack elements.

`Float`: float stack element.

`Address`, `Xt`, `Label`: pointer typies to memory, Forth words, and Forth instructions inside the VM.

<span id="Variables-2"></span>

### 11.2 Variables

Data and FP Stack pointer. Area sizes. Accessing the Stacks

`gforth_SP`, `gforth_FP`.

<span id="Functions"></span>

### 11.3 Functions

<div class="example">

``` example
void *gforth_engine(Xt *, stackpointers *);
Cell gforth_main(int argc, char **argv, char **env);
int gforth_args(int argc, char **argv, char **path, char **imagename);
ImageHeader* gforth_loader(char* imagename, char* path);
user_area* gforth_stacks(Cell dsize, Cell rsize, Cell fsize, Cell lsize);
void gforth_free_stacks(user_area* t);
void gforth_setstacks(user_area * t);
void gforth_free_dict();
Cell gforth_go(Xt* ip0);
Cell gforth_boot(int argc, char** argv, char* path);
void gforth_bootmessage();
Cell gforth_start(int argc, char ** argv);
Cell gforth_quit();
Xt gforth_find(Char * name);
Cell gforth_execute(Xt xt);
void gforth_cleanup();
void gforth_printmetrics();
void gforth_setwinch();
```

</div>

<span id="Signals"></span>

### 11.4 Signals

Gforth sets up signal handlers to catch exceptions and window size changes. This may interfere with your C program.

-----

<div class="header">

Next: [Emacs and Gforth](Emacs-and-Gforth.html#Emacs-and-Gforth), Previous: [Model](Model.html#Model), Up: [Top](index.html#Top)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>
